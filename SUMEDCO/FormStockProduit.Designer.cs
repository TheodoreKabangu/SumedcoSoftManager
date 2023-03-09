namespace SUMEDCO
{
    partial class FormStockProduit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockProduit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStockPha = new System.Windows.Forms.Button();
            this.btnNouveauStock = new System.Windows.Forms.Button();
            this.btnPerte = new System.Windows.Forms.Button();
            this.btnDemande = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSorties = new System.Windows.Forms.Button();
            this.btnEntrees = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFicheStock = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnRecherche = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboCategorie = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvProduit = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.btnStockPha);
            this.panel2.Controls.Add(this.btnNouveauStock);
            this.panel2.Controls.Add(this.btnPerte);
            this.panel2.Controls.Add(this.btnDemande);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSorties);
            this.panel2.Controls.Add(this.btnEntrees);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnFicheStock);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 30);
            this.panel2.TabIndex = 625;
            // 
            // btnStockPha
            // 
            this.btnStockPha.BackColor = System.Drawing.Color.Transparent;
            this.btnStockPha.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStockPha.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnStockPha.Enabled = false;
            this.btnStockPha.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStockPha.FlatAppearance.BorderSize = 0;
            this.btnStockPha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStockPha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockPha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockPha.Image = ((System.Drawing.Image)(resources.GetObject("btnStockPha.Image")));
            this.btnStockPha.Location = new System.Drawing.Point(181, 0);
            this.btnStockPha.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStockPha.Name = "btnStockPha";
            this.btnStockPha.Size = new System.Drawing.Size(30, 30);
            this.btnStockPha.TabIndex = 727;
            this.toolTip1.SetToolTip(this.btnStockPha, "Ajouter ce stock à la pharmacie");
            this.btnStockPha.UseVisualStyleBackColor = false;
            this.btnStockPha.Click += new System.EventHandler(this.btnStockPha_Click);
            // 
            // btnNouveauStock
            // 
            this.btnNouveauStock.BackColor = System.Drawing.Color.Transparent;
            this.btnNouveauStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNouveauStock.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNouveauStock.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNouveauStock.FlatAppearance.BorderSize = 0;
            this.btnNouveauStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNouveauStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveauStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveauStock.Image = ((System.Drawing.Image)(resources.GetObject("btnNouveauStock.Image")));
            this.btnNouveauStock.Location = new System.Drawing.Point(151, 0);
            this.btnNouveauStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNouveauStock.Name = "btnNouveauStock";
            this.btnNouveauStock.Size = new System.Drawing.Size(30, 30);
            this.btnNouveauStock.TabIndex = 723;
            this.toolTip1.SetToolTip(this.btnNouveauStock, "Ajouter un nouveau stock");
            this.btnNouveauStock.UseVisualStyleBackColor = false;
            this.btnNouveauStock.Click += new System.EventHandler(this.btnNouveauStock_Click);
            // 
            // btnPerte
            // 
            this.btnPerte.BackColor = System.Drawing.Color.Transparent;
            this.btnPerte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPerte.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPerte.Enabled = false;
            this.btnPerte.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPerte.FlatAppearance.BorderSize = 0;
            this.btnPerte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPerte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerte.Image = ((System.Drawing.Image)(resources.GetObject("btnPerte.Image")));
            this.btnPerte.Location = new System.Drawing.Point(121, 0);
            this.btnPerte.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPerte.Name = "btnPerte";
            this.btnPerte.Size = new System.Drawing.Size(30, 30);
            this.btnPerte.TabIndex = 726;
            this.toolTip1.SetToolTip(this.btnPerte, "Servir une demande");
            this.btnPerte.UseVisualStyleBackColor = false;
            this.btnPerte.Click += new System.EventHandler(this.btnPerte_Click);
            // 
            // btnDemande
            // 
            this.btnDemande.BackColor = System.Drawing.Color.Transparent;
            this.btnDemande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDemande.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDemande.Enabled = false;
            this.btnDemande.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDemande.FlatAppearance.BorderSize = 0;
            this.btnDemande.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDemande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDemande.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemande.Image = ((System.Drawing.Image)(resources.GetObject("btnDemande.Image")));
            this.btnDemande.Location = new System.Drawing.Point(91, 0);
            this.btnDemande.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDemande.Name = "btnDemande";
            this.btnDemande.Size = new System.Drawing.Size(30, 30);
            this.btnDemande.TabIndex = 715;
            this.toolTip1.SetToolTip(this.btnDemande, "Servir une demande");
            this.btnDemande.UseVisualStyleBackColor = false;
            this.btnDemande.Click += new System.EventHandler(this.btnDemande_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DimGray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(90, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1, 30);
            this.label1.TabIndex = 725;
            this.label1.Text = "label1";
            // 
            // btnSorties
            // 
            this.btnSorties.BackColor = System.Drawing.Color.Transparent;
            this.btnSorties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSorties.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSorties.Enabled = false;
            this.btnSorties.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSorties.FlatAppearance.BorderSize = 0;
            this.btnSorties.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSorties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSorties.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSorties.Image = ((System.Drawing.Image)(resources.GetObject("btnSorties.Image")));
            this.btnSorties.Location = new System.Drawing.Point(60, 0);
            this.btnSorties.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSorties.Name = "btnSorties";
            this.btnSorties.Size = new System.Drawing.Size(30, 30);
            this.btnSorties.TabIndex = 658;
            this.toolTip1.SetToolTip(this.btnSorties, "Afficher les sorties");
            this.btnSorties.UseVisualStyleBackColor = false;
            this.btnSorties.Click += new System.EventHandler(this.btnSorties_Click);
            // 
            // btnEntrees
            // 
            this.btnEntrees.BackColor = System.Drawing.Color.Transparent;
            this.btnEntrees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEntrees.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEntrees.Enabled = false;
            this.btnEntrees.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEntrees.FlatAppearance.BorderSize = 0;
            this.btnEntrees.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEntrees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntrees.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrees.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrees.Image")));
            this.btnEntrees.Location = new System.Drawing.Point(30, 0);
            this.btnEntrees.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEntrees.Name = "btnEntrees";
            this.btnEntrees.Size = new System.Drawing.Size(30, 30);
            this.btnEntrees.TabIndex = 657;
            this.toolTip1.SetToolTip(this.btnEntrees, "Afficher les entrées");
            this.btnEntrees.UseVisualStyleBackColor = false;
            this.btnEntrees.Click += new System.EventHandler(this.btnEntrees_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(673, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 656;
            this.toolTip1.SetToolTip(this.btnExit, "Fermer");
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFicheStock
            // 
            this.btnFicheStock.BackColor = System.Drawing.Color.Transparent;
            this.btnFicheStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFicheStock.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFicheStock.Enabled = false;
            this.btnFicheStock.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnFicheStock.FlatAppearance.BorderSize = 0;
            this.btnFicheStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFicheStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFicheStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFicheStock.Image = ((System.Drawing.Image)(resources.GetObject("btnFicheStock.Image")));
            this.btnFicheStock.Location = new System.Drawing.Point(0, 0);
            this.btnFicheStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFicheStock.Name = "btnFicheStock";
            this.btnFicheStock.Size = new System.Drawing.Size(30, 30);
            this.btnFicheStock.TabIndex = 655;
            this.toolTip1.SetToolTip(this.btnFicheStock, "Afficher la fiche de stock");
            this.btnFicheStock.UseVisualStyleBackColor = false;
            this.btnFicheStock.Click += new System.EventHandler(this.btnFicheStock_Click);
            // 
            // btnRecherche
            // 
            this.btnRecherche.BackColor = System.Drawing.Color.Transparent;
            this.btnRecherche.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRecherche.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecherche.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecherche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecherche.Image = ((System.Drawing.Image)(resources.GetObject("btnRecherche.Image")));
            this.btnRecherche.Location = new System.Drawing.Point(416, 75);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 756;
            this.toolTip1.SetToolTip(this.btnRecherche, "Rechercher");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 27);
            this.panel1.TabIndex = 713;
            // 
            // cboCategorie
            // 
            this.cboCategorie.DropDownHeight = 150;
            this.cboCategorie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCategorie.FormattingEnabled = true;
            this.cboCategorie.IntegralHeight = false;
            this.cboCategorie.Items.AddRange(new object[] {
            "passant",
            "patient"});
            this.cboCategorie.Location = new System.Drawing.Point(78, 75);
            this.cboCategorie.MaxDropDownItems = 10;
            this.cboCategorie.Name = "cboCategorie";
            this.cboCategorie.Size = new System.Drawing.Size(188, 30);
            this.cboCategorie.TabIndex = 755;
            this.cboCategorie.DropDown += new System.EventHandler(this.cboCategorie_DropDown);
            this.cboCategorie.SelectedIndexChanged += new System.EventHandler(this.cboCategorie_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 78);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 754;
            this.label4.Text = "Catégorie :";
            // 
            // dgvStock
            // 
            this.dgvStock.AllowUserToAddRows = false;
            this.dgvStock.AllowUserToDeleteRows = false;
            this.dgvStock.AllowUserToOrderColumns = true;
            this.dgvStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStock.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStock.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn10});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvStock.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvStock.Location = new System.Drawing.Point(232, 104);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(459, 335);
            this.dgvStock.TabIndex = 626;
            this.dgvStock.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn8.HeaderText = "Qté stock";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn9.HeaderText = "CMM";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Forme";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Dosage";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 110;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "N° Lot";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Expiration";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // txtRecherche
            // 
            this.txtRecherche.Location = new System.Drawing.Point(331, 75);
            this.txtRecherche.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtRecherche.MaxLength = 75;
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Size = new System.Drawing.Size(85, 28);
            this.txtRecherche.TabIndex = 757;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(275, 78);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 760;
            this.label3.Text = "Produit :";
            // 
            // dgvProduit
            // 
            this.dgvProduit.AllowUserToAddRows = false;
            this.dgvProduit.AllowUserToDeleteRows = false;
            this.dgvProduit.AllowUserToOrderColumns = true;
            this.dgvProduit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvProduit.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvProduit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProduit.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProduit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvProduit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProduit.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvProduit.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvProduit.Location = new System.Drawing.Point(12, 104);
            this.dgvProduit.MultiSelect = false;
            this.dgvProduit.Name = "dgvProduit";
            this.dgvProduit.ReadOnly = true;
            this.dgvProduit.RowHeadersVisible = false;
            this.dgvProduit.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvProduit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProduit.Size = new System.Drawing.Size(214, 335);
            this.dgvProduit.TabIndex = 761;
            this.dgvProduit.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduit_CellClick);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Produit";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // FormStockProduit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.dgvProduit);
            this.Controls.Add(this.txtRecherche);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.cboCategorie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStockProduit";
            this.Text = "FormStockProduit";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cboCategorie;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgvStock;
        public System.Windows.Forms.TextBox txtRecherche;
        public System.Windows.Forms.Button btnRecherche;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dgvProduit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        public System.Windows.Forms.Button btnNouveauStock;
        public System.Windows.Forms.Button btnDemande;
        public System.Windows.Forms.Button btnSorties;
        public System.Windows.Forms.Button btnEntrees;
        public System.Windows.Forms.Button btnFicheStock;
        public System.Windows.Forms.Button btnPerte;
        public System.Windows.Forms.Button btnStockPha;
    }
}