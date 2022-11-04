namespace SUMEDCO
{
    partial class FormStockPharma2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStockPharma2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnStockTout = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.txtProduit = new System.Windows.Forms.TextBox();
            this.dgvStock = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNouveauStock = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDemande = new System.Windows.Forms.Button();
            this.btnCommandes = new System.Windows.Forms.Button();
            this.btnEditerCommande = new System.Windows.Forms.Button();
            this.btnEditerRequisition = new System.Windows.Forms.Button();
            this.btnAlertes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSorties = new System.Windows.Forms.Button();
            this.btnEntrees = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFicheStock = new System.Windows.Forms.Button();
            this.listProduit = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 620;
            // 
            // btnStockTout
            // 
            this.btnStockTout.BackColor = System.Drawing.Color.Transparent;
            this.btnStockTout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStockTout.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStockTout.FlatAppearance.BorderSize = 0;
            this.btnStockTout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStockTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockTout.Image = ((System.Drawing.Image)(resources.GetObject("btnStockTout.Image")));
            this.btnStockTout.Location = new System.Drawing.Point(490, 71);
            this.btnStockTout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStockTout.Name = "btnStockTout";
            this.btnStockTout.Size = new System.Drawing.Size(30, 21);
            this.btnStockTout.TabIndex = 718;
            this.toolTip1.SetToolTip(this.btnStockTout, "Afficher pour tous les produits");
            this.btnStockTout.UseVisualStyleBackColor = false;
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.Transparent;
            this.btnStock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnStock.Enabled = false;
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.Location = new System.Drawing.Point(450, 71);
            this.btnStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(30, 21);
            this.btnStock.TabIndex = 715;
            this.toolTip1.SetToolTip(this.btnStock, "Afficher pour ce produit");
            this.btnStock.UseVisualStyleBackColor = false;
            // 
            // txtProduit
            // 
            this.txtProduit.Location = new System.Drawing.Point(92, 71);
            this.txtProduit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtProduit.MaxLength = 75;
            this.txtProduit.Name = "txtProduit";
            this.txtProduit.Size = new System.Drawing.Size(347, 21);
            this.txtProduit.TabIndex = 716;
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
            this.Column3,
            this.Column6,
            this.Column9,
            this.Column10,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column5});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvStock.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvStock.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvStock.Location = new System.Drawing.Point(12, 100);
            this.dgvStock.Name = "dgvStock";
            this.dgvStock.ReadOnly = true;
            this.dgvStock.RowHeadersVisible = false;
            this.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStock.Size = new System.Drawing.Size(679, 345);
            this.dgvStock.TabIndex = 714;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "ID";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "idproduit";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column9.HeaderText = "Produit";
            this.Column9.MinimumWidth = 150;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Conditionnement";
            this.Column10.MinimumWidth = 110;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 110;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Dosage";
            this.Column4.MinimumWidth = 110;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Forme";
            this.Column7.MinimumWidth = 100;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "N° Lot";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column1
            // 
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column1.HeaderText = "PVU";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column2.HeaderText = "Qté stock";
            this.Column2.MinimumWidth = 100;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "CMM";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.btnNouveauStock);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnDemande);
            this.panel1.Controls.Add(this.btnCommandes);
            this.panel1.Controls.Add(this.btnEditerCommande);
            this.panel1.Controls.Add(this.btnEditerRequisition);
            this.panel1.Controls.Add(this.btnAlertes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSorties);
            this.panel1.Controls.Add(this.btnEntrees);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnFicheStock);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(703, 30);
            this.panel1.TabIndex = 713;
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
            this.btnNouveauStock.Location = new System.Drawing.Point(242, 0);
            this.btnNouveauStock.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNouveauStock.Name = "btnNouveauStock";
            this.btnNouveauStock.Size = new System.Drawing.Size(30, 30);
            this.btnNouveauStock.TabIndex = 723;
            this.toolTip1.SetToolTip(this.btnNouveauStock, "Nouveau stock pharmaceutique");
            this.btnNouveauStock.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DimGray;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(241, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1, 30);
            this.label2.TabIndex = 727;
            this.label2.Text = "label2";
            // 
            // btnDemande
            // 
            this.btnDemande.BackColor = System.Drawing.Color.Transparent;
            this.btnDemande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDemande.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDemande.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDemande.FlatAppearance.BorderSize = 0;
            this.btnDemande.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDemande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDemande.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemande.Image = ((System.Drawing.Image)(resources.GetObject("btnDemande.Image")));
            this.btnDemande.Location = new System.Drawing.Point(211, 0);
            this.btnDemande.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDemande.Name = "btnDemande";
            this.btnDemande.Size = new System.Drawing.Size(30, 30);
            this.btnDemande.TabIndex = 715;
            this.toolTip1.SetToolTip(this.btnDemande, "Historique d\'approvisionnements");
            this.btnDemande.UseVisualStyleBackColor = false;
            // 
            // btnCommandes
            // 
            this.btnCommandes.BackColor = System.Drawing.Color.Transparent;
            this.btnCommandes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCommandes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCommandes.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCommandes.FlatAppearance.BorderSize = 0;
            this.btnCommandes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCommandes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommandes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommandes.Image = ((System.Drawing.Image)(resources.GetObject("btnCommandes.Image")));
            this.btnCommandes.Location = new System.Drawing.Point(181, 0);
            this.btnCommandes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCommandes.Name = "btnCommandes";
            this.btnCommandes.Size = new System.Drawing.Size(30, 30);
            this.btnCommandes.TabIndex = 660;
            this.toolTip1.SetToolTip(this.btnCommandes, "Historique des commandes");
            this.btnCommandes.UseVisualStyleBackColor = false;
            // 
            // btnEditerCommande
            // 
            this.btnEditerCommande.BackColor = System.Drawing.Color.Transparent;
            this.btnEditerCommande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditerCommande.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditerCommande.Enabled = false;
            this.btnEditerCommande.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEditerCommande.FlatAppearance.BorderSize = 0;
            this.btnEditerCommande.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditerCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditerCommande.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditerCommande.Image = ((System.Drawing.Image)(resources.GetObject("btnEditerCommande.Image")));
            this.btnEditerCommande.Location = new System.Drawing.Point(151, 0);
            this.btnEditerCommande.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEditerCommande.Name = "btnEditerCommande";
            this.btnEditerCommande.Size = new System.Drawing.Size(30, 30);
            this.btnEditerCommande.TabIndex = 713;
            this.toolTip1.SetToolTip(this.btnEditerCommande, "Nouvelle commande");
            this.btnEditerCommande.UseVisualStyleBackColor = false;
            // 
            // btnEditerRequisition
            // 
            this.btnEditerRequisition.BackColor = System.Drawing.Color.Transparent;
            this.btnEditerRequisition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEditerRequisition.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEditerRequisition.Enabled = false;
            this.btnEditerRequisition.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnEditerRequisition.FlatAppearance.BorderSize = 0;
            this.btnEditerRequisition.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnEditerRequisition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditerRequisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditerRequisition.Image = ((System.Drawing.Image)(resources.GetObject("btnEditerRequisition.Image")));
            this.btnEditerRequisition.Location = new System.Drawing.Point(121, 0);
            this.btnEditerRequisition.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEditerRequisition.Name = "btnEditerRequisition";
            this.btnEditerRequisition.Size = new System.Drawing.Size(30, 30);
            this.btnEditerRequisition.TabIndex = 714;
            this.toolTip1.SetToolTip(this.btnEditerRequisition, "Nouvelle réquisition");
            this.btnEditerRequisition.UseVisualStyleBackColor = false;
            // 
            // btnAlertes
            // 
            this.btnAlertes.BackColor = System.Drawing.Color.Transparent;
            this.btnAlertes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAlertes.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAlertes.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAlertes.FlatAppearance.BorderSize = 0;
            this.btnAlertes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAlertes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlertes.Image = ((System.Drawing.Image)(resources.GetObject("btnAlertes.Image")));
            this.btnAlertes.Location = new System.Drawing.Point(91, 0);
            this.btnAlertes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAlertes.Name = "btnAlertes";
            this.btnAlertes.Size = new System.Drawing.Size(30, 30);
            this.btnAlertes.TabIndex = 659;
            this.toolTip1.SetToolTip(this.btnAlertes, "Alertes d\'approvisionnement");
            this.btnAlertes.UseVisualStyleBackColor = false;
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
            // 
            // listProduit
            // 
            this.listProduit.FormattingEnabled = true;
            this.listProduit.ItemHeight = 15;
            this.listProduit.Location = new System.Drawing.Point(92, 94);
            this.listProduit.Name = "listProduit";
            this.listProduit.Size = new System.Drawing.Size(347, 154);
            this.listProduit.TabIndex = 717;
            this.listProduit.Visible = false;
            // 
            // FormConditionnement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnStockTout);
            this.Controls.Add(this.btnStock);
            this.Controls.Add(this.txtProduit);
            this.Controls.Add(this.dgvStock);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listProduit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormConditionnement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormConditionnement";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnStockTout;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnStock;
        public System.Windows.Forms.TextBox txtProduit;
        public System.Windows.Forms.DataGridView dgvStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnNouveauStock;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnDemande;
        public System.Windows.Forms.Button btnCommandes;
        public System.Windows.Forms.Button btnEditerCommande;
        public System.Windows.Forms.Button btnEditerRequisition;
        public System.Windows.Forms.Button btnAlertes;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSorties;
        public System.Windows.Forms.Button btnEntrees;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.Button btnFicheStock;
        public System.Windows.Forms.ListBox listProduit;
    }
}