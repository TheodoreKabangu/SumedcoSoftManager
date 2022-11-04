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
    public partial class FormApproStockPharma : Form
    {
        public FormApproStockPharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public string poste;
        public int idAppro = 0,
            idstock = 0,
            idproduit = 0;
        public bool bon_valide;
        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAppro.RowCount > 0)
            {
                if (poste == "admin")
                {
                    idAppro = int.Parse(dgvAppro.CurrentRow.Cells[0].Value.ToString());
                    idstock = int.Parse(dgvAppro.CurrentRow.Cells[2].Value.ToString());
                    idproduit = int.Parse(dgvAppro.CurrentRow.Cells[3].Value.ToString());
                    btnServir.Enabled = true;
                }
                else
                    btnRetirer.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            dgvAppro.Rows.RemoveAt(dgvAppro.CurrentRow.Index);
            btnRetirer.Enabled = false;
        }

        private void FormApproRapport_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.ServirApproPharma(this, new FormApproPharma());
        }

        private void btnToutes_Click(object sender, EventArgs e)
        {
            cs.AfficherTouteDemandeAppro(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.AfficherApproPeriode(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cs.ImprimerBonCommande(this, new FormImpression());
        }

        private void txtCompte_TextChanged(object sender, EventArgs e)
        {

        }

        private void listProduit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
