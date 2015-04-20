using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    class EventManager
    {
        private List<Event> evenementen;
        public Event a;
        public EventManager()
        {
            evenementen = new List<Event>();
        }
        public List<Event> RequestEvent()
        {
            evenementen = new List<Event>();
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT ID_EVENT, TITLE, DATEICT, STARTDATE, ENDDATE, CAMPINGNAME, LOCATION FROM ICT4_EVENT";
            OracleDataReader reader = con.SelectFromDatabase(Querry);
            while (reader.Read())
            {
                Event event1 = new Event(reader.GetString(1), reader.GetDateTime(2), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(0));
                evenementen.Add(event1);
                a = event1;
            }
            return evenementen;
        }
    }
}
