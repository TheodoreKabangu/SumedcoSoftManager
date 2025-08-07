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
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }
        public bool access_autorise;
        private void btnExit_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        private void txtUtilisateur_TextChanged(object sender, EventArgs e)
        {
            txtUtilisateur.ForeColor = Color.Black;
        }

        private void txtUtilisateur_Click(object sender, EventArgs e)
        {
            if (txtUtilisateur.Text=="Utilisateur") 
                txtUtilisateur.Text = "";
            txtUtilisateur.ForeColor = Color.Black;
        }

        ClassMalade cm = new ClassMalade();
        ConnexionClasse cnx = new ConnexionClasse();
        public int idmedecin, idpharma;
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if (cboUtilisateur.Enabled)
            {
                if (cboUtilisateur.Text != "")
                    cnx.Connexion(this);
                else
                {
                    MessageBox.Show("Aucun utilisateur n'est sélectionné dans la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboUtilisateur.Select();
                }
            }
            else
                cnx.Connexion(this);
        }

        private void txtMotdePass_Enter(object sender, EventArgs e)
        {
            if (txtMotdePass.Text == "Mot de passe")
                txtMotdePass.Text = "";
            txtMotdePass.ForeColor = Color.Black;
            if(!checkBox1.Checked) 
                txtMotdePass.UseSystemPasswordChar = true;
        }
        public string poste = "";
        private void FormConnexion_Load(object sender, EventArgs e)
        {
            txtUtilisateur.Select();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                txtMotdePass.UseSystemPasswordChar = false;
            else
                txtMotdePass.UseSystemPasswordChar = true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            new FormAccueil().Show();
            this.Close();
        }

        private void linkModifier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cnx.ModifierMotdePasse(this, new ConnexionPass());
        }

        private void cboUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (poste == "médecin")
            {
                idmedecin = cm.TrouverId("medecin", cboUtilisateur.Text);
            }
            if (poste == "pharmacie")
            {
                idpharma = cm.TrouverId("pharmacie", cboUtilisateur.Text);
            }
        }
    }
}
