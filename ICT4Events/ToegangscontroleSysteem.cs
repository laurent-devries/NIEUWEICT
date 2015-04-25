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
        private bool scanned = false;
        RFID rfid = new RFID();
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
                    btnStartScanner.Text = "Herstart scanner";
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
        }

        public void rfid_Tag(object sender, TagEventArgs e)
        {
            scanned = true;
            UserManager dataCollect = new UserManager();
            if (scanned == true)
            {
            }
            else
            {
            }
        }
    }
}
