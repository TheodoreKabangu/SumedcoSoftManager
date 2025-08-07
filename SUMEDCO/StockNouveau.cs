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
    public partial class StockNouveau : Form
    {
        public StockNouveau()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idstock = 0,
            idstockpharma=0,
            idproduit = 0,
            idcondition = 0,
            idcat = 0;

        public string poste = "";
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cs.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.ModifierProduit(this);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idstock = int.Parse(dgvStock.CurrentRow.Cells[0].Value.ToString());
            btnModifierStock.Enabled = true;
            btnSupprimerStock.Enabled = true;
            btnModifier.Enabled = false;
            btnSupprimer.Enabled = false;
            btnAjoutStock.Enabled = false;
            btnEnregistrer.Enabled = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.SupprimerProduit(this);
        }
        ClasseElements ce = new ClasseElements();
        private void txtCMM_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtCMM);
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            idcat = cs.TrouverId("categorie", cboCategorie.Text);
        }

        private void cboCategorie_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("categorie", cboCategorie, 0);
        }

        private void FormStockNouveau_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (txtRecherche.Text != "")
                cs.ChargerProduit(this, "recherche");
            else
                cs.ChargerProduit(this, "");
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProduit.RowCount != 0)
            {
                idproduit = int.Parse(dgvProduit.CurrentRow.Cells[0].Value.ToString());
                cs.ChargerStock(this);
                btnModifierStock.Enabled = false;
                btnSupprimerStock.Enabled = false;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAjoutStock.Enabled = true;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            btnPlus.Enabled = false;
            cs.AjouterStock(this);
        }

        private void btnModifierStock_Click(object sender, EventArgs e)
        {
            cs.ModifierStock(this);
        }

        private void btnAjoutStock_Click(object sender, EventArgs e)
        {
            btnAjoutStock.Enabled = false;
            txtProduit.Text = dgvProduit.CurrentRow.Cells[1].Value.ToString();
            txtProduit.Enabled = false;
            cboCategorie.Enabled = false;
            btnPlus.Enabled = true;
            btnEnregistrer.Enabled = false;
            cboForme.Select();
        }

        private void btnSupprimerStock_Click(object sender, EventArgs e)
        {
            cs.SupprimerStock(this);
        }


    }
}
