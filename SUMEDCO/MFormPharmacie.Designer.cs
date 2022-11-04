namespace SUMEDCO
{
    partial class MFormPharmacie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormPharmacie));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.pnlSousMenu = new System.Windows.Forms.Panel();
            this.btnUtilisation = new System.Windows.Forms.Button();
            this.btnVente = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnEntreeSortie = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.btnEncaisser = new System.Windows.Forms.Button();
            this.pnlSide.SuspendLayout();
            this.pnlSousMenu.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnEncaisser);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.pnlSousMenu);
            this.pnlSide.Controls.Add(this.btnEntreeSortie);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 471);
            this.pnlSide.TabIndex = 584;
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
            this.btnQuitter.Location = new System.Drawing.Point(0, 441);
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
            // btnRapport
            // 
            this.btnRapport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRapport.FlatAppearance.BorderSize = 0;
            this.btnRapport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnRapport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapport.ForeColor = System.Drawing.Color.Black;
            this.btnRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnRapport.Image")));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.Location = new System.Drawing.Point(0, 286);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 3;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            // 
            // pnlSousMenu
            // 
            this.pnlSousMenu.Controls.Add(this.btnUtilisation);
            this.pnlSousMenu.Controls.Add(this.btnVente);
            this.pnlSousMenu.Controls.Add(this.btnStock);
            this.pnlSousMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSousMenu.Location = new System.Drawing.Point(0, 117);
            this.pnlSousMenu.Name = "pnlSousMenu";
            this.pnlSousMenu.Size = new System.Drawing.Size(180, 124);
            this.pnlSousMenu.TabIndex = 2;
            // 
            // btnUtilisation
            // 
            this.btnUtilisation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUtilisation.FlatAppearance.BorderSize = 0;
            this.btnUtilisation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnUtilisation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUtilisation.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnUtilisation.Location = new System.Drawing.Point(0, 80);
            this.btnUtilisation.Name = "btnUtilisation";
            this.btnUtilisation.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnUtilisation.Size = new System.Drawing.Size(180, 40);
            this.btnUtilisation.TabIndex = 4;
            this.btnUtilisation.Text = "Utilisation des produits";
            this.btnUtilisation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUtilisation.UseVisualStyleBackColor = true;
            // 
            // btnVente
            // 
            this.btnVente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVente.FlatAppearance.BorderSize = 0;
            this.btnVente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnVente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVente.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnVente.Location = new System.Drawing.Point(0, 40);
            this.btnVente.Name = "btnVente";
            this.btnVente.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnVente.Size = new System.Drawing.Size(180, 40);
            this.btnVente.TabIndex = 2;
            this.btnVente.Text = "Ventes";
            this.btnVente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVente.UseVisualStyleBackColor = true;
            this.btnVente.Click += new System.EventHandler(this.btnVente_Click);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.FlatAppearance.BorderSize = 0;
            this.btnStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnStock.Location = new System.Drawing.Point(0, 0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Padding = new System.Windows.Forms.Padding(39, 0, 0, 0);
            this.btnStock.Size = new System.Drawing.Size(180, 40);
            this.btnStock.TabIndex = 0;
            this.btnStock.Text = "Stocks des produits";
            this.btnStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
            // 
            // btnEntreeSortie
            // 
            this.btnEntreeSortie.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEntreeSortie.FlatAppearance.BorderSize = 0;
            this.btnEntreeSortie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEntreeSortie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntreeSortie.ForeColor = System.Drawing.Color.Black;
            this.btnEntreeSortie.Image = ((System.Drawing.Image)(resources.GetObject("btnEntreeSortie.Image")));
            this.btnEntreeSortie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntreeSortie.Location = new System.Drawing.Point(0, 72);
            this.btnEntreeSortie.Name = "btnEntreeSortie";
            this.btnEntreeSortie.Size = new System.Drawing.Size(180, 45);
            this.btnEntreeSortie.TabIndex = 1;
            this.btnEntreeSortie.Text = "Entrées - Sorties";
            this.btnEntreeSortie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntreeSortie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEntreeSortie.UseVisualStyleBackColor = true;
            this.btnEntreeSortie.Click += new System.EventHandler(this.btnEntreeSortie_Click);
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
            this.pnlChildForm.Size = new System.Drawing.Size(714, 471);
            this.pnlChildForm.TabIndex = 585;
            // 
            // btnEncaisser
            // 
            this.btnEncaisser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEncaisser.FlatAppearance.BorderSize = 0;
            this.btnEncaisser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnEncaisser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncaisser.ForeColor = System.Drawing.Color.Black;
            this.btnEncaisser.Image = ((System.Drawing.Image)(resources.GetObject("btnEncaisser.Image")));
            this.btnEncaisser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncaisser.Location = new System.Drawing.Point(0, 241);
            this.btnEncaisser.Name = "btnEncaisser";
            this.btnEncaisser.Size = new System.Drawing.Size(180, 45);
            this.btnEncaisser.TabIndex = 586;
            this.btnEncaisser.Text = "Encaisser";
            this.btnEncaisser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncaisser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEncaisser.UseVisualStyleBackColor = true;
            this.btnEncaisser.Click += new System.EventHandler(this.btnEncaisser_Click);
            // 
            // MFormPharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(894, 471);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 510);
            this.Name = "MFormPharmacie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Pharmacie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.pnlSousMenu.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Panel pnlSousMenu;
        public System.Windows.Forms.Button btnVente;
        public System.Windows.Forms.Button btnStock;
        public System.Windows.Forms.Button btnEntreeSortie;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Button btnLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnUtilisation;
        public System.Windows.Forms.Button btnEncaisser;

    }
}