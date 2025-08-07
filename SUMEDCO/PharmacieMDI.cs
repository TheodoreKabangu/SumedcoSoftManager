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
    public partial class PharmacieMDI : Form
    {
        public PharmacieMDI()
        {
            InitializeComponent();
        }
        public Form activeForm = null;
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        public int idutilisateur, idpharma;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnEncaisser_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new PharmacieVente());
        }

        private void btnStockPh_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new StockProduit());
        }

        private void btnCommande_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new StockHistoCommande());
        }
        private void btnUtilisation_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormUtilisation());
        }

        private void btnRapport_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new StockInventaire());
        }

        private void btnFacturePorduit_Click(object sender, EventArgs e)
        {
            rfc.FactureProduit(this, new PharmacieFacturation());
        }

    }
}
