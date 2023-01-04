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
    public partial class FormFactureProduit2 : Form
    {
        public FormFactureProduit2()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public int idproduit;
        public bool fermeture_succes,
            ajoutvalide;

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }


        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgvStock.Rows.RemoveAt(dgvStock.CurrentRow.Index);
        }
        private void btnValider_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
                btnRetirer.Enabled = true;
        }
    }
}
