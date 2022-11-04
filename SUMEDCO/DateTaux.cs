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
    public partial class DateTaux : Form
    {
        public DateTaux()
        {
            InitializeComponent();
        }
        ClassCompta cm = new ClassCompta();
        public bool fermeture_succes;

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnContinuer_Click(object sender, EventArgs e)
        {
            if (cm.VerifierTaux(dtpTaux.Value.Date, "") != 0)
            {
                fermeture_succes = true;
                this.Hide();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }
    }
}
