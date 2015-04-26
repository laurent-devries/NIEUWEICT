namespace ICT4Events
{
    partial class FormGathering
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSocial = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReservering = new System.Windows.Forms.Button();
            this.btnSMS = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(79, 59);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(220, 37);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login system";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSocial
            // 
            this.btnSocial.Location = new System.Drawing.Point(79, 15);
            this.btnSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSocial.Name = "btnSocial";
            this.btnSocial.Size = new System.Drawing.Size(220, 37);
            this.btnSocial.TabIndex = 1;
            this.btnSocial.Text = "Social sharing system";
            this.btnSocial.UseVisualStyleBackColor = true;
            this.btnSocial.Click += new System.EventHandler(this.btnSocial_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hire system";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(79, 148);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(220, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "EventBeheerReservering";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReservering
            // 
            this.btnReservering.Location = new System.Drawing.Point(79, 192);
            this.btnReservering.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReservering.Name = "btnReservering";
            this.btnReservering.Size = new System.Drawing.Size(220, 37);
            this.btnReservering.TabIndex = 4;
            this.btnReservering.Text = "Reservering";
            this.btnReservering.UseVisualStyleBackColor = true;
            this.btnReservering.Click += new System.EventHandler(this.btnReservering_Click);
            // 
            // btnSMS
            // 
            this.btnSMS.Location = new System.Drawing.Point(79, 236);
            this.btnSMS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSMS.Name = "btnSMS";
            this.btnSMS.Size = new System.Drawing.Size(220, 37);
            this.btnSMS.TabIndex = 5;
            this.btnSMS.Text = "Social Media Sharing 2.0";
            this.btnSMS.UseVisualStyleBackColor = true;
            this.btnSMS.Click += new System.EventHandler(this.btnSMS_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(79, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(220, 37);
            this.button3.TabIndex = 6;
            this.button3.Text = "Toegangscontrole";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormGathering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 364);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnSMS);
            this.Controls.Add(this.btnReservering);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSocial);
            this.Controls.Add(this.btnLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FormGathering";
            this.Text = "FormGathering";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSocial;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReservering;
        private System.Windows.Forms.Button btnSMS;
        private System.Windows.Forms.Button button3;
    }
}