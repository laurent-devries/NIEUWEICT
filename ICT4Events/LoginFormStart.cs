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
    public partial class LoginFormStart : Form
    {
        User user;
        public LoginFormStart()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager dataUser = new UserManager();

            tbUsername.Text = "frankhartman96";
            tbPassword.Text = "hunter1";
            cbFormLoader.SelectedIndex = 0;

            string userName = tbUsername.Text;
            string password = tbPassword.Text;

            try
            {
                user = dataUser.LoginUser(userName, password);
                MessageBox.Show(user.Username);
                Permission p = new Permission();

                if (cbFormLoader.Text == "Social media")
                {
                    SocialSharing s = new SocialSharing(user);
                    this.Close();
                    s.Show();
                }
                
                else if (cbFormLoader.Text == "Event beheer")
                {
                    if (p.GetPermissionUser(user).Permission_Value >= 80)
                    {
                        EventBeheerReservering ev = new EventBeheerReservering();
                        this.Close();
                        ev.Show();
                    }

                    else
                    {
                        MessageBox.Show("Gebruiker heeft geen rechten");
                    }
                }

                else if (cbFormLoader.Text == "Materiaal verhuur")
                {
                    if (p.GetPermissionUser(user).Permission_Value >= 50)
                    {
                        Hiresystem h = new Hiresystem();
                        this.Close();
                        h.Show();
                    }

                    else
                    {
                        MessageBox.Show("Gebruiker heeft geen rechten");
                    }
                }
            }

            catch (Exception)
            {
                
            }
            

          
        }
    }
}
