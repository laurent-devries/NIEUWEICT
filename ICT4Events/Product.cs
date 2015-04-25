using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Forms;



namespace ICT4Events
{
    //Mario Schipper
    public class Product
    
    {
        //Fields
        IFormatProvider Culture = new System.Globalization.CultureInfo("fr-FR", true);
        
        private int iD_product;
        private string product_name;
        private decimal bail;
        private decimal price;
        private string category;
        private DateTime hire_date;
        private DateTime return_date;
        private DateTime returned_date;
        private string available;
        private int amount;
        
        public decimal Price { get { return price; } set { price = value; } }
        public decimal Bail { get { return bail; } set { bail = value; } }
        public string Product_Name { get { return product_name; } set { product_name = value; } }
        public int ID_Product { get { return iD_product; } set { iD_product = value; } }  
        public DateTime Return_Date { get { return return_date; } set { return_date = value; } } 
        public DateTime Hire_Date { get { return hire_date; } set { hire_date = value; } } 
        public DateTime Returned_Date { get { return returned_date; } set { returned_date = value; } } 
        public string Category { get { return category; } set { category = value; } }
        public string Available { get { return available; } set { available = value; } }
        public int Amount { get { return amount; } set { amount = value;  } }
        
        public Product(int iD_product, string product_name, decimal bail, decimal price, string available)
        {
          
            this.iD_product = iD_product;
            this.product_name = product_name;
            this.bail = bail;
            this.price = price;
            this.available = available;
        }

        public Product(int iD_product, string product_name, DateTime hire_date, DateTime return_date, decimal bail)
        {
            this.iD_product = iD_product;
            this.product_name = product_name;
            this.hire_date = hire_date;
            this.return_date = return_date;
            this.bail = bail;
            
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

             string hiredate = hire_date.ToShortDateString();
             string returndate = return_date.ToShortDateString();

             if (category == null && available == null) 
             {
                 return iD_product + "\t" + product_name + "\t" + category + "\t" + "€" + bail + "\t" + "\t" + hiredate + "\t" + returndate;
             }

             if (category ==  null)
             {
                 return iD_product + "\t" + product_name + "\t" + "€" + bail + "\t" + "€" + price + "\t" + available; 
                 
             }

             else 
             {
                 return iD_product + "\t" + product_name + "\t" + category + "\t" + "€" + bail;
             }

         }

         
    }
}
