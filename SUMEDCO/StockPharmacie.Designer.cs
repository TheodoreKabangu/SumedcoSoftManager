namespace SUMEDCO
{
    partial class StockPharmacie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockPharmacie));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboPharma = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPharmacie = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 18);
            this.label2.TabIndex = 640;
            this.label2.Text = "Pharmacies existantes:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(392, 27);
            this.panel1.TabIndex = 649;
            // 
            // cboPharma
            // 
            this.cboPharma.DropDownHeight = 150;
            this.cboPharma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPharma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPharma.FormattingEnabled = true;
            this.cboPharma.IntegralHeight = false;
            this.cboPharma.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cboPharma.Location = new System.Drawing.Point(18, 66);
            this.cboPharma.MaxDropDownItems = 10;
            this.cboPharma.Name = "cboPharma";
            this.cboPharma.Size = new System.Drawing.Size(359, 26);
            this.cboPharma.Sorted = true;
            this.cboPharma.TabIndex = 1;
            this.cboPharma.DropDown += new System.EventHandler(this.cboPharma_DropDown);
            this.cboPharma.SelectedIndexChanged += new System.EventHandler(this.cboPharma_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 18);
            this.label3.TabIndex = 762;
            this.label3.Text = "Nouvelle pharmacie:";
            // 
            // txtPharmacie
            // 
            this.txtPharmacie.Location = new System.Drawing.Point(18, 118);
            this.txtPharmacie.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtPharmacie.MaxLength = 30;
            this.txtPharmacie.Name = "txtPharmacie";
            this.txtPharmacie.Size = new System.Drawing.Size(359, 24);
            this.txtPharmacie.TabIndex = 761;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.btnValider.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnValider.Enabled = false;
            this.btnValider.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnValider.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValider.Location = new System.Drawing.Point(297, 152);
            this.btnValider.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(80, 27);
            this.btnValider.TabIndex = 764;
            this.btnValider.Text = "Créer";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // StockPharmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(392, 193);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.txtPharmacie);
            this.Controls.Add(this.cboPharma);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 240);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(410, 240);
            this.Name = "StockPharmacie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SSM - Stock Pharmacie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox cboPharma;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPharmacie;
        public System.Windows.Forms.Button btnValider;
    }
}