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
    class RecetteClasse
    {
        private DataLoader _dataLoader;

        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        string cmdtxt = "", valeurchaine = "";
        int id = 0;
        double valeur;
        ReportDataSource rs = new ReportDataSource();

        ClasseElements ce = new ClasseElements();
        public void TrouverRecettePatient(Recette b)
        {
            cmd = new SqlCommand("SELECT idrecette, date_operation, prix * qtedem, libelle, categorie, statut_caisse, servi, numcompte, statut_facture  FROM Recette_ WHERE idpatient = @idpatient AND date_operation BETWEEN @dateDe AND @dateA ", con);
            cmd.Parameters.AddWithValue("@idpatient", Convert.ToInt32(b.dgvPatient.CurrentRow.Cells[0].Value));
            cmd.Parameters.AddWithValue("@dateDe", b.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", b.dtpDateA.Text);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                b.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvRecette.Rows.Add();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[6].Value = dr[6].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[7].Value = dr[7].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[8].Value = dr[8].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if (b.dgvRecette.RowCount != 0)
            {
                //Ligne total
                ce.TotalColonne(b.dgvRecette, 2, 1);
                b.btnValider.Enabled = true;
            }
        }
        public void SoldeCaisse(Label lblCDF, Label lblUSD, double taux)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(qtedem * prix) 
                    FROM Recette_ r
                    JOIN Patient p ON r.idpatient= p.idpatient
                    JOIN TypePatient tp ON p.idtype = tp.idtype
                    WHERE date_operation = @date_jour AND statut_caisse = 'OK' AND nomtype = 'payant'";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() != "")
                {
                    lblCDF.Text = string.Format("{0} CDF", Convert.ToDouble(dr[0].ToString()));
                    lblUSD.Text = string.Format("{0} USD", Convert.ToDouble(dr[0].ToString()) / taux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            //A programmer pour la trésorerie: sommer les flux entrants - les dépenses
        }
        public void StatutCaisseOK(int idrecette, string motif)
        {
            con.Open();
            try
            {
                if (motif == "OK")
                    cmd = new SqlCommand("UPDATE Recette_ SET statut_caisse = 'OK' WHERE idrecette = " + idrecette + "", con);
                else
                    cmd = new SqlCommand("UPDATE Recette_ SET statut_caisse = NULL WHERE idrecette = " + idrecette + "", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void RecetteServiOK(int idrecette, int idutilisateur, string statut)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (statut == "OK")
                {
                    cmd = new SqlCommand("UPDATE Recette_ SET servi = 'OK', idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + "", con);
                }
                else
                    cmd = new SqlCommand("UPDATE Recette_ SET servi = NULL, idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + "", con);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ValiderPayement(Recette b)
        {
            //Ajouter payement
            if (MessageBox.Show(string.Format("Voulez-vous valider le montant total de {0} CDF ?", b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value), "Payement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = b.dgvRecette.RowCount - 1; i >= 0; i--)
                {
                    //MAJ statut caisse de la recette
                    StatutCaisseOK(Convert.ToInt32(b.dgvRecette.Rows[i].Cells[0].Value), "OK");
                    //retrait de la ligne
                    b.dgvRecette.Rows.RemoveAt(b.dgvRecette.Rows[i].Index);
                }
                b.btnValider.Enabled = false;
                SoldeCaisse(b.lblCaisseCDF, b.lblCaisseUSD, b.taux);
            }
        }

        public async void RecetteReception(ReceptionRapport r)
        {
            _dataLoader = new DataLoader(conString);
            con.Open();
            try
            {
                if (r.txtRecherche.Text == "")
                    cmdtxt = @"SELECT r.idrecette AS ID, r.date_operation AS Date, p.noms AS Patient, r.libelle AS Libellé, r.categorie AS Catégorie, r.qtedem AS Qté, r.prix AS Prix, (r.qtedem * r.prix) AS Total, servi AS Servi
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA";
                else
                    cmdtxt = @"SELECT r.idrecette AS ID, r.date_operation AS Date, p.noms AS Patient, r.libelle AS Libellé, r.categorie AS Catégorie, r.qtedem AS Qté, r.prix AS Prix, (r.qtedem * r.prix) AS Total, servi AS Servi
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND noms LIKE '" + r.txtRecherche.Text.Replace("'", "") + "%'";              

                // Load data asynchronously without freezing UI
                await _dataLoader.LoadReceptionDataAsync(r.dgvRecette, cmdtxt, r.dtpDe, r.dtpA);

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        private int RecetteNonServi(int idrecette)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ WHERE idrecette = @id AND servi IS NULL", con);
                cmd.Parameters.AddWithValue("@id", idrecette);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public void SupprimerRecette(DataGridView dgv)
        {
            if (RecetteNonServi(Convert.ToInt32(dgv.CurrentRow.Cells[0].Value)) > 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("DELETE FROM Recette_ where idrecette = @id", con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dgv.CurrentRow.Cells[0].Value));

                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
            }
            else
                MessageBox.Show("Cette recette est déjà comptabilisée,\npour raison de cohérence, elle ne peut être supprimée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AfficherRecette(Recette b, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                    if(b.txtNom.Text != "")
                        cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE date_operation BETWEEN '" + b.dtpDateDe.Text + "' AND '" + b.dtpDateA.Text + "' AND noms LIKE '" + b.txtNom.Text.Replace("'", "") + "%'", con);
                    else
                        cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE date_operation BETWEEN '" + b.dtpDateDe.Text + "' AND '" + b.dtpDateA.Text + "'", con);
                else
                    cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE statut_caisse is NULL AND date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                dr = cmd.ExecuteReader();
                b.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvPatient.Rows.Add();
                    b.dgvPatient.Rows[b.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvPatient.Rows[b.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        /*
         * Rapport
         */
        public void RecetteJournal(RecetteJournal r)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT r.numcompte, c.libellecompte, SUM(qtedem * prix)
                FROM Recette_ r
                JOIN Compte c ON r.numcompte = c.numcompte
                WHERE statut_facture = 'immédiat' AND statut_caisse = 'OK' AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY r.numcompte, c.libellecompte
                ORDER BY c.libellecompte";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                r.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRecette.Rows.Add();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (r.dgvRecette.RowCount != 0)
                ce.TotalColonne(r.dgvRecette, 2, 1);
        }
        public void RapportCaisse(RecetteRapport r)
        {
            con.Open();
            try
            {                
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '701100%' OR numcompte LIKE '7061%' OR numcompte <> '707803' AND numcompte LIKE '70780%'", con);
                dr = cmd.ExecuteReader();
                r.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRecette.Rows.Add();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void MontantRecette(RecetteRapport r)
        {

            for (int i = 0; i < r.dgvRecette.RowCount; i++)
            {
                for (int j = 2; j < r.dgvRecette.ColumnCount; j++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT SUM(qtedem * prix) as Total
                        FROM Recette_ r
                        JOIN Compte c ON r.numcompte = c.numcompte
                        WHERE r.date_operation= @datejour AND r.numcompte = @numcompte";
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@datejour", r.dgvRecette.Columns[j].HeaderText);
                        cmd.Parameters.AddWithValue("@numcompte", r.dgvRecette.Rows[i].Cells[0].Value);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            r.dgvRecette.Rows[i].Cells[j].Value = dr[0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
        }
        public void ImprimerRapportRecette(RecetteJournal b, FormImpression imp)
        {
            imp.Text = string.Format("{0} {1}_{2}_{3}", "SSM - Rapport recette", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            List<Rapport_recette> list = new List<Rapport_recette>();
            list.Clear();

            for (int i = 0; i < b.dgvRecette.RowCount; i++)
            {
                Rapport_recette r = new Rapport_recette
                {
                    id = (i + 1).ToString(),
                    categorie = b.dgvRecette.Rows[i].Cells[1].Value.ToString(),
                    montant = b.dgvRecette.Rows[i].Cells[2].Value.ToString()
                };
                list.Add(r);
            }            
            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.RapportRecette.rdlc";
            imp.ShowDialog();
            imp.Close();
        }

        /*
         * Trcae
         */
        ClasseExercice exer = new ClasseExercice();
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
        bool success;
        public bool RecetteTrace(DataGridView dgv)
        {
            success = false;
            con.Open();
            try
            {
                cmdtxt = @"SELECT idrecette, noms, SUM(qtedem * prix), numcompte
                FROM Recette_ r
                JOIN Patient p ON r.idpatient = p.idpatient
                JOIN TypePatient tp ON p.idtype = tp.idtype
                WHERE nomtype = 'payant' AND date_operation BETWEEN '01/06/2024' AND '31/07/2024'
                GROUP BY idrecette, noms, numcompte";
                cmd = new SqlCommand(cmdtxt, con);
                //cmd.Parameters.AddWithValue("@datejour", DateTime.Now.ToShortDateString());= @datejour
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    for (int i = 2; i < dgv.ColumnCount; i++)
                    {
                        if(dr[3].ToString() == dgv.Rows[0].Cells[i].Value.ToString())
                            dgv.Rows[dgv.RowCount - 1].Cells[i].Value = dr[2].ToString();
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
    }

    public class Rapport_recette
    {
        public string id { get; set; }
        public string categorie { get; set; }
        public string montant { get; set; }
    }
    public class RapportRecette
    {
        public int numcompte { get; set; }
        public string libelle { get; set; }
        public string j1 { get; set; }
        public string j2 { get; set; }
        public string j3 { get; set; }
        public string j4 { get; set; }
        public string j5 { get; set; }
        public string j6 { get; set; }
        public string j7 { get; set; }
        public string j8 { get; set; }
        public string j9 { get; set; }
        public string j10 { get; set; }
        public string j11 { get; set; }
        public string j12 { get; set; }
        public string j13 { get; set; }
        public string j14 { get; set; }
        public string j15 { get; set; }
        public string j16 { get; set; }
        public string j17 { get; set; }
        public string j18 { get; set; }
        public string j19 { get; set; }
        public string j20 { get; set; }
        public string j21 { get; set; }
        public string j22 { get; set; }
        public string j23 { get; set; }
        public string j24 { get; set; }
        public string j25 { get; set; }
        public string j26 { get; set; }
        public string j27 { get; set; }
        public string j28 { get; set; }
        public string j29 { get; set; }
        public string j30 { get; set; }
        public string j31 { get; set; }
    }
}
