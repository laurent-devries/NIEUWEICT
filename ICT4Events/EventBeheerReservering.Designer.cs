namespace ICT4Events
{
    partial class EventBeheerReservering
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
            this.btn_verwijder_gebruiker = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_changeuser = new System.Windows.Forms.Button();
            this.cB_Event_ID_User = new System.Windows.Forms.ComboBox();
            this.gb_gebruikercreatie = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cB_Reservation_ID_User = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_achternaam_user = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_password_gebruiker = new System.Windows.Forms.TextBox();
            this.btn_Confirm_user = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_loginname_gebruiker = new System.Windows.Forms.TextBox();
            this.tb_username_gebruiker = new System.Windows.Forms.TextBox();
            this.lb_Username_gebruiker = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.Listb_gebruikers = new System.Windows.Forms.ListBox();
            this.btn_nieuwe_gebruiker = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Event_End_Date = new System.Windows.Forms.DateTimePicker();
            this.Event_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.btn_create_event = new System.Windows.Forms.Button();
            this.Event_Camping_Location = new System.Windows.Forms.TextBox();
            this.Event_Camping_Name = new System.Windows.Forms.TextBox();
            this.Event_Title = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Listb_Events = new System.Windows.Forms.ListBox();
            this.gB_aanwezige_gebruikers = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lb_show_user_on_event = new System.Windows.Forms.ListBox();
            this.btn_show_users = new System.Windows.Forms.Button();
            this.cb_showusersonevent = new System.Windows.Forms.ComboBox();
            this.btn_printlistusers = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_gebruikercreatie.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gB_aanwezige_gebruikers.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_verwijder_gebruiker
            // 
            this.btn_verwijder_gebruiker.Location = new System.Drawing.Point(175, 19);
            this.btn_verwijder_gebruiker.Name = "btn_verwijder_gebruiker";
            this.btn_verwijder_gebruiker.Size = new System.Drawing.Size(75, 23);
            this.btn_verwijder_gebruiker.TabIndex = 0;
            this.btn_verwijder_gebruiker.Text = "Delete";
            this.btn_verwijder_gebruiker.UseVisualStyleBackColor = true;
            this.btn_verwijder_gebruiker.Click += new System.EventHandler(this.btn_verwijder_gebruiker_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btn_changeuser);
            this.groupBox1.Controls.Add(this.cB_Event_ID_User);
            this.groupBox1.Controls.Add(this.gb_gebruikercreatie);
            this.groupBox1.Controls.Add(this.Listb_gebruikers);
            this.groupBox1.Controls.Add(this.btn_verwijder_gebruiker);
            this.groupBox1.Controls.Add(this.btn_nieuwe_gebruiker);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 649);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Management";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(307, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "User_ID      ID_Event                 ID_Reservation               Name";
            // 
            // btn_changeuser
            // 
            this.btn_changeuser.Location = new System.Drawing.Point(94, 19);
            this.btn_changeuser.Name = "btn_changeuser";
            this.btn_changeuser.Size = new System.Drawing.Size(75, 23);
            this.btn_changeuser.TabIndex = 5;
            this.btn_changeuser.Text = "Change";
            this.btn_changeuser.UseVisualStyleBackColor = true;
            this.btn_changeuser.Click += new System.EventHandler(this.button1_Click);
            // 
            // cB_Event_ID_User
            // 
            this.cB_Event_ID_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cB_Event_ID_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cB_Event_ID_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Event_ID_User.Enabled = false;
            this.cB_Event_ID_User.FormattingEnabled = true;
            this.cB_Event_ID_User.Location = new System.Drawing.Point(102, 284);
            this.cB_Event_ID_User.Name = "cB_Event_ID_User";
            this.cB_Event_ID_User.Size = new System.Drawing.Size(141, 21);
            this.cB_Event_ID_User.TabIndex = 31;
            this.cB_Event_ID_User.SelectedIndexChanged += new System.EventHandler(this.cB_Event_ID_User_SelectedIndexChanged);
            this.cB_Event_ID_User.TextChanged += new System.EventHandler(this.cB_Event_ID_User_TextChanged);
            // 
            // gb_gebruikercreatie
            // 
            this.gb_gebruikercreatie.Controls.Add(this.btnCancel);
            this.gb_gebruikercreatie.Controls.Add(this.cB_Reservation_ID_User);
            this.gb_gebruikercreatie.Controls.Add(this.label12);
            this.gb_gebruikercreatie.Controls.Add(this.tb_achternaam_user);
            this.gb_gebruikercreatie.Controls.Add(this.label9);
            this.gb_gebruikercreatie.Controls.Add(this.tb_password_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.btn_Confirm_user);
            this.gb_gebruikercreatie.Controls.Add(this.label3);
            this.gb_gebruikercreatie.Controls.Add(this.label2);
            this.gb_gebruikercreatie.Controls.Add(this.tb_loginname_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.tb_username_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.lb_Username_gebruiker);
            this.gb_gebruikercreatie.Controls.Add(this.label1);
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
            this.gb_gebruikercreatie.Location = new System.Drawing.Point(6, 311);
            this.gb_gebruikercreatie.Name = "gb_gebruikercreatie";
            this.gb_gebruikercreatie.Size = new System.Drawing.Size(426, 332);
            this.gb_gebruikercreatie.TabIndex = 3;
            this.gb_gebruikercreatie.TabStop = false;
            this.gb_gebruikercreatie.Text = "User Create / Change";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(264, 298);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cB_Reservation_ID_User
            // 
            this.cB_Reservation_ID_User.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cB_Reservation_ID_User.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cB_Reservation_ID_User.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_Reservation_ID_User.FormattingEnabled = true;
            this.cB_Reservation_ID_User.Location = new System.Drawing.Point(96, 19);
            this.cB_Reservation_ID_User.Name = "cB_Reservation_ID_User";
            this.cB_Reservation_ID_User.Size = new System.Drawing.Size(324, 21);
            this.cB_Reservation_ID_User.Sorted = true;
            this.cB_Reservation_ID_User.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 13);
            this.label12.TabIndex = 30;
            this.label12.Text = "Reservation_ID";
            // 
            // tb_achternaam_user
            // 
            this.tb_achternaam_user.Location = new System.Drawing.Point(275, 44);
            this.tb_achternaam_user.Name = "tb_achternaam_user";
            this.tb_achternaam_user.Size = new System.Drawing.Size(145, 20);
            this.tb_achternaam_user.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Last Name:";
            // 
            // tb_password_gebruiker
            // 
            this.tb_password_gebruiker.Location = new System.Drawing.Point(95, 272);
            this.tb_password_gebruiker.MaxLength = 255;
            this.tb_password_gebruiker.Name = "tb_password_gebruiker";
            this.tb_password_gebruiker.ShortcutsEnabled = false;
            this.tb_password_gebruiker.Size = new System.Drawing.Size(325, 20);
            this.tb_password_gebruiker.TabIndex = 19;
            this.tb_password_gebruiker.UseSystemPasswordChar = true;
            // 
            // btn_Confirm_user
            // 
            this.btn_Confirm_user.Location = new System.Drawing.Point(345, 298);
            this.btn_Confirm_user.Name = "btn_Confirm_user";
            this.btn_Confirm_user.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm_user.TabIndex = 4;
            this.btn_Confirm_user.Text = "Confirm";
            this.btn_Confirm_user.UseVisualStyleBackColor = true;
            this.btn_Confirm_user.Click += new System.EventHandler(this.btn_create_gebruiker_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Loginname:";
            // 
            // tb_loginname_gebruiker
            // 
            this.tb_loginname_gebruiker.Location = new System.Drawing.Point(96, 220);
            this.tb_loginname_gebruiker.MaxLength = 17;
            this.tb_loginname_gebruiker.Name = "tb_loginname_gebruiker";
            this.tb_loginname_gebruiker.Size = new System.Drawing.Size(324, 20);
            this.tb_loginname_gebruiker.TabIndex = 17;
            // 
            // tb_username_gebruiker
            // 
            this.tb_username_gebruiker.Location = new System.Drawing.Point(95, 246);
            this.tb_username_gebruiker.MaxLength = 255;
            this.tb_username_gebruiker.Name = "tb_username_gebruiker";
            this.tb_username_gebruiker.Size = new System.Drawing.Size(325, 20);
            this.tb_username_gebruiker.TabIndex = 18;
            // 
            // lb_Username_gebruiker
            // 
            this.lb_Username_gebruiker.AutoSize = true;
            this.lb_Username_gebruiker.Location = new System.Drawing.Point(7, 249);
            this.lb_Username_gebruiker.Name = "lb_Username_gebruiker";
            this.lb_Username_gebruiker.Size = new System.Drawing.Size(58, 13);
            this.lb_Username_gebruiker.TabIndex = 18;
            this.lb_Username_gebruiker.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tel.Nr:";
            // 
            // tb_telnr_gebruiker
            // 
            this.tb_telnr_gebruiker.Location = new System.Drawing.Point(95, 194);
            this.tb_telnr_gebruiker.MaxLength = 20;
            this.tb_telnr_gebruiker.Name = "tb_telnr_gebruiker";
            this.tb_telnr_gebruiker.Size = new System.Drawing.Size(325, 20);
            this.tb_telnr_gebruiker.TabIndex = 16;
            // 
            // lb_addres_stad_gebruiker
            // 
            this.lb_addres_stad_gebruiker.AutoSize = true;
            this.lb_addres_stad_gebruiker.Location = new System.Drawing.Point(46, 171);
            this.lb_addres_stad_gebruiker.Name = "lb_addres_stad_gebruiker";
            this.lb_addres_stad_gebruiker.Size = new System.Drawing.Size(29, 13);
            this.lb_addres_stad_gebruiker.TabIndex = 13;
            this.lb_addres_stad_gebruiker.Text = "Stad";
            // 
            // tb_stad_user
            // 
            this.tb_stad_user.Location = new System.Drawing.Point(95, 168);
            this.tb_stad_user.MaxLength = 255;
            this.tb_stad_user.Name = "tb_stad_user";
            this.tb_stad_user.Size = new System.Drawing.Size(178, 20);
            this.tb_stad_user.TabIndex = 12;
            // 
            // tb_number_user
            // 
            this.tb_number_user.Location = new System.Drawing.Point(332, 146);
            this.tb_number_user.MaxLength = 10;
            this.tb_number_user.Name = "tb_number_user";
            this.tb_number_user.Size = new System.Drawing.Size(88, 20);
            this.tb_number_user.TabIndex = 11;
            // 
            // lb_addres_nummer_gebruiker
            // 
            this.lb_addres_nummer_gebruiker.AutoSize = true;
            this.lb_addres_nummer_gebruiker.Location = new System.Drawing.Point(281, 149);
            this.lb_addres_nummer_gebruiker.Name = "lb_addres_nummer_gebruiker";
            this.lb_addres_nummer_gebruiker.Size = new System.Drawing.Size(44, 13);
            this.lb_addres_nummer_gebruiker.TabIndex = 10;
            this.lb_addres_nummer_gebruiker.Text = "Number";
            // 
            // lb_addres_straat_gebruiker
            // 
            this.lb_addres_straat_gebruiker.AutoSize = true;
            this.lb_addres_straat_gebruiker.Location = new System.Drawing.Point(7, 145);
            this.lb_addres_straat_gebruiker.Name = "lb_addres_straat_gebruiker";
            this.lb_addres_straat_gebruiker.Size = new System.Drawing.Size(74, 13);
            this.lb_addres_straat_gebruiker.TabIndex = 9;
            this.lb_addres_straat_gebruiker.Text = "Addres: Street";
            // 
            // tb_straat_user
            // 
            this.tb_straat_user.Location = new System.Drawing.Point(96, 142);
            this.tb_straat_user.MaxLength = 255;
            this.tb_straat_user.Name = "tb_straat_user";
            this.tb_straat_user.Size = new System.Drawing.Size(179, 20);
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
            this.cb_land_gebruiker.Location = new System.Drawing.Point(96, 118);
            this.cb_land_gebruiker.Name = "cb_land_gebruiker";
            this.cb_land_gebruiker.Size = new System.Drawing.Size(324, 21);
            this.cb_land_gebruiker.Sorted = true;
            this.cb_land_gebruiker.TabIndex = 7;
            // 
            // lb_land_gebruiker
            // 
            this.lb_land_gebruiker.AutoSize = true;
            this.lb_land_gebruiker.Location = new System.Drawing.Point(7, 118);
            this.lb_land_gebruiker.Name = "lb_land_gebruiker";
            this.lb_land_gebruiker.Size = new System.Drawing.Size(46, 13);
            this.lb_land_gebruiker.TabIndex = 6;
            this.lb_land_gebruiker.Text = "Country:";
            // 
            // tb_email_gebruiker
            // 
            this.tb_email_gebruiker.Location = new System.Drawing.Point(96, 93);
            this.tb_email_gebruiker.MaxLength = 255;
            this.tb_email_gebruiker.Name = "tb_email_gebruiker";
            this.tb_email_gebruiker.Size = new System.Drawing.Size(324, 20);
            this.tb_email_gebruiker.TabIndex = 5;
            // 
            // lb_email_gebruiker
            // 
            this.lb_email_gebruiker.AutoSize = true;
            this.lb_email_gebruiker.Location = new System.Drawing.Point(7, 96);
            this.lb_email_gebruiker.Name = "lb_email_gebruiker";
            this.lb_email_gebruiker.Size = new System.Drawing.Size(39, 13);
            this.lb_email_gebruiker.TabIndex = 4;
            this.lb_email_gebruiker.Text = "E-Mail:";
            // 
            // dtp_geboortedatum_gebruiker
            // 
            this.dtp_geboortedatum_gebruiker.Location = new System.Drawing.Point(96, 68);
            this.dtp_geboortedatum_gebruiker.Name = "dtp_geboortedatum_gebruiker";
            this.dtp_geboortedatum_gebruiker.Size = new System.Drawing.Size(324, 20);
            this.dtp_geboortedatum_gebruiker.TabIndex = 3;
            this.dtp_geboortedatum_gebruiker.Value = new System.DateTime(2015, 4, 17, 9, 46, 0, 0);
            // 
            // lb_geboortedatum_gebruiker
            // 
            this.lb_geboortedatum_gebruiker.AutoSize = true;
            this.lb_geboortedatum_gebruiker.Location = new System.Drawing.Point(7, 74);
            this.lb_geboortedatum_gebruiker.Name = "lb_geboortedatum_gebruiker";
            this.lb_geboortedatum_gebruiker.Size = new System.Drawing.Size(52, 13);
            this.lb_geboortedatum_gebruiker.TabIndex = 2;
            this.lb_geboortedatum_gebruiker.Text = "Birthdate:";
            // 
            // lb_naam_gebruiker
            // 
            this.lb_naam_gebruiker.AutoSize = true;
            this.lb_naam_gebruiker.Location = new System.Drawing.Point(6, 47);
            this.lb_naam_gebruiker.Name = "lb_naam_gebruiker";
            this.lb_naam_gebruiker.Size = new System.Drawing.Size(60, 13);
            this.lb_naam_gebruiker.TabIndex = 1;
            this.lb_naam_gebruiker.Text = "First Name:";
            // 
            // tb_voornaam_gebruiker
            // 
            this.tb_voornaam_gebruiker.Location = new System.Drawing.Point(96, 45);
            this.tb_voornaam_gebruiker.MaxLength = 255;
            this.tb_voornaam_gebruiker.Name = "tb_voornaam_gebruiker";
            this.tb_voornaam_gebruiker.Size = new System.Drawing.Size(100, 20);
            this.tb_voornaam_gebruiker.TabIndex = 0;
            // 
            // Listb_gebruikers
            // 
            this.Listb_gebruikers.FormattingEnabled = true;
            this.Listb_gebruikers.Location = new System.Drawing.Point(9, 64);
            this.Listb_gebruikers.Name = "Listb_gebruikers";
            this.Listb_gebruikers.Size = new System.Drawing.Size(426, 199);
            this.Listb_gebruikers.TabIndex = 2;
            this.Listb_gebruikers.SelectedIndexChanged += new System.EventHandler(this.Listb_gebruikers_SelectedIndexChanged);
            // 
            // btn_nieuwe_gebruiker
            // 
            this.btn_nieuwe_gebruiker.Location = new System.Drawing.Point(6, 19);
            this.btn_nieuwe_gebruiker.Name = "btn_nieuwe_gebruiker";
            this.btn_nieuwe_gebruiker.Size = new System.Drawing.Size(75, 23);
            this.btn_nieuwe_gebruiker.TabIndex = 1;
            this.btn_nieuwe_gebruiker.Text = "New";
            this.btn_nieuwe_gebruiker.UseVisualStyleBackColor = true;
            this.btn_nieuwe_gebruiker.Click += new System.EventHandler(this.btn_nieuwe_gebruiker_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Event_ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.Listb_Events);
            this.groupBox2.Location = new System.Drawing.Point(463, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 649);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event Management";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Event_End_Date);
            this.groupBox3.Controls.Add(this.Event_Start_Date);
            this.groupBox3.Controls.Add(this.btn_create_event);
            this.groupBox3.Controls.Add(this.Event_Camping_Location);
            this.groupBox3.Controls.Add(this.Event_Camping_Name);
            this.groupBox3.Controls.Add(this.Event_Title);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 311);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 332);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Event Create / Change";
            // 
            // Event_End_Date
            // 
            this.Event_End_Date.Location = new System.Drawing.Point(103, 68);
            this.Event_End_Date.Name = "Event_End_Date";
            this.Event_End_Date.Size = new System.Drawing.Size(317, 20);
            this.Event_End_Date.TabIndex = 12;
            // 
            // Event_Start_Date
            // 
            this.Event_Start_Date.Location = new System.Drawing.Point(103, 43);
            this.Event_Start_Date.Name = "Event_Start_Date";
            this.Event_Start_Date.Size = new System.Drawing.Size(317, 20);
            this.Event_Start_Date.TabIndex = 11;
            // 
            // btn_create_event
            // 
            this.btn_create_event.Location = new System.Drawing.Point(314, 298);
            this.btn_create_event.Name = "btn_create_event";
            this.btn_create_event.Size = new System.Drawing.Size(112, 23);
            this.btn_create_event.TabIndex = 10;
            this.btn_create_event.Text = "Create / Change Event";
            this.btn_create_event.UseVisualStyleBackColor = true;
            this.btn_create_event.Click += new System.EventHandler(this.btn_create_event_Click_1);
            // 
            // Event_Camping_Location
            // 
            this.Event_Camping_Location.Location = new System.Drawing.Point(103, 120);
            this.Event_Camping_Location.Name = "Event_Camping_Location";
            this.Event_Camping_Location.Size = new System.Drawing.Size(317, 20);
            this.Event_Camping_Location.TabIndex = 9;
            // 
            // Event_Camping_Name
            // 
            this.Event_Camping_Name.Location = new System.Drawing.Point(103, 96);
            this.Event_Camping_Name.Name = "Event_Camping_Name";
            this.Event_Camping_Name.Size = new System.Drawing.Size(317, 20);
            this.Event_Camping_Name.TabIndex = 6;
            // 
            // Event_Title
            // 
            this.Event_Title.Location = new System.Drawing.Point(103, 23);
            this.Event_Title.Name = "Event_Title";
            this.Event_Title.Size = new System.Drawing.Size(317, 20);
            this.Event_Title.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Camping Location:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Camping Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Event StartDate:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Event EndDate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Event Title:";
            // 
            // Listb_Events
            // 
            this.Listb_Events.FormattingEnabled = true;
            this.Listb_Events.Location = new System.Drawing.Point(6, 64);
            this.Listb_Events.Name = "Listb_Events";
            this.Listb_Events.Size = new System.Drawing.Size(432, 199);
            this.Listb_Events.TabIndex = 6;
            // 
            // gB_aanwezige_gebruikers
            // 
            this.gB_aanwezige_gebruikers.Controls.Add(this.lb_show_user_on_event);
            this.gB_aanwezige_gebruikers.Controls.Add(this.groupBox5);
            this.gB_aanwezige_gebruikers.Location = new System.Drawing.Point(913, 12);
            this.gB_aanwezige_gebruikers.Name = "gB_aanwezige_gebruikers";
            this.gB_aanwezige_gebruikers.Size = new System.Drawing.Size(507, 649);
            this.gB_aanwezige_gebruikers.TabIndex = 3;
            this.gB_aanwezige_gebruikers.TabStop = false;
            this.gB_aanwezige_gebruikers.Text = "Show Users on Event";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btn_printlistusers);
            this.groupBox5.Controls.Add(this.cb_showusersonevent);
            this.groupBox5.Controls.Add(this.btn_show_users);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(6, 505);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(495, 138);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Show Users";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Event_ID:";
            // 
            // lb_show_user_on_event
            // 
            this.lb_show_user_on_event.FormattingEnabled = true;
            this.lb_show_user_on_event.Location = new System.Drawing.Point(15, 64);
            this.lb_show_user_on_event.Name = "lb_show_user_on_event";
            this.lb_show_user_on_event.Size = new System.Drawing.Size(480, 420);
            this.lb_show_user_on_event.TabIndex = 1;
            // 
            // btn_show_users
            // 
            this.btn_show_users.Location = new System.Drawing.Point(414, 104);
            this.btn_show_users.Name = "btn_show_users";
            this.btn_show_users.Size = new System.Drawing.Size(75, 23);
            this.btn_show_users.TabIndex = 2;
            this.btn_show_users.Text = "Show users";
            this.btn_show_users.UseVisualStyleBackColor = true;
            this.btn_show_users.Click += new System.EventHandler(this.btn_show_users_Click);
            // 
            // cb_showusersonevent
            // 
            this.cb_showusersonevent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cb_showusersonevent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cb_showusersonevent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_showusersonevent.FormattingEnabled = true;
            this.cb_showusersonevent.Location = new System.Drawing.Point(67, 23);
            this.cb_showusersonevent.Name = "cb_showusersonevent";
            this.cb_showusersonevent.Size = new System.Drawing.Size(422, 21);
            this.cb_showusersonevent.TabIndex = 3;
            // 
            // btn_printlistusers
            // 
            this.btn_printlistusers.Location = new System.Drawing.Point(320, 104);
            this.btn_printlistusers.Name = "btn_printlistusers";
            this.btn_printlistusers.Size = new System.Drawing.Size(75, 23);
            this.btn_printlistusers.TabIndex = 4;
            this.btn_printlistusers.Text = "PrintList";
            this.btn_printlistusers.UseVisualStyleBackColor = true;
            this.btn_printlistusers.Click += new System.EventHandler(this.btn_printlistusers_Click);
            // 
            // EventBeheerReservering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1432, 673);
            this.Controls.Add(this.gB_aanwezige_gebruikers);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EventBeheerReservering";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_gebruikercreatie.ResumeLayout(false);
            this.gb_gebruikercreatie.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gB_aanwezige_gebruikers.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_verwijder_gebruiker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gb_gebruikercreatie;
        private System.Windows.Forms.ComboBox cb_land_gebruiker;
        private System.Windows.Forms.Label lb_land_gebruiker;
        private System.Windows.Forms.TextBox tb_email_gebruiker;
        private System.Windows.Forms.Label lb_email_gebruiker;
        private System.Windows.Forms.DateTimePicker dtp_geboortedatum_gebruiker;
        private System.Windows.Forms.Label lb_geboortedatum_gebruiker;
        private System.Windows.Forms.Label lb_naam_gebruiker;
        private System.Windows.Forms.TextBox tb_voornaam_gebruiker;
        private System.Windows.Forms.ListBox Listb_gebruikers;
        private System.Windows.Forms.Button btn_nieuwe_gebruiker;
        private System.Windows.Forms.Label lb_addres_stad_gebruiker;
        private System.Windows.Forms.TextBox tb_stad_user;
        private System.Windows.Forms.TextBox tb_number_user;
        private System.Windows.Forms.Label lb_addres_nummer_gebruiker;
        private System.Windows.Forms.Label lb_addres_straat_gebruiker;
        private System.Windows.Forms.TextBox tb_straat_user;
        private System.Windows.Forms.TextBox tb_password_gebruiker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_loginname_gebruiker;
        private System.Windows.Forms.TextBox tb_username_gebruiker;
        private System.Windows.Forms.Label lb_Username_gebruiker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_telnr_gebruiker;
        private System.Windows.Forms.Button btn_Confirm_user;
        private System.Windows.Forms.Button btn_changeuser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox Listb_Events;
        private System.Windows.Forms.DateTimePicker Event_End_Date;
        private System.Windows.Forms.DateTimePicker Event_Start_Date;
        private System.Windows.Forms.Button btn_create_event;
        private System.Windows.Forms.TextBox Event_Camping_Location;
        private System.Windows.Forms.TextBox Event_Camping_Name;
        private System.Windows.Forms.TextBox Event_Title;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_achternaam_user;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cB_Reservation_ID_User;
        private System.Windows.Forms.ComboBox cB_Event_ID_User;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gB_aanwezige_gebruikers;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lb_show_user_on_event;
        private System.Windows.Forms.Button btn_show_users;
        private System.Windows.Forms.ComboBox cb_showusersonevent;
        private System.Windows.Forms.Button btn_printlistusers;
    }
}

