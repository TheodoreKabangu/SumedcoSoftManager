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
    public partial class FormComptabilite : Form
    {
        public FormComptabilite()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int id = 0, 
            idoperation = 0,
            idtypejournal = 0;
        public string numcompteJournal = "",
            numcompteAchat="",
            numcompteVariation = "",
            numcompte = "",
            intituleCompte="",
            classe = "";
        public double montantdebit = 0, taux=0;
        public bool operation_plurielle;
        private void FormComptabilite_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(this, new DateTaux());
                txtNumPiece.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                taux = double.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
                txtNumPiece.Select();
            }
        }
        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMotif.Focus();
        }

        private void cboTypeJournal_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("typejournal", cboTypeJournal, 0);
        }

        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypejournal = cc.TrouverId("typejournal", cboTypeJournal.Text);
        }

        private void txtMontant_Leave(object sender, EventArgs e)
        {
            cc.TestMontant(txtMontant);
        }

        private void btnNouveauJournal_Click(object sender, EventArgs e)
        {
            //Programmer les opérations sur ce form
            new FormComptaJournal().ShowDialog();
        }
        private void cboTypeJournal_Enter(object sender, EventArgs e)
        {
            if (txtNumPiece.Text == "")
            {
                MessageBox.Show("Aucun numéro de pièce n'est fourni pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumPiece.Focus();
            }
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (txtCompte2.Text == "")
            {
                MessageBox.Show("Fournissez d'abord le compte concerné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumPiece.Select();
            }
        }

        private void txtMotifCompte_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Le montant n'est fourni pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotif.Select();
            }
        }
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void dgvEcriture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.RowCount != 0)
            {
                btnRetirer.Enabled = true;
                btnRetirerTout.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            btnRetirerTout.Enabled = false;
            if (dgvEcriture.CurrentRow.Index < dgvEcriture.RowCount - 1)
            {
                if (dgvEcriture.RowCount > 2)
                {
                    dgvEcriture.Rows.RemoveAt(dgvEcriture.CurrentRow.Index);
                    if(double.Parse(dgvEcriture.Rows[dgvEcriture.RowCount-1].Cells[2].Value.ToString())==0)
                        cc.ContrePartie(dgvEcriture, 2, 3);
                    else
                        cc.ContrePartie(dgvEcriture, 3, 2);
                }
                else dgvEcriture.Rows.Clear();
            }
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
            dgvEcriture.Rows.Clear();
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(this, new DateTaux());
            txtNumPiece.Select();
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtMotif.Text == "")
            {
                MessageBox.Show("Aucun libellé n'est fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumPiece.Select();
            }
            else
                cc.ValiderEcriture(this);
        }
        private void cboDebitCredit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboDebitCredit.Enabled = false;
            btnCompte1.Select();
            lblCompte1.Text = cboDebitCredit.Text+" :";
            if (cboDebitCredit.Text == "Crédit")
                lblCompte2.Text = "Débit :";
            else
                lblCompte2.Text = "Crédit :";
        }

        private void btnCompte1_Click(object sender, EventArgs e)
        {
            txtCompte1.Text = cc.CompteDepense(new FormComptaPlan(), "comptable");
        }

        private void btnCompte2_Click(object sender, EventArgs e)
        {
            if (txtCompte1.Text == "")
            {
                MessageBox.Show("Fournissez d'abord le compte concerné ci-haut", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumPiece.Select();
            }
            else
                txtCompte2.Text = cc.CompteDepense(new FormComptaPlan(), "comptable");
        }

        private void cboMonnaie_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Aucun montant n'est fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumPiece.Select();
            }
        }
    }
}
