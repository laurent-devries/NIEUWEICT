using System;
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
    public partial class FirstTimeLogin : Form
    {
        User user;
        public FirstTimeLogin(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btn_Confirm_user_Click(object sender, EventArgs e)
        {
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
            string Query = "UPDATE ICT4_USER SET FIRSTNAME = '" + tb_voornaam_gebruiker.Text + " ', SURNAME = '" + tb_achternaam_user.Text + "', birthDate = to_date('" + dag + maand + dtp_geboortedatum_gebruiker.Value.Year + "', 'DDMMYYYY'), email = '" + tb_email_gebruiker.Text + "', country = '" + cb_land_gebruiker.Text + "', street = '" + tb_straat_user.Text + "', housenumber = '" + tb_number_user.Text + "', city = '" + tb_stad_user.Text + "', CELLPHONENUMBER = '" + tb_telnr_gebruiker.Text + "', loginName = '" + tb_loginname_gebruiker.Text + "', userName = '" + tb_username_gebruiker.Text + "', passwordUser = '" + tb_password_gebruiker.Text + "' WHERE id_user = " + user.ID_User;
            conn.InsertOrUpdate(Query);
            
        }
    }
}
