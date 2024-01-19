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
    public partial class FormReceptionRapport : Form
    {
        public FormReceptionRapport()
        {
            InitializeComponent();
            for (int i = 0; i < dgvRecette.ColumnCount; i++)
            {
                dgvRecette.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int idproduit;
        public string poste;
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
                btnSupprimer.Enabled = true;
        }
        private void btnEditerRequisition_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherRapportRecette(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvRecette.CurrentRow.Index < dgvRecette.RowCount-1) 
                cc.SupprimerRecette(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.AfficherRapportRecette(this);
        }

        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.AfficherRapportRecette(this);
        }
    }
}
