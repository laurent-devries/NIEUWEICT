using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Events
{
    //Laurent de Vries
    class Comment
    {
        //Fields
        int id_Comment;
        int id_media;
        string comment;
        DateTime Date { get; set; }
        User User { get; set; }

        //Constructor
        public Comment(int id_Comment, DateTime date, string comment, int id_media, User user)
        {
            this.id_Comment = id_Comment;
            this.id_media = id_media;
            this.comment = comment;
            Date = date;
            User = user;
        }

        public bool checkAbuse()
        {
            return true;
        }

        public override string ToString()
        {
            return comment + " --- Written by: " + User.Username.ToUpper();
        }
    }
}