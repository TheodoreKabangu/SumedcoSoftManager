
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
    class TresorerieClasse
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        string chaine = "", cmdtxt = "", nom = "";
        int id = 0;
        double valeur;

        public void AfficherSousForm(TresorerieMDI d, TresoFlux child)
        {
            if (d.activeForm != null)
                d.activeForm.Close();
            d.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            d.pnlChildForm.Controls.Add(child);
            d.pnlChildForm.Tag = child;
            child.BringToFront();
            child.affectation = d.affectation;
            child.Show();
        }
        public void AfficherSousForm(TresorerieMDI d, TresoRapport child)
        {
            if (d.activeForm != null)
                d.activeForm.Close();
            d.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            d.pnlChildForm.Controls.Add(child);
            d.pnlChildForm.Tag = child;
            child.BringToFront();
            child.affectation = d.affectation;
            child.Show();
        }
        ClasseElements ce = new ClasseElements();
        bool ajout_valide;
        public void CategoriesRecettes(TresoFluxNew f)
        {
            if (f.txtNumPiece.Text != "")
            {
                f.btnAjouter.Enabled = false;
                f.btnMonnaie.Enabled = false;
                f.dgvEcriture.Columns[0].ReadOnly = true;
                f.dgvEcriture.Columns[4].ReadOnly = true;
                cmd = new SqlCommand("SELECT libellecompte FROM Compte WHERE numcompte LIKE '7052%'", con);
                con.Open();
                try
                {
                    dr = cmd.ExecuteReader();
                    f.dgvEcriture.Rows.Clear();
                    valeur = 0;
                    while (dr.Read())
                    {
                        f.dgvEcriture.Rows.Add();
                        f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[0].Value = f.txtNumPiece.Text;
                        f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[1].Value = "Trésorerie";
                        f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[2].Value = 0;
                        f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[3].Value = "CDF";
                        f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[4].Value = dr[0].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
            {
                f.chbCatRecette.Checked = false;
                MessageBox.Show("Renseignez un numéro de pièce qui référence le rapport recettes", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AjouterFlux(TresoFluxNew f)
        {
            if (f.dgvEcriture.RowCount != 0)
            {
                ajout_valide = false;
                for (int i = 0; i < f.dgvEcriture.RowCount; i++)
                {
                    if (Convert.ToDouble(f.dgvEcriture.Rows[i].Cells[2].Value) > 0)
                    {
                        id = ce.NouveauID("flux");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("INSERT INTO Fluxtresorerie (idflux, date_operation, numpiece, montant, monnaie, beneficiaire, libelle, operation, affectation) VALUES (@idflux, @date_operation, @numpiece, @montant, @monnaie, @beneficiaire, @libelle, @operation, @affectation)", con);
                            cmd.Parameters.AddWithValue("@idflux", id);
                            cmd.Parameters.AddWithValue("@date_operation", f.lblDateOperation.Text);
                            cmd.Parameters.AddWithValue("@numpiece", f.dgvEcriture.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@montant", Convert.ToDouble(f.dgvEcriture.Rows[i].Cells[2].Value.ToString()));
                            cmd.Parameters.AddWithValue("@monnaie", f.dgvEcriture.Rows[i].Cells[3].Value.ToString());
                            cmd.Parameters.AddWithValue("@beneficiaire", f.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@libelle", f.dgvEcriture.Rows[i].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@operation", f.operation);
                            cmd.Parameters.AddWithValue("@affectation", f.affectation);
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            ajout_valide = true;
                        }
                        catch (Exception ex)
                        {
                            tx.Rollback();
                            MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    else
                    {
                        f.dgvEcriture.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
                        f.dgvEcriture.Rows[i].Cells[2].Style.SelectionBackColor = Color.IndianRed;
                    }
                }
                if (ajout_valide)
                {
                    MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f.dgvEcriture.Rows.Clear();
                }
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierFlux(TresoFlux fx, TresoFluxNew f)
        {
            fx.btnModifier.Enabled = false;
            f.idflux = Convert.ToInt32(fx.dgvFlux.CurrentRow.Cells[0].Value);
            f.dgvEcriture.Rows.Add();
            f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[0].Value = fx.dgvFlux.CurrentRow.Cells[2].Value;
            f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[1].Value = fx.dgvFlux.CurrentRow.Cells[5].Value;
            f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[2].Value = fx.dgvFlux.CurrentRow.Cells[3].Value;
            f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[3].Value = fx.dgvFlux.CurrentRow.Cells[4].Value;
            f.dgvEcriture.Rows[f.dgvEcriture.RowCount - 1].Cells[4].Value = fx.dgvFlux.CurrentRow.Cells[6].Value;
            f.btnAjouter.Enabled = false;
            f.btnEnregistrer.Enabled = false;
            f.btnModifier.Enabled = true;
            f.btnAnnuler.Enabled = false;
            f.operation = "modifier";
            f.ShowDialog();

            if (f.modifier_succes)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Fluxtresorerie SET numpiece = @numpiece, montant= @montant, monnaie = @monnaie, beneficiaire = @beneficiaire, libelle = @libelle WHERE idflux = " + f.idflux + "", con);
                    cmd.Parameters.AddWithValue("@numpiece", f.dgvEcriture.Rows[0].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@montant", f.dgvEcriture.Rows[0].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", f.dgvEcriture.Rows[0].Cells[3].Value.ToString());
                    cmd.Parameters.AddWithValue("@beneficiaire", f.dgvEcriture.Rows[0].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@libelle", f.dgvEcriture.Rows[0].Cells[4].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Mise à jour réussie", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                AfficherFlux(fx);
            }
            f.Close();
        }
        public void AnnulerFlux(TresoFlux f, TresoAnnuler td)
        {
            f.btnAnnuler.Enabled = false;
            td.ShowDialog();
            if (td.fermeture_succes)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Fluxtresorerie SET raison_retrait = @raison WHERE idflux = " + f.dgvFlux.CurrentRow.Cells[0].Value + "", con);
                    cmd.Parameters.AddWithValue("@raison", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), td.txtRaison_retrait.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Opération effectuée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                ////composer le message
                //chaine = string.Format("Annulation dépense {0} pour {1}\nDate:{2}\nMontant:{3} {4}\nCompte:{5}",
                //    d.dgvFlux.CurrentRow.Cells[0].Value.ToString(),
                //    d.dgvFlux.CurrentRow.Cells[7].Value.ToString(),
                //    d.dgvFlux.CurrentRow.Cells[1].Value.ToString(),
                //    d.dgvFlux.CurrentRow.Cells[2].Value.ToString(),
                //    d.dgvFlux.CurrentRow.Cells[3].Value.ToString(),
                //    d.dgvFlux.CurrentRow.Cells[8].Value.ToString());
                ////Signaler au comptable
                //MessageAuComptable(d.idutilisateur, chaine, "dépense");
                AfficherFlux(f);
            }
            td.Close();
        }
        public void AfficherFlux(TresoFlux f)
        {
            if (f.cboMonnaie.Text != "")
            {
                if (f.cboOperation.Text != "")
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type  
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie AND operation = @operation";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@operation", f.cboOperation.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type    
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@monnaie", f.cboMonnaie.Text);
            }
            else
            {
                if (f.cboOperation.Text != "")
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type   
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND date_operation BETWEEN @dateDe AND @dateA AND operation = @operation";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@operation", f.cboOperation.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type   
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }

            }
            cmd.Parameters.AddWithValue("@affect", f.affectation);
            cmd.Parameters.AddWithValue("@dateDe", f.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", f.dtpDateA.Value.Date);
            con.Open();
            try
            {
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    f.dgvFlux.DataSource = dt;
                    ce.FigerColonne(f.dgvFlux);
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            f.btnModifier.Enabled = false;
            f.btnAnnuler.Enabled = false;
            f.btnPrepEcriture.Enabled = false;
        }

        public void AfficherFluxEffectif(TresoFlux f)
        {
            if (f.cboMonnaie.Text != "")
            {
                if (f.cboOperation.Text != "")
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type  
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie AND operation = @operation";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@operation", f.cboOperation.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type    
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@monnaie", f.cboMonnaie.Text);
            }
            else
            {
                if (f.cboOperation.Text != "")
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type   
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA AND operation = @operation";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@operation", f.cboOperation.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idflux AS ID, date_operation AS Date, numpiece AS Pièce, montant AS Montant, monnaie AS Monnaie, beneficiaire AS Beneficiaire, libelle AS Libelle, raison_retrait AS Retiré, operation AS Type   
                    FROM Fluxtresorerie
                    WHERE affectation = @affect AND raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }

            }
            cmd.Parameters.AddWithValue("@affect", f.affectation);
            cmd.Parameters.AddWithValue("@dateDe", f.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", f.dtpDateA.Value.Date);
            con.Open();
            try
            {
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    f.dgvFlux.DataSource = dt;
                    ce.FigerColonne(f.dgvFlux);
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if (f.dgvFlux.RowCount != 0 && f.poste == "tresorerie")
            {
                f.btnModifier.Enabled = true;
                f.btnAnnuler.Enabled = true;
                f.btnPrepEcriture.Enabled = true;
            }
        }

        List<int> lignetotaux = new List<int>(); 
        private void TotalRapport(TresoRapport r, int index_col, double valeur, string lib_total)
        {
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = lib_total;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[index_col].Value = valeur;
            lignetotaux.Add(r.dgvRapport.RowCount - 1);
        }

        public void AfficherRapport(TresoRapport r)
        {
            //Add a background worker avec AttenteForm
            lignetotaux.Clear();
            //Entrées en CDF
            cmdtxt = @"SELECT idflux, date_operation, numpiece, montant, libelle, beneficiaire 
            FROM Fluxtresorerie 
            WHERE raison_retrait IS NULL AND operation = @operation AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            cmd.Parameters.AddWithValue("@operation", "entrée");
            cmd.Parameters.AddWithValue("@monnaie", "CDF");
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                r.dgvRapport.Rows.Clear();
                valeur = 0;
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    valeur += Convert.ToDouble(dr[3].ToString());
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[5].ToString();
                }
                TotalRapport(r, 3, valeur, "Entées CDF");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Entrées en USD
            cmdtxt = @"SELECT idflux, date_operation, numpiece, montant, libelle, beneficiaire 
            FROM Fluxtresorerie 
            WHERE raison_retrait IS NULL AND operation = @operation AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            cmd.Parameters.AddWithValue("@operation", "entrée");
            cmd.Parameters.AddWithValue("@monnaie", "USD");
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                valeur = 0;
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    valeur += Convert.ToDouble(dr[3].ToString());
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[5].ToString();
                }
                TotalRapport(r, 4, valeur, "Entrées USD");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Sorties en CDF
            cmdtxt = @"SELECT idflux, date_operation, numpiece, montant, libelle, beneficiaire 
            FROM Fluxtresorerie 
            WHERE raison_retrait IS NULL AND operation = @operation AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            cmd.Parameters.AddWithValue("@operation", "sortie");
            cmd.Parameters.AddWithValue("@monnaie", "CDF");
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                valeur = 0;
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    valeur += Convert.ToDouble(dr[3].ToString());
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[5].ToString();
                }
                TotalRapport(r, 3, valeur, "Sorties CDF");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Sorties en USD
            cmdtxt = @"SELECT idflux, date_operation, numpiece, montant, libelle, beneficiaire 
            FROM Fluxtresorerie 
            WHERE raison_retrait IS NULL AND operation = @operation AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            cmd.Parameters.AddWithValue("@operation", "sortie");
            cmd.Parameters.AddWithValue("@monnaie", "USD");
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                valeur = 0;
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    valeur += Convert.ToDouble(dr[3].ToString());
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[5].ToString();
                }
                TotalRapport(r, 4, valeur, "Sorties USD");
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.IndianRed;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.IndianRed;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = "Solde CDF/USD";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = Convert.ToDouble(r.dgvRapport.Rows[lignetotaux[0]].Cells[3].Value) -
                                                                          Convert.ToDouble(r.dgvRapport.Rows[lignetotaux[2]].Cells[3].Value);
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = Convert.ToDouble(r.dgvRapport.Rows[lignetotaux[1]].Cells[4].Value) -
                                                                          Convert.ToDouble(r.dgvRapport.Rows[lignetotaux[3]].Cells[4].Value);

        }
        private double SommeFluxTreso(string operation, string monnaie, string affectation)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montant) 
                FROM Fluxtresorerie
                WHERE raison_retrait IS NULL AND affectation = '" + affectation + "' AND operation= '" + operation + "' AND monnaie = '" + monnaie + "'";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    valeur = Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return valeur;
        }
        public void SoldeTreso(TresoFlux f)
        {
            f.lblCDF.Text = (SommeFluxTreso("entrée", "CDF", f.affectation) - SommeFluxTreso("sortie", "CDF", f.affectation)).ToString("0.00");
            f.lblUSD.Text = (SommeFluxTreso("entrée", "USD", f.affectation) - SommeFluxTreso("sortie", "USD", f.affectation)).ToString("0.00");
        }
        public void ComptabiliserFlux(TresoFlux f, ComptaEcriture c)
        {
            if (f.cboOperation.Text != "" && f.dgvFlux.RowCount != 0)
            {
                if(f.cboOperation.Text == "entrée")
                {
                    //ajouter la ligne de débit
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = "RAS";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "Recettes";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].ReadOnly = true;
                    //ajouter les rubriques au crédit
                    valeur = 0;
                    for (int i = 0; i < f.dgvFlux.RowCount; i++)
                    {
                        c.dgvEcriture.Rows.Add();
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = f.dgvFlux.Rows[i].Cells[2].Value;
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = f.dgvFlux.Rows[i].Cells[6].Value;
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                        if (f.dgvFlux.Rows[i].Cells[4].Value.ToString() == "CDF")
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value = f.dgvFlux.Rows[i].Cells[3].Value;
                        else
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value = Convert.ToDouble(f.dgvFlux.Rows[i].Cells[3].Value.ToString()) * f.taux;
                        valeur += Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value.ToString());
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].ReadOnly = true;                    
                    }
                    //ajouter la somme au débit
                    c.dgvEcriture.Rows[0].Cells[3].Value = valeur;
                }
                else
                {
                    //ajouter les rubriques au débit
                    valeur = 0;
                    for (int i = 0; i < f.dgvFlux.RowCount; i++)
                    {
                        if (f.dgvFlux.Rows[i].Cells[7].Value == null)
                        {
                            c.dgvEcriture.Rows.Add();
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = f.dgvFlux.Rows[i].Cells[2].Value;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = f.dgvFlux.Rows[i].Cells[6].Value;
                            if (f.dgvFlux.Rows[i].Cells[4].Value.ToString() == "CDF")
                                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = f.dgvFlux.Rows[i].Cells[3].Value;
                            else
                                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = Convert.ToDouble(f.dgvFlux.Rows[i].Cells[3].Value.ToString()) * f.taux;

                            valeur += Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value.ToString());
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value = 0;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].ReadOnly = true;
                        }                        
                    }
                    //ajouter la ligne de crébit
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = "RAS";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "Dépenses";
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = 0;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value = valeur;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].ReadOnly = true;
                }
                if(c.dgvEcriture.RowCount != 0)
                {
                    c.StartPosition = FormStartPosition.CenterScreen;
                    c.Show();
                }
            }
            else MessageBox.Show("Spécifiez le type d'opération concernée par la comptabilisation et affichez le résultat", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
