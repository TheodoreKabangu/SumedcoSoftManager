
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
    class RecetteTraceClasse
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

        ExerciceClasse exer = new ExerciceClasse();
        public void AfficherTrace(RecetteMDI r, RecetteTrace child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (r.activeForm != null)
                    r.activeForm.Close();
                r.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                r.pnlChildForm.Controls.Add(child);
                r.pnlChildForm.Tag = child;
                child.BringToFront();
                child.poste = "recette";
                child.idutilisateur = r.idutilisateur;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
