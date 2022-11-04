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
    public partial class FormLot : Form
    {
        public FormLot()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public string numlot = "";
        public int idproduit = 0;
        public bool fermeture_succes;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cs.Supprimer(this);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }
    }
}
