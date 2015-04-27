namespace ICT4Events
{
    partial class CommentNewsfeedItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.btnComment = new System.Windows.Forms.Button();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblLikes = new System.Windows.Forms.Label();
            this.pbMedia = new System.Windows.Forms.PictureBox();
            this.rtbSummary = new System.Windows.Forms.RichTextBox();
            this.lbCommentLoader = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbComment
            // 
            this.rtbComment.Location = new System.Drawing.Point(277, 407);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(269, 40);
            this.rtbComment.TabIndex = 0;
            this.rtbComment.Text = "";
            // 
            // btnComment
            // 
            this.btnComment.Location = new System.Drawing.Point(552, 424);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(75, 23);
            this.btnComment.TabIndex = 1;
            this.btnComment.Text = "Upload";
            this.btnComment.UseVisualStyleBackColor = true;
            this.btnComment.Click += new System.EventHandler(this.btnUploadComment_Click);
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitel.Location = new System.Drawing.Point(5, 9);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(45, 22);
            this.lblTitel.TabIndex = 3;
            this.lblTitel.Text = "Titel";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatum.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblDatum.Location = new System.Drawing.Point(358, 1);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(54, 18);
            this.lblDatum.TabIndex = 4;
            this.lblDatum.Text = "Datum";
            // 
            // lblViews
            // 
            this.lblViews.AutoSize = true;
            this.lblViews.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblViews.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblViews.Location = new System.Drawing.Point(523, 23);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(43, 16);
            this.lblViews.TabIndex = 5;
            this.lblViews.Text = "Views";
            // 
            // lblLikes
            // 
            this.lblLikes.AutoSize = true;
            this.lblLikes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLikes.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLikes.Location = new System.Drawing.Point(523, 1);
            this.lblLikes.Name = "lblLikes";
            this.lblLikes.Size = new System.Drawing.Size(39, 16);
            this.lblLikes.TabIndex = 6;
            this.lblLikes.Text = "Likes";
            // 
            // pbMedia
            // 
            this.pbMedia.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbMedia.Location = new System.Drawing.Point(8, 44);
            this.pbMedia.Name = "pbMedia";
            this.pbMedia.Size = new System.Drawing.Size(263, 289);
            this.pbMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedia.TabIndex = 7;
            this.pbMedia.TabStop = false;
            // 
            // rtbSummary
            // 
            this.rtbSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.rtbSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSummary.Location = new System.Drawing.Point(8, 339);
            this.rtbSummary.Name = "rtbSummary";
            this.rtbSummary.Size = new System.Drawing.Size(263, 108);
            this.rtbSummary.TabIndex = 8;
            this.rtbSummary.Text = "";
            // 
            // lbCommentLoader
            // 
            this.lbCommentLoader.FormattingEnabled = true;
            this.lbCommentLoader.Location = new System.Drawing.Point(277, 44);
            this.lbCommentLoader.Name = "lbCommentLoader";
            this.lbCommentLoader.Size = new System.Drawing.Size(346, 355);
            this.lbCommentLoader.TabIndex = 9;
            // 
            // CommentNewsfeedItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(636, 460);
            this.Controls.Add(this.lbCommentLoader);
            this.Controls.Add(this.rtbSummary);
            this.Controls.Add(this.pbMedia);
            this.Controls.Add(this.lblLikes);
            this.Controls.Add(this.lblViews);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.rtbComment);
            this.Name = "CommentNewsfeedItem";
            this.Text = "CommentNewsfeedItem";
            this.Load += new System.EventHandler(this.CommentNewsfeedItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMedia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblLikes;
        private System.Windows.Forms.PictureBox pbMedia;
        private System.Windows.Forms.RichTextBox rtbSummary;
        private System.Windows.Forms.ListBox lbCommentLoader;
    }
}