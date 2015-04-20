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
        //private static int idnumber = 0;
        private int iD_product;
        private string product_name;
        private decimal bail;
        private decimal price;

       

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

        public decimal GetProductPrice()
        {
            decimal a = bail + price;
            return a;
        }

        
        
         public override string ToString()
         {
             return iD_product + "\t" + "\t" + "\t" + product_name + "\t" + "\t" + "\t" + "€"+bail + "\t" + "\t" + "\t" + "€"+ price; 
         }
    }
}
