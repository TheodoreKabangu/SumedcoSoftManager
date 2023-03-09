namespace SUMEDCO
{
    partial class MFormRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormRecette));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnRecette = new System.Windows.Forms.Button();
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
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnRecette);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 474);
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
            this.btnQuitter.Location = new System.Drawing.Point(0, 444);
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
            this.btnRapport.Location = new System.Drawing.Point(0, 117);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 3;
            this.btnRapport.Text = "Rapports";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnRecette
            // 
            this.btnRecette.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRecette.FlatAppearance.BorderSize = 0;
            this.btnRecette.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnRecette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecette.ForeColor = System.Drawing.Color.Black;
            this.btnRecette.Image = ((System.Drawing.Image)(resources.GetObject("btnRecette.Image")));
            this.btnRecette.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecette.Location = new System.Drawing.Point(0, 72);
            this.btnRecette.Name = "btnRecette";
            this.btnRecette.Size = new System.Drawing.Size(180, 45);
            this.btnRecette.TabIndex = 1;
            this.btnRecette.Text = "Bons à encaisser";
            this.btnRecette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRecette.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRecette.UseVisualStyleBackColor = true;
            this.btnRecette.Click += new System.EventHandler(this.btnRecette_Click);
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
            this.pnlChildForm.Size = new System.Drawing.Size(708, 474);
            this.pnlChildForm.TabIndex = 585;
            // 
            // MFormRecette
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(888, 474);
            this.Controls.Add(this.pnlChildForm);
            this.Controls.Add(this.pnlSide);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(910, 530);
            this.Name = "MFormRecette";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Recette";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.pnlLogo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Button btnRecette;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Button btnLogo;
        public System.Windows.Forms.Panel pnlChildForm;
    }
}