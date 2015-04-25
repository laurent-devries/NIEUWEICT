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
    public partial class SocialMediaSharing : Form
    {
        // Teller voor welke media bestanden het form moet laten zien
        int mediaCount = 0;

        List<Media> mediaList;
        MediaManager mediaManager;

        // Arrays van alle objecten
        Label[] viewsArray = new Label[4];
        Label[] likesArray = new Label[4];
        Label[] reportsArray = new Label[4];
        GroupBox[] groupBoxArray = new GroupBox[4];
        TextBox[] summaryArray = new TextBox[4];
        PictureBox[] pictureArray = new PictureBox[4];
        public SocialMediaSharing(User user)
        {
            InitializeComponent();
            mediaManager = new MediaManager();
            mediaList = mediaManager.RequestMediaUploads();

            #region Vullen van arrays
            //Vult alle arrays
            viewsArray[0] = lbViews1;
            viewsArray[1] = lbViews2;
            viewsArray[2] = lbViews3;
            viewsArray[3] = lbViews4;

            likesArray[0] = lbLikes1;
            likesArray[1] = lbLikes2;
            likesArray[2] = lbLikes3;
            likesArray[3] = lbLikes4;

            reportsArray[0] = lbReports1;
            reportsArray[1] = lbReports2;
            reportsArray[2] = lbReports3;
            reportsArray[3] = lbReports4;

            groupBoxArray[0] = gbNumber1;
            groupBoxArray[1] = gbNumber2;
            groupBoxArray[2] = gbNumber3;
            groupBoxArray[3] = gbNumber4;

            summaryArray[0] = tbSummary1;
            summaryArray[1] = tbSummary2;
            summaryArray[2] = tbSummary3;
            summaryArray[3] = tbSummary4;

            pictureArray[0] = pbImage1;
            pictureArray[1] = pbImage2;
            pictureArray[2] = pbImage3;
            pictureArray[3] = pbImage4;
            #endregion


            //Vult de posts wanneer het programma geopent wordt
            fillPosts(0);
     

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (mediaCount < mediaList.Count - 1)
            {
                mediaCount++;
                fillPosts(mediaCount);
            }

            else
            {
                btnNext.Enabled = false;
            }
        }

        private void fillPosts(int postNumber)
        {
            // Vult de eerste post
            lbLikes1.Text = "Likes: " + mediaList[postNumber].Likes;
            lbReports1.Text = "Reports: " + mediaList[postNumber].Reports;
            tbSummary1.Text = mediaList[postNumber].Summary;

            for (int i = 0; i < viewsArray.Length; i++)
            {
                viewsArray[i].Text = "Views: " + mediaList[i + postNumber].Views;
                likesArray[i].Text = "Likes: " + mediaList[i + postNumber].Likes;
                reportsArray[i].Text = "Reports: " + mediaList[i + postNumber].Reports;
                groupBoxArray[i].Text = mediaList[i + postNumber].Title;
                summaryArray[i].Text = mediaList[i + postNumber].Summary;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            mediaList = mediaManager.RequestMediaUploads();
            mediaCount = 0;
            fillPosts(0);
        }

        private void SocialMediaSharing_Load(object sender, EventArgs e)
        {

        }



    }
}
