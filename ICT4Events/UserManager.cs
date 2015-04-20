using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{
    class UserManager
    {
        List<User> userlist = new List<User>();
        public List<User> RequestUsers()
        {
            userlist = new List<User>();
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER";

            OracleDataReader reader = con.SelectFromDatabase(Querry);
            User user;
            while (reader.Read())
            {
                if (!reader.IsDBNull(19))
                {
                    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
                }
                else
                {
                    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)));
                }
                userlist.Add(user);
            }

            reader.Dispose();

            return userlist;
        }

        public User LoginUser(string us, string ps)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER WHERE UPPER(LOGINNAME) = '" + us.ToUpper() + "' AND PASSWORDUSER = '" + ps + "'";
                OracleDataReader reader = con.SelectFromDatabase(Querry);
                User user;
                while (reader.Read())
                {
                    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
                    return user;
                }
                MessageBox.Show("Username and password combination does not excist");
                return null;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public User SearchByRfid(string rfid)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                string Querry = "SELECT SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER WHERE rfidtag = " + "'" + rfid + "'";

                OracleDataReader reader = con.SelectFromDatabase(Querry);
                User user;
                while (reader.Read())
                {
                    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
                    return user;
                }
                MessageBox.Show("RFID_Tag not in system");
                return null;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
    }
    }
}
