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
    public partial class FormMedecin : Form
    {
        public FormMedecin()
        {
            InitializeComponent();
        }
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            cm.Annuler(this);
        }
        public int idmedecin = 0;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if(cm.Enregistrer(this))
            {
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cm.AfficherMedecin(this);
                cm.Annuler(this);
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cm.Recuperer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (cm.Modifier(this))
            {
                MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cm.AfficherMedecin(this);
                cm.Annuler(this);
            }
        }

        private void Medecin_Shown(object sender, EventArgs e)
        {
            cm.AfficherMedecin(this);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

        private void cboUtilisateur_DropDown(object sender, EventArgs e)
        {
            cs.Utilisateur(this);
        }
        
    }
}
