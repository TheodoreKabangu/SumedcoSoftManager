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
    public partial class StockAlerte : Form
    {
        public StockAlerte()
        {
            InitializeComponent();
            for (int i = 0; i < dgvStock.ColumnCount; i++)
            {
                dgvStock.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        ClassStock cs = new ClassStock();
        ClassCompta cc = new ClassCompta();
        public int idcom = 0,
            idproduit = 0,
            idstock=0,
            qteprise = 0,
            idpharma = 0,
            idcat= 0;
        public string poste = "";
        public bool ajout_effectue;
        private void btnServir_Click(object sender, EventArgs e)
        {
            cs.AjouterCommande(this, poste);
        }

        private void dgvStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvStock.RowCount != 0)
            {
                btnRetirer.Enabled = true;
            }
        }

        private void btnRetirer_Click(object sender, EventArgs e)
        {
            if(dgvStock.RowCount!=0)
                dgvStock.Rows.RemoveAt(dgvStock.CurrentRow.Index);
            btnRetirer.Enabled = false;            
        }

        private void dgvStock_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dgvStock.RowCount; i++)
            {
                try
                {
                    if (Convert.ToInt32(dgvStock.CurrentRow.Cells[5].Value) < 0)
                    {
                        MessageBox.Show("Rassurez-vous de saisir un nombre entier", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dgvStock.CurrentRow.Cells[5].Value = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Rassurez-vous de saisir un nombre entier supérieur à 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvStock.CurrentRow.Cells[5].Value = 0;
                }
            }
        }
    }
}
