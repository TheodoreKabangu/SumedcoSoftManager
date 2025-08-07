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
    public partial class LaboResult : Form
    {
        public LaboResult()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public string poste;
        public int idutilisateur, idoperation = 0;
        public bool fermeture_succes;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifier_Click_1(object sender, EventArgs e)
        {
            cm.ModifierResultatLabo(this, new LaboResultNew());
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            cm.AfficherResultat(dgvResult, txtNom.Text, dtpDateDe, dtpDateA, poste);
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }
    }
}
