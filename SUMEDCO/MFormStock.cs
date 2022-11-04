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
    public partial class MFormStock : Form
    {
        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();
        public MFormStock()
        {
            InitializeComponent();
        }

        private void btnStocks_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockPharma());
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAutreStock_Click(object sender, EventArgs e)
        {
            cs.AfficherSousForm(this, new FormStockAutreProduit());
        }
    }
}
