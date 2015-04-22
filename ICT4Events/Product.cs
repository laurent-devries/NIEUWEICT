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
        //Fields
        private int iD_product;
        private string product_name;
        private decimal bail;
        private decimal price;
        private string category;
        private DateTime hire_date;
        private DateTime return_date;

       

        public decimal Price { get { return price; } set { price = value; } }
        public decimal Bail { get { return bail; } set { bail = value; } }
        public string Product_Name { get { return product_name; } set { product_name = value; } }
        public int ID_Product { get { return iD_product; } set { iD_product = value; } }  
        public DateTime Return_Date { get { return return_date; } set { return_date = value; } } 
        public string Category { get { return category; } set { category = value; } }
        
        public Product(int iD_product, string product_name, decimal bail, decimal price)
        {
          
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



        public Product(int iD_product, string product_name, string category, decimal bail)
        {
            this.iD_product = iD_product;
            this.product_name = product_name;
            this.category = category;
            this.bail = bail;
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
