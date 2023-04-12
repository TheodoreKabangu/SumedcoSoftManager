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
    public partial class FormTresoDepense : Form
    {
        public FormTresoDepense()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public int numbon = 0, iddepense = 0;
        private void FormFrequentation_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {

        }

        private void FormTresoDepense_Load(object sender, EventArgs e)
        {

        }
    }
}
