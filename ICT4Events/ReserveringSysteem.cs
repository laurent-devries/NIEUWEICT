using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events
{
    public partial class ReserveringSysteem : Form
    {
        private int userid;
        private int usersleft;
        private int idreservation = 0;
        public ReserveringSysteem()
        {
            InitializeComponent();
            CampingPlaceManager cpManager = new CampingPlaceManager();
            EventManager eventManager = new EventManager();
            List<Event> eventList = eventManager.RequestEvent();
            cbEvents.DataSource = eventList;
            cbEvents.Refresh();
            gbVerhuur.Enabled = false;
            gbUsers.Enabled = false;
        }

        private void cbEvents_SelectedValueChanged(object sender, EventArgs e)
        {
            Event el = cbEvents.SelectedItem as Event;
            CampingPlaceManager cpManager = new CampingPlaceManager();
            List<string> typelist = cpManager.GetCampingplaceTypes(el);
            cbSoortPlaats.DataSource = typelist;
            cbSoortPlaats.Refresh();
        }

        private void ClearUserTextboxes()
        {
            tb_voornaam_gebruiker.Text = null;
            tb_achternaam_user.Text = null;
            tb_email_gebruiker.Text = null;
            tb_loginname_gebruiker.Text = null;
            tb_number_user.Text = null;
            tb_password_gebruiker.Text = null;
            tb_stad_user.Text = null;
            tb_straat_user.Text = null;
            tb_telnr_gebruiker.Text = null;
            tb_username_gebruiker.Text = null;
        }

        private bool UserSyntax()
        {
            if (tb_email_gebruiker.Text.Contains("@") && tb_email_gebruiker.Text.Contains("."))
            {
                int parse;
                if(int.TryParse(tb_telnr_gebruiker.Text, out parse) == true)
                {
                    if(dtp_geboortedatum_gebruiker.Value < System.DateTime.Now)
                    {
                        if(tb_telnr_gebruiker.Text != "")
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("U heeft geen telefoonnummer ingevoerd. Probeer het opnieuw");
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("U heeft een ongeldige geboortedatum ingevoerd. Probeer het opniew.");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("U heeft een ongeldig telefoonnummer ingevoerd. Probeer het opnieuw.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("U heeft een ongeldig emailadress ingevoerd. Probeer het opnieuw.");
                return false;
            }
        }

        private void cbSoortPlaats_SelectedIndexChanged(object sender, EventArgs e)
        {
            Event el = cbEvents.SelectedItem as Event;
            CampingPlaceManager cpManager = new CampingPlaceManager();
            List<CampingPlace> campingPlaceList = cpManager.RequestFreeCampingPlaces(dtpAankomst.Value, dtpVertrek.Value, el, Convert.ToString(cbSoortPlaats.SelectedValue));
            cbPlaces.DataSource = campingPlaceList;
            cbPlaces.Refresh();
        }

        private void btnBevestigHuur_Click(object sender, EventArgs e)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, ID_PERMISSIONFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG FROM ICT4_USER WHERE ID_USER = " + userid;
            User user = null;
            OracleDataReader reader = con.SelectFromDatabase(Query);
            while (reader.Read())
            {
                user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
            }                   // userid           eventfk             reservationfk       permissionfk        firstname           surname                 birthdate               email               country             street              housenumber             city                celphonenumber          loginname           username                password            profilepic              summary             presentuser         rfid
            reader.Dispose();

            ProductManager productManager = new ProductManager();
            Product product = lbProducten.SelectedItem as Product;
            productManager.InsertBorrow(product, user, dtpMatriaalhuur.Value.ToString("dd-MM-yyyy"), Convert.ToInt32(nudAantalhuur.Value));
            lbGehuurd.DataSource = productManager.GetHiredProducts(user.ID_User);
            lbProducten.DataSource = productManager.availableProduct();
            lbGehuurd.Refresh();
            lbProducten.Refresh();
        }

        private void btnBevestigEvent_Click(object sender, EventArgs e)
        {
            CampingPlace c = cbPlaces.SelectedItem as CampingPlace;
            Event ev = cbEvents.SelectedItem as Event;
            if (cbPlaces.Items.Count != 0)
            {
                if (ev != null && c != null)
                {
                    if (c.MaxPeople >= nudAantal.Value)
                    {
                        if (dtpVertrek.Value > dtpAankomst.Value)
                        {
                            gb_gebruikercreatie.Enabled = true;
                            gbEvent.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("De vertrekdatum kan niet voor de aankomst datum liggen. Conterroleer beide datums en probeer het opnieuw.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("U heeft te veel mensen geselecteerd voor deze campeerplaats.");
                    }
                }
                else
                {
                    MessageBox.Show("Voer eerst alle gegevens in voordat u een account aan kunt maken.");
                }
            }
            else
            {
                MessageBox.Show("Er zijn helaas geen plaatsen meer beschikbaar voor dit evenement.");
            }
            
        }

        private void btnBevestigUser_Click(object sender, EventArgs e)
        {
            usersleft = Convert.ToInt32(nudAantal.Value) - 1;
            lblAccountsLeft.Text = usersleft.ToString();
            Event a = cbEvents.SelectedItem as Event;
            CampingPlace p = cbPlaces.SelectedItem as CampingPlace;
            {

                DatabaseConnection conn = new DatabaseConnection();
                string maand;
                string dag;
                if (UserSyntax())
                {
                    if (dtp_geboortedatum_gebruiker.Value.Month < 10)
                    {
                        maand = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                    }
                    else
                    {
                        maand = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                    }

                    if (dtp_geboortedatum_gebruiker.Value.Day < 10)
                    {
                        dag = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                    }
                    else
                    {
                        dag = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                    }

                    conn.InsertOrUpdate("insert into ICT4_RESERVATION (ID_RESERVATION, ID_EVENTFK, PAYMENTSTATE) values (RES_SEQ.NEXTVAL, " + a.ID_Event + ", 'N')");
                    OracleDataReader reader = conn.SelectFromDatabase("select MAX(ID_RESERVATION) FROM ICT4_RESERVATION");
                    

                    while (reader.Read())
                    {
                        idreservation = reader.GetInt32(0);
                    }
                    conn.InsertOrUpdate("insert into ICT4_RES_CAMPPLACE (ID_RESERVATIONFK, ID_CAMPINGPLACEFK, STARTDATE, ENDDATE) values (" + idreservation + ", '" + p.IdCampingPlace + "', '" + dtpAankomst.Value.Date.ToString("dd/MM/yyyy") + "', '" + dtpVertrek.Value.Date.ToString("dd/MM/yyyy") + "')");
                    string insertUser = "insert into ICT4_USER (ID_USER, ID_EVENTFK, ID_RESERVATIONFK, ID_PERMISSIONFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER) values (USER_SEQ.NEXTVAL, " + Convert.ToString(a.ID_Event) + ", " + idreservation + ", 1, '" + tb_voornaam_gebruiker.Text + "', '" + tb_achternaam_user.Text + "', '" + dtp_geboortedatum_gebruiker.Value.Date.ToString("dd/MM/yyyy") + "', '" + tb_email_gebruiker.Text + "', '" + cb_land_gebruiker.Text + "', '" + tb_straat_user.Text + "', '" + tb_number_user.Text + "', '" + tb_stad_user.Text + "', '" + tb_telnr_gebruiker.Text + "', '" + tb_loginname_gebruiker.Text + "', '" + tb_username_gebruiker.Text + "', '" + tb_password_gebruiker.Text + "', 'C:/', 'No Summary', 'N')";

                    OracleDataReader reader2 = conn.SelectFromDatabase("select MAX(ID_USER) FROM ICT4_USER");

                    while (reader2.Read())
                    {
                        userid = reader2.GetInt32(0);
                    }

                    conn.InsertOrUpdate(insertUser);
                    MessageBox.Show("Uw account is aangemaakt, deze is nu gereed voor gebruik op het media- en materiaalverhuursysteem. Uw reservering voor het evenement is verzonden.");
                    ClearUserTextboxes();
                    reader.Close();

                    ProductManager productManager = new ProductManager();
                    lbProducten.DataSource = productManager.availableProduct();
                    lbGehuurd.DataSource = productManager.GetHiredProducts(userid);
                    gbVerhuur.Text = "Materiaalverhuur voor gebruiker nr : " + userid;
                    gbVerhuur.Enabled = true;
                    gbEvent.Enabled = false;
                    gb_gebruikercreatie.Enabled = false;
                    if (usersleft > 0)
                    {
                        gbUsers.Enabled = true;
                    }
                }
            }
        }

        private void tb_telnr_gebruiker_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btnConfirmExtraAcc_Click(object sender, EventArgs e)
        {
            usersleft = usersleft - 1;
            if (usersleft > 0)
            {
                gbUsers.Enabled = true;
            }
            else
            {
                gbUsers.Enabled = false;
            }
            Event a = cbEvents.SelectedItem as Event;

            DatabaseConnection conn = new DatabaseConnection();
            string insert = "insert into ICT4_USER (ID_USER, ID_EVENTFK, ID_RESERVATIONFK, ID_PERMISSIONFK, LOGINNAME, PASSWORDUSER) VALUES (USER_SEQ.NEXTVAL, " + Convert.ToString(a.ID_Event) + ", " + idreservation + ", 1, '" + tbLoginEx.Text + "', '" + tbPassEx.Text + "'";
            conn.InsertOrUpdate(insert);
        }
    }
}
