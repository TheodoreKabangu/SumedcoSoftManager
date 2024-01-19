namespace SUMEDCO
{
    partial class FormPatient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatient));
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnAffecter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.lblAge = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtAdresse = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPersonContact = new System.Windows.Forms.TextBox();
            this.txtTelContact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAnnee = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSexe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTypePatient = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMois = new System.Windows.Forms.TextBox();
            this.rbNouveau = new System.Windows.Forms.RadioButton();
            this.rbUrgence = new System.Windows.Forms.RadioButton();
            this.cboTypeFacture = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTaux = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboTypeAbonne = new System.Windows.Forms.ComboBox();
            this.cboEntreprise = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtNumService = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 558;
            // 
            // btnAffecter
            // 
            this.btnAffecter.BackColor = System.Drawing.Color.Transparent;
            this.btnAffecter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAffecter.Enabled = false;
            this.btnAffecter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAffecter.FlatAppearance.BorderSize = 0;
            this.btnAffecter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAffecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAffecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAffecter.Image = ((System.Drawing.Image)(resources.GetObject("btnAffecter.Image")));
            this.btnAffecter.Location = new System.Drawing.Point(220, 408);
            this.btnAffecter.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAffecter.Name = "btnAffecter";
            this.btnAffecter.Size = new System.Drawing.Size(30, 23);
            this.btnAffecter.TabIndex = 642;
            this.toolTip1.SetToolTip(this.btnAffecter, "Ajouter ce cas");
            this.btnAffecter.UseVisualStyleBackColor = false;
            this.btnAffecter.Click += new System.EventHandler(this.btnAffecter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuler.Image")));
            this.btnAnnuler.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAnnuler.Location = new System.Drawing.Point(95, 408);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 23);
            this.btnAnnuler.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnModifier.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnModifier.Enabled = false;
            this.btnModifier.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Image = ((System.Drawing.Image)(resources.GetObject("btnModifier.Image")));
            this.btnModifier.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModifier.Location = new System.Drawing.Point(179, 408);
            this.btnModifier.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(30, 23);
            this.btnModifier.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnModifier, "Modifier");
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrer.Image")));
            this.btnEnregistrer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEnregistrer.Location = new System.Drawing.Point(137, 408);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 23);
            this.btnEnregistrer.TabIndex = 13;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblAge.Location = new System.Drawing.Point(413, 225);
            this.lblAge.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(48, 20);
            this.lblAge.TabIndex = 632;
            this.lblAge.Text = "Age :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 189);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.TabIndex = 624;
            this.label1.Text = "Noms :";
            // 
            // txtNom
            // 
            this.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNom.Location = new System.Drawing.Point(95, 186);
            this.txtNom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNom.MaxLength = 75;
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(531, 24);
            this.txtNom.TabIndex = 4;
            this.txtNom.Enter += new System.EventHandler(this.txtNom_Enter);
            // 
            // txtAdresse
            // 
            this.txtAdresse.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtAdresse.Location = new System.Drawing.Point(307, 251);
            this.txtAdresse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAdresse.MaxLength = 75;
            this.txtAdresse.Name = "txtAdresse";
            this.txtAdresse.Size = new System.Drawing.Size(359, 24);
            this.txtAdresse.TabIndex = 8;
            this.txtAdresse.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtTel
            // 
            this.txtTel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTel.Location = new System.Drawing.Point(95, 251);
            this.txtTel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(141, 24);
            this.txtTel.TabIndex = 9;
            this.txtTel.TextChanged += new System.EventHandler(this.txtTel_TextChanged);
            this.txtTel.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtPersonContact
            // 
            this.txtPersonContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPersonContact.Location = new System.Drawing.Point(95, 281);
            this.txtPersonContact.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPersonContact.MaxLength = 75;
            this.txtPersonContact.Name = "txtPersonContact";
            this.txtPersonContact.Size = new System.Drawing.Size(288, 24);
            this.txtPersonContact.TabIndex = 11;
            this.txtPersonContact.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // txtTelContact
            // 
            this.txtTelContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelContact.Location = new System.Drawing.Point(415, 281);
            this.txtTelContact.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTelContact.MaxLength = 15;
            this.txtTelContact.Name = "txtTelContact";
            this.txtTelContact.Size = new System.Drawing.Size(143, 24);
            this.txtTelContact.TabIndex = 10;
            this.txtTelContact.TextChanged += new System.EventHandler(this.txtTelContact_TextChanged);
            this.txtTelContact.Enter += new System.EventHandler(this.txtTel_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 254);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 18);
            this.label5.TabIndex = 625;
            this.label5.Text = "Adresse :";
            // 
            // txtAnnee
            // 
            this.txtAnnee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAnnee.Location = new System.Drawing.Point(349, 222);
            this.txtAnnee.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAnnee.MaxLength = 4;
            this.txtAnnee.Name = "txtAnnee";
            this.txtAnnee.Size = new System.Drawing.Size(59, 24);
            this.txtAnnee.TabIndex = 7;
            this.txtAnnee.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            this.txtAnnee.Enter += new System.EventHandler(this.txtAge_Enter);
            this.txtAnnee.Leave += new System.EventHandler(this.txtAge_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 254);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 18);
            this.label7.TabIndex = 626;
            this.label7.Text = "Téléphone :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 284);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 627;
            this.label8.Text = "Pers. contact : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(385, 284);
            this.label9.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 18);
            this.label9.TabIndex = 628;
            this.label9.Text = "Tél. :";
            // 
            // cboSexe
            // 
            this.cboSexe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSexe.FormattingEnabled = true;
            this.cboSexe.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cboSexe.Location = new System.Drawing.Point(95, 221);
            this.cboSexe.Name = "cboSexe";
            this.cboSexe.Size = new System.Drawing.Size(141, 26);
            this.cboSexe.TabIndex = 5;
            this.cboSexe.SelectedIndexChanged += new System.EventHandler(this.cboSexe_SelectedIndexChanged);
            this.cboSexe.Enter += new System.EventHandler(this.cboSexe_Enter);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 225);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 18);
            this.label6.TabIndex = 630;
            this.label6.Text = "Sexe :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 225);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 631;
            this.label2.Text = "Né(e) en :";
            // 
            // cboTypePatient
            // 
            this.cboTypePatient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypePatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypePatient.FormattingEnabled = true;
            this.cboTypePatient.Location = new System.Drawing.Point(95, 61);
            this.cboTypePatient.Name = "cboTypePatient";
            this.cboTypePatient.Size = new System.Drawing.Size(313, 26);
            this.cboTypePatient.TabIndex = 1;
            this.cboTypePatient.DropDown += new System.EventHandler(this.cboTypePatient_DropDown);
            this.cboTypePatient.SelectedIndexChanged += new System.EventHandler(this.cboTypePatient_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 636;
            this.label3.Text = "Type :";
            // 
            // txtMois
            // 
            this.txtMois.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMois.Location = new System.Drawing.Point(307, 222);
            this.txtMois.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMois.MaxLength = 2;
            this.txtMois.Name = "txtMois";
            this.txtMois.Size = new System.Drawing.Size(40, 24);
            this.txtMois.TabIndex = 6;
            this.txtMois.TextChanged += new System.EventHandler(this.txtMois_TextChanged);
            this.txtMois.Enter += new System.EventHandler(this.txtMois_Enter);
            // 
            // rbNouveau
            // 
            this.rbNouveau.AutoSize = true;
            this.rbNouveau.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbNouveau.Location = new System.Drawing.Point(13, 27);
            this.rbNouveau.Name = "rbNouveau";
            this.rbNouveau.Size = new System.Drawing.Size(116, 22);
            this.rbNouveau.TabIndex = 649;
            this.rbNouveau.TabStop = true;
            this.rbNouveau.Text = "Nouveau cas";
            this.rbNouveau.UseVisualStyleBackColor = true;
            this.rbNouveau.Click += new System.EventHandler(this.rbNouveau_Click);
            // 
            // rbUrgence
            // 
            this.rbUrgence.AutoSize = true;
            this.rbUrgence.ForeColor = System.Drawing.Color.MediumBlue;
            this.rbUrgence.Location = new System.Drawing.Point(13, 55);
            this.rbUrgence.Name = "rbUrgence";
            this.rbUrgence.Size = new System.Drawing.Size(85, 22);
            this.rbUrgence.TabIndex = 649;
            this.rbUrgence.TabStop = true;
            this.rbUrgence.Text = "Urgence";
            this.rbUrgence.UseVisualStyleBackColor = true;
            this.rbUrgence.Click += new System.EventHandler(this.rbUrgence_Click);
            // 
            // cboTypeFacture
            // 
            this.cboTypeFacture.DropDownHeight = 50;
            this.cboTypeFacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeFacture.FormattingEnabled = true;
            this.cboTypeFacture.IntegralHeight = false;
            this.cboTypeFacture.Items.AddRange(new object[] {
            "immédiat",
            "différé"});
            this.cboTypeFacture.Location = new System.Drawing.Point(288, 21);
            this.cboTypeFacture.MaxDropDownItems = 10;
            this.cboTypeFacture.Name = "cboTypeFacture";
            this.cboTypeFacture.Size = new System.Drawing.Size(142, 26);
            this.cboTypeFacture.TabIndex = 650;
            // 
            // lblDate
            // 
            this.lblDate.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDate.Location = new System.Drawing.Point(290, 61);
            this.lblDate.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 15);
            this.lblDate.TabIndex = 651;
            this.lblDate.Text = "jj/mm/aaaa";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(202, 57);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 18);
            this.label11.TabIndex = 652;
            this.label11.Text = "Date :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(202, 24);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(97, 18);
            this.label12.TabIndex = 653;
            this.label12.Text = "Type facture :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTaux);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.rbUrgence);
            this.groupBox1.Controls.Add(this.cboTypeFacture);
            this.groupBox1.Controls.Add(this.rbNouveau);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Location = new System.Drawing.Point(95, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 87);
            this.groupBox1.TabIndex = 654;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultation";
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(375, 61);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(55, 15);
            this.lblTaux.TabIndex = 654;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTaux.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(566, 283);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 22);
            this.checkBox1.TabIndex = 655;
            this.checkBox1.Text = "ZS/HZS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboTypeAbonne);
            this.groupBox2.Controls.Add(this.cboEntreprise);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtNumService);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(95, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 90);
            this.groupBox2.TabIndex = 656;
            this.groupBox2.TabStop = false;
            // 
            // cboTypeAbonne
            // 
            this.cboTypeAbonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeAbonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTypeAbonne.FormattingEnabled = true;
            this.cboTypeAbonne.Location = new System.Drawing.Point(97, 50);
            this.cboTypeAbonne.Name = "cboTypeAbonne";
            this.cboTypeAbonne.Size = new System.Drawing.Size(203, 26);
            this.cboTypeAbonne.TabIndex = 542;
            this.cboTypeAbonne.SelectedIndexChanged += new System.EventHandler(this.cboTypeAbonne_SelectedIndexChanged);
            this.cboTypeAbonne.Enter += new System.EventHandler(this.cboTypeAbonne_Enter);
            // 
            // cboEntreprise
            // 
            this.cboEntreprise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEntreprise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboEntreprise.FormattingEnabled = true;
            this.cboEntreprise.Location = new System.Drawing.Point(97, 18);
            this.cboEntreprise.Name = "cboEntreprise";
            this.cboEntreprise.Size = new System.Drawing.Size(434, 26);
            this.cboEntreprise.TabIndex = 541;
            this.cboEntreprise.DropDown += new System.EventHandler(this.cboEntreprise_DropDown);
            this.cboEntreprise.SelectedIndexChanged += new System.EventHandler(this.cboEntreprise_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 53);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 18);
            this.label10.TabIndex = 545;
            this.label10.Text = "Type abonné :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 21);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 18);
            this.label13.TabIndex = 546;
            this.label13.Text = "Entreprise :";
            // 
            // txtNumService
            // 
            this.txtNumService.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumService.Location = new System.Drawing.Point(395, 50);
            this.txtNumService.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumService.MaxLength = 15;
            this.txtNumService.Name = "txtNumService";
            this.txtNumService.Size = new System.Drawing.Size(136, 24);
            this.txtNumService.TabIndex = 543;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(307, 53);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 18);
            this.label14.TabIndex = 544;
            this.label14.Text = "Matricule :";
            // 
            // FormPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMois);
            this.Controls.Add(this.cboTypePatient);
            this.Controls.Add(this.btnAffecter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.txtAdresse);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.txtPersonContact);
            this.Controls.Add(this.txtTelContact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAnnee);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cboSexe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPatient";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SSM - Patient";
            this.Shown += new System.EventHandler(this.FormPatient_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnAffecter;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtNom;
        public System.Windows.Forms.TextBox txtAdresse;
        public System.Windows.Forms.TextBox txtTel;
        public System.Windows.Forms.TextBox txtPersonContact;
        public System.Windows.Forms.TextBox txtTelContact;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtAnnee;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cboSexe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cboTypePatient;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnModifier;
        public System.Windows.Forms.TextBox txtMois;
        public System.Windows.Forms.RadioButton rbNouveau;
        public System.Windows.Forms.RadioButton rbUrgence;
        public System.Windows.Forms.ComboBox cboTypeFacture;
        public System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.ComboBox cboTypeAbonne;
        public System.Windows.Forms.ComboBox cboEntreprise;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtNumService;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.GroupBox groupBox1;

    }
}