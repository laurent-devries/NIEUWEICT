using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace ICT4Events
{

    public partial class SocialSharing : Form
    {
        //maakt alle fields aan
        int countWidth = 0;
        int countHeight = 0;
        int loadStarter = 0;
        int loadEnder = 6;
        
        bool startup = false;
        
        List<NewsFeedItem> itemlist = new List<NewsFeedItem>();
        List<Media> mediaList;
        
        TextBox tTitleOfMedia;
        TextBox tMediaPath;
        
        RichTextBox tMediaDescription;
        Image previewImag;
        User user;
        FTPConnection ftp;

        //Geeft een user mee die gebruikt wordt om te kijken welke user ingelogd is
        public SocialSharing(User user)
        {
            InitializeComponent();
            this.user = user;

            //Vraagt alle media tijdens het starten op
            MediaManager mediaData = new MediaManager();
            mediaList = mediaData.RequestMedia();

            //Laad de gegevens van de gebruiker
            lblIngelogdNaam.Location = new Point(this.Width - lblIngelogdNaam.Width - 30, 18);
            pbProfilePicture.Location = new Point(this.Width - lblIngelogdNaam.Width - 85, 2);

            panel1.Location = new Point(0, 0);
            panel1.Width = Width;

            pnlNewsFeed.Location = new Point(Width / 6, Height / 10);
            pnlNewsFeed.Width = Width / 6 * 4;
            pnlNewsFeed.Height = Height / 10 * 8;

            if (startup == false)
            {
                loadMedia(0, 6);
            }

            lblIngelogdNaam.Text = user.Username;

        }

        //btnNextPage
        private void button1_Click(object sender, EventArgs e)
        {
            loadStarter = loadStarter + 6;
            loadEnder = loadStarter + 6;
            loadMedia(loadStarter, loadEnder);

            btnPreviousPage.Enabled = true;
        }

        //btnPreviousPage
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            loadStarter = loadStarter -= 6;
            loadEnder -= 6;
            loadMedia(loadStarter, loadEnder);

            btnNextPage.Enabled = true;
        }

        public void loadMedia(int start, int end)
        {
            //Laad de media bestanden op het form
            MediaManager mediaData = new MediaManager();
            mediaList = mediaData.RequestMedia();

            btnNextPage.Visible = true;
            btnPreviousPage.Visible = true;

            //Vraagt de specifieke media bestanden op die nodig zijn die tussen start en end zitten
                if (mediaList.Count < end)
                {
                    end = mediaList.Count;
                    btnNextPage.Enabled = false;
                }
                
                //Er kan terug geklikt worden wanneer 6 items zijn
                if (end <= 6)
                {
                    btnPreviousPage.Enabled = false;
                }

                pnlNewsFeed.Controls.Clear();
                itemlist.Clear();
                countWidth = 0;
                countHeight = 0;
                
                //Zet alle media bestanden op de juise plek neer
                for (int i = start; i < end; i++)
                {
                    Media media = mediaList[i];
                    Panel p = new Panel();                                            
                    NewsFeedItem item = new NewsFeedItem(media, p, pnlNewsFeed, i, countWidth, countHeight, user, media.ID_Media);
                    

                    //Geeft de positie op de x as aan
                    countWidth++;

                    if (countWidth > 2)
                    {
                        //Geeft positie op y as en reset de x as
                        countHeight++;
                        countWidth = 0;
                    }
                    //Voegt de items aan de itemlist toe
                    itemlist.Add(item);
                }

            foreach (NewsFeedItem item in itemlist)
            {
                //Alle medie/newsfeeditems worden aan het form toegevoegd
                pnlNewsFeed.Controls.Add(item.Panel);
                Panel p = item.Panel;
                p.ForeColor = Color.CadetBlue;
                p.BringToFront();
            }
        }

        //HomeButton
        private void btnHome_Click(object sender, EventArgs e)
        {
            loadMedia(loadStarter, loadEnder);
        }

        //UploadButton
        private void button2_Click(object sender, EventArgs e)
        {
            pnlNewsFeed.Controls.Clear();
            btnNextPage.Visible = false;
            btnPreviousPage.Visible = false;
            loadUploadingScreen();
        }

        public void loadUploadingScreen()
        {
            //Maakt de ftp connectie
            ftp = new FTPConnection(@"ftp://172.16.0.15/", "client", "1233");
            string s = "";
            string q = "";
            string localfile = "";
            //Titel
            Label Titel = new Label();
            Titel.Location = new Point(0, 5);
            Titel.Text = "Upload";
            Titel.ForeColor = Color.DarkOrange;
            Titel.Font = new Font("Georgia", 20, FontStyle.Underline);
            Titel.AutoSize = false;
            Titel.TextAlign = ContentAlignment.MiddleCenter;
            Titel.Width = pnlNewsFeed.Width;
            Titel.Height = 40;
            pnlNewsFeed.Controls.Add(Titel);

            //TitelOfMedia
            Label lTitleOfMedia = new Label();
            lTitleOfMedia.Location = new Point(10, pnlNewsFeed.Height / 10 * 2);
            lTitleOfMedia.Text = "Title of Media";
            lTitleOfMedia.ForeColor = Color.DarkOrange;
            lTitleOfMedia.Font = new Font("Georgia", 13);
            lTitleOfMedia.Width = 140;
            lTitleOfMedia.Height = 20;
            pnlNewsFeed.Controls.Add(lTitleOfMedia);

            tTitleOfMedia = new TextBox();
            tTitleOfMedia.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 10 * 2);
            tTitleOfMedia.Width = 150;
            pnlNewsFeed.Controls.Add(tTitleOfMedia);

            //MediaDescription
            Label lMediaDescription = new Label();
            lMediaDescription.Location = new Point(10, pnlNewsFeed.Height / 10 * 3);
            lMediaDescription.Text = "Description";
            lMediaDescription.ForeColor = Color.DarkOrange;
            lMediaDescription.Font = new Font("Georgia", 13);
            lMediaDescription.Width = 140;
            lMediaDescription.Height = 20;
            pnlNewsFeed.Controls.Add(lMediaDescription);

            tMediaDescription = new RichTextBox();
            tMediaDescription.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 10 * 3);
            tMediaDescription.Width = 150;
            tMediaDescription.Height = tTitleOfMedia.Height * 3;
            pnlNewsFeed.Controls.Add(tMediaDescription);

            //MediaPath
            Label lMediaPath = new Label();
            lMediaPath.Location = new Point(10, pnlNewsFeed.Height / 10 * 5);
            lMediaPath.Text = "MediaPath";
            lMediaPath.ForeColor = Color.DarkOrange;
            lMediaPath.Font = new Font("Georgia", 13);
            lMediaPath.Width = 140;
            lMediaPath.Height = 20;
            pnlNewsFeed.Controls.Add(lMediaPath);


            //Button mediapath
            Button bMediaPath = new Button();
            bMediaPath.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 10 * 5 - 1);
            bMediaPath.Text = "Browse";
            pnlNewsFeed.Controls.Add(bMediaPath);
            bMediaPath.Click += delegate
            {
                OpenFileDialog fDialog = new OpenFileDialog();
                fDialog.Title = "Open media";
                fDialog.Filter = "IMAGE Files|*.jpg";
                fDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    tMediaPath.Text = fDialog.FileName;
                    previewImag = Image.FromFile(tMediaPath.Text);
                    s = Path.GetFileName(fDialog.FileName);
                    localfile = fDialog.FileName;
                    q = Path.Combine("ftp://172.16.0.15/", s);
                }
            };

            //Preview image

            PictureBox previewImage = new PictureBox();
            previewImage.Location = new Point(pnlNewsFeed.Width / 4 * 2 + 20, pnlNewsFeed.Height / 10 * 2 + pnlNewsFeed.Height / 20);
            previewImage.BackColor = Color.Transparent;
            previewImage.SizeMode = PictureBoxSizeMode.Zoom;
            previewImage.MaximumSize = new System.Drawing.Size(600, 600);
            previewImage.MinimumSize = new System.Drawing.Size(200, 200);
            pnlNewsFeed.Controls.Add(previewImage);

            Button bTry = new Button();
            bTry.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 10 * 5 + bMediaPath.Height);
            bTry.Text = "Try";
            pnlNewsFeed.Controls.Add(bTry);
            bTry.Click += delegate
            {
                if (File.Exists(tMediaPath.Text))
                {
                    previewImage.Load(tMediaPath.Text);
                }
            };

            tMediaPath = new TextBox();
            tMediaPath.Location = new Point(lTitleOfMedia.Width + bMediaPath.Width + 10, pnlNewsFeed.Height / 10 * 5);
            tMediaPath.Width = 150 - bMediaPath.Width;
            pnlNewsFeed.Controls.Add(tMediaPath);

            //Preview
            Label lPreview = new Label();
            lPreview.Location = new Point(pnlNewsFeed.Width / 4 * 2 + 20, pnlNewsFeed.Height / 10 * 2);
            lPreview.Text = "Preview";
            lPreview.ForeColor = Color.DarkOrange;
            lPreview.Font = new Font("Georgia", 13);
            lPreview.Width = 140;
            lPreview.Height = 20;
            pnlNewsFeed.Controls.Add(lPreview);


            //Categorie
            Label lCategorie = new Label();
            lCategorie.Location = new Point(10, pnlNewsFeed.Height / 20 * 13);
            lCategorie.Text = "Categorie";
            lCategorie.ForeColor = Color.DarkOrange;
            lCategorie.Font = new Font("Georgia", 13);
            lCategorie.Width = 140;
            lCategorie.Height = 30;
            pnlNewsFeed.Controls.Add(lCategorie);


            ComboBox cbCategorie = new ComboBox();
            cbCategorie.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 20 * 13);
            cbCategorie.Width = 150;
            cbCategorie.Height = tTitleOfMedia.Height * 3;
            pnlNewsFeed.Controls.Add(cbCategorie);

            Category categoryData = new Category();
            foreach (Category c in categoryData.RequestCategories())
            {
                cbCategorie.Items.Add(c);
            }

            //Upload
            Button bUpload = new Button();
            bUpload.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 20 * 15);
            bUpload.Text = "Upload";
            bUpload.ForeColor = Color.DarkOrange;
            bUpload.Font = new Font("Georgia", 13);
            bUpload.Width = 140;
            bUpload.Height = 30;
            pnlNewsFeed.Controls.Add(bUpload);


            bUpload.Click += delegate
            {
                MediaManager media = new MediaManager();
                DateTime currentDate = DateTime.Now;
                media.InsertMedia(tTitleOfMedia.Text, tMediaDescription.Text, tMediaPath.Text, "anus", currentDate);
                ftp.upload(q, localfile);
            };
        }
    }
}


