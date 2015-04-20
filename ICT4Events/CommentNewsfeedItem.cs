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
        int i = 0;
        int id;
        List<Media> medialist;
        List<Comment> commentList;

        public User UserComment { get; set; }
        public CommentNewsfeedItem(string titel, int id, User user)
        {
            InitializeComponent();
            this.id = id;
            mediaManager = new MediaManager();
            commentManager = new CommentManager();
            UserComment = user;
            medialist = mediaManager.RequestMedia();
            commentList = mediaManager.RequestComments(id);
            

            foreach (Media media in medialist)
            {
                if (media.Title == titel)
                {
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
                }
            }

            foreach (Comment c in commentList)
            {
                lblOpenComment = new Label();
                
                lblOpenComment.Location = new Point(0, lbCommentLoader.Height / 6 * i);
                i++;
                lbCommentLoader.Items.Add(c.ToString());
            }          
            
        }

        private void btnUploadComment_Click(object sender, EventArgs e)
        {
            commentManager.InsertComment(rtbComment.Text, id, UserComment);
        }

        private void CommentNewsfeedItem_Load(object sender, EventArgs e)
        {
            
        }
    }
}
