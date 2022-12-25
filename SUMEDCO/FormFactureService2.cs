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
    public partial class FormFactureService2 : Form
    {
        public FormFactureService2()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        private void btnRetirer_Click(object sender, EventArgs e)
        {
            btnRetirer.Enabled = false;
            dgv2.Rows.RemoveAt(dgv2.CurrentRow.Index);
            dgv3.Rows.Clear();
            for (int i = 0; i < dgv2.RowCount; i++)
            {
                dgv3.Rows.Add();
                dgv3.Rows[dgv3.RowCount - 1].Cells[0].Value = dgv2.Rows[i].Cells[0].Value.ToString();
                dgv3.Rows[dgv3.RowCount - 1].Cells[1].Value = dgv2.Rows[i].Cells[1].Value.ToString();
                dgv3.Rows[dgv3.RowCount - 1].Cells[2].Value = dgv2.Rows[i].Cells[2].Value.ToString();
            }
        }

        private void btnVoir_Click(object sender, EventArgs e)
        {
            if(dgv3.RowCount != 0)
            {
                btnRetirer.Enabled = true;
                dgv2.Rows.Clear();
                for (int i = 0; i < dgv3.RowCount; i++)
                {
                    dgv2.Rows.Add();
                    dgv2.Rows[dgv2.RowCount - 1].Cells[0].Value = dgv3.Rows[i].Cells[0].Value.ToString();
                    dgv2.Rows[dgv2.RowCount - 1].Cells[1].Value = dgv3.Rows[i].Cells[1].Value.ToString();
                    dgv2.Rows[dgv2.RowCount - 1].Cells[2].Value = dgv3.Rows[i].Cells[2].Value.ToString();
                }
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            selectionvalide = false;
            this.Hide();
        }
        bool ajoutvalide;
        public bool selectionvalide;
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ajoutvalide = true;
            for (int i = 0; i < dgv2.RowCount; i++)
            {
                if (dgv2.Rows[i].Selected)
                {
                    for (int j = 0; j < dgv3.RowCount; j++)
                    {
                        if (dgv2.Rows[i].Cells[0].Value.ToString() == dgv3.Rows[j].Cells[0].Value.ToString())
                        {
                            ajoutvalide = false;
                            break;
                        }
                    }
                    if (ajoutvalide)
                    {
                        dgv3.Rows.Add();
                        dgv3.Rows[dgv3.RowCount - 1].Cells[0].Value = dgv2.Rows[i].Cells[0].Value.ToString();
                        dgv3.Rows[dgv3.RowCount - 1].Cells[1].Value = dgv2.Rows[i].Cells[1].Value.ToString();
                        dgv3.Rows[dgv3.RowCount - 1].Cells[2].Value = dgv2.Rows[i].Cells[2].Value.ToString();
                    }
                    else
                        MessageBox.Show("Vous ne pouvez pas ajouter un même service plusieurs fois", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void FormFactureService2_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            if (dgv3.RowCount != 0)
            {
                selectionvalide = true;
                this.Hide();
            }
            else
                MessageBox.Show("Vous ne pouvez valider une liste vide!\nAjoutez-y au moins un service", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cc.ChargerService(this, new FormExamenPhysique());
        }
    }
}
