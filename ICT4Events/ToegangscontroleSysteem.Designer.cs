namespace ICT4Events
{
    partial class ToegangscontroleSysteem
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
            this.lblHeeftBetaald = new System.Windows.Forms.Label();
            this.lblReservering = new System.Windows.Forms.Label();
            this.lblEvent = new System.Windows.Forms.Label();
            this.btnStartScanner = new System.Windows.Forms.Button();
            this.btnStopScanner = new System.Windows.Forms.Button();
            this.lblNaam = new System.Windows.Forms.Label();
            this.lblScannerToestand = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHeeftBetaald
            // 
            this.lblHeeftBetaald.AutoSize = true;
            this.lblHeeftBetaald.Location = new System.Drawing.Point(12, 203);
            this.lblHeeftBetaald.Name = "lblHeeftBetaald";
            this.lblHeeftBetaald.Size = new System.Drawing.Size(49, 13);
            this.lblHeeftBetaald.TabIndex = 0;
            this.lblHeeftBetaald.Text = "Betaald: ";
            // 
            // lblReservering
            // 
            this.lblReservering.AutoSize = true;
            this.lblReservering.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblReservering.Location = new System.Drawing.Point(40, 127);
            this.lblReservering.Name = "lblReservering";
            this.lblReservering.Size = new System.Drawing.Size(98, 20);
            this.lblReservering.TabIndex = 1;
            this.lblReservering.Text = "Reservering:";
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(12, 168);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(41, 13);
            this.lblEvent.TabIndex = 2;
            this.lblEvent.Text = "Event: ";
            // 
            // btnStartScanner
            // 
            this.btnStartScanner.Location = new System.Drawing.Point(12, 12);
            this.btnStartScanner.Name = "btnStartScanner";
            this.btnStartScanner.Size = new System.Drawing.Size(94, 23);
            this.btnStartScanner.TabIndex = 3;
            this.btnStartScanner.Text = "Start Scanner";
            this.btnStartScanner.UseVisualStyleBackColor = true;
            this.btnStartScanner.Click += new System.EventHandler(this.btnStartScanner_Click);
            // 
            // btnStopScanner
            // 
            this.btnStopScanner.Location = new System.Drawing.Point(112, 12);
            this.btnStopScanner.Name = "btnStopScanner";
            this.btnStopScanner.Size = new System.Drawing.Size(94, 23);
            this.btnStopScanner.TabIndex = 4;
            this.btnStopScanner.Text = "Stop Scanner";
            this.btnStopScanner.UseVisualStyleBackColor = true;
            this.btnStopScanner.Click += new System.EventHandler(this.btnStopScanner_Click);
            // 
            // lblNaam
            // 
            this.lblNaam.AutoSize = true;
            this.lblNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblNaam.Location = new System.Drawing.Point(12, 75);
            this.lblNaam.Name = "lblNaam";
            this.lblNaam.Size = new System.Drawing.Size(52, 18);
            this.lblNaam.TabIndex = 5;
            this.lblNaam.Text = "Naam:";
            // 
            // lblScannerToestand
            // 
            this.lblScannerToestand.AutoSize = true;
            this.lblScannerToestand.Location = new System.Drawing.Point(29, 38);
            this.lblScannerToestand.Name = "lblScannerToestand";
            this.lblScannerToestand.Size = new System.Drawing.Size(160, 13);
            this.lblScannerToestand.TabIndex = 6;
            this.lblScannerToestand.Text = "Scanner is niet aan het scannen";
            // 
            // ToegangscontroleSysteem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 261);
            this.Controls.Add(this.lblScannerToestand);
            this.Controls.Add(this.lblNaam);
            this.Controls.Add(this.btnStopScanner);
            this.Controls.Add(this.btnStartScanner);
            this.Controls.Add(this.lblEvent);
            this.Controls.Add(this.lblReservering);
            this.Controls.Add(this.lblHeeftBetaald);
            this.Name = "ToegangscontroleSysteem";
            this.Text = "ToegangscontroleSysteem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeeftBetaald;
        private System.Windows.Forms.Label lblReservering;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.Button btnStartScanner;
        private System.Windows.Forms.Button btnStopScanner;
        private System.Windows.Forms.Label lblNaam;
        private System.Windows.Forms.Label lblScannerToestand;
    }
}