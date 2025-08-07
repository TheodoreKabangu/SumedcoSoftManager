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
    public partial class TresoRapport : Form
    {
        ClasseElements ce = new ClasseElements();
        public TresoRapport()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRapport);
        }
        TresorerieClasse tc = new TresorerieClasse();
        public double taux = 0, somme = 0;
        public string affectation;
        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (dtpDateDe.Value <= dtpDateA.Value) tc.AfficherRapport(this);
            else MessageBox.Show("Rassurez-vous que les dates sont ordonées", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void FormDepenseJournal_Shown(object sender, EventArgs e)
        {
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            //Si au moins une ligne existe dans la liste
        }
    }
}
