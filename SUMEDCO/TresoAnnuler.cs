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
    public partial class TresoAnnuler : Form
    {
        public TresoAnnuler()
        {
            InitializeComponent();
        }
        public int idflux = 0;
        public bool fermeture_succes;
        private void btnValider_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }
    }
}
