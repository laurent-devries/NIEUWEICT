using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets; //voor het gebruik van RFID
using Phidgets.Events; //voor het gebruik van EVENTS (Attach etc.)
using Oracle.ManagedDataAccess.Client; 

namespace ICT4Events
{
    public partial class ToegangscontroleSysteem : Form
    {
        private bool scanned = false; // ik gebruik dit om eventueel de RFID te resete anders crashed dat schijt ding... niet verder gebruiken :)
        RFID rfid = new RFID();
        User user;
        public ToegangscontroleSysteem()
        {
            InitializeComponent();
        }

        private void btnStartScanner_Click(object sender, EventArgs e)
        {
            lblScannerToestand.Text = "Scanner is aan het scannen";
            try
            {
                if (scanned == false)
                {
                    rfid.Attach += new AttachEventHandler(rfid_Attach);
                    rfid.Detach += new DetachEventHandler(rfid_Detach);
                    rfid.Error += new ErrorEventHandler(rfid_Error);
                    rfid.Tag += new TagEventHandler(rfid_Tag);
                    rfid.open();
                }
                else
                {
                    scanned = false;
                    rfid.close();
                }
            }


            catch (PhidgetException ex)
            {
                MessageBox.Show(ex.Description);
            }

            catch (DllNotFoundException)
            {
                MessageBox.Show("Phidget Dll kan niet gevonden worden");
            }
        }

        private void rfid_Attach(object sender, AttachEventArgs e)
        {

        }
        private void rfid_Detach(object sender, DetachEventArgs e)
        {

        }

        private void rfid_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void btnStopScanner_Click(object sender, EventArgs e)
        {
            lblScannerToestand.Text = "Scanner is gestopt met scannen";
            btnStartScanner.Text = "Start scanner";
        }

        public void rfid_Tag(object sender, TagEventArgs e)
        {
            scanned = true;
            UserManager dataCollect = new UserManager();
            EventManager em = new EventManager();
            Event userEvent;
            user = dataCollect.SearchByRfid(e.Tag);
            if (user == null) // als user leeg is, dan staat de RFID niet in de database.
            {
                lblNaam.Text = "User not available";
            }
            else
            {
                lblNaam.Text = user.First_Name + " " + user.Sur_Name; //miss heb ik niet de juiste LB gebruikt maar dit kun jij veranderen. Werkt wel tooooch..
                userEvent = em.Request1Event(user.ID_EventFK.ToString());
               lblEvent.Text = userEvent.Title;

                char inFalse = Convert.ToChar("N");
                char inTrue = Convert.ToChar("Y");

                if (user.Present == inFalse)
                {
                    dataCollect.UpdateUserPresent(user.ID_User.ToString(), true);
                }
                else
                {
                    dataCollect.UpdateUserPresent(user.ID_User.ToString(), false);
                }
                
            }
        }
    }
}
