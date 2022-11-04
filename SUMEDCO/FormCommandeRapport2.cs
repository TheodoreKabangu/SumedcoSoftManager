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
    public partial class FormCommandeRapport2 : Form
    {
        public FormCommandeRapport2()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public string poste, motif = "", statut_examen = "";
        public int idproduit = 0, idcommande = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnToutes_Click(object sender, EventArgs e)
        {
            cs.AfficherTouteCommande(this);
        }

        private void listProduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtProduit.Text = listProduit.Text;
            idproduit = cs.TrouverId("", "");
            listProduit.Visible = false;
            cs.AfficherCommandeProduit(this);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.AfficherCommandePeriode(this);
        }
        private void dgvCommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
