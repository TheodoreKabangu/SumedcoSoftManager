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
    public partial class FormComptaGdLivre : Form
    {
        public FormComptaGdLivre()
        {
            InitializeComponent();
            for (int i = 0; i < dgvCompte.ColumnCount; i++)
            {
                dgvCompte.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            for (int i = 0; i < dgvOperation.ColumnCount; i++)
            {
                dgvOperation.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int idexercice = 0;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComptaGdLivre_Shown(object sender, EventArgs e)
        {
            cc.ChargerCompte(this);
        }

        private void dgvCompte_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCompte.RowCount != 0)
            {
                btnImprimer.Enabled = true;
                btnImprimerTout.Enabled = false;
                cc.AfficherMouvement(this, dgvCompte.CurrentRow.Cells[0].Value.ToString());
            }
        }

        private void btnGdLivre_Click(object sender, EventArgs e)
        {
            txtRecherche.Text = "";
            cc.ChargerCompte(this);
            cc.AfficherMouvement(this, "");
            btnImprimer.Enabled = false;
            btnImprimerTout.Enabled = true;
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.ChargerCompte(this);
        }
        public string concerne="";
        private void btnImprimer_Click(object sender, EventArgs e)
        {
            concerne = string.Format("Compte: {0}", dgvCompte.CurrentRow.Cells[0].Value.ToString());
            cc.ImprimerGdLivre(this, new FormImpression());
        }

        private void btnImprimerTout_Click(object sender, EventArgs e)
        {          
            concerne = "Tous les comptes";
            cc.ImprimerGdLivre(this, new FormImpression());
        }
    }
}
