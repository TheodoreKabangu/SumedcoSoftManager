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
    public partial class FormAccueil : Form
    {
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        public FormAccueil()
        {
            InitializeComponent();
        }
        FormConnexion cn = new FormConnexion();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            cn.poste = "admin";
            cn.cboUtilisateur.Items.AddRange(new string[] { "AG", "Représentant(e)", "admin" });
            cn.cboUtilisateur.Enabled = true;
            cn.Show();
            this.Hide();
        }
        private void btnRecette_Click(object sender, EventArgs e)
        {
			cn.poste = "recette";
            cn.Show();
            this.Hide();
        }

        private void btnMalade_Click(object sender, EventArgs e)
        {
            cn.poste = "médecin";
            cm.ChargerCombo(cn.cboUtilisateur, "médecin");
            cn.cboUtilisateur.Enabled = true;
            cn.Show();
            this.Hide();          
        }

        private void btnReception_Click(object sender, EventArgs e)
        {
            cn.poste = "réception";
            cn.Show();
            this.Hide();
        }

        private void btnInfirmerie_Click(object sender, EventArgs e)
        {
            cn.poste = "infirmier";
            cn.Show();
            this.Hide();
        }

        private void btnAbonne_Click(object sender, EventArgs e)
        {
            cn.poste = "abonné";
            cn.Show();
            this.Hide();
        }

        private void btnDepense_Click(object sender, EventArgs e)
        {
            cn.poste = "dépense";
            cn.Show();
            this.Hide();
        }

        private void btnCompta_Click(object sender, EventArgs e)
        {
            cn.poste = "comptable";
            cn.Show();
            this.Hide();
        }

        private void btnPharma_Click(object sender, EventArgs e)
        {
            cn.poste = "pharmacie";
            cn.Show();
            this.Hide();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            cn.poste = "stock";
            cn.Show();
            this.Hide();
        }
    }
}
