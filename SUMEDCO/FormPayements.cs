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
    public partial class FormPayements : Form
    {
        public FormPayements()
        {
            InitializeComponent();
            for (int i = 0; i < dgvPayement.ColumnCount; i++)
            {
                dgvPayement.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public string poste, motif = "", statut_examen = "";
        public int idutilisateur = 0, idcommande = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherPayement(this);
        }

        private void cboMonnaie_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.AfficherPayement(this);
        }

        private void dgvPayement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (annuler_recette)
            {
                if (dgvPayement.RowCount != 0 && dgvPayement.CurrentRow.Cells[6].Value.ToString() == "" && !dgvPayement.CurrentRow.Cells[1].Value.ToString().StartsWith("Total"))
                    btnAnnuler.Enabled = true;
                else
                    btnAnnuler.Enabled = false;
            }
        }
        public bool fermeture_succes, annuler_recette;
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            if (cboAnnulation.Text == "")
                cboAnnulation.Enabled = true;
            else
            {
                cc.AnnulerPayement(this);
                if(annuler_recette)
                {
                    fermeture_succes = true;
                    this.Hide();
                }
            }
        }

        private void cboAnnulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
