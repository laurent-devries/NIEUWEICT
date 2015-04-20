using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{
    //Laurent de Vries
    public class Media
    {
        //Fields
        private static int idnumber = 0;
        private int id_media;
        private int likes;
        private int reports;
        private int views;

        private List<Media> mediaList;

        //Properties
        public string Title { get; set; }
        public string Date { get; set; }
        public string Summary { get; set; }
        public int Views { get { return views; } set { views = value; } }
        public string File_path { get; set; }
        public string Type_Media { get; set; }
        public int ID_Media { get { return id_media; } set { id_media = value; } }
        public int Likes { get { return likes; } set { likes = value; } }
        public int Reports { get { return reports; } set { reports = value; } }
        //Methods
        public Media(string title, string date, string summary, int views, int likes, int reports, string file_Path, string type_Media, int idmedia)
        {
            ID_Media = idmedia;
            Title = title;
            Date = date;
            Summary = summary;
            Views = views;
            File_path = file_Path;
            Type_Media = type_Media;
            Likes = likes;
            Reports = reports;
        }

        public Media()
        {
            mediaList = new List<Media>();

        }

        public bool CheckAbuse(string abusiveWord)
        {
            return true;
        }

        public int GetLikes()
        {
            return likes;
        }

        public int getReports()
        {
            return reports;
        }

        public int getViews()
        {
            return views;
        }
    }
}
