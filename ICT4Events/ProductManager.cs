﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;


namespace ICT4Events
{
    class ProductManager
    {
        public bool noUserSelected = false;
        private int Totalhireamount;
        private int TotalAmount;
        //done
        List<Product> productList = new List<Product>();

         public List<Product> RequestProducts()
         {
             DatabaseConnection con = new DatabaseConnection();
             string Query = "SELECT ID_PRODUCT, PRODUCTNAME, BAIL, PRICE, available, TOTALAMOUNT FROM ICT4_PRODUCT";
             

             OracleDataReader reader = con.SelectFromDatabase(Query);
             Product product;
             while (reader.Read())
             {
                 product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetString(4), reader.GetInt32(5));
                 productList.Add(product);
             }

             reader.Dispose();

          return productList;
         }

        //done
         public List<Product> availableProduct()
         {
             List<Product> availableProduct = new List<Product>();

             try
             {
                 DatabaseConnection con = new DatabaseConnection();
                 string Query = "SELECT DISTINCT P.ID_PRODUCT, P.PRODUCTNAME, PC.PRODUCTCATEGORY, P.BAIL, P.TOTALAMOUNT, P.TOTALHIREDAMOUNT FROM ICT4_PRODUCT P, ICT4_USER_PRODUCTS UP, ICT4_PRODUCTCATEGORY PC WHERE PC.ID_PRODUCTCAT = P.ID_PRODUCTCATFK AND P.ID_PRODUCT = UP.ID_PRODUCTFK(+) AND P.AVAILABLE = 'Y' ORDER BY P.ID_PRODUCT ";


                      
                 OracleDataReader reader = con.SelectFromDatabase(Query);
                 Product product;
                 while (reader.Read())
                 {
                     product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt32(5));
                     availableProduct.Add(product);
                 }


                 reader.Dispose();

                 return availableProduct;
             }
             
             catch (Exception e)
             {
                 MessageBox.Show(e.ToString());
                 return null;
             }
         }

         
    //done
     public List<Product> SearchUserProduct(string rfid)
         {
             List<Product> productUserList = new List<Product>();
             
             try
             {
                 DatabaseConnection con = new DatabaseConnection();
                 string Query = "SELECT P.ID_PRODUCT, P.PRODUCTNAME, UP.HIREDATE, UP.RETURNDATE, P.BAIL, UP.HIREDAMOUNT  FROM ICT4_USER U, ICT4_USER_PRODUCTS UP, ICT4_PRODUCT P where u.ID_USER = UP.ID_USERFK and UP.ID_PRODUCTFK = p.ID_PRODUCT AND UP.RETURNEDDATE IS NULL AND u.rfidtag = " + "'" + rfid + "'"; 
                  
                 OracleDataReader reader = con.SelectFromDatabase(Query);
                 Product product;
                 while (reader.Read())
                 {
                     product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(3), reader.GetDecimal(4), reader.GetInt32(5));
                     productUserList.Add(product);
                 }
                 reader.Dispose();

                 return productUserList;
               
             }

             catch (Exception e)
             {
                 MessageBox.Show(e.ToString());
                 return null;
             }
         }

        // done
         public void InsertBorrow(Product product, User user , string date, int hireAmount) 
         {

             if (user == null)
             {
                 noUserSelected = true;         
             }
             else
             {
                 DatabaseConnection con = new DatabaseConnection();
                 string Query = "SELECT TOTALAMOUNT, TOTALHIREDAMOUNT FROM ICT4_PRODUCT";
                 OracleDataReader reader = con.SelectFromDatabase(Query);
                 while (reader.Read())
                 {
                     Totalhireamount =  (reader.GetInt32(0)); 
                     TotalAmount = (reader.GetInt32(1));
                 }
                 reader.Dispose();

                 if (Totalhireamount >= TotalAmount)
                 {
                     MessageBox.Show("fck it");
                 }

                 else 
                 {
                     string Query1 = "INSERT INTO ICT4_USER_PRODUCTS VALUES(" + "'" + user.ID_User + "'" + "," + "'" + product.ID_Product + "'" + ", to_date(sysdate,'DD-MM-YYYY'), to_date('" + date + "', 'DD-MM-YYYY'), null" + "'" + product.ID_Product + "," + "'" + hireAmount + "'" + ")";
                     con.InsertOrUpdate(Query1);

                     string Query2 = "UPDATE ICT4_PRODUCT SET AVAILABLE = 'N' WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
                     con.InsertOrUpdate(Query2);
                     noUserSelected = false;
                 }
                 
             } 

             
             //if ()
             //{
             //    return true;
             //}

             //else 
             //{
             //   return false;
             //}

             

         }

        
        public bool deleteBorrow(Product product, User user)
        {
            DatabaseConnection con = new DatabaseConnection();

            string Query = "UPDATE ICT4_USER_PRODUCTS SET returnedDate = to_date(sysdate,'DD-MM-YYYY') WHERE id_userFk = " + "'" + user.ID_User + "'" + " AND id_ProductFk = " + "'" + product.ID_Product + "'" + ""; 
            con.InsertOrUpdate(Query);

            string Query2 = "UPDATE ICT4_PRODUCT SET AVAILABLE = 'Y' WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
            con.InsertOrUpdate(Query2);

            return true;
        }
            

        
     }
}
