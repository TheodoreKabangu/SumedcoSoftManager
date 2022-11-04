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
    public partial class FormProduitPharma : Form
    {
        public FormProduitPharma()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
		public int idproduit = 0;

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(this);
        }

        private void dgvProduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cs.Recuperer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.Supprimer(this);
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            cs.Afficher(this,"recherche");
        }

    }
}
