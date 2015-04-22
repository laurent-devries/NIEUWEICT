using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    public class Reservation
    {

        private int id_reservation;
        private int id_eventFK;
        private int id_campingPlaceFK;
        private char paymentState;
        private List<User> reservationusers;
        
        public int ID_Reservation { get { return id_reservation; } }
        public int ID_EventFK { get { return id_eventFK; } }
        public int ID_campingPlaceFK { get { return id_campingPlaceFK; } set { id_campingPlaceFK = value; } }
        public char PaymentState { get { return paymentState; } set { paymentState = value; } }

        public Reservation(int id_reservation, int id_eventFK, int id_campingPlaceFK, char Paymentstate)
        {
            this.id_reservation = id_reservation;
            this.id_eventFK = id_eventFK;
            this.id_campingPlaceFK = id_campingPlaceFK;
            this.paymentState = Paymentstate;
            reservationusers = new List<User>();
        }
        
        public void Adduser(User user)
        {
            reservationusers.Add(user);
        }
        public void Removeuser(User user)
        {
            reservationusers.Remove(user);
        }
        public override string ToString()
        {
            return id_reservation.ToString();
        }
    }
}
