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
    public partial class FormDepenseRapport : Form
    {
        public FormDepenseRapport()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int numbon = 0;
        public double sommeDepense = 0;
        public Form activForm = null;
        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvBon.RowCount > 0)
            {
                btnSupprimer.Enabled = true;
                numbon = int.Parse(dgvBon.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //cc.ModifierDepense(this, new FormDepense());
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rassurez-vous de renseigner la cause de cette suppression", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtMotif.Enabled = true;
            btnValider.Enabled = true;
            txtMotif.Focus();
            btnSupprimer.Enabled = false;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (txtMotif.Text != "")
            {
                cc.RetirerBon(this);
            }
        }

        private void btnSomme_Click(object sender, EventArgs e)
        {
            if(dgvBon.RowCount>0)
            {
                if (cboMonnaie.Text != "")
                {
                    cc.SommeDepense(this);
                }
                else
                    MessageBox.Show("Sélectionnez une monnaie unique pour tous les bons", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
