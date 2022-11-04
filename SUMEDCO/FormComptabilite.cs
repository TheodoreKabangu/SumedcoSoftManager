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
        public int taux, id = 0, 
            idoperation = 0,
            idtypejournal = 0;
        public string numcompteJournal = "",
            numcompteAchat="",
            numcompteVariation = "",
            numcompte = "",
            intituleCompte="",
            classe = "";
        public double montantdebit = 0;
        public bool operation_plurielle;
        private void FormComptabilite_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
                txtLibelle.Select();
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                lblTaux.Text = cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString() + " CDF";
                txtLibelle.Select();
            }
            taux = int.Parse(lblTaux.Text.Substring(0, lblTaux.Text.IndexOf(" ")));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             * code du changement d'item dans cboOperation supprimé
             *             //if (cboOperation.Text == "Entrée")
            {
                txtDebit.Text = numcompteJournal;
                txtDebit.Enabled = false;
                txtCredit.Text = "";
                txtCredit.Enabled = true;
                txtCredit.Select();
            }
            else
            {
                txtCredit.Text = numcompteJournal;
                txtCredit.Enabled = false;
                txtDebit.Text = "";
                txtDebit.Enabled = true;
                txtDebit.Select();
            }
             */
            
            //cboMonnaie.Enabled = false;
            txtMontant.Focus();
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
        private void txtNumPiece_Enter(object sender, EventArgs e)
        {
            if(txtLibelle.Text=="")
            {
                MessageBox.Show("Aucun libellé n'est fourni pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Select();
            }
        }

        private void cboTypeJournal_Enter(object sender, EventArgs e)
        {
            if (txtNumPiece.Text == "")
            {
                MessageBox.Show("Aucun numéro de pièce n'est fourni pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Select();
            }
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (cboTypeJournal.Text == "")
            {
                MessageBox.Show("Aucun type de journal n'est choisi pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Select();
            }
        }

        private void txtMotifCompte_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Le montant n'est fourni pour cette opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Select();
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
            if(dgvEcriture.RowCount != 0)
                dgvEcriture.Rows.RemoveAt(dgvEcriture.CurrentRow.Index);
        }

        private void btnRetirerTout_Click(object sender, EventArgs e)
        {
            btnRetirerTout.Enabled = false;
            btnRetirer.Enabled = false;
            dgvEcriture.Rows.Clear();
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            txtLibelle.Select();
        }


        private void listCompteExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listCompteExp2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //numcompte = cc.TrouverId("numcompte", listCompteExp2.Text).ToString();
            //if (bilan_actif)
            //    txtCredit.Text = numcompteExp;
            //else
            //    txtCompteExp2.Text = numcompteExp;
            //listCompteExp2.Visible = false;
        }
        bool debit_actif;
        private void txtDebit_TextChanged(object sender, EventArgs e)
        {
            debit_actif= true;
            cc.ChargerCompte(txtDebit, listCompte);
        }

        private void txtCredit_TextChanged(object sender, EventArgs e)
        {
            debit_actif = false;
            cc.ChargerCompte(txtCredit, listCompte);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cc.ValiderEcriture(this);
        }
        private void txtDebit_Enter(object sender, EventArgs e)
        {
            debit_actif = true;
        }

        private void txtCredit_Enter(object sender, EventArgs e)
        {
            debit_actif = true;
        }

        private void txtCompteExp1_Enter(object sender, EventArgs e)
        {
            debit_actif = false;
        }

        private void txtCompteExp2_Enter(object sender, EventArgs e)
        {
            debit_actif = false;
        }

        private void listCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            intituleCompte = listCompte.Text;
            intituleCompte = intituleCompte.Replace("'", " ");
            numcompte = cc.TrouverId("numcompte", listCompte.Text).ToString();
            if (debit_actif)
                txtDebit.Text = numcompte;
            else
                txtCredit.Text = numcompte;
            if (numcompte.StartsWith("31"))
            {
                numcompteAchat = cc.TrouverId("numcompteAchat", intituleCompte).ToString();
                numcompteVariation = cc.TrouverId("numcompteVariation", intituleCompte).ToString();
            }
            listCompte.Visible = false;
        }
    }
}
