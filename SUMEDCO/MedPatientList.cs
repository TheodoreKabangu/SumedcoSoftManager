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
    public partial class MedPatientList : Form
    {
        public MedPatientList()
        {
            InitializeComponent();
            for (int i = 0; i < dgvPatient.ColumnCount; i++)
            {
                dgvPatient.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvPrise.ColumnCount; i++)
            {
                dgvPrise.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassMalade cm = new ClassMalade();

        public int idutilisateur,
            idmedecin,
            idpatient,
            idconsultation,
            idprise, idrecette, idservice;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormConsulterPrise_Shown(object sender, EventArgs e)
        {
            cm.ChargerPriseSigneVitaux(this, "");
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.ChargerPriseSigneVitaux(this, "recherche");
        }

        private void dgvPrise_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPrise.RowCount != 0)
            {
                idprise = Convert.ToInt32(dgvPrise.CurrentRow.Cells[0].Value);
                idpatient = Convert.ToInt32(dgvPrise.CurrentRow.Cells[1].Value);
                idrecette = Convert.ToInt32(dgvPrise.CurrentRow.Cells[3].Value);
                cm.PatientConsulte(dgvPatient, idpatient);
            }
        }
        int progress = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cm.ChargerPriseSigneVitaux(this, "");
                progress = 0;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                timer1.Start();
                progress = 0;
            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnPlainte2_Click(object sender, EventArgs e)
        {
            idconsultation = cm.IdConsultationPrise(Convert.ToInt32(dgvPrise.CurrentRow.Cells[0].Value));
            if (idconsultation == 0)
            {
                if (txtRepondant.Text == "")
                {
                    if (MessageBox.Show("Le malade est-il le répondant lui-même ?", "Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        cm.AjouterConsultation(this);
                    else
                        checkBox1.Select();
                }
                else
                {
                    if (cboLienRepondant.Text != "")
                        cm.AjouterConsultation(this);
                    else
                        MessageBox.Show("Renseignez le lien entre le répondant et le malade", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if(MessageBox.Show("Voulez-vous continuer la consultation de ce patient ?", "Consultation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                    cm.Consultation(this, new MedConsulter());
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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
    }
}
