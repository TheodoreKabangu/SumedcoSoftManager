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
    public partial class FormStockRetour : Form
    {
        public FormStockRetour()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();

        ClassStock cs = new ClassStock();
        public int idstock = 0;
        public string poste = "";
        private void txtQte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtQte);
        }

        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            cs.AjouterRetourEnStock(this, poste);
        }

    }
}
