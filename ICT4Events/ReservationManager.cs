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
            string Querry = "SELECT id_reservation,id_eventFK,id_campingPlaceFK,startdate,endDate,PAYMENTSTATE FROM ICT4_RESERVATION WHERE id_EventFK = " + Convert.ToString(event_Id);
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
    }
}
