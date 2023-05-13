namespace SUMEDCO
{
    partial class MFormInfirmerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFormInfirmerie));
            this.pnlSide = new System.Windows.Forms.Panel();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnIntervention = new System.Windows.Forms.Button();
            this.btnConsultation = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlChildForm = new System.Windows.Forms.Panel();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.pnlSide.Controls.Add(this.btnChat);
            this.pnlSide.Controls.Add(this.btnIntervention);
            this.pnlSide.Controls.Add(this.btnConsultation);
            this.pnlSide.Controls.Add(this.btnQuitter);
            this.pnlSide.Controls.Add(this.pnlLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(180, 474);
            this.pnlSide.TabIndex = 584;
            // 
            // btnChat
            // 
            this.btnChat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChat.Enabled = false;
            this.btnChat.FlatAppearance.BorderSize = 0;
            this.btnChat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.ForeColor = System.Drawing.Color.Black;
            this.btnChat.Image = ((System.Drawing.Image)(resources.GetObject("btnChat.Image")));
            this.btnChat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.Location = new System.Drawing.Point(0, 117);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(180, 45);
            this.btnChat.TabIndex = 586;
            this.btnChat.Text = "Messagerie";
            this.btnChat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChat.UseVisualStyleBackColor = true;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnIntervention
            // 
            this.btnIntervention.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnIntervention.FlatAppearance.BorderSize = 0;
            this.btnIntervention.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnIntervention.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIntervention.ForeColor = System.Drawing.Color.Black;
            this.btnIntervention.Image = ((System.Drawing.Image)(resources.GetObject("btnIntervention.Image")));
            this.btnIntervention.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntervention.Location = new System.Drawing.Point(0, 72);
            this.btnIntervention.Name = "btnIntervention";
            this.btnIntervention.Size = new System.Drawing.Size(180, 45);
            this.btnIntervention.TabIndex = 3;
            this.btnIntervention.Text = "Traitements";
            this.btnIntervention.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIntervention.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnIntervention.UseVisualStyleBackColor = true;
            // 
            // btnConsultation
            // 
            this.btnConsultation.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConsultation.FlatAppearance.BorderSize = 0;
            this.btnConsultation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSlateGray;
            this.btnConsultation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsultation.ForeColor = System.Drawing.Color.Black;
            this.btnConsultation.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultation.Image")));
            this.btnConsultation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultation.Location = new System.Drawing.Point(0, 27);
            this.btnConsultation.Name = "btnConsultation";
            this.btnConsultation.Size = new System.Drawing.Size(180, 45);
            this.btnConsultation.TabIndex = 1;
            this.btnConsultation.Text = "Cas à consulter ";
            this.btnConsultation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultation.UseVisualStyleBackColor = true;
            this.btnConsultation.Click += new System.EventHandler(this.btnConsultation_Click);
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
            this.btnQuitter.Location = new System.Drawing.Point(0, 429);
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
            this.pnlChildForm.Size = new System.Drawing.Size(708, 474);
            this.pnlChildForm.TabIndex = 585;
            // 
            // MFormInfirmerie
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
            this.Name = "MFormInfirmerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Infirmerie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormInfirmerie_Load);
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Button btnQuitter;
        public System.Windows.Forms.Button btnIntervention;
        public System.Windows.Forms.Button btnConsultation;
        private System.Windows.Forms.Panel pnlLogo;
        public System.Windows.Forms.Panel pnlChildForm;
        public System.Windows.Forms.Button btnChat;


    }
}