using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;         //voor het gebruik van RFID
using Phidgets.Events;  //voor het gebruik van EVENTS (Attach etc.)
using Oracle.ManagedDataAccess.Client; 

namespace ICT4Events
{
    public partial class Hiresystem : Form
    {
        List<Product> producten;
        RFID rfid = new RFID(); //RFID object
        private bool scanned = false;
        
        User user;

        //load alle producten in de lists
        public Hiresystem()
        {
            InitializeComponent();
            LoadProducts();
            availableProduct();
        }
        
        public void bttnEnableRFID_Click(object sender, EventArgs e)
        {
            try
            {
                if (scanned == false)
                {
                    //Maak nieuwe events aan voor RFID
                    rfid.Attach += new AttachEventHandler(rfid_Attach);
                    rfid.Detach += new DetachEventHandler(rfid_Detach);
                    rfid.Error += new ErrorEventHandler(rfid_Error);
                    rfid.Tag += new TagEventHandler(rfid_Tag);
                    rfid.open();
                    bttnEnableRFID.Text = "Restart";
                }
                else
                {
                    RFIDtext.Text = "";
                    scanned = false;
                    rfid.close();
                }
            }
            //Als er fout meldingen komen vanuit Phidget vang op en laat messagebox zien
            catch (PhidgetException ex)
            {
               MessageBox.Show(ex.Description);
            }
            // Als Dll niet toegevoegd is, laat fout melding zien
            catch (DllNotFoundException)
            {
                MessageBox.Show("Phidget Dll kan niet gevonden worden");
            }
        }

        //kijk of de RFID connected is aan USB en laat port zien
        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            lblconnectedInfo.Text = "Verbonden";
            lblserialInfo.Text = e.Device.SerialNumber.ToString();

        }

        //kijk of de RFID connected is aan USB en zet port label op --.
        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            lblconnectedInfo.Text = "Verbinding verbroken";
            lblserialInfo.Text = "--";
        }

        //Haal alle informatie op die de zelfde tag ID heeft als de user en vul alles er mee
        public void rfid_Tag(object sender, TagEventArgs e)
        {
            lblWaiting.Text = "De scan is voltooid";

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
                lblStreetHR.Text = user.Street;
                lblHouseNBHR.Text = user.Housenumber;
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

        
        // Kijk of er producten aanwezig zijn die gehuurd kan worden
        private void availableProduct() 
        { 
          ProductManager productData = new ProductManager();
            producten = productData.availableProduct();
            
            if (producten.Count == 0)
            {
             listBoxAvble.Text = "Er zijn geen producten beschikbaar"; 
            }
            else

                foreach (Product product in producten)
                {
                    listBoxAvble.Items.Add(product);
                }
        }

        // load alle producten en vul ze in de lists
        public void LoadProducts()
        {
            ProductManager productData = new ProductManager();
            producten = productData.RequestProducts();
            
            foreach (Product product in producten)
            {

                listBox3.Items.Add(product);
            }
        }

        // Kijk of er producten zijn die de user heeft, zo niet heeft de user geen producten
        public void LoadHiredProducts(string RFID)
        {
            
            listBox1.Items.Clear();
            ProductManager productData = new ProductManager();
            producten = productData.SearchUserProduct(RFID);
            
            if (producten.Count == 0)
            {

                listBox1.Items.Add("Gebruiker heeft geen producten gehuurd");
            }
            else
                foreach (Product product in producten)
                {
                    listBox1.Items.Add(product);
                }
        }

        //producten die op user gezet kan worden
        private void bttnLend_Click(object sender, EventArgs e)
        {

            int Amountvalue = Convert.ToInt32(numericUpDown1.Value);
             
            {
                Product product;
                DateTime now = DateTime.Now;

                if (now > dateTimePicker1.Value)
                {
                    MessageBox.Show("Vul een geldige datum in");
                }

                else
                if (listBoxAvble.SelectedItem is Product)
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
                    
                    product = listBoxAvble.SelectedItem as Product;
                    ProductManager productdata = new ProductManager();
                    productdata.InsertBorrow(product, user, date, Amountvalue);
                    if (productdata.noUserSelected == true)
                    {
                        MessageBox.Show("Scan eerst een user.");
                        
                    }
                    string RFID = RFIDtext.Text;
                    // refresh listboxen
                    refresh(RFID);
                }
                else
                {
                    MessageBox.Show("Selecteer eerst een product om uit te lenen");
                }
            }
                     
        }
            private void bttnReturn_Click(object sender, EventArgs e)
            {
               Product product;

               if (listBox1.SelectedItem is Product)
               {
                    product = listBox1.SelectedItem as Product;
                    ProductManager productdata = new ProductManager();
                    productdata.deleteBorrow(product, user);
                    string RFID = RFIDtext.Text;
                    refresh(RFID);
               }
            }

            public void refresh(string e)
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                listBoxAvble.Items.Clear();
                LoadProducts();
                availableProduct();
                LoadHiredProducts(e);
            }

            private void btnSearch_Click(object sender, EventArgs e)
            {

                //foreach (Product p in ProductList)
                //{
                //    string title = tbTitleSort.Text;
                //    if (m.Title.ToUpper().Contains(title.ToUpper()))
                //    {
                //        swap.Add(m);
                //        swapped = true;
                //    }
                //}
            }
    }
}
