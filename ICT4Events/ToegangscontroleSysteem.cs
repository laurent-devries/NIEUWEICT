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
        private bool scanned = false; //wordt gebruikt voor het resetten van de RFID Scanner
        RFID rfid = new RFID();
        User user;
        public ToegangscontroleSysteem()
        {
            InitializeComponent();
        }

        //functie voor het starten van de scanner
        //Wanneer er niet gescand wordt zal er gescand gaan worden
        private void btnStartScanner_Click(object sender, EventArgs e)
        {
            lblScannerToestand.Text = "Scanner is aan het scannen";
            try
            {
                if (scanned == false)
                {
                    
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

      

        private void rfid_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void btnStopScanner_Click(object sender, EventArgs e)
        {
            //reset de labels naar de standaardwaarde;
            lblScannerToestand.Text = "Scanner is gestopt met scannen";
            btnStartScanner.Text = "Start scanner";
            lblEvent.Text = "Event: ";
            lblHeeftBetaald.Text = "Betaald: ";
            lblInOfUitgecheckt.Text = "";
            lblNaam.Text = "Naam: ";
            lblReservering.Text = "Reservering: ";
            rfid.close();           
        }

        //ontvang informatie van de RFID tag
        public void rfid_Tag(object sender, TagEventArgs e)
        {
            scanned = true;
            UserManager dataCollect = new UserManager();
            EventManager em = new EventManager();
            Event userEvent;
            ReservationManager rm = new ReservationManager();

            user = dataCollect.SearchByRfid(e.Tag);
            if (user == null) // als user leeg is, dan staat de RFID niet in de database.
            {
                lblNaam.Text = "User not available";
            }
            else
            {
                lblNaam.Text = "Naam: " + user.First_Name + " " + user.Sur_Name; 
                userEvent = em.Request1Event(user.ID_EventFK.ToString());
                lblEvent.Text = "Event: " + userEvent.Title;
                
                char inFalse = Convert.ToChar("N");
                char inTrue = Convert.ToChar("Y");
                string payed = rm.ReservationPayed(user.ID_User.ToString());
                lblHeeftBetaald.Text = "Betaald: " + payed;


                if (user.Present == inFalse)
                {
                    dataCollect.UpdateUserPresent(user.ID_User.ToString(), true);
                    lblInOfUitgecheckt.Text = "Ingecheckt";
                }
                else
                {
                    dataCollect.UpdateUserPresent(user.ID_User.ToString(), false);
                    lblInOfUitgecheckt.Text = "Uitgecheckt";
                }
                
            }
        }
    }
}
