namespace SUMEDCO
{
    partial class FormTresoSortie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTresoSortie));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDate = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtBeneficiaire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMotif = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMonnaie = new System.Windows.Forms.ComboBox();
            this.txtMontantLettre = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCompte = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnRetirerTout = new System.Windows.Forms.Button();
            this.txtCompte = new System.Windows.Forms.TextBox();
            this.txtNumRequisition = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboCaisseDepense = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCaisseCDF = new System.Windows.Forms.Label();
            this.lblCaisseUSD = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvEcriture = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcriture)).BeginInit();
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
            this.btnDate.Location = new System.Drawing.Point(205, 81);
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
            this.lblTaux.Location = new System.Drawing.Point(333, 83);
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
            this.lblDateOperation.Location = new System.Drawing.Point(119, 83);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(77, 15);
            this.lblDateOperation.TabIndex = 593;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 83);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 22);
            this.label4.TabIndex = 594;
            this.label4.Text = "Taux du jour :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 22);
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
            this.txtBeneficiaire.Location = new System.Drawing.Point(122, 138);
            this.txtBeneficiaire.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtBeneficiaire.MaxLength = 75;
            this.txtBeneficiaire.Name = "txtBeneficiaire";
            this.txtBeneficiaire.Size = new System.Drawing.Size(319, 28);
            this.txtBeneficiaire.TabIndex = 3;
            this.txtBeneficiaire.Enter += new System.EventHandler(this.txtBeneficiaire_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 22);
            this.label1.TabIndex = 620;
            this.label1.Text = "Bénéficiaire :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 171);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 22);
            this.label2.TabIndex = 620;
            this.label2.Text = "Montant :";
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(122, 169);
            this.txtMontant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontant.MaxLength = 10;
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(148, 28);
            this.txtMontant.TabIndex = 4;
            this.txtMontant.Enter += new System.EventHandler(this.txtMontant_Enter);
            this.txtMontant.Leave += new System.EventHandler(this.txtMontant_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 110);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 22);
            this.label6.TabIndex = 620;
            this.label6.Text = "Montant global en lettres :";
            // 
            // txtMotif
            // 
            this.txtMotif.Location = new System.Drawing.Point(122, 230);
            this.txtMotif.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMotif.MaxLength = 25;
            this.txtMotif.Name = "txtMotif";
            this.txtMotif.Size = new System.Drawing.Size(289, 28);
            this.txtMotif.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 171);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 22);
            this.label7.TabIndex = 620;
            this.label7.Text = "CDF/USD :";
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
            this.cboMonnaie.Location = new System.Drawing.Point(372, 166);
            this.cboMonnaie.MaxDropDownItems = 10;
            this.cboMonnaie.Name = "cboMonnaie";
            this.cboMonnaie.Size = new System.Drawing.Size(69, 30);
            this.cboMonnaie.Sorted = true;
            this.cboMonnaie.TabIndex = 4;
            this.cboMonnaie.SelectedIndexChanged += new System.EventHandler(this.cboMonnaie_SelectedIndexChanged);
            this.cboMonnaie.Enter += new System.EventHandler(this.cboMonnaie_Enter);
            // 
            // txtMontantLettre
            // 
            this.txtMontantLettre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtMontantLettre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMontantLettre.Enabled = false;
            this.txtMontantLettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontantLettre.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtMontantLettre.Location = new System.Drawing.Point(453, 130);
            this.txtMontantLettre.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtMontantLettre.MaxLength = 200;
            this.txtMontantLettre.Multiline = true;
            this.txtMontantLettre.Name = "txtMontantLettre";
            this.txtMontantLettre.Size = new System.Drawing.Size(238, 121);
            this.txtMontantLettre.TabIndex = 626;
            // 
            // btnCompte
            // 
            this.btnCompte.BackColor = System.Drawing.Color.Transparent;
            this.btnCompte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCompte.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCompte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCompte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompte.Image = ((System.Drawing.Image)(resources.GetObject("btnCompte.Image")));
            this.btnCompte.Location = new System.Drawing.Point(240, 199);
            this.btnCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCompte.Name = "btnCompte";
            this.btnCompte.Size = new System.Drawing.Size(30, 21);
            this.btnCompte.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnCompte, "Ajouter le compte");
            this.btnCompte.UseVisualStyleBackColor = false;
            this.btnCompte.Click += new System.EventHandler(this.btnCompte_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.Transparent;
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Image = ((System.Drawing.Image)(resources.GetObject("btnValider.Image")));
            this.btnValider.Location = new System.Drawing.Point(411, 230);
            this.btnValider.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(30, 21);
            this.btnValider.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnValider, "Valider");
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnuler.Image")));
            this.btnAnnuler.Location = new System.Drawing.Point(122, 260);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(30, 30);
            this.btnAnnuler.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btnAnnuler, "Annuler");
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click_1);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.BackColor = System.Drawing.Color.Transparent;
            this.btnEnregistrer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnregistrer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Image = ((System.Drawing.Image)(resources.GetObject("btnEnregistrer.Image")));
            this.btnEnregistrer.Location = new System.Drawing.Point(164, 260);
            this.btnEnregistrer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(30, 30);
            this.btnEnregistrer.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnEnregistrer, "Enregistrer");
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnRetirer
            // 
            this.btnRetirer.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetirer.Enabled = false;
            this.btnRetirer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRetirer.FlatAppearance.BorderSize = 0;
            this.btnRetirer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetirer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirer.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirer.Image")));
            this.btnRetirer.Location = new System.Drawing.Point(205, 261);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 30);
            this.btnRetirer.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btnRetirer, "Retirer");
            this.btnRetirer.UseVisualStyleBackColor = false;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnRetirerTout
            // 
            this.btnRetirerTout.BackColor = System.Drawing.Color.Transparent;
            this.btnRetirerTout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRetirerTout.Enabled = false;
            this.btnRetirerTout.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRetirerTout.FlatAppearance.BorderSize = 0;
            this.btnRetirerTout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRetirerTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetirerTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirerTout.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirerTout.Image")));
            this.btnRetirerTout.Location = new System.Drawing.Point(245, 261);
            this.btnRetirerTout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirerTout.Name = "btnRetirerTout";
            this.btnRetirerTout.Size = new System.Drawing.Size(30, 30);
            this.btnRetirerTout.TabIndex = 12;
            this.toolTip1.SetToolTip(this.btnRetirerTout, "Retirer tout");
            this.btnRetirerTout.UseVisualStyleBackColor = false;
            this.btnRetirerTout.Click += new System.EventHandler(this.btnRetirerTout_Click);
            // 
            // txtCompte
            // 
            this.txtCompte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtCompte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompte.Enabled = false;
            this.txtCompte.Location = new System.Drawing.Point(122, 199);
            this.txtCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte.MaxLength = 75;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.Size = new System.Drawing.Size(118, 28);
            this.txtCompte.TabIndex = 11;
            // 
            // txtNumRequisition
            // 
            this.txtNumRequisition.Location = new System.Drawing.Point(122, 107);
            this.txtNumRequisition.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtNumRequisition.MaxLength = 75;
            this.txtNumRequisition.Name = "txtNumRequisition";
            this.txtNumRequisition.Size = new System.Drawing.Size(148, 28);
            this.txtNumRequisition.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 22);
            this.label8.TabIndex = 671;
            this.label8.Text = "Réf. réquisition :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 201);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 22);
            this.label9.TabIndex = 621;
            this.label9.Text = "Compte dépense :";
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
            this.cboCaisseDepense.Location = new System.Drawing.Point(372, 107);
            this.cboCaisseDepense.MaxDropDownItems = 10;
            this.cboCaisseDepense.Name = "cboCaisseDepense";
            this.cboCaisseDepense.Size = new System.Drawing.Size(69, 30);
            this.cboCaisseDepense.Sorted = true;
            this.cboCaisseDepense.TabIndex = 2;
            this.cboCaisseDepense.SelectedIndexChanged += new System.EventHandler(this.cboCaisseDepense_SelectedIndexChanged);
            this.cboCaisseDepense.Enter += new System.EventHandler(this.cboCaisseDepense_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 110);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(119, 22);
            this.label10.TabIndex = 673;
            this.label10.Text = "Décaissé en :";
            // 
            // lblCaisseCDF
            // 
            this.lblCaisseCDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseCDF.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseCDF.Location = new System.Drawing.Point(385, 62);
            this.lblCaisseCDF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseCDF.Name = "lblCaisseCDF";
            this.lblCaisseCDF.Size = new System.Drawing.Size(175, 15);
            this.lblCaisseCDF.TabIndex = 677;
            this.lblCaisseCDF.Text = "0000";
            this.lblCaisseCDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaisseUSD
            // 
            this.lblCaisseUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseUSD.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseUSD.Location = new System.Drawing.Point(119, 62);
            this.lblCaisseUSD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseUSD.Name = "lblCaisseUSD";
            this.lblCaisseUSD.Size = new System.Drawing.Size(151, 15);
            this.lblCaisseUSD.TabIndex = 678;
            this.lblCaisseUSD.Text = "0000";
            this.lblCaisseUSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 234);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 22);
            this.label11.TabIndex = 679;
            this.label11.Text = "Motif dépense :";
            // 
            // dgvEcriture
            // 
            this.dgvEcriture.AllowUserToAddRows = false;
            this.dgvEcriture.AllowUserToDeleteRows = false;
            this.dgvEcriture.AllowUserToOrderColumns = true;
            this.dgvEcriture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEcriture.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvEcriture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEcriture.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEcriture.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEcriture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEcriture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.dataGridViewTextBoxColumn10,
            this.Column3});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEcriture.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEcriture.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvEcriture.Location = new System.Drawing.Point(122, 298);
            this.dgvEcriture.MultiSelect = false;
            this.dgvEcriture.Name = "dgvEcriture";
            this.dgvEcriture.ReadOnly = true;
            this.dgvEcriture.RowHeadersVisible = false;
            this.dgvEcriture.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvEcriture.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEcriture.Size = new System.Drawing.Size(569, 141);
            this.dgvEcriture.TabIndex = 710;
            this.dgvEcriture.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEcriture_CellClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Compte";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Libellé";
            this.Column1.MaxInputLength = 250;
            this.Column1.MinimumWidth = 200;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn10.HeaderText = "Débit";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column3.HeaderText = "Crédit";
            this.Column3.MinimumWidth = 100;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.MediumBlue;
            this.label12.Location = new System.Drawing.Point(15, 62);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 711;
            this.label12.Text = "Caisse USD :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.MediumBlue;
            this.label13.Location = new System.Drawing.Point(282, 62);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 15);
            this.label13.TabIndex = 711;
            this.label13.Text = "Caisse CDF :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormDepense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnRetirerTout);
            this.Controls.Add(this.btnCompte);
            this.Controls.Add(this.dgvEcriture);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblCaisseCDF);
            this.Controls.Add(this.lblCaisseUSD);
            this.Controls.Add(this.cboCaisseDepense);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNumRequisition);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.txtMontantLettre);
            this.Controls.Add(this.cboMonnaie);
            this.Controls.Add(this.txtMotif);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBeneficiaire);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvEcriture)).EndInit();
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
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtMotif;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.ComboBox cboMonnaie;
        public System.Windows.Forms.TextBox txtMontantLettre;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.TextBox txtCompte;
        public System.Windows.Forms.TextBox txtNumRequisition;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cboCaisseDepense;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblCaisseCDF;
        public System.Windows.Forms.Label lblCaisseUSD;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.DataGridView dgvEcriture;
        public System.Windows.Forms.Button btnCompte;
        public System.Windows.Forms.Button btnValider;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.Button btnEnregistrer;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnRetirerTout;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}