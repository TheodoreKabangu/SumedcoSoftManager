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
    public partial class FormUtilisation : Form
    {
        public FormUtilisation()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        public int idstock = 0, 
            idutilisateur = 0,
            idpharma = 0;
        public string poste = "";
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cs.ChargerProduit(this);
        }
        
    }
}
