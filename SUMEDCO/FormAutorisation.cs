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
    public partial class FormAutorisation : Form
    {
        public FormAutorisation()
        {
            InitializeComponent();
        }
        public string poste, etat;
        public int idpharma,
            idutilisateur, 
            idmedecin,
            id;
        ClassMalade cm = new ClassMalade();
        ClassStock cs = new ClassStock();
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            if(cboAutorisation.Text == "" && cboUtilisateur.Text == "")
            {
                if (poste == "infirmier")
                {
                    MFormInfirmerie inf = new MFormInfirmerie();
                    inf.idutilisateur = idutilisateur;
                    inf.Show();
                }
                else if (poste == "pharmacie")
                {
                    MFormPharmacie ph = new MFormPharmacie();
                    ph.idutilisateur = idutilisateur;
                    ph.idpharma = idpharma;
                    ph.Show();
                }
                this.Close();
            }
            else if (cboAutorisation.Text != "")
            {
                if (etat == "autorisé")
                {
                    if (cboAutorisation.Text == "infirmier - médecin")
                    {
                        if (cboUtilisateur.Text != "")
                        {
                            MFormConsultation cons = new MFormConsultation();
                            cons.idmedecin = idmedecin;
                            cons.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sélectionnez un médecin dans la liste", "Valeur");
                            cboUtilisateur.Select();
                        }
                    }
                    else if (cboAutorisation.Text == "infirmier - réception")
                    {
                        MFormReception r = new MFormReception();
                        r.infirmier_autorise = true;
                        r.idutilisateur = cs.TrouverId("utilisateur", "réception");
                        r.Show();
                        this.Close();
                    }
                    else if (cboAutorisation.Text == "infirmier - abonné")
                    {
                        MFormAbonne ab = new MFormAbonne();
                        ab.infirmier_autorise = true;
                        ab.idutilisateur = cs.TrouverId("utilisateur", "abonné");
                        ab.Show();
                        this.Close();
                    }
                    else if (cboAutorisation.Text == "pharmacie - caisse")
                    {
                        MFormRecette rec = new MFormRecette();
                        rec.idutilisateur = cs.TrouverId("utilisateur", "recette");
                        rec.Show();
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Accès refusé\nUne autorisation de l'administration est nécessaire", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAutorisation_DropDown(object sender, EventArgs e)
        {
            cs.ChargerAutorisation(cboAutorisation, poste);
        }

        private void cboUtilisateur_DropDown(object sender, EventArgs e)
        {
            
        }

        private void cboAutorisation_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = cm.TrouverId("autorisation", cboAutorisation.Text);
            etat = cm.TrouverNom("autorisation", id);
            btnConnexion.Text = "Connexion";
            if (cboAutorisation.Text == "infirmier - médecin" && poste == "infirmier")
            {
                cm.ChargerCombo(cboUtilisateur, "médecin");
                cboUtilisateur.Enabled = true;
            }
            else
                cboUtilisateur.Enabled = false;
        }

        private void cboUtilisateur_SelectedIndexChanged(object sender, EventArgs e)
        {
            idmedecin = cm.TrouverId("medecin", cboUtilisateur.Text);
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            if (poste == "Admin")
                this.Close();
            else
                Application.Exit();
        }

        private void btnActiver_Click(object sender, EventArgs e)
        {
            cs.ActiverAutorisation(cboAutorisation.Text);
        }
    }
}
