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
    public partial class ComptaEcriture : Form
    {
        ClasseElements ce = new ClasseElements();
        public ComptaEcriture()
        {
            InitializeComponent();
            ce.FigerColonne(dgvEcriture);
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public string type_comptabilite="";
        public int id = 0,
            idoperation = 0,
            idtypejournal = 0,
            idexercice = 0;
        public string numcompteJournal = "",
            numcompteAchat = "",
            numcompteVariation = "",
            numcompte = "",
            intituleCompte = "",
            classe = "";
        public double montantdebit = 0, taux = 0;
        private void btnDebit_Click(object sender, EventArgs e)
        {
            if(dgvEcriture.RowCount==0)
            {
                dgvEcriture.Rows.Add();
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value = txtNumPiece.Text;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = "";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].ReadOnly = true;
            }
            else
            {
                if (dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value != "")
                {
                    dgvEcriture.Rows.Add();
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value = txtNumPiece.Text;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = "";
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].ReadOnly = true;
                }
                else MessageBox.Show("Rassurez-vous que la dernière écriture contient toutes les valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void ComptaEcriture_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
            }
            else
            {
                lblDateOperation.Text = DateTime.Now.ToShortDateString();
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
                lblTaux.Text = taux + " CDF";
            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            taux = cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
        }

        private void cboTypeJournal_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("typejournal", cboTypeJournal, 0);
        }

        private void cboTypeJournal_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypejournal = cc.TrouverId("typejournal", cboTypeJournal.Text);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            txtNumPiece.Clear();
            dgvEcriture.Rows.Clear();
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvEcriture.RowCount != 0)
                dgvEcriture.Rows.RemoveAt(dgvEcriture.CurrentRow.Index);
            btnRetirer.Enabled = false;
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            if(dgvEcriture.RowCount == 0)
            {
                dgvEcriture.Rows.Add();
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value = txtNumPiece.Text;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = "";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].ReadOnly = true;
            }
            else
            {
                if (dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value != "" &&
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value != "")
                {
                    dgvEcriture.Rows.Add();
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value = txtNumPiece.Text;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = "";
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].ReadOnly = true;
                }
                else MessageBox.Show("Rassurez-vous que la dernière écriture contient toutes les valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEcriture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.RowCount != 0) btnRetirer.Enabled = true;
        }
        ComptaComptes c;
        private void dgvEcriture_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.CurrentCell.ColumnIndex == 1)
            {
                c = new ComptaComptes();
                c.btnCompte.Enabled = false;
                c.btnImprimer.Enabled = false;
                c.btnQuitter.Visible = false;
                c.btnValider.Enabled = true;
                c.ShowDialog();
                dgvEcriture.CurrentRow.Cells[1].Value = c.numcompte;
                c.Close();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnMonnaie_Click(object sender, EventArgs e)
        {
            if (dgvEcriture.RowCount != 0)
            {
                dgvEcriture.CurrentRow.Cells[3].Value = Convert.ToDouble(dgvEcriture.CurrentRow.Cells[3].Value) * taux;
                dgvEcriture.CurrentRow.Cells[4].Value = Convert.ToDouble(dgvEcriture.CurrentRow.Cells[4].Value) * taux;
            }
            else MessageBox.Show("Aucune ligne trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvEcriture_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.CurrentCell.ColumnIndex == 3 || dgvEcriture.CurrentCell.ColumnIndex == 4)
                ce.TestMontantDGV(dgvEcriture, false);
        }
    }
}
