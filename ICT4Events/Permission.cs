using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Forms;

namespace ICT4Events
{
    //teun van der wijst
    public class Permission
    {
        private string name;
        private int permission_value;

        public int Permission_Value
        {
            get { return permission_value; }
            set { permission_value = value; }
        }
        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public Permission(string name, int permission_value)
        {
            this.name = name;
            this.permission_value = permission_value;
        }

        public Permission()
        {

        }

        public Permission GetPermissionUser(User u)
        {
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                string Querry = "SELECT PERMISSIONNAME, PERMISSIONVALUE FROM ICT4_PERMISSION WHERE ID_PERMISSION = '" + u.Permissionfk.ToString() + "'";

                OracleDataReader reader = con.SelectFromDatabase(Querry);
                Permission permission;
                while (reader.Read())
                {
                    permission = new Permission(reader.GetString(0), reader.GetInt32(1));
                    return permission;
                }
                MessageBox.Show("Permission not in system");
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
