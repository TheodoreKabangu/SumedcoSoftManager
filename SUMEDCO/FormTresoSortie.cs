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
    public partial class FormTresoSortie : Form
    {
        public FormTresoSortie()
        {
            InitializeComponent();            
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int numbon = 0,
            idabonne =0,
            idcatdepense = 0,
            iddepense = 0,
            idoperation=0,
            id=0;
        public bool ajoutvalide;
        public string numcompte = "", 
            caisse="";
        public double taux= 0, 
            soldeCaisse = 0,
            montantdecaisse = 0;
        private void FormDepense_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(this, new DateTaux());
                txtNumRequisition.Focus();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
                lblCaisseUSD.Text = string.Format("{0} USD", cc.MontantCompte("571202"));
                lblCaisseCDF.Text = string.Format("{0} CDF", cc.MontantCompte("571102"));
                txtNumRequisition.Focus();
            }
        }
        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtMontant.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre != "")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else if (cboMonnaie.Text == "USD")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
            btnCompte.Select();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            
        }
        string montantLettre = "";
        private void txtMontant_Leave(object sender, EventArgs e)
        {
            if (txtMontant.Text != "")
            {
                montantLettre = cc.TestMontant(txtMontant);
                if (montantLettre != "")
                {
                    if (cboMonnaie.Text == "CDF")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " francs congolais";
                    else if (cboMonnaie.Text == "USD")
                        txtMontantLettre.Text = montantLettre.Substring(0, 1).ToUpper() + montantLettre.Substring(1) + " dollars américains";
                }
            }
        }
        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(this, new DateTaux());
            txtNumRequisition.Focus();
        }
        private void cboMonnaie_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Aucun montant n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumRequisition.Focus();
            }
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (txtBeneficiaire.Text == "")
            {
                MessageBox.Show("Aucun bénficiaire n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeneficiaire.Focus();
            }
        }

        private void txtMotif_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtBeneficiaire_Enter(object sender, EventArgs e)
        {
            if (cboCaisseDepense.Text == "")
            {
                MessageBox.Show("Aucun compte de trésorerie n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumRequisition.Focus();
            }
        }

        private void cboCaisseDepense_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCaisseDepense.Text == "CDF")
                numcompte = "571102";
            else
                numcompte = "571202";
            caisse = cc.TrouverNom("compte", Convert.ToInt32(numcompte));
            soldeCaisse = cc.MontantCompte(numcompte);
            cboCaisseDepense.Enabled = false;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cc.Valider(this);
        }

        private void btnCompte_Click(object sender, EventArgs e)
        {
            txtCompte.Text = cc.CompteDepense(new FormComptaPlan(), "trésorerie");
        }

        private void cboCaisseDepense_Enter(object sender, EventArgs e)
        {
            if (txtNumRequisition.Text == "")
            {
                MessageBox.Show("Aucun numéro de réquisition n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumRequisition.Focus();
            }
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void dgvEcriture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.RowCount != 0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            btnRetirerTout.Enabled = false;
            if (dgvEcriture.CurrentRow.Index < dgvEcriture.RowCount-1)
            {
                if (dgvEcriture.RowCount > 2)
                {
                    dgvEcriture.Rows.RemoveAt(dgvEcriture.CurrentRow.Index);
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    for (int i = 0; i < dgvEcriture.RowCount - 1; i++)
                    {
                        if (dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value == "")
                            dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = dgvEcriture.Rows[i].Cells[1].Value.ToString();
                        else
                            dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}", dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value.ToString(), dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    }
                    cc.ContrePartie(dgvEcriture, 2, 3);
                }
                else dgvEcriture.Rows.Clear();
            }
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            btnRetirerTout.Enabled = false;
            dgvEcriture.Rows.Clear();
        }

    }
}
