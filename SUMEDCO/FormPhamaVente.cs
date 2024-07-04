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
    public partial class FormPhamaVente : Form
    {
        public FormPhamaVente()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int idpharma = 0,
            idpatient=0,
            idrecette = 0,
        idutilisateur = 0;
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.TrouverPatientRecetteProduit(this, "recherche");
        }

        private void FormPhaVente_Shown(object sender, EventArgs e)
        {
            cc.TrouverPatientRecetteProduit(this, "");
        }
        int progress = 0;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            progress += 1;
            if (progress == 60)
            {
                cc.TrouverPatientRecetteProduit(this, "");
                progress = 0;
            }
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cc.ServirRecette(this, "OK");
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.ServirRecette(this, "");
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
            {               
                idpatient = int.Parse(dgvPatient.CurrentRow.Cells[0].Value.ToString());
                cc.RecetteProduit(this);
            }
        }

        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
            {
                if (dgvRecette.CurrentRow.Cells[5].Value.ToString() == "")
                {
                    btnValider.Enabled = true;
                    btnAnnuler.Enabled = false;
                }
                else
                {
                    btnAnnuler.Enabled = true;
                    btnValider.Enabled = false;
                }
            }
        }
    }
}
