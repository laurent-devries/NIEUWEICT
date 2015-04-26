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
        CategoryManager categoryManager;
        TagManager tagManager;

        // Arrays van alle objecten
        Label[] viewsArray = new Label[4];
        Label[] likesArray = new Label[4];
        Label[] reportsArray = new Label[4];
        Label[] uploaderArray = new Label[4];
        Label[] dateArray = new Label[4];
        Label[] categoryArray = new Label[4];
        Label[] tagArray = new Label[4];
        GroupBox[] groupBoxArray = new GroupBox[4];
        TextBox[] summaryArray = new TextBox[4];
        PictureBox[] pictureArray = new PictureBox[4];

        // De user die ingelogd is
        User user;

        public SocialMediaSharing(User user)
        {
            InitializeComponent();
            mediaManager = new MediaManager();
            categoryManager = new CategoryManager();
            tagManager = new TagManager();
            mediaList = mediaManager.RequestMediaUploads();

            this.user = user;

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

            uploaderArray[0] = lbUploader1;
            uploaderArray[1] = lbUploader2;
            uploaderArray[2] = lbUploader3;
            uploaderArray[3] = lbUploader4;

            dateArray[0] = lbDatum1;
            dateArray[1] = lbDatum2;
            dateArray[2] = lbDatum3;
            dateArray[3] = lbDatum4;

            categoryArray[0] = lblCategorie1;
            categoryArray[1] = lblCategorie2;
            categoryArray[2] = lblCategorie3;
            categoryArray[3] = lblCategorie4;

            tagArray[0] = lbTags1;
            tagArray[1] = lbTags2;
            tagArray[2] = lbTags3;
            tagArray[3] = lbTags4;

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


            // Vult de posts wanneer het programma geopent wordt
            fillPosts(0);

            // Vult de comboboxes om te kunnen sorteren
            // Haal de categoryList op
            List<Category> categoryList = categoryManager.RequestCategories();
            List<Tag> tagList = tagManager.RequestAllTags();
            // Voegt alles toe in aan de combobox
            cbCategorySort.Items.Clear();
            cbTags.Items.Clear();
            foreach (Category c in categoryList)
            {
                cbCategorySort.Items.Add(c);
            }

            foreach (Tag t in tagList)
            {
                cbTags.Items.Add(t);
            }


            
     

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            // Kijkt naar welke posts geladen moeten worden
            if (mediaCount < mediaList.Count)
            {
                mediaCount = mediaCount + groupBoxArray.Length;
                fillPosts(mediaCount);
                btnBack.Enabled = true;
            }

            // Kijkt of de next button gedisabeld moet worden
            if (mediaCount + groupBoxArray.Length >= mediaList.Count)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            // Kijkt naar welke posts geladen moeten worden
            if (mediaCount < mediaList.Count)
            {
                mediaCount = mediaCount - 4;
                fillPosts(mediaCount);
                btnNext.Enabled = true;
            }

            // Kijkt of de back button gedisabeld moet worden
            if (mediaCount - groupBoxArray.Length < 0)
            {
                btnBack.Enabled = false;
            }
        }

        private void fillPosts(int postNumber)
        {
            int groupBoxAmount = groupBoxArray.Length;

            if (postNumber + 4 >= mediaList.Count)
            {
                groupBoxAmount = mediaList.Count - postNumber;
            }

            // Kijkt of er minder posts geladen moeten worden dan het aantal groupboxes
            if (postNumber + 4 > mediaList.Count())
            {
                // Verandert het aantal groupboxes wanneer er minder gevult moeten worden dan er zijn

                int amount = mediaList.Count % postNumber;
                for (int i = 3; i >= amount; i = i -1)
                {
                    // Zorgt dat de overige groupboxes niet getoond worden
                    groupBoxArray[i].Visible = false;
                }
            }

            else
            {
                for (int i = 0; i < groupBoxArray.Length; i++)
                {
                    groupBoxArray[i].Visible = true;
                }
            }

            for (int i = 0; i < groupBoxAmount; i++)
            {
                // Vult alle data van de posts
                Media media = mediaList[i + postNumber];
                viewsArray[i].Text = "Views: " + media.Views;
                likesArray[i].Text = "Likes: " + media.Likes;
                reportsArray[i].Text = "Reports: " + media.Reports;
                uploaderArray[i].Text = media.User.Username;
                dateArray[i].Text = media.Date;
                groupBoxArray[i].Text = media.Title;
                summaryArray[i].Text = media.Summary;
                categoryArray[i].Text = media.Category.Name;

                //Voegt alle tags toe
                tagArray[i].Text = "";
                foreach (Tag tag in media.TagList)
                {
                    tagArray[i].Text = tagArray[i].Text + " #" + tag.Name;
                }
                
                //Kijkt of er een foto toegevoegd moet worden
                if (media.File_path != null)
                {
                    try
                    {
                        pictureArray[i].Visible = true;
                        pictureArray[i].Image = Image.FromFile(media.File_path);
                    }

                    catch
                    {
                        pictureArray[i].Visible = false;
                    }
                }

                else
                {
                    pictureArray[i].Visible = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Vraagt de media lijst opnieuw op
            mediaList = mediaManager.RequestMediaUploads();
            mediaCount = 0;
            fillPosts(0);

            // Vult de comboboxes om te kunnen sorteren
            // Haal de categoryList op
            List<Category> categoryList = categoryManager.RequestCategories();

            // Voegt alles toe in aan de combobox
            cbCategorySort.Items.Clear();
            foreach (Category c in categoryList)
            {
                cbCategorySort.Items.Add(c);
            }
           

            // Reset de knoppen
            btnNext.Enabled = true;
            btnBack.Enabled = false;
        }

        // Events voor het klikken op een like linkLabel

        #region Updaten van likes
        private void lbLike1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateLike(0);
        }

        private void lbLike2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateLike(1);
        }

        private void lbLike3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateLike(2);
        }

        private void lbLike4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateLike(3);
        }

        private void updateLike(int position)
        {
            if (!mediaManager.UpdateLikes(mediaList[mediaCount + position], user))
            {
                MessageBox.Show("Er is al geliked");
            }
        }

        #endregion

        #region updaten van reports
        private void lbReport1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateReports(0);
        }

        private void lbReport2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateReports(1);
        }

        private void lbReport3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateReports(2);
        }

        private void lbReport4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            updateReports(3);
        }

        private void updateReports(int position)
        {
            if (!mediaManager.UpdateReports(user, mediaList[mediaCount + position]))
            {
                MessageBox.Show("Je hebt dit al gereport");
            }
        }

        #endregion 

        #region Vergroten van post en commenten

        private void tbSummary1_MouseClick(object sender, MouseEventArgs e)
        {
            CommentNewsfeedItem c = new CommentNewsfeedItem(mediaList[mediaCount], user);
            c.Show();
        }

        private void tbSummary2_MouseClick(object sender, MouseEventArgs e)
        {
            CommentNewsfeedItem c = new CommentNewsfeedItem(mediaList[mediaCount + 1], user);
            c.Show();
        }

        private void tbSummary3_MouseClick(object sender, MouseEventArgs e)
        {
            CommentNewsfeedItem c = new CommentNewsfeedItem(mediaList[mediaCount + 2], user);
            c.Show();
        }

        private void tbSummary4_MouseClick(object sender, MouseEventArgs e)
        {
            CommentNewsfeedItem c = new CommentNewsfeedItem(mediaList[mediaCount + 3], user);
            c.Show();
        }
        #endregion

        #region UploadTab
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string filePath;
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open media";
            // Geeft de file types aan
            fDialog.Filter = "All files (*.*)|*.*";
            fDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

            if (fDialog.ShowDialog() == DialogResult.OK)
            {
                // Geeft een preview van het image wanneer het gelukt is
                filePath = fDialog.FileName;
                tbFilepath.Text = filePath;
                Image previewImage = Image.FromFile(filePath);
                pbPreview.Image = previewImage;
            }
        }


        

        // Vult de lijst met categorieen wanneer de tab upload geopent wordt
        private void tabPage4_Enter(object sender, EventArgs e)
        {
            // Maakt de manager aan
            CategoryManager categoryManager = new CategoryManager();
            // Haal de categoryList op
            List<Category> categoryList = categoryManager.RequestCategories();

            // Voegt alles toe in aan de combobox
            cbCategory.Items.Clear();
            foreach (Category c in categoryList)
            {
                cbCategory.Items.Add(c);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            List<string> tag = new List<string>(tbTags.Text.Split('#'));
            tag.RemoveAll(p => string.IsNullOrEmpty(p));
            string[] tags = tag.ToArray();
            // Pakt de datum van vandaag
            DateTime currentDate = DateTime.Now;
            Category category = cbCategory.SelectedItem as Category;

            if (!mediaManager.InsertMedia(tbTitle.Text, tbSummary.Text, tbFilepath.Text, "FOTO", currentDate, user, tags, category))
            {
                MessageBox.Show("Upload mislukt!");
            }

        }

        #endregion

    }
}
