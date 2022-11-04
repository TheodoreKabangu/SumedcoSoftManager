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
    public partial class FormRequisition : Form
    {
        public FormRequisition()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public long idrequisition = 0,
            idproduit= 0,
            idforme = 0,
            idcondition = 0;

        private void btnToutStock_Click(object sender, EventArgs e)
        {
            cs.AfficherTouteRequisition(this);
        }
        
    }
}
