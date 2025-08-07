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
    public partial class StockFicheStock : Form
    {
        ClasseElements ce = new ClasseElements();
        public StockFicheStock()
        {
            InitializeComponent();
            ce.FigerColonne(dgvProduit);
        }
        public string poste = "", motif= "";
        public int idstock = 0;
        ClassStock cs = new ClassStock();
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.EntreeSortieStock(this, motif);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cs.ImprimerFicheStock(this, new FormImpression());
        }
    }
}
