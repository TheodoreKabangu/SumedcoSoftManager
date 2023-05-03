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
    public partial class MFormComptabilite : Form
    {
        ClassCompta cc = new ClassCompta();
        public MFormComptabilite()
        {
            InitializeComponent();
            pnlRapport.Visible = false;
            pnlCompta.Visible = false;
        }
        ClassStock cs = new ClassStock();
        public Form activeForm = null;
        public int id = 0, idutilisateur;
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();          
        }
        private void btnCompte_Click(object sender, EventArgs e)
        {
            
        }
        private void btnAppro_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormApproCommande());
            if (btnAppro.BackColor != Color.LightSlateGray)
            {
                btnAppro.BackColor = Color.LightSlateGray;
                btnRapport.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnCompta.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnChat.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            }
            else
                btnAppro.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);           
        }        
        private void btnRapport_Click(object sender, EventArgs e)
        {
            if (btnRapport.BackColor != Color.LightSlateGray)
            {
                btnRapport.BackColor = Color.LightSlateGray;
                btnAppro.BackColor = Color.FromArgb(180, 200, 255);
                btnCompta.BackColor = Color.FromArgb(180, 200, 255);
                btnChat.BackColor = Color.FromArgb(180, 200, 255);
            }
            else
                btnRapport.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            cc.SousMenu(pnlRapport);
        }

        private void btnCompta_Click(object sender, EventArgs e)
        {
            if (btnCompta.BackColor != Color.LightSlateGray)
            {
                btnCompta.BackColor = Color.LightSlateGray;
                btnAppro.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnRapport.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnChat.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            }
            else
                btnCompta.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            cc.LancerCompta(this);
            cc.SousMenu(pnlCompta);
        }

        private void btnRapportRecette_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormRecetteJournal());
        }

        private void btnRapportDepense_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormTresoJournal());
        }

        private void btnEcriture_Click(object sender, EventArgs e)
        {
            
        }

        private void btnVisualisation_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaOperation());
        }

        private void btnGrandLivre_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaGdLivre());
        }

        private void btnBilan__Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBilan());
        }

        private void btnBalance__Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaBalance());
        }

        private void btnTabFluxT_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaTableauFlux());
        }

        private void btnResultat_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaResultat());
        }

        private void btnCasMedecin_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormAdminRapportCasMedecin());
        }

        private void btnRapportGlobal_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new FormComptaRecetteDepense());
        }
    }
}
