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
    public partial class FormCompte : Form
    {
        public FormCompte()
        {
            InitializeComponent();

        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public string numcompte = "";

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            //Ajouter catégorie dans la requête
            cc.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            //Ajouter catégorie dans la requête
            cc.Modifier(this);
        }
        private void txtNumCompte_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtNumCompte);
        }
        public string categorie = "";
        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            categorie = cboCategorie.Text.Substring(0, cboCategorie.Text.IndexOf("-"));
            txtLibelle.Focus();
        }

    }
}
