namespace SUMEDCO
{
    partial class FormBonRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBonRecette));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.dgvPayement = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRecette = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnValiderBon = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnRetirer = new System.Windows.Forms.Button();
            this.btnActualiser = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnAfficherTout = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnTouteRecette = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.lblTaux = new System.Windows.Forms.Label();
            this.lblDateOperation = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateA = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateDe = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecherche = new System.Windows.Forms.Button();
            this.cboCaisseRecette = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCaisseUSD = new System.Windows.Forms.Label();
            this.lblCaisseCDF = new System.Windows.Forms.Label();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnulerPayement = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(703, 27);
            this.panel2.TabIndex = 591;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(672, 28);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(30, 30);
            this.btnExit.TabIndex = 617;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dgvPayement
            // 
            this.dgvPayement.AllowUserToAddRows = false;
            this.dgvPayement.AllowUserToDeleteRows = false;
            this.dgvPayement.AllowUserToOrderColumns = true;
            this.dgvPayement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPayement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvPayement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPayement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPayement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvPayement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column8});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPayement.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvPayement.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvPayement.Location = new System.Drawing.Point(590, 113);
            this.dgvPayement.MultiSelect = false;
            this.dgvPayement.Name = "dgvPayement";
            this.dgvPayement.ReadOnly = true;
            this.dgvPayement.RowHeadersVisible = false;
            this.dgvPayement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayement.Size = new System.Drawing.Size(101, 326);
            this.dgvPayement.TabIndex = 618;
            this.dgvPayement.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacture_CellClick);
            // 
            // Column10
            // 
            this.Column10.HeaderText = "id";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "Payements";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // dgvRecette
            // 
            this.dgvRecette.AllowUserToAddRows = false;
            this.dgvRecette.AllowUserToDeleteRows = false;
            this.dgvRecette.AllowUserToOrderColumns = true;
            this.dgvRecette.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecette.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.dgvRecette.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecette.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRecette.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvRecette.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecette.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.Column6,
            this.Column9,
            this.Column4,
            this.Column7,
            this.Column1,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Lavender;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecette.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvRecette.GridColor = System.Drawing.Color.RoyalBlue;
            this.dgvRecette.Location = new System.Drawing.Point(11, 113);
            this.dgvRecette.MultiSelect = false;
            this.dgvRecette.Name = "dgvRecette";
            this.dgvRecette.ReadOnly = true;
            this.dgvRecette.RowHeadersVisible = false;
            this.dgvRecette.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecette.Size = new System.Drawing.Size(573, 326);
            this.dgvRecette.TabIndex = 619;
            this.dgvRecette.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBon_CellClick);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtTotal.Location = new System.Drawing.Point(556, 31);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(17, 14);
            this.txtTotal.TabIndex = 621;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnValiderBon
            // 
            this.btnValiderBon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnValiderBon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValiderBon.Enabled = false;
            this.btnValiderBon.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValiderBon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValiderBon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderBon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderBon.Location = new System.Drawing.Point(625, 83);
            this.btnValiderBon.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnValiderBon.Name = "btnValiderBon";
            this.btnValiderBon.Size = new System.Drawing.Size(33, 27);
            this.btnValiderBon.TabIndex = 622;
            this.btnValiderBon.Text = "Valider";
            this.btnValiderBon.UseVisualStyleBackColor = false;
            this.btnValiderBon.Click += new System.EventHandler(this.btnValiderBon_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnSupprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSupprimer.Enabled = false;
            this.btnSupprimer.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSupprimer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(669, 82);
            this.btnSupprimer.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(33, 27);
            this.btnSupprimer.TabIndex = 623;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
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
            this.btnRetirer.Location = new System.Drawing.Point(487, 27);
            this.btnRetirer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRetirer.Name = "btnRetirer";
            this.btnRetirer.Size = new System.Drawing.Size(30, 21);
            this.btnRetirer.TabIndex = 627;
            this.toolTip1.SetToolTip(this.btnRetirer, "Retirer cette ligne");
            this.btnRetirer.UseVisualStyleBackColor = false;
            this.btnRetirer.Click += new System.EventHandler(this.btnRetirer_Click);
            // 
            // btnActualiser
            // 
            this.btnActualiser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnActualiser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnActualiser.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnActualiser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnActualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualiser.Location = new System.Drawing.Point(331, 28);
            this.btnActualiser.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnActualiser.Name = "btnActualiser";
            this.btnActualiser.Size = new System.Drawing.Size(34, 27);
            this.btnActualiser.TabIndex = 631;
            this.btnActualiser.Text = "Actualiser";
            this.btnActualiser.UseVisualStyleBackColor = false;
            this.btnActualiser.Click += new System.EventHandler(this.btnActualiser_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnuler.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(376, 30);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(33, 27);
            this.btnAnnuler.TabIndex = 639;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnAfficherTout
            // 
            this.btnAfficherTout.BackColor = System.Drawing.Color.Transparent;
            this.btnAfficherTout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAfficherTout.Enabled = false;
            this.btnAfficherTout.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAfficherTout.FlatAppearance.BorderSize = 0;
            this.btnAfficherTout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAfficherTout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAfficherTout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAfficherTout.Image = ((System.Drawing.Image)(resources.GetObject("btnAfficherTout.Image")));
            this.btnAfficherTout.Location = new System.Drawing.Point(527, 28);
            this.btnAfficherTout.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAfficherTout.Name = "btnAfficherTout";
            this.btnAfficherTout.Size = new System.Drawing.Size(30, 21);
            this.btnAfficherTout.TabIndex = 640;
            this.toolTip1.SetToolTip(this.btnAfficherTout, "Afficher tout");
            this.btnAfficherTout.UseVisualStyleBackColor = false;
            this.btnAfficherTout.Click += new System.EventHandler(this.btnAfficherTout_Click);
            // 
            // btnTouteRecette
            // 
            this.btnTouteRecette.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnTouteRecette.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTouteRecette.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTouteRecette.FlatAppearance.BorderSize = 0;
            this.btnTouteRecette.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTouteRecette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTouteRecette.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTouteRecette.Image = ((System.Drawing.Image)(resources.GetObject("btnTouteRecette.Image")));
            this.btnTouteRecette.Location = new System.Drawing.Point(440, 83);
            this.btnTouteRecette.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnTouteRecette.Name = "btnTouteRecette";
            this.btnTouteRecette.Size = new System.Drawing.Size(30, 21);
            this.btnTouteRecette.TabIndex = 646;
            this.toolTip1.SetToolTip(this.btnTouteRecette, "Valider le payement");
            this.btnTouteRecette.UseVisualStyleBackColor = false;
            this.btnTouteRecette.Click += new System.EventHandler(this.btnTouteRecette_Click);
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
            this.btnDate.Location = new System.Drawing.Point(134, 57);
            this.btnDate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(30, 21);
            this.btnDate.TabIndex = 645;
            this.btnDate.UseVisualStyleBackColor = false;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // lblTaux
            // 
            this.lblTaux.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTaux.Location = new System.Drawing.Point(212, 59);
            this.lblTaux.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTaux.Name = "lblTaux";
            this.lblTaux.Size = new System.Drawing.Size(75, 15);
            this.lblTaux.TabIndex = 641;
            this.lblTaux.Text = "0000";
            this.lblTaux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDateOperation
            // 
            this.lblDateOperation.ForeColor = System.Drawing.Color.IndianRed;
            this.lblDateOperation.Location = new System.Drawing.Point(49, 59);
            this.lblDateOperation.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDateOperation.Name = "lblDateOperation";
            this.lblDateOperation.Size = new System.Drawing.Size(80, 15);
            this.lblDateOperation.TabIndex = 642;
            this.lblDateOperation.Text = "jj/mm/aaaa";
            this.lblDateOperation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 643;
            this.label4.Text = "Taux :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 644;
            this.label3.Text = "Date :";
            // 
            // dtpDateA
            // 
            this.dtpDateA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateA.Location = new System.Drawing.Point(165, 85);
            this.dtpDateA.Name = "dtpDateA";
            this.dtpDateA.Size = new System.Drawing.Size(87, 21);
            this.dtpDateA.TabIndex = 649;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 15);
            this.label2.TabIndex = 651;
            this.label2.Text = "à :";
            // 
            // dtpDateDe
            // 
            this.dtpDateDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateDe.Location = new System.Drawing.Point(45, 85);
            this.dtpDateDe.Name = "dtpDateDe";
            this.dtpDateDe.Size = new System.Drawing.Size(87, 21);
            this.dtpDateDe.TabIndex = 650;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 652;
            this.label1.Text = "De :";
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
            this.btnRecherche.Location = new System.Drawing.Point(255, 85);
            this.btnRecherche.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRecherche.Name = "btnRecherche";
            this.btnRecherche.Size = new System.Drawing.Size(30, 21);
            this.btnRecherche.TabIndex = 648;
            this.btnRecherche.UseVisualStyleBackColor = false;
            this.btnRecherche.Click += new System.EventHandler(this.btnRecherche_Click);
            // 
            // cboCaisseRecette
            // 
            this.cboCaisseRecette.DropDownHeight = 150;
            this.cboCaisseRecette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCaisseRecette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCaisseRecette.FormattingEnabled = true;
            this.cboCaisseRecette.IntegralHeight = false;
            this.cboCaisseRecette.Items.AddRange(new object[] {
            "CDF",
            "USD"});
            this.cboCaisseRecette.Location = new System.Drawing.Point(369, 82);
            this.cboCaisseRecette.MaxDropDownItems = 10;
            this.cboCaisseRecette.Name = "cboCaisseRecette";
            this.cboCaisseRecette.Size = new System.Drawing.Size(62, 23);
            this.cboCaisseRecette.Sorted = true;
            this.cboCaisseRecette.TabIndex = 674;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.label10.TabIndex = 675;
            this.label10.Text = "CDF/USD :";
            // 
            // lblCaisseUSD
            // 
            this.lblCaisseUSD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseUSD.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseUSD.Location = new System.Drawing.Point(299, 59);
            this.lblCaisseUSD.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseUSD.Name = "lblCaisseUSD";
            this.lblCaisseUSD.Size = new System.Drawing.Size(179, 15);
            this.lblCaisseUSD.TabIndex = 676;
            this.lblCaisseUSD.Text = "0000";
            this.lblCaisseUSD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCaisseCDF
            // 
            this.lblCaisseCDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaisseCDF.ForeColor = System.Drawing.Color.MediumBlue;
            this.lblCaisseCDF.Location = new System.Drawing.Point(509, 59);
            this.lblCaisseCDF.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCaisseCDF.Name = "lblCaisseCDF";
            this.lblCaisseCDF.Size = new System.Drawing.Size(179, 15);
            this.lblCaisseCDF.TabIndex = 676;
            this.lblCaisseCDF.Text = "0000";
            this.lblCaisseCDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValider.FlatAppearance.BorderSize = 0;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Image = ((System.Drawing.Image)(resources.GetObject("btnValider.Image")));
            this.btnValider.Location = new System.Drawing.Point(477, 83);
            this.btnValider.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(30, 21);
            this.btnValider.TabIndex = 646;
            this.btnValider.UseVisualStyleBackColor = false;
            // 
            // btnAnnulerPayement
            // 
            this.btnAnnulerPayement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAnnulerPayement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAnnulerPayement.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAnnulerPayement.FlatAppearance.BorderSize = 0;
            this.btnAnnulerPayement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAnnulerPayement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnulerPayement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerPayement.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnulerPayement.Image")));
            this.btnAnnulerPayement.Location = new System.Drawing.Point(516, 83);
            this.btnAnnulerPayement.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnAnnulerPayement.Name = "btnAnnulerPayement";
            this.btnAnnulerPayement.Size = new System.Drawing.Size(30, 21);
            this.btnAnnulerPayement.TabIndex = 646;
            this.btnAnnulerPayement.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(554, 83);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 21);
            this.button3.TabIndex = 646;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewCellStyle16.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn5.HeaderText = "N°";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 40;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Statut";
            this.Column6.MinimumWidth = 100;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column9
            // 
            dataGridViewCellStyle17.Format = "N2";
            dataGridViewCellStyle17.NullValue = null;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle17;
            this.Column9.HeaderText = "Montant";
            this.Column9.MinimumWidth = 100;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Caisse";
            this.Column4.MinimumWidth = 80;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 80;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "categorie";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "typepayeur";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Payeur";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // FormBonRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(703, 451);
            this.Controls.Add(this.lblCaisseCDF);
            this.Controls.Add(this.lblCaisseUSD);
            this.Controls.Add(this.cboCaisseRecette);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpDateA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDateDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecherche);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnAnnulerPayement);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnTouteRecette);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.lblTaux);
            this.Controls.Add(this.lblDateOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAfficherTout);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnActualiser);
            this.Controls.Add(this.btnRetirer);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnValiderBon);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.dgvRecette);
            this.Controls.Add(this.dgvPayement);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBonRecette";
            this.ShowIcon = false;
            this.Text = "FormBon";
            this.Shown += new System.EventHandler(this.FormBon_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecette)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnExit;
        public System.Windows.Forms.DataGridView dgvPayement;
        public System.Windows.Forms.DataGridView dgvRecette;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.Button btnValiderBon;
        public System.Windows.Forms.Button btnSupprimer;
        public System.Windows.Forms.Button btnRetirer;
        public System.Windows.Forms.Button btnActualiser;
        public System.Windows.Forms.Button btnAnnuler;
        public System.Windows.Forms.Button btnAfficherTout;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button btnDate;
        public System.Windows.Forms.Label lblTaux;
        public System.Windows.Forms.Label lblDateOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btnTouteRecette;
        public System.Windows.Forms.DateTimePicker dtpDateA;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dtpDateDe;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnRecherche;
        public System.Windows.Forms.ComboBox cboCaisseRecette;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label lblCaisseUSD;
        public System.Windows.Forms.Label lblCaisseCDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        public System.Windows.Forms.Button btnValider;
        public System.Windows.Forms.Button btnAnnulerPayement;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Timer timer1;
    }
}