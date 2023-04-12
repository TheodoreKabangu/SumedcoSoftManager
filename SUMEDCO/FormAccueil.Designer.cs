namespace SUMEDCO
{
    partial class FormAccueil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAccueil));
            this.btnExit = new System.Windows.Forms.Button();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnAbonne = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnPharma = new System.Windows.Forms.Button();
            this.btnCompta = new System.Windows.Forms.Button();
            this.btnDepense = new System.Windows.Forms.Button();
            this.btnMalade = new System.Windows.Forms.Button();
            this.btnInfirmerie = new System.Windows.Forms.Button();
            this.btnRecette = new System.Windows.Forms.Button();
            this.btnReception = new System.Windows.Forms.Button();
            this.bunifuElipse2 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.btnImagerie = new System.Windows.Forms.Button();
            this.btnLabo = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(210, 18);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 38);
            this.btnExit.TabIndex = 160;
            this.btnExit.Text = "Quitter";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 125;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 77);
            this.panel1.TabIndex = 161;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 677);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 77);
            this.panel2.TabIndex = 136;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 24F);
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(0, 77);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(544, 62);
            this.label10.TabIndex = 169;
            this.label10.Text = "Menu d\'accueil de SSM";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.Controls.Add(this.btnAdmin);
            this.pnlMenu.Controls.Add(this.btnStock);
            this.pnlMenu.Controls.Add(this.btnPharma);
            this.pnlMenu.Controls.Add(this.btnCompta);
            this.pnlMenu.Controls.Add(this.btnDepense);
            this.pnlMenu.Controls.Add(this.btnLabo);
            this.pnlMenu.Controls.Add(this.btnMalade);
            this.pnlMenu.Controls.Add(this.btnInfirmerie);
            this.pnlMenu.Controls.Add(this.btnImagerie);
            this.pnlMenu.Controls.Add(this.btnRecette);
            this.pnlMenu.Controls.Add(this.btnReception);
            this.pnlMenu.Controls.Add(this.btnAbonne);
            this.pnlMenu.Location = new System.Drawing.Point(78, 148);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(388, 506);
            this.pnlMenu.TabIndex = 170;
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.Transparent;
            this.btnAdmin.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAdmin.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAdmin.FlatAppearance.BorderSize = 0;
            this.btnAdmin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdmin.ForeColor = System.Drawing.Color.Black;
            this.btnAdmin.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.Image")));
            this.btnAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAdmin.Location = new System.Drawing.Point(0, 759);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(362, 69);
            this.btnAdmin.TabIndex = 563;
            this.btnAdmin.Text = "Administration";
            this.btnAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdmin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btnAbonne
            // 
            this.btnAbonne.BackColor = System.Drawing.Color.Transparent;
            this.btnAbonne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbonne.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAbonne.FlatAppearance.BorderSize = 0;
            this.btnAbonne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnAbonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbonne.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonne.ForeColor = System.Drawing.Color.Black;
            this.btnAbonne.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonne.Image")));
            this.btnAbonne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonne.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAbonne.Location = new System.Drawing.Point(0, 0);
            this.btnAbonne.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbonne.Name = "btnAbonne";
            this.btnAbonne.Size = new System.Drawing.Size(362, 69);
            this.btnAbonne.TabIndex = 562;
            this.btnAbonne.Text = "Abonnés/Employés";
            this.btnAbonne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonne.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbonne.UseVisualStyleBackColor = false;
            this.btnAbonne.Click += new System.EventHandler(this.btnAbonne_Click);
            // 
            // btnStock
            // 
            this.btnStock.BackColor = System.Drawing.Color.Transparent;
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.Black;
            this.btnStock.Image = ((System.Drawing.Image)(resources.GetObject("btnStock.Image")));
            this.btnStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStock.Location = new System.Drawing.Point(0, 690);
            this.btnStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(362, 69);
            this.btnStock.TabIndex = 561;
            this.btnStock.Text = "Stock des produits";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStock.UseVisualStyleBackColor = false;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnPharma
            // 
            this.btnPharma.BackColor = System.Drawing.Color.Transparent;
            this.btnPharma.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPharma.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnPharma.FlatAppearance.BorderSize = 0;
            this.btnPharma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnPharma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPharma.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPharma.ForeColor = System.Drawing.Color.Black;
            this.btnPharma.Image = ((System.Drawing.Image)(resources.GetObject("btnPharma.Image")));
            this.btnPharma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPharma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPharma.Location = new System.Drawing.Point(0, 621);
            this.btnPharma.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPharma.Name = "btnPharma";
            this.btnPharma.Size = new System.Drawing.Size(362, 69);
            this.btnPharma.TabIndex = 560;
            this.btnPharma.Text = "Pharmacie";
            this.btnPharma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPharma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPharma.UseVisualStyleBackColor = false;
            this.btnPharma.Click += new System.EventHandler(this.btnPharma_Click);
            // 
            // btnCompta
            // 
            this.btnCompta.BackColor = System.Drawing.Color.Transparent;
            this.btnCompta.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompta.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCompta.FlatAppearance.BorderSize = 0;
            this.btnCompta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCompta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompta.ForeColor = System.Drawing.Color.Black;
            this.btnCompta.Image = ((System.Drawing.Image)(resources.GetObject("btnCompta.Image")));
            this.btnCompta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompta.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCompta.Location = new System.Drawing.Point(0, 552);
            this.btnCompta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCompta.Name = "btnCompta";
            this.btnCompta.Size = new System.Drawing.Size(362, 69);
            this.btnCompta.TabIndex = 559;
            this.btnCompta.Text = "Comptabilité";
            this.btnCompta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompta.UseVisualStyleBackColor = false;
            this.btnCompta.Click += new System.EventHandler(this.btnCompta_Click);
            // 
            // btnDepense
            // 
            this.btnDepense.BackColor = System.Drawing.Color.Transparent;
            this.btnDepense.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepense.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDepense.FlatAppearance.BorderSize = 0;
            this.btnDepense.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDepense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepense.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepense.ForeColor = System.Drawing.Color.Black;
            this.btnDepense.Image = ((System.Drawing.Image)(resources.GetObject("btnDepense.Image")));
            this.btnDepense.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepense.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDepense.Location = new System.Drawing.Point(0, 483);
            this.btnDepense.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDepense.Name = "btnDepense";
            this.btnDepense.Size = new System.Drawing.Size(362, 69);
            this.btnDepense.TabIndex = 557;
            this.btnDepense.Text = "Trésorerie";
            this.btnDepense.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepense.UseVisualStyleBackColor = false;
            this.btnDepense.Click += new System.EventHandler(this.btnDepense_Click);
            // 
            // btnMalade
            // 
            this.btnMalade.BackColor = System.Drawing.Color.Transparent;
            this.btnMalade.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMalade.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnMalade.FlatAppearance.BorderSize = 0;
            this.btnMalade.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMalade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMalade.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMalade.ForeColor = System.Drawing.Color.Black;
            this.btnMalade.Image = ((System.Drawing.Image)(resources.GetObject("btnMalade.Image")));
            this.btnMalade.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMalade.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMalade.Location = new System.Drawing.Point(0, 345);
            this.btnMalade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMalade.Name = "btnMalade";
            this.btnMalade.Size = new System.Drawing.Size(362, 69);
            this.btnMalade.TabIndex = 553;
            this.btnMalade.Text = "Cabinet du médecin";
            this.btnMalade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMalade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMalade.UseVisualStyleBackColor = false;
            this.btnMalade.Click += new System.EventHandler(this.btnMalade_Click);
            // 
            // btnInfirmerie
            // 
            this.btnInfirmerie.BackColor = System.Drawing.Color.Transparent;
            this.btnInfirmerie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfirmerie.FlatAppearance.BorderSize = 0;
            this.btnInfirmerie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnInfirmerie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfirmerie.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnInfirmerie.ForeColor = System.Drawing.Color.Black;
            this.btnInfirmerie.Image = ((System.Drawing.Image)(resources.GetObject("btnInfirmerie.Image")));
            this.btnInfirmerie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfirmerie.Location = new System.Drawing.Point(0, 276);
            this.btnInfirmerie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInfirmerie.Name = "btnInfirmerie";
            this.btnInfirmerie.Size = new System.Drawing.Size(362, 69);
            this.btnInfirmerie.TabIndex = 564;
            this.btnInfirmerie.Text = "Salle des soins";
            this.btnInfirmerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfirmerie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInfirmerie.UseVisualStyleBackColor = false;
            this.btnInfirmerie.Click += new System.EventHandler(this.btnInfirmerie_Click);
            // 
            // btnRecette
            // 
            this.btnRecette.BackColor = System.Drawing.Color.Transparent;
            this.btnRecette.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecette.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRecette.FlatAppearance.BorderSize = 0;
            this.btnRecette.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnRecette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecette.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecette.ForeColor = System.Drawing.Color.Black;
            this.btnRecette.Image = ((System.Drawing.Image)(resources.GetObject("btnRecette.Image")));
            this.btnRecette.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecette.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnRecette.Location = new System.Drawing.Point(0, 138);
            this.btnRecette.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecette.Name = "btnRecette";
            this.btnRecette.Size = new System.Drawing.Size(362, 69);
            this.btnRecette.TabIndex = 555;
            this.btnRecette.Text = "Caisse des recettes";
            this.btnRecette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecette.UseVisualStyleBackColor = false;
            this.btnRecette.Click += new System.EventHandler(this.btnRecette_Click);
            // 
            // btnReception
            // 
            this.btnReception.BackColor = System.Drawing.Color.Transparent;
            this.btnReception.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReception.FlatAppearance.BorderSize = 0;
            this.btnReception.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReception.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReception.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnReception.ForeColor = System.Drawing.Color.Black;
            this.btnReception.Image = ((System.Drawing.Image)(resources.GetObject("btnReception.Image")));
            this.btnReception.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReception.Location = new System.Drawing.Point(0, 69);
            this.btnReception.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReception.Name = "btnReception";
            this.btnReception.Size = new System.Drawing.Size(362, 69);
            this.btnReception.TabIndex = 565;
            this.btnReception.Text = "Réception";
            this.btnReception.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReception.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReception.UseVisualStyleBackColor = false;
            this.btnReception.Click += new System.EventHandler(this.btnReception_Click);
            // 
            // bunifuElipse2
            // 
            this.bunifuElipse2.ElipseRadius = 20;
            this.bunifuElipse2.TargetControl = this.btnExit;
            // 
            // btnImagerie
            // 
            this.btnImagerie.BackColor = System.Drawing.Color.Transparent;
            this.btnImagerie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnImagerie.FlatAppearance.BorderSize = 0;
            this.btnImagerie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnImagerie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImagerie.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnImagerie.ForeColor = System.Drawing.Color.Black;
            this.btnImagerie.Image = ((System.Drawing.Image)(resources.GetObject("btnImagerie.Image")));
            this.btnImagerie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagerie.Location = new System.Drawing.Point(0, 207);
            this.btnImagerie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImagerie.Name = "btnImagerie";
            this.btnImagerie.Size = new System.Drawing.Size(362, 69);
            this.btnImagerie.TabIndex = 566;
            this.btnImagerie.Text = "Imagerie";
            this.btnImagerie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImagerie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImagerie.UseVisualStyleBackColor = false;
            this.btnImagerie.Click += new System.EventHandler(this.btnImagerie_Click);
            // 
            // btnLabo
            // 
            this.btnLabo.BackColor = System.Drawing.Color.Transparent;
            this.btnLabo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLabo.FlatAppearance.BorderSize = 0;
            this.btnLabo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLabo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLabo.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.btnLabo.ForeColor = System.Drawing.Color.Black;
            this.btnLabo.Image = ((System.Drawing.Image)(resources.GetObject("btnLabo.Image")));
            this.btnLabo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLabo.Location = new System.Drawing.Point(0, 414);
            this.btnLabo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLabo.Name = "btnLabo";
            this.btnLabo.Size = new System.Drawing.Size(362, 69);
            this.btnLabo.TabIndex = 567;
            this.btnLabo.Text = "Laboratoire";
            this.btnLabo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLabo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLabo.UseVisualStyleBackColor = false;
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(544, 754);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAccueil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM";
            this.Shown += new System.EventHandler(this.FormAccueil_Shown);
            this.panel2.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnExit;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel pnlMenu;
        public System.Windows.Forms.Button btnMalade;
        private System.Windows.Forms.Button btnRecette;
        public System.Windows.Forms.Button btnDepense;
        public System.Windows.Forms.Button btnCompta;
        public System.Windows.Forms.Button btnAdmin;
        public System.Windows.Forms.Button btnAbonne;
        private System.Windows.Forms.Button btnStock;
        public System.Windows.Forms.Button btnPharma;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse2;
        public System.Windows.Forms.Button btnInfirmerie;
        public System.Windows.Forms.Button btnReception;
        public System.Windows.Forms.Button btnImagerie;
        public System.Windows.Forms.Button btnLabo;
    }
}