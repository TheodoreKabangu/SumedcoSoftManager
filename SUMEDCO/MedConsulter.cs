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
    public partial class MedConsulter : Form
    {
        public MedConsulter()
        {
            InitializeComponent();
            for (int i = 0; i < dgvLabo.ColumnCount; i++)
            {
                dgvLabo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            idprise;

        public string motif = "", 
            type_consultation = "",
            type_patient= "",
            type_facture="";
        public bool ajoutvalide;
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        private void btnSignes_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
        }

        private void btnPlainte_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
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
            cm.ExamenPhysique(this);
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
        private void btnPlusPlainte_Click(object sender, EventArgs e)
        {
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
            cm.AjouterRenseignement(dgvPlainte, "plainte", idconsultation);
        }

        private void btnEnregistrerHisto_Click(object sender, EventArgs e)
        {
            cm.AjouterRenseignement(dgvHisto, "historique", idconsultation);
        }

        private void btnEnregistrerAntecedent_Click(object sender, EventArgs e)
        {
            cm.AjouterRenseignement(dgvAntecedent, "antécédent", idconsultation);
        }

        private void btnEnregistrerComplement_Click(object sender, EventArgs e)
        {
            cm.AjouterRenseignement(dgvComplement, "complément", idconsultation);
        }

        private void btnEnregistrerExamPhys_Click(object sender, EventArgs e)
        {
            cm.AjouterValeurExamenPhysique(this);
        }

        private void btnEnregistrerPrediagnostic_Click(object sender, EventArgs e)
        {
            cm.AjouterRenseignement(dgvPrediagnostic, "prédiagnostic", idconsultation);
        }

        private void btnEnregistrerLabo_Click(object sender, EventArgs e)
        {
            cm.AjouterExamenPara(this);
        }

        private void btnEnregistrerDiagnostic_Click(object sender, EventArgs e)
        {
            cm.AjouterDiagnostics(this);
        }

        private void btnEnregistrerAutrePresc_Click(object sender, EventArgs e)
        {
            if (dgvAutrePresc.RowCount != 0) 
                cm.AjouterPrescription(this, "autre");
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnPlusHisto_Click(object sender, EventArgs e)
        {
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
            dgvComplement.Rows.Add();
            dgvComplement.Rows[dgvComplement.RowCount - 1].Cells[0].Value = dgvComplement.RowCount;
        }

        private void btnRetirerComplement_Click(object sender, EventArgs e)
        {
            if (dgvComplement.RowCount != 0) 
                dgvComplement.Rows.RemoveAt(dgvComplement.CurrentRow.Index);
        }

        private void btnRetirerExamPhys_Click(object sender, EventArgs e)
        {
            if (dgvExamPhys.RowCount != 0) 
                dgvExamPhys.Rows.RemoveAt(dgvExamPhys.CurrentRow.Index);
        }

        private void btnPlusPrediagnostic_Click(object sender, EventArgs e)
        {
            dgvPrediagnostic.Rows.Add();
            dgvPrediagnostic.Rows[dgvPrediagnostic.RowCount - 1].Cells[0].Value = dgvPrediagnostic.RowCount;
        }

        private void btnRetirerPrediagnostic_Click(object sender, EventArgs e)
        {
            if (dgvLabo.RowCount != 0)
                dgvLabo.Rows.RemoveAt(dgvLabo.CurrentRow.Index);
        }

        private void btnRetirerLabo_Click(object sender, EventArgs e)
        {
            if (dgvLabo.RowCount != 0)
            {
                dgvLabo.Rows.RemoveAt(dgvLabo.CurrentRow.Index);
            }
        }

        private void btnPlusDiagnostic_Click(object sender, EventArgs e)
        {
            cm.MaladieDiagnostic(this, new MedMaladie());
        }

        private void btnRetirerDiagnostic_Click(object sender, EventArgs e)
        {
            if (dgvDiagnostic.RowCount != 0) 
                dgvDiagnostic.Rows.RemoveAt(dgvDiagnostic.CurrentRow.Index);
        }

        private void btnPlusAutrePresc_Click(object sender, EventArgs e)
        {
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
            if (dgvPresc.RowCount != 0) 
                cm.AjouterPrescription(this, "produit");
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRendezVous_Click(object sender, EventArgs e)
        {
            cm.AjouterRendezVous(this, new MedRendezVous());
        }

        private void btnModifierPlainte_Click(object sender, EventArgs e)
        {
            btnModifierPlainte.Enabled = false;
            btnSupprimerPlainte.Enabled = false;
            cm.ModifierRenseignement(dgvPlainte);
        }

        private void btnSupprimerPlainte_Click(object sender, EventArgs e)
        {
            btnModifierPlainte.Enabled = false;
            btnSupprimerPlainte.Enabled = false;
            cm.SupprimerRenseignement(dgvPlainte);
        }

        private void btnModifierHisto_Click(object sender, EventArgs e)
        {
            btnModifierHisto.Enabled = false;
            btnSupprimerHisto.Enabled = false;
            cm.ModifierRenseignement(dgvHisto);
        }

        private void btnSupprimerHisto_Click(object sender, EventArgs e)
        {
            btnModifierHisto.Enabled = false;
            btnSupprimerHisto.Enabled = false;
            cm.SupprimerRenseignement(dgvHisto);
        }

        private void btnModifierAntecedent_Click(object sender, EventArgs e)
        {
            btnModifierAntecedent.Enabled = false;
            btnSupprimerAntecedent.Enabled = false;
            cm.ModifierRenseignement(dgvAntecedent);
        }

        private void btnSupprimerAntecedent_Click(object sender, EventArgs e)
        {
            btnModifierAntecedent.Enabled = false;
            btnSupprimerAntecedent.Enabled = false;
            cm.SupprimerRenseignement(dgvAntecedent);
        }

        private void btnModifierComplement_Click(object sender, EventArgs e)
        {
            btnModifierComplement.Enabled = false;
            btnSupprimerComplement.Enabled = false;
            cm.ModifierRenseignement(dgvComplement);
        }

        private void btnSupprimerComplement_Click(object sender, EventArgs e)
        {
            btnModifierComplement.Enabled = false;
            btnSupprimerComplement.Enabled = false;
            cm.SupprimerRenseignement(dgvComplement);
        }

        private void btnModifierExamPhys_Click(object sender, EventArgs e)
        {
            btnModifierExamPhys.Enabled = false;
            btnSupprimerExamPhys.Enabled = false;
            cm.ModifierExamenPhysique(this);
        }

        private void btnSupprimerExamPhys_Click(object sender, EventArgs e)
        {
            btnModifierExamPhys.Enabled = false;
            btnSupprimerExamPhys.Enabled = false;
            cm.SupprimerExamenPhysique(this);
        }

        private void btnModifierPrediag_Click(object sender, EventArgs e)
        {
            btnModifierPrediag.Enabled = false;
            btnSupprimerPrediag.Enabled = false;
            cm.ModifierRenseignement(dgvPrediagnostic);
        }

        private void btnSupprimerPrediag_Click(object sender, EventArgs e)
        {
            btnModifierPrediag.Enabled = false;
            btnSupprimerPrediag.Enabled = false;
            cm.SupprimerRenseignement(dgvPrediagnostic);
        }
        private void btnModifierDiagno_Click(object sender, EventArgs e)
        {
            btnModifierDiagno.Enabled = false;
            btnSupprimerDiagno.Enabled = false;
            cm.ModifierMaladieDiagnostic(this);
        }
        private void btnSupprimerDiagno_Click(object sender, EventArgs e)
        {
            btnModifierDiagno.Enabled = false;
            btnSupprimerDiagno.Enabled = false;
            cm.SupprimerMaladieDiagnostic(this);
        }

        private void dgvLabo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                if (rfc.ValeurInexistanteDGV(dgvLabo, 0, dgv1.CurrentRow.Cells[0].Value.ToString(), dgvLabo.RowCount))
                {
                    dgvLabo.Rows.Add();
                    dgvLabo.Rows[dgvLabo.RowCount - 1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value.ToString();
                    dgvLabo.Rows[dgvLabo.RowCount - 1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
                    dgvLabo.Rows[dgvLabo.RowCount - 1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value.ToString();
                    dgvLabo.Rows[dgvLabo.RowCount - 1].Cells[3].Value = 1;
                    dgvLabo.Rows[dgvLabo.RowCount - 1].Cells[4].Value = dgv1.CurrentRow.Cells[4].Value.ToString();
                }
            }
        }
        private void btnResultat_Click(object sender, EventArgs e)
        {
            if (idconsultation != 0)
            {
                cm.VoirPrescription(this, new MedConsulterPresc(), "examen para");
            }
        }

        private void btnAfficherPlainte_Click(object sender, EventArgs e)
        {
            cm.VoirRenseignement(this, "plainte");
        }

        private void btnAfficherHisto_Click(object sender, EventArgs e)
        {
            cm.VoirRenseignement(this, "historique");
        }

        private void btnAfficherAntecedent_Click(object sender, EventArgs e)
        {
            cm.VoirRenseignement(this, "antécédent");
        }

        private void btnAfficherComplement_Click(object sender, EventArgs e)
        {
            cm.VoirRenseignement(this, "complément");
        }

        private void btnAfficherExamenPhysique_Click(object sender, EventArgs e)
        {
            cm.VoirExamenPhysique(this);
        }

        private void btnAfficherPrediag_Click(object sender, EventArgs e)
        {
            cm.VoirRenseignement(this, "prédiagnostic");
        }

        private void btnAfficherDiagno_Click(object sender, EventArgs e)
        {
            cm.VoirMaladieDiagnostic(this);
        }

        private void btnAfficherPresc_Click(object sender, EventArgs e)
        {
            cm.VoirPrescription(this, new MedConsulterPresc(), "produit");
        }
        private void btnAfficherAutrePresc_Click(object sender, EventArgs e)
        {
            cm.VoirPrescription(this, new MedConsulterPresc(), "autre");
        }
        private void dgvLabo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvLabo.CurrentRow.Cells[4].Value) < 1)
                {
                    MessageBox.Show("Erreur! La valeur minimale doit être 1", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvLabo.CurrentRow.Cells[3].Value = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur! Valeur interdite", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvLabo.CurrentRow.Cells[3].Value = 1;
            }
        }
        private void btnOuvrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txtFiche.Text = dlg.FileName;
        }

        private void btnAjouterFiche_Click(object sender, EventArgs e)
        {
            cm.AjouterFichePatient(this);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            cm.ImprimerOrdonnance(this, new FormImpression());
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            if (txtRecherche.Text != "")
            {
                rfc.RechercheService(dgv1, txtRecherche.Text, "");
                dgv1.BringToFront();
                dgv1.Visible = true;
            }
            else
                dgv1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                rfc.RechercheProduit(dgvprod, textBox1.Text, "", 0);
                dgvprod.BringToFront();
                dgvprod.Visible = true;
            }
            else
                dgvprod.Visible = false;
        }

        private void dgvprod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvprod.RowCount != 0)
            {
                if (rfc.ValeurInexistanteDGV(dgvPresc, 0, dgvprod.CurrentRow.Cells[0].Value.ToString(), dgvPresc.RowCount))
                {
                    dgvPresc.Rows.Add();
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[0].Value = dgvprod.CurrentRow.Cells[0].Value.ToString();
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}, {2}",
                                                                              dgvprod.CurrentRow.Cells[1].Value.ToString(),
                                                                              dgvprod.CurrentRow.Cells[2].Value.ToString(),
                                                                              dgvprod.CurrentRow.Cells[3].Value.ToString());
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[2].Value = 1;
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[3].Value = "RAS";
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[4].Value = dgvprod.CurrentRow.Cells[5].Value.ToString();
                    dgvPresc.Rows[dgvPresc.RowCount - 1].Cells[5].Value = dgvprod.CurrentRow.Cells[6].Value.ToString();
                }
            }
        }
    }
}
