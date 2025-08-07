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
        private DataLoader _dataLoader;
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        string chaine = "", cmdtxt = "", nom = "";
        int id = 0;
        double valeur;
        public void Afficher(AbonneTrace r)
        {
            
           
        }
        public void SousForm(AbonneMDI a, Form childForm)
        {
            if (a.activeForm != null)
                a.activeForm.Close();
            a.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            a.pnlChildForm.Controls.Add(childForm);
            a.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void SousForm(AbonneMDI a, ReceptionPatient child)
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
                child.poste = ce.TrouverNom("poste", a.idutilisateur);
                child.infirmier_autorise = a.infirmier_autorise;
                
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        ClasseExercice exer = new ClasseExercice();
        ClasseElements ce = new ClasseElements();
        public void AfficherTrace(AbonneMDI a, AbonneTrace child, bool show= false)
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
                child.poste = ce.TrouverNom("poste", a.idutilisateur); //créer une classe Utilisateur
                child.infirmier_autorise = a.infirmier_autorise;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public bool ConsommationTrace(DataGridView dgv)
        {
            success = false;
            con.Open();
            try
            {                
                cmdtxt = @"SELECT idrecette, nomentreprise, noms, age, sexe, num_service, r.numcompte, SUM(qtedem * prix)
                FROM Recette_ r
                JOIN Patient p ON r.idpatient = p.idpatient
                JOIN TypePatient tp ON p.idtype = tp.idtype
                JOIN Entreprise e ON p.identreprise = e.identreprise
                WHERE date_operation = @datejour
                GROUP BY idrecette, nomentreprise, noms, age, sexe, num_service, r.numcompte";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@datejour", DateTime.Now.ToShortDateString()); 
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    for (int i = 6; i < dgv.ColumnCount; i++)
                    {
                        if (dr[6].ToString() == dgv.Rows[0].Cells[i].Value.ToString())
                            dgv.Rows[dgv.RowCount - 1].Cells[i].Value = dr[7].ToString();
                    }
                }
                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return success;
        }
        public async void RapportAbonne(AbonneRapport r)
        {
            _dataLoader = new DataLoader(conString);
            con.Open();
            try
            {        
                // Load data asynchronously without freezing UI
                await _dataLoader.LoadAbonneDataAsync(r.dgvRapport, r.identreprise, r.dtpDe, r.dtpA);
                r.dgvRapport.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (r.dgvRapport.RowCount > 1)
                r.btnImprimer.Enabled = true;
        }
        bool success;
        public bool ExporterVersExcel(string filename)
        {
            success = false;
            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlwbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;
            object misseddata = System.Reflection.Missing.Value;

            xlwbook = xlapp.Workbooks.Add(misseddata);
            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlwbook.Worksheets.get_Item(1);
            Microsoft.Office.Interop.Excel.Range xlrange = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];
            xlrange.Select();
            xlsheet.PasteSpecial(xlrange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            var sfd = new SaveFileDialog();
            sfd.FileName = filename;
            if (File.Exists(sfd.FileName)) File.Delete(sfd.FileName);
            xlwbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            success = true;
            xlapp.Quit();
            return success;
        }

    }
}
