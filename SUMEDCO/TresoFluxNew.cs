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
    public partial class TresoFluxNew : Form
    {
        ClasseElements ce = new ClasseElements();
        public TresoFluxNew()
        {
            InitializeComponent();
            ce.FigerColonne(dgvEcriture);
        }

        public int idexercice, idflux;
        public string affectation, poste = "",
            operation= "entrée/sortie";
        ClassCompta cc = new ClassCompta();
        TresorerieClasse tc = new TresorerieClasse();
        public double montantdebit = 0, taux = 0;
        private void btnDate_Click(object sender, EventArgs e)
        {
            taux = cc.ChangerDate(new DateTaux(), this, lblDateOperation, lblTaux);
        }

        private void TresoFluxNew_Shown(object sender, EventArgs e)
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
            if (affectation == "FFL") chbCatRecette.Enabled = false;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (dgvEcriture.RowCount == 0)
            {
                dgvEcriture.Rows.Add();
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[0].Value = txtNumPiece.Text;
                //La trésorerie est le beneficiaire de toute entrée
                if (operation == "entrée")
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "Trésorerie";
                else
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = 0;
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = "CDF";
                dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = "";
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
                    if (operation == "entrée")
                        dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = "Trésorerie";
                    else
                        dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[1].Value = ""; 
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[2].Value = 0;
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[3].Value = "CDF";
                    dgvEcriture.Rows[dgvEcriture.RowCount - 1].Cells[4].Value = "";
                }
                else MessageBox.Show("Rassurez-vous que la dernière écriture contient toutes les valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvEcriture_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEcriture.CurrentCell.ColumnIndex == 2)
                ce.TestMontantDGV(dgvEcriture, true);
        }

        private void dgvEcriture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvEcriture.RowCount != 0 && operation != "modifier")
            {
                btnRetirer.Enabled = true;
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            tc.AjouterFlux(this);
        }

        private void btnMonnaie_Click(object sender, EventArgs e)
        {
            if (dgvEcriture.RowCount != 0)
            {
                dgvEcriture.CurrentRow.Cells[2].Value = Convert.ToDouble(dgvEcriture.CurrentRow.Cells[2].Value) / taux;
                dgvEcriture.CurrentRow.Cells[3].Value = "USD";
            }
            else MessageBox.Show("Aucune ligne trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvEcriture.RowCount != 0)
                dgvEcriture.Rows.RemoveAt(dgvEcriture.CurrentRow.Index);
            btnRetirer.Enabled = false;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            txtNumPiece.Clear();
            dgvEcriture.Rows.Clear();
        }
        public bool modifier_succes;
        private void btnModifier_Click(object sender, EventArgs e)
        {
            modifier_succes = true;
            this.Hide();
        }

        private void chbCatRecette_Click(object sender, EventArgs e)
        {
            if (chbCatRecette.Checked)
                tc.CategoriesRecettes(this);
            else
            {
                dgvEcriture.Rows.Clear();
                btnAjouter.Enabled = true;
            }
        }
    }
}
