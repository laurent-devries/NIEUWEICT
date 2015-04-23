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
            return mediaList;
        }


        public int CountLikes(int mediaId)
        {
            DatabaseConnection con = new DatabaseConnection();
            string Query = "SELECT COUNT(id_note) FROM ICT4_NOTE WHERE id_mediafk = " + mediaId;

            OracleDataReader reader = con.SelectFromDatabase(Query);
            reader.Read();
            int count = reader.GetInt32(0);
            reader.Dispose();
            return count;
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
                    string insertTag = "INSERT INTO ICT4_TAG (id_tag, tagname) VALUES ( tag_seq.nextval, '" + tags[i] + "')";
                    con.InsertOrUpdate(insertTag);
                    string tagId = "SELECT id_tag FROM ICT4_TAG WHERE tagname = '" + tags[i] + "'";
                    OracleDataReader reader = con.SelectFromDatabase(tagId);
                    reader.Read();
                    tagIdList.Add(reader.GetInt32(0));
                    reader.Dispose();
                }
            }

          



            ////Toevoegen wanneer tag is not in database
            //for (int i = 0; i < tags.Length; i++)
            //{
            //    bool insert = false;
            //    foreach (string t in readTaglist)
            //    {
            //        if (t == tags[i])
            //        {
            //            insert = true;
            //        }

            //    }
            //    if (!insert)
            //    {
            //        string insertNewTag = "INSERT INTO ICT4_TAG(id_Tag, tagName) VALUES(tag_seq.nextval,'" + tags[i] + "')";
            //        string selectTagId = "SELECT ID_TAG FROM ICT4_TAG where tagName = '" + tags[i] + "'";
            //        bool bInsertNewTag = con.InsertOrUpdate(insertNewTag);

            //        OracleDataReader tagReader = con.SelectFromDatabase(selectTagId);
            //        while (tagReader.Read())
            //        {
            //            int tagID = tagReader.GetInt32(0);
            //        }
            //    }
            //}


            string dateMonth = Convert.ToString(currentDate.Month);
            if (currentDate.Month < 10)
            {
                dateMonth = "0" + dateMonth;
            }



            string Query;
            if (filePath == "")
            {
                Query = "INSERT INTO ICT4_MEDIA(ID_MEDIA,TITLE,SUMMARYMEDIA,TYPEMEDIA, ID_USERFK) VALUES(media_seq.nextval,'" + title + "','" + summaryMedia + "', '" + typeMedia + "', " + user.ID_User +")";
                    
            }

            else
            {
                Query = "INSERT INTO ICT4_MEDIA(ID_MEDIA,TITLE,DATEMEDIA,SUMMARYMEDIA,VIEWMEDIA,FILEPATH,TYPEMEDIA) VALUES(media_seq.nextval,'" + title + "', to_date('" + Convert.ToString(currentDate.Day) + dateMonth + Convert.ToString(currentDate.Year) + "', 'DDMMYYYY'),'" + summaryMedia + "', 0,'" + filePath + "','" + typeMedia + "')";
            }
            bool writer = con.InsertOrUpdate(Query);
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
    }
}
