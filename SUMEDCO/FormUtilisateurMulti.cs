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
    public partial class FormUtilisateurMulti : Form
    {
        public FormUtilisateurMulti()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int idutilisateur;
        public string poste;
        public bool fermeture_succes;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.EnregistrerMulti(this);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if(dgvAgenda.RowCount != 0)
            {
                if (dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[1].Value == "" ||
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[1].Value == "NULL" ||
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[2].Value == "" ||
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[2].Value == "NULL")
                    MessageBox.Show("Renseignez toutes les valeurs pour la derniere ligne", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    dgvAgenda.Rows.Add();
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[0].Value = dgvAgenda.RowCount;
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[1].Value = "NULL";
                    dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[2].Value = "NULL";
                }
            }
            else
            {
                dgvAgenda.Rows.Add();
                dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[0].Value = dgvAgenda.RowCount;
                dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[1].Value = "NULL";
                dgvAgenda.Rows[dgvAgenda.RowCount - 1].Cells[2].Value = "NULL";
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvAgenda.RowCount != 0)
            {
                dgvAgenda.Rows.RemoveAt(dgvAgenda.CurrentRow.Index);
                cm.RemplirNumLigne(dgvAgenda, 0);
            }
            btnRetirer.Enabled = false;
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAgenda.RowCount != 0)
            {
                btnRetirer.Enabled = true;
            }
        }

    }
}
