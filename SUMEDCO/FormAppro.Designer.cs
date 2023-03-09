namespace SUMEDCO
{
    partial class FormAppro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAppro));
            this.txtQteAppro = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpDateJour = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQteAjout = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrixAchat = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPrixVente = new System.Windows.Forms.TextBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtTaux = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQteDem = new System.Windows.Forms.TextBox();
            this.txtLibelle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAnnee = new System.Windows.Forms.NumericUpDown();
            this.cboMois = new System.Windows.Forms.ComboBox();
            this.txtNumLot = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtPrixStock = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnnee)).BeginInit();
            this.SuspendLayout();
            // 
            // txtQteAppro
            // 
            this.txtQteAppro.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteAppro.Location = new System.Drawing.Point(146, 326);
            this.txtQteAppro.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteAppro.MaxLength = 10;
            this.txtQteAppro.Name = "txtQteAppro";
            this.txtQteAppro.Size = new System.Drawing.Size(170, 28);
            this.txtQteAppro.TabIndex = 5;
            this.txtQteAppro.TextChanged += new System.EventHandler(this.txtQteAppro_TextChanged);
            this.txtQteAppro.Leave += new System.EventHandler(this.txtQteAppro_Leave);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnEnregistrer.Location = new System.Drawing.Point(236, 387);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 26);
            this.btnEnregistrer.TabIndex = 9;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnAnnuler.Location = new System.Drawing.Point(146, 387);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 26);
            this.btnAnnuler.TabIndex = 8;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 329);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 22);
            this.label7.TabIndex = 686;
            this.label7.Text = "Quantité appro :";
            // 
            // dtpDateJour
            // 
            this.dtpDateJour.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateJour.Location = new System.Drawing.Point(146, 77);
            this.dtpDateJour.Name = "dtpDateJour";
            this.dtpDateJour.Size = new System.Drawing.Size(170, 28);
            this.dtpDateJour.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 360);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 685;
            this.label2.Text = "Quantité ajoutée :";
            // 
            // txtQteAjout
            // 
            this.txtQteAjout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtQteAjout.Location = new System.Drawing.Point(146, 357);
            this.txtQteAjout.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteAjout.MaxLength = 10;
            this.txtQteAjout.Name = "txtQteAjout";
            this.txtQteAjout.Size = new System.Drawing.Size(170, 28);
            this.txtQteAjout.TabIndex = 6;
            this.txtQteAjout.TextChanged += new System.EventHandler(this.txtQteAjout_TextChanged);
            this.txtQteAjout.Enter += new System.EventHandler(this.txtQteAjout_Enter);
            this.txtQteAjout.Leave += new System.EventHandler(this.txtQteAjout_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 22);
            this.label3.TabIndex = 684;
            this.label3.Text = "Date du jour :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 22);
            this.label6.TabIndex = 686;
            this.label6.Text = "Prix d\'achat U. :";
            // 
            // txtPrixAchat
            // 
            this.txtPrixAchat.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPrixAchat.Location = new System.Drawing.Point(146, 137);
            this.txtPrixAchat.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPrixAchat.MaxLength = 10;
            this.txtPrixAchat.Name = "txtPrixAchat";
            this.txtPrixAchat.Size = new System.Drawing.Size(139, 28);
            this.txtPrixAchat.TabIndex = 3;
            this.txtPrixAchat.TextChanged += new System.EventHandler(this.txtPrixAchat_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.MediumBlue;
            this.label11.Location = new System.Drawing.Point(323, 140);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 22);
            this.label11.TabIndex = 686;
            this.label11.Text = "Prix vente :";
            // 
            // txtPrixVente
            // 
            this.txtPrixVente.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPrixVente.Location = new System.Drawing.Point(403, 137);
            this.txtPrixVente.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPrixVente.MaxLength = 10;
            this.txtPrixVente.Name = "txtPrixVente";
            this.txtPrixVente.ReadOnly = true;
            this.txtPrixVente.Size = new System.Drawing.Size(139, 28);
            this.txtPrixVente.TabIndex = 10;
            this.txtPrixVente.Text = "0";
            this.txtPrixVente.TextChanged += new System.EventHandler(this.txtPrixVente_TextChanged);
            this.txtPrixVente.DoubleClick += new System.EventHandler(this.txtPrixVente_DoubleClick);
            this.txtPrixVente.Leave += new System.EventHandler(this.txtPrixVente_Leave);
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblPrix.Location = new System.Drawing.Point(323, 109);
            this.lblPrix.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.Size = new System.Drawing.Size(103, 22);
            this.lblPrix.TabIndex = 691;
            this.lblPrix.Text = "Prix stock : ";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(285, 107);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(31, 28);
            this.textBox2.TabIndex = 695;
            this.textBox2.Text = "%";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTaux
            // 
            this.txtTaux.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtTaux.Location = new System.Drawing.Point(146, 107);
            this.txtTaux.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTaux.MaxLength = 3;
            this.txtTaux.Name = "txtTaux";
            this.txtTaux.Size = new System.Drawing.Size(139, 28);
            this.txtTaux.TabIndex = 2;
            this.txtTaux.Text = "20";
            this.txtTaux.TextChanged += new System.EventHandler(this.txtTaux_TextChanged);
            this.txtTaux.Leave += new System.EventHandler(this.txtTaux_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 109);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 22);
            this.label12.TabIndex = 697;
            this.label12.Text = "Taux bénéfice :";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(285, 137);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(31, 28);
            this.textBox3.TabIndex = 698;
            this.textBox3.Text = "CDF";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(542, 137);
            this.textBox4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(31, 28);
            this.textBox4.TabIndex = 699;
            this.textBox4.Text = "CDF";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(579, 27);
            this.panel1.TabIndex = 702;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 298);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 22);
            this.label1.TabIndex = 686;
            this.label1.Text = "Quantité demandée :";
            // 
            // txtQteDem
            // 
            this.txtQteDem.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtQteDem.Enabled = false;
            this.txtQteDem.Location = new System.Drawing.Point(146, 295);
            this.txtQteDem.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtQteDem.MaxLength = 10;
            this.txtQteDem.Name = "txtQteDem";
            this.txtQteDem.Size = new System.Drawing.Size(170, 28);
            this.txtQteDem.TabIndex = 4;
            // 
            // txtLibelle
            // 
            this.txtLibelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtLibelle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLibelle.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtLibelle.Enabled = false;
            this.txtLibelle.Location = new System.Drawing.Point(146, 48);
            this.txtLibelle.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtLibelle.MaxLength = 200;
            this.txtLibelle.Name = "txtLibelle";
            this.txtLibelle.Size = new System.Drawing.Size(427, 28);
            this.txtLibelle.TabIndex = 703;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 22);
            this.label4.TabIndex = 704;
            this.label4.Text = "Libellé produit :";
            // 
            // nudAnnee
            // 
            this.nudAnnee.Enabled = false;
            this.nudAnnee.Location = new System.Drawing.Point(146, 256);
            this.nudAnnee.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAnnee.Minimum = new decimal(new int[] {
            1999,
            0,
            0,
            0});
            this.nudAnnee.Name = "nudAnnee";
            this.nudAnnee.Size = new System.Drawing.Size(170, 28);
            this.nudAnnee.TabIndex = 710;
            this.nudAnnee.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            // 
            // cboMois
            // 
            this.cboMois.DropDownHeight = 150;
            this.cboMois.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMois.Enabled = false;
            this.cboMois.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMois.FormattingEnabled = true;
            this.cboMois.IntegralHeight = false;
            this.cboMois.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboMois.Location = new System.Drawing.Point(146, 226);
            this.cboMois.MaxDropDownItems = 10;
            this.cboMois.Name = "cboMois";
            this.cboMois.Size = new System.Drawing.Size(170, 30);
            this.cboMois.Sorted = true;
            this.cboMois.TabIndex = 709;
            // 
            // txtNumLot
            // 
            this.txtNumLot.Enabled = false;
            this.txtNumLot.Location = new System.Drawing.Point(146, 195);
            this.txtNumLot.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumLot.MaxLength = 20;
            this.txtNumLot.Name = "txtNumLot";
            this.txtNumLot.Size = new System.Drawing.Size(170, 28);
            this.txtNumLot.TabIndex = 705;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(14, 198);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 22);
            this.label5.TabIndex = 706;
            this.label5.Text = "Numéro de lot :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(14, 260);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 22);
            this.label8.TabIndex = 707;
            this.label8.Text = "Année expiration :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblDateEntree.Location = new System.Drawing.Point(14, 229);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(140, 22);
            this.lblDateEntree.TabIndex = 708;
            this.lblDateEntree.Text = "Mois expiration :";
            // 
            // txtObs
            // 
            this.txtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObs.Location = new System.Drawing.Point(328, 295);
            this.txtObs.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtObs.MaxLength = 100;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(245, 83);
            this.txtObs.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(325, 268);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 22);
            this.label9.TabIndex = 686;
            this.label9.Text = "Observation :";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(542, 106);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(31, 28);
            this.textBox1.TabIndex = 712;
            this.textBox1.Text = "CDF";
            // 
            // txtPrixStock
            // 
            this.txtPrixStock.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPrixStock.Enabled = false;
            this.txtPrixStock.Location = new System.Drawing.Point(403, 106);
            this.txtPrixStock.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPrixStock.MaxLength = 10;
            this.txtPrixStock.Name = "txtPrixStock";
            this.txtPrixStock.Size = new System.Drawing.Size(139, 28);
            this.txtPrixStock.TabIndex = 711;
            this.txtPrixStock.Text = "0";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(146, 166);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(171, 26);
            this.checkBox1.TabIndex = 713;
            this.checkBox1.Text = "Produit expirable";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // FormAppro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(579, 409);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtPrixStock);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.nudAnnee);
            this.Controls.Add(this.cboMois);
            this.Controls.Add(this.txtNumLot);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.txtLibelle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.txtTaux);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPrixVente);
            this.Controls.Add(this.txtPrixAchat);
            this.Controls.Add(this.txtQteDem);
            this.Controls.Add(this.txtQteAppro);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDateJour);
            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.txtQteAjout);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(601, 465);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(601, 465);
            this.Name = "FormAppro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Approvisionner par achat";
            this.Shown += new System.EventHandler(this.FormApproPharma_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.nudAnnee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtQteAppro;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DateTimePicker dtpDateJour;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtQteAjout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtPrixAchat;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtPrixVente;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox txtTaux;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtQteDem;
        public System.Windows.Forms.TextBox txtLibelle;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.NumericUpDown nudAnnee;
        public System.Windows.Forms.ComboBox cboMois;
        public System.Windows.Forms.TextBox txtNumLot;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox txtPrixStock;
        private System.Windows.Forms.Label lblPrix;
        public System.Windows.Forms.CheckBox checkBox1;
    }
}