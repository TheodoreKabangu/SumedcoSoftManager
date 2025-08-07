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
    public partial class ReceptionPatient : Form
    {
        ClasseElements dg = new ClasseElements();
        public ReceptionPatient()
        {
            InitializeComponent();
            dg.FigerColonne(dgv);
        }
        ClassMalade cm = new ClassMalade();
        ClasseExercice exer = new ClasseExercice();
        public int idpatient = 0,
        identreprise,
        idexercice;
        public string poste = "";
        public bool infirmier_autorise;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        ReceptionPatientNew p;
        private void btnNouveau_Click(object sender, EventArgs e)
        {
            p = new ReceptionPatientNew();
            p.statut = "nouveau";
            p.poste = poste;
            p.idexercice = exer.ExerciceEncours();
            p.ShowDialog();
            p.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Recuperer(this, new ReceptionPatientNew());
        }
        ClassCompta cc = new ClassCompta();
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }
        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.RowCount != 0)
            {
                idpatient = Convert.ToInt32(dgv.CurrentRow.Cells[0].Value);
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnAffecter.Enabled = true;
                btnService.Enabled = true;
                if (poste == "abonné")
                {
                    identreprise = cc.TrouverId("entreprise", dgv.CurrentRow.Cells[11].Value.ToString());
                }
            }
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            p = new ReceptionPatientNew();
            p.type_patient = dgv.CurrentRow.Cells[9].Value.ToString();
            p.idpatient = idpatient;
            p.cboTypePatient.Enabled = false;
            p.txtNom.Enabled = false;
            p.cboSexe.Enabled = false;
            p.txtAdresse.Enabled = false;
            p.txtMois.Enabled = false;
            p.txtAnnee.Enabled = false;
            p.txtPersonContact.Enabled = false;
            p.txtTel.Enabled = false;
            p.txtTelContact.Enabled = false;
            p.btnEnregistrer.Enabled = false;
            p.btnAffecter.Enabled = true;
            p.poste = poste;
            p.identreprise = identreprise;
            p.idexercice = idexercice;
            p.statut = "ancien";
            if (infirmier_autorise)
                p.statut = "urgence";
            p.ShowDialog();
            p.Close();
        }
        ReceptionFacturation fs;
        private void btnService_Click(object sender, EventArgs e)
        {
            fs = new ReceptionFacturation();
            fs.txtPayeur.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            fs.idpayeur = idpatient;
            fs.btnExit.Visible = false;
            fs.idexercice = exer.ExerciceEncours();
            fs.poste = poste;
            fs.MinimizeBox = fs.MaximizeBox = false;
            fs.MaximumSize = fs.MinimumSize = fs.Size;
            fs.ShowDialog();
            fs.Close();
            btnService.Enabled = false;
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherPatient(this);
        }

        private void FormPatientRecherche_Shown(object sender, EventArgs e)
        {
            txtRecherche.Text = " ";
            btnRecherche_Click(null, null);
        }
    }
}
