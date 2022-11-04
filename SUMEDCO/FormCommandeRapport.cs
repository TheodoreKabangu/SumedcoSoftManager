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
    public partial class FormCommandeRapport : Form
    {
        public FormCommandeRapport()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idcommande = 0,
            idstock=0,
            qteprise = 0,
            idmvmt = 0;
        public string poste = "";
        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.ServirCommande(this, new FormCom());
        }

        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvCommande.RowCount > 0)
            {
                idcommande = int.Parse(dgvCommande.CurrentRow.Cells[0].Value.ToString());
                btnServir.Enabled = true;
                btnRetourner.Enabled = true;
            }
        }

        private void FormCommandeRapport_Shown(object sender, EventArgs e)
        {

        }

        private void btnToutes_Click(object sender, EventArgs e)
        {
            cs.AfficherTouteCommande(this);
        }
    }
}
