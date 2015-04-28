namespace ICT4Events
{
    partial class ReserveringSysteem
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAankomst = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbEvents = new System.Windows.Forms.ComboBox();
            this.dtpAankomst = new System.Windows.Forms.DateTimePicker();
            this.dtpVertrek = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPlaces = new System.Windows.Forms.ComboBox();
            this.gb_gebruikercreatie = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_achternaam_user = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_password_gebruiker = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_loginname_gebruiker = new System.Windows.Forms.TextBox();
            this.tb_username_gebruiker = new System.Windows.Forms.TextBox();
            this.lb_Username_gebruiker = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_telnr_gebruiker = new System.Windows.Forms.TextBox();
            this.lb_addres_stad_gebruiker = new System.Windows.Forms.Label();
            this.tb_stad_user = new System.Windows.Forms.TextBox();
            this.tb_number_user = new System.Windows.Forms.TextBox();
            this.lb_addres_nummer_gebruiker = new System.Windows.Forms.Label();
            this.lb_addres_straat_gebruiker = new System.Windows.Forms.Label();
            this.tb_straat_user = new System.Windows.Forms.TextBox();
            this.cb_land_gebruiker = new System.Windows.Forms.ComboBox();
            this.lb_land_gebruiker = new System.Windows.Forms.Label();
            this.tb_email_gebruiker = new System.Windows.Forms.TextBox();
            this.lb_email_gebruiker = new System.Windows.Forms.Label();
            this.dtp_geboortedatum_gebruiker = new System.Windows.Forms.DateTimePicker();
            this.lb_geboortedatum_gebruiker = new System.Windows.Forms.Label();
            this.lb_naam_gebruiker = new System.Windows.Forms.Label();
            this.tb_voornaam_gebruiker = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudAantal = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.cbSoortPlaats = new System.Windows.Forms.ComboBox();
            this.gbVerhuur = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbGehuurd = new System.Windows.Forms.ListBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbProducten = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_gebruikercreatie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAantal)).BeginInit();
            this.gbVerhuur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kies een evenement:";
            // 
            // lblAankomst
            // 
            this.lblAankomst.AutoSize = true;
            this.lblAankomst.Location = new System.Drawing.Point(13, 92);
            this.lblAankomst.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAankomst.Name = "lblAankomst";
            this.lblAankomst.Size = new System.Drawing.Size(74, 17);
            this.lblAankomst.TabIndex = 2;
            this.lblAankomst.Text = "Aankomst:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 122);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vertrek:";
            // 
            // cbEvents
            // 
            this.cbEvents.FormattingEnabled = true;
            this.cbEvents.Location = new System.Drawing.Point(151, 55);
            this.cbEvents.Margin = new System.Windows.Forms.Padding(4);
            this.cbEvents.Name = "cbEvents";
            this.cbEvents.Size = new System.Drawing.Size(265, 24);
            this.cbEvents.TabIndex = 4;
            this.cbEvents.SelectedValueChanged += new System.EventHandler(this.cbEvents_SelectedValueChanged);
            // 
            // dtpAankomst
            // 
            this.dtpAankomst.Location = new System.Drawing.Point(151, 87);
            this.dtpAankomst.Margin = new System.Windows.Forms.Padding(4);
            this.dtpAankomst.Name = "dtpAankomst";
            this.dtpAankomst.Size = new System.Drawing.Size(265, 22);
            this.dtpAankomst.TabIndex = 5;
            // 
            // dtpVertrek
            // 
            this.dtpVertrek.Location = new System.Drawing.Point(151, 117);
            this.dtpVertrek.Margin = new System.Windows.Forms.Padding(4);
            this.dtpVertrek.Name = "dtpVertrek";
            this.dtpVertrek.Size = new System.Drawing.Size(265, 22);
            this.dtpVertrek.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 181);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Kies een plaats:";
            // 
            // cbPlaces
            // 
            this.cbPlaces.FormattingEnabled = true;
            this.cbPlaces.Location = new System.Drawing.Point(151, 178);
            this.cbPlaces.Margin = new System.Windows.Forms.Padding(4);
            this.cbPlaces.Name = "cbPlaces";
            this.cbPlaces.Size = new System.Drawing.Size(324, 24);
            this.cbPlaces.TabIndex = 8;
            // 
            // gb_gebruikercreatie
            // 
            this.gb_gebruikercreatie.Controls.Add(this.button2);
            this.gb_gebruikercreatie.Controls.Add(this.tb_achternaam_user);
            this.gb_gebruikercreatie.Controls.Add(this.label9);
            this.gb_gebruikercreatie.Controls.Add(this.tb_password_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.label4);
            this.gb_gebruikercreatie.Controls.Add(this.label5);
            this.gb_gebruikercreatie.Controls.Add(this.tb_loginname_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_username_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_Username_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.label6);
            this.gb_gebruikercreatie.Controls.Add(this.tb_telnr_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_addres_stad_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_stad_user);
            this.gb_gebruikercreatie.Controls.Add(this.tb_number_user);
            this.gb_gebruikercreatie.Controls.Add(this.lb_addres_nummer_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_addres_straat_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_straat_user);
            this.gb_gebruikercreatie.Controls.Add(this.cb_land_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_land_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_email_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_email_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.dtp_geboortedatum_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_geboortedatum_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_naam_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_voornaam_gebruiker);
            this.gb_gebruikercreatie.Enabled = false;
            this.gb_gebruikercreatie.Location = new System.Drawing.Point(20, 274);
            this.gb_gebruikercreatie.Margin = new System.Windows.Forms.Padding(4);
            this.gb_gebruikercreatie.Name = "gb_gebruikercreatie";
            this.gb_gebruikercreatie.Padding = new System.Windows.Forms.Padding(4);
            this.gb_gebruikercreatie.Size = new System.Drawing.Size(568, 409);
            this.gb_gebruikercreatie.TabIndex = 9;
            this.gb_gebruikercreatie.TabStop = false;
            this.gb_gebruikercreatie.Text = "Account aanmaken";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(432, 38);
            this.button2.TabIndex = 19;
            this.button2.Text = "Bevestig";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBevestigUser_Click);
            // 
            // tb_achternaam_user
            // 
            this.tb_achternaam_user.Location = new System.Drawing.Point(367, 54);
            this.tb_achternaam_user.Margin = new System.Windows.Forms.Padding(4);
            this.tb_achternaam_user.Name = "tb_achternaam_user";
            this.tb_achternaam_user.Size = new System.Drawing.Size(192, 22);
            this.tb_achternaam_user.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 59);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 17);
            this.label9.TabIndex = 26;
            this.label9.Text = "Achternaam:";
            // 
            // tb_password_gebruiker
            // 
            this.tb_password_gebruiker.Location = new System.Drawing.Point(127, 335);
            this.tb_password_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_password_gebruiker.MaxLength = 255;
            this.tb_password_gebruiker.Name = "tb_password_gebruiker";
            this.tb_password_gebruiker.ShortcutsEnabled = false;
            this.tb_password_gebruiker.Size = new System.Drawing.Size(432, 22);
            this.tb_password_gebruiker.TabIndex = 19;
            this.tb_password_gebruiker.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 338);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Wachtwoord:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Inlognaam:";
            // 
            // tb_loginname_gebruiker
            // 
            this.tb_loginname_gebruiker.Location = new System.Drawing.Point(128, 271);
            this.tb_loginname_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_loginname_gebruiker.MaxLength = 17;
            this.tb_loginname_gebruiker.Name = "tb_loginname_gebruiker";
            this.tb_loginname_gebruiker.Size = new System.Drawing.Size(431, 22);
            this.tb_loginname_gebruiker.TabIndex = 17;
            // 
            // tb_username_gebruiker
            // 
            this.tb_username_gebruiker.Location = new System.Drawing.Point(127, 303);
            this.tb_username_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_username_gebruiker.MaxLength = 255;
            this.tb_username_gebruiker.Name = "tb_username_gebruiker";
            this.tb_username_gebruiker.Size = new System.Drawing.Size(432, 22);
            this.tb_username_gebruiker.TabIndex = 18;
            // 
            // lb_Username_gebruiker
            // 
            this.lb_Username_gebruiker.AutoSize = true;
            this.lb_Username_gebruiker.Location = new System.Drawing.Point(8, 306);
            this.lb_Username_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Username_gebruiker.Name = "lb_Username_gebruiker";
            this.lb_Username_gebruiker.Size = new System.Drawing.Size(117, 17);
            this.lb_Username_gebruiker.TabIndex = 18;
            this.lb_Username_gebruiker.Text = "Gebruikersnaam:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 242);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Tel.Nr:";
            // 
            // tb_telnr_gebruiker
            // 
            this.tb_telnr_gebruiker.Location = new System.Drawing.Point(127, 239);
            this.tb_telnr_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_telnr_gebruiker.MaxLength = 20;
            this.tb_telnr_gebruiker.Name = "tb_telnr_gebruiker";
            this.tb_telnr_gebruiker.Size = new System.Drawing.Size(432, 22);
            this.tb_telnr_gebruiker.TabIndex = 16;
            this.tb_telnr_gebruiker.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_telnr_gebruiker_KeyPress);
            // 
            // lb_addres_stad_gebruiker
            // 
            this.lb_addres_stad_gebruiker.AutoSize = true;
            this.lb_addres_stad_gebruiker.Location = new System.Drawing.Point(8, 210);
            this.lb_addres_stad_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_addres_stad_gebruiker.Name = "lb_addres_stad_gebruiker";
            this.lb_addres_stad_gebruiker.Size = new System.Drawing.Size(37, 17);
            this.lb_addres_stad_gebruiker.TabIndex = 13;
            this.lb_addres_stad_gebruiker.Text = "Stad";
            // 
            // tb_stad_user
            // 
            this.tb_stad_user.Location = new System.Drawing.Point(127, 207);
            this.tb_stad_user.Margin = new System.Windows.Forms.Padding(4);
            this.tb_stad_user.MaxLength = 255;
            this.tb_stad_user.Name = "tb_stad_user";
            this.tb_stad_user.Size = new System.Drawing.Size(238, 22);
            this.tb_stad_user.TabIndex = 12;
            // 
            // tb_number_user
            // 
            this.tb_number_user.Location = new System.Drawing.Point(444, 175);
            this.tb_number_user.Margin = new System.Windows.Forms.Padding(4);
            this.tb_number_user.MaxLength = 10;
            this.tb_number_user.Name = "tb_number_user";
            this.tb_number_user.Size = new System.Drawing.Size(116, 22);
            this.tb_number_user.TabIndex = 11;
            // 
            // lb_addres_nummer_gebruiker
            // 
            this.lb_addres_nummer_gebruiker.AutoSize = true;
            this.lb_addres_nummer_gebruiker.Location = new System.Drawing.Point(376, 178);
            this.lb_addres_nummer_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_addres_nummer_gebruiker.Name = "lb_addres_nummer_gebruiker";
            this.lb_addres_nummer_gebruiker.Size = new System.Drawing.Size(53, 17);
            this.lb_addres_nummer_gebruiker.TabIndex = 10;
            this.lb_addres_nummer_gebruiker.Text = "Huisnr.";
            // 
            // lb_addres_straat_gebruiker
            // 
            this.lb_addres_straat_gebruiker.AutoSize = true;
            this.lb_addres_straat_gebruiker.Location = new System.Drawing.Point(8, 178);
            this.lb_addres_straat_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_addres_straat_gebruiker.Name = "lb_addres_straat_gebruiker";
            this.lb_addres_straat_gebruiker.Size = new System.Drawing.Size(46, 17);
            this.lb_addres_straat_gebruiker.TabIndex = 9;
            this.lb_addres_straat_gebruiker.Text = "Straat";
            // 
            // tb_straat_user
            // 
            this.tb_straat_user.Location = new System.Drawing.Point(128, 175);
            this.tb_straat_user.Margin = new System.Windows.Forms.Padding(4);
            this.tb_straat_user.MaxLength = 255;
            this.tb_straat_user.Name = "tb_straat_user";
            this.tb_straat_user.Size = new System.Drawing.Size(237, 22);
            this.tb_straat_user.TabIndex = 8;
            // 
            // cb_land_gebruiker
            // 
            this.cb_land_gebruiker.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cb_land_gebruiker.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_land_gebruiker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_land_gebruiker.FormattingEnabled = true;
            this.cb_land_gebruiker.Items.AddRange(new object[] {
            "Alandseilanden",
            "Albanië",
            "Andorra",
            "Azerbeidzjan",
            "Belarus (Wit-Rusland)",
            "België",
            "Bosnië en Herzegovina",
            "Bulgarije",
            "Cyprus",
            "Denemarken",
            "Duitsland",
            "Engeland (Verenigd Koningrijk)",
            "Estland",
            "Farao Eilanden",
            "Finland",
            "Frankrijk",
            "Georgië",
            "Gibraltar",
            "Griekenland",
            "Guernsey",
            "Hongarije",
            "Ierland",
            "IJsland",
            "Italië",
            "Jan Mayen",
            "Jersey",
            "Kazachstan",
            "Kosovo",
            "Kroatië",
            "Letland",
            "Liechtenstein",
            "Litouwen",
            "Luxemburg",
            "Macedonië",
            "Malta",
            "Man",
            "Moldavië",
            "Monaco",
            "Montenegro",
            "Nederland",
            "Noorwegen",
            "Oekraïne",
            "Oostenrijk",
            "Polen",
            "Portugal",
            "Roemenië",
            "Rusland",
            "San Marino",
            "Schotland (Verenigd Koninkrijk)",
            "Servië",
            "Slovenië",
            "Slowakije",
            "Spanje",
            "Spitsbergen",
            "Tsjechië",
            "Turkije",
            "Vaticaanstad",
            "Zweden",
            "Zwitserland"});
            this.cb_land_gebruiker.Location = new System.Drawing.Point(128, 145);
            this.cb_land_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.cb_land_gebruiker.Name = "cb_land_gebruiker";
            this.cb_land_gebruiker.Size = new System.Drawing.Size(431, 24);
            this.cb_land_gebruiker.Sorted = true;
            this.cb_land_gebruiker.TabIndex = 7;
            // 
            // lb_land_gebruiker
            // 
            this.lb_land_gebruiker.AutoSize = true;
            this.lb_land_gebruiker.Location = new System.Drawing.Point(9, 148);
            this.lb_land_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_land_gebruiker.Name = "lb_land_gebruiker";
            this.lb_land_gebruiker.Size = new System.Drawing.Size(40, 17);
            this.lb_land_gebruiker.TabIndex = 6;
            this.lb_land_gebruiker.Text = "Land";
            // 
            // tb_email_gebruiker
            // 
            this.tb_email_gebruiker.Location = new System.Drawing.Point(128, 114);
            this.tb_email_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_email_gebruiker.MaxLength = 255;
            this.tb_email_gebruiker.Name = "tb_email_gebruiker";
            this.tb_email_gebruiker.Size = new System.Drawing.Size(431, 22);
            this.tb_email_gebruiker.TabIndex = 5;
            // 
            // lb_email_gebruiker
            // 
            this.lb_email_gebruiker.AutoSize = true;
            this.lb_email_gebruiker.Location = new System.Drawing.Point(9, 117);
            this.lb_email_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_email_gebruiker.Name = "lb_email_gebruiker";
            this.lb_email_gebruiker.Size = new System.Drawing.Size(51, 17);
            this.lb_email_gebruiker.TabIndex = 4;
            this.lb_email_gebruiker.Text = "E-Mail:";
            // 
            // dtp_geboortedatum_gebruiker
            // 
            this.dtp_geboortedatum_gebruiker.Location = new System.Drawing.Point(128, 84);
            this.dtp_geboortedatum_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.dtp_geboortedatum_gebruiker.Name = "dtp_geboortedatum_gebruiker";
            this.dtp_geboortedatum_gebruiker.Size = new System.Drawing.Size(431, 22);
            this.dtp_geboortedatum_gebruiker.TabIndex = 3;
            this.dtp_geboortedatum_gebruiker.Value = new System.DateTime(2015, 4, 17, 9, 46, 0, 0);
            // 
            // lb_geboortedatum_gebruiker
            // 
            this.lb_geboortedatum_gebruiker.AutoSize = true;
            this.lb_geboortedatum_gebruiker.Location = new System.Drawing.Point(8, 89);
            this.lb_geboortedatum_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_geboortedatum_gebruiker.Name = "lb_geboortedatum_gebruiker";
            this.lb_geboortedatum_gebruiker.Size = new System.Drawing.Size(111, 17);
            this.lb_geboortedatum_gebruiker.TabIndex = 2;
            this.lb_geboortedatum_gebruiker.Text = "Geboortedatum:";
            // 
            // lb_naam_gebruiker
            // 
            this.lb_naam_gebruiker.AutoSize = true;
            this.lb_naam_gebruiker.Location = new System.Drawing.Point(8, 58);
            this.lb_naam_gebruiker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_naam_gebruiker.Name = "lb_naam_gebruiker";
            this.lb_naam_gebruiker.Size = new System.Drawing.Size(77, 17);
            this.lb_naam_gebruiker.TabIndex = 1;
            this.lb_naam_gebruiker.Text = "Voornaam:";
            // 
            // tb_voornaam_gebruiker
            // 
            this.tb_voornaam_gebruiker.Location = new System.Drawing.Point(128, 55);
            this.tb_voornaam_gebruiker.Margin = new System.Windows.Forms.Padding(4);
            this.tb_voornaam_gebruiker.MaxLength = 255;
            this.tb_voornaam_gebruiker.Name = "tb_voornaam_gebruiker";
            this.tb_voornaam_gebruiker.Size = new System.Drawing.Size(132, 22);
            this.tb_voornaam_gebruiker.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 211);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Aantal personen:";
            // 
            // nudAantal
            // 
            this.nudAantal.Location = new System.Drawing.Point(151, 209);
            this.nudAantal.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudAantal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudAantal.Name = "nudAantal";
            this.nudAantal.Size = new System.Drawing.Size(265, 22);
            this.nudAantal.TabIndex = 14;
            this.nudAantal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Soort plaats:";
            // 
            // cbSoortPlaats
            // 
            this.cbSoortPlaats.FormattingEnabled = true;
            this.cbSoortPlaats.Location = new System.Drawing.Point(151, 146);
            this.cbSoortPlaats.Name = "cbSoortPlaats";
            this.cbSoortPlaats.Size = new System.Drawing.Size(265, 24);
            this.cbSoortPlaats.TabIndex = 16;
            this.cbSoortPlaats.SelectedIndexChanged += new System.EventHandler(this.cbSoortPlaats_SelectedIndexChanged);
            // 
            // gbVerhuur
            // 
            this.gbVerhuur.Controls.Add(this.label17);
            this.gbVerhuur.Controls.Add(this.label18);
            this.gbVerhuur.Controls.Add(this.label19);
            this.gbVerhuur.Controls.Add(this.label20);
            this.gbVerhuur.Controls.Add(this.label21);
            this.gbVerhuur.Controls.Add(this.label22);
            this.gbVerhuur.Controls.Add(this.lbGehuurd);
            this.gbVerhuur.Controls.Add(this.numericUpDown1);
            this.gbVerhuur.Controls.Add(this.label16);
            this.gbVerhuur.Controls.Add(this.btnConfirm);
            this.gbVerhuur.Controls.Add(this.label15);
            this.gbVerhuur.Controls.Add(this.label14);
            this.gbVerhuur.Controls.Add(this.label13);
            this.gbVerhuur.Controls.Add(this.label12);
            this.gbVerhuur.Controls.Add(this.label11);
            this.gbVerhuur.Controls.Add(this.label8);
            this.gbVerhuur.Controls.Add(this.lbProducten);
            this.gbVerhuur.Location = new System.Drawing.Point(774, 12);
            this.gbVerhuur.Name = "gbVerhuur";
            this.gbVerhuur.Size = new System.Drawing.Size(548, 670);
            this.gbVerhuur.TabIndex = 17;
            this.gbVerhuur.TabStop = false;
            this.gbVerhuur.Text = "Materiaalverhuur";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(433, 271);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 17);
            this.label17.TabIndex = 28;
            this.label17.Text = "Aantal gehuurd:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(364, 271);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 17);
            this.label18.TabIndex = 27;
            this.label18.Text = "Prijs:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(302, 271);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 17);
            this.label19.TabIndex = 26;
            this.label19.Text = "Borg:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(187, 271);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(73, 17);
            this.label20.TabIndex = 25;
            this.label20.Text = "Categorie:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(70, 271);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 24;
            this.label21.Text = "Product:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 247);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(144, 17);
            this.label22.TabIndex = 23;
            this.label22.Text = "Gehuurde producten:";
            // 
            // lbGehuurd
            // 
            this.lbGehuurd.FormattingEnabled = true;
            this.lbGehuurd.ItemHeight = 16;
            this.lbGehuurd.Location = new System.Drawing.Point(6, 298);
            this.lbGehuurd.Name = "lbGehuurd";
            this.lbGehuurd.Size = new System.Drawing.Size(536, 84);
            this.lbGehuurd.TabIndex = 22;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(98, 196);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 21;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 198);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(52, 17);
            this.label16.TabIndex = 20;
            this.label16.Text = "Aantal:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(367, 192);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(175, 28);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "Bevestig";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnBevestigHuur_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(409, 46);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 17);
            this.label15.TabIndex = 18;
            this.label15.Text = "Aantal beschikbaar:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(364, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Prijs:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(302, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 17);
            this.label13.TabIndex = 4;
            this.label13.Text = "Borg:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(187, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 17);
            this.label12.TabIndex = 3;
            this.label12.Text = "Categorie:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Product:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Beschikbare producten:";
            // 
            // lbProducten
            // 
            this.lbProducten.FormattingEnabled = true;
            this.lbProducten.ItemHeight = 16;
            this.lbProducten.Location = new System.Drawing.Point(6, 70);
            this.lbProducten.Name = "lbProducten";
            this.lbProducten.Size = new System.Drawing.Size(536, 116);
            this.lbProducten.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(265, 38);
            this.button1.TabIndex = 18;
            this.button1.Text = "Bevestig";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBevestigEvent_Click);
            // 
            // ReserveringSysteem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 698);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gbVerhuur);
            this.Controls.Add(this.cbSoortPlaats);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.nudAantal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gb_gebruikercreatie);
            this.Controls.Add(this.cbPlaces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpVertrek);
            this.Controls.Add(this.dtpAankomst);
            this.Controls.Add(this.cbEvents);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAankomst);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ReserveringSysteem";
            this.Text = "ReserveringSysteem";
            this.gb_gebruikercreatie.ResumeLayout(false);
            this.gb_gebruikercreatie.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAantal)).EndInit();
            this.gbVerhuur.ResumeLayout(false);
            this.gbVerhuur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAankomst;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbEvents;
        private System.Windows.Forms.DateTimePicker dtpAankomst;
        private System.Windows.Forms.DateTimePicker dtpVertrek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPlaces;
        private System.Windows.Forms.GroupBox gb_gebruikercreatie;
        private System.Windows.Forms.TextBox tb_achternaam_user;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_password_gebruiker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_loginname_gebruiker;
        private System.Windows.Forms.TextBox tb_username_gebruiker;
        private System.Windows.Forms.Label lb_Username_gebruiker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_telnr_gebruiker;
        private System.Windows.Forms.Label lb_addres_stad_gebruiker;
        private System.Windows.Forms.TextBox tb_stad_user;
        private System.Windows.Forms.TextBox tb_number_user;
        private System.Windows.Forms.Label lb_addres_nummer_gebruiker;
        private System.Windows.Forms.Label lb_addres_straat_gebruiker;
        private System.Windows.Forms.TextBox tb_straat_user;
        private System.Windows.Forms.ComboBox cb_land_gebruiker;
        private System.Windows.Forms.Label lb_land_gebruiker;
        private System.Windows.Forms.TextBox tb_email_gebruiker;
        private System.Windows.Forms.Label lb_email_gebruiker;
        private System.Windows.Forms.DateTimePicker dtp_geboortedatum_gebruiker;
        private System.Windows.Forms.Label lb_geboortedatum_gebruiker;
        private System.Windows.Forms.Label lb_naam_gebruiker;
        private System.Windows.Forms.TextBox tb_voornaam_gebruiker;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudAantal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbSoortPlaats;
        private System.Windows.Forms.GroupBox gbVerhuur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbProducten;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ListBox lbGehuurd;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}