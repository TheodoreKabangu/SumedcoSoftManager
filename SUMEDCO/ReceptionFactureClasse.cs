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
    public class ReceptionFactureClasse
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        bool cmdStatut;
        string chaine = "", cmdtxt = "", valeurchaine = "";
        int id = 0;
        double valeur;

        ClasseExercice exer = new ClasseExercice();
        ClasseElements ce = new ClasseElements();
        public void RechercheService(DataGridView dgv, string service, string statut_patient)
        {
            con.Open();
            try
            {
                if (statut_patient == "nouveau")
                    cmdtxt = @"SELECT idservice, nomservice, prixservice, numcompte FROM Service WHERE nomservice IN ('Consultation nouveau cas','Consultation urgence')";
                else if (statut_patient == "ancien")
                    cmdtxt = @"SELECT idservice, nomservice, prixservice, numcompte FROM Service WHERE nomservice IN ('Consultation ancien cas','Consultation urgence')";
                else if (statut_patient == "urgence")
                    cmdtxt = @"SELECT idservice, nomservice, prixservice, numcompte FROM Service WHERE nomservice IN ('Consultation urgence')";
                else
                    cmdtxt = @"SELECT idservice, nomservice, prixservice, numcompte FROM Service WHERE nomservice LIKE '" + service.Replace("'", "") + "%' AND nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') ORDER BY nomservice";
                
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = 1;
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            dgv.ClearSelection();
        }
        public void FactureService(ReceptionMDI r, ReceptionFacturation childForm)
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
        
        bool ajoutvalide;
        public bool ValeurInexistanteDGV(DataGridView dgv, int id_col, string val_comp, int total_ligne)
        {
            ajoutvalide = true;
            for (int j = 0; j < total_ligne; j++)
            {
                if (val_comp == dgv.Rows[j].Cells[id_col].Value.ToString())
                {
                    ajoutvalide = false;
                    MessageBox.Show("L'élément sélectionné existe déjà sur la facture", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    j += dgv.RowCount;
                }
            }
            return ajoutvalide;
        }
        public void AjouterAlaFacture(DataGridView dgv1, DataGridView dgvFacture, string categorie)
        {
            ajoutvalide = true;
            if (dgvFacture.RowCount > 0)
            {
                ValeurInexistanteDGV(dgvFacture, 0, dgv1.CurrentRow.Cells[0].Value.ToString(), dgvFacture.RowCount - 1);
            }            
            if (ajoutvalide)
            {
                if (dgvFacture.RowCount > 0)
                    dgvFacture.Rows.RemoveAt(dgvFacture.RowCount - 1);
                dgvFacture.Rows.Add();
                dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[0].Value = dgv1.CurrentRow.Cells[0].Value.ToString();
                if (categorie == "service")
                {
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[1].Value = dgv1.CurrentRow.Cells[1].Value.ToString();
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[2].Value = dgv1.CurrentRow.Cells[2].Value.ToString();
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[3].Value = dgv1.CurrentRow.Cells[3].Value.ToString();
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[4].Value = Convert.ToDouble(dgv1.CurrentRow.Cells[2].Value.ToString()) * Convert.ToDouble(dgv1.CurrentRow.Cells[3].Value.ToString());
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[5].Value = dgv1.CurrentRow.Cells[4].Value.ToString();
                }
                else
                {
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}, {2}",
                                                                              dgv1.CurrentRow.Cells[1].Value.ToString(),
                                                                              dgv1.CurrentRow.Cells[2].Value.ToString(),
                                                                              dgv1.CurrentRow.Cells[3].Value.ToString());
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[2].Value = dgv1.CurrentRow.Cells[6].Value.ToString();
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[3].Value = dgv1.CurrentRow.Cells[7].Value.ToString();
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[4].Value = Convert.ToDouble(dgv1.CurrentRow.Cells[6].Value.ToString()) * Convert.ToDouble(dgv1.CurrentRow.Cells[7].Value.ToString());
                    dgvFacture.Rows[dgvFacture.RowCount - 1].Cells[5].Value = dgv1.CurrentRow.Cells[8].Value.ToString();
                }
                ce.TotalColonne(dgvFacture, 4, 1);
            }
        }
        public void RetirerDelaFacture(DataGridView dgv)
        {
            if (dgv.CurrentRow.Index < (dgv.RowCount - 1))
            {
                dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                dgv.Rows.RemoveAt(dgv.RowCount - 1);
                ce.TotalColonne(dgv, 4, 1);
            }
        }
        public void Annuler(ReceptionFacturation f)
        {
            f.chbTypeFcture.Checked = false;
            f.txtPayeur.Clear();
            f.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboSexe.SelectedText = "";
            f.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtTel.Clear();
            f.dgvFacture.Rows.Clear();
            f.btnRetirer.Enabled = false;
            f.btnRetirerTout.Enabled = false;
        }
        public int AjouterPayeur(string noms, string sexe, string tel)
        {
            ajoutvalide = false;
            if (tel == "") tel = "RAS";
            id = ce.NouveauID("payeur");

            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Patient (idpatient, noms, sexe, telephone) values (@idpatient, @noms, @sexe, @telephone)", con);
                cmd.Parameters.AddWithValue("@idpatient", id);
                cmd.Parameters.AddWithValue("@noms", noms);
                cmd.Parameters.AddWithValue("@sexe", sexe);
                cmd.Parameters.AddWithValue("@telephone", tel);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                ajoutvalide = true;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ajoutvalide = false;
            }
            con.Close();
            return id;
        }
        public bool AjouterRecette(string statut_facture, string date, string numcompte, string libelle, int qtedem, double prix, string categorie, int idpayeur)
        {
            ajoutvalide = false;
            id = ce.NouveauID("recette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (statut_facture == "différé")
                {
                    cmd = new SqlCommand("insert into Recette_ (idrecette, statut_facture, date_operation, libelle, qtedem, prix, categorie, idpatient,  statut_caisse, numcompte) values (@idrecette, @statut_facture, @date_operation, @libelle, @qtedem, @prix, @categorie, @idpatient, @statut_caisse, @numcompte)", con);
                    cmd.Parameters.AddWithValue("@statut_caisse", "OK");
                }
                else
                    cmd = new SqlCommand("insert into Recette_ (idrecette, statut_facture, date_operation, libelle, qtedem, prix, categorie, idpatient, numcompte) values (@idrecette, @statut_facture, @date_operation, @libelle, @qtedem, @prix, @categorie, @idpatient, @numcompte)", con);
                cmd.Parameters.AddWithValue("@idrecette", id);
                cmd.Parameters.AddWithValue("@statut_facture", statut_facture);
                cmd.Parameters.AddWithValue("@date_operation", date);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@libelle", libelle);
                cmd.Parameters.AddWithValue("@qtedem", qtedem);
                cmd.Parameters.AddWithValue("@prix", prix);
                cmd.Parameters.AddWithValue("@categorie", categorie);
                cmd.Parameters.AddWithValue("@idpatient", idpayeur);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                ajoutvalide = true;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ajoutvalide = false;
            }
            con.Close();
            return ajoutvalide;
        }
        public void EnregistrerFacureService(ReceptionFacturation f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.txtPayeur.Enabled)
                {

                    //Ajouter le payeur
                    f.idpayeur = AjouterPayeur(f.txtPayeur.Text, f.cboSexe.Text, f.txtTel.Text);

                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount-1; i++)
                    {
                        AjouterRecette(
                            f.type_facture, 
                            f.lblDate.Text, 
                            f.dgvFacture.Rows[i].Cells[5].Value.ToString(), 
                            f.dgvFacture.Rows[i].Cells[1].Value.ToString(), 
                            Convert.ToInt32(f.dgvFacture.Rows[i].Cells[3].Value), 
                            Convert.ToDouble(f.dgvFacture.Rows[i].Cells[2].Value), 
                            "service", 
                            f.idpayeur);
                    }
                }
                else
                {
                    //Ajout des recettes pour ancien cas
                    for (int i = 0; i < f.dgvFacture.RowCount-1; i++)
                    {
                        AjouterRecette(
                            f.type_facture,
                            f.lblDate.Text,
                            f.dgvFacture.Rows[i].Cells[5].Value.ToString(),
                            f.dgvFacture.Rows[i].Cells[1].Value.ToString(),
                            Convert.ToInt32(f.dgvFacture.Rows[i].Cells[3].Value),
                            Convert.ToDouble(f.dgvFacture.Rows[i].Cells[2].Value),
                            "service",
                            f.idpayeur);
                    }                  
                }
                if (ajoutvalide)
                {
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(f);
                }
            }
            else
                MessageBox.Show("Aucune ligne de facture n'a été trouvée", "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Annuler(PharmacieFacturation f)
        {
            f.chbTypeFcture.Checked = false;
            f.txtPayeur.Clear();
            f.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboSexe.SelectedText = "";
            f.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtTel.Clear();
            f.dgvFacture.Rows.Clear();
            f.btnRetirer.Enabled = false;
            f.btnRetirerTout.Enabled = false;
        }
        public void EnregistrerFactureProduit(PharmacieFacturation f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.txtPayeur.Enabled)
                {

                    //Ajouter le payeur
                    f.idpayeur = AjouterPayeur(f.txtPayeur.Text, f.cboSexe.Text, f.txtTel.Text);

                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount-1; i++)
                    {
                        AjouterRecette(
                            f.type_facture,
                            f.lblDate.Text,
                            f.dgvFacture.Rows[i].Cells[5].Value.ToString(),
                            f.dgvFacture.Rows[i].Cells[1].Value.ToString(),
                            Convert.ToInt32(f.dgvFacture.Rows[i].Cells[3].Value),
                            Convert.ToDouble(f.dgvFacture.Rows[i].Cells[2].Value),
                            "produit",
                            f.idpayeur);
                    }
                }
                if (ajoutvalide)
                {
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(f);
                }
            }
            else
                MessageBox.Show("Aucune ligne de facture n'a été trouvée", "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        public void FactureProduit(PharmacieMDI r, PharmacieFacturation child)
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
                child.idutilisateur = r.idutilisateur;
                child.poste = "pharmacie";
                child.idpharma = r.idpharma;
                child.txtPayeur.Enabled = true;
                child.cboSexe.Enabled = true;
                child.txtTel.Enabled = true;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void RechercheProduit(DataGridView dgv, string produit, string motif, int idpharma)
        {
            //recuperer le numcompte de produits
            chaine = ce.TrouverId("numcompte", "Ventes des médicaments").ToString();
            con.Open();
            try
            {
                if(motif == "facture")
                {
                    cmdtxt = @"SELECT s.idstock, nomproduit, forme, dosage, s.qtestock, sph.qtestock, prixunitaire
                    FROM LigneStock s
                    JOIN Produit p ON p.idproduit = s.idproduit
                    JOIN LigneStockPharma sph ON s.idstock = sph.idstock
                    JOIN Pharmacie ph ON ph.idpharma = sph.idpharma
                    WHERE nomproduit LIKE '" + produit.Replace("'", "") + "%' AND ph.idpharma = " + idpharma + " ORDER BY nomproduit";
                    cmd = new SqlCommand(cmdtxt, con);
                    dr = cmd.ExecuteReader();
                    dgv.Rows.Clear();
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[6].Value = dr[6].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[7].Value = 1;
                        dgv.Rows[dgv.RowCount - 1].Cells[8].Value = chaine;
                    }
                }
                else
                {
                    cmdtxt = @"SELECT s.idstock, nomproduit, forme, dosage, s.qtestock, prixunitaire
                    FROM LigneStock s
                    JOIN Produit p ON p.idproduit = s.idproduit
                    WHERE nomproduit LIKE '" + produit.Replace("'", "") + "%' ORDER BY nomproduit";
                    cmd = new SqlCommand(cmdtxt, con);
                    dr = cmd.ExecuteReader();
                    dgv.Rows.Clear();
                    while (dr.Read())
                    {
                        dgv.Rows.Add();
                        dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                        dgv.Rows[dgv.RowCount - 1].Cells[6].Value = "701100"; //a modifier selon le plan de comptes
                    }
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public void AfficherRecette(PharmacieVente p, string motif)
        {
            p.btnValider.Enabled = false;
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (p.txtNom.Text != "")
                    {
                        cmdtxt = @"SELECT idrecette AS ID, noms AS Patient, date_operation AS Date, libelle AS Libellé, qtedem AS Qté, statut_caisse AS Caisse, servi AS Servi 
                        FROM Recette_ r
                        JOIN Patient p ON r.idpatient = p.idpatient
                        WHERE noms LIKE '" + p.txtNom.Text.Replace("'", "") + "%' AND categorie = 'produit' AND statut_caisse = 'OK' AND date_operation BETWEEN @dateDe AND @dateA";
                    }
                    else
                    {
                        cmdtxt = @"SELECT idrecette AS ID, noms AS Patient, date_operation AS Date, libelle AS Libellé, qtedem AS Qté, statut_caisse AS Caisse, servi AS Servi  
                        FROM Recette_ r
                        JOIN Patient p ON r.idpatient = p.idpatient
                        WHERE date_operation BETWEEN @dateDe AND @dateA AND categorie = 'produit' AND statut_caisse = 'OK'";
                    }
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", p.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", p.dtpDateA.Text);
                }
                else
                {
                        cmdtxt = @"SELECT idrecette AS ID, noms AS Patient, date_operation AS Date, libelle AS Libellé, qtedem AS Qté, statut_caisse AS Caisse, servi AS Servi 
                        FROM Recette_ r
                        JOIN Patient p ON r.idpatient = p.idpatient
                        WHERE date_operation = '" + DateTime.Now.ToShortDateString() + "' AND categorie = 'produit' AND statut_caisse = 'OK'";
                        cmd = new SqlCommand(cmdtxt, con);
                }

                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                p.dgvRecette.DataSource = dt;
                p.dgvRecette.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                p.dgvRecette.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            p.dgvRecette.ClearSelection();
            if (p.dgvRecette.RowCount != 0)
                p.btnValider.Enabled = true;
        }
        
        RecetteClasse rc = new RecetteClasse();
        string[] tab_chaine;
        private void AjouterSortiePharmacie(string motif, DateTime datejour, int idstock, int qtedem, int qteservie, int idposte)
        {
            id = ce.NouveauID("sortiepha");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (motif == "perte" || motif == "vente")
                {
                    cmd = new SqlCommand("insert into SortiePharma (idsortie, date_jour, idstockph, qte_dem, qteservie, motif) values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif)", con);
                    cmd.Parameters.AddWithValue("@motif", motif);
                }
                else
                {
                    cmd = new SqlCommand("insert into SortiePharma values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif, @idposte)", con);
                    cmd.Parameters.AddWithValue("@motif", "servir une demande");
                    cmd.Parameters.AddWithValue("@idposte", idposte);
                }
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date_jour", datejour);
                cmd.Parameters.AddWithValue("@idstock", idstock);
                cmd.Parameters.AddWithValue("@qte_dem", qtedem);
                cmd.Parameters.AddWithValue("@qteservie", qteservie);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ValiderVente(PharmacieVente p)
        {
            tab_chaine = p.dgvRecette.CurrentRow.Cells[3].Value.ToString().Split(',');
            for (int i = 0; i < tab_chaine.Length; i++)
            {
                tab_chaine[i] = tab_chaine[i].Trim();
            }
            con.Open();
            try
            {
                cmdtxt = @"SELECT idstockph, nomproduit, forme, dosage, sp.qtestock
                FROM LigneStockPharma sp
                JOIN LigneStock s ON sp.idstock= s.idstock
                JOIN Produit p ON s.idproduit= p.idproduit
                WHERE nomproduit = @produit AND forme = @forme AND dosage = @dosage AND idpharma = @idpharma";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@produit", tab_chaine[0]);
                cmd.Parameters.AddWithValue("@forme", tab_chaine[1]);
                cmd.Parameters.AddWithValue("@dosage", tab_chaine[2]);
                cmd.Parameters.AddWithValue("@idpharma", p.idpharma);
                dr = cmd.ExecuteReader();
                p.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvStock.Rows.Add();
                    p.dgvStock.Rows[0].Cells[0].Value = dr[0].ToString();
                    p.dgvStock.Rows[0].Cells[1].Value = string.Format("{0}, {1}, {2}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    p.dgvStock.Rows[0].Cells[2].Value = dr[4].ToString();
                    p.dgvStock.Rows[0].Cells[3].Value = p.dgvRecette.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

            if (p.dgvStock.RowCount != 0)
            {
                if (Convert.ToInt32(p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[3].Value) > Convert.ToInt32(p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[2].Value))
                    MessageBox.Show("Stock local insuffisant!", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    //Ajouter une sortie pharma
                    AjouterSortiePharmacie(
                        "vente",
                        DateTime.Now.Date,
                        Convert.ToInt32(p.dgvStock.Rows[0].Cells[0].Value),
                        Convert.ToInt32(p.dgvStock.Rows[0].Cells[3].Value),
                        Convert.ToInt32(p.dgvStock.Rows[0].Cells[3].Value),
                        0
                        );
                    rc.RecetteServiOK(Convert.ToInt32(p.dgvRecette.CurrentRow.Cells[0].Value), p.idutilisateur, "OK");
                }
            }
            p.btnValider.Enabled = false;
        }

    }
}
