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
    public partial class FormCommande : Form
    {
        public FormCommande()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int idproduit,
            idcommande = 0,
            idAppro = 0,
            idrequisition = 0,
            idmvmt = 0,
            qteprise= 0,
            idstock = 0;
        public string poste="",
            motif = "";
        private void btnQteCom_Click(object sender, EventArgs e)
        {
            if(poste == "stock")
                cs.ValiderCommande(this, new FormCom(), "demandeAppro");
            else
            {
                if(dgvCommande.Columns[9].Visible)
                    cs.ValiderCommande(this, new FormCom(), "requisition");
                else
                    cs.ValiderCommande(this, new FormCom(), "commande");
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvCommande.CurrentRow.Cells[8].Value.ToString() == "")
                dgvCommande.Rows.RemoveAt(dgvCommande.CurrentRow.Index);
            else
                MessageBox.Show("Désolé! Une commande déjà enregistrée ne peut être supprimée qu'à partir de l'historique de commandes", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnRetirer.Enabled = false;
        }

        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCommande.RowCount > 0)
            {
                idstock = int.Parse(dgvCommande.CurrentRow.Cells[1].Value.ToString());
                btnRetirer.Enabled = true;
                btnQteCom.Enabled = true;
            }
        }

    }
}
