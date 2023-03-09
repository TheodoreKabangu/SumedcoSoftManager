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
    public partial class FormCommandePharma : Form
    {
        public FormCommandePharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public string motif = "";
        public int idAppro = 0, 
            idcommande = 0,
            idproduit= 0,
            idmvmt = 0,
            idrequisition = 0;
        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvComande.RowCount > 0)
            {
                idproduit = int.Parse(dgvComande.CurrentRow.Cells[1].Value.ToString());                    
                btnRetirer.Enabled = true;
                btnQteCom.Enabled = true;
            }
        }

        private void btnQteCom_Click(object sender, EventArgs e)
        {
            cs.ValiderCommande(this, new FormComAutre(), motif);
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if (dgvComande.CurrentRow.Cells[5].Value.ToString() == "")
                dgvComande.Rows.RemoveAt(dgvComande.CurrentRow.Index);
            else
                MessageBox.Show("Désolé! Une commande déjà enregistrée ne peut être supprimée qu'à partir de l'historique de commandes", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            btnRetirer.Enabled = false;
        }
    }
}
