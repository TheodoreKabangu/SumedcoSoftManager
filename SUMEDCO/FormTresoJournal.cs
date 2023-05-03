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
    public partial class FormTresoJournal : Form
    {
        public FormTresoJournal()
        {
            InitializeComponent();
            for (int i = 0; i < dgvBon.ColumnCount; i++)
            {
                dgvBon.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassCompta cc = new ClassCompta();
        public int numbon = 0;
        public double sommeDepense = 0;
        public Form activForm = null;
        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.AfficherTresoRapport(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnModifier.Enabled = true;
            btnAnnuler.Enabled = true;
        }

        private void btnDepenseCompte_Click(object sender, EventArgs e)
        {
            new FormTresoRapport().ShowDialog();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnModifier.Enabled = false;
            new FormTresoDepense().ShowDialog();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            btnAnnuler.Enabled = false;
            new FormTresoDepense().ShowDialog();
        }
    }
}
