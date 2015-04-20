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
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(59, 48);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(165, 30);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login system";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnSocial
            // 
            this.btnSocial.Location = new System.Drawing.Point(59, 12);
            this.btnSocial.Name = "btnSocial";
            this.btnSocial.Size = new System.Drawing.Size(165, 30);
            this.btnSocial.TabIndex = 1;
            this.btnSocial.Text = "Social sharing system";
            this.btnSocial.UseVisualStyleBackColor = true;
            this.btnSocial.Click += new System.EventHandler(this.btnSocial_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Hire system";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(59, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(165, 30);
            this.button2.TabIndex = 3;
            this.button2.Text = "EventBeheerReservering";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnReservering
            // 
            this.btnReservering.Location = new System.Drawing.Point(59, 156);
            this.btnReservering.Name = "btnReservering";
            this.btnReservering.Size = new System.Drawing.Size(165, 30);
            this.btnReservering.TabIndex = 4;
            this.btnReservering.Text = "Reservering";
            this.btnReservering.UseVisualStyleBackColor = true;
            this.btnReservering.Click += new System.EventHandler(this.btnReservering_Click);
            // 
            // FormGathering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnReservering);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSocial);
            this.Controls.Add(this.btnLogin);
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
    }
}