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
    public partial class LaboResultNew : Form
    {
        public LaboResultNew()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        public int idrecette=0;
        public bool fermeture_succes;

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this);
        }
    }
}
