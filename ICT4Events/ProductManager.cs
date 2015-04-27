﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;


namespace ICT4Events
{
    class ProductManager
    {
        public bool noUserSelected = false;
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
                 OracleConnection oracleConnection = con.OracleConnetion();
                 oracleConnection.Open();

                 string cmdQuery = "SELECT TOTALAMOUNT, TOTALHIREDAMOUNT FROM ICT4_PRODUCT WHERE ID_PRODUCT = " + product.ID_Product;

                 // Maakt het OracleCommand aan
                 OracleCommand cmd = new OracleCommand(cmdQuery);

                 cmd.Connection = oracleConnection;
                 cmd.CommandType = CommandType.Text;

                 // Voert het OracleCommand uit
                 OracleDataReader reader = cmd.ExecuteReader();

                 //Haalt het totaal en aantal gehuurde producten op
                 reader.Read();
                 int totalAmount = reader.GetInt32(0);
                 int hiredAmount = reader.GetInt32(1);

                 // Opruimen
                 reader.Dispose();
                 cmd.Dispose();
                 oracleConnection.Dispose();

                 if (hiredAmount < totalAmount)
                 {
                        MessageBox.Show("Aantal producten is niet meer beschikbaar");
                        noUserSelected = false;
                 }


                 /////////////////////////OUDE CODE MARIO////////////////////////////
                 //DatabaseConnection con = new DatabaseConnection();
                 //string Query = "SELECT TOTALAMOUNT, TOTALHIREDAMOUNT FROM ICT4_PRODUCT WHERE ID_PRODUCT = " + product.ID_Product;
                 //OracleDataReader reader = con.SelectFromDatabase(Query);
                 //while (reader.Read())
                 //{
                 //    Totalhireamount =  (reader.GetInt32(0)); 
                 //    TotalAmount = (reader.GetInt32(1));
                 //}
                 //reader.Dispose();

                 //if (Totalhireamount < TotalAmount)
                 //{
                 //    MessageBox.Show("Aantal producten is niet meer beschikbaar");
                 //    noUserSelected = false;
                 //}
                //////////////////////////////////////////////////////////////////////


                               

                // if (hireAmount >= TotalAmount)
                // {

                   //  MessageBox.Show("Te veel producten aantal");
                     //string Query2 = "UPDATE ICT4_PRODUCT SET AVAILABLE = 'N' WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
                     //con.InsertOrUpdate(Query2);

                     //string Query3 = "UPDATE ICT4_PRODUCT SET TotalHiredamount =+ " + "'" + hireAmount + "'" + "," + "5 WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
                     //con.InsertOrUpdate(Query3);

               //      noUserSelected = false;
              //   }

                 else 
                 {
                     {
                         string Query4 = "INSERT INTO ICT4_USER_PRODUCTS VALUES(" + "'" + user.ID_User + "'" + "," + "'" + product.ID_Product + "'" + ", to_date(sysdate,'DD-MM-YYYY'), to_date('" + date + "', 'DD-MM-YYYY'), null" + "," + +hireAmount + ")";
                         con.InsertOrUpdate(Query4);

                         string Query5 = "UPDATE ICT4_PRODUCT SET TotalHiredamount  = TOTALHIREDAMOUNT +" + hireAmount + "WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
                         con.InsertOrUpdate(Query5);
                         noUserSelected = false;

                        

                         if (product.Totalamount == 0)
                         {
                             string Query2 = "UPDATE ICT4_PRODUCT SET AVAILABLE = 'N' WHERE ID_PRODUCT = " + "'" + product.ID_Product + "'" + "";
                             con.InsertOrUpdate(Query2);
                         }

                     }
                    

                 }
                 
             } 
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
