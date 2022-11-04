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
    public partial class FormService : Form
    {
        public FormService()
        {
            InitializeComponent();
        }
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        public int idservice = 0;
        public string numcompte;
        private void Service_Shown(object sender, EventArgs e)
        {
        }
        private void cboCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            numcompte = cc.TrouverId("numcompte", cboCatService.Text).ToString();
            txtNomService.Focus();
        }

        private void txtPrixService_TextChanged(object sender, EventArgs e)
        {
            cm.TestEntier(txtPrixService);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cc.Annuler(this);
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cc.Enregistrer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cc.Modifier(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Ne peut etre supprimé qu'un service qui n'a jamais été dans les recettes
            cc.Supprimer(this);
        }
        private void txtPrixService_Enter(object sender, EventArgs e)
        {
            if(txtNomService.Text =="")
            {
                MessageBox.Show("Aucun nom de servie n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomService.Focus();
            }
        }

        private void dgvService_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cc.Recuperer(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboCatService_DropDown(object sender, EventArgs e)
        {
            cc.ChargerCombo("catservice", cboCatService, 0);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cc.Afficher(this, "recherche");
        }

    }
}
