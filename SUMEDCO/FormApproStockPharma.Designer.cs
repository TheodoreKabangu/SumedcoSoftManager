namespace SUMEDCO
{
    partial class FormApproStockPharma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApproStockPharma));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.dgvAppro = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnServir = new System.Windows.Forms.Button();
            this.btnNonServies = new System.Windows.Forms.Button();
            this.btnServies = new System.Windows.Forms.Button();
            this.btnToutes = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompte = new System.Windows.Forms.TextBox();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateEntree = new System.Windows.Forms.Label();
            this.listProduit = new System.Windows.Forms.ListBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImprimer = new System.Windows.Forms.Button();
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
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // dgvAppro
            // 
            this.dgvAppro.AllowUserToAddRows = false;
            this.dgvAppro.AllowUserToDeleteRows = false;
            this.dgvAppro.AllowUserToOrderColumns = true;
            this.dgvAppro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppro.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvAppro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAppro.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAppro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAppro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column10,
            this.Column13,
            this.Column5,
            this.Column2,
            this.Column7,
            this.Column8,
            this.Column6,
            this.Column12,
            this.Column14,
            this.Column11,
            this.Column9,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAppro.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAppro.Location = new System.Drawing.Point(12, 96);
            this.dgvAppro.MultiSelect = false;
            this.dgvAppro.Name = "dgvAppro";
            this.dgvAppro.ReadOnly = true;
            this.dgvAppro.RowHeadersVisible = false;
            this.dgvAppro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAppro.Size = new System.Drawing.Size(679, 343);
            this.dgvAppro.TabIndex = 738;
            this.dgvAppro.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStock_CellClick);
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
            this.Column3.HeaderText = "Date com.";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "idstock";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "idproduit";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column5.HeaderText = "Produit";
            this.Column5.MinimumWidth = 150;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Conditionnement";
            this.Column2.MinimumWidth = 150;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column7.HeaderText = "Dosage";
            this.Column7.MinimumWidth = 150;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Forme";
            this.Column8.MinimumWidth = 100;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Qté dem.";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Qté appro";
            this.Column12.MinimumWidth = 100;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "Qté ajoutée";
            this.Column14.MinimumWidth = 100;
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "P.A.U.";
            this.Column11.MinimumWidth = 100;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.ToolTipText = "Prix d\'achat unitaire";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Taux(%)";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "P.V.U.";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.ToolTipText = "Prix de vente";
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
            this.btnRetirer.Location = new System.Drawing.Point(532, 67);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 21);
            this.btnRetirer.TabIndex = 751;
            this.toolTip1.SetToolTip(this.btnRetirer, "Supprimer cette demande");
            this.btnRetirer.UseVisualStyleBackColor = false;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnServir
            // 
            this.btnServir.BackColor = System.Drawing.Color.Transparent;
            this.btnServir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServir.Enabled = false;
            this.btnServir.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnServir.FlatAppearance.BorderSize = 0;
            this.btnServir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnServir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServir.Image = ((System.Drawing.Image)(resources.GetObject("btnServir.Image")));
            this.btnServir.Location = new System.Drawing.Point(491, 68);
            this.btnServir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServir.Name = "btnServir";
            this.btnServir.Size = new System.Drawing.Size(30, 21);
            this.btnServir.TabIndex = 750;
            this.toolTip1.SetToolTip(this.btnServir, "Servir cette demande");
            this.btnServir.UseVisualStyleBackColor = false;
            this.btnServir.Click += new System.EventHandler(this.btnServir_Click);
            // 
            // btnNonServies
            // 
            this.btnNonServies.BackColor = System.Drawing.Color.Transparent;
            this.btnNonServies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNonServies.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnNonServies.FlatAppearance.BorderSize = 0;
            this.btnNonServies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNonServies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNonServies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonServies.Image = ((System.Drawing.Image)(resources.GetObject("btnNonServies.Image")));
            this.btnNonServies.Location = new System.Drawing.Point(451, 68);
            this.btnNonServies.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNonServies.Name = "btnNonServies";
            this.btnNonServies.Size = new System.Drawing.Size(30, 21);
            this.btnNonServies.TabIndex = 749;
            this.toolTip1.SetToolTip(this.btnNonServies, "Demandes non servies");
            this.btnNonServies.UseVisualStyleBackColor = false;
            // 
            // btnServies
            // 
            this.btnServies.BackColor = System.Drawing.Color.Transparent;
            this.btnServies.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnServies.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnServies.FlatAppearance.BorderSize = 0;
            this.btnServies.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnServies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServies.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnServies.Image = ((System.Drawing.Image)(resources.GetObject("btnServies.Image")));
            this.btnServies.Location = new System.Drawing.Point(411, 68);
            this.btnServies.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnServies.Name = "btnServies";
            this.btnServies.Size = new System.Drawing.Size(30, 21);
            this.btnServies.TabIndex = 748;
            this.toolTip1.SetToolTip(this.btnServies, "Demandes servies");
            this.btnServies.UseVisualStyleBackColor = false;
            // 
            // btnToutes
            // 
            this.btnToutes.BackColor = System.Drawing.Color.Transparent;
            this.btnToutes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnToutes.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnToutes.FlatAppearance.BorderSize = 0;
            this.btnToutes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnToutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToutes.Image = ((System.Drawing.Image)(resources.GetObject("btnToutes.Image")));
            this.btnToutes.Location = new System.Drawing.Point(441, 41);
            this.btnToutes.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnToutes.Name = "btnToutes";
            this.btnToutes.Size = new System.Drawing.Size(30, 21);
            this.btnToutes.TabIndex = 747;
            this.toolTip1.SetToolTip(this.btnToutes, "Afficher tout");
            this.btnToutes.UseVisualStyleBackColor = false;
            this.btnToutes.Click += new System.EventHandler(this.btnToutes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 15);
            this.label3.TabIndex = 746;
            this.label3.Text = "Nom produit :";
            // 
            // txtCompte
            // 
            this.txtCompte.Location = new System.Drawing.Point(92, 40);
            this.txtCompte.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtCompte.MaxLength = 75;
            this.txtCompte.Name = "txtCompte";
            this.txtCompte.Size = new System.Drawing.Size(347, 21);
            this.txtCompte.TabIndex = 744;
            this.txtCompte.TextChanged += new System.EventHandler(this.txtCompte_TextChanged);
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
            this.btnRecherche.Location = new System.Drawing.Point(371, 68);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 743;
            this.toolTip1.SetToolTip(this.btnRecherche, "Afficher pour cette période");
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(250, 68);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(113, 21);
            this.dtpDateA.TabIndex = 739;
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(92, 68);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(113, 21);
            this.dtpDateDe.TabIndex = 740;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(215, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 15);
            this.label1.TabIndex = 741;
            this.label1.Text = "à :";
            // 
            // lblDateEntree
            // 
            this.lblDateEntree.AutoSize = true;
            this.lblDateEntree.Location = new System.Drawing.Point(9, 73);
            this.lblDateEntree.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDateEntree.Name = "lblDateEntree";
            this.lblDateEntree.Size = new System.Drawing.Size(29, 15);
            this.lblDateEntree.TabIndex = 742;
            this.lblDateEntree.Text = "De :";
            // 
            // listProduit
            // 
            this.listProduit.FormattingEnabled = true;
            this.listProduit.ItemHeight = 15;
            this.listProduit.Location = new System.Drawing.Point(92, 63);
            this.listProduit.Name = "listProduit";
            this.listProduit.Size = new System.Drawing.Size(347, 154);
            this.listProduit.TabIndex = 745;
            this.listProduit.Visible = false;
            this.listProduit.SelectedIndexChanged += new System.EventHandler(this.listProduit_SelectedIndexChanged);
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
            this.btnImprimer.Location = new System.Drawing.Point(573, 67);
            this.btnImprimer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimer.Name = "btnImprimer";
            this.btnImprimer.Size = new System.Drawing.Size(30, 21);
            this.btnImprimer.TabIndex = 752;
            this.toolTip1.SetToolTip(this.btnImprimer, "Imprimer le bon de commande");
            this.btnImprimer.UseVisualStyleBackColor = false;
            this.btnImprimer.Click += new System.EventHandler(this.btnImprimer_Click);
            // 
            // FormApproStockPharma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.btnImprimer);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnServir);
            this.Controls.Add(this.btnNonServies);
            this.Controls.Add(this.btnServies);
            this.Controls.Add(this.btnToutes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompte);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDateEntree);
            this.Controls.Add(this.dgvAppro);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.listProduit);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(719, 490);
            this.Name = "FormApproStockPharma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Approvisionnement produits pharmaceutiques";
            this.Shown += new System.EventHandler(this.FormApproRapport_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.DataGridView dgvAppro;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnServir;
        public System.Windows.Forms.Button btnNonServies;
        public System.Windows.Forms.Button btnServies;
        public System.Windows.Forms.Button btnToutes;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtCompte;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblDateEntree;
        public System.Windows.Forms.ListBox listProduit;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.Button btnImprimer;

    }
}