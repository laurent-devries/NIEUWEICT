using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;

namespace ICT4Events
{
    class MediaManager
    {
       
        List<Media> mediaList = new List<Media>();
        List<Comment> commentList = new List<Comment>();

        public List<Media> RequestMedia()
        {
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "SELECT TITLE, to_char(DATEMEDIA), SUMMARYMEDIA,  to_char(viewMedia), to_char(likes), to_char(reports), FILEPATH, id_media, id_userFk   FROM ICT4_MEDIA";
            
            OracleDataReader reader = con.SelectFromDatabase(Querry);
            Media media;
            UserManager userManager = new UserManager();
            while (reader.Read())
            {
                int aantalLikes;
                int aantalReports;
                try
                {
                    aantalLikes = Convert.ToInt32(reader.GetString(4));
                    aantalReports = Convert.ToInt32(reader.GetString(5));
                }
                catch
                {
                    aantalLikes = 0;
                    aantalReports = 0;
                }


                media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), aantalLikes, aantalReports, reader.GetString(6), "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                mediaList.Add(media);
            }

            reader.Dispose();

            return mediaList;
        }


        

        public bool InsertMedia(string title, string summaryMedia, string filePath, string typeMedia, DateTime currentDate)
        {
            DatabaseConnection con = new DatabaseConnection();

            string dateMonth = Convert.ToString(currentDate.Month);
            if (currentDate.Month < 10)
            {
                dateMonth = "0" + dateMonth;
            }

            string Query = "INSERT INTO ICT4_MEDIA(ID_MEDIA,TITLE,DATEMEDIA,SUMMARYMEDIA,VIEWMEDIA,FILEPATH,TYPEMEDIA) VALUES(media_seq.nextval,'" + title + "', to_date('" + Convert.ToString(currentDate.Day) + dateMonth + Convert.ToString(currentDate.Year) + "', 'DDMMYYYY'),'" + summaryMedia + "', 50000,'" + filePath + "','" + typeMedia + "')";
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }

        public bool UpdateLikes(string title)
        {
            DatabaseConnection con = new DatabaseConnection();

            //string Query = "UPDATE ICT4_MEDIA SET likes = likes + 1 WHERE title = '" + title + "'";
            string Query = "INSERT INTO ICT4_NOTE(ID_NOTE, ID_USERFK, ID_COMMENTFK, LIKENOTE) VALUESVALUES (note_seq.nextval, 3, 1, 'Y')";
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }

        public bool UpdateReports(string title)
        {
            DatabaseConnection con = new DatabaseConnection();

            string Query = "UPDATE ICT4_MEDIA SET reports = reports + 1 WHERE title = '" + title + "'";
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }

        public bool MakeComment(string comment)
        {
            DatabaseConnection con = new DatabaseConnection();

            string Query = "INSERT INTO ICT4_COMMENT(idComment = 1, commentComment = alksdjf)";
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }

        public bool UpdateViews(Media media)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "UPDATE ICT4_MEDIA SET VIEWMEDIA = VIEWMEDIA + 1 WHERE ID_MEDIA = " + media.ID_Media;
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }
    }
}
