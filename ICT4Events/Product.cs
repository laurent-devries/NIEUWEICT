using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{
    //Mario Schipper
    public class Product
    {
        
        private int iD_product;
        private string product_name;
        private decimal bail;
        private decimal price;
        private DateTime hire_date;
        private DateTime return_date;

       

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        

        public decimal Bail
        {
            get { return bail; }
            set { bail = value; }
        }
        

        public string Product_Name
        {
            get { return product_name; }
            set { product_name = value; }
        }
        

        public int ID_Product
        {
            get { return iD_product; }
            set { iD_product = value; }
        }
        
        public Product(int iD_product, string product_name, decimal bail, decimal price)
        {
           // this.ID_product = idnumber;
           // idnumber++;
            this.iD_product = iD_product;
            this.product_name = product_name;
            this.bail = bail;
            this.price = price;
        }

        public Product(int iD_product, string product_name, decimal bail, decimal price, DateTime hire_date, DateTime return_date)
        {

            this.iD_product = iD_product;
            this.product_name = product_name;
            this.bail = bail;
            this.price = price;
            this.hire_date = hire_date;
            this.return_date = return_date;
        }

        public decimal GetProductPrice()
        {
            decimal a = bail + price;
            return a;
        }

        public DateTime Return_Date
        {
            get { return return_date; }
            set { return_date = value; }
        }

        public DateTime Hire_Date
        {
            get { return hire_date; }
            set { hire_date = value; }
        }
        

        
         public override string ToString()
         {
             return iD_product + "\t" + "\t" + "\t" + product_name + "\t" + "\t" + "\t" + "€"+bail + "\t" + "\t" + "\t" + "€"+ price; 
         }
    }
}
