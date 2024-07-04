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
    public partial class StockTrace : Form
    {
        ClasseGeneraleDGV dgv = new ClasseGeneraleDGV();
        public StockTrace()
        {
            InitializeComponent();
            dgv.FigerColonne(dgvRapport);
        }
        public int idpharma;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
