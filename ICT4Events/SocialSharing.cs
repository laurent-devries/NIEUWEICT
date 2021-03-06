﻿using System;
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

            loadCategories();
            loadTags();
        }

        public SocialSharing(string message)
        {
            MessageBox.Show(message);
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
            countWidth = 0;
            countHeight = 0;
            loadEnder = 6;
            loadStarter = 0;
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
            string path = "";
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
                fDialog.Filter = "All files (*.*)|*.*";
                fDialog.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();

                if (fDialog.ShowDialog() == DialogResult.OK)
                {
                    path = fDialog.FileName;
                    tMediaPath.Text = path;
                    previewImag = Image.FromFile(path);
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
                if (File.Exists(path))
                {
                    previewImage.Load(path);
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

            Label lTag = new Label();
            lTag.Location = new Point(10, pnlNewsFeed.Height / 20 * 15);
            lTag.Text = "Tag";
            lTag.ForeColor = Color.DarkOrange;
            lTag.Font = new Font("Georgia", 13);
            lTag.Width = 140;
            lTag.Height = 25;
            pnlNewsFeed.Controls.Add(lTag);

            Label lTagMax = new Label();
            lTagMax.Location = new Point(10, pnlNewsFeed.Height / 20 * 16);
            lTagMax.Text = "(Max 100characters)";
            lTagMax.ForeColor = Color.DarkOrange;
            lTagMax.Font = new Font("Georgia", 8);
            lTagMax.Width = 140;
            lTagMax.Height = 30;
            pnlNewsFeed.Controls.Add(lTagMax);

            RichTextBox tTag = new RichTextBox();
            tTag.Location = new Point(lTag.Width + 10, pnlNewsFeed.Height / 20 * 15);
            tTag.Width = 150;
            tTag.Height = pnlNewsFeed.Height / 20 * 2;
            tTag.MaxLength = 100;
            tTag.Text = "use '#'between tags";
            pnlNewsFeed.Controls.Add(tTag);

            //Upload
            Button bUpload = new Button();
            bUpload.Location = new Point(lTitleOfMedia.Width + 10, pnlNewsFeed.Height / 20 * 17);
            bUpload.Text = "Upload";
            bUpload.ForeColor = Color.DarkOrange;
            bUpload.Font = new Font("Georgia", 13);
            bUpload.Width = 140;
            bUpload.Height = 30;
            pnlNewsFeed.Controls.Add(bUpload);


            bUpload.Click += delegate
            {
                List<string> tag = new List<string>(tTag.Text.Split('#'));
                tag.RemoveAll(p => string.IsNullOrEmpty(p));
                string [] tags = tag.ToArray();
                MediaManager media = new MediaManager();
                DateTime currentDate = DateTime.Now;
                //media.InsertMedia(tTitleOfMedia.Text, tMediaDescription.Text, path, "test", currentDate, user, tags);
            };
        }

        private void loadCategories()
        {
            cbCategorieCheck.Visible = true;
            List<Category> categorylist = new List<Category>();
            Category category = new Category();
            categorylist = category.RequestCategories();

            foreach (Category c in categorylist)
            {
                cbCategorieCheck.Items.Add(c.ToString());
            }
        }

        private void loadTags()
        {
            List<Tag> tags = new List<Tag>();
            TagManager tm = new TagManager();
            tags = tm.RequestAllTags();

            foreach (Tag t in tags)
            {
                cbTagCheck.Items.Add(t.Name);
            }

        }

        private void cbCategorieCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbTagCheck.Text = "";
            countWidth = 0;
            countHeight = 0;
            loadEnder = 6;
            loadStarter = 0;
            //Laad de media bestanden op het form
            MediaManager mediaData = new MediaManager();
            List<Tag> taglist = new List<Tag>();
            List<Category> categorylist = new List<Category>();
            Category category = new Category();
            categorylist = category.RequestCategories();

            string selectedCategory = cbCategorieCheck.GetItemText(cbCategorieCheck.SelectedItem);
            MessageBox.Show(selectedCategory);
            cbTagCheck.Text = "";
            mediaList = mediaData.RequestMediaCategory(cbCategorieCheck.SelectedText);

            btnNextPage.Visible = true;
            btnPreviousPage.Visible = true;

            //Vraagt de specifieke media bestanden op die nodig zijn die tussen start en end zitten
            if (mediaList.Count < loadEnder)
            {
                loadEnder = mediaList.Count;
                btnNextPage.Enabled = false;
            }

            //Er kan terug geklikt worden wanneer 6 items zijn
            if (loadEnder <= 6)
            {
                btnPreviousPage.Enabled = false;
            }

            pnlNewsFeed.Controls.Clear();
            itemlist.Clear();
            countWidth = 0;
            countHeight = 0;

            //Zet alle media bestanden op de juise plek neer
            for (int i = loadStarter; i < loadEnder; i++)
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


        private void cbTagCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCategorieCheck.Text = "";
            countWidth = 0;
            countHeight = 0;
            loadEnder = 6;
            loadStarter = 0;
            //Laad de media bestanden op het form
            MediaManager mediaData = new MediaManager();
            List<Tag> taglist = new List<Tag>();
            TagManager tm = new TagManager();
            taglist = tm.RequestAllTags();

            string selectedTag = cbTagCheck.GetItemText(cbTagCheck.SelectedItem);
            MessageBox.Show(selectedTag);
            mediaList = mediaData.RequestMediaTag(cbTagCheck.SelectedText);

            btnNextPage.Visible = true;
            btnPreviousPage.Visible = true;

            //Vraagt de specifieke media bestanden op die nodig zijn die tussen start en end zitten
            if (mediaList.Count < loadEnder)
            {
                loadEnder = mediaList.Count;
                btnNextPage.Enabled = false;
            }

            //Er kan terug geklikt worden wanneer 6 items zijn
            if (loadEnder <= 6)
            {
                btnPreviousPage.Enabled = false;
            }

            pnlNewsFeed.Controls.Clear();
            itemlist.Clear();
            countWidth = 0;
            countHeight = 0;

            //Zet alle media bestanden op de juise plek neer
            for (int i = loadStarter; i < loadEnder; i++)
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
    }
}


