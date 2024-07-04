using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using System.IO;
using Microsoft.Reporting.WinForms;

namespace SUMEDCO
{
    class AbonneTraceClasse
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        bool cmdStatut;
        string chaine = "", cmdtxt = "", nom = "";
        int id = 0;
        double valeur;
        public void Exporter(AbonneTrace r)
        {
            
           
        }
        ExerciceClasse exer = new ExerciceClasse();
        public void AfficherTrace(AbonneMDI a, AbonneTrace child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (a.activeForm != null)
                    a.activeForm.Close();
                a.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                a.pnlChildForm.Controls.Add(child);
                a.pnlChildForm.Tag = child;
                child.BringToFront();
                //childForm.poste = TrouverNom("poste", a.idutilisateur); //créer une classe Utilisateur
                child.infirmier_autorise = a.infirmier_autorise;

                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
    }
}
