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
using Microsoft.Reporting.WinForms;

namespace SUMEDCO
{
    class ClassStock
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        bool cmdStatut;
        string cmdtxt = "",
            chaine ="";
        int id= 0;
        float valeur = 0F;
        private Form activeForm = null;


        #region METHODES GENERALES
        public int TrouverId(string motif, string nom)
        {
            id = 0;
            switch (motif)
            {
                case "user": cmdtxt = "select id from Utilisateur where utilisateur = @nom"; break;
                case "produit": cmdtxt = "select idproduit from Produit where nomproduit = @nom"; break;
                case "produitstock": cmdtxt = "select idproduit from LigneStock where idstock = @nom"; break;
                case "autreproduit": cmdtxt = "select idproduit from ProduitAutreStock where nomproduit = @nom"; break;
                case "utilisateur": cmdtxt = "select id from Utilisateur where poste = @nom"; break;
                case "categorie": cmdtxt = "select idcat from CategorieProduit where categorie = @nom"; break;
                case "poste": cmdtxt = "select idposte from ServiceDemandeur where nomposte = @nom"; break;
                case "pharma": cmdtxt = "select idpharma from Pharmacie where designation = @nom"; break;
            }
            con.Open();
            try
            {
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@nom", nom);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public string TrouverNom(string motif, int id)
        {
            chaine = "";
            switch (motif)
            {
                case "produit": cmdtxt = "select nomproduit from Produit where idproduit = @id"; break;
            }
            con.Open();
            try
            {
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                dr.Read();
                chaine = dr[0].ToString();
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return chaine;
        }
        public int NouveauID(string concerne)
        {
            id = 0;
            switch (concerne)
            {
                case "user": cmdtxt = "select max(id) from Utilisateur"; break;
                case "produit": cmdtxt = "select max(idproduit) from Produit"; break;
                case "stock": cmdtxt = "select max(idstock) from LigneStock"; break;
                case "pharmacie": cmdtxt = "select max(idpharma) from Pharmacie"; break;
                case "stockpharma": cmdtxt = "select max(idstockpharma) from LigneStockPharma"; break;
                case "autreproduit": cmdtxt = "select max(idproduit) from ProduitAutreStock"; break;
                case "commande": cmdtxt = "select max(idcom) from LigneCommande"; break;
                case "commandepharma": cmdtxt = "select max(idcomph) from CommandePharma"; break;
                case "appro": cmdtxt = "select max(idappro) from LigneAppro"; break;
                case "appro2": cmdtxt = "select max(idappro) from LigneApproAutre"; break;
                case "appropharma": cmdtxt = "select max(idapproph) from ApproPharma"; break;
                case "requisition": cmdtxt = "select max(idrequisition) from LigneRequisition"; break;
                case "requisitionautre": cmdtxt = "select max(idrequisition) from LigneRequisitionAutre"; break;
                case "poste": cmdtxt = "select max(idposte) from ServiceDemandeur"; break;
                case "stockpha": cmdtxt = "select max(idstockph) from LigneStockPharma"; break;
                case "sortie": cmdtxt = "select max(idsortie) from SortieStock"; break;
            }
            cmd = new SqlCommand(cmdtxt, con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() == "")
                    id = 1;
                else
                    id = int.Parse(dr[0].ToString()) + 1;// +1 pour un nouveau id
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        #endregion

        #region CONNEXION
        public bool TestMotdePass(FormConnexionPass c)
        {
            cmdStatut = false;
            con.Open();
            try
            {
                cmd = new SqlCommand("select motdepasse from Utilisateur where utilisateur = @utilisateur and motdepasse = @mot and poste = @poste", con);
                cmd.Parameters.AddWithValue("@utilisateur", c.txtUtilisateur.Text);
                cmd.Parameters.AddWithValue("@mot", c.txtAncienMdPass.Text);
                cmd.Parameters.AddWithValue("@poste", c.poste);
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    cmdStatut = true;
                }
                else
                    MessageBox.Show("Vérifiez que l'utilisateur et l'ancien mot de passe correspondent au poste sélectionné ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return cmdStatut;
        }
        public void Connexion(FormConnexion c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select id, utilisateur, motdepasse, poste, specification from Utilisateur where utilisateur = @utilisateur and motdepasse = @mot and poste = @poste", con);
                cmd.Parameters.AddWithValue("@utilisateur", c.txtUtilisateur.Text);
                cmd.Parameters.AddWithValue("@mot", c.txtMotdePass.Text);
                cmd.Parameters.AddWithValue("@poste", c.poste);
                dr = cmd.ExecuteReader();
                if(dr.Read() == true)
                {
                    c.access_autorise = true;
                    id = int.Parse(dr[0].ToString());
                    chaine = dr[4].ToString();
                }
                else
                    MessageBox.Show("Vérifiez que l'utilisateur et le mot de passe correspondent au poste sélectionné ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if(c.access_autorise)
            {
                    if (c.poste == "admin")
                    {
                        if (chaine == c.cboUtilisateur.Text)
                        {
                            MFormAdmin ad = new MFormAdmin();
                            ad.utilisateur = c.cboUtilisateur.Text;
                            RefuserAutorisation("infirmier - réception");
                            RefuserAutorisation("infirmier - abonné");
                            RefuserAutorisation("infirmier - médecin");
                            RefuserAutorisation("pharmacie - caisse");
                            ad.Show();
                        }
                        else
                        {
                            c.access_autorise = false;
                            MessageBox.Show("Accès refusé", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (c.poste == "réception")
                    {
                        MFormReception r = new MFormReception();
                        r.idutilisateur = id;
                        RefuserAutorisation("infirmier - réception");
                        r.Show();
                    }
                    else if (c.poste == "recette")
                    {
                        MFormRecette rec = new MFormRecette();
                        rec.idutilisateur = id;
                        RefuserAutorisation("pharmacie - caisse");
                        rec.Show();
                    }
                    else if (c.poste == "infirmier")
                    {
                        FormAutorisation aut = new FormAutorisation();
                        aut.idutilisateur = id;
                        aut.poste = "infirmier";
                        aut.Show();

                    }
                    else if (c.poste == "médecin")
                    {
                        if (chaine == c.medecin)
                        {
                            MFormConsultation cons = new MFormConsultation();
                            cons.idmedecin = c.idmedecin;
                            cons.idutilisateur = id;
                            RefuserAutorisation("infirmier - médecin");
                            cons.Show();
                        }
                        else
                        {
                            c.access_autorise = false;
                            MessageBox.Show("Accès refusé", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (c.poste == "abonné")
                    {
                        MFormAbonne ab = new MFormAbonne();
                        ab.idutilisateur = id;
                        RefuserAutorisation("infirmier - abonné");
                        ab.Show();
                    }
                    else if (c.poste == "dépense")
                    {
                        MFormTreso d = new MFormTreso();
                        d.idutilisateur = id;
                        d.Show();
                    }
                    else if (c.poste == "comptable")
                    {
                        MFormComptabilite co = new MFormComptabilite();
                        co.idutilisateur = id;
                        RefuserAutorisation("infirmier - réception");
                        RefuserAutorisation("infirmier - abonné");
                        RefuserAutorisation("infirmier - médecin");
                        RefuserAutorisation("pharmacie - caisse");
                        co.Show();
                    }
                    else if (c.poste == "pharmacie")
                    {
                        FormAutorisation aut = new FormAutorisation();
                        aut.idutilisateur = id;
                        aut.poste = "pharmacie";
                        aut.Show();
                    }
                    else if (c.poste == "stock")
                    {
                        MFormStock s = new MFormStock();
                        s.idutilisateur = id;
                        s.Show();
                    }
                    else if (c.poste == "imagerie")
                    {
                        MFormEchoRadio s = new MFormEchoRadio();
                        s.idutilisateur = id;
                        s.Show();
                    }
                    else if (c.poste == "labo")
                    {
                        //MFormStock s = new MFormStock();
                        //s.idutilisateur = id;
                        //s.Show();
                    }
                    
                    if (c.access_autorise)
                        c.Close();
            }
        }
        public void ChargerAutorisation(ComboBox combo, string motif)
        {
            switch (motif)
            {
                case "infirmier": cmd = new SqlCommand("select libelle from Autorisations where libelle LIKE 'infirmier%'", con); break;
                case "pharmacie": cmd = new SqlCommand("select libelle from Autorisations where libelle LIKE 'pharmacie%'", con); break;
                case "Admin": cmd = new SqlCommand("select libelle from Autorisations", con); break;
            }
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                combo.Items.Clear();
                while (dr.Read())
                {
                    combo.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void RefuserAutorisation(string compte)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Autorisations set etat = 'refusé' where libelle = '"+compte+"'", con);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ActiverAutorisation(string compte)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Autorisations set etat = 'autorisé' where libelle = '" + compte + "'", con);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Autorisation accordée", "Poste utilisqteur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ModifierMotdePasse(FormConnexion c, FormConnexionPass cp)
        {
            cp.poste = c.poste;           
            cp.txtUtilisateur.Select();
            cp.ShowDialog();
            if(cp.connexion)
            {
                c.txtUtilisateur.ForeColor = Color.Black;
                c.txtMotdePass.ForeColor = Color.Black;
                c.txtMotdePass.UseSystemPasswordChar = true;
                c.txtUtilisateur.Text = cp.txtUtilisateur.Text;
                c.txtMotdePass.Text = cp.txtConfirmerMdPass.Text;
                c.btnConnexion.Select();
            }
            cp.Close();
        }
        #endregion

        #region ADMIN
        public void AfficherSousForm(MFormAdmin a, Form childForm)
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
        public void AfficherSousForm(FormAdmin a, Form childForm)
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
        public void AfficherSousForm(MFormAdmin a, FormStockProduit childForm)
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
            childForm.poste = "admin";
            childForm.Show();
        }
        public void ChargerRubriques(FormAdminRapportCas r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '7061%' OR numcompte LIKE '70780%'", con);
                dr = cmd.ExecuteReader();
                r.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRecette.Rows.Add();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = r.dgvRecette.RowCount;
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AbonneTypePatient(FormAdminRapportCas r)
        {
            r.btnRecherche.Enabled = true;
            for (int i = r.dgvRecette.ColumnCount-1; i > 2; i--)
            {
                r.dgvRecette.Columns.RemoveAt(i);
            }
            con.Open();
            try
            {
                if (r.cboMotif.Text.ToLower() == "abonné")
                    cmd = new SqlCommand("SELECT nomentreprise FROM Entreprise", con);
                else
                    cmd = new SqlCommand("SELECT nomtype FROM TypePatient", con);
                dr = cmd.ExecuteReader();
                id = 0;
                while (dr.Read())
                {
                    r.dgvRecette.Columns.Add("column_"+id, dr[0].ToString());
                    id++;
                    for (int i = 0; i < r.dgvRecette.RowCount; i++)
                    {
                        r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = "0";
                    }
                }
                if (r.cboMotif.Text.ToLower() != "abonné")
                {
                    r.dgvRecette.Columns.Add("column_" + id, "Autre");
                    for (int i = 0; i < r.dgvRecette.RowCount; i++)
                    {
                        r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = "0";
                    }
                    id++;
                }
                r.dgvRecette.Columns.Add("column_" + id, "Total");
                for (int i = 0; i < r.dgvRecette.RowCount; i++)
                {
                    r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }       
        
        int totalCas = 0;
        public void AfficherCas(FormAdminRapportCas r)
        {
            r.btnRecherche.Enabled = false;
            if (r.cboMotif.Text.ToLower() == "abonné")
            {               
                for (int i = 0; i < r.dgvRecette.RowCount; i++)
                {
                    totalCas = 0;
                    for (int j = 3; j < r.dgvRecette.ColumnCount - 1; j++)
                    {
                        con.Open();
                        try
                        {
                            cmd = new SqlCommand("SELECT COUNT(rs.idrecette) FROM RecetteService rs JOIN Service s ON rs.idservice = s.idservice JOIN Recette r ON r.idrecette = rs.idrecette JOIN Payeur p ON r.idpayeur = p.idpayeur JOIN Patient pa ON p.idpatient = pa.idpatient JOIN Entreprise e ON pa.identreprise = e.identreprise WHERE s.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND e.nomentreprise = '" + r.dgvRecette.Columns[j].HeaderText + "' AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                r.dgvRecette.Rows[i].Cells[j].Value = dr[0].ToString();
                                totalCas += Convert.ToInt32(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = totalCas;
                }
                
            }
            else
            {
                for (int i = 0; i < r.dgvRecette.RowCount; i++)
                {
                    totalCas = 0;
                    for (int j = 3; j < r.dgvRecette.ColumnCount - 1; j++)
                    {
                        con.Open();
                        try
                        {
                            if (j < r.dgvRecette.ColumnCount - 2)
                                cmd = new SqlCommand("SELECT COUNT(rs.idrecette) FROM RecetteService rs JOIN Service s ON rs.idservice = s.idservice JOIN Recette r ON r.idrecette = rs.idrecette JOIN Payeur p ON r.idpayeur = p.idpayeur JOIN Patient pa ON p.idpatient = pa.idpatient JOIN TypePatient t ON pa.idtype = t.idtype WHERE s.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND t.nomtype = '" + r.dgvRecette.Columns[j].HeaderText + "' AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                            else
                                cmd = new SqlCommand("SELECT COUNT(rs.idrecette) FROM RecetteService rs JOIN Service s ON rs.idservice = s.idservice JOIN Recette r ON r.idrecette = rs.idrecette JOIN Payeur p ON r.idpayeur = p.idpayeur WHERE s.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND p.idpatient is NULL AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                r.dgvRecette.Rows[i].Cells[j].Value = dr[0].ToString();
                                totalCas += Convert.ToInt32(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = totalCas;
                }
            }
        }

        public void AfficherResume(FormAdminRapportCasMedecin r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idmedecin, nommedecin FROM Medecin", con);
                dr = cmd.ExecuteReader();
                r.dgvResume.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvResume.Rows.Add();
                    r.dgvResume.Rows[r.dgvResume.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvResume.Rows[r.dgvResume.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvResume.Rows[r.dgvResume.RowCount - 1].Cells[2].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (r.dgvResume.RowCount != 0)
            {
                for (int i = 0; i < r.dgvResume.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("SELECT COUNT(c.idconsultation) FROM Consultation c JOIN PriseSigneVitaux psv ON c.idprise = psv.idprise JOIN Recette r ON psv.idrecette = r.idrecette JOIN RecetteService rs ON r.idrecette = rs.idrecette JOIN Service s ON s.idservice = rs.idservice WHERE idmedecin = '" + r.dgvResume.Rows[i].Cells[0].Value.ToString() + "' AND s.nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') AND c.date_consultation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            r.dgvResume.Rows[i].Cells[2].Value = dr[0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                AfficherGraphique(r);
            }


        }
        private void AfficherGraphique(FormAdminRapportCasMedecin a)
        {
            List<ResumeRapportCas> list = new List<ResumeRapportCas>();
            list.Clear();

            for (int i = 0; i < a.dgvResume.RowCount; i++)
            {
                ResumeRapportCas ligne = new ResumeRapportCas
                {
                    idmedecin = Convert.ToInt32(a.dgvResume.Rows[i].Cells[0].Value),
                    nommedecin = a.dgvResume.Rows[i].Cells[1].Value.ToString(),
                    nbcas = Convert.ToInt32(a.dgvResume.Rows[i].Cells[2].Value),
                };
                list.Add(ligne);
            }
            rs.Name = "DataSet1";
            rs.Value = list;
            a.reportViewer1.LocalReport.DataSources.Clear();
            a.reportViewer1.LocalReport.DataSources.Add(rs);
            a.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.RapportCasMedecin.rdlc";
            a.reportViewer1.RefreshReport();
        }
        #endregion

        #region PRODUIT
        public void ChargerCombo(ComboBox combo, string motif, int id)
        {
            switch (motif)
            {
                case "produit": cmd = new SqlCommand("select nomproduit from Produit", con); break;
                case "stock": 
                    cmd = new SqlCommand("select idstock from LigneStock where idproduit= @idproduit", con);
                    cmd.Parameters.AddWithValue("@idproduit", id);
                    break;
            }
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                combo.Items.Clear();
                while (dr.Read())
                {
                    combo.Items.Add(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public int VerifierNomProduit(string nomproduit)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT COUNT(nomproduit) FROM Produit WHERE nomproduit = @nomproduit", con);                
                cmd.Parameters.AddWithValue("@nomproduit", nomproduit);
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
        public void Enregistrer(FormStockNouveau s)
        {
            if(s.txtProduit.Text !="" && s.cboCategorie.Text != "" && s.txtDosage.Text != "" && s.cboForme.Text != "" && s.txtCMM.Text != "")
            {
                if (VerifierNomProduit(s.txtProduit.Text) == 0)
                {
                    s.idproduit = NouveauID("produit");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Produit values (@id, @nom, @idcat)", con);
                        cmd.Parameters.AddWithValue("@id", s.idproduit);
                        cmd.Parameters.AddWithValue("@nom", s.txtProduit.Text);
                        cmd.Parameters.AddWithValue("@idcat", s.idcat);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    AjouterStock(s);
                }
                else MessageBox.Show("Le nom du produit fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierProduit(FormStockNouveau s)
        {
            s.btnModifier.Enabled = false;
            if (s.txtProduit.Text != "" && s.cboCategorie.Text != "")
            {
                if (VerifierNomProduit(s.txtProduit.Text) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update Produit set nomproduit = @nom, idcat = @idcat where idproduit = @id", con);
                        cmd.Parameters.AddWithValue("@id", s.idproduit);
                        cmd.Parameters.AddWithValue("@nom", s.txtProduit.Text);
                        cmd.Parameters.AddWithValue("@idcat", s.idcat);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    Annuler(s);
                }
                else MessageBox.Show("Le nom du produit fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public int CompterStockProduit(int idproduit)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idstock) from LigneStock where idproduit = @idproduit", con); cmd.Parameters.AddWithValue("@idproduit", idproduit);
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
        public void SupprimerProduit(FormStockNouveau s)
        {
            s.btnSupprimer.Enabled = false;
            if (CompterStockProduit(s.idproduit) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Produit where idproduit = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idproduit);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    s.dgvProduit.Rows.RemoveAt(s.dgvProduit.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
                MessageBox.Show("Ce produit est déjà impliqué dans les stocks,\npour raison de cohérence, il ne peut être supprimé","Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Recuperer(FormProduitPharma p)
        {
            if(p.dgvProduit.RowCount != 0)
            {
                p.idproduit = int.Parse(p.dgvProduit.CurrentRow.Cells[0].Value.ToString());
                p.txtProduit.Text = p.dgvProduit.CurrentRow.Cells[1].Value.ToString();
                p.btnModifier.Enabled = true;
                p.btnSupprimer.Enabled = true;
                p.btnEnregistrer.Enabled = false;
            }
        }
        public void Afficher(FormProduitPharma p, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if(p.txtProduit.Text != "")
                        cmd = new SqlCommand("select * from Produit where nomproduit like '" + p.txtProduit.Text + "%'", con);
                    else
                        cmd = new SqlCommand("select * from Produit", con);
                }
                else
                {
                    cmd = new SqlCommand("select * from Produit where idproduit= @idproduit", con);
                    cmd.Parameters.AddWithValue("@idproduit", p.idproduit);
                }
                dr = cmd.ExecuteReader();
                p.dgvProduit.Rows.Clear();
                while(dr.Read())
                {
                    p.dgvProduit.Rows.Add();
                    p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Annuler(FormProduitPharma p)
        {
            p.txtProduit.Text = "";
            p.dgvProduit.Rows.Clear();
        }
        public void ChargerCompte(TextBox txt, ListBox list, string motif)
        {
            if (txt.Text != "")
            {
                con.Open();
                if(motif=="produit")
                    cmd = new SqlCommand("select distinct nomproduit from Produit, LigneStock where LigneStock.idproduit = Produit.idproduit and qtestock <> 0 and nomproduit like '" + txt.Text + "%'", con);
                else
                    cmd = new SqlCommand("select distinct nomproduit from ProduitAutreStock where qtestock <> 0 and nomproduit like '" + txt.Text + "%'", con);
                dr = cmd.ExecuteReader();
                list.Items.Clear();
                while (dr.Read())
                {
                    list.Items.Add(dr[0].ToString());
                }
                con.Close();
                if (list.Items.Count > 0)
                {
                    list.BringToFront();
                    list.Visible = true;
                }
                else list.Visible = false;
            }
            else list.Visible = false;
        }
        #endregion

        #region STOCK_PRODUIT
        public void Annuler(FormStockNouveau s)
        {
            s.btnModifier.Enabled = false;
            s.btnSupprimer.Enabled = false;
            s.btnEnregistrer.Enabled = true;
            s.btnModifierStock.Enabled = false;
            s.btnSupprimerStock.Enabled = false;
            s.btnAjoutStock.Enabled = false;
            s.txtProduit.Text = "";
            s.txtProduit.Enabled = true;
            s.cboCategorie.Enabled = true;
            s.cboCategorie.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboCategorie.SelectedText = "";
            s.cboCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtDosage.Text = "";
            s.cboForme.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboForme.SelectedText = "";
            s.cboForme.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtCMM.Text = "0";
        }
        public void Afficher(FormStockNouveau s, string motif)
        {
            
        }
        public int CompterMvtStock(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idconsultation) from PrescriptionProduit where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idrecette) from RecetteProduit where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                id += int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public int VerifierLigneStock(int idproduit, string forme, string dosage, string numlot)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT COUNT(idstock) FROM LigneStock where idproduit = @idproduit AND forme = @forme AND dosage= @dosage AND numlot = @numlot", con);
                cmd.Parameters.AddWithValue("@idproduit", idproduit);
                cmd.Parameters.AddWithValue("@forme", forme);
                cmd.Parameters.AddWithValue("@dosage", dosage);
                cmd.Parameters.AddWithValue("@numlot", numlot);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }

        public void AjouterStockPharma(FormStockNouveau s)
        {
            s.idstockpharma = NouveauID("stockpharma");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneStockPharma values (@id, @idpharma, @idstock, @qte)", con);
                cmd.Parameters.AddWithValue("@id", s.idstockpharma);
                cmd.Parameters.AddWithValue("@idpharma", 1);
                cmd.Parameters.AddWithValue("@idstock", s.idstock);
                cmd.Parameters.AddWithValue("@qte", "0");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        
        public void AjouterStock(FormStockNouveau s)
        {
            if (s.txtDosage.Text != "" && s.cboForme.Text != "" && s.txtCMM.Text != "")
            {
                s.idstock = NouveauID("stock");
                if (s.txtCMM.Text == "") s.txtCMM.Text = "0";
                if (s.txtDosage.Text == "") s.txtDosage.Text = "RAS";
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into LigneStock values (@id, @idproduit, @qte, @CMM, @forme, @dosage, @numlot, @expiration, @prix_achat, @prix_vente)", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                    cmd.Parameters.AddWithValue("@idproduit", s.idproduit);
                    cmd.Parameters.AddWithValue("@qte", "0"); // stock initial = 0
                    cmd.Parameters.AddWithValue("@CMM", s.txtCMM.Text);// CMM initial = 0
                    cmd.Parameters.AddWithValue("@forme", s.cboForme.Text);
                    cmd.Parameters.AddWithValue("@dosage", s.txtDosage.Text);
                    cmd.Parameters.AddWithValue("@numlot", "RAS");
                    cmd.Parameters.AddWithValue("@expiration", "RAS");
                    cmd.Parameters.AddWithValue("@prix_achat", "0");
                    cmd.Parameters.AddWithValue("@prix_vente", "0");
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Annuler(s);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void AjouterStock(FormApproAutre s)
        {
            if (s.txtDosage.Text != "" && s.cboForme.Text != "" && s.txtCMM.Text != "")
            {
                s.idstock = NouveauID("stock");
                if (s.txtCMM.Text == "") s.txtCMM.Text = "0";
                if (s.txtDosage.Text == "") s.txtDosage.Text = "RAS";
                if (s.txtNumLot.Text == "") s.txtNumLot.Text = "RAS";
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into LigneStock values (@id, @idproduit, @qte, @CMM, @forme, @dosage, @numlot, @expiration, @prix_achat, @prix_vente)", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                    cmd.Parameters.AddWithValue("@idproduit", s.idproduit);
                    cmd.Parameters.AddWithValue("@qte", s.txtQteAppro.Text); // stock initial = 0
                    cmd.Parameters.AddWithValue("@CMM", s.txtCMM.Text);// CMM initial = 0
                    cmd.Parameters.AddWithValue("@forme", s.cboForme.Text);
                    cmd.Parameters.AddWithValue("@dosage", s.txtDosage.Text);
                    cmd.Parameters.AddWithValue("@numlot", s.txtNumLot.Text);
                    cmd.Parameters.AddWithValue("@expiration", s.expirationlot);
                    cmd.Parameters.AddWithValue("@prix_achat", Convert.ToDouble(s.txtPrixAchat.Text));
                    cmd.Parameters.AddWithValue("@prix_vente", Convert.ToDouble(s.txtPrixVente.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierStock(FormStockNouveau s)
        {
            s.btnModifierStock.Enabled = false;
            if (s.txtDosage.Text != "" && s.cboForme.Text != "" && s.txtCMM.Text != "")
            {
                if (s.txtCMM.Text == "") s.txtCMM.Text = "0";
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update LigneStock set  dosage= @dosage, forme = @forme, CMM= @CMM where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                    cmd.Parameters.AddWithValue("@dosage", s.txtDosage.Text);
                    cmd.Parameters.AddWithValue("@forme", s.cboForme.Text);
                    cmd.Parameters.AddWithValue("@CMM", s.txtCMM.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Annuler(s);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerStock(FormStockNouveau s)
        {
            s.btnSupprimerStock.Enabled = false;
            if (CompterMvtStock(s.idstock) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from LigneStock where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    s.dgvStock.Rows.RemoveAt(s.dgvStock.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
                MessageBox.Show("Ce stock est déjà impliqué dans les entrées/soties,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void DetailsStock(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {

                con.Open();
                try
                {
                    cmd = new SqlCommand("select idproduit, conditionnement, dosage, forme from LigneStock where idstock = @idstock", con);
                    cmd.Parameters.AddWithValue("@idstock", dgv.Rows[i].Cells[2].Value.ToString());
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[3].Value = dr[0].ToString();
                        dgv.Rows[i].Cells[5].Value = dr[1].ToString();
                        dgv.Rows[i].Cells[6].Value = dr[2].ToString();
                        dgv.Rows[i].Cells[7].Value = dr[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[4].Value = TrouverNom("produit", int.Parse(dgv.Rows[i].Cells[3].Value.ToString()));
            }
        }
        public void DetailsStock2(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {

                con.Open();
                try
                {
                    cmd = new SqlCommand("select idproduit, conditionnement, dosage, forme, numlot, prixunitaire from LigneStock where idstock = @idstock", con);
                    cmd.Parameters.AddWithValue("@idstock", dgv.Rows[i].Cells[10].Value.ToString());
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[1].Value = dr[0].ToString();
                        dgv.Rows[i].Cells[3].Value = dr[1].ToString();
                        dgv.Rows[i].Cells[4].Value = dr[2].ToString();
                        dgv.Rows[i].Cells[5].Value = dr[3].ToString();
                        dgv.Rows[i].Cells[6].Value = dr[4].ToString();
                        dgv.Rows[i].Cells[7].Value = dr[5].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[2].Value = TrouverNom("produit", int.Parse(dgv.Rows[i].Cells[1].Value.ToString()));
            }
        }
        public double PrixStock(int idstock, string motif)
        {
            valeur = 0;
            con.Open();
            try
            {
                if(motif == "vente")
                    cmd = new SqlCommand("SELECT COUNT(prixunitaire), SUM(prixunitaire) FROM LigneStock WHERE idstock = @id", con);
                else
                    cmd = new SqlCommand("SELECT COUNT(prix_achat), SUM(prix_achat) FROM LigneStock WHERE idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() != "") 
                    valeur = float.Parse(dr[1].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return valeur;
        }
        public int QteStock(int idstock, string motif)
        {
            id = 0;
            con.Open();
            try
            {
                if (motif == "pharma")
                    cmd = new SqlCommand("select qtestock from LigneStock where idstock = @id", con);
                else
                    cmd = new SqlCommand("select qtestock from ProduitAutreStock where idproduit = @id", con);
                
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public int QteStock2(int idstockpharma)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select qtestockpharma from LigneStockPharma where idstockpharma = @id", con);
                cmd.Parameters.AddWithValue("@id", idstockpharma);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public string DateExpNumLot(string numlot)
        {
            chaine = "";
            con.Open();
            try
            {
                cmd = new SqlCommand("select date_expiration from Lot where numlot = @numlot", con);
                cmd.Parameters.AddWithValue("@numlot", numlot);
                dr = cmd.ExecuteReader();
                dr.Read();
                chaine = dr[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return chaine;
        }
        
        //une méthode vers AbonneProduit
        public void AfficherLigneStock(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[5].Value = TrouverNom("produit", TrouverId("produitstock", dgv.Rows[i].Cells[3].Value.ToString()));
                con.Open();
                try
                {
                    cmd = new SqlCommand("select conditionnement, dosage, forme, numlot from LigneStock where idstock = @idstock", con);
                    cmd.Parameters.AddWithValue("@idstock", dgv.Rows[i].Cells[3].Value.ToString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    dgv.Rows[i].Cells[6].Value = dr[0].ToString();
                    dgv.Rows[i].Cells[7].Value = dr[1].ToString();
                    dgv.Rows[i].Cells[8].Value = dr[2].ToString();
                    dgv.Rows[i].Cells[9].Value = dr[3].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        #endregion

        #region REQUISITION_PRODUIT_PHARMA
        public void EnregistrerRequisition(FormHistoCommande c, string dest)
        {
            c.idrequisition = NouveauID("requisition");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneRequisition values (@id, @date_jour, @idstock, @qterequise, @qteaccordee)", con);
                cmd.Parameters.AddWithValue("@id", c.idrequisition);
                //cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idstock", c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@qterequise", c.dgvCommande.CurrentRow.Cells[8].Value.ToString());
                cmd.Parameters.AddWithValue("@qteaccordee", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
            //Mouvement de stock à la pharma
            EnregistrerMvmt(c, dest);
        }
        public void AfficherTouteRequisition(FormRequisition r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneRequisition ", con);
                dr = cmd.ExecuteReader();
                r.dgvRequisition.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRequisition.Rows.Add();
                    r.dgvRequisition.Rows[r.dgvRequisition.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRequisition.Rows[r.dgvRequisition.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRequisition.Rows[r.dgvRequisition.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRequisition.Rows[r.dgvRequisition.RowCount - 1].Cells[8].Value = dr[3].ToString();
                    r.dgvRequisition.Rows[r.dgvRequisition.RowCount - 1].Cells[9].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            DetailsStock(r.dgvRequisition);
        }
        #endregion

        #region REQUISITION_AUTRE_PRODUIT
        public void EnregistrerRequisition(FormCommandePharma c, string dest)
        {
            c.idrequisition = NouveauID("requisitionautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneRequisitionAutre values (@id, @date_jour, @idproduit, @qterequise, @qteaccordee)", con);
                cmd.Parameters.AddWithValue("@id", c.idrequisition);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idproduit", c.dgvComande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@qterequise", c.dgvComande.CurrentRow.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@qteaccordee", c.dgvComande.CurrentRow.Cells[6].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
            //Mouveent de stock au stock autre produit
            EnregistrerMvmt(c, dest);
        }
        #endregion

        #region PHARMACIE
        public void AfficherSousForm(MFormPharmacie ph, FormRecette childForm)
        {
            if (ph.activeForm != null)
                ph.activeForm.Close();
            ph.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ph.pnlChildForm.Controls.Add(childForm);
            ph.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.Show();
        }
        public void AfficherSousForm(MFormPharmacie ph, FormPhamaVente childForm)
        {
            if (ph.activeForm != null)
                ph.activeForm.Close();
            ph.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ph.pnlChildForm.Controls.Add(childForm);
            ph.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idpharma = 1;//Cette valeur changera selon la pharmacie
            childForm.idutilisateur = ph.idutilisateur;
            childForm.Show();
        }

        public void AfficherSousForm(MFormPharmacie c, FormStockProduit childForm)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = 1;//Trouver l'id de la pharma qui se connecte
            childForm.btnNouveauStock.Visible = false;
            childForm.btnStockPha.Visible = false;
            childForm.Show();
        }
        public void AfficherSousForm(MFormPharmacie s, FormStockAlerte childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = 1;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        public void AfficherSousForm(MFormPharmacie s, FormUtilisation childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = 1;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        public void AfficherSousForm(MFormPharmacie c, FormHistoCommande childForm)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = 1;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }

        
        #endregion

        #region GESTION_STOCKS
        public void AfficherSousForm(MFormStock s, FormStockProduit childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.Show();
        }
        public void AfficherSousForm(MFormStock s, FormHistoCommande childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.Show();
        }
        public void AfficherSousForm(MFormStock s, FormApproCommande childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.dgvAppro.Columns[4].Visible = false;
            childForm.btnImprimer.Enabled = false;
            childForm.Show();
        }
        public void AfficherSousForm(MFormStock s, FormStockAlerte childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.Show();
        }
        public void AfficherSousForm(MFormStock s, Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            //childForm.poste = "stock";
            childForm.Show();
        }
        public void AfficherSousForm(MFormStock s, FormStockInventaire childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.Show();
        }

        public void ServirSortieStock(FormStockProduit s, FormStockServir com)
        {
            s.btnDemande.Enabled = false;
            com.poste = s.poste;
            com.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1} {2}",
                s.dgvProduit.CurrentRow.Cells[1].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[3].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[4].Value.ToString());

            com.txtQteStock.Text = s.dgvStock.CurrentRow.Cells[1].Value.ToString();
            com.txtQteCom.Focus();
            com.ShowDialog();
            com.Close();
        }
        public void PerteSortieStock(FormStockProduit s, FormStockServir com)
        {
            s.btnPerte.Enabled = false;
            com.poste = s.poste;
            com.ajout_perte = true;
            com.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1} {2}",
                s.dgvProduit.CurrentRow.Cells[1].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[3].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[4].Value.ToString());

            com.txtQteStock.Text = s.dgvStock.CurrentRow.Cells[1].Value.ToString();
            com.txtQteCom.Focus();
            com.ShowDialog();
            com.Close();
        }
        public void AjouterSortieStock(FormStockServir c)
        {
            if (c.txtQteCom.Text != "" && c.txtQteServie.Text != "" && c.cboPoste.Text != "")
            {
                if (int.Parse(c.txtQteCom.Text) <= int.Parse(c.txtQteStock.Text))
                {
                    if (int.Parse(c.txtQteCom.Text) == int.Parse(c.txtQteServie.Text))
                    {
                        c.idsortie = NouveauID("sortie");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            if (c.ajout_perte)
                            {
                                cmd = new SqlCommand("insert into SortieStock (idsortie, date_jour, idstock, qte_dem, qteservie, motif) values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif)", con);
                                cmd.Parameters.AddWithValue("@motif", "perte");
                            }
                            else
                            {
                                cmd = new SqlCommand("insert into SortieStock values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif, @idposte)", con);
                                cmd.Parameters.AddWithValue("@motif", "servir une demande");
                                cmd.Parameters.AddWithValue("@idposte", c.idposte);
                            }
                            cmd.Parameters.AddWithValue("@id", c.idsortie);
                            cmd.Parameters.AddWithValue("@date_jour", c.dtpDateJour.Text);
                            cmd.Parameters.AddWithValue("@idstock", c.idstock);
                            cmd.Parameters.AddWithValue("@qte_dem", c.txtQteCom.Text);
                            cmd.Parameters.AddWithValue("@qteservie", c.txtQteServie.Text);
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        con.Close();
                        Annuler(c);
                        MiseAjourQteStock(c.idstock, int.Parse(c.txtQteServie.Text), "stock");
                    }
                    else
                        MessageBox.Show("Erreur! La quantité servie doit être égale à celle demandée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Erreur! La quantité demandée dépasse le stock disponilbe", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Erreur! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s)", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Annuler(FormStockServir c)
        {
            c.txtQteCom.Text = "";
            c.txtQteServie.Text = "";
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboPoste.SelectedText = "";
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtQteCom.Focus();
        }
        public void AjouterStockPha(FormStockProduit s, FormStockPha sp)
        {
            s.btnStockPha.Enabled = false;
            sp.idstock = s.idstock;
            sp.ShowDialog();
            sp.Close();
        }
        public void FicheStock(FormStockProduit s, FormFicheStock f)
        {
            // Afficher tous les mouvements concernant le stock sélectionné
            f.ShowDialog();
            s.btnFicheStock.Enabled = false;
        }
        public void NouveauStock(FormStockProduit s, FormStockNouveau n)
        {
            n.poste = s.poste;
            n.ShowDialog();
            ChargerProduit(s, "");
        }
        public void SortiesStock(FormStockProduit s)
        {
            // Afficher tous les mouvements concernant le stock sélectionné
            s.btnSorties.Enabled = false;
        }
        public void ChargerProduit(FormStockNouveau s, string motif)
        {
            con.Open();
            if (motif == "recherche")
                cmd = new SqlCommand("select idproduit, nomproduit FROM Produit WHERE nomproduit like '" + s.txtRecherche.Text + "%' order by nomproduit", con);
            else
                cmd = new SqlCommand("select idproduit, nomproduit FROM Produit order by nomproduit", con);
            try
            {
                dr = cmd.ExecuteReader();
                s.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvProduit.Rows.Add();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerStock(FormStockNouveau s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idstock, qtestock, forme, dosage from LigneStock where idproduit = @id", con);
                cmd.Parameters.AddWithValue("@id", s.idproduit);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerProduit(FormStockProduit s, string motif)
        {
            con.Open();
            if (s.poste == "pharmacie")
            {
                if (motif == "recherche")
                    cmd = new SqlCommand("select Produit.idproduit, nomproduit from Produit, LigneStock, LigneStockPharma where Produit.idproduit = LigneStock.idproduit and LigneStock.idstock = LigneStockPharma.idstock and idpharma = '" + s.idpharma + "' and idcat = '" + s.idcat + "' and nomproduit like '" + s.txtRecherche.Text + "%' order by nomproduit", con);
                else
                    cmd = new SqlCommand("select Produit.idproduit, nomproduit from Produit, LigneStock, LigneStockPharma where Produit.idproduit = LigneStock.idproduit and LigneStock.idstock = LigneStockPharma.idstock and idpharma = '" + s.idpharma + "' and idcat = '" + s.idcat + "' order by nomproduit", con);
            }
            else
            {
                if (motif == "recherche")
                    cmd = new SqlCommand("select idproduit, nomproduit from Produit where idcat = '" + s.idcat + "' and nomproduit like '" + s.txtRecherche.Text + "%' order by nomproduit", con);
                else
                    cmd = new SqlCommand("select idproduit, nomproduit from Produit where idcat = '" + s.idcat + "' order by nomproduit", con);
            }
            try
            {
                dr = cmd.ExecuteReader();
                s.dgvProduit.Rows.Clear();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvProduit.Rows.Add();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerStockProduit(FormStockProduit s)
        {
            con.Open();
            try
            {
                if (s.poste == "pharmacie")
                {
                    s.dgvStock.Columns[2].Visible = false;
                    cmd = new SqlCommand("select idstockph, LigneStockPharma.qtestock, CMM, forme, dosage, numlot, expiration from LigneStock,LigneStockPharma where LigneStockPharma.idstock = LigneStock.idstock and LigneStockPharma.idpharma = '" + s.idpharma + "' and idproduit = @id", con);
                }
                else
                    cmd = new SqlCommand("select idstock, qtestock, CMM, forme, dosage, numlot, expiration from LigneStock where idproduit = @id", con);
                cmd.Parameters.AddWithValue("@id", s.idproduit);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherCommande(FormHistoCommande c, string motif)
        {
            if (c.cboCategorie.Text != "")
            {
                con.Open();
                try
                {
                    if(c.poste == "pharmacie")
                    {
                        if (motif == "recherche")
                            cmd = new SqlCommand("select idcomph,date_com,nomproduit,forme,dosage,qtecom from CommandePharma, LigneStockPharma, LigneStock, Produit where date_com between @dateDe and @dateA and CommandePharma.idstockph = LigneStockPharma.idstockph and LigneStockPharma.idstock = LigneStock.idstock and LigneStockPharma.idpharma = '"+c.idpharma+"' and LigneStock.idproduit = Produit.idproduit and Produit.idcat = '" + c.idcat + "' and nomproduit LIKE '" + c.txtRecherche.Text + "%'", con);
                        else
                            cmd = new SqlCommand("select idcomph,date_com,nomproduit,forme,dosage,qtecom from CommandePharma, LigneStockPharma, LigneStock, Produit where date_com between @dateDe and @dateA and CommandePharma.idstockph = LigneStockPharma.idstockph and LigneStockPharma.idstock = LigneStock.idstock and LigneStockPharma.idpharma = '" + c.idpharma + "' and LigneStock.idproduit = Produit.idproduit and Produit.idcat = '" + c.idcat + "'", con);
                    }
                    else
                    {
                        if (motif == "recherche")
                            cmd = new SqlCommand("select idcom,date_com,nomproduit,forme,dosage,qtedem from LigneCommande, LigneStock, Produit where date_com between @dateDe and @dateA and LigneCommande.idstock = LigneStock.idstock and LigneStock.idproduit = Produit.idproduit and Produit.idcat = '" + c.idcat + "' and nomproduit LIKE '" + c.txtRecherche.Text + "%'", con);
                        else
                            cmd = new SqlCommand("select idcom,date_com,nomproduit,forme,dosage,qtedem from LigneCommande, LigneStock, Produit where date_com between @dateDe and @dateA and LigneCommande.idstock = LigneStock.idstock and LigneStock.idproduit = Produit.idproduit and Produit.idcat = '" + c.idcat + "'", con);
                    }
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    c.dgvCommande.Rows.Clear();
                    while (dr.Read())
                    {
                        c.dgvCommande.Rows.Add();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[4].Value = dr[4].ToString();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                if(c.dgvCommande.RowCount != 0)
                {
                    for (int i = 0; i < c.dgvCommande.RowCount; i++)
                    {
                        con.Open();
                        try
                        {
                            c.idcommande = int.Parse(c.dgvCommande.Rows[i].Cells[0].Value.ToString());
                            if (c.poste == "pharmacie")
                                cmd = new SqlCommand("SELECT COUNT(qteservie), SUM(qteservie) FROM ApproPharma, CommandePharma WHERE ApproPharma.idcomph = CommandePharma.idcomph AND CommandePharma.idcomph = '" + c.idcommande + "'", con);
                            else
                                cmd = new SqlCommand("SELECT COUNT(qteajoute), SUM(qteajoute) FROM LigneAppro, LigneCommande WHERE LigneAppro.idcom = LigneCommande.idcom AND LigneCommande.idcom = '" + c.idcommande + "'", con);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr[0].ToString() != "0")
                                c.dgvCommande.Rows[i].Cells[6].Value = dr[1].ToString();
                            else
                                c.dgvCommande.Rows[i].Cells[6].Value = "0";
                            c.dgvCommande.Rows[i].Cells[7].Value = int.Parse(c.dgvCommande.Rows[i].Cells[5].Value.ToString()) - int.Parse(c.dgvCommande.Rows[i].Cells[6].Value.ToString());
                        }
                        catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        con.Close();
                    }
                }
            }
            else MessageBox.Show("Aucune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AfficherStockProduit(FormStockInventaire s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idstock, nomproduit, forme, dosage, qtestock From LigneStock s JOIN Produit p ON p.idproduit = s.idproduit", con);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = 0;
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = 0;
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void TrouverQteStock(FormStockInventaire s)
        {
            for (int i = 0; i < s.dgvStock.RowCount; i++)
            {
                //Entrée
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(qteajoute) entree
                    FROM LigneStock s
                    JOIN LigneCommande c ON c.idstock = s.idstock
                    JOIN LigneAppro a ON a.idcom = c.idcom
                    WHERE s.idstock = @idstock AND date_appro BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idstock", s.dgvStock.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@dateDe", s.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", s.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if(dr[0].ToString() != "")
                            s.dgvStock.Rows[i].Cells[5].Value = Convert.ToInt32(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                //Sortie
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(qteservie) sortie
                    FROM LigneStock s
                    JOIN LigneStockPharma sp ON sp.idstock = s.idstock
                    JOIN CommandePharma cp ON cp.idstockph = sp.idstockph
                    JOIN ApproPharma ap ON ap.idcomph = cp.idcomph
                    WHERE s.idstock = @idstock AND date_appro BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idstock", s.dgvStock.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@dateDe", s.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", s.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                            s.dgvStock.Rows[i].Cells[6].Value = Convert.ToInt32(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                //Calcul Valeur stock
                s.dgvStock.Rows[i].Cells[7].Value = Convert.ToInt32(s.dgvStock.Rows[i].Cells[4].Value) * PrixStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value), "achat");               
            }
            //Total
            s.dgvStock.Rows.Add();
            s.dgvStock.Rows[s.dgvStock.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = "Total";
            s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = 0;
            for (int j = 0; j < s.dgvStock.RowCount - 1; j++)
            {
                s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = Convert.ToDouble(s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value) +
                    Convert.ToDouble(s.dgvStock.Rows[j].Cells[7].Value);
            }
        }

        #endregion

        #region COMMANDE_PRODUIT_PHARMA
        public void ChargerProduit(FormStockAlerte s, string motif)
        {
            con.Open();
            if (s.poste == "pharmacie")
            {
                if (motif == "recherche")
                    cmd = new SqlCommand("select distinct Produit.idproduit, nomproduit from Produit, LigneStock, LigneStockPharma where Produit.idproduit = LigneStock.idproduit and LigneStock.idstock = LigneStockPharma.idstock and idpharma = '" + s.idpharma + "' and LigneStockPharma.qtestock <= 10 and idcat = '" + s.idcat + "' and nomproduit like '" + s.txtRecherche.Text + "%' order by nomproduit", con);
                else
                    cmd = new SqlCommand("select distinct Produit.idproduit, nomproduit from Produit, LigneStock, LigneStockPharma where Produit.idproduit = LigneStock.idproduit and LigneStock.idstock = LigneStockPharma.idstock and idpharma = '" + s.idpharma + "' and LigneStockPharma.qtestock <= 10 and idcat = '" + s.idcat + "' order by nomproduit", con);
            }
            else
            {
                if (motif == "recherche")
                    cmd = new SqlCommand("select distinct Produit.idproduit, nomproduit from Produit, LigneStock where Produit.idproduit = LigneStock.idproduit and qtestock <= 10 and idcat = '" + s.idcat + "' and nomproduit like '" + s.txtRecherche.Text + "%' order by nomproduit", con);
                else
                    cmd = new SqlCommand("select distinct Produit.idproduit, nomproduit from Produit, LigneStock where Produit.idproduit = LigneStock.idproduit and qtestock <= 10 and idcat = '" + s.idcat + "' order by nomproduit", con);
            }
            try
            {
                dr = cmd.ExecuteReader();
                s.dgvProduit.Rows.Clear();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvProduit.Rows.Add();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerStockProduit(FormStockAlerte s)
        {
            con.Open();
            try
            {
                if (s.poste == "pharmacie")
                {
                    cmd = new SqlCommand("select idstockph, LigneStockPharma.qtestock, forme, dosage from LigneStock,LigneStockPharma where LigneStockPharma.idstock = LigneStock.idstock and LigneStockPharma.idpharma = '" + s.idpharma + "' and LigneStockPharma.qtestock <= 10 and idproduit = @id", con);
                }
                else
                    cmd = new SqlCommand("select idstock, qtestock, forme, dosage from LigneStock where idproduit = @id and qtestock <= 10", con);
                cmd.Parameters.AddWithValue("@id", s.idproduit);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[2].Value = "0";
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AjouterCommande(FormStockAlerte s, string poste)
        {
            if(s.dgvStock.RowCount !=0)
            {
                for (int i = s.dgvStock.RowCount-1; i >=0; i--)
                {
                    s.ajout_effectue = false;
                    
                    s.idstock = int.Parse(s.dgvStock.Rows[i].Cells[0].Value.ToString());
                    try
                    {
                        if (int.Parse(s.dgvStock.Rows[i].Cells[2].Value.ToString()) > 0)
                        {
                            if(VerifierCommande(s.idstock, s.dtpDateJour.Text, poste)==0)
                            {
                                if(poste == "stock")
                                {
                                    s.idcom = NouveauID("commande");
                                    con.Open();
                                    SqlTransaction tx = con.BeginTransaction();
                                    try
                                    {
                                        cmd = new SqlCommand("insert into LigneCommande values (@id, @date_jour, @idstock, @qtecom)", con);
                                        cmd.Parameters.AddWithValue("@id", s.idcom);
                                        cmd.Parameters.AddWithValue("@date_jour", s.dtpDateJour.Text);
                                        cmd.Parameters.AddWithValue("@idstock", s.dgvStock.Rows[i].Cells[0].Value.ToString());
                                        cmd.Parameters.AddWithValue("@qtecom", s.dgvStock.Rows[i].Cells[2].Value.ToString());
                                        cmd.Transaction = tx;
                                        cmd.ExecuteNonQuery();
                                        tx.Commit();
                                        s.ajout_effectue = true;
                                    }
                                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    con.Close();
                                }
                                else
                                {
                                    s.idcom = NouveauID("commandepharma");
                                    con.Open();
                                    SqlTransaction tx = con.BeginTransaction();
                                    try
                                    {
                                        cmd = new SqlCommand("insert into CommandePharma values (@id, @idstock, @date_jour, @qtecom)", con);
                                        cmd.Parameters.AddWithValue("@id", s.idcom);
                                        cmd.Parameters.AddWithValue("@idstock", s.dgvStock.Rows[i].Cells[0].Value.ToString());
                                        cmd.Parameters.AddWithValue("@date_jour", s.dtpDateJour.Text);
                                        cmd.Parameters.AddWithValue("@qtecom", s.dgvStock.Rows[i].Cells[2].Value.ToString());
                                        cmd.Transaction = tx;
                                        cmd.ExecuteNonQuery();
                                        tx.Commit();
                                        s.ajout_effectue = true;
                                    }
                                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    con.Close();
                                }
                            }
                            else
                                MessageBox.Show("Une commande existe déjà pour la ligne " + (i + 1) + " à cette date ", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            s.dgvStock.Rows.RemoveAt(s.dgvStock.Rows[i].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Vérifiez que la quantité commandée sur la ligne " + (i + 1) + " est un entier supérieur à 0", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                if (s.ajout_effectue)
                {
                    MessageBox.Show("Commande ajoutée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    s.dgvStock.Rows.Clear();
                }
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvé", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public int VerifierCommande(int idstock, string date_jour, string poste)
        {
            id = 0;
            con.Open();
            if (poste == "pharmacie")
                cmd = new SqlCommand("select count(idcomph) from CommandePharma where idstockph = '" + idstock + "' and date_com = '" + date_jour + "'", con);
            else
                cmd = new SqlCommand("select count(idcom) from LigneCommande where idstock = '" + idstock + "' and date_com = '"+date_jour+"'", con);
            try
            {
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();           
            return id;
        }
        public void MiseAJourCommande(FormHistoCommande c, string poste)
        {
            if (VerifierApproCommande(c.idcom, poste) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (poste == "stock")
                        cmd = new SqlCommand("UPDATE LigneCommande SET date_com = '"+c.dtpDateDe.Text+"', qtedem = '" + c.txtQte.Text + "' WHERE idcom = '" + c.idcom + "'", con);
                    else
                        cmd = new SqlCommand("UPDATE CommandePharma SET date_com = '" + c.dtpDateDe.Text + "', qtecom = '" + c.txtQte.Text + "' WHERE idcomph = '" + c.idcom + "'", con);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.txtQte.Text = "";
                    c.btnValider.Enabled = false;
                    c.txtQte.Enabled = false;
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
                MessageBox.Show("Vous ne pouvez modifier une commande déjà au moins servie", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public int VerifierApproCommande(int idcom, string poste)
        {
            id = 0;
            con.Open();
            if (poste == "pharmacie")
                cmd = new SqlCommand("select count(idapproph) from ApproPharma where idcomph = '" + idcom + "' ", con);
            else
                cmd = new SqlCommand("select count(idappro) from LigneAppro where idcom = '" + idcom + "' ", con);
            try
            {
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close(); 
            return id;
        }
        public bool RetirerCommande(int idcom, string poste)
        {
            cmdStatut = false;
            if (VerifierApproCommande(idcom, poste) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (poste == "stock")
                        cmd = new SqlCommand("DELETE FROM LigneCommande WHERE idcom = '" + idcom + "'", con);
                    else
                        cmd = new SqlCommand("DELETE FROM CommandePharma WHERE idcomph = '" + idcom + "'", con);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Retiré avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmdStatut = true;
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
                MessageBox.Show("Vous ne pouvez retirer une commande déjà au moins servie", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return cmdStatut;
        }
        public void ValiderCommande(FormCommandePharma c, FormComAutre com, string motif)
        {
            com.idproduit = int.Parse(c.dgvComande.CurrentRow.Cells[1].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1}",
                c.dgvComande.CurrentRow.Cells[2].Value.ToString(),
                c.dgvComande.CurrentRow.Cells[3].Value.ToString());
            com.txtQteStock.Text = c.dgvComande.CurrentRow.Cells[4].Value.ToString();
            com.txtQteCom.Focus();
            if (!c.dgvComande.CurrentRow.Cells[6].Visible)
            {
                com.txtQteServie.Enabled = false;
                com.txtDest.Enabled = false;
            }
            com.motif = c.motif;
            com.ShowDialog();
            if (com.fermeture_succes)
            {
                c.dgvComande.CurrentRow.Cells[5].Value = com.txtQteCom.Text;
                if (c.dgvComande.CurrentRow.Cells[6].Visible)
                    c.dgvComande.CurrentRow.Cells[6].Value = com.txtQteServie.Text;
                if (motif == "commande")
                    EnregistrerAppro(c);
                else
                    EnregistrerRequisition(c, com.txtDest.Text);
            }
            com.Close();
            c.btnQteCom.Enabled = false;
        }

        public void ChargerProduit(FormUtilisation u)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idstockph,nomproduit,forme,dosage from LigneStockPharma, LigneStock, Produit where LigneStockPharma.idstock = LigneStock.idstock and LigneStock.idproduit = Produit.idproduit and idpharma = '" + u.idpharma + "'", con);
                dr = cmd.ExecuteReader();
                u.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    u.dgvProduit.Rows.Add();
                    u.dgvProduit.Rows[u.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    u.dgvProduit.Rows[u.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    u.dgvProduit.Rows[u.dgvProduit.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    u.dgvProduit.Rows[u.dgvProduit.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            AjouterJourRumer(u);
        }
        public void AjouterJourRumer(FormUtilisation u)
        {
            DateTime t;
            TimeSpan s = u.dtpDateA.Value.Date - u.dtpDateDe.Value.Date;
            t = u.dtpDateDe.Value.Date;
            if (s.TotalDays > 0 && u.dtpDateA.Value.Month == u.dtpDateDe.Value.Month)
            {
                for (int i = 0; i < s.TotalDays + 1; i++)
                {
                    u.dgvProduit.Columns.Add("column_" + (i), t.AddDays(i).Day.ToString());
                }
            }
        }

        ReportDataSource rs = new ReportDataSource();
        public void ImprimerBonCommande(FormApproCommande a, FormImpression imp)
        {
            if (a.dgvCommande.RowCount != 0)
            {
                imp.Text = "SSM - Bon de Commande";

                List<BonCommandePharma> list = new List<BonCommandePharma>();
                list.Clear();

                for (int i = 0; i < a.dgvCommande.RowCount; i++)
                {
                    BonCommandePharma bc = new BonCommandePharma
                    {
                        id = list.Count + 1,
                        produit = a.dgvCommande.Rows[i].Cells[2].Value.ToString(),
                        forme = a.dgvCommande.Rows[i].Cells[3].Value.ToString(),
                        dosage = a.dgvCommande.Rows[i].Cells[4].Value.ToString(),
                        qtedem = a.dgvCommande.Rows[i].Cells[5].Value.ToString(),
                    };
                    list.Add(bc);
                }
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonCommandePharma.rdlc";
                imp.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ImprimerHistoCommande(FormHistoCommande a, FormImpression imp)
        {
            if (a.dgvCommande.RowCount != 0)
            {
                imp.Text = "SSM - Historique de Commande";

                List<BonHistoCommande> list = new List<BonHistoCommande>();
                list.Clear();

                for (int i = 0; i < a.dgvCommande.RowCount; i++)
                {
                    BonHistoCommande bc = new BonHistoCommande
                    {
                        id = list.Count + 1,
                        date_com = a.dgvCommande.Rows[i].Cells[1].Value.ToString(),
                        produit = a.dgvCommande.Rows[i].Cells[2].Value.ToString(),
                        forme = a.dgvCommande.Rows[i].Cells[3].Value.ToString(),
                        dosage = a.dgvCommande.Rows[i].Cells[4].Value.ToString(),
                        qtedem = a.dgvCommande.Rows[i].Cells[5].Value.ToString(),
                        qteservie = a.dgvCommande.Rows[i].Cells[6].Value.ToString(),
                        qtereste = a.dgvCommande.Rows[i].Cells[7].Value.ToString(),
                    };
                    list.Add(bc);
                }
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonHistoCommande.rdlc";
                imp.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion
        
        #region GESTION_STOCKS_AUTRE
        public void AfficherSousForm(MFormStock s, FormReceptionRapport childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            s.pnlChildForm.Controls.Add(childForm);
            s.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "stock";
            childForm.Show();
        }
        public void HistoriqueApproStockAutre(MFormComptabilite c, FormApprov childForm)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "admin";
            childForm.Show();
        }
        public void AfficherToutStock(FormReceptionRapport s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from ProduitAutreStock ", con);
                dr = cmd.ExecuteReader();
                s.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvRecette.Rows.Add();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    s.dgvRecette.Rows[s.dgvRecette.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        #endregion

        #region MOUVEMENT_STOCK
        public void EnregistrerMvmt(FormStockAlerte c)
        {
            
        }
        public void DiminuerStock(FormStockAlerte c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneStock set qtestock = qtestock - @qteservie where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idstock);
                //cmd.Parameters.AddWithValue("@qteservie", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EnregistrerMvmt(FormCommandePharma c, string dest)
        {
            //Enregistre le mouvement à la requisition
            c.idmvmt = NouveauID("mouvementautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into MouvementAutreStock values (@id, @date_jour, @operation, @idproduit, @quantite, @dest)", con);
                cmd.Parameters.AddWithValue("@id", c.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Value);
                cmd.Parameters.AddWithValue("@operation", "sortie");
                cmd.Parameters.AddWithValue("@idproduit", c.idproduit);
                cmd.Parameters.AddWithValue("@quantite", c.dgvComande.CurrentRow.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void EnregistrerMvmt(FormHistoCommande c, string dest)
        {
            //Enregistre le mouvement à la requisition
            c.idmvmt = NouveauID("mouvementpharma");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into MouvementPharma values (@id, @date_jour, @operation, @idstock, @quantite, @dest)", con);
                cmd.Parameters.AddWithValue("@id", c.idmvmt);
                //cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Value);
                cmd.Parameters.AddWithValue("@operation", "sortie");
                cmd.Parameters.AddWithValue("@idstock", c.idcom);
                cmd.Parameters.AddWithValue("@quantite", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Stock pharma diminue
            MiseAJourStockPharma(c.idcom, int.Parse(c.dgvCommande.CurrentRow.Cells[9].Value.ToString()), "reduire");
        }
        public void MiseAJourStockPharma(int idstock, int qte, string motif)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(motif =="reduire")
                    cmd = new SqlCommand("update LigneStockPharma set qtestock = qtestock - @qteservie where idstock = @id", con);
                else
                    cmd = new SqlCommand("update LigneStockPharma set qtestock = qtestock + @qteservie where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id",idstock);
                cmd.Parameters.AddWithValue("@qteservie", qte);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EnregistrerMvmt(FormStockAlerte c, string dest)
        {
            
        }
        public void Afficher(FormTresoEntree m)
        {
            //
        }
        public void Afficher(FormMouvementPharma m)
        {
            //
        }
        public void ReduireColonnes(DataGridView dgv , Button btn1, Button btn2)
        {
            for (int i = 5; i <= 9; i++)
            {
                dgv.Columns[i].Visible = false;
            }
            btn1.Enabled = false;
            btn2.Enabled = true;
        }
        public void AfficherColonnes(DataGridView dgv, Button btn1, Button btn2)
        {
            for (int i = 5; i <= 9; i++)
            {
                dgv.Columns[i].Visible = true;
            }
            btn1.Enabled = true;
            btn2.Enabled = false;
        }
        #endregion

        #region STOCK_PHARMA
        public int VerifierStockPharma(FormStockPha s)
        {
            id =0;
            cmd = new SqlCommand("select count(idstockph) from LigneStockPharma where idpharma = '" + s.idpharma + "' and idstock = '"+s.idstock+"'", con);
            con.Open();
            try
            {
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
        
        public void Enregistrer(FormStockPha s)
        {
            if (s.cboPharma.Text !="")
            {
                if (VerifierStockPharma(s) == 0)
                {
                    s.idstockpharma = NouveauID("stockpha");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into LigneStockPharma values (@id, @idpharma, @idstock, @qte)", con);
                        cmd.Parameters.AddWithValue("@id", s.idstockpharma);
                        cmd.Parameters.AddWithValue("@idpharma", s.idpharma);
                        cmd.Parameters.AddWithValue("@idstock", s.idstock);
                        cmd.Parameters.AddWithValue("@qte", "0");
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else MessageBox.Show("Stock déjà existant pour la pharmacie sélectionnée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterNouvellePharma(FormStockPha p)
        {
            if(p.txtPharmacie.Text != "")
            {
                if(VerifierPharma(p.txtPharmacie.Text)==0)
                {
                    p.idpharma = NouveauID("pharmacie");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Pharmacie values (@idpharma, @designation)", con);
                        cmd.Parameters.AddWithValue("@idpharma", p.idpharma);
                        cmd.Parameters.AddWithValue("@designation", p.txtPharmacie.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    
                    //Ajouter comme service demandeur
                    p.idpharma = NouveauID("poste");
                    con.Open();
                    tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ServiceDemandeur values (@idposte, @nomposte)", con);
                        cmd.Parameters.AddWithValue("@idposte", p.idpharma);
                        cmd.Parameters.AddWithValue("@nomposte", p.txtPharmacie.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else MessageBox.Show("Cette pharmacie existe déjà dans le système", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            p.txtPharmacie.Enabled = false;
            p.txtPharmacie.Text = "";
            p.btnValider.Enabled = false;
        }
        public int VerifierPharma(string nompharma)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT COUNT(idpharma) from Pharmacie WHERE designation = '"+nompharma+"'", con);
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
        #endregion

        #region APPRO_STOCK_PRINCIPAL
        public void ApprovisionnerStock2(FormApproCommande a, FormApproAutre ap)
        {
            if (a.cboCategorie.Text != "")
            {
                ap.categorie_produit = a.cboCategorie.Text;
                ap.idcat = a.idcat;
                ChargerProduit(ap, "");
                if (ap.categorie_produit.ToLower() == "pharmaceutique")
                {
                    ap.chboxLot.Enabled = false;
                    ap.txtNumLot.Enabled = true;
                    ap.cboMois.Enabled = true;
                    ap.nudAnnee.Enabled = true;
                }
                ap.ShowDialog();
                ap.Close();
            }
            else
                MessageBox.Show("Aucune catégorie de produits n'est sélectionnée","Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void EnregistrerAppro(FormApprov a)
        {
            if(a.poste == "comptable")
            {
                for (int i = 0; i < a.dgvAppro.RowCount-1; i++)
                {
                    a.idAppro = NouveauID("appro");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into LigneAppro values (@id, @date_appro, @idcom, @qteappro, @qteajoute, @obs)", con);
                        cmd.Parameters.AddWithValue("@id", a.idAppro);
                        cmd.Parameters.AddWithValue("@date_appro", a.dtpDateJour.Text);
                        cmd.Parameters.AddWithValue("@idcom", a.dgvAppro.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@qteappro", a.dgvAppro.Rows[i].Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@qteajoute", a.dgvAppro.Rows[i].Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@obs", a.dgvAppro.Rows[i].Cells[12].Value.ToString());
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
            else
            {
                for (int i = 0; i < a.dgvAppro.RowCount-1; i++)
                {
                    a.idAppro = NouveauID("appropharma");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ApproPharma values (@idapproph, @date_appro, @idcomph, @qteservie)", con);
                        cmd.Parameters.AddWithValue("@idapproph", a.idAppro);
                        cmd.Parameters.AddWithValue("@date_appro", a.dtpDateJour.Text);
                        cmd.Parameters.AddWithValue("@idcomph", a.dgvAppro.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@qteservie", a.dgvAppro.Rows[i].Cells[7].Value.ToString());
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public void AjouterProduit(FormApproAutre a)
        {
            if (VerifierNomProduit(a.txtProduit.Text) == 0)
            {
                a.idproduit = NouveauID("produit");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Produit values (@id, @nom, @idcat)", con);
                    cmd.Parameters.AddWithValue("@id", a.idproduit);
                    cmd.Parameters.AddWithValue("@nom", a.txtProduit.Text);
                    cmd.Parameters.AddWithValue("@idcat", a.idcat);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                AjouterStock(a);
            }
            else MessageBox.Show("Le nom du produit fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Annuler(FormApproAutre a)
        {
            a.txtProduit.Enabled = true;
            a.txtProduit.Text = "";
            a.cboForme.DropDownStyle = ComboBoxStyle.DropDown;
            a.cboForme.SelectedText = "";
            a.cboForme.DropDownStyle = ComboBoxStyle.DropDownList;
            a.txtCMM.Text = "0";
            a.txtDosage.Text = "";
            a.txtPrixAchat.Text = "0";
            a.txtPrixVente.Text = "0";
            a.txtTaux.Text = "20";
            a.chboxLot.Checked = false;            
            a.txtQteAppro.Text = "";
        }
        public void AjouterApproAutre(FormApproAutre a)
        {
            if(a.txtProduit.Enabled)
            {
                //Nouveau produit de la catégorie sélectionnée et le stock initial
                AjouterProduit(a);
            }
            else
                AjouterStock(a);//Nouveau stock initial pour le produit sélectionné
            Annuler(a);
        }
        public void ChargerProduit(FormApproAutre s, string motif)
        {
            con.Open();
            if (motif == "recherche")
                cmd = new SqlCommand("SELECT idproduit, nomproduit from Produit WHERE idcat = '" + s.idcat + "' AND nomproduit LIKE '" + s.txtRecherche.Text + "%' ORDER BY nomproduit", con);
            else
                cmd = new SqlCommand("SELECT idproduit, nomproduit from Produit WHERE idcat = '" + s.idcat + "' ORDER BY nomproduit", con);
            try
            {
                dr = cmd.ExecuteReader();
                s.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvProduit.Rows.Add();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvProduit.Rows[s.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public void AfficherCommande(FormApproCommande a, string motif)
        {
            if (a.cboCategorie.Text != "")
            {
                con.Open();
                try
                {
                    if (motif == "recherche")
                       cmdtxt = @"SELECT idcom,date_com,nomproduit,forme,dosage,qtedem,c.idstock, s.prix_achat 
                        from LigneCommande c
                        JOIN LigneStock s ON c.idstock = s.idstock
                        JOIN Produit p ON s.idproduit = p.idproduit
                        JOIN CategorieProduit cp ON p.idcat = cp.idcat 
                        where date_com BETWEEN @dateDe AND @dateA AND categorie = @categ AND 
                        nomproduit LIKE '" + a.txtRecherche.Text.Replace("'","") + "%'";                        
                    else
                        cmdtxt = @"SELECT idcom,date_com,nomproduit,forme,dosage,qtedem,c.idstock, s.prix_achat 
                        from LigneCommande c
                        JOIN LigneStock s ON c.idstock = s.idstock
                        JOIN Produit p ON s.idproduit = p.idproduit
                        JOIN CategorieProduit cp ON p.idcat = cp.idcat 
                        where date_com BETWEEN @dateDe AND @dateA AND categorie = @categ";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@categ", a.cboCategorie.Text);
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    a.dgvCommande.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvCommande.Rows.Add();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[4].Value = dr[4].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[5].Value = dr[5].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[6].Value = dr[6].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[7].Value = dr[7].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else MessageBox.Show("Aucune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void TrouverApproCommande(FormApproCommande a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idappro,date_appro,qteappro,qteajoute, observation from LigneAppro where idcom = '"+a.idcom+"' ", con);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }

        public void MiseAJourAppro(FormApproCommande a)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneAppro set qteappro = @qteappro, qteajoute = @qteajoute where idappro = @id", con);
                cmd.Parameters.AddWithValue("@id", a.idcom);
                cmd.Parameters.AddWithValue("@qteappro", a.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@qteajoute", a.dgvCommande.CurrentRow.Cells[10].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }

        public void MiseAJourLigneStock(FormApprov ap)
        {
            if(ap.poste == "comptable")
            {
                for (int i = 0; i < ap.dgvAppro.RowCount-1; i++)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        if (ap.categorie_produit.ToLower() == "pharmaceutique")
                        {
                            //check prix_achat
                            if (Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[8].Value) < Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[15].Value))
                                ap.prix_achat = Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[15].Value);
                            else
                                ap.prix_achat = Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[8].Value);
                            //check prixvente
                            if (Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[10].Value) < Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[9].Value))
                                ap.prixvente = Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[9].Value);
                            else
                                ap.prixvente = Convert.ToDouble(ap.dgvAppro.Rows[i].Cells[10].Value);
                            cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, prix_achat = @prix_achat, prixunitaire = @prix, qtestock = qtestock + @qte where idstock = @id", con);
                            cmd.Parameters.AddWithValue("@prix", ap.prixvente);
                            cmd.Parameters.AddWithValue("@numlot", ap.dgvAppro.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@expiration", ap.dgvAppro.Rows[i].Cells[3].Value.ToString());
                        }
                        else if (ap.categorie_produit.ToLower() != "pharmaceutique" && ap.dgvAppro.Rows[i].Cells[2].Value.ToString() != "" && ap.dgvAppro.Rows[i].Cells[3].Value.ToString() != "")
                        {
                            cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, prix_achat = @prix_achat, qtestock = qtestock + @qte where idstock = @id", con);
                            cmd.Parameters.AddWithValue("@numlot", ap.dgvAppro.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@expiration", ap.dgvAppro.Rows[i].Cells[3].Value.ToString());
                        }
                        else
                            cmd = new SqlCommand("update LigneStock set prix_achat = @prix_achat, qtestock = qtestock + @qte where idstock = @id", con);
                        cmd.Parameters.AddWithValue("@id", ap.dgvAppro.Rows[i].Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", ap.dgvAppro.Rows[i].Cells[7].Value.ToString());
                        cmd.Parameters.AddWithValue("@prix_achat", ap.prix_achat);

                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }               
            }
            else
            {
                for (int i = 0; i < ap.dgvAppro.RowCount-1; i++)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("UPDATE LigneStock SET qtestock = qtestock - @qte where idstock = @id", con);
                        cmd.Parameters.AddWithValue("@id", ap.dgvAppro.Rows[i].Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", ap.dgvAppro.Rows[i].Cells[7].Value.ToString());
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
            ap.dgvAppro.Rows.Clear();
            MessageBox.Show("Enregistré avec succès", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void MiseAJourLigneStock(FormApproAutre ap)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (ap.categorie_produit.ToLower() == "pharmaceutique")
                {
                    cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, prix_achat = @prix_achat, prixunitaire = @prix, qtestock = qtestock + @qte where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@prix", double.Parse(ap.txtPrixVente.Text));
                    cmd.Parameters.AddWithValue("@numlot", ap.txtNumLot.Text);
                    cmd.Parameters.AddWithValue("@expiration", string.Format("{0}/{1}", ap.cboMois.Text, ap.nudAnnee.Value));
                }
                else if (ap.txtNumLot.Text != "" && ap.cboMois.Text != "")
                {
                    cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, qtestock = qtestock + @qte where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@numlot", ap.txtNumLot.Text);
                    cmd.Parameters.AddWithValue("@expiration", string.Format("{0}/{1}", ap.cboMois.Text, ap.nudAnnee.Value));
                }
                else
                    cmd = new SqlCommand("update LigneStock set qtestock = qtestock + @qte where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", ap.idstock);
                cmd.Parameters.AddWithValue("@qte", ap.txtQteAppro.Text);
                cmd.Parameters.AddWithValue("@prix_achat", ap.txtPrixAchat.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void MiseAjourQteStock(int idstock, int qte, string poste)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(poste=="stock")
                    cmd = new SqlCommand("update LigneStock set qtestock = qtestock - @qte where idstock = @id", con);
                else
                    cmd = new SqlCommand("update LigneStockPharma set qtestock = qtestock - @qte where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                cmd.Parameters.AddWithValue("@qte", qte);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        #endregion

        #region APPRO_STOCK_SECONDAIRES
        public void AfficherCommandePha(FormApproCommande a, string motif)
        {
            if (a.cboCategorie.Text != "")
            {
                con.Open();
                try
                {
                    if (motif == "recherche")
                    {
                        cmdtxt = @"SELECT idcomph,date_com,nomproduit,forme,dosage,qtecom,lp.idstock 
                        FROM CommandePharma c
                        JOIN LigneStockPharma lp ON c.idstockph = lp.idstockph
                        JOIN LigneStock l ON lp.idstock = l.idstock
                        JOIN Produit p ON l.idproduit = p.idproduit
                        JOIN CategorieProduit cp ON p.idcat = cp.idcat
                        WHERE categorie = @categ 
                        AND date_com BETWEEN @dateDe AND @dateA AND nomproduit LIKE '" + a.txtRecherche.Text + "%'";
                    }
                    else
                    {
                        cmdtxt = @"SELECT idcomph,date_com,nomproduit,forme,dosage,qtecom,lp.idstock 
                        FROM CommandePharma c
                        JOIN LigneStockPharma lp ON c.idstockph = lp.idstockph
                        JOIN LigneStock l ON lp.idstock = l.idstock
                        JOIN Produit p ON l.idproduit = p.idproduit
                        JOIN CategorieProduit cp ON p.idcat = cp.idcat
                        WHERE categorie = @categ 
                        AND date_com BETWEEN @dateDe AND @dateA";
                        
                    }
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@categ", a.cboCategorie.Text);
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    a.dgvCommande.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvCommande.Rows.Add();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[4].Value = dr[4].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[5].Value = dr[5].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[6].Value = dr[6].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else MessageBox.Show("Aucune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void TrouverApproCommandePha(FormApproCommande a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idapproph,date_appro,qteservie,qteservie from ApproPharma where idcomph = '" + a.idcom + "' ", con);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[4].Value = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        #endregion

        #region APPRO_AUTRE_PRODUIT
        public void ProduitUnite(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                con.Open();
                try
                {
                    cmd = new SqlCommand("select nomproduit, unite from ProduitAutreStock where idproduit = @idproduit", con);
                    cmd.Parameters.AddWithValue("@idproduit", dgv.Rows[i].Cells[2].Value.ToString());
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[3].Value = dr[0].ToString();
                        dgv.Rows[i].Cells[4].Value = dr[1].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void EnregistrerAppro(FormCommandePharma c)
        {
            c.idAppro = NouveauID("approautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneApproAutreStock values (@id, @date_dem, @idproduit, @prix_achat, @qtedem, @qteappro, @qteajoute)", con);
                cmd.Parameters.AddWithValue("@id", c.idAppro);
                cmd.Parameters.AddWithValue("@date_dem", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idproduit", c.dgvComande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@prix_achat", "0");
                cmd.Parameters.AddWithValue("@qtedem", c.dgvComande.CurrentRow.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@qteappro", "0");
                cmd.Parameters.AddWithValue("@qteajoute", "0");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void AfficherApproPeriode(FormApprov a)
        {
            
        }
        public void MiseAJourAppro(FormApprov a)
        {
            
        }
        #endregion

        #region UTILISATEUR
        public void Enregistrer(FormUtilisateur u)
        {
            if (u.cboPoste.Text != "" && u.txtUtilisateur.Text != "" && u.txtSpecification.Text != "")
            {
                if (u.txtUtilisateur.Text.Length >= 5)
                {
                    u.idutilisateur = NouveauID("user");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Utilisateur values (@id, @util, @mot, @poste, @specification)", con);
                        cmd.Parameters.AddWithValue("@id", u.idutilisateur);
                        cmd.Parameters.AddWithValue("@util", u.txtUtilisateur.Text);
                        cmd.Parameters.AddWithValue("@mot", "123456");
                        cmd.Parameters.AddWithValue("@poste", u.cboPoste.Text);
                        cmd.Parameters.AddWithValue("@specification", u.txtSpecification.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    if (u.nouveau_medecin)
                    {
                        u.fermeture_succes = true;
                        u.Hide();
                    }
                    else
                    {
                        Afficher(u);
                        Annuler(u);
                    }
                }
                else
                {
                    MessageBox.Show("Le nom d'utilisateur doit avoir une taille miniamale de 5 caractères", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    u.txtUtilisateur.Select();
                }
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Annuler(FormUtilisateur c)
        {
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboPoste.SelectedText = "";
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDownList;
            c.btnEnregistrer.Enabled = true;
            c.btnSupprimer.Enabled = false;
            c.idmedecin = 0;
            c.txtUtilisateur.Text = "";
            c.checkBox1.Checked = false;
            c.txtSpecification.Enabled = false;
            c.cboPoste.Select();
        }
        public void Modifier(FormUtilisateur u)
        {
            if (u.cboPoste.Text != "" && u.txtUtilisateur.Text != "" && u.txtSpecification.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Utilisateur set utilisateur= @util, poste= @poste, specification= @specification  where id= @id", con);
                    cmd.Parameters.AddWithValue("@id", u.idutilisateur);
                    cmd.Parameters.AddWithValue("@specification", u.txtSpecification.Text);
                    cmd.Parameters.AddWithValue("@util", u.txtUtilisateur.Text);
                    cmd.Parameters.AddWithValue("@poste", u.cboPoste.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Afficher(u);
                Annuler(u);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormConnexionPass c)
        {
            if(TestMotdePass(c))
            {
                if (c.txtNouveauMdPass.Text == c.txtConfirmerMdPass.Text && c.txtNouveauMdPass.Text != "11111111" && c.txtNouveauMdPass.Text != "12345678")
                {
                    if(c.txtNouveauMdPass.Text.Length >= 8)
                    {
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("update Utilisateur set motdepasse= @motdepasse where id= @id", con);
                            cmd.Parameters.AddWithValue("@id", c.idutilisateur);
                            cmd.Parameters.AddWithValue("@motdepasse", c.txtConfirmerMdPass.Text);
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            if (MessageBox.Show("Modifié avec succès\n\rVoulez-vous vous connecter ?", "Mise à jour", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                c.connexion = true;
                                c.Hide();
                            }
                            else
                            {
                                c.connexion = false;
                                c.Hide();
                            }
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
                        MessageBox.Show("Le mot de passe doit avoir une taille miniamale de 8 caractères", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        c.txtNouveauMdPass.Select();
                    }
                }
                else
                    MessageBox.Show("Confirmation du nouveau mot de passe invalide! \n\nLe mot de passe ne doit pas être si facile que 11111111 ou 12345678", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Supprimer(FormUtilisateur c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("delete from Utilisateur where id= @id", con);
                cmd.Parameters.AddWithValue("@id", c.idutilisateur);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Compte supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Afficher(c);
            Annuler(c);
        }
        public void Afficher(FormUtilisateur c)
        {
            //Modifier cette méthode pour permettre la recherche
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from Utilisateur", con);
                dr = cmd.ExecuteReader();
                c.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvAgenda.Rows.Add();
                    c.dgvAgenda.Rows[c.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvAgenda.Rows[c.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvAgenda.Rows[c.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvAgenda.Rows[c.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    c.dgvAgenda.Rows[c.dgvAgenda.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Recuperer(FormUtilisateur c)
        {
            c.btnSupprimer.Enabled = true;
            c.btnEnregistrer.Enabled = false;
            c.idutilisateur = int.Parse(c.dgvAgenda.CurrentRow.Cells[0].Value.ToString());
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboPoste.Text = c.dgvAgenda.CurrentRow.Cells[3].Value.ToString();
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtUtilisateur.Text = c.dgvAgenda.CurrentRow.Cells[1].Value.ToString();
        }
        #endregion
    }
    public class ResumeRapportCas
    {
        public int idmedecin { get; set; }
        public string nommedecin { get; set; }
        public int nbcas { get; set; }
    }
    public class BonCommandePharma
    {
        public int id { get; set; }
        public string produit { get; set; }
        public string dosage { get; set; }
        public string forme { get; set; }
        public string qtedem { get; set; }
    }
    public class BonHistoCommande
    {
        public int id { get; set; }
        public string date_com { get; set; }
        public string produit { get; set; }
        public string dosage { get; set; }
        public string forme { get; set; }
        public string qtedem { get; set; }
        public string qteservie { get; set; }
        public string qtereste { get; set; }
    }
}
