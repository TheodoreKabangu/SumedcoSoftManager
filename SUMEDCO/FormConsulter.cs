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
    public partial class FormConsulter : Form
    {
        public FormConsulter()
        {
            InitializeComponent();
        }
        public int idligneagenda = 0,
            idligne = 0,
            idsigne = 0,
            idresultat,
            idmaladie,
            idconsultation = 0,
            idprescription,
            idmedecin = 0,
            idpatient = 0,
            numbon, numbonS;

        public string motif = "", 
            type_consultation = "",
            type_patient= "";
        public bool ajoutvalide;
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        private void btnSignes_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnPlainte_Click(object sender, EventArgs e)
        {
            if (txtRepondant.Text == "")
            {
                if (MessageBox.Show("Le malade est-il le répondant lui-même ?", "Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    cm.EnregistrerConsultation(this);
                else
                    cboLienRepondant.Select();
            }
            else
            {
                if (cboLienRepondant.Text != "")
                    cm.EnregistrerConsultation(this);
                else
                    MessageBox.Show("Renseignez le lien entre le répondant et le malade", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[2];
            btnHisto2.Enabled = false;
        }

        private void btnAntecedent_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[3];
            btnAntecedent2.Enabled = false;
        }

        private void btnComplement_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[4];
            btnComplement2.Enabled = false;
        }

        private void btnExamenPhysique_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[5];
            btnExamPhys.Enabled = false;
        }

        private void btnPrediagnostic_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[6];
            btnPrediagnostic2.Enabled = false;
        }

        private void btnLaboratoire_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[7];
            cc.ChargerRubriqueExamen(this);
            btnLabo2.Enabled = false;
        }

        private void btnDiagnostic_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[8];
            btnDiagnostic2.Enabled = false;
        }

        private void btnPrescription_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[9];
            btnPrescription2.Enabled = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtRepondant.Enabled = true;
                cboLienRepondant.Enabled = true;
                txtRepondant.Select();
            }
            else
            {
                txtRepondant.Text = "";
                txtRepondant.Enabled = false;
                cboLienRepondant.DropDownStyle = ComboBoxStyle.DropDown;
                cboLienRepondant.SelectedText = "";
                cboLienRepondant.DropDownStyle = ComboBoxStyle.DropDownList;
                cboLienRepondant.Enabled = false;
            }
        }

        private void FormConsulter_Shown(object sender, EventArgs e)
        {
            type_patient = "abonné";
        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvPresc.Rows.Clear();
            cm.Prescrire(this, new FormFactureProduit2());
        }

        private void btnPlusPlainte_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvPlainte.Rows.Clear();
            dgvPlainte.Rows.Add();
            dgvPlainte.Rows[dgvPlainte.RowCount - 1].Cells[0].Value = dgvPlainte.RowCount;
        }

        private void btnRetirerPlainte_Click(object sender, EventArgs e)
        {
            if (dgvPlainte.RowCount != 0) 
                dgvPlainte.Rows.RemoveAt(dgvPlainte.CurrentRow.Index);
        }
        public string label = "";
        private void btnEnregistrerPlainte_Click(object sender, EventArgs e)
        {
            label = "plainte";
            cm.AjouterRenseignement(dgvPlainte, label, idconsultation);
        }

        private void btnEnregistrerHisto_Click(object sender, EventArgs e)
        {
            label = "historique";
            cm.AjouterRenseignement(dgvHisto, label, idconsultation);
        }

        private void btnEnregistrerAntecedent_Click(object sender, EventArgs e)
        {
            label = "antécédent";
            cm.AjouterRenseignement(dgvAntecedent, label, idconsultation);
        }

        private void btnEnregistrerComplement_Click(object sender, EventArgs e)
        {
            label = "complément";
            cm.AjouterRenseignement(dgvComplement, label, idconsultation);
        }

        private void btnEnregistrerExamPhys_Click(object sender, EventArgs e)
        {
            label = "examen physique";
            cm.AjouterRenseignement(dgvExamPhys, label, idconsultation);
        }

        private void btnEnregistrerPrediagnostic_Click(object sender, EventArgs e)
        {
            label = "prédiagnostic";
            cm.AjouterRenseignement(dgvPrediagnostic, label, idconsultation);
        }

        private void btnEnregistrerLabo_Click(object sender, EventArgs e)
        {
            label = "examen labo";
            cm.AjouterExamenConsultation(this);
        }

        private void btnEnregistrerDiagnostic_Click(object sender, EventArgs e)
        {
            label = "diagnostic";
            cm.AjouterMaladieDiagnostic(this);
        }

        private void btnEnregistrerAutrePresc_Click(object sender, EventArgs e)
        {
            label = "autre prescription";
            cm.AjouterRenseignement(dgvAutrePresc, label, idconsultation);
        }

        private void btnPlusHisto_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvHisto.Rows.Clear();
            dgvHisto.Rows.Add();
            dgvHisto.Rows[dgvHisto.RowCount - 1].Cells[0].Value = dgvHisto.RowCount;
        }

        private void btnRetirerHisto_Click(object sender, EventArgs e)
        {
            if (dgvHisto.RowCount != 0) 
                dgvHisto.Rows.RemoveAt(dgvHisto.CurrentRow.Index);
        }

        private void btnPlusAntecedent_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvAntecedent.Rows.Clear();
            dgvAntecedent.Rows.Add();
            dgvAntecedent.Rows[dgvAntecedent.RowCount - 1].Cells[0].Value = dgvAntecedent.RowCount;
        }

        private void btnRetirerAntecedent_Click(object sender, EventArgs e)
        {
            if (dgvAntecedent.RowCount != 0) 
                dgvAntecedent.Rows.RemoveAt(dgvAntecedent.CurrentRow.Index);
        }

        private void btnPlusComplement_Click(object sender, EventArgs e)
        {
            if(motif == "modifier")
                dgvComplement.Rows.Clear();
            dgvComplement.Rows.Add();
            dgvComplement.Rows[dgvComplement.RowCount - 1].Cells[0].Value = dgvComplement.RowCount;
        }

        private void btnRetirerComplement_Click(object sender, EventArgs e)
        {
            if (dgvComplement.RowCount != 0) 
                dgvComplement.Rows.RemoveAt(dgvComplement.CurrentRow.Index);
        }

        private void btnPlusExamPhys_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvExamPhys.Rows.Clear();
            cm.ExamenPhysique(this, new FormExamenPhysique());
        }

        private void btnRetirerExamPhys_Click(object sender, EventArgs e)
        {
            if (dgvExamPhys.RowCount != 0) 
                dgvExamPhys.Rows.RemoveAt(dgvExamPhys.CurrentRow.Index);
        }

        private void btnPlusPrediagnostic_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvPrediagnostic.Rows.Clear();
            dgvPrediagnostic.Rows.Add();
            dgvPrediagnostic.Rows[dgvPrediagnostic.RowCount - 1].Cells[0].Value = dgvPrediagnostic.RowCount;
        }

        private void btnRetirerPrediagnostic_Click(object sender, EventArgs e)
        {
            if (dgvPrediagnostic.RowCount != 0)
                dgvPrediagnostic.Rows.RemoveAt(dgvPrediagnostic.CurrentRow.Index);
        }

        private void btnRetirerLabo_Click(object sender, EventArgs e)
        {
            if(dgvLabo.RowCount != 0)
                dgvLabo.Rows.RemoveAt(dgvLabo.CurrentRow.Index);
        }

        private void btnPlusDiagnostic_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvDiagnostic.Rows.Clear();
            cm.MaladieDiagnostic(this, new FormMaladie());
        }

        private void btnRetirerDiagnostic_Click(object sender, EventArgs e)
        {
            if (dgvDiagnostic.RowCount != 0) 
                dgvDiagnostic.Rows.RemoveAt(dgvDiagnostic.CurrentRow.Index);
        }

        private void btnPlusAutrePresc_Click(object sender, EventArgs e)
        {
            if (motif == "modifier")
                dgvAutrePresc.Rows.Clear();
            dgvAutrePresc.Rows.Add();
            dgvAutrePresc.Rows[dgvAutrePresc.RowCount - 1].Cells[0].Value = dgvAutrePresc.RowCount;
        }

        private void btnRetirerAutrePresc_Click(object sender, EventArgs e)
        {
            if (dgvAutrePresc.RowCount != 0) 
                dgvAutrePresc.Rows.RemoveAt(dgvAutrePresc.CurrentRow.Index);
        }

        private void btnRetirerPrescription_Click(object sender, EventArgs e)
        {
            if (dgvPresc.RowCount != 0) 
                dgvPresc.Rows.RemoveAt(dgvPresc.CurrentRow.Index);
        }

        private void btnEnregistrerPresc_Click(object sender, EventArgs e)
        {
            label = "prescription";
            cm.AjouterPrescription(this);
        }

        private void btnRendezVous_Click(object sender, EventArgs e)
        {
            cm.AjouterRendezVous(this, new FormConsulterRendezVous());
        }

        private void btnModifierPlainte_Click(object sender, EventArgs e)
        {
            label = "plainte";
            cm.ModifierRenseignement(dgvPlainte, label);
        }

        private void btnSupprimerPlainte_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvPlainte);
        }

        private void btnModifierHisto_Click(object sender, EventArgs e)
        {
            label = "historique";
            cm.ModifierRenseignement(dgvHisto, label);
        }

        private void btnSupprimerHisto_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvHisto);
        }

        private void btnModifierAntecedent_Click(object sender, EventArgs e)
        {
            label = "antécédent";
            cm.ModifierRenseignement(dgvAntecedent, label);
        }

        private void btnSupprimerAntecedent_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvAntecedent);
        }

        private void btnModifierComplement_Click(object sender, EventArgs e)
        {
            label = "complément";
            cm.ModifierRenseignement(dgvComplement, label);
        }

        private void btnSupprimerComplement_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvComplement);
        }

        private void btnModifierExamPhys_Click(object sender, EventArgs e)
        {
            label = "examen physique";
            cm.ModifierRenseignement(dgvExamPhys, label);
        }

        private void btnSupprimerExamPhys_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvExamPhys);
        }

        private void btnModifierPrediag_Click(object sender, EventArgs e)
        {
            label = "prédiagnostic";
            cm.ModifierRenseignement(dgvPrediagnostic, label);
        }

        private void btnSupprimerPrediag_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvPrediagnostic);
        }

        private void btnModifierBonLabo_Click(object sender, EventArgs e)
        {
            cm.ModifierExamenLabo(this);
        }

        private void btnModifierDiagno_Click(object sender, EventArgs e)
        {
            cm.ModifierMaladieDiagnostic(this);
        }

        private void btnSupprimerBonLabo_Click(object sender, EventArgs e)
        {
            cm.SupprimerExamenLabo(this);
        }

        private void btnSupprimerDiagno_Click(object sender, EventArgs e)
        {
            cm.SupprimerMaladieDiagnostic(this);
        }

        private void btnModifierPresc_Click(object sender, EventArgs e)
        {
            cm.ModifierPrescription(this);
        }

        private void btnSupprimerPresc_Click(object sender, EventArgs e)
        {
            cm.SupprimerPrescription(this);
        }

        private void btnModifierAutrePresc_Click(object sender, EventArgs e)
        {
            label = "autre prescription";
            cm.ModifierRenseignement(dgvAutrePresc, label);
        }

        private void btnSupprimerAutrePresc_Click(object sender, EventArgs e)
        {
            cm.SupprimerRenseignement(dgvAutrePresc);
        }

        private void dgvLabo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLabo.CurrentRow.Cells[1].Selected && dgvLabo.CurrentRow.Cells[0].Value.ToString() == "")
            {
                if (motif == "modifier")
                {
                    cc.ChargerRubriqueExamen(this);
                }
                if (dgvLabo.CurrentRow.Cells[1].Value.ToString() == "AUTRES")
                    cc.AutresExamens(this, new FormExamenPhysique());
                else
                    cc.ChargerExamens(this, new FormExamenPhysique());
            }
        }
    }
}
