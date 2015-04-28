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
    class TagManager
    {
        List<Tag> tagList = new List<Tag>();
        public List<Tag> RequestAllTags()
        {
            //DatabaseConnection con = new DatabaseConnection();
            //string Query = "SELECT TAGNAME FROM ICT4_TAG";
            //OracleDataReader reader = con.SelectFromDatabase(Query);
            //Tag tag;
            //UserManager userManager = new UserManager();

            //while (reader.Read())
            //{
            //    tag = new Tag(reader.GetString(0));
            //    tagList.Add(tag);
            //}

            //reader.Dispose();

            //return tagList;

            List<Tag> tagList = new List<Tag>();

            DatabaseConnection con = new DatabaseConnection();
            OracleConnection oracleConnection = con.OracleConnection();
            oracleConnection.Open();

            string cmdQuery = "SELECT TAGNAME FROM ICT4_TAG";

            // Maakt het OracleCommand aan
            OracleCommand cmd = new OracleCommand(cmdQuery);

            cmd.Connection = oracleConnection;
            cmd.CommandType = CommandType.Text;

            // Voert het OracleCommand uit
            OracleDataReader reader = cmd.ExecuteReader();

            //Haalt alle categorieen op
            while (reader.Read())
            {
                Tag tag = new Tag(reader.GetString(0));
                tagList.Add(tag);
            }

            // Opruimen
            reader.Dispose();
            cmd.Dispose();
            oracleConnection.Dispose();

            // Returend de list
            return tagList;
        }
    }
}
