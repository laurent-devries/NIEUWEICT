using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events
{
    public partial class EventBeheerReservering : Form
    {

        List<Event> evenementen = null;
        List<User> userList = null;
        List<CampingPlace> campingplaatslijst = null;
        EventManager Event = new EventManager();
        UserManager Users = new UserManager();
        ReservationManager Reservation = new ReservationManager();
        public EventBeheerReservering()
        {
            InitializeComponent();
            lists();
        }
        private void lists()
        {
            // Refresht alle lijsten en alle benodigdheden
            evenementen = Event.RequestEvent();
            userList = Users.RequestUsers();

            if (userList != null)
            {
                Listb_gebruikers.Items.Clear();
                foreach (User user in userList)
                {
                    Listb_gebruikers.Items.Add(user.ToString());
                }
            }
            if (evenementen != null)
            {
                Listb_Events.Items.Clear();
                cB_Event_ID_User.Items.Clear();
                cb_showusersonevent.Items.Clear();
                cb_event_id_campingplaces.Items.Clear();
                foreach (Event event1 in evenementen)
                {
                    Listb_Events.Items.Add(event1.ToString());
                    cB_Event_ID_User.Items.Add(event1.Title);
                    cb_event_id_campingplaces.Items.Add(event1.Title);
                    cb_showusersonevent.Items.Add(event1.Title);
                }
            }
        }
        private void userclear()
        {
            // cleart alle input knoppen
            cB_Event_ID_User.Text = null;
            cb_land_gebruiker.Text = null;
            tb_voornaam_gebruiker.Text = null;
            tb_achternaam_user.Text = null;
            dtp_geboortedatum_gebruiker.ResetText();
            tb_email_gebruiker.Text = null;
            cB_Reservation_ID_User.Text = null;
            tb_stad_user.Text = null;
            tb_straat_user.Text = null;
            tb_number_user.Text = null;
            tb_telnr_gebruiker.Text = null;
            tb_loginname_gebruiker.Text = null;
            tb_username_gebruiker.Text = null;
            tb_password_gebruiker.Text = null;
            Event_Title.Text = null;
            Event_Start_Date.ResetText();
            Event_End_Date.ResetText();
            Event_Camping_Location.Text = null;
            Event_Camping_Name.Text = null;
            cb_event_id_campingplaces.Text = null;
            tb_eventcampingplacenumber.Text = null;
            nuD_maxpeople.Value = 1;
            cb_campingtype.Text = null;
        }
        private void btn_show_users_Click_1(object sender, EventArgs e)
        {
            // laat alle users zien op een event.
            lb_show_user_on_event.Items.Clear();
            DatabaseConnection conn = new DatabaseConnection();
            int event_ID = 0;
            foreach (Event event1 in evenementen)
            {
                if (cb_showusersonevent.Text == event1.Title)
                {
                    event_ID = event1.ID_Event;
                }
            }
            string querry = "select u.ID_USER, u.FIRSTNAME, u.SURNAME, u.PRESENTUSER, r.PAYMENTSTATE FROM ICT4_USER u, ICT4_EVENT e , ICT4_RESERVATION r WHERE e.ID_EVENT = u.ID_EVENTFK and r.ID_RESERVATION = u.ID_RESERVATIONFK and u.ID_EVENTFK = " + event_ID.ToString();
            OracleDataReader reader = conn.SelectFromDatabase(querry);
            while (reader.Read())
            {
                lb_show_user_on_event.Items.Add("ID: " + Convert.ToString(reader.GetInt32(0)) + "\t" + "naam: " + reader.GetString(1) + " " + reader.GetString(2) + "      \t\t" + "present: " + reader.GetString(3) + "\t Paymentstate: " + reader.GetString(4));
            }
        }

        private void btn_printlistusers_Click_1(object sender, EventArgs e)
        {
            // als deze button wordt ingedrukt zal er een lijst op je bureaublad komen te staan.
            FileStream file;
            StreamWriter writer;
            try
            {
                file = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "/Logbestand.txt", FileMode.Create, FileAccess.Write);
                writer = new StreamWriter(file);
                foreach (string tekst in lb_show_user_on_event.Items)
                {
                    writer.WriteLine(tekst);
                }
                MessageBox.Show("The userlist on the event has been placed on you desktop.");

                writer.Close();
                file.Close();
            }
            catch (IOException)
            {
                MessageBox.Show("Something has gone wrong.");
            }
        }

        private void btn_create_event_Click(object sender, EventArgs e)
        {
            if (btn_new_event.Enabled)
            {
                // creeërt een event met de meegegeven gegevens
                DatabaseConnection conn = new DatabaseConnection();
                string startmonth;
                if (Event_Start_Date.Value.Month < 10)
                {
                    startmonth = "0" + Convert.ToString(Event_Start_Date.Value.Month);
                }
                else
                {
                    startmonth = Convert.ToString(Event_Start_Date.Value.Month);
                }
                string startday;
                if (Event_Start_Date.Value.Day < 10)
                {
                    startday = "0" + Convert.ToString(Event_Start_Date.Value.Day);
                }
                else
                {
                    startday = Convert.ToString(Event_Start_Date.Value.Day);
                }
                string endmonth;
                if (Event_End_Date.Value.Month < 10)
                {
                    endmonth = "0" + Convert.ToString(Event_End_Date.Value.Month);
                }
                else
                {
                    endmonth = Convert.ToString(Event_End_Date.Value.Month);
                }
                string endday;
                if (Event_Start_Date.Value.Day < 10)
                {
                    endday = "0" + Convert.ToString(Event_End_Date.Value.Day);
                }
                else
                {
                    endday = Convert.ToString(Event_End_Date.Value.Day);
                }
                string querry = "INSERT INTO ICT4_EVENT (ID_EVENT, TITLE, DateICT, STARTDATE, ENDDATE, CAMPINGNAME, LOCATION) VALUES (EVENT_SEQ.NEXTVAL,'" + Event_Title.Text + "', sysdate, to_date('" + startday + startmonth + Convert.ToString(Event_Start_Date.Value.Year) + "','DDMMYYYY'), to_date('" + endday + endmonth + Convert.ToString(Event_End_Date.Value.Year) + "','DDMMYYYY'),'" + Event_Camping_Name.Text + "','" + Event_Camping_Location.Text + "')";
                if (conn.InsertOrUpdate(querry))
                {
                    MessageBox.Show("The event has been created!");
                }
                else
                {
                    MessageBox.Show("Make sure you have filled everything in right! Event Title can't already exist!");
                }
            }
            if (btn_change_event.Enabled)
            {
                // Verander het event naar de meegegeven gegevens
                DatabaseConnection conn = new DatabaseConnection();
                string startmonth;
                if (Event_Start_Date.Value.Month < 10)
                {
                    startmonth = "0" + Convert.ToString(Event_Start_Date.Value.Month);
                }
                else
                {
                    startmonth = Convert.ToString(Event_Start_Date.Value.Month);
                }
                string startday;
                if (Event_Start_Date.Value.Day < 10)
                {
                    startday = "0" + Convert.ToString(Event_Start_Date.Value.Day);
                }
                else
                {
                    startday = Convert.ToString(Event_Start_Date.Value.Day);
                }
                string endmonth;
                if (Event_End_Date.Value.Month < 10)
                {
                    endmonth = "0" + Convert.ToString(Event_End_Date.Value.Month);
                }
                else
                {
                    endmonth = Convert.ToString(Event_End_Date.Value.Month);
                }
                string endday;
                if (Event_Start_Date.Value.Day < 10)
                {
                    endday = "0" + Convert.ToString(Event_End_Date.Value.Day);
                }
                else
                {
                    endday = Convert.ToString(Event_End_Date.Value.Day);
                }
                bool trueorfalse = false;
                foreach (Event event1 in evenementen)
                {
                    if (event1.ToString() == Listb_Events.GetItemText(Listb_Events.SelectedItem) && trueorfalse == false)
                    {
                        string querry = "UPDATE ICT4_EVENT SET title = '" + Event_Title.Text + "', startDate = to_date('" + startday + startmonth + Convert.ToString(Event_Start_Date.Value.Year) + "','DDMMYYYY'), endDate= to_date('" + endday + endmonth + Convert.ToString(Event_End_Date.Value.Year) + "','DDMMYYYY'), campingName = '" + Event_Camping_Name.Text + "', location = '" + Event_Camping_Location.Text + "'WHERE ID_EVENT = " + Convert.ToString(event1.ID_Event);

                        bool succes = conn.InsertOrUpdate(querry);
                        if (succes)
                        {
                            MessageBox.Show("The event has been succesfully updated!");
                        }
                        else
                        {
                            MessageBox.Show("Something has gone wrong. Did you fill in everything you need?");
                        }
                        trueorfalse = true;
                    }
                }
            }
            btn_change_event.Enabled = true;
            btn_create_event.Enabled = true;
            btn_delete_event.Enabled = true;
            gb_mantain_event.Enabled = false;
            lists();
            userclear();
        }

        private void btnEventcancel_1(object sender, EventArgs e)
        {
            // Cancelt de actie
            lists();
            userclear();
            btn_new_event.Enabled = true;
            btn_change_event.Enabled = true;
            btn_delete_event.Enabled = true;
            gb_mantain_event.Enabled = false;
        }

        private void btn_new_event_Click_1(object sender, EventArgs e)
        {
            // Cancelt de actie
            lists();
            userclear();
            btn_new_event.Enabled = true;
            btn_change_event.Enabled = false;
            btn_delete_event.Enabled = false;
            gb_mantain_event.Enabled = true;
        }

        private void btn_change_event_Click_1(object sender, EventArgs e)
        {
            // activeert de functie om een event te kunnen veranderen
            btn_new_event.Enabled = false;
            btn_change_event.Enabled = true;
            btn_delete_event.Enabled = false;
            gb_mantain_event.Enabled = true;
            foreach (Event event1 in evenementen)
            {
                if (event1.ToString() == Listb_Events.GetItemText(Listb_Events.SelectedItem))
                {
                    Event_Title.Text = event1.Title;
                    Event_Start_Date.Value = event1.StartDate;
                    Event_End_Date.Value = event1.EndDate;
                    Event_Camping_Name.Text = event1.Campingname;
                    Event_Camping_Location.Text = event1.Location;
                }
            }
        }

        private void btn_delete_event_Click_1(object sender, EventArgs e)
        {
            //activeert de functie om event te kunnen verwijderen
            btn_new_event.Enabled = true;
            btn_change_event.Enabled = true;
            btn_delete_event.Enabled = true;
            bool trueorfalse = false;
            foreach (Event event1 in evenementen)
            {
                if (event1.ToString() == Listb_Events.GetItemText(Listb_Events.SelectedItem) && trueorfalse == false)
                {
                    DatabaseConnection conn = new DatabaseConnection();
                    string querry = "DELETE FROM ICT4_EVENT WHERE ID_event = " + Convert.ToString(event1.ID_Event);

                    bool succes = conn.InsertOrUpdate(querry);
                    if (succes == true)
                    {
                        MessageBox.Show("The user has been succesfully deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Something has gone wrong, make sure you have selected the user!");
                    }
                    trueorfalse = true;
                }
            }
            lists();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            //cancelt de actie
            lists();
            userclear();
            btn_nieuwe_gebruiker.Enabled = true;
            btn_verwijder_gebruiker.Enabled = true;
            btn_changeuser.Enabled = true;
            gb_gebruikercreatie.Enabled = false;
        }

        private void btn_Confirm_user_Click(object sender, EventArgs e)
        {

            gb_gebruikercreatie.Enabled = false;
            cB_Event_ID_User.Enabled = false;

            if (btn_nieuwe_gebruiker.Enabled)
            {
                // creëert nieuwe user in de database
                DatabaseConnection conn = new DatabaseConnection();
                string maand;
                if (dtp_geboortedatum_gebruiker.Value.Month < 10)
                {
                    maand = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                }
                else
                {
                    maand = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                }
                string dag;
                if (dtp_geboortedatum_gebruiker.Value.Day < 10)
                {
                    dag = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                }
                else
                {
                    dag = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                }
                int event_ID = 0;
                foreach (Event event1 in evenementen)
                {
                    if (cB_Event_ID_User.Text == event1.Title)
                    {
                        event_ID = event1.ID_Event;
                    }
                }
                bool succes = false;
                if (cB_Reservation_ID_User.Text == "New" && tB_rfid_user.Text == null)
                {

                    succes = conn.InsertOrUpdate("INSERT INTO ICT4_USER (id_user,id_eventFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser) VALUES(USER_SEQ.NEXTVAL," + event_ID.ToString() + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N')");
                }
                else if (cB_Reservation_ID_User.Text == "New" && tB_rfid_user.Text != null)
                {
                    succes = conn.InsertOrUpdate("INSERT INTO ICT4_USER (id_user,id_eventFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser,RfidTag) VALUES(USER_SEQ.NEXTVAL," + event_ID.ToString() + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N','" + tB_rfid_user.Text + "')");
                }
                else if (tB_rfid_user.Text == null)
                {
                    succes = conn.InsertOrUpdate("INSERT INTO ICT4_USER (id_user,id_eventFK,id_reservationFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser) VALUES(USER_SEQ.NEXTVAL," + event_ID.ToString() + "," + cB_Reservation_ID_User.Text + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N')");
                }
                else
                {
                    succes = conn.InsertOrUpdate("INSERT INTO ICT4_USER (id_user,id_eventFK,id_reservationFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser, RfidTag) VALUES(USER_SEQ.NEXTVAL," + event_ID.ToString() + "," + cB_Reservation_ID_User.Text + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N','" + tB_rfid_user.Text + "')");
                }
                if (succes)
                {
                    MessageBox.Show("You have created the user");
                }
                else
                {
                    MessageBox.Show("Something has gone wrong! Make sure you have filled in everything");
                }
            }
            if (btn_changeuser.Enabled)
            {
                // verandert een user in de database
                DatabaseConnection conn = new DatabaseConnection();
                string maand;
                if (dtp_geboortedatum_gebruiker.Value.Month < 10)
                {
                    maand = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                }
                else
                {
                    maand = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Month);
                }
                string dag;
                if (dtp_geboortedatum_gebruiker.Value.Day < 10)
                {
                    dag = "0" + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                }
                else
                {
                    dag = Convert.ToString(dtp_geboortedatum_gebruiker.Value.Day);
                }
                bool trueorfalse = false;
                foreach (User user in userList)
                {

                    if (user.ToString() == Listb_gebruikers.GetItemText(Listb_gebruikers.SelectedItem) && trueorfalse == false)
                    {
                        string querry = "UPDATE ICT4_USER SET FIRSTNAME = '" + tb_voornaam_gebruiker.Text + "', SURNAME = '" + tb_achternaam_user.Text + "', BIRTHDATE = to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY'), EMAIL = '" + tb_email_gebruiker.Text + "', COUNTRY = '" + cb_land_gebruiker.Text + "', STREET = '" + tb_straat_user + "', HOUSENUMBER = '" + tb_number_user.Text + "', CITY = '" + tb_stad_user.Text + "', CELLPHONENUMBER = '" + tb_telnr_gebruiker.Text + "', LOGINNAME = '" + tb_loginname_gebruiker.Text + "', USERNAME = '" + tb_username_gebruiker.Text + "', PASSWORDUSER ='" + tb_password_gebruiker.Text + "', RfidTag = '"+tB_rfid_user.Text+"' WHERE ID_USER = " + Convert.ToString(user.ID_User);
                        bool succes = conn.InsertOrUpdate(querry);
                        if (succes)
                        {
                            MessageBox.Show("The user has been succesfully updated!");
                        }
                        else
                        {
                            MessageBox.Show("Something has gone wrong. Did you fill in everything you need?");
                        }
                        trueorfalse = true;
                    }
                }
            }
            lists();
            btn_nieuwe_gebruiker.Enabled = true;
            btn_verwijder_gebruiker.Enabled = true;
            btn_changeuser.Enabled = true;
            userclear();
        }

        private void btn_nieuwe_gebruiker_Click_1(object sender, EventArgs e)
        {
            //activeert de functie om een gebruiker aan te maken
            cB_Event_ID_User.Enabled = true;
            btn_changeuser.Enabled = false;
            btn_verwijder_gebruiker.Enabled = false;
            btnCancel.Enabled = true;

        }

        private void btn_changeuser_Click(object sender, EventArgs e)
        {
            //activeert de functie om een gebruiker te veranderen
            gb_gebruikercreatie.Enabled = true;
            cB_Event_ID_User.Enabled = false;
            cB_Reservation_ID_User.Enabled = false;
            btn_nieuwe_gebruiker.Enabled = false;
            btn_verwijder_gebruiker.Enabled = false;
            foreach (User user in userList)
            {
                if (user.ToString() == Listb_gebruikers.GetItemText(Listb_gebruikers.SelectedItem))
                {
                    cB_Reservation_ID_User.Text = user.ID_ReservationFK.ToString();
                    cb_land_gebruiker.Text = user.Country;
                    tb_voornaam_gebruiker.Text = user.First_Name;
                    tb_achternaam_user.Text = user.Sur_Name;
                    dtp_geboortedatum_gebruiker.Value = user.Birth_Date;
                    tb_email_gebruiker.Text = user.Email;

                    tb_stad_user.Text = user.City;
                    tb_straat_user.Text = user.Street;
                    tb_number_user.Text = user.Housenumber;
                    tb_telnr_gebruiker.Text = user.Phone_Number;
                    tb_loginname_gebruiker.Text = user.Login_Name;
                    tb_username_gebruiker.Text = user.Username;
                    tb_password_gebruiker.Text = "Welkom";
                }
            }
        }

        private void cB_Event_ID_User_TextChanged_1(object sender, EventArgs e)
        {
            //verandert gegevens in de combobox
            List<string> liststring = new List<string>();
            gb_gebruikercreatie.Enabled = true;
            int event_ID = 0;
            foreach (Event event1 in evenementen)
            {
                if (cB_Event_ID_User.Text == event1.Title)
                {
                    event_ID = event1.ID_Event;
                }
            }
            try
            {
                cB_Reservation_ID_User.Items.Clear();
                cB_Reservation_ID_User.Items.Add("New");
                liststring = Reservation.RequestReservationsInfo(event_ID);
                foreach (string tekst in liststring)
                {
                    string[] teksten = tekst.Split(':');
                    cB_Reservation_ID_User.Items.Add(teksten[0]);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("error");
            }
            cB_Reservation_ID_User.Enabled = true;

        }

        private void btn_verwijder_gebruiker_Click_1(object sender, EventArgs e)
        {
            // verwijdert de geselecteerde gebruiker.
            btn_changeuser.Enabled = true;
            btn_nieuwe_gebruiker.Enabled = true;
            bool trueorfalse = false;
            foreach (User user in userList)
            {
                if (user.ToString() == Listb_gebruikers.GetItemText(Listb_gebruikers.SelectedItem) && trueorfalse == false)
                {
                    DatabaseConnection conn = new DatabaseConnection();
                    string querry = "DELETE FROM ICT4_USER WHERE ID_USER = " + Convert.ToString(user.ID_User);
                    bool succes = conn.InsertOrUpdate(querry);
                    if (succes == true)
                    {
                        MessageBox.Show("The user has been succesfully deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Something has gone wrong, make sure you have selected the user!");
                    }
                    trueorfalse = true;
                }

            }
            lists();
        }

        private void cb_event_id_campingplaces_TextChanged(object sender, EventArgs e)
        {
            CampingPlaceManager mngr = new CampingPlaceManager();
            foreach (Event event1 in evenementen)
            {
                if (cb_event_id_campingplaces.Text == event1.Title)
                {
                    campingplaatslijst = mngr.RequestCampingPlaces(event1);
                }
            }

            Listb_Event_campingplaces.Items.Clear();
            foreach (CampingPlace plaats in campingplaatslijst)
            {
                Listb_Event_campingplaces.Items.Add(plaats.ToString());
            }
        }

        private void Btn_addcampingplace_Click(object sender, EventArgs e)
        {

            DatabaseConnection conn = new DatabaseConnection();
            int event_ID = 0;
            foreach (Event event1 in evenementen)
            {
                if (cb_event_id_campingplaces.Text == event1.Title)
                {
                    event_ID = event1.ID_Event;
                }
            }
            string querry = "INSERT INTO ICT4_CAMPING_PLACE (ID_CAMPINGPLACE, ID_EVENTFK, PLACENUMBER, MAXPEOPLE, CAMPINGTYPE,plaatsPositie) VALUES (camping_place_seq.NEXTVAL," + event_ID.ToString() + ",'" + tb_eventcampingplacenumber.Text + "'," + nuD_maxpeople.Value.ToString() + ",'" + cb_campingtype.Text + "','" + cB_Characteristics.Text + "')";


            bool trueorfalse = conn.InsertOrUpdate(querry);
            if (trueorfalse)
            {
                MessageBox.Show("The campingplace has been added to the event!");
            }
            else
            {
                MessageBox.Show("Somethingg has gone wrong! Make sure you have filled in everything you need!");
            }

            lists();
            userclear();
        }

        private void Btn_deletecampingplace_Click(object sender, EventArgs e)
        {
            CampingPlaceManager mngr = new CampingPlaceManager();

            foreach (CampingPlace campingplace in campingplaatslijst)
            {
                if (Listb_Event_campingplaces.GetItemText(Listb_Event_campingplaces.SelectedItem) == campingplace.ToString())
                {
                    DatabaseConnection conn = new DatabaseConnection();
                    string querry = "DELETE FROM ICT4_CAMPING_PLACE WHERE ID_CAMPINGPLACE = " + Convert.ToString(campingplace.IdCampingPlace);

                    bool succes = conn.InsertOrUpdate(querry);
                    if (succes)
                    {
                        MessageBox.Show("The campingplace has been succesfully deleted!");
                    }
                    else
                    {
                        MessageBox.Show("Something has gone wrong, make sure you have selected the campingplace!");
                    }
                }
            }
            lists();
        }
    }
}
