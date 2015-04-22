using System;
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
        List<Product> productList = new List<Product>();

         public List<Product> RequestProducts()
         {
             DatabaseConnection con = new DatabaseConnection();
             string Querry = "SELECT ID_PRODUCT, PRODUCTNAME, BAIL, PRICE FROM ICT4_PRODUCT";
             

             OracleDataReader reader = con.SelectFromDatabase(Querry);
             Product product;
             while (reader.Read())
             {
                 product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3));
                 productList.Add(product);
             }

             reader.Dispose();

          return productList;
         }


         public List<Product> availableProduct()
         {
             List<Product> availableProduct = new List<Product>();

             try
             {
                 DatabaseConnection con = new DatabaseConnection();
                 string Querry = "SELECT P.ID_PRODUCT, P.PRODUCTNAME, PR.PRODUCTCATEGORY, P.BAIL FROM ICT4_PRODUCT P, ICT4_BORROWED_PRODUCTS BP, ICT4_BORROW B, ICT4_PRODUCTCATEGORY PR WHERE P.ID_PRODUCT = BP.ID_PRODUCTFK AND B.ID_BORROW = BP.ID_BORROWFK AND PR.ID_PRODUCTCAT = P.ID_PRODUCTCATFK AND HIREDATE = 'NULL'";
                      
                 OracleDataReader reader = con.SelectFromDatabase(Querry);
                 Product product;
                 while (reader.Read())
                 {
                     product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetString(3), reader.GetInt32(4));
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

         
    
     public List<Product> SearchUserProduct(string rfid)
         {
             List<Product> productUserList = new List<Product>();
             
             try
             {
                 DatabaseConnection con = new DatabaseConnection();
                 string Querry = "SELECT P.ID_PRODUCT, P.PRODUCTNAME, P.BAIL, P.PRICE, B.HIREDATE, B.RETURNDATE, B.RETURNEDDATE FROM ICT4_USER U, ICT4_BORROW B, ICT4_BORROWED_PRODUCTS BP, ICT4_PRODUCT P where u.ID_USER = b.ID_USERFK and b.ID_BORROW = bp.ID_BORROWFK and bp.ID_PRODUCTFK = p.ID_PRODUCT AND u.rfidtag = " + "'" + rfid + "'";  
                                        
                 OracleDataReader reader = con.SelectFromDatabase(Querry);
                 Product product;
                 while (reader.Read())
                 {
                     product = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetDateTime(4), reader.GetDateTime(5));
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

         public void InsertBorrow(Product product, User user , string date) 
         {
             DatabaseConnection con = new DatabaseConnection();

             string Query = "INSERT INTO ICT4_BORROW (ID_BORROW, ID_USERFK, returnDate, returnedDate) VALUES(borrow_seq.nextval," + user.ID_User + " , " + "'" + "to_date('" + date + "', 'ddmmyyyy'), 'null')";
             //MessageBox.Show(Query);
             con.InsertOrUpdate(Query);

         }
    }
}
