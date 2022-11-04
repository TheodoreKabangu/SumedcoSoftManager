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
    public partial class FormProduitPharmaStock : Form
    {
        public FormProduitPharmaStock()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int idstock = 0,
            idstockpharma=0,
            idproduit = 0,
            idcondition = 0;
        private void btnProduit_Click(object sender, EventArgs e)
        {
            new FormProduitPharma().Show();
        }
        private void cboProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            idproduit = cs.TrouverId("produit", cboProduit.Text);
        }
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
            cs.Modifier(this);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cs.Recuperer(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.Supprimer(this);
        }

        private void txtCMM_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtCMM);
        }

        private void cboProduit_DropDown(object sender, EventArgs e)
        {
            cs.ChargerCombo(cboProduit, "produit", 0);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cs.Afficher(this, "recherche");
        }

    }
}
