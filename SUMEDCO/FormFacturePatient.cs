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
            btnValider.Enabled = false;
            fermeture_succes = true;
            this.Hide();
            
        }

        public string poste;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherPatient(dgvPatient, txtPatient, "recherche", poste, 0);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }
        private void txtPatient_Enter(object sender, EventArgs e)
        {
            
        }

        private void FormFacturePatient_Shown(object sender, EventArgs e)
        {
            if (poste == "abonné")
                txtPatient.Text = "Numéro service";
            else
            {
                txtPatient.Text = "Nom patient";
                dgvPatient.Columns[11].Visible = false;
                dgvPatient.Columns[12].Visible = false;
                dgvPatient.Columns[13].Visible = false;
            }
        }

        private void txtPatient_Click(object sender, EventArgs e)
        {
            if (txtPatient.Text == "Nom patient" || txtPatient.Text == "Numéro service")
                txtPatient.Text = "";
        }

        private void dgvPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPatient.RowCount != 0)
                btnValider.Enabled = true;
        }

    }
}
