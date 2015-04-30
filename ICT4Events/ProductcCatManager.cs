using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace ICT4Events
{
    class ProductcCatManager
    {
        List<ProductCategory> productCatlist = new List<ProductCategory>();


        public List<ProductCategory> RequestProductCategory()
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "SELECT ID_PRODUCTCAT, PRODUCTCATEGORY FROM ICT4_PRODUCTCATEGORY";


            OracleDataReader reader = con.SelectFromDatabase(Query);
            ProductCategory productCategory;
            while (reader.Read())
            {
                productCategory = new ProductCategory(reader.GetInt32(0), reader.GetString(1));
                productCatlist.Add(productCategory);
            }

            reader.Dispose();

            return productCatlist;
        }


    }
}
