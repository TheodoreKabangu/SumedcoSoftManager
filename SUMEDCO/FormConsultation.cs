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
            fermeture_succes = false;
            this.Hide();
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "recherche");
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                idconsultation = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
                idpatient = cm.TrouverId("patient", dgvPatient.CurrentRow.Cells[1].Value.ToString());
                btnDossier.Enabled = true;
                btnConsultation.Enabled = true;
                btnHospitaliser.Enabled = true;
                btnDeces.Enabled = true;
            }
        }

        private void FormConsultation_Shown(object sender, EventArgs e)
        {
            cm.Afficher(this, "");
        }

        private void btnDossier_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void btnConsultation_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "patient");
            btnConsultation.Enabled = false;
        }

        private void btnHospitaliser_Click(object sender, EventArgs e)
        {
            btnHospitaliser.Enabled = false;
        }

        private void btnDeces_Click(object sender, EventArgs e)
        {
            btnDeces.Enabled = false;
        }

    }
}
