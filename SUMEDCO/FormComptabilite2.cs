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
    public partial class FormComptabilite2 : Form
    {
        public FormComptabilite2()
        {
            InitializeComponent();
        }
        public long idoperation = 0;
        ClassMetier cm = new ClassMetier();

        private void Comptabilite_Load(object sender, EventArgs e)
        {
            cboTypeJournal.Focus();
        }

        private void cboClasseDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cm.ChargerCboCompte(this);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cm.Annuler(this);
        }
        double montantdebit = 0, montantcredit = 0;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            montantdebit = 0; montantcredit = 0;
            for (int i = 0; i < dgvCompte.RowCount; i++)
            {
                montantdebit += double.Parse(dgvCompte.Rows[i].Cells[2].Value.ToString());
                montantcredit += double.Parse(dgvCompte.Rows[i].Cells[3].Value.ToString());
            }
            if (montantdebit == montantcredit)
            {
                idoperation = cm.NouveauID("operation");
                if (cm.Enregistrer(this))
                {
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cm.Annuler(this);
                }
            }
            else
                MessageBox.Show("Le débit et le crédit ne sont pas équilibrés", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnRetirer.Enabled = true;         
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvCompte.Rows.RemoveAt(dgvCompte.CurrentRow.Index);
        }
        string compte = "";
        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //journal achat et journal ventes à crédit quels comptes rattachés pour la contrepartie

            if (cboTypeJournal.Text.Contains("caisse") || cboTypeJournal.Text.Contains("banque"))
            {
                cboDebitCredit.Enabled = false;
                compte = cm.TrouverNumCompte(this).ToString();
                montantdebit = cm.MontantCompte(long.Parse(compte), "debit");

            }
            else
            {
                cboDebitCredit.Enabled = true;
            }
        }

        private void cboNumCompte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDebitCredit.Enabled)
            {
                if (cboDebitCredit.Text == "crédit")
                {
                    if (dgvCompte.RowCount == 0)
                        MessageBox.Show("Insérez d'abord le compte de débit et sa valeur", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        dgvCompte.Rows.Add();
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Crédit";
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = cboNumCompte.Text;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = 0;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = txtMontant.Text;
                        cboNumCompte.Items.RemoveAt(cboNumCompte.SelectedIndex);
                    }
                }
                else
                {
                    dgvCompte.Rows.Add();
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Débit";
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = cboNumCompte.Text;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = txtMontant.Text;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = 0;
                    cboNumCompte.Items.RemoveAt(cboNumCompte.SelectedIndex);
                }
            }
            else
            {
                if (compte == "5711" || compte == "5712")
                {
                    if (long.Parse(txtMontant.Text) > montantdebit)
                    {
                        MessageBox.Show("Le solde de la caisse ne peut être créditeur.\nSaisissez une valeur inférieure ou égale à "+montantdebit, "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvCompte.Rows.Add();
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Débit";
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = cboNumCompte.Text;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = txtMontant.Text;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = 0;
                        cboNumCompte.Items.RemoveAt(cboNumCompte.SelectedIndex);
                        dgvCompte.Rows.Add();
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Crédit";
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = 0;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = txtMontant.Text;
                        dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = compte;
                        //retranchement du montant ajouté
                        montantdebit -= double.Parse(txtMontant.Text); 
                    }
                }
                else
                {
                    dgvCompte.Rows.Add();
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Débit";
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = cboNumCompte.Text;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = txtMontant.Text;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = 0;
                    cboNumCompte.Items.RemoveAt(cboNumCompte.SelectedIndex);
                    dgvCompte.Rows.Add();
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "Crédit";
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = 0;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[3].Value = txtMontant.Text;
                    dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = compte;
                }
            }
            for (int i = 0; i < dgvCompte.RowCount; i++)
                dgvCompte.Rows[i].Selected = false;
        }

        private void txtLibelle_Enter(object sender, EventArgs e)
        {
            if (cboTypeJournal.Text == "")
            {
                MessageBox.Show("Veuillez d'abord sélectionner le type de journal", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypeJournal.Select();
            }
        }

        private void txtNumPiece_Enter(object sender, EventArgs e)
        {
            if (txtLibelle.Text == "")
            {
                MessageBox.Show("Veuillez d'abord saisir le libellé de l'opération", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLibelle.Focus();
            }
        }

        private void txtMontant_Enter(object sender, EventArgs e)
        {
            if (txtNumPiece.Text == "")
                if (MessageBox.Show("Numéro de la pièce absent! Voulez-vous continuer", "Valeur", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    txtNumPiece.Focus();
        }

        private void cboDebitCredit_Enter(object sender, EventArgs e)
        {
            if (txtMontant.Text == "")
            {
                MessageBox.Show("Veuillez d'abord saisir le montant", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontant.Focus();
            }
        }

        private void cboAfficheJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAfficheJournal.Text == "tout")
                cm.ChargerJournal(this);
        }

        private void dgvGrandLivre_Click(object sender, EventArgs e)
        {
            
        }

        private void linkAfficherActif_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < cboActif.Items.Count; i++)
            {
                dgvActifBilan.Rows.Add();
                dgvActifBilan.Rows[i].Cells[1].Value = cboActif.Items[i].ToString();
            }                
            dgvActifBilan.Rows[0].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvActifBilan.Rows[5].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvActifBilan.Rows[12].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvActifBilan.Rows[15].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvActifBilan.Rows[22].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvActifBilan.Rows[26].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvActifBilan.Rows[28].DefaultCellStyle.BackColor = Color.Goldenrod;
            for (int i = 0; i < cboActif.Items.Count; i++)
            {
                dgvActifBilan.Rows[i].Selected = false;
            }
        }

        private void linkAfficherPassif_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < cboPassif.Items.Count; i++)
            {
                dgvPassifBilan.Rows.Add();
                dgvPassifBilan.Rows[i].Cells[1].Value = cboPassif.Items[i].ToString();
            }
            dgvPassifBilan.Rows[10].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvPassifBilan.Rows[14].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvPassifBilan.Rows[15].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvPassifBilan.Rows[22].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvPassifBilan.Rows[25].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvPassifBilan.Rows[27].DefaultCellStyle.BackColor = Color.Goldenrod;
            for (int i = 0; i < cboPassif.Items.Count; i++)
            {
                dgvPassifBilan.Rows[i].Selected = false;
            }
        }
        DateTaux d = new DateTaux();
        private void Comptabilite_Shown(object sender, EventArgs e)
        {        
            d.ShowDialog();
            if (!d.fermeture_succes)
                this.Close();
            else
            {
                lblDateOperation.Text = d.dtpTaux.Text;
                lblTaux.Text = "Taux : "+cm.VerifierTaux(d.dtpTaux.Text, "valeur").ToString()+" CDF";
            }
        }

        private void linkResultat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < cboResultat.Items.Count; i++)
            {
                dgvResultat.Rows.Add();
                dgvResultat.Rows[i].Cells[1].Value = cboResultat.Items[i].ToString();
            }
            dgvResultat.Rows[3].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[7].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[21].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[15].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[23].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[26].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[32].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[33].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[38].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvResultat.Rows[41].DefaultCellStyle.BackColor = Color.Goldenrod;
            for (int i = 0; i < cboResultat.Items.Count; i++)
            {
                dgvResultat.Rows[i].Selected = false;
            }
        }

        private void linkFlux_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < cboFlux.Items.Count; i++)
            {
                dgvFlux.Rows.Add();
                dgvFlux.Rows[i].Cells[1].Value = cboFlux.Items[i].ToString();
            }
            dgvFlux.Rows[0].DefaultCellStyle.BackColor = Color.Goldenrod;
            dgvFlux.Rows[7].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvFlux.Rows[13].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvFlux.Rows[18].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvFlux.Rows[22].DefaultCellStyle.BackColor = Color.RosyBrown;
            dgvFlux.Rows[23].DefaultCellStyle.BackColor = Color.IndianRed;
            dgvFlux.Rows[25].DefaultCellStyle.BackColor = Color.Goldenrod;

            for (int i = 0; i < cboFlux.Items.Count; i++)
            {
                dgvFlux.Rows[i].Selected = false;
            }
        }

        private void btnRechercheCompte_Click(object sender, EventArgs e)
        {
            if (txtNumCompte.Text != "")
                cm.ChargerGrandLivre(this, "");
            else
            {
                MessageBox.Show("Numéro de compte manquant", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumCompte.Focus();
            }
        }
        long valeur = 0;
        private void txtNumCompte_TextChanged(object sender, EventArgs e)
        {
            txtNumCompte.Text = cm.TestEntier(txtNumCompte.Text, valeur);          
        }

        private void cboMotifGL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboMotifGL.Text.ToLower()=="tout")
                cm.ChargerGrandLivre(this, "tout");
        }

        private void cboBalance_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBalance.Text.ToLower() == "tout")
                cm.ChargerBalance(this);
        }

        private void cboDebitCredit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboAfficher_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
