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
    public partial class Hiresystem : Form
    {
        List<Product> producten;
        RFID rfid = new RFID(); //RFID object
        private bool scanned = false;
        User user;

        public Hiresystem()
        {
            InitializeComponent();
            LoadProducts();
            availableProduct();
        }

        private void bttnEnableRFID_Click(object sender, EventArgs e)
        {
            try
            {
                if (scanned == false)
                {
                    rfid.Attach += new AttachEventHandler(rfid_Attach);
                    rfid.Detach += new DetachEventHandler(rfid_Detach);
                    rfid.Error += new ErrorEventHandler(rfid_Error);
                    rfid.Tag += new TagEventHandler(rfid_Tag);
                    rfid.open();
                    bttnEnableRFID.Text = "Restart";
                    //rfid.Antenna = true;
                    //rfid.LED = true;
                }
                else
                {
                    RFIDtext.Text = "";
                    scanned = false;
                    rfid.close();
                  //  rfid.Antenna = false;
                   // rfid.LED = false;
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
            lblconnectedInfo.Text = "connected";
            lblserialInfo.Text = e.Device.SerialNumber.ToString();

        }
        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            lblconnectedInfo.Text = "disconnected";
            lblserialInfo.Text = "--";
            //scanned = false;
        }

        public void rfid_Tag(object sender, TagEventArgs e)
        {

            lblWaiting.Text = "Scan succesfull";

            scanned = true;
            UserManager dataCollect = new UserManager();
            user = dataCollect.SearchByRfid(e.Tag);
            if (user == null)
            {
                RFIDtext.Text = (e.Tag);
                RFIDtext.Text = "";
                lblFirstHR.Text = "";
                lblSureNameHR.Text = "";
                lblRFIDinfoUser.Text = "";
                lblBirthDHR.Text = "";
                lblEmailHR.Text = "";
                lblCountryHR.Text = "";
                lblStreetHR.Text = "";
                lblHouseNBHR.Text = "";
                lblCityHR.Text = "";
                lblCellPhoneNBHR.Text = "";
                lblLoginHR.Text = "";
                lbluserHS.Text = "";
                LoadHiredProducts(e.Tag);
            }
            else
            {
                RFIDtext.Text = user.RFID_Tag;
                lblFirstHR.Text = user.First_Name;
                lblSureNameHR.Text = user.Sur_Name;
                lblRFIDinfoUser.Text = user.RFID_Tag;
                lblBirthDHR.Text = Convert.ToString(user.Birth_Date);
                lblEmailHR.Text = user.Email;
                lblCountryHR.Text = user.Country;
                // lblStreetHR.Text = user.
                // lblHouseNBHR.Text = user.
                lblCityHR.Text = user.City;
                lblCellPhoneNBHR.Text = user.Phone_Number;
                lblLoginHR.Text = user.Login_Name;
                lbluserHS.Text = user.Username;

                //load hired producten
                LoadHiredProducts(e.Tag);
            }
        }

        private void rfid_Error(object sender, ErrorEventArgs e)
        {
            MessageBox.Show(e.Description);
        }

        private void availableProduct() 
        { 
          ProductManager productData = new ProductManager();
            producten = productData.availableProduct();
            foreach (Product product in producten)
            {
                listBoxAvble.Items.Add(product);
            }
        }


        public void LoadProducts()
        {
            ProductManager productData = new ProductManager();
            producten = productData.RequestProducts();
            foreach (Product product in producten)
            {

                listBox3.Items.Add(product);
            }
        }

        public void LoadHiredProducts(string RFID)
        {
            listBox1.Items.Clear();
            ProductManager productData = new ProductManager();
            producten = productData.SearchUserProduct(RFID);
            if (producten.Count == 0)
            {

                listBox1.Items.Add("User heeft geen producten gehuurd");
            }

            else
                foreach (Product product in producten)
                {
                    listBox1.Items.Add(product);
                }

        }

            private void bttnLend_Click(object sender, EventArgs e)
            {
                Product product;
                //User user;
                if (listBox3.SelectedItem is Product)
                {
                    string maand;
                    if (dateTimePicker1.Value.Month < 10)
                    {

                        maand = "0" + Convert.ToString(dateTimePicker1.Value.Month);
                    }
                    else
                    {
                        maand = Convert.ToString(dateTimePicker1.Value.Month);
                    }
                    string dag;
                    if (dateTimePicker1.Value.Day < 10)
                    {
                        dag = "0" + Convert.ToString(dateTimePicker1.Value.Day);
                    }
                    else
                    {
                        dag = Convert.ToString(dateTimePicker1.Value.Day);
                    }
                    string date = dag + maand + Convert.ToString(dateTimePicker1.Value.Year);

                    //UserManager userdata = new UserManager();
                    product = listBox3.SelectedItem as Product;
                    ProductManager productdata = new ProductManager();
                    productdata.InsertBorrow(product, user, date);

                    //MessageBox.Show(Convert.ToString(product.ID_Product));

                }

                else
                {
                    MessageBox.Show("Selecteer eerst een product om uit te lenen");
                }

            }

    }
}
