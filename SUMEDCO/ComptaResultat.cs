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
    public partial class ComptaResultat : Form
    {
        public ComptaResultat()
        {
            InitializeComponent();
            ce.FigerColonne(dgvResultat);
        }
        ClassCompta cc = new ClassCompta();
        ClasseElements ce = new ClasseElements();
        public string type_comptabilite = "";
        public double sommeRef = 0, sommeSoldeAnte = 0;
        public int idexercice = 0, taux = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormComptaResultat_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
                taux = cc.ChangerDate(this, new DateTaux());
            else
                taux = cc.VerifierTaux(DateTime.Now.Date, "valeur");
            if (taux != 0)
            {
                cc.RubriquesResultat(this);
            }
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {
            cc.ImprimerResultat(this, new FormImpression());
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (dtpDateDe.Value.Year == dtpDateA.Value.Year && dtpDateDe.Value.Date <= dtpDateA.Value.Date)
            {
                cc.CalculerResultat(this);
                btnImprimer.Enabled = true;
            }
            else
                MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
