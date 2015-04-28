using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
            string Querry = "SELECT ID_EVENT, TITLE, DATEICT, STARTDATE, ENDDATE, CAMPINGNAME, LOCATION FROM ICT4_EVENT ORDER BY ID_EVENT, TITLE, CAMPINGNAME";
            OracleDataReader reader = con.SelectFromDatabase(Querry);
            while (reader.Read())
            {
                Event event1 = new Event(reader.GetString(1), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(0));
                evenementen.Add(event1);
                a = event1;
            }
            return evenementen;
        }

        public Event Request1Event(string eventId)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT ID_EVENT, TITLE, DATEICT, STARTDATE, ENDDATE, CAMPINGNAME, LOCATION FROM ICT4_EVENT WHERE ID_EVENT = '"+ eventId + "' ORDER BY ID_EVENT, TITLE, CAMPINGNAME";
            OracleDataReader reader = con.SelectFromDatabase(Querry);
            while (reader.Read())
            {
                Event event1 = new Event(reader.GetString(1), reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(0));
                a = event1;
            }
            return a;
        }

        public string RequestEventName(int id)
        {       
            DatabaseConnection con = new DatabaseConnection();
            OracleConnection oracleConnection = con.OracleConnection();
            oracleConnection.Open();

            string cmdQuery = "SELECT TITLE FROM ICT4_EVENT WHERE ID_EVENT =" + id;

            // Maakt het OracleCommand aan
            OracleCommand cmd = new OracleCommand(cmdQuery);

            cmd.Connection = oracleConnection;
            cmd.CommandType = CommandType.Text;

            // Voert het OracleCommand uit
            OracleDataReader reader = cmd.ExecuteReader();

            //Haalt de titel van het event op
            reader.Read();
            string eventName = reader.GetString(0);

            // Opruimen
            reader.Dispose();
            cmd.Dispose();
            oracleConnection.Dispose();

            // Returend de titel
            return eventName;
        }
    }
}
