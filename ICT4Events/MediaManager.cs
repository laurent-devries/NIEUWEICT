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
            string Querry = "SELECT TITLE, to_char(DATEMEDIA), SUMMARYMEDIA,  to_char(viewMedia), to_char(likes), to_char(reports), FILEPATH, id_media, ID_USERFK FROM ICT4_MEDIA";

            OracleDataReader reader = con.SelectFromDatabase(Querry);
            Media media;
            UserManager userManager = new UserManager();
            MediaManager mediaManager = new MediaManager();
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
                string filePath;
                try
                {
                    filePath = reader.GetString(6);
                    media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, filePath, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                }

                catch
                {
                    media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                }

                mediaList.Add(media);
            }

            reader.Dispose();
            //con.CloseConnection();//////////////////////////test
            return mediaList;
        }


        public int CountLikes(int mediaId)
        {
            int count = 0;
            try
            {
                DatabaseConnection con = new DatabaseConnection();
                string Query = "SELECT COUNT(id_note) FROM ICT4_NOTE WHERE id_mediafk = " + mediaId;

                OracleDataReader reader = con.SelectFromDatabase(Query);
                reader.Read();
                count = reader.GetInt32(0);
                reader.Close();
                reader.Dispose();
                //con.CloseConnection();//////////////////////////test
                return count;
            }

            catch
            {
                return count;
            }
          
        }

        public bool InsertMedia(string title, string summaryMedia, string filePath, string typeMedia, DateTime currentDate, User user, string[] tags)
        {
            DatabaseConnection con = new DatabaseConnection();


            //READ TAGS
            TagManager tagManager = new TagManager();
            List<Tag> TagList = tagManager.RequestAllTags();
            List<int> tagIdList = new List<int>();

            // Gaat een lijst af om te kijken of de tag al bestaat
            for (int i = 0; i < tags.Length; i++)
            {
                bool insert = true;
                foreach (Tag t in TagList)
                {
                    MessageBox.Show(t.Tag_name + " + " + tags[i]);
                    if (t.Tag_name == tags[i])
                    {
                        insert = false;
                    }
                }

                if (insert)
                {
                    //Voegt de tags toe als ze nog niet bestaan
                    string insertTag = "INSERT INTO ICT4_TAG (id_tag, tagname) VALUES ( tag_seq.nextval, '" + tags[i] + "')";
                    con.InsertOrUpdate(insertTag);
                    string tagId = "SELECT id_tag FROM ICT4_TAG WHERE tagname = '" + tags[i] + "'";
                    OracleDataReader reader = con.SelectFromDatabase(tagId);
                    reader.Read();
                    tagIdList.Add(reader.GetInt32(0));
                    reader.Dispose();
                    //con.CloseConnection();//////////////////////////test
                }
            }



            string dateMonth = Convert.ToString(currentDate.Month);
            if (currentDate.Month < 10)
            {
                dateMonth = "0" + dateMonth;
            }



            string Query;
            //Kijkt of het filepath gevult is of niet
            if (filePath == "ftp://172.16.0.15/")
            {
                Query = "INSERT INTO ICT4_MEDIA(ID_MEDIA,TITLE,SUMMARYMEDIA,TYPEMEDIA, ID_USERFK) VALUES(media_seq.nextval,'" + title + "','" + summaryMedia + "', '" + typeMedia + "', " + user.ID_User +")";
                    
            }

            else
            {
                Query = "INSERT INTO ICT4_MEDIA(ID_MEDIA,TITLE,DATEMEDIA,SUMMARYMEDIA,VIEWMEDIA,FILEPATH,TYPEMEDIA) VALUES(media_seq.nextval,'" + title + "', to_date('" + Convert.ToString(currentDate.Day) + dateMonth + Convert.ToString(currentDate.Year) + "', 'DDMMYYYY'),'" + summaryMedia + "', 0,'" + filePath + "','" + typeMedia + "')";
            }
            bool writer = con.InsertOrUpdate(Query);
            
            string selectMediaId = "SELECT MAX(ID_MEDIA) FROM ICT4_MEDIA WHERE ID_USERFK = " + user.ID_User;
            OracleDataReader r = con.SelectFromDatabase(selectMediaId);
            r.Read();
            int id = r.GetInt32(0);
            r.Dispose();


            //Vult de koppel tabbellen 
            foreach (int i in tagIdList)
            {
                string insertTagMedia = "INSERT INTO ICT4_MEDIA_TAG(ID_MEDIAFK, ID_TAGFK) VALUES (" + id + ", " + i + ")";
                con.InsertOrUpdate(insertTagMedia);
            }
            //con.CloseConnection();//////////////////////////test

            

            return writer;
        }



        public bool UpdateLikes(Media media, User user)
        {
            DatabaseConnection con = new DatabaseConnection();

            string Query = "INSERT INTO ICT4_NOTE(ID_NOTE, ID_USERFK, ID_MEDIAFK, LIKENOTE) VALUES (note_seq.nextval, " + user.ID_User +", " + media.ID_Media +", 'Y')";
            bool writer = con.InsertOrUpdate(Query);
            return writer;
        }

        public bool UpdateReports(User user, Media media)
        {
            DatabaseConnection con = new DatabaseConnection();

            string Query = "INSERT INTO ICT4_NOTE(ID_NOTE, ID_USERFK, ID_MEDIAFK, REPORTNOTE) VALUES (note_seq.nextval, " + user.ID_User + ", " + media.ID_Media + ", 'Y')";
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
        public List<Media> RequestMediaTag(string tagnaam)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "select id_MediaFK from ICT4_MEDIA_TAG where ID_TAGFK = (SELECT id_tag from ICT4_TAG where tagName = '"+ tagnaam + "')";
            OracleDataReader mediaReader = con.SelectFromDatabase(Querry);

            List<int> mediaIDs = new List<int>();
            while (mediaReader.Read())
            {
                mediaIDs.Add(mediaReader.GetInt32(0));
            }
            foreach (int i in mediaIDs)
            {
                string Query = "SELECT TITLE, to_char(DATEMEDIA), SUMMARYMEDIA,  to_char(viewMedia), to_char(likes), to_char(reports), FILEPATH, id_media, ID_USERFK FROM ICT4_MEDIA WHERE id_media = '" + i + "'";
                OracleDataReader reader = con.SelectFromDatabase(Query);
                Media media;
                UserManager userManager = new UserManager();
                MediaManager mediaManager = new MediaManager();
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
                    string filePath;
                    try
                    {
                        filePath = reader.GetString(6);
                        media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, filePath, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                    }

                    catch
                    {
                        media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                    }

                    mediaList.Add(media);
                }

                reader.Dispose();
            }            

            //con.CloseConnection();//////////////////////////test
            return mediaList;
        }
        public List<Media> RequestMediaCategory(string categoryName)
        {
            
            DatabaseConnection con = new DatabaseConnection();
            string Querry = "select id_MediaFK from ICT4_MEDIA_CATEGORY where ID_CATEGORYFK = (SELECT id_category from ICT4_category where categoryName = '" + categoryName + "')";
            OracleDataReader mediaReader = con.SelectFromDatabase(Querry);

            List<int> mediaIDs = new List<int>();
            while (mediaReader.Read())
            {
                mediaIDs.Add(mediaReader.GetInt32(0));
            }
            foreach (int i in mediaIDs)
            {
                string Query = "SELECT TITLE, to_char(DATEMEDIA), SUMMARYMEDIA,  to_char(viewMedia), to_char(likes), to_char(reports), FILEPATH, id_media, ID_USERFK FROM ICT4_MEDIA WHERE id_media = '" + i + "'";
                OracleDataReader reader = con.SelectFromDatabase(Query);
                Media media;
                UserManager userManager = new UserManager();
                MediaManager mediaManager = new MediaManager();
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
                    string filePath;
                    try
                    {
                        filePath = reader.GetString(6);
                        media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, filePath, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                    }

                    catch
                    {
                        media = new Media(reader.GetString(0), reader.GetString(1), reader.GetString(2), Convert.ToInt32(reader.GetString(3)), mediaManager.CountLikes(reader.GetInt32(7)), aantalReports, "VIDEO", reader.GetInt32(7), userManager.SearchUserById(reader.GetInt32(8)));
                    }

                    mediaList.Add(media);
                }

                reader.Dispose();
            }

            //con.CloseConnection();//////////////////////////test
            return mediaList;
        }
    }


}
