using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{
    //Laurent de Vries
    class Category : ICategorieTag
    {
        //Fields 
        List<Category> categories;

        public string Name { get; set; }

        //Constructor
        public Category(string Category_Name)
        {
            Name = Category_Name;
        }

        public Category()
        {
            categories = new List<Category>();
        }

        // Deze moet hier nog weg -- Frank
        public List<Category> RequestCategories()
        {
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT categoryName FROM ICT4_CATEGORY";

            OracleDataReader reader = con.SelectFromDatabase(Querry);
            Category categorie;
            while (reader.Read())
            {
                categorie = new Category(reader.GetString(0));
                categories.Add(categorie);
            }

            reader.Dispose();

            return categories;
        }

        public override string ToString()
        {
            return Name;
        }
    }

}
