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
    public partial class FormFacturePatient : Form
    {
        public FormFacturePatient()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public bool fermeture_succes;
        public int idtypepatient = 0;
        
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (cboTypePatient.Text != "" && dgvPatient.RowCount != 0)
            {
                if (cboTypePatient.Text.Contains("abonné"))
                    numcomptediffere = cm.TrouverNom("numcompte_entreprise", cm.TrouverId("entreprise", dgvPatient.CurrentRow.Cells[12].Value.ToString()));
                else if (cboTypePatient.Text == "employé")
                    numcomptediffere = cc.TrouverId("numcompte", "Médecine du travail et pharmacie").ToString();
                else if (cboTypePatient.Text == "cas social")
                    numcomptediffere = cc.TrouverId("numcompte", "Frais médicaux & Pharmaceutiques Cas sociaux").ToString();
                else if (cboTypePatient.Text == "payant" && type_facture == "différé")
                    numcomptediffere = "4711";
                btnValider.Enabled = false;
                fermeture_succes = true;
                this.Hide();
            }
            else MessageBox.Show("Sélectionnez le type de patient et/ou le patient concerné", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string poste= "",
            type_facture = "",
            numcomptediffere = "";
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherPatient(dgvPatient, txtPatient, "recherche", cboTypePatient.Text, 0);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void FormFacturePatient_Shown(object sender, EventArgs e)
        {
            if (poste != "abonné")           
            {
                txtPatient.Text = "Nom patient";
                dgvPatient.Columns[11].Visible = false;
                dgvPatient.Columns[12].Visible = false;
                dgvPatient.Columns[13].Visible = false;
            }
        }
        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
                btnValider.Enabled = true;
        }

        private void cboTypePatient_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboTypePatient, "typepatient");
            if (poste == "réception")
            {
                cboTypePatient.Items.Remove("abonné");
                cboTypePatient.Items.Remove("employé");
                cboTypePatient.Items.Remove("abonné forfaitaire");
            }
            else if (poste == "abonné")
            {
                cboTypePatient.Items.Remove("payant");
                cboTypePatient.Items.Remove("cas social");
            }
        }
        ClassCompta cc = new ClassCompta();
        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
