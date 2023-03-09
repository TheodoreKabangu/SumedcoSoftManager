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
    public partial class FormDepenseJournal : Form
    {
        public FormDepenseJournal()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public double taux = 0, somme = 0;

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void FormDepenseJournal_Shown(object sender, EventArgs e)
        {
            if (cc.VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                cc.ChangerDate(this, new DateTaux());
            }
            else
                taux = double.Parse(cc.VerifierTaux(DateTime.Now.Date, "valeur").ToString());
        }
    }
}
