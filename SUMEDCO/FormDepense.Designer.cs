namespace SUMEDCO
{
    partial class FormDepense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDepense));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDate = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBeneficiaire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.txtMontantLettre = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtCompte = new System.Windows.Forms.TextBox();
            this.txtNumRequisition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboCibleDepense = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCaisseDepense = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCaisseCDF = new System.Windows.Forms.Label();
            this.lblCaisseUSD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 559;
            // 
            // btnDate
            // 
            this.btnDate.BackColor = System.Drawing.Color.Transparent;
            this.btnDate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDate.BackgroundImage")));
            this.btnDate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDate.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDate.FlatAppearance.BorderSize = 0;
            this.btnDate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.Location = new System.Drawing.Point(205, 64);
            this.btnDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(30, 21);
            this.btnDate.TabIndex = 596;
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(333, 66);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(91, 15);
            this.lblTaux.TabIndex = 592;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(119, 66);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 593;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 594;
            this.label4.Text = "Taux du jour :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 595;
            this.label3.Text = "Date du jour :";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(672, 31);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 617;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtBeneficiaire
            // 
            this.txtBeneficiaire.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBeneficiaire.Location = new System.Drawing.Point(122, 181);
            this.txtBeneficiaire.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBeneficiaire.MaxLength = 75;
            this.txtBeneficiaire.Name = "txtBeneficiaire";
            this.txtBeneficiaire.Size = new System.Drawing.Size(504, 21);
            this.txtBeneficiaire.TabIndex = 3;
            this.txtBeneficiaire.Enter += new System.EventHandler(this.txtBeneficiaire_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 15);
            this.label1.TabIndex = 620;
            this.label1.Text = "Bénéficiaire :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 122);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 621;
            this.label5.Text = "Catégorie :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 213);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 620;
            this.label2.Text = "Montant :";
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(278, 210);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontant.MaxLength = 10;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(169, 21);
            this.txtMontant.TabIndex = 5;
            this.txtMontant.Enter += new System.EventHandler(this.txtMontant_Enter);
            this.txtMontant.Leave += new System.EventHandler(this.txtMontant_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 287);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 620;
            this.label6.Text = "Motif :";
            // 
            // txtMotif
            // 
            this.txtMotif.Location = new System.Drawing.Point(122, 284);
            this.txtMotif.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMotif.MaxLength = 100;
            this.txtMotif.Multiline = true;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Size = new System.Drawing.Size(504, 41);
            this.txtMotif.TabIndex = 7;
            this.txtMotif.Enter += new System.EventHandler(this.txtMotif_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 213);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 620;
            this.label7.Text = "Monnaie :";
            // 
            // cboMonnaie
            // 
            this.cboMonnaie.DropDownHeight = 150;
            this.cboMonnaie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonnaie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMonnaie.FormattingEnabled = true;
            this.cboMonnaie.IntegralHeight = false;
            this.cboMonnaie.Items.AddRange(new object[] {
            "CDF",
            "USD"});
            this.cboMonnaie.Location = new System.Drawing.Point(122, 210);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(77, 23);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 4;
            this.cboMonnaie.SelectedIndexChanged += new System.EventHandler(this.cboMonnaie_SelectedIndexChanged);
            this.cboMonnaie.Enter += new System.EventHandler(this.cboMonnaie_Enter);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(122, 366);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(80, 27);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(214, 366);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(80, 27);
            this.btnEnregistrer.TabIndex = 10;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // txtMontantLettre
            // 
            this.txtMontantLettre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtMontantLettre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMontantLettre.Enabled = false;
            this.txtMontantLettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontantLettre.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtMontantLettre.Location = new System.Drawing.Point(122, 241);
            this.txtMontantLettre.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontantLettre.MaxLength = 200;
            this.txtMontantLettre.Multiline = true;
            this.txtMontantLettre.Name = "txtMontantLettre";
            this.txtMontantLettre.Size = new System.Drawing.Size(504, 41);
            this.txtMontantLettre.TabIndex = 626;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.checkBox1.Location = new System.Drawing.Point(122, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(199, 19);
            this.checkBox1.TabIndex = 627;
            this.checkBox1.Text = "Lier cette dépense à un abonné";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
            // 
            // txtCompte
            // 
            this.txtCompte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtCompte.Location = new System.Drawing.Point(122, 150);
            this.txtCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte.MaxLength = 75;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.ReadOnly = true;
            this.txtCompte.Size = new System.Drawing.Size(504, 21);
            this.txtCompte.TabIndex = 2;
            // 
            // txtNumRequisition
            // 
            this.txtNumRequisition.Location = new System.Drawing.Point(122, 335);
            this.txtNumRequisition.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumRequisition.MaxLength = 75;
            this.txtNumRequisition.Name = "txtNumRequisition";
            this.txtNumRequisition.Size = new System.Drawing.Size(504, 21);
            this.txtNumRequisition.TabIndex = 8;
            this.txtNumRequisition.Enter += new System.EventHandler(this.txtNumRequisition_Enter);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 338);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 15);
            this.label8.TabIndex = 671;
            this.label8.Text = "Réf. réquisition :";
            // 
            // cboCibleDepense
            // 
            this.cboCibleDepense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCibleDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCibleDepense.FormattingEnabled = true;
            this.cboCibleDepense.Location = new System.Drawing.Point(122, 119);
            this.cboCibleDepense.Name = "cboCibleDepense";
            this.cboCibleDepense.Size = new System.Drawing.Size(504, 23);
            this.cboCibleDepense.Sorted = true;
            this.cboCibleDepense.TabIndex = 1;
            this.cboCibleDepense.DropDown += new System.EventHandler(this.cboCibleDepense_DropDown);
            this.cboCibleDepense.SelectedIndexChanged += new System.EventHandler(this.cboCibleDepense_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 153);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 621;
            this.label9.Text = "Compte cible";
            // 
            // cboCaisseDepense
            // 
            this.cboCaisseDepense.DropDownHeight = 150;
            this.cboCaisseDepense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaisseDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCaisseDepense.FormattingEnabled = true;
            this.cboCaisseDepense.IntegralHeight = false;
            this.cboCaisseDepense.Items.AddRange(new object[] {
            "CDF",
            "USD"});
            this.cboCaisseDepense.Location = new System.Drawing.Point(549, 208);
            this.cboCaisseDepense.MaxDropDownItems = 10;
            this.cboCaisseDepense.Name = "cboCaisseDepense";
            this.cboCaisseDepense.Size = new System.Drawing.Size(77, 23);
            this.cboCaisseDepense.Sorted = true;
            this.cboCaisseDepense.TabIndex = 6;
            this.cboCaisseDepense.SelectedIndexChanged += new System.EventHandler(this.cboCaisseDepense_SelectedIndexChanged);
            this.cboCaisseDepense.Enter += new System.EventHandler(this.cboCaisseDepense_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(459, 211);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 673;
            this.label10.Text = "Décaissé en :";
            // 
            // lblCaisseCDF
            // 
            this.lblCaisseCDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseCDF.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseCDF.Location = new System.Drawing.Point(285, 39);
            this.lblCaisseCDF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseCDF.Name = "lblCaisseCDF";
            this.lblCaisseCDF.Size = new System.Drawing.Size(244, 15);
            this.lblCaisseCDF.TabIndex = 677;
            this.lblCaisseCDF.Text = "0000";
            this.lblCaisseCDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaisseUSD
            // 
            this.lblCaisseUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseUSD.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseUSD.Location = new System.Drawing.Point(15, 39);
            this.lblCaisseUSD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseUSD.Name = "lblCaisseUSD";
            this.lblCaisseUSD.Size = new System.Drawing.Size(222, 15);
            this.lblCaisseUSD.TabIndex = 678;
            this.lblCaisseUSD.Text = "0000";
            this.lblCaisseUSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDepense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.lblCaisseCDF);
            this.Controls.Add(this.lblCaisseUSD);
            this.Controls.Add(this.cboCaisseDepense);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboCibleDepense);
            this.Controls.Add(this.txtNumRequisition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtMontantLettre);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.cboMonnaie);
            this.Controls.Add(this.txtMotif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBeneficiaire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.lblTaux);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDepense";
            this.Text = "FormDepense";
            this.Shown += new System.EventHandler(this.FormDepense_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnDate;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.TextBox txtBeneficiaire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cboMonnaie;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.TextBox txtMontantLettre;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtCompte;
        public System.Windows.Forms.TextBox txtNumRequisition;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cboCibleDepense;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cboCaisseDepense;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblCaisseCDF;
        public System.Windows.Forms.Label lblCaisseUSD;
    }
}