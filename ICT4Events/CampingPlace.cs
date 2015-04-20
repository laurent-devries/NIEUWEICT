using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    class CampingPlace
    {
        public int IdCampingPlace { get; set; }
        public int IdEventFk { get; set; }
        public string PlaceNumber { get; set; }
        public int MaxPeople { get; set; }
        public string CampingType { get; set; }

        public CampingPlace(int id, int idEvent,string placeNumber, int maxPeople, string campingType ) 
        {
            IdCampingPlace = id;
            IdEventFk = idEvent;
            PlaceNumber = placeNumber;
            MaxPeople = maxPeople;
            CampingType = campingType;
        }

        public override string ToString()
        {
            return "Nummer: " + PlaceNumber + " aantal: " + MaxPeople + " type: " + CampingType; 
        }

    }
}
