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
    public partial class ComptaJournal : Form
    {
        public ComptaJournal()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            dgvJournal.Rows.Clear();
        }
    }
}
