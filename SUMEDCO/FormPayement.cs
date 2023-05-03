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
    public partial class FormPayement : Form
    {
        public FormPayement()
        {
            InitializeComponent();
            for (int i = 0; i < dgvCompte.ColumnCount; i++)
            {
                dgvCompte.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int idpayement,
            idpayeur,
            idrecette,
            idoperation;
        public string caisse = "", 
            numcompte="",
            numcompteDiffere = "",
            statut_recette= "", 
            categorie_recette ="",
            raison_retrait= "";
        public double taux, montant_recette;
        public bool fermeture_succes;
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (btnAjouter.Text == "Valider")
                this.Hide();
            else
                this.Close();
        }
        public bool ajout_valide;
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (txtMontant.Text != "" && cboMonnaie.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre != "")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
            if (btnAjouter.Text == "Valider")
            {
                if (cboAnnulation.Text != "")
                {
                    raison_retrait = lblDateOperation.Text + ", " + cboAnnulation.Text;
                    fermeture_succes = true;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Renseignez la raison du retrait de ce payement", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboAnnulation.Select();
                }
            }
            else
            {
                cc.PayerRecette(this);
                fermeture_succes = true;
                this.Hide();
            }
        }
        public string montantLettre = "";

        private void txtMontant_Leave(object sender, EventArgs e)
        {
            
        }

        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonnaie.Text == "CDF")
                numcompte = "571101";
            else
                numcompte = "571201";
            caisse = cc.TrouverNom("compte", Convert.ToInt32(numcompte));
            if (txtMontant.Text != "" && cboMonnaie.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre != "")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
        }

        private void cboMonnaie_Leave(object sender, EventArgs e)
        {
            
        }

        private void FormPayement_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
