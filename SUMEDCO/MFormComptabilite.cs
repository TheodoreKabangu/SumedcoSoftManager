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
    public partial class MFormComptabilite : Form
    {
        public MFormComptabilite()
        {
            InitializeComponent();
            cc.ActualiserDesign2(pnlSousMenu, pnlSousMenu2);
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public Form activeForm = null;
        public int idutilisateur;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();          
        }

        private void btnIntervention_Click(object sender, EventArgs e)
        {
            cc.CacherSousMenu(pnlSousMenu);
            cc.AfficherSousMenu(pnlSousMenu2);
        }

        private void btnOperations_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaOperation());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnBilan_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBilan());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnResultat_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaResultat());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnFlux_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaTableauFlux());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }
        private void btnCompte_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormCompte());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnEcriture_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptabilite());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnAppro_Click(object sender, EventArgs e)
        {
            cc.CacherSousMenu(pnlSousMenu2);
            cc.AfficherSousMenu(pnlSousMenu);
        }

        private void btnStockPharma_Click(object sender, EventArgs e)
        {
            cs.HistoriqueApproStockPharma(this, new FormApproStockPharma());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnAutreStock_Click(object sender, EventArgs e)
        {
            cs.HistoriqueApproStockAutre(this, new FormApproStockAutre());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }

        private void btnBalance_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBalance());
            cc.CacherSousMenu(pnlSousMenu);
            cc.CacherSousMenu(pnlSousMenu2);
        }
    }
}
