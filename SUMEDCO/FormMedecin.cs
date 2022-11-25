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
        public string utilisateur;
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            cm.Enregistrer(this);
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cm.Recuperer(this);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            cm.Modifier(this);
        }

        private void Medecin_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            cm.Supprimer(this);
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            cm.AfficherMedecin(this, "recherche");
        }
        
    }
}
