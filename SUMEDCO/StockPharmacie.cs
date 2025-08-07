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
    public partial class StockPharmacie : Form
    {
        public StockPharmacie()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        ClassCompta cc = new ClassCompta();
        public string numlot = "";
        public int idstock = 0,
            idstockpharma = 0, idpharma = 0;
        private void cboPharma_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("pharma", cboPharma, 0);
        }

        private void cboPharma_SelectedIndexChanged(object sender, EventArgs e)
        {
            idpharma = cs.TrouverId("pharma", cboPharma.Text);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            cs.AjouterNouvellePharma(this);
        }

    }
}
