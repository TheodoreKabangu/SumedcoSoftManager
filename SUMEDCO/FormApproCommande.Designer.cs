namespace SUMEDCO
{
    partial class FormApproCommande
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApproCommande));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.dgvCommande = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnServir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImprimer = new System.Windows.Forms.Button();
            this.btnRecherche2 = new System.Windows.Forms.Button();
            this.btnNouveauProduit = new System.Windows.Forms.Button();
            this.btnMiseAjour = new System.Windows.Forms.Button();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.dgvAppro = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDepot = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommande)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppro)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 737;
            // 
            // btnQuitter
            // 
            this.btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.Location = new System.Drawing.Point(673, 28);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(30, 30);
            this.btnQuitter.TabIndex = 736;
            this.toolTip1.SetToolTip(this.btnQuitter, "Fermer");
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // dgvCommande
            // 
            this.dgvCommande.AllowUserToAddRows = false;
            this.dgvCommande.AllowUserToDeleteRows = false;
            this.dgvCommande.AllowUserToOrderColumns = true;
            this.dgvCommande.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommande.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvCommande.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCommande.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCommande.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCommande.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommande.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column5,
            this.Column8,
            this.Column7,
            this.Column6,
            this.Column10,
            this.Column11});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCommande.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCommande.EnableHeadersVisualStyles = false;
            this.dgvCommande.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvCommande.Location = new System.Drawing.Point(12, 97);
            this.dgvCommande.MultiSelect = false;
            this.dgvCommande.Name = "dgvCommande";
            this.dgvCommande.ReadOnly = true;
            this.dgvCommande.RowHeadersVisible = false;
            this.dgvCommande.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCommande.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCommande.Size = new System.Drawing.Size(319, 342);
            this.dgvCommande.TabIndex = 738;
            this.dgvCommande.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "N°";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Date com.";
            this.Column3.MinimumWidth = 130;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Produit";
            this.Column5.MinimumWidth = 150;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Forme";
            this.Column8.MinimumWidth = 100;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Dosage";
            this.Column7.MinimumWidth = 150;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Qté dem.";
            this.Column6.MinimumWidth = 130;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 130;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "idstock";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "prix_achat";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
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
            this.btnRetirer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirer.Image = ((System.Drawing.Image)(resources.GetObject("btnRetirer.Image")));
            this.btnRetirer.Location = new System.Drawing.Point(572, 68);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 21);
            this.btnRetirer.TabIndex = 751;
            this.toolTip1.SetToolTip(this.btnRetirer, "Supprimer cette commande");
            this.btnRetirer.UseVisualStyleBackColor = false;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnServir
            // 
            this.btnServir.BackColor = System.Drawing.Color.Transparent;
            this.btnServir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServir.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnServir.FlatAppearance.BorderSize = 0;
            this.btnServir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnServir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServir.Image = ((System.Drawing.Image)(resources.GetObject("btnServir.Image")));
            this.btnServir.Location = new System.Drawing.Point(531, 69);
            this.btnServir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServir.Name = "btnServir";
            this.btnServir.Size = new System.Drawing.Size(30, 21);
            this.btnServir.TabIndex = 750;
            this.toolTip1.SetToolTip(this.btnServir, "Servir cette commande");
            this.btnServir.UseVisualStyleBackColor = false;
            this.btnServir.Click += new System.EventHandler(this.btnServir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 746;
            this.label3.Text = "Catégorie :";
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.BorderSize = 0;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche.Image")));
            this.btnRecherche.Location = new System.Drawing.Point(297, 69);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 743;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(206, 70);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(86, 28);
            this.dtpDateA.TabIndex = 739;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(84, 70);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(86, 28);
            this.dtpDateDe.TabIndex = 740;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 71);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 22);
            this.label1.TabIndex = 741;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(9, 71);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(43, 22);
            this.lblDateEntree.TabIndex = 742;
            this.lblDateEntree.Text = "De :";
            // 
            // btnImprimer
            // 
            this.btnImprimer.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImprimer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnImprimer.FlatAppearance.BorderSize = 0;
            this.btnImprimer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnImprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimer.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimer.Image")));
            this.btnImprimer.Location = new System.Drawing.Point(613, 67);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(30, 21);
            this.btnImprimer.TabIndex = 752;
            this.toolTip1.SetToolTip(this.btnImprimer, "Imprimer le bon de commande");
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // btnRecherche2
            // 
            this.btnRecherche2.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche2.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche2.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche2.Image")));
            this.btnRecherche2.Location = new System.Drawing.Point(490, 68);
            this.btnRecherche2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRecherche2.Name = "btnRecherche2";
            this.btnRecherche2.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche2.TabIndex = 755;
            this.toolTip1.SetToolTip(this.btnRecherche2, "Rechercher");
            this.btnRecherche2.UseVisualStyleBackColor = false;
            this.btnRecherche2.Click += new System.EventHandler(this.btnRecherche2_Click);
            // 
            // btnNouveauProduit
            // 
            this.btnNouveauProduit.BackColor = System.Drawing.Color.Transparent;
            this.btnNouveauProduit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNouveauProduit.Enabled = false;
            this.btnNouveauProduit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNouveauProduit.FlatAppearance.BorderSize = 0;
            this.btnNouveauProduit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNouveauProduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveauProduit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveauProduit.Image = ((System.Drawing.Image)(resources.GetObject("btnNouveauProduit.Image")));
            this.btnNouveauProduit.Location = new System.Drawing.Point(301, 41);
            this.btnNouveauProduit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnNouveauProduit.Name = "btnNouveauProduit";
            this.btnNouveauProduit.Size = new System.Drawing.Size(30, 21);
            this.btnNouveauProduit.TabIndex = 762;
            this.toolTip1.SetToolTip(this.btnNouveauProduit, "Autre approvisionnement");
            this.btnNouveauProduit.UseVisualStyleBackColor = false;
            this.btnNouveauProduit.Click += new System.EventHandler(this.btnNouveauProduit_Click);
            // 
            // btnMiseAjour
            // 
            this.btnMiseAjour.BackColor = System.Drawing.Color.Transparent;
            this.btnMiseAjour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMiseAjour.Enabled = false;
            this.btnMiseAjour.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMiseAjour.FlatAppearance.BorderSize = 0;
            this.btnMiseAjour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMiseAjour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiseAjour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiseAjour.Image = ((System.Drawing.Image)(resources.GetObject("btnMiseAjour.Image")));
            this.btnMiseAjour.Location = new System.Drawing.Point(661, 67);
            this.btnMiseAjour.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnMiseAjour.Name = "btnMiseAjour";
            this.btnMiseAjour.Size = new System.Drawing.Size(30, 21);
            this.btnMiseAjour.TabIndex = 763;
            this.toolTip1.SetToolTip(this.btnMiseAjour, "Mettre à jour cet appro");
            this.btnMiseAjour.UseVisualStyleBackColor = false;
            this.btnMiseAjour.Click += new System.EventHandler(this.btnMiseAjour_Click);
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownHeight = 150;
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.IntegralHeight = false;
            this.cboCategorie.Location = new System.Drawing.Point(84, 40);
            this.cboCategorie.MaxDropDownItems = 10;
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(208, 30);
            this.cboCategorie.TabIndex = 753;
            this.cboCategorie.DropDown += new System.EventHandler(this.cboCategorie_DropDown);
            this.cboCategorie.SelectedIndexChanged += new System.EventHandler(this.cboCategorie_SelectedIndexChanged);
            // 
            // dgvAppro
            // 
            this.dgvAppro.AllowUserToAddRows = false;
            this.dgvAppro.AllowUserToDeleteRows = false;
            this.dgvAppro.AllowUserToOrderColumns = true;
            this.dgvAppro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvAppro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAppro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.Column9});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppro.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAppro.EnableHeadersVisualStyles = false;
            this.dgvAppro.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.dgvAppro.Location = new System.Drawing.Point(337, 98);
            this.dgvAppro.MultiSelect = false;
            this.dgvAppro.Name = "dgvAppro";
            this.dgvAppro.ReadOnly = true;
            this.dgvAppro.RowHeadersVisible = false;
            this.dgvAppro.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvAppro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppro.Size = new System.Drawing.Size(354, 342);
            this.dgvAppro.TabIndex = 754;
            this.dgvAppro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppro_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "N°";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Date appro.";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Qté appro";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Qté ajoutée";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 120;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Observation";
            this.Column9.MinimumWidth = 100;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(405, 68);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtRecherche.MaxLength = 75;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(85, 28);
            this.txtRecherche.TabIndex = 756;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(341, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 760;
            this.label2.Text = "Produit :";
            // 
            // cboDepot
            // 
            this.cboDepot.DropDownHeight = 150;
            this.cboDepot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDepot.FormattingEnabled = true;
            this.cboDepot.IntegralHeight = false;
            this.cboDepot.Location = new System.Drawing.Point(405, 37);
            this.cboDepot.MaxDropDownItems = 10;
            this.cboDepot.Name = "cboDepot";
            this.cboDepot.Size = new System.Drawing.Size(238, 30);
            this.cboDepot.TabIndex = 765;
            this.cboDepot.DropDown += new System.EventHandler(this.cboDepot_DropDown);
            this.cboDepot.SelectedIndexChanged += new System.EventHandler(this.cboDepot_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(341, 40);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 22);
            this.label4.TabIndex = 764;
            this.label4.Text = "Dépôt :";
            // 
            // FormApproCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.cboDepot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnMiseAjour);
            this.Controls.Add(this.btnNouveauProduit);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnRecherche2);
            this.Controls.Add(this.dgvAppro);
            this.Controls.Add(this.cboCategorie);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnServir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.dgvCommande);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormApproCommande";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommande)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.DataGridView dgvCommande;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnServir;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnImprimer;
        public System.Windows.Forms.ComboBox cboCategorie;
        public System.Windows.Forms.DataGridView dgvAppro;
        public System.Windows.Forms.TextBox txtRecherche;
        public System.Windows.Forms.Button btnRecherche2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnNouveauProduit;
        public System.Windows.Forms.Button btnMiseAjour;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        public System.Windows.Forms.ComboBox cboDepot;
        private System.Windows.Forms.Label label4;

    }
}