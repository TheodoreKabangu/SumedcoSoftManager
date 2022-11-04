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
    public partial class MFormPharmacie : Form
    {
        public MFormPharmacie()
        {
            InitializeComponent();
            cc.ActualiserDesign(pnlSousMenu);
        }
        public Form activeForm = null;
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        private void btnEntreeSortie_Click(object sender, EventArgs e)
        {
            cc.AfficherSousMenu(pnlSousMenu);
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVente_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormBonRecette());
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockPharma());
            cc.CacherSousMenu(pnlSousMenu);
        }

        private void btnEncaisser_Click(object sender, EventArgs e)
        {
            cs.Encaisser(this, new FormBonRecette());
        }

    }
}
