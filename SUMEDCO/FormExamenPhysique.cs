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
        string chaine = "";

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }

        private void btnPlusExamPhys_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount == 0)
            {
                dgv.Rows.Add();
                dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dgv.RowCount;
                dgv.Rows[dgv.RowCount - 1].Cells[1].Value = "";
                dgv.Rows[dgv.RowCount - 1].Cells[2].Value = "0";
            }
            else
            {
                if(dgv.Rows[dgv.RowCount - 1].Cells[1].Value.ToString() != "")
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dgv.RowCount;
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = "";
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = "0";
                }
            }
        }

        private void btnRetirerExamPhys_Click(object sender, EventArgs e)
        {
            if(dgv.RowCount != 0)
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
        }
        ClassCompta cc = new ClassCompta();
        private void FormExamenPhysique_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
