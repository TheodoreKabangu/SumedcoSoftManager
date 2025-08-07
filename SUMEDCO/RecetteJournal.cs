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
    public partial class RecetteJournal : Form
    {
        ClasseElements ce = new ClasseElements();
        public RecetteJournal()
        {
            InitializeComponent();
            ce.FigerColonne(dgvRecette);
        }
        ClassCompta cc = new ClassCompta();
        RecetteClasse rc = new RecetteClasse();
        public string numcompte = "";
        public int idutilisateur;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            rc.RecetteJournal(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            rc.ImprimerRapportRecette(this, new FormImpression());
        }

        private void FormBonRecetteJournal_Shown(object sender, EventArgs e)
        {
            rc.RecetteJournal(this);
        }
    }
}
