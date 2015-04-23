using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    class ReservationManager
    {
        private List<Reservation> reservations;
        public ReservationManager()
        {
            reservations = new List<Reservation>();
        }
        public List<Reservation> RequestReservations(int event_Id)
        {
            reservations = new List<Reservation>();

            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT id_reservation,id_eventFK,startdate,endDate, PAYMENTSTATE FROM ICT4_RESERVATION WHERE id_EventFK = " + Convert.ToString(event_Id);
            Reservation reservation;
            OracleDataReader reader = con.SelectFromDatabase(Querry);

            while (reader.Read())
            {
                reservation = new Reservation(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetDateTime(3), reader.GetDateTime(4), Convert.ToChar(reader.GetString(5)));
                reservations.Add(reservation);

            }

            reader.Dispose();

            return reservations;


        }
        public List<string> RequestReservationsInfo(int event_Id)
        {
            DatabaseConnection conn = new DatabaseConnection();
            string QuerrySELECT = "SELECT R.ID_RESERVATION, E.CAMPINGNAME, C.PLACENUMBER, RC.STARTDATE, RC.ENDDATE, R.PAYMENTSTATE  ";
            string QuerryFROM = "FROM ICT4_RESERVATION R, ICT4_RES_CAMPPLACE RC, ICT4_CAMPING_PLACE C, ICT4_EVENT E ";
            string QuerryWHERE = "WHERE R.ID_RESERVATION = RC.ID_RESERVATIONFK AND C.ID_CAMPINGPLACE = RC.ID_CAMPINGPLACEFK AND E.ID_EVENT = R.ID_EVENTFK AND E.ID_EVENT =" + event_Id.ToString();
            string Querry = QuerrySELECT + QuerryFROM + QuerryWHERE;
            OracleDataReader reader = conn.SelectFromDatabase(Querry);
            int i = 0;
            List<string> Liststring = new List<string>();
            while (reader.Read())
            {

                Liststring.Add(reader.GetInt32(0).ToString() + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetDateTime(3).ToString("dd-MM-yyyy") + " " + reader.GetDateTime(4).ToString("dd-MM-yyyy") + " " + Convert.ToChar(reader.GetString(5)));
                i++;
            }
            return Liststring;
        }
    }
}
