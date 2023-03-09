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
    public partial class FormProduitPharma : Form
    {
        public FormProduitPharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
		public int idproduit = 0, idcat= 0;

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(new FormStockNouveau());
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cs.Recuperer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.ModifierProduit(new FormStockNouveau());
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.SupprimerProduit(new FormStockNouveau());
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            cs.Afficher(this,"recherche");
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            idcat = cs.TrouverId("categorie", cboCategorie.Text);
        }

    }
}
