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
    class ClasseExercice
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
        
        public int NbExerciceEncours()
        {
            id = 0;
            con.Open();
            try
            {

                cmd = new SqlCommand("SELECT COUNT(exercice) from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public int ExerciceEncours()
        {
            id = 0;
            con.Open();
            try
            {

                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public void LancerCompta(ComptabiliteMDI c)
        {
            id = NbExerciceEncours();
            if (id == 0)
            {
                MessageBox.Show("Ajoutez un exercice comptable pour les opérations", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new ComptaExercice().ShowDialog();
            }
            else if (id > 1)
            {
                MessageBox.Show("Retenez un exercice comptable pour les opérations", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ComptaExercice exe = new ComptaExercice();
                exe.suppression = true;
                exe.ShowDialog();
            }
        }
    }
}
