﻿using System;
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
    public partial class FormGathering : Form
    {
        public FormGathering()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginFormStart l = new LoginFormStart();
            l.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hiresystem h = new Hiresystem();
            h.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EventBeheerReservering E = new EventBeheerReservering();
            E.Show();
        }

        private void btnReservering_Click(object sender, EventArgs e)
        {
            ReserveringSysteem r = new ReserveringSysteem();
            r.Show();

        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            User user = new User(1, 1, 11111111, 2, "Frank", "Hartman", new DateTime(1, 1, 1), "frankhartman96@gmail.com", "Nederland", "straat", "15", "Helmond", "06-36127912", "frankhartman96", "MightyFrenkel", "hunter1", "C:/", "hoi", 'Y', "2800c48fcf");
            SocialMediaSharing s = new SocialMediaSharing(user);
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ToegangscontroleSysteem k = new ToegangscontroleSysteem();
            k.Show();
        }


    }
}
    