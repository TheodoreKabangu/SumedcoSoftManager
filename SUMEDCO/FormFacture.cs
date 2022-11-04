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
    public partial class FormFacture : Form
    {
        public FormFacture()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public bool fermeture_succes;
        public int idtypepatient = 0;
        private void btnValider_Click(object sender, EventArgs e)
        {
            if (lblPatient.Text != "Nom, Postnom, Prénom")
            {
                fermeture_succes = true;
                this.Hide();
            }
            
        }

        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtIdPatient);
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            lblPatient.Text = cm.TrouverPatientPayant(this);
            if (lblPatient.Text == "")
                lblPatient.Text = "Nom, Postnom, Prénom";
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void cboTypePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypepatient = cm.TrouverId("typepatient", cboTypePatient.Text);
            txtIdPatient.Focus();
        }

        private void txtIdPatient_Enter(object sender, EventArgs e)
        {
            if (cboTypePatient.Text == "")
            {
                MessageBox.Show("Aucun type de patient n'a été sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTypePatient.Select();
            }
        }
    }
}
