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
    public partial class FormUtilisateur : Form
    {
        public FormUtilisateur()
        {
            InitializeComponent();
        }
        ClassStock cs = new ClassStock();
        ClassMalade cm = new ClassMalade();
        public int idmedecin = 0, idutilisateur = 0;
        public bool fermeture_succes, nouveau_medecin;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cs.Enregistrer(this);
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            //Supprimer revient à désactiver un compte??
            cs.Supprimer(this);
        }

        private void FormCompte_Shown(object sender, EventArgs e)
        {
            
        }

        private void dgvAgenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cs.Recuperer(this);
        }

        private void btnAnnuler_Click_1(object sender, EventArgs e)
        {
            cs.Annuler(this);
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (cboPoste.Text != "")
                {
                    txtSpecification.Enabled = true;
                }
                else
                    MessageBox.Show("Aucun poste n'est sélectionné dans la liste", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cs.Modifier(this);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cs.Afficher(this);
        }
    }
}
