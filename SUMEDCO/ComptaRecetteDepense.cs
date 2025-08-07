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
    public partial class ComptaRecetteDepense : Form
    {
        public ComptaRecetteDepense()
        {
            InitializeComponent();
            for (int i = 0; i < dgvRapport.ColumnCount; i++)
            {
                dgvRapport.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public double taux = 0;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            //cc.AfficherRapportGlobal(this);
        }

        private void FormComptaRecetteDepense_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                taux = cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
        }

        private void btnAjouteValeur_Click(object sender, EventArgs e)
        {
            if (dgvRapport.RowCount != 0 && cboMonnaie.Text != "")
            {
                if (txtMontant1.Text == "" && txtMontant2.Text == "")
                    MessageBox.Show("Aucune valeur fournie pour la subvention ni le solde antérieur", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(txtMontant1.Text != "" && txtMontant2.Text != "")
                {
                    if (cboMonnaie.Text == "CDF")
                    {
                        dgvRapport.Rows[0].Cells[2].Value = Convert.ToDouble(txtMontant1.Text);
                        dgvRapport.Rows[1].Cells[2].Value = Convert.ToDouble(txtMontant2.Text);
                    }
                    else
                    {
                        dgvRapport.Rows[0].Cells[3].Value = Convert.ToDouble(txtMontant1.Text);
                        dgvRapport.Rows[1].Cells[3].Value = Convert.ToDouble(txtMontant2.Text);
                    }
                }
                else if (txtMontant1.Text != "" && txtMontant2.Text == "")
                {
                    if (cboMonnaie.Text == "CDF")
                    {
                        dgvRapport.Rows[0].Cells[2].Value = Convert.ToDouble(txtMontant1.Text);
                    }
                    else
                    {
                        dgvRapport.Rows[0].Cells[3].Value = Convert.ToDouble(txtMontant1.Text);
                    }
                }
                else if (txtMontant1.Text == "" && txtMontant2.Text != "")
                {
                    if (cboMonnaie.Text == "CDF")
                    {
                        dgvRapport.Rows[1].Cells[2].Value = Convert.ToDouble(txtMontant2.Text);
                    }
                    else
                    {
                        dgvRapport.Rows[1].Cells[3].Value = Convert.ToDouble(txtMontant2.Text);
                    }
                }

                //Recalculer les totaux
                for (int i = 0; i < 3; i++)
                {
                    dgvRapport.Rows.RemoveAt(dgvRapport.Rows[dgvRapport.RowCount - 1].Index);
                }
                cc.CalculerTotauxRapportGlobal(this);
            }
            else
                MessageBox.Show("Le rapport est encore vide et/ou aucune monnaie n'est sélectionnée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void txtMontant1_Leave(object sender, EventArgs e)
        {
            cc.TestMontant(txtMontant1);
        }

        private void txtMontant2_Leave(object sender, EventArgs e)
        {
            cc.TestMontant(txtMontant2);
        }
    }
}
