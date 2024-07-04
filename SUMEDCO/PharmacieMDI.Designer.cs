namespace SUMEDCO
{
    partial class PharmacieMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PharmacieMDI));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnUtilisation = new System.Windows.Forms.Button();
            this.btnCommande = new System.Windows.Forms.Button();
            this.btnVente = new System.Windows.Forms.Button();
            this.btnStockPh = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.btnFacturePorduit = new System.Windows.Forms.Button();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnChat);
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnUtilisation);
            this.pnlSide.Controls.Add(this.btnCommande);
            this.pnlSide.Controls.Add(this.btnVente);
            this.pnlSide.Controls.Add(this.btnStockPh);
            this.pnlSide.Controls.Add(this.btnFacturePorduit);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 483);
            this.pnlSide.TabIndex = 584;
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.ForeColor = System.Drawing.Color.Black;
            this.btnChat.Image = ((System.Drawing.Image)(resources.GetObject("btnChat.Image")));
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(0, 297);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(180, 45);
            this.btnChat.TabIndex = 590;
            this.btnChat.Text = "Messagerie";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            // 
            // btnRapport
            // 
            this.btnRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapport.FlatAppearance.BorderSize = 0;
            this.btnRapport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRapport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapport.ForeColor = System.Drawing.Color.Black;
            this.btnRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnRapport.Image")));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.Location = new System.Drawing.Point(0, 252);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 3;
            this.btnRapport.Text = "Inventaire";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnUtilisation
            // 
            this.btnUtilisation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUtilisation.FlatAppearance.BorderSize = 0;
            this.btnUtilisation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnUtilisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtilisation.ForeColor = System.Drawing.Color.Black;
            this.btnUtilisation.Image = ((System.Drawing.Image)(resources.GetObject("btnUtilisation.Image")));
            this.btnUtilisation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilisation.Location = new System.Drawing.Point(0, 207);
            this.btnUtilisation.Name = "btnUtilisation";
            this.btnUtilisation.Size = new System.Drawing.Size(180, 45);
            this.btnUtilisation.TabIndex = 1;
            this.btnUtilisation.Text = "Utilisations";
            this.btnUtilisation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilisation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUtilisation.UseVisualStyleBackColor = true;
            this.btnUtilisation.Click += new System.EventHandler(this.btnUtilisation_Click);
            // 
            // btnCommande
            // 
            this.btnCommande.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCommande.FlatAppearance.BorderSize = 0;
            this.btnCommande.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommande.ForeColor = System.Drawing.Color.Black;
            this.btnCommande.Image = ((System.Drawing.Image)(resources.GetObject("btnCommande.Image")));
            this.btnCommande.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommande.Location = new System.Drawing.Point(0, 162);
            this.btnCommande.Name = "btnCommande";
            this.btnCommande.Size = new System.Drawing.Size(180, 45);
            this.btnCommande.TabIndex = 588;
            this.btnCommande.Text = "Mes commandes";
            this.btnCommande.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommande.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCommande.UseVisualStyleBackColor = true;
            this.btnCommande.Click += new System.EventHandler(this.btnCommande_Click);
            // 
            // btnVente
            // 
            this.btnVente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVente.FlatAppearance.BorderSize = 0;
            this.btnVente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnVente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVente.ForeColor = System.Drawing.Color.Black;
            this.btnVente.Image = ((System.Drawing.Image)(resources.GetObject("btnVente.Image")));
            this.btnVente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVente.Location = new System.Drawing.Point(0, 117);
            this.btnVente.Name = "btnVente";
            this.btnVente.Size = new System.Drawing.Size(180, 45);
            this.btnVente.TabIndex = 586;
            this.btnVente.Text = "Ventes";
            this.btnVente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnEncaisser_Click);
            // 
            // btnStockPh
            // 
            this.btnStockPh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStockPh.FlatAppearance.BorderSize = 0;
            this.btnStockPh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnStockPh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockPh.ForeColor = System.Drawing.Color.Black;
            this.btnStockPh.Image = ((System.Drawing.Image)(resources.GetObject("btnStockPh.Image")));
            this.btnStockPh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockPh.Location = new System.Drawing.Point(0, 72);
            this.btnStockPh.Name = "btnStockPh";
            this.btnStockPh.Size = new System.Drawing.Size(180, 45);
            this.btnStockPh.TabIndex = 587;
            this.btnStockPh.Text = "Stocks";
            this.btnStockPh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStockPh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStockPh.UseVisualStyleBackColor = true;
            this.btnStockPh.Click += new System.EventHandler(this.btnStockPh_Click);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnQuitter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.ForeColor = System.Drawing.Color.Black;
            this.btnQuitter.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitter.Image")));
            this.btnQuitter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.Location = new System.Drawing.Point(0, 438);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(180, 45);
            this.btnQuitter.TabIndex = 585;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(180, 27);
            this.pnlLogo.TabIndex = 0;
            // 
            // pnlChildForm
            // 
            this.pnlChildForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlChildForm.BackgroundImage")));
            this.pnlChildForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChildForm.Location = new System.Drawing.Point(180, 0);
            this.pnlChildForm.Name = "pnlChildForm";
            this.pnlChildForm.Size = new System.Drawing.Size(712, 483);
            this.pnlChildForm.TabIndex = 585;
            // 
            // btnFacturePorduit
            // 
            this.btnFacturePorduit.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturePorduit.FlatAppearance.BorderSize = 0;
            this.btnFacturePorduit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnFacturePorduit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturePorduit.ForeColor = System.Drawing.Color.Black;
            this.btnFacturePorduit.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturePorduit.Image")));
            this.btnFacturePorduit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturePorduit.Location = new System.Drawing.Point(0, 27);
            this.btnFacturePorduit.Name = "btnFacturePorduit";
            this.btnFacturePorduit.Size = new System.Drawing.Size(180, 45);
            this.btnFacturePorduit.TabIndex = 591;
            this.btnFacturePorduit.Text = "Facturation";
            this.btnFacturePorduit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturePorduit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturePorduit.UseVisualStyleBackColor = true;
            this.btnFacturePorduit.Click += new System.EventHandler(this.btnFacturePorduit_Click);
            // 
            // PharmacieMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(892, 483);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 530);
            this.Name = "PharmacieMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Pharmacie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Button btnUtilisation;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnVente;
        public System.Windows.Forms.Button btnStockPh;
        public System.Windows.Forms.Button btnCommande;
        public System.Windows.Forms.Button btnChat;
        public System.Windows.Forms.Button btnFacturePorduit;

    }
}