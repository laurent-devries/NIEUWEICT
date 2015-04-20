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
    class BorrowManager
    {
        List<Borrow> borrowList = new List<Borrow>();

            public List<Borrow> RequestBorrow()
            {
                DatabaseConnection con = new DatabaseConnection();
                string Querry = "SELECT ID_BORROW, HIREDATE, RETURNDATE FROM ICT4_BORROW";


                OracleDataReader reader = con.SelectFromDatabase(Querry);
                Borrow borrow;
                while (reader.Read())
                {
                    borrow = new Borrow(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2));
                    borrowList.Add(borrow);
                }

                reader.Dispose();

              return borrowList;
            }

        }
    }



