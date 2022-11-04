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
    public partial class FormConsultation : Form
    {
        public FormConsultation()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public bool fermeture_succes;
        public string poste;
        public int idmedecin = 0, idconsultation = 0, idpatient = 0;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.Afficher(this);
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                idconsultation = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
                idpatient = int.Parse(dgvPatient.CurrentRow.Cells[3].Value.ToString());
            }
        }

        private void FormConsultation_Shown(object sender, EventArgs e)
        {
            if (btnQuitter.Visible)
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                {
                    if (item.Name == "itemResultatExamen" || item.Name == "itemPrescrire")
                        item.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripItem item in contextMenuStrip1.Items)
                {
                    if (item.Name != "itemResultatExamen" && item.Name != "itemPrescrire")
                        item.Enabled = false;
                }
            }
        }

        private void itemResultatExamen_Click(object sender, EventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                fermeture_succes = true;
                this.Hide();
            }
            else MessageBox.Show("Aucune ligne n'a été sélectionnée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void itemPrescrire_Click(object sender, EventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                fermeture_succes = true;
                this.Hide();
            }
            else MessageBox.Show("Aucune ligne n'a été sélectionnée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void itemdossierMedical_Click(object sender, EventArgs e)
        {
            cm.DetailsConsultation(this, new FormConsultationDossier());
        }

    }
}
