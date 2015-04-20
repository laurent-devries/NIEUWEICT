using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events
{
    class CommentManager
    {
        public void InsertComment(string comment, int id_media, User user)
        {
            DatabaseConnection con = new DatabaseConnection();
            DateTime currentDate = DateTime.Now;
            string dateMonth = Convert.ToString(currentDate.Month);
            string dateDay = Convert.ToString(currentDate.Day);
            string dateYear = Convert.ToString(currentDate.Year);

            if (currentDate.Month < 10)
            {
                dateMonth = "0" + dateMonth;
            }
            if (currentDate.Day < 10)
            {
                dateDay = "0" + dateDay;
            }

            string Query = "INSERT INTO ICT4_COMMENT(ID_COMMENT, id_MediaFK , id_userFk, dateComment, commentComment) VAlues(com_seq.nextval, " + id_media.ToString() + ", " + user.ID_User.ToString() + ", to_date('" + dateDay + dateMonth + dateYear + "', 'DDMMYYYY'), '" + comment + "')";
            MessageBox.Show(Query);
            bool writer = con.InsertOrUpdate(Query);
        }
    }
}
