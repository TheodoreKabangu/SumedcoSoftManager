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
    public partial class FormBonRecetteJournal : Form
    {
        public FormBonRecetteJournal()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.JournalCaisseRecette(this);
        }

        private void btnImprimer_Click(object sender, EventArgs e)
        {

        }
    }
}
