using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

    }
}
