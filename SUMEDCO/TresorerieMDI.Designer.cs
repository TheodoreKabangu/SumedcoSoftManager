namespace SUMEDCO
{
    partial class TresorerieMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TresorerieMDI));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnRapport = new System.Windows.Forms.Button();
            this.btnFluxFFL = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnFlux = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnRapport);
            this.pnlSide.Controls.Add(this.btnFluxFFL);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.btnFlux);
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
            this.btnRapport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnRapport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRapport.ForeColor = System.Drawing.Color.Black;
            this.btnRapport.Image = ((System.Drawing.Image)(resources.GetObject("btnRapport.Image")));
            this.btnRapport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.Location = new System.Drawing.Point(0, 117);
            this.btnRapport.Name = "btnRapport";
            this.btnRapport.Size = new System.Drawing.Size(180, 45);
            this.btnRapport.TabIndex = 3;
            this.btnRapport.Text = "Rapport flux";
            this.btnRapport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRapport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRapport.UseVisualStyleBackColor = true;
            this.btnRapport.Click += new System.EventHandler(this.btnRapport_Click);
            // 
            // btnFluxFFL
            // 
            this.btnFluxFFL.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFluxFFL.FlatAppearance.BorderSize = 0;
            this.btnFluxFFL.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnFluxFFL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFluxFFL.ForeColor = System.Drawing.Color.Black;
            this.btnFluxFFL.Image = ((System.Drawing.Image)(resources.GetObject("btnFluxFFL.Image")));
            this.btnFluxFFL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFluxFFL.Location = new System.Drawing.Point(0, 72);
            this.btnFluxFFL.Name = "btnFluxFFL";
            this.btnFluxFFL.Size = new System.Drawing.Size(180, 45);
            this.btnFluxFFL.TabIndex = 586;
            this.btnFluxFFL.Text = "Flux FFL";
            this.btnFluxFFL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFluxFFL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFluxFFL.UseVisualStyleBackColor = true;
            this.btnFluxFFL.Click += new System.EventHandler(this.btnFluxFFL_Click);
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
            this.btnQuitter.Location = new System.Drawing.Point(0, 446);
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
            // btnFlux
            // 
            this.btnFlux.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFlux.FlatAppearance.BorderSize = 0;
            this.btnFlux.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnFlux.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlux.ForeColor = System.Drawing.Color.Black;
            this.btnFlux.Image = ((System.Drawing.Image)(resources.GetObject("btnFlux.Image")));
            this.btnFlux.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlux.Location = new System.Drawing.Point(0, 27);
            this.btnFlux.Name = "btnFlux";
            this.btnFlux.Size = new System.Drawing.Size(180, 45);
            this.btnFlux.TabIndex = 1;
            this.btnFlux.Text = "Flux journaliers";
            this.btnFlux.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlux.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFlux.UseVisualStyleBackColor = true;
            this.btnFlux.Click += new System.EventHandler(this.btnFlux_Click);
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
            this.pnlChildForm.Size = new System.Drawing.Size(714, 491);
            this.pnlChildForm.TabIndex = 586;
            // 
            // TresorerieMDI
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
            this.Name = "TresorerieMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Dépense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnRapport;
        public System.Windows.Forms.Button btnFlux;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnFluxFFL;
    }
}