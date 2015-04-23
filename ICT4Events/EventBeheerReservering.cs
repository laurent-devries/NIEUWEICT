﻿using Oracle.ManagedDataAccess.Client;
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
        List<Reservation> reservations = null;
        EventManager Event = new EventManager();
        UserManager Users = new UserManager();
        ReservationManager Reservation = new ReservationManager();
        public EventBeheerReservering()
        {
            InitializeComponent();
            lists();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_nieuwe_gebruiker_Click(object sender, EventArgs e)
        {
            cB_Event_ID_User.Enabled = true;
            btn_changeuser.Enabled = false;
            btn_verwijder_gebruiker.Enabled = false;
        }

        private void btn_create_gebruiker_Click(object sender, EventArgs e)
        {
            gb_gebruikercreatie.Enabled = false;
            cB_Event_ID_User.Enabled = false;

            if (btn_nieuwe_gebruiker.Enabled)
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
                conn.InsertOrUpdate("INSERT INTO ICT4_USER (id_user,id_eventFK,id_reservationFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser) VALUES(USER_SEQ.NEXTVAL," + cB_Event_ID_User.Text + "," + cB_Reservation_ID_User.Text + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N')");
            }
            if (btn_changeuser.Enabled)
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
                bool trueorfalse = false;
                foreach (User user in userList)
                {

                    if (user.ToString() == Listb_gebruikers.GetItemText(Listb_gebruikers.SelectedItem) && trueorfalse == false)
                    {
                        string querry = "UPDATE ICT4_USER SET FIRSTNAME = '" + tb_voornaam_gebruiker.Text + "', SURNAME = '" + tb_achternaam_user.Text + "', BIRTHDATE = to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY'), EMAIL = '" + tb_email_gebruiker.Text + "', COUNTRY = '" + cb_land_gebruiker.Text + "', STREET = '" + tb_straat_user + "', HOUSENUMBER = '" + tb_number_user.Text + "', CITY = '" + tb_stad_user.Text + "', CELLPHONENUMBER = '" + tb_telnr_gebruiker.Text + "', LOGINNAME = '" + tb_loginname_gebruiker.Text + "', USERNAME = '" + tb_username_gebruiker.Text + "', PASSWORDUSER ='" + tb_password_gebruiker.Text + "' WHERE ID_USER = " + Convert.ToString(user.ID_User);
                        MessageBox.Show(querry);
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
            if (btn_verwijder_gebruiker.Enabled)
            {
                bool trueorfalse = false;
                foreach (User user in userList)
                {
                    if (user.ToString() == Listb_gebruikers.GetItemText(Listb_gebruikers.SelectedItem) && trueorfalse == false)
                    {
                        DatabaseConnection conn = new DatabaseConnection();
                        string querry = "DELETE FROM ICT4_USER WHERE ID_USER = " + user.ID_User;
                        MessageBox.Show(querry);
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
                //  conn.InsertOrUpdate("UPDATE ICT4_USER SET (id_user,id_eventFK,id_reservationFK,id_permissionFK,firstName,surName,birthDate,email,country,street,houseNumber,city,cellphoneNumber,loginName,userName,passwordUser,profilePic,summaryUser,presentUser) VALUES(USER_SEQ.NEXTVAL," + Convert.ToInt32(cB_Event_ID_User.Text) + "," + Convert.ToInt32(cB_Reservation_ID_User.Text) + "," + 1 + ",'" + tb_voornaam_gebruiker.Text + "','" + tb_achternaam_user.Text + "', to_date('" + dag + maand + Convert.ToString(dtp_geboortedatum_gebruiker.Value.Year) + "','DDMMYYYY') ,'" + tb_email_gebruiker.Text + "','" + cb_land_gebruiker.Text + "','" + tb_straat_user.Text + "','" + tb_number_user.Text + "','" + tb_stad_user.Text + "','" + tb_telnr_gebruiker.Text + "','" + tb_loginname_gebruiker.Text + "','" + tb_username_gebruiker.Text + "','" + tb_password_gebruiker.Text + "','C:/','No Summary','N')");

            }
            lists();
            btn_nieuwe_gebruiker.Enabled = true;
            btn_verwijder_gebruiker.Enabled = true;
            btn_changeuser.Enabled = true;
            userclear();
        }
        private void lists()
        {
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
                foreach (Event event1 in evenementen)
                {
                    Listb_Events.Items.Add(event1.ToString());
                    cB_Event_ID_User.Items.Add(event1.ID_Event);
                    cb_showusersonevent.Items.Add(event1.ID_Event);
                }
            }
        }
        private void userclear()
        {
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
        private void cB_Event_ID_User_TextChanged(object sender, EventArgs e)
        {
            List<string> liststring = new List<string>();
            gb_gebruikercreatie.Enabled = true;
            int eventid;
            try
            {

                bool succes = int.TryParse(cB_Event_ID_User.Text, out eventid);
                if (succes)
                {
                    cB_Reservation_ID_User.Items.Clear();
                    liststring = Reservation.RequestReservationsInfo(eventid);
                    foreach (string tekst in liststring)
                    {
                        string[] teksten = tekst.Split(':');
                        cB_Reservation_ID_User.Items.Add(teksten[0]);
                    }
                }
                else
                {
                    MessageBox.Show("Het is niet gelukt om de reservaties op te halen.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("error");
            }
            cB_Reservation_ID_User.Enabled = true;
        }
        private void btn_verwijder_gebruiker_Click(object sender, EventArgs e)
        {
            cB_Event_ID_User.Enabled = true;
            btn_changeuser.Enabled = false;
            btn_nieuwe_gebruiker.Enabled = false;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            lists();
            userclear();
            gb_gebruikercreatie.Enabled = false;
        }
        private void btn_create_event_Click_1(object sender, EventArgs e)
        {
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
            string querry = "INSERT INTO (ID_EVENT, TITLE, STARTDATE,ENDDATE,CAMPINGNAME,LOCATION) VALUES (event_seq,'" + Event_Title.Text + "',to_date('" + startday + startmonth + Convert.ToString(Event_Start_Date.Value.Year) + "','DDMMYYYY'),to_date('" + endday + endmonth + Event_End_Date.Value.Year + "','DDMMYYYY')";
            conn.InsertOrUpdate(querry);
        }
        private void btn_show_users_Click(object sender, EventArgs e)
        {
            lb_show_user_on_event.Items.Clear();
            DatabaseConnection conn = new DatabaseConnection();
            string querry = "select u.ID_USER, u.FIRSTNAME, u.SURNAME, u.PRESENTUSER FROM ICT4_USER u, ICT4_EVENT e WHERE e.ID_EVENT = u.ID_EVENTFK and u.ID_EVENTFK = " + Convert.ToInt32(cb_showusersonevent.Text);
            OracleDataReader reader = conn.SelectFromDatabase(querry);
            while (reader.Read())
            {
                lb_show_user_on_event.Items.Add("ID: " + Convert.ToString(reader.GetInt32(0)) + "\t" + "naam: " + reader.GetString(1) + " " + reader.GetString(2) + "  \t\t" + "present: " + reader.GetString(3));
            }
        }
        private void btn_printlistusers_Click(object sender, EventArgs e)
        {
            // deze button moet een lijst uitprinten van alle users op het event.
            // deze is nog niet uitgewerkt.
            FileStream file;
            StreamWriter writer;
            try
            {
                file = new FileStream("C:/Users/Yoeri/Desktop/Logbestand.txt", FileMode.Create, FileAccess.Write);
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
    }
}
