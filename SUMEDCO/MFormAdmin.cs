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
    public partial class MFormAdmin : Form
    {
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public string utilisateur = "";
        public MFormAdmin()
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
            cs.AfficherSousForm(this, new FormAdmin());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnRapports_Click(object sender, EventArgs e)
        {
            cc.AfficherSousMenu(pnlSousMenu);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockPharma());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnMaladeMedecin_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormFrequentation());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnRecetteDepense_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormRecetteDepense());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnStock2_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockAutreProduit());
            cc.CacherSousMenu(pnlSousMenu);
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
                btnRapports.Enabled = false;
        }

        private void btnRapportStat_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormAdminStatService());
        }
    }
}
