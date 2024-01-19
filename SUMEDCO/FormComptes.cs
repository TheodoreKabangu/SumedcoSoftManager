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
    public partial class FormComptes : Form
    {
        public FormComptes()
        {
            InitializeComponent();
            for (int i = 0; i < dgvCompte.ColumnCount; i++)
            {
                dgvCompte.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCompte.RowCount > 0)
            {
                btnCompte.Enabled = true;
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
            }
        }
        FormCompte c;
        private void btnCompte_Click(object sender, EventArgs e)
        {
            c = new FormCompte();
            c.numcompte = dgvCompte.CurrentRow.Cells[0].Value.ToString();
            c.txtNumCompte.Text = dgvCompte.CurrentRow.Cells[0].Value.ToString();
            if (dgvCompte.CurrentRow.Cells[3].Value.ToString() == "U" || dgvCompte.CurrentRow.Cells[3].Value.ToString() == "UU")
            {
                c.txtRef.Text = dgvCompte.CurrentRow.Cells[2].Value.ToString();
            }
            c.ShowDialog();
            cc.Afficher(this);
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
            c = new FormCompte();
            c.numcompte = dgvCompte.CurrentRow.Cells[0].Value.ToString();
            c.txtNumCompte.Text = dgvCompte.CurrentRow.Cells[0].Value.ToString();
            c.txtLibelle.Text = dgvCompte.CurrentRow.Cells[1].Value.ToString();
            if (dgvCompte.CurrentRow.Cells[3].Value.ToString() == "U" || dgvCompte.CurrentRow.Cells[3].Value.ToString() == "UU")
            {
                c.txtRef.Text = dgvCompte.CurrentRow.Cells[2].Value.ToString();              
            }
            c.cboCategorie.Items.Clear();
            c.cboCategorie.Items.Add(dgvCompte.CurrentRow.Cells[3].Value.ToString());
            c.btnModifier.Enabled = true;
            c.btnEnregistrer.Enabled = false;
            c.btnAnnuler.Enabled = false;
            c.ShowDialog();
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

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void btnRecherche_Click_1(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }
    }
}
