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
    public partial class FormAbonnePersoRapport : Form
    {
        public FormAbonnePersoRapport()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int identreprise;

        //public DataGridView dgv = new DataGridView();
        private void cboTypePatient_DropDown(object sender, EventArgs e)
        {
            cm.ChargerCombo(cboTypePatient, "typepatient");
            cboTypePatient.Items.Remove("payant");
        }
        public ComboBox cbonumcompte = new ComboBox();
        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTypePatient.Text == "abonné")
            {
                dgvRapport.Columns[5].Visible = true;
                cboEntreprise.Enabled = true;
                txtTaux.Enabled = true;
            }
            else
            {
                dgvRapport.Columns[5].Visible = false;
                cboEntreprise.Items.Clear();
                cboEntreprise.Enabled = false;
                txtTaux.Enabled = false;
            }
        }

        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text);
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }
        public int taux;
        private void FormAbonnePersoRapport_Shown(object sender, EventArgs e)
        {
            taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            lblTaux.Text =  taux + " CDF";            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            dgvRapport.Rows.Clear();
            cc.RubriquesRapport(this);

            if(cboTypePatient.Text == "abonné")
            {
                cc.AfficherAbonne(this);
                cm.AfficherPatient(dgvRapport, 1, 2);

                cc.CalculDepense(this);
                cc.CalculTotalLigne2(this);
                cc.CalculerTotaux(this);

                lblTotalCDF.Text = (double.Parse(dgvRapport.Rows[dgvRapport.RowCount - 1].Cells[dgvRapport.ColumnCount - 1].Value.ToString()) + 0.1 * double.Parse(dgvRapport.Rows[dgvRapport.RowCount - 1].Cells[dgvRapport.ColumnCount - 1].Value.ToString())).ToString("0.00");
                lblTotalUSD.Text = (double.Parse(lblTotalCDF.Text) / taux).ToString("0.00");
            }
            else
            {
                cc.AfficherEmploye(this);
                cm.AfficherPatient(dgvRapport, 1, 2);

                cc.CalculTotalLigne(this);
                cc.CalculerTotaux(this);

                lblTotalUSD.Text = "0";
                lblTotalCDF.Text = "0";
            }
            btnImprimer.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerRapport(this);
        }
    }
}
