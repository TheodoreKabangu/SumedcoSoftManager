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
    public partial class MFormStock : Form
    {
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public int idutilisateur;
        public MFormStock()
        {
            InitializeComponent();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockProduit());
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAlertes_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockAlerte());
        }

        private void btnHistoCommande_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormHistoCommande());
        }

        private void btnComPharma_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormApproCommande());
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockInventaire());
        }
    }
}
