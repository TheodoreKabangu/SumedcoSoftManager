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
    public partial class FormMouvement : Form
    {
        public FormMouvement()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idmouvement = 0,
            idstock = 0,
            qtestock = 0;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.Afficher(this);
        }

        private void btnReduireColonne_Click(object sender, EventArgs e)
        {
            cs.ReduireColonnes(dgvMvt, btnReduireColonne, btnAfficherTout);
        }

        private void btnAfficherTout_Click(object sender, EventArgs e)
        {
            cs.AfficherColonnes(dgvMvt, btnReduireColonne, btnAfficherTout);
        }
    }
}
