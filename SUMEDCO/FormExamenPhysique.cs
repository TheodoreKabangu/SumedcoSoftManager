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
    public partial class FormExamenPhysique : Form
    {
        public FormExamenPhysique()
        {
            InitializeComponent();
        }
        public bool fermeture_succes;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnPlusExamPhys_Click(object sender, EventArgs e)
        {
            dgv.Rows.Add();
            dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dgv.RowCount;
        }

        private void btnRetirerExamPhys_Click(object sender, EventArgs e)
        {
            dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }
    }
}
