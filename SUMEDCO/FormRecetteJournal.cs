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
    public partial class FormRecetteJournal : Form
    {
        public FormRecetteJournal()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public string numcompte = "";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.TotauxProduitService(this);
            cc.TotalPayementCategorie(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerRapportRecette(this, new FormImpression());
        }

        private void FormBonRecetteJournal_Shown(object sender, EventArgs e)
        {
            cc.ChargerRubriquesRecette(this);
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
                cc.AfficherRapport(this, new FormRecetteRapport());
        }
    }
}
