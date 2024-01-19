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
    public partial class FormPatientRecherche : Form
    {
        public FormPatientRecherche()
        {
            InitializeComponent();
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassMalade cm = new ClassMalade();
        public int idpatient = 0,
        identreprise,
        idexercice;
        public string poste = "";
        public bool infirmier_autorise;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        FormPatient p;
        private void btnNouveau_Click(object sender, EventArgs e)
        {
            p = new FormPatient();
            p.statut = "nouveau";
            p.poste = poste;
            p.idexercice = cc.ExerciceEncours();
            p.ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Recuperer(this, new FormPatient());
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
                btnProduit.Enabled = true;
                if (poste == "abonné")
                {
                    identreprise = cc.TrouverId("entreprise", dgv.CurrentRow.Cells[11].Value.ToString());
                }
            }
        }

        private void btnAffecter_Click(object sender, EventArgs e)
        {
            p = new FormPatient();
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
            p.rbNouveau.Text = "Ancien cas";
            p.poste = poste;
            p.identreprise = identreprise;
            p.idexercice = idexercice;
            p.statut = "ancien";
            if (infirmier_autorise)
                p.rbNouveau.Enabled = false;
            p.ShowDialog();
        }
        FormFactureService fs;
        FormFactureProduit fp;
        private void btnService_Click(object sender, EventArgs e)
        {
            fs = new FormFactureService();
            fs.txtPayeur.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            fs.idpayeur = idpatient;
            fs.cboTypeFacture.Select();
            fs.btnExit.Visible = false;
            fs.idexercice = cc.ExerciceEncours();
            fs.poste = poste;
            fs.MinimizeBox = fs.MaximizeBox = false;
            fs.MaximumSize = fs.MinimumSize= fs.Size;
            fs.ShowDialog();
            fs.Close();
        }

        private void btnProduit_Click(object sender, EventArgs e)
        {
            fp = new FormFactureProduit();
            fp.txtPayeur.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            fp.idpayeur = idpatient;
            fp.cboTypeFacture.Select();
            fp.btnExit.Visible = false;
            fp.idexercice = cc.ExerciceEncours();
            fp.poste = poste;
            fp.MinimizeBox = fp.MaximizeBox = false;
            fp.MaximumSize = fp.MinimumSize = fp.Size;
            fp.ShowDialog();
            fp.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherPatient(this);
        }
    }
}
