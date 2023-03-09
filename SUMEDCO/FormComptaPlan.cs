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
    public partial class FormComptaPlan : Form
    {
        public FormComptaPlan()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public string numcompte = "";
        public bool fermeture_succes;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCompte.RowCount != 0)
            {
                btnEnregistrer.Enabled = true;
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void cboClasse_SelectedIndexChanged(object sender, EventArgs e)
        {
            cc.ChargerCompte(this);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.ChargerCompte(this);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.RowCount != 0)
            {
                numcompte = dgv1.CurrentRow.Cells[0].Value.ToString();
                cc.CompteClasse(this);
            }
        }
    }
}
