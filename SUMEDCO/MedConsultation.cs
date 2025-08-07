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
    public partial class MedConsultation : Form
    {
        public MedConsultation()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public bool fermeture_succes;
        public string poste;
        public int idmedecin = 0, idconsultation = 0, idpatient = 0, iddossier= 0;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "recherche");
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {
                idconsultation = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
                idpatient = Convert.ToInt32(dgvPatient.CurrentRow.Cells[5].Value);
                btnDossier.Enabled = true;
                btnConsultation.Enabled = true;
                cm.FichiersConsultation(this);
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

        private void dgvDossier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDossier.RowCount != 0)
            {
                iddossier = Convert.ToInt32(dgvDossier.CurrentRow.Cells[0].Value);
                btnFiche.Enabled = true;
            }
        }

        private void btnFiche_Click(object sender, EventArgs e)
        {
            cm.OuvrirFicheManuscrite(this);
        }

    }
}
