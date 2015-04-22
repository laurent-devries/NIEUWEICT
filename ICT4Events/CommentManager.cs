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
    class CommentManager
    {
        List<Comment> commentList = new List<Comment>();
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

        public List<Comment> RequestComments(int mediaID)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "SELECT id_comment, id_mediaFK, dateComment, commentComment, id_userFK FROM ICT4_COMMENT WHERE id_mediaFk = '" + mediaID + "'";
            OracleDataReader reader = con.SelectFromDatabase(Query);
            Comment comment;
            UserManager userManager = new UserManager();

            while (reader.Read())
            {
                comment = new Comment(reader.GetInt32(0), reader.GetDateTime(2), reader.GetString(3), reader.GetInt32(1), userManager.SearchUserById(reader.GetInt32(4)));
                commentList.Add(comment);
            }

            reader.Dispose();

            return commentList;
        }
    }
}
