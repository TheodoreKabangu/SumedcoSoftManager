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
    public partial class FormProduitAutreStock : Form
    {
        public FormProduitAutreStock()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int idproduit = 0;
        public string numcompte;
        private void cboCompte_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("stock", cboCompte, 0);
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cs.Recuperer(this);
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(this);
            if (dgvProduit.RowCount != 0)
            {
                for (int i = 0; i < dgvProduit.RowCount; i++)
                {
                    dgvProduit.Rows[i].Cells[2].Value = cc.TrouverNom("compte", int.Parse(dgvProduit.Rows[i].Cells[1].Value.ToString()));
                }
            }
        }

        private void cboCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompte = cc.TrouverId("numcompte", cboCompte.Text).ToString();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.Modifier(this);
            if (dgvProduit.RowCount != 0)
            {
                for (int i = 0; i < dgvProduit.RowCount; i++)
                {
                    dgvProduit.Rows[i].Cells[2].Value = cc.TrouverNom("compte", int.Parse(dgvProduit.Rows[i].Cells[1].Value.ToString()));
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.Supprimer(this);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            cs.Afficher(this, "recherche");
            if (dgvProduit.RowCount !=0)
            {
                for (int i = 0; i < dgvProduit.RowCount; i++)
                {
                    dgvProduit.Rows[i].Cells[2].Value = cc.TrouverNom("compte", int.Parse(dgvProduit.Rows[i].Cells[1].Value.ToString()));
                }
            }
        }

        private void txtCMM_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtCMM);
        }
    }
}
