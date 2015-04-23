using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{
    class TagManager
    {
        List<Tag> tagList = new List<Tag>();
        public List<Tag> RequestAllTags()
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "SELECT TAGNAME FROM ICT4_TAG";
            OracleDataReader reader = con.SelectFromDatabase(Query);
            Tag tag;
            UserManager userManager = new UserManager();

            while (reader.Read())
            {
                tag = new Tag(reader.GetString(0));
                tagList.Add(tag);
            }

            reader.Dispose();

            return tagList;
        }
    }
}
