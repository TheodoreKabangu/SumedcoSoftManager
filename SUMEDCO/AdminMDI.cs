using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUMEDCO
{
    public partial class AdminMDI : Form
    {
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public string utilisateur = "";
        public AdminMDI()
        {
            InitializeComponent();
            cc.ActualiserDesign(pnlSousMenu);
        }
        public Form activeForm = null;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMiseAJour_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new Admin());
            if (btnMiseAJour.BackColor != Color.LightSlateGray)
            {
                btnMiseAJour.BackColor = Color.LightSlateGray;
                btnRapportStat.BackColor = Color.FromArgb(180, 200, 255);
                btnRapports.BackColor = Color.FromArgb(180, 200, 255);
                btnChat.BackColor = Color.FromArgb(180, 200, 255);
            }
            else
                btnMiseAJour.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            if (btnRapports.BackColor != Color.LightSlateGray)
            {
                btnRapports.BackColor = Color.LightSlateGray;
                btnRapportStat.BackColor = Color.FromArgb(180, 200, 255);
                btnMiseAJour.BackColor = Color.FromArgb(180, 200, 255);
                btnChat.BackColor = Color.FromArgb(180, 200, 255);
            }
            else
                btnRapports.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            cc.SousMenu(pnlSousMenu);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new StockInventaire());           
        }

        private void btnMaladeMedecin_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new AdminCasMedecin());            
        }

        private void btnRecetteDepense_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new ComptaRecetteDepense());
        }
        private void MFormAdmin_Shown(object sender, EventArgs e)
        {
            if (utilisateur == "admin")
            {
                btnRapports.Enabled = false;
                btnRapportStat.Enabled = false;
            }
            else if (utilisateur == "Numéro 1")
                btnMiseAJour.Enabled = false;
            else
            {
                btnMaladeMedecin.Enabled = false;
                btnRecetteDepense.Enabled = false;
            }
        }

        private void btnRapportStat_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new AdminRapportCas());
            if (btnRapportStat.BackColor != Color.LightSlateGray)
            {
                btnRapportStat.BackColor = Color.LightSlateGray; 
                btnRapports.BackColor = Color.FromArgb(180, 200, 255);
                btnChat.BackColor = Color.FromArgb(180, 200, 255);
                btnMiseAJour.BackColor = Color.FromArgb(180, 200, 255);
            }
            else
				btnRapportStat.BackColor = Color.FromArgb(180, 200, 255);
        }
        private void btnChat_Click(object sender, EventArgs e)
        {
            //if (btnChat.BackColor != Color.LightSlateGray)
            //{
            //    btnChat.BackColor = Color.LightSlateGray;
            //    btnRapports.BackColor = Color.FromArgb(180, 200, 255);
            //    btnRapportStat.BackColor = Color.FromArgb(180, 200, 255);
            //    btnMiseAJour.BackColor = Color.FromArgb(180, 200, 255);
            //}
            //else
            //    btnChat.BackColor = Color.FromArgb(180, 200, 255);
        }
    }
}
