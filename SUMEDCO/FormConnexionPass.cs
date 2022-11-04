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
    public partial class FormConnexionPass : Form
    {
        public FormConnexionPass()
        {
            InitializeComponent();
        }
        public bool connexion;
        public int idutilisateur = 0;
        public string poste;
        ClassStock cs = new ClassStock();
        private void btnValider_Click(object sender, EventArgs e)
        {
            idutilisateur = cs.TrouverId("user", txtUtilisateur.Text);
            if (idutilisateur != 0)
                cs.Modifier(this);
            else
                MessageBox.Show("Utilisateur non reconnu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            connexion = false;
            this.Hide();
        }

        private void txtUtilisateur_Click(object sender, EventArgs e)
        {
            txtUtilisateur.Text = "";
            txtUtilisateur.ForeColor = Color.Black;
        }

        private void txtUtilisateur_TextChanged(object sender, EventArgs e)
        {
            txtUtilisateur.ForeColor = Color.Black;
        }

        private void txtAncienMdPass_Click(object sender, EventArgs e)
        {
            txtAncienMdPass.Text = "";
            txtAncienMdPass.Focus();
        }
        private void txtAncienMdPass_Enter(object sender, EventArgs e)
        {
            if (txtAncienMdPass.Text.Contains("mot de passe"))
                txtAncienMdPass.Text = "";
            txtAncienMdPass.ForeColor = Color.Black;
            txtAncienMdPass.UseSystemPasswordChar = true;
        }

        private void txtNouveauMdPass_Enter(object sender, EventArgs e)
        {
            if (txtNouveauMdPass.Text.Contains("mot de passe"))
                txtNouveauMdPass.Text = "";
            txtNouveauMdPass.ForeColor = Color.Black;
            txtNouveauMdPass.UseSystemPasswordChar = true;
        }

        private void txtConfirmerMdPass_Enter(object sender, EventArgs e)
        {
            if (txtConfirmerMdPass.Text.Contains("mot de passe"))
                txtConfirmerMdPass.Text = "";
            txtConfirmerMdPass.ForeColor = Color.Black;
            txtConfirmerMdPass.UseSystemPasswordChar = true;
        }
    }
}
