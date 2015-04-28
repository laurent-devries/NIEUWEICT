using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.IO;
using System.Data;
namespace ICT4Events
{
    class UserManager
    {
        List<User> userlist = new List<User>();
        public List<User> RequestUsers()
        {
            userlist = new List<User>();
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER ORDER BY ID_USER, ID_EVENTFK, ID_RESERVATIONFK";

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
                reader.Read();
                user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
                return user;
            }

            

          

            catch (Exception e)
            {
                try
                {
                    DatabaseConnection con = new DatabaseConnection();
                    string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, LOGINNAME, PASSWORDUSER, PRESENTUSER  FROM ICT4_USER WHERE UPPER(LOGINNAME) = '" + us.ToUpper() + "' AND PASSWORDUSER = '" + ps + "'";
                    OracleDataReader reader = con.SelectFromDatabase(Querry);
                    User user;
                    reader.Read();
                    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), Convert.ToChar(reader.GetString(6)));
                    return user;
                    
                }

                catch
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }
                
            }

        }

        public User SearchUserById(int idUser)
        {
            //try
            //{
            //    DatabaseConnection con = new DatabaseConnection();
            //    string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER WHERE ID_USER = " + idUser;
            //    OracleDataReader reader = con.SelectFromDatabase(Querry);
            //    User user;
            //    reader.Read();
            //    user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));
            //    return user;
            //}

            //catch (Exception)
            //{
            //    return null;
            //}

            DatabaseConnection con = new DatabaseConnection();
            OracleConnection oracleConnection = con.OracleConnection();
            oracleConnection.Open();

            string cmdQuery = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER WHERE ID_USER = " + idUser;

            // Maakt het OracleCommand aan
            OracleCommand cmd = new OracleCommand(cmdQuery);

            cmd.Connection = oracleConnection;
            cmd.CommandType = CommandType.Text;

            // Voert het OracleCommand uit
            OracleDataReader reader = cmd.ExecuteReader();

            //Haalt het aantal likes op
            reader.Read();
            User user = new User(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetDateTime(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetString(12), reader.GetString(13), reader.GetString(14), reader.GetString(15), reader.GetString(16), reader.GetString(17), Convert.ToChar(reader.GetString(18)), reader.GetString(19));

            // Opruimen
            reader.Dispose();
            cmd.Dispose();
            oracleConnection.Dispose();

            // Returend het aantal
            return user;
        }

        public bool UpdateUserPresent(string userId, bool goingIn)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                if (goingIn == true)
                {
                    string Querry = "UPDATE ICT4_USER SET PresentUser = 'Y' where id_user = '" + userId + "'";
                    OracleDataReader reader = con.SelectFromDatabase(Querry);
                    return true;
                }

                else if (goingIn == false)
                {
                    string Querry = "UPDATE ICT4_USER SET PresentUser = 'N' where id_user = '" + userId + "'";
                    OracleDataReader reader = con.SelectFromDatabase(Querry);
                    return true;
                }

                MessageBox.Show("RFID_Tag not in system");
                return false;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }


        public User SearchByRfid(string rfid)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                string Querry = "SELECT ID_USER, ID_EVENTFK, ID_RESERVATIONFK, id_permissionFK, FIRSTNAME, SURNAME, BIRTHDATE, EMAIL, COUNTRY, STREET, HOUSENUMBER, CITY, CELLPHONENUMBER, LOGINNAME, USERNAME, PASSWORDUSER, PROFILEPIC, SUMMARYUSER, PRESENTUSER, RFIDTAG  FROM ICT4_USER WHERE rfidtag = " + "'" + rfid + "'";
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
