namespace SUMEDCO
{
    partial class MFormStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormStock));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnSortieStock = new System.Windows.Forms.Button();
            this.btnComPharma = new System.Windows.Forms.Button();
            this.btnHistoCommande = new System.Windows.Forms.Button();
            this.btnAlertes = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnStockProduit = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSide.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnSortieStock);
            this.pnlSide.Controls.Add(this.btnComPharma);
            this.pnlSide.Controls.Add(this.btnHistoCommande);
            this.pnlSide.Controls.Add(this.btnAlertes);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnStockProduit);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 491);
            this.pnlSide.TabIndex = 585;
            // 
            // btnRapport
            // 
            this.btnRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapport.FlatAppearance.BorderSize = 0;
            this.btnRapport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnRapport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapport.ForeColor = System.Drawing.Color.Black;
            this.btnRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnRapport.Image")));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.Location = new System.Drawing.Point(0, 297);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 586;
            this.btnRapport.Text = "Inventaire";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnSortieStock
            // 
            this.btnSortieStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSortieStock.FlatAppearance.BorderSize = 0;
            this.btnSortieStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnSortieStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSortieStock.ForeColor = System.Drawing.Color.Black;
            this.btnSortieStock.Image = ((System.Drawing.Image)(resources.GetObject("btnSortieStock.Image")));
            this.btnSortieStock.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortieStock.Location = new System.Drawing.Point(0, 252);
            this.btnSortieStock.Name = "btnSortieStock";
            this.btnSortieStock.Size = new System.Drawing.Size(180, 45);
            this.btnSortieStock.TabIndex = 588;
            this.btnSortieStock.Text = "Sorties des produits";
            this.btnSortieStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSortieStock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSortieStock.UseVisualStyleBackColor = true;
            this.btnSortieStock.Click += new System.EventHandler(this.btnSortieStock_Click);
            // 
            // btnComPharma
            // 
            this.btnComPharma.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComPharma.FlatAppearance.BorderSize = 0;
            this.btnComPharma.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnComPharma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComPharma.ForeColor = System.Drawing.Color.Black;
            this.btnComPharma.Image = ((System.Drawing.Image)(resources.GetObject("btnComPharma.Image")));
            this.btnComPharma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComPharma.Location = new System.Drawing.Point(0, 207);
            this.btnComPharma.Name = "btnComPharma";
            this.btnComPharma.Size = new System.Drawing.Size(180, 45);
            this.btnComPharma.TabIndex = 589;
            this.btnComPharma.Text = "Commandes reçues";
            this.btnComPharma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComPharma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComPharma.UseVisualStyleBackColor = true;
            this.btnComPharma.Click += new System.EventHandler(this.btnComPharma_Click);
            // 
            // btnHistoCommande
            // 
            this.btnHistoCommande.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistoCommande.FlatAppearance.BorderSize = 0;
            this.btnHistoCommande.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnHistoCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoCommande.ForeColor = System.Drawing.Color.Black;
            this.btnHistoCommande.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoCommande.Image")));
            this.btnHistoCommande.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoCommande.Location = new System.Drawing.Point(0, 162);
            this.btnHistoCommande.Name = "btnHistoCommande";
            this.btnHistoCommande.Size = new System.Drawing.Size(180, 45);
            this.btnHistoCommande.TabIndex = 3;
            this.btnHistoCommande.Text = "Mes commandes";
            this.btnHistoCommande.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistoCommande.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHistoCommande.UseVisualStyleBackColor = true;
            this.btnHistoCommande.Click += new System.EventHandler(this.btnHistoCommande_Click);
            // 
            // btnAlertes
            // 
            this.btnAlertes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlertes.FlatAppearance.BorderSize = 0;
            this.btnAlertes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAlertes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlertes.ForeColor = System.Drawing.Color.Black;
            this.btnAlertes.Image = ((System.Drawing.Image)(resources.GetObject("btnAlertes.Image")));
            this.btnAlertes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlertes.Location = new System.Drawing.Point(0, 117);
            this.btnAlertes.Name = "btnAlertes";
            this.btnAlertes.Size = new System.Drawing.Size(180, 45);
            this.btnAlertes.TabIndex = 587;
            this.btnAlertes.Text = "Alertes stocks";
            this.btnAlertes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlertes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlertes.UseVisualStyleBackColor = true;
            this.btnAlertes.Click += new System.EventHandler(this.btnAlertes_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Black;
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.Location = new System.Drawing.Point(0, 461);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(180, 30);
            this.btnQuitter.TabIndex = 585;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnStockProduit
            // 
            this.btnStockProduit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockProduit.FlatAppearance.BorderSize = 0;
            this.btnStockProduit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnStockProduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockProduit.ForeColor = System.Drawing.Color.Black;
            this.btnStockProduit.Image = ((System.Drawing.Image)(resources.GetObject("btnStockProduit.Image")));
            this.btnStockProduit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockProduit.Location = new System.Drawing.Point(0, 72);
            this.btnStockProduit.Name = "btnStockProduit";
            this.btnStockProduit.Size = new System.Drawing.Size(180, 45);
            this.btnStockProduit.TabIndex = 1;
            this.btnStockProduit.Text = "Stocks";
            this.btnStockProduit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockProduit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockProduit.UseVisualStyleBackColor = true;
            this.btnStockProduit.Click += new System.EventHandler(this.btnStocks_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.btnLogo);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 72);
            this.pnlLogo.TabIndex = 0;
            // 
            // btnLogo
            // 
            this.btnLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogo.Enabled = false;
            this.btnLogo.FlatAppearance.BorderSize = 0;
            this.btnLogo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.btnLogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogo.Font = new System.Drawing.Font("Segoe Marker", 20F);
            this.btnLogo.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogo.Location = new System.Drawing.Point(0, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(180, 72);
            this.btnLogo.TabIndex = 1;
            this.btnLogo.Text = "F.F.L.\r\nSUMEDCO";
            this.btnLogo.UseVisualStyleBackColor = false;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlChildForm.BackgroundImage")));
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(180, 0);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(714, 491);
            this.pnlChildForm.TabIndex = 586;
            // 
            // MFormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(894, 491);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 530);
            this.Name = "MFormStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Stocks";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnHistoCommande;
        public System.Windows.Forms.Button btnStockProduit;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Button btnLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Button btnAlertes;
        public System.Windows.Forms.Button btnSortieStock;
        public System.Windows.Forms.Button btnComPharma;
    }
}