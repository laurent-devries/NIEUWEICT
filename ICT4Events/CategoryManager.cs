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
    class CategoryManager
    {
        public List<Category> RequestCategories()
        {
            List<Category> categoryList = new List<Category>();

            DatabaseConnection con = new DatabaseConnection();
            OracleConnection oracleConnection = con.OracleConnection();
            oracleConnection.Open();

            string cmdQuery = "SELECT categoryName, id_category FROM ICT4_CATEGORY";

            // Maakt het OracleCommand aan
            OracleCommand cmd = new OracleCommand(cmdQuery);

            cmd.Connection = oracleConnection;
            cmd.CommandType = CommandType.Text;

            // Voert het OracleCommand uit
            OracleDataReader reader = cmd.ExecuteReader();

            //Haalt alle categorieen op
            while (reader.Read())
            {
                Category categorie = new Category(reader.GetString(0), reader.GetInt32(1));
                categoryList.Add(categorie);
            }

            // Opruimen
            reader.Dispose();
            cmd.Dispose();
            oracleConnection.Dispose();

            // Returend de list
            return categoryList;
        }
    }
}
