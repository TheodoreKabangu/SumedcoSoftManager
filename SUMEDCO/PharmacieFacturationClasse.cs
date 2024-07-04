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
    class PharmacieFacturationClasse
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
        public void FactureProduit(PharmacieMDI r, PharmacieFacturation childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (r.activeForm != null)
                    r.activeForm.Close();
                r.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                r.pnlChildForm.Controls.Add(childForm);
                r.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.idutilisateur = r.idutilisateur;
                childForm.poste = "réception";
                childForm.txtPayeur.Enabled = true;
                childForm.cboSexe.Enabled = true;
                childForm.txtTel.Enabled = true;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}
