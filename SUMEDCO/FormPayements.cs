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
    public partial class FormPayements : Form
    {
        public FormPayements()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        public string poste, motif = "", statut_examen = "";
        public int idproduit = 0, idcommande = 0;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cc.AfficherPayement(this);
        }
    }
}
