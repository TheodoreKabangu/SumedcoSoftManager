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
    public partial class FormComptaBilan : Form
    {
        public FormComptaBilan()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public string typeItem = "";
        public int taux = 0;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (dgvActif.RowCount != 0)
            {
                cc.AfficherActif(this);
                cc.AfficherPassif(this);
            }
            else
                MessageBox.Show("Aucune ligne trouvée! Rassurez-vous que le taux du jour est enregistré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void FormComptaBilan_Shown(object sender, EventArgs e)
        {
            taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            if(taux !=0)
            {
                cc.RubriquesActif(this);
                cc.RubriquesPassif(this);
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerBilan(this);
        }

        private void cboBilan_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnImprimer.Enabled = true;
        }
        
    }
}
