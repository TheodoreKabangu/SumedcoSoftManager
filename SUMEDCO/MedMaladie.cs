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
    public partial class MedMaladie : Form
    {
        public MedMaladie()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public bool fermeture_succes;
        public int idmaladie = 0;

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "");
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.RowCount > 0)
            {
                idmaladie = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                txtLibelle.Text = dgv.CurrentRow.Cells[1].Value.ToString();
                btnModifier.Enabled = true;
                btnSupprimer.Enabled = true;
                btnEnregistrer.Enabled = false;
            }
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            cm.Afficher(this, "recherche");
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

    }
}
