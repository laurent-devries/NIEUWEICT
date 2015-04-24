using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Events
{
    public partial class CommentNewsfeedItem : Form
    {
        MediaManager mediaManager;
        CommentManager commentManager;
        Label lblOpenComment;
        List<Media> medialist;
        List<Comment> commentList;

        Media mediaComment;
        User userComment;
        public CommentNewsfeedItem(Media media, User user)
        {
            InitializeComponent();
            //Maakt de managers aan
            mediaManager = new MediaManager();
            commentManager = new CommentManager();
            //Vult die fields
            userComment = user;
            mediaComment = media;
         
            //Update de views
            mediaManager.UpdateViews(media);

            //Vult het form met de eigenschappen van de media
            lblTitel.Text = media.Title;
            lblDatum.Text = media.Date;
            lblLikes.Text = "Likes : " + media.Likes.ToString();
            lblViews.Text = "Views : " + media.Views.ToString();
            rtbSummary.Text = media.Summary;
            try
            {
                pbMedia.Load(media.File_path);
            }
            catch
            {

            }

            RefreshComments();
            
        }

        private void btnUploadComment_Click(object sender, EventArgs e)
        {
            //Voegt de comments toe
            commentManager.InsertComment(rtbComment.Text, mediaComment.ID_Media, userComment);
            Refresh();
        }

        private void RefreshComments()
        {
            //Voegt de comments toe
            int row = 0;
            //Vraagt de bijhorende comments op
            if (commentList != null)
            {
                commentList.Clear();
            }
            commentList = commentManager.RequestComments(mediaComment.ID_Media);
            //Maakt de lijst leeg
            lbCommentLoader.Items.Clear();

            
            foreach (Comment c in commentList)
            {
                lblOpenComment = new Label();

                lblOpenComment.Location = new Point(0, lbCommentLoader.Height / 6 * row);
                row++;
                lbCommentLoader.Items.Add(c.ToString());
            }    
        }

        private void CommentNewsfeedItem_Load(object sender, EventArgs e)
        {
            
        }
    }
}
