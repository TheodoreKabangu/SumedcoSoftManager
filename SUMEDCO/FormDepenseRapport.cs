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
    public partial class FormDepenseRapport : Form
    {
        public FormDepenseRapport()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int numbon = 0;
        public double sommeDepense = 0;
        public Form activForm = null;
        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDepenseCompte_Click(object sender, EventArgs e)
        {
            new FormDepenseJournal().ShowDialog();
        }
    }
}
