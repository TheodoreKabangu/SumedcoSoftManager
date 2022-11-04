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
    public partial class FormStockPharma2 : Form
    {
        public FormStockPharma2()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idcondition = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
