namespace SUMEDCO
{
    partial class MFormAbonne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormAbonne));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnVoirAbonne = new System.Windows.Forms.Button();
            this.btnAncien = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnAbonne = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.btnLogo = new System.Windows.Forms.Button();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.btnProduitConsomme = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.pnlSide.SuspendLayout();
            this.pnlLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnChat);
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnProduitConsomme);
            this.pnlSide.Controls.Add(this.btnVoirAbonne);
            this.pnlSide.Controls.Add(this.btnAncien);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnAbonne);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 491);
            this.pnlSide.TabIndex = 586;
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
            this.btnRapport.Location = new System.Drawing.Point(0, 252);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 5;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnVoirAbonne
            // 
            this.btnVoirAbonne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnVoirAbonne.FlatAppearance.BorderSize = 0;
            this.btnVoirAbonne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnVoirAbonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoirAbonne.ForeColor = System.Drawing.Color.Black;
            this.btnVoirAbonne.Image = ((System.Drawing.Image)(resources.GetObject("btnVoirAbonne.Image")));
            this.btnVoirAbonne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoirAbonne.Location = new System.Drawing.Point(0, 162);
            this.btnVoirAbonne.Name = "btnVoirAbonne";
            this.btnVoirAbonne.Size = new System.Drawing.Size(180, 45);
            this.btnVoirAbonne.TabIndex = 586;
            this.btnVoirAbonne.Text = "Services consommés";
            this.btnVoirAbonne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVoirAbonne.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoirAbonne.UseVisualStyleBackColor = true;
            this.btnVoirAbonne.Click += new System.EventHandler(this.btnVoirAbonne_Click);
            // 
            // btnAncien
            // 
            this.btnAncien.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAncien.FlatAppearance.BorderSize = 0;
            this.btnAncien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAncien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAncien.ForeColor = System.Drawing.Color.Black;
            this.btnAncien.Image = ((System.Drawing.Image)(resources.GetObject("btnAncien.Image")));
            this.btnAncien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAncien.Location = new System.Drawing.Point(0, 117);
            this.btnAncien.Name = "btnAncien";
            this.btnAncien.Size = new System.Drawing.Size(180, 45);
            this.btnAncien.TabIndex = 587;
            this.btnAncien.Text = "Ancien cas";
            this.btnAncien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAncien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAncien.UseVisualStyleBackColor = true;
            this.btnAncien.Click += new System.EventHandler(this.btnAncien_Click);
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
            // btnAbonne
            // 
            this.btnAbonne.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbonne.FlatAppearance.BorderSize = 0;
            this.btnAbonne.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnAbonne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbonne.ForeColor = System.Drawing.Color.Black;
            this.btnAbonne.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonne.Image")));
            this.btnAbonne.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonne.Location = new System.Drawing.Point(0, 72);
            this.btnAbonne.Name = "btnAbonne";
            this.btnAbonne.Size = new System.Drawing.Size(180, 45);
            this.btnAbonne.TabIndex = 1;
            this.btnAbonne.Text = "Nouveau cas";
            this.btnAbonne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonne.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbonne.UseVisualStyleBackColor = true;
            this.btnAbonne.Click += new System.EventHandler(this.btnAbonne_Click);
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
            this.pnlChildForm.TabIndex = 587;
            // 
            // btnProduitConsomme
            // 
            this.btnProduitConsomme.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduitConsomme.FlatAppearance.BorderSize = 0;
            this.btnProduitConsomme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnProduitConsomme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduitConsomme.ForeColor = System.Drawing.Color.Black;
            this.btnProduitConsomme.Image = ((System.Drawing.Image)(resources.GetObject("btnProduitConsomme.Image")));
            this.btnProduitConsomme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduitConsomme.Location = new System.Drawing.Point(0, 207);
            this.btnProduitConsomme.Name = "btnProduitConsomme";
            this.btnProduitConsomme.Size = new System.Drawing.Size(180, 45);
            this.btnProduitConsomme.TabIndex = 588;
            this.btnProduitConsomme.Text = "Produits consommés";
            this.btnProduitConsomme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduitConsomme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProduitConsomme.UseVisualStyleBackColor = true;
            this.btnProduitConsomme.Click += new System.EventHandler(this.btnProduitConsomme_Click);
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.ForeColor = System.Drawing.Color.Black;
            this.btnChat.Image = ((System.Drawing.Image)(resources.GetObject("btnChat.Image")));
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(0, 297);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(180, 45);
            this.btnChat.TabIndex = 589;
            this.btnChat.Text = "Messagerie";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            // 
            // MFormAbonne
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
            this.Name = "MFormAbonne";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Abonnés et Employés";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnAbonne;
        public System.Windows.Forms.Button btnRapport;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Button btnLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnVoirAbonne;
        public System.Windows.Forms.Button btnAncien;
        public System.Windows.Forms.Button btnProduitConsomme;
        public System.Windows.Forms.Button btnChat;
    }
}