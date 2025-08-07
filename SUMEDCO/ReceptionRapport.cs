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
    public partial class ReceptionRapport : Form
    {
        ClasseElements ce = new ClasseElements();
        public ReceptionRapport()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRecette);
        }
        ReceptionFactureClasse rfc = new ReceptionFactureClasse();
        RecetteClasse rc = new RecetteClasse();
        public int idproduit;
        public string poste;
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            btnSupprimer.Enabled = false;
            rc.SupprimerRecette(dgvRecette);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvRecette_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRecette.RowCount != 0)
                btnSupprimer.Enabled = true;
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            rc.RecetteReception(this);
        }

        private void ReceptionRapport_Shown(object sender, EventArgs e)
        {
            btnRecherche_Click(null, null);
        }
    }
}
