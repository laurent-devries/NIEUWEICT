using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        // Holder voor het swappen van media
        List<Media> holder;
        MediaManager mediaManager;
        CategoryManager categoryManager;
        TagManager tagManager;
        EventManager eventManager; 
        Media reportedMedia;

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
            eventManager = new EventManager();

            mediaList = mediaManager.RequestMediaUploads(user);
            holder = mediaList;

            this.user = user;
            lblLoginUser.Text = "Ingelogd als: " + user.Username;
            // Kijkt wat de titel van het event is
            string eventTitle = eventManager.RequestEventName(user.ID_EventFK);
            lbEvent.Text = "Event: " + eventTitle;
            this.Text = eventTitle;

            // Kijkt of de user genoeg rechten heeft om de admin page te bekijken
            if (user.Permissionfk != 2)
            {
                // Pagina wordt weggegooit wanneer dit niet het geval is
                tabAdmin.Dispose();
            }
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

            // Vult de comboboxes om te kunnen sorteren
            RefreshData();

            // Vult de posts wanneer het programma geopent wordt
            fillPosts(0);

            
     

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
            if (postNumber + 4 >= mediaList.Count())
            {
                btnNext.Enabled = false;
                // Verandert het aantal groupboxes wanneer er minder gevult moeten worden dan er zijn
                int amount = mediaList.Count - postNumber;
                for (int i = 3; i >= amount; i = i -1)
                {
                    // Zorgt dat de overige groupboxes niet getoond worden
                    groupBoxArray[i].Visible = false;
                }

                if (amount != 0)
                {
                    for (int i = amount; i > 0; i = i - 1)
                    {
                        // Zorgt dat de groupboxes die wel getoond moeten worden getoond worden
                        groupBoxArray[i - 1].Visible = true;
                    }
                }
              
            }

            else
            {
                btnNext.Enabled = true;
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
                
                //Kijkt of er een foto toegevoegd moet worden aan de post
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
            // Laad alle posts opnieuw
            btnRefresh.Enabled = false;
            mediaList = mediaManager.RequestMediaUploads(user);
            btnRefresh.Enabled = true;
            RefreshData();
        }

        private void RefreshData()
        {
            // Vraagt de media lijst opnieuw op
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

            List<Tag> tagList = tagManager.RequestAllTags();
            cbTags.Items.Clear();
            foreach (Tag t in tagList)
            {
                cbTags.Items.Add(t);
            }

            mediaList = mediaManager.RequestMediaUploads(user);
            holder = mediaList;
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
            tbFilepath.Text = "";
            OpenFileDialog fDialog = new OpenFileDialog();
            fDialog.Title = "Open media";
            // Geeft de file types aan
            fDialog.Filter = "BMP|*.bmp|GIF|*.gif|JPG|*.jpg;*.jpeg|PNG|*.png|TIFF|*.tif;*.tiff";
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
            try
            {
                // Pakt de geselecteerde waarde uit de combobox
                int c = cbCategory.SelectedIndex;
                Category category = cbCategory.Items[c] as Category;

                if (!mediaManager.InsertMedia(tbTitle.Text, tbSummary.Text, tbFilepath.Text, "FOTO", currentDate, user, tags, category))
                {
                    MessageBox.Show("Upload mislukt!");
                }

                else
                {
                    // Maakt de upload pagina leeg en gaat vervolgens naar de post pagina
                    MessageBox.Show("Uploaden gelukt");
                    tbTitle.Text = "";
                    tbSummary.Text = "";
                    tbFilepath.Text = "";
                    tbTags.Text = "";
                    tabPage3.Show();
                    pbPreview.Image = null;
                }
            }

            catch
            {
                MessageBox.Show("Selecteer eerst een categorie");
            }

            
        }

        

        // Sorteren
        private void btnSort_Click(object sender, EventArgs e)
        {
            // Maakt een nieuwe lijst om later te verwisselen
            List<Media> swap = new List<Media>();
            // Wordt aangemaakt om te kijken of de lijsten gewisselt moeten worden
            bool swapped = false;

            // Vult de holder met hoe de lijst er op dit moment uit ziet
            mediaList = holder;

            // Sorteren op categorie 
            if (rbCategory.Checked)
            {
                 foreach (Media m in mediaList)
                 {
                     // Kijkt of de categorie namen overeen komen
                     if (m.Category.Name == cbCategorySort.Text)
                     {
                         // Voegt m toe aan de swap list
                         swap.Add(m);
                         swapped = true;
                     }
                 }
                
            }

            // Sorteren op tag
            else if (rbTag.Checked)
            {     
                foreach (Media m in mediaList)
                {
                    // Vult de taglist met alle tags van de media
                    List<Tag> tagList = m.TagList;
                    foreach (Tag t in tagList)
                    {
                        // Kijkt of de media de gezochte tag bevat
                        if (t.Name == cbTags.Text)
                        {
                            // Voegt m toe aan de swap list
                            swap.Add(m);
                            swapped = true;
                        }
                    }
                }
            }

            // Sorteren op titel
            else if (rbTitle.Checked)
            {
                foreach (Media m in mediaList)
                {
                    string title = tbTitleSort.Text;
                    // Kijkt of de title de string bevat
                    if (m.Title.ToUpper().Contains(title.ToUpper()))
                    {
                        // Voegt m toe aan de swap list
                        swap.Add(m);
                        swapped = true;
                    }
                }
            }

            // Wanneer er iets is toegevoegd aan de swap list dan verwisselen de lijsten
            if (swapped)
            {
                mediaList = swap;
                RefreshData();
            }

            // Wanneer er niet is verwisselt wordt de lijst leeg gemaakt
            else
            {
                mediaList = new List<Media>();
                RefreshData();
            }
        }
        #endregion


        #region AdminTab
        private void tabAdmin_Enter(object sender, EventArgs e)
        {
            List<Media> reportedPosts = mediaManager.RequestMediaUploads(user);
            lbReportedPosts.Items.Clear();
            foreach (Media m in reportedPosts)
            {
                if (m.Reports > 0)
                {
                    lbReportedPosts.Items.Add(m);
                }
            }
        }

        #endregion

        private void lbReportedPosts_SelectedValueChanged(object sender, EventArgs e)
        {
            reportedMedia = lbReportedPosts.SelectedItem as Media;

            if (reportedMedia != null)
            {
                // Vult de preview van de geselecteerde pst
                gbAdmin.Text = reportedMedia.Title;
                tbSummaryAdmin.Text = reportedMedia.Title;
                lbLikesAdmin.Text = "Likes: " + reportedMedia.Likes;
                lbReportsAdmin.Text = "Reports: " + reportedMedia.Reports;
                lbViewsAdmin.Text = "Views: " + reportedMedia.Views;
                lbCategorieAdmin.Text = reportedMedia.Category.Name;
                lbUploaderAdmin.Text = reportedMedia.User.ToString();
                lbDateAdmin.Text = reportedMedia.Date;

                List<Tag> tagList = reportedMedia.TagList;
                lbTagsAdmin.Text = "";
                foreach (Tag t in tagList)
                {
                    lbTagsAdmin.Text = lbTagsAdmin.Text + " #" + t.Name;
                }

                if (reportedMedia.File_path != null)
                {
                    try
                    {
                        pbAdmin.Visible = true;
                        pbAdmin.Image = Image.FromFile(reportedMedia.File_path);
                    }

                    catch
                    {
                        pbAdmin.Visible = false;
                    }
                }

                else
                {
                    pbAdmin.Visible = false;
                }

                
            }
        }

        private void tbSummaryAdmin_Click(object sender, EventArgs e)
        {
            // Opent de post in een groter scherm
            if (lbReportedPosts.SelectedItem != null)
            {
                CommentNewsfeedItem c = new CommentNewsfeedItem(reportedMedia, user);
                c.Show();
            }
        }

        private void btnVerwijder_Click(object sender, EventArgs e)
        {
            // Verwijdert de geselecteerde post
            Media media = lbReportedPosts.SelectedItem as Media;
            if (mediaManager.DeleteMedia(media))
            {
                MessageBox.Show("Succesvol verwijdert: " + media.Title);
            }

            else
            {
                MessageBox.Show("Verwijderen van de post is mislukt");
            }
        }


        private void pbImage1_Click(object sender, EventArgs e)
        {
            string path = "";
            foreach (Media m in mediaList)
            {
                if (m.Title == gbNumber1.Text)
                {
                    path = m.File_path;
                    break;
                }
            }
            FileInfo info = new FileInfo(path);
            string filename = Path.GetFileName(path);
            string destination = Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), filename);
            info.CopyTo(destination, true);
        }

        private void tabPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresht de data wanneer de post tab wordt geopent
            if (tabPosts.SelectedIndex == 0)
            {
                RefreshData();
                fillPosts(0);
            }
        }
    }
}