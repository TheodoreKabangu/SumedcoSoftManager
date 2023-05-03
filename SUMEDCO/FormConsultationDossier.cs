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
    public partial class FormConsultationDossier : Form
    {
        public FormConsultationDossier()
        {
            InitializeComponent();
            for (int i = 0; i < dgvPatient.ColumnCount; i++)
            {
                dgvPatient.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvDetail.ColumnCount; i++)
            {
                dgvDetail.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public int idconsultation = 0,
            idpatient = 0,
            idmedecin = 0, idprise;
        public string patient, medecin;
        ClassMalade cm = new ClassMalade();
        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDetail.Rows.Clear();
            switch (cboCategorie.Text)
            {
                case "signes vitaux": cm.SigneVitalConsultation(this); break;
                case "plainte": cm.RenseignementConsultation(this, "plainte"); break;
                case "historique": cm.RenseignementConsultation(this, "historique"); break;
                case "antécédent": cm.RenseignementConsultation(this, "antécédent"); break;
                case "complément": cm.RenseignementConsultation(this, "complément"); break;
                case "examen physique": cm.ExamenPhysiqueConsultation(this); break;
                case "prédiagnostic": cm.RenseignementConsultation(this, "prédiagnostic"); break;
                case "examen para": cm.PrescriptionService(this, "examen para"); break;
                case "diagnostic": cm.MaladieConsultation(this); break;
                case "prescription produit": cm.PrescriptionProduit(this); break;
                case "prescription service": cm.PrescriptionService(this, "autre"); break;
                case "autre prescription": cm.RenseignementConsultation(this, "autre"); break;
                case "rendez-vous": cm.AfficherRDVConsultation(idconsultation, new FormConsulterRendezVous()); break;
                case "tout": cm.DetailsConsultation(this); break;
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cm.ImprimerDossier(this, new FormImpression());
        }

        private void FormConsultationDossier_Shown(object sender, EventArgs e)
        {
            cm.RechercheConsultation(this, new FormConsultation());
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetail.RowCount != 0)
            {
                if (dgvDetail.CurrentRow.Cells[0].Value.ToString() != "")
                    dgvDetail.CurrentRow.DefaultCellStyle.SelectionBackColor = Color.Silver;
            }
        }
    }
}
