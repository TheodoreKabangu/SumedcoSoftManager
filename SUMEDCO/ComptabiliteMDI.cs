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
    public partial class ComptabiliteMDI : Form
    {
        ClassCompta cc = new ClassCompta();
        ClassMalade cm = new ClassMalade();
        ClasseExercice exer = new ClasseExercice();
        public ComptabiliteMDI()
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
            cc.AfficherSousForm(this, new StockApproCom());
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
            exer.LancerCompta(this);
            cc.SousMenu(pnlCompta);
        }
        public string affectation;
        private void btnVisualisation_Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherOperations(this, new ComptaOperation());
        }

        private void btnGrandLivre_Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherGrandLivre(this, new ComptaGdLivre());
        }

        private void btnBilan__Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherBilan(this, new ComptaBilan());
        }

        private void btnBalance__Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherBalance(this, new ComptaBalance());
        }

        private void btnTabFluxT_Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherTableauFluxT(this, new ComptaTableauFlux());
        }

        private void btnResultat_Click(object sender, EventArgs e)
        {
            if (rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.AfficherResultat(this, new ComptaResultat());
        }

        private void btnCasMedecin_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new AdminCasMedecin());
        }

        private void btnRapportGlobal_Click(object sender, EventArgs e)
        {
            //cc.AfficherSousForm(this, new ComptaRecetteDepense());
        }

        private void btnInventaire_Click(object sender, EventArgs e)
        {
            cc.AfficherSousForm(this, new StockInventaire());
        }

        private void btnExercice_Click(object sender, EventArgs e)
        {
            //Cloturer l'exercice dans la table.
            //Passer l'écriture d'ouverture
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            cm.AfficherSousForm(this, new MedMessageHisto());
            if (btnChat.BackColor != Color.LightSlateGray)
            {
                btnChat.BackColor = Color.LightSlateGray;
                btnAppro.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnRapport.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
                btnCompta.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
            }
            else
                btnChat.BackColor = System.Drawing.Color.FromArgb(180, 200, 255);
        }
        public string type_comptabilite = "";
        private void btnPlancompte_Click(object sender, EventArgs e)
        {
            if(rbRoutine.Checked) type_comptabilite = rbRoutine.Text.ToLower();
            else type_comptabilite = rbProjet.Text.ToLower();
            cc.PlanComptes(this, new ComptaComptes());
        }

        private void btnFluxJour_Click(object sender, EventArgs e)
        {
            affectation = "routine";
            cc.AfficherFluxTresorerie(this, new TresoFlux());
        }

        private void btnFluxFFL_Click(object sender, EventArgs e)
        {
            affectation = "FFL";
            cc.AfficherFluxTresorerie(this, new TresoFlux());
        }

        private void ComptabiliteMDI_Shown(object sender, EventArgs e)
        {
            rbRoutine.Checked = true;
        }
    }
}
