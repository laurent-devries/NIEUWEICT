using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    //Laurent de Vries
    public class Note
    {
        private static int idnumber = 0;
        private int id_note;
        private string likeOrreport;
        private string soort;
        public string LikeOrReport { get { return likeOrreport; } set { likeOrreport = value; } }
        public string Soort { get { return Soort; } }
        public Note(string likeOrreport,string Soort)
        {

            if (Soort == "Like" || Soort == "Report")
            {
                id_note = idnumber;
                idnumber++;
                this.likeOrreport = likeOrreport;
                this.soort = Soort;
            }
        }
    }
}
