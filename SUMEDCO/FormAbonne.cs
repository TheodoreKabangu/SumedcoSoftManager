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
    public partial class FormAbonne : Form
    {
        public FormAbonne()
        {
            InitializeComponent();
        }
        public int idabonne= 0, 
            identreprise = 0,
            idtypeabonne = 0;
        public bool fermeture_succes,
            recherche_valide;

        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        private void cboEntreprise_SelectedIndexChanged(object sender, EventArgs e)
        {
            identreprise = cc.TrouverId("entreprise", cboEntreprise.Text);
            cc.ChargerCombo("typeabonne", cboTypeAbonne, identreprise);
            cboTypeAbonne.Select();
        }
        private void cboTypeAbonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            idtypeabonne = cc.TrouverId("typeabonne", cboTypeAbonne.Text);
            txtReference.Focus();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            fermeture_succes = false;
            this.Hide();
        }
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            fermeture_succes = true;
            this.Hide();
        }
        public string age;

        private void cboTypeAbonne_Enter(object sender, EventArgs e)
        {
            if (cboEntreprise.Text == "")
            {
                MessageBox.Show("Aucune entreprise n'a été sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEntreprise.Select();
            }
        }

        private void cboEntreprise_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("entreprise", cboEntreprise, 0);
        }

    }
}
