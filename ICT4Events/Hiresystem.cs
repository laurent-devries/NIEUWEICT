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
        List<ProductCategory> productCategoryList;

        RFID rfid = new RFID(); //RFID object
        private bool scanned = false;
        List<Product> productholder;
        User user;

        // create tab
        ProductCategory productCategory;

        //load alle producten in de lists
        public Hiresystem()
        {
            InitializeComponent();
            LoadProducts();
            availableProduct();
            productholder = producten;
            LoadProductsCategory();
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
                lblBirthDHR.Text = user.Birth_Date.ToShortDateString();
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
                allProductslist.Items.Add(product);
                AllproductsP2lst.Items.Add(product);
            }
        }

        // Kijk of er producten zijn die de user heeft, zo niet heeft de user geen producten
        public void LoadHiredProducts(string RFID)
        {

            UserProductlist.Items.Clear();
            ProductManager productData = new ProductManager();
            producten = productData.SearchUserProduct(RFID);

            if (producten.Count == 0)
            {

                UserProductlist.Items.Add("Gebruiker heeft geen producten gehuurd");
            }
            else
                foreach (Product product in producten)
                {
                    UserProductlist.Items.Add(product);
                }
        }

        //producten die op user gezet kan worden
        private void bttnLend_Click(object sender, EventArgs e)
        {

            int Amountvalue = Convert.ToInt32(numericUpDown1.Value);

            {
                Product product;
                DateTime dateNow = DateTime.Now;
                string datePicker = dateTimePicker1.Value.ToShortDateString(); 
                string dateToday = dateNow.ToShortDateString();
                DateTime datePickerConvert = Convert.ToDateTime(datePicker);
                DateTime dateTodayConvert = Convert.ToDateTime(dateToday);

                if (datePickerConvert < dateTodayConvert)
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

            if (UserProductlist.SelectedItem is Product)
            {
                product = UserProductlist.SelectedItem as Product;
                ProductManager productdata = new ProductManager();
                productdata.deleteBorrow(product, user);

                decimal dayshired = (decimal)product.GetTotalHireDate();
                decimal bail = product.Bail;
                if (dayshired < 0)
                {
                    dayshired = 1;
                }

                decimal price = product.Price * dayshired;
                decimal dayprice = product.Hiredamount * price;
                decimal total = bail + price + dayprice;
                MessageBox.Show("Het uit eindelijke bedrag wat er betaald moet worden is: €" + total + ", Hier van is €" + bail + " de borg.");
                

                string RFID = RFIDtext.Text;
                refresh(RFID);
            }
        }

        public void refresh(string e)
        {
            UserProductlist.Items.Clear();
            allProductslist.Items.Clear();
            listBoxAvble.Items.Clear();
            LoadProducts();
            availableProduct();
            LoadHiredProducts(e);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<Product> swap = new List<Product>();
            producten = productholder;
            listBoxAvble.Items.Clear();
           
            foreach (Product p in producten)
            {
                
                if (SearchTxtHR.Text == "")
                {
                    MessageBox.Show("Vul product naam in");
                    break; 
                }

                string title = SearchTxtHR.Text;
                
                if (p.Product_Name.ToUpper().Contains(title.ToUpper()) && SearchTxtHR.Text != "")
                {
                    swap.Add(p);
                    listBoxAvble.Items.Add(p);
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            SearchTxtHR.Text = "";
            UserProductlist.Items.Clear();
            allProductslist.Items.Clear();
            listBoxAvble.Items.Clear();
            LoadProducts();
            availableProduct();
            LoadProductsCategory();
        }

        public void LoadProductsCategory()
        {
            ProductcCatManager productCatData = new ProductcCatManager();
            productCategoryList = productCatData.RequestProductCategory();

            foreach (ProductCategory productCategory in productCategoryList)
            {
                comboBoxCat.Items.Add(productCategory);
            }
        }

        private void Createbtn_Click(object sender, EventArgs e)
        {
                // Maakt de manager aan
                ProductManager productManager = new ProductManager();

                if (NameTxt.Text != "")
                {
                    // Vult alle data van een product
                    string productName = NameTxt.Text;
                    decimal priceBail = nudBailPrice.Value;
                    decimal priceDay = nudPriceDay.Value;
                    decimal productAmount = (int)nudAmount.Value;

                    if (productCategory != null)
                    {
                        try
                        {
                            productManager.insertProduct(productName, productAmount, productCategory, priceBail, priceDay);
                            string RFID = RFIDtext.Text;
                            refresh(RFID);
                        }

                        catch
                        {
                            MessageBox.Show("Product kan niet toegevoegd worden");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("Alle velden moeten ingevuld zijn");
                }
                
            }
        private void comboBoxCat_SelectedValueChanged(object sender, EventArgs e)
        {
            // Vult de productCategory met de geselecteerde waarde
            productCategory = comboBoxCat.SelectedItem as ProductCategory;
        }

     }   
}

