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
    public partial class ComptaComptes : Form
    {
        public ComptaComptes()
        {
            InitializeComponent();
            for (int i = 0; i < dgvCompte.ColumnCount; i++)
            {
                dgvCompte.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public string type_comptabilite = "";
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnQuitter.Visible)
            {
                if (dgvCompte.RowCount > 0)
                {
                    btnModifier.Enabled = true;
                    btnSupprimer.Enabled = true;
                }
            }
            else
            {
                if (dgvCompte.RowCount > 0)
                {
                    btnValider.Enabled = true;
                }
            }           
        }
        private void btnCompte_Click(object sender, EventArgs e)
        {
            dgvCompte.Rows.Clear();
            dgvCompte.ReadOnly = false;
            dgvCompte.SelectionMode = DataGridViewSelectionMode.CellSelect;
            btnAjouter.Enabled = true;
            dgvCompte.Rows.Add();
            dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[0].Value = "";
            dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[1].Value = "";
            dgvCompte.Rows[dgvCompte.RowCount - 1].Cells[2].Value = "";

        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (btnModifier.Text == "Modifier")
            {
                numcompte = dgvCompte.CurrentRow.Cells[0].Value.ToString();
                libellecompte = dgvCompte.CurrentRow.Cells[1].Value.ToString();
                refcompte = dgvCompte.CurrentRow.Cells[2].Value.ToString();
                btnModifier.Text = "Confirmer";

                dgvCompte.Rows.Clear();
                dgvCompte.ReadOnly = false;
                dgvCompte.SelectionMode = DataGridViewSelectionMode.CellSelect;
                dgvCompte.Rows.Add();
                dgvCompte.Rows[0].Cells[0].Value = numcompte;
                dgvCompte.Rows[0].Cells[1].Value = libellecompte;
                dgvCompte.Rows[0].Cells[2].Value = refcompte;
                btnModifier.Enabled = true;

            }
            else
            {
                cc.Modifier(this);
            }
            cc.Afficher(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cc.Supprimer(this);
        }

        private void cboClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void btnRecherche_Click_1(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }
        public string numcompte, libellecompte, refcompte;
        private void btnValider_Click(object sender, EventArgs e)
        {
            btnValider.Enabled = false;
            if(dgvCompte.RowCount != 0)
                numcompte = dgvCompte.CurrentRow.Cells[0].Value.ToString();
            this.Hide();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
