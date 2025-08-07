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
    public partial class ComptaExercice : Form
    {
        public ComptaExercice()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public int idexercice = 0;
        public bool suppression;
        private void btnValider_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            txtexercice.Text = "";
            txtexercice.Focus();
        }
        private void FormComptaExercice_Shown(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }
        ClasseElements ce = new ClasseElements();
        private void txtexercice_TextChanged(object sender, EventArgs e)
        {
            ce.TestEntier(txtexercice);
        }

        private void dgvExercice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvExercice.RowCount != 0 && suppression)
            {
                idexercice = Convert.ToInt32(dgvExercice.CurrentRow.Cells[0].Value);
                btnSupprimer.Enabled = true;
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cc.Supprimer(this);
        }
    }
}
