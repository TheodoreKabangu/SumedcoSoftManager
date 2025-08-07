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
                case "commande": cmdtxt = "select max(idcom) from LigneCommande"; break;
                case "commandepharma": cmdtxt = "select max(idcomph) from CommandePharma"; break;
                case "appro": cmdtxt = "select max(idappro) from LigneAppro"; break;
                case "appropharma": cmdtxt = "select max(idapproph) from ApproPharma"; break;
                case "poste": cmdtxt = "select max(idposte) from ServiceDemandeur"; break;
                case "stockpha": cmdtxt = "select max(idstockph) from LigneStockPharma"; break;
                case "sortie": cmdtxt = "select max(idsortie) from SortieStock"; break;
                case "sortiepha": cmdtxt = "select max(idsortie) from SortiePharma"; break;
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
        public bool TestMotdePass(ConnexionPass c)
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
        public void Connexion(Connexion c)
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
                            AdminMDI ad = new AdminMDI();
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
                        ReceptionMDI r = new ReceptionMDI();
                        r.idutilisateur = id;
                        RefuserAutorisation("infirmier - réception");
                        r.Show();
                    }
                    else if (c.poste == "recette")
                    {
                        RecetteMDI rec = new RecetteMDI();
                        rec.idutilisateur = id;
                        RefuserAutorisation("pharmacie - caisse");
                        rec.Show();
                    }
                    else if (c.poste == "infirmier")
                    {
                        ConnexionAutorisation aut = new ConnexionAutorisation();
                        aut.idutilisateur = id;
                        aut.poste = "infirmier";
                        aut.Show();

                    }
                    else if (c.poste == "médecin")
                    {
                        if (chaine == c.cboUtilisateur.Text)
                        {
                            MedMDI cons = new MedMDI();
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
                        AbonneMDI ab = new AbonneMDI();
                        ab.idutilisateur = id;
                        RefuserAutorisation("infirmier - abonné");
                        ab.Show();
                    }
                    else if (c.poste == "dépense")
                    {
                        TresorerieMDI d = new TresorerieMDI();
                        d.idutilisateur = id;
                        d.Show();
                    }
                    else if (c.poste == "comptable")
                    {
                        ComptabiliteMDI co = new ComptabiliteMDI();
                        co.idutilisateur = id;
                        RefuserAutorisation("infirmier - réception");
                        RefuserAutorisation("infirmier - abonné");
                        RefuserAutorisation("infirmier - médecin");
                        RefuserAutorisation("pharmacie - caisse");
                        co.Show();
                    }
                    else if (c.poste == "pharmacie")
                    {
                        if (chaine == c.cboUtilisateur.Text)
                        {
                            ConnexionAutorisation aut = new ConnexionAutorisation();
                            aut.idutilisateur = id;
                            aut.idpharma = c.idpharma;
                            aut.poste = "pharmacie";
                            aut.Show();
                        }
                        else
                        {
                            c.access_autorise = false;
                            MessageBox.Show("Accès refusé", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                        
                    }
                    else if (c.poste == "stock")
                    {
                        StockMDI s = new StockMDI();
                        s.idutilisateur = id;
                        s.Show();
                    }
                    else if (c.poste == "imagerie")
                    {
                        EchoRadioMDI s = new EchoRadioMDI();
                        s.idutilisateur = id;
                        s.Show();
                    }
                    else if (c.poste == "labo")
                    {
                        LaboMDI s = new LaboMDI();
                        s.idutilisateur = id;
                        s.Show();
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
        public void ModifierMotdePasse(Connexion c, ConnexionPass cp)
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
        public void AfficherSousForm(AdminMDI a, Form childForm)
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
        public void AfficherSousForm(Admin a, Form childForm)
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
        public void AfficherSousForm(AdminMDI a, StockProduit childForm)
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
        public void ChargerRubriques(AdminRapportCas r)
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
        public void AbonneTypePatient(AdminRapportCas r)
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
                //if (r.cboMotif.Text.ToLower() != "abonné")
                //{
                //    r.dgvRecette.Columns.Add("column_" + id, "Autre");
                //    for (int i = 0; i < r.dgvRecette.RowCount; i++)
                //    {
                //        r.dgvRecette.Rows[i].Cells[r.dgvRecette.ColumnCount - 1].Value = "0";
                //    }
                //    id++;
                //}
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
        public void AfficherCas(AdminRapportCas r)
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
                            cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ r JOIN Patient pa ON r.idpatient = pa.idpatient JOIN Entreprise e ON pa.identreprise = e.identreprise WHERE r.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND e.nomentreprise = '" + r.dgvRecette.Columns[j].HeaderText + "' AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
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
                            //if (j < r.dgvRecette.ColumnCount - 2)
                            //    cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ r JOIN Patient pa ON r.idpatient = pa.idpatient JOIN TypePatient t ON pa.idtype = t.idtype WHERE r.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND t.nomtype = '" + r.dgvRecette.Columns[j].HeaderText + "' AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                            //else
                            //    cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ r JOIN Patient pa ON r.idpatient = pa.idpatient WHERE r.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND p.idpatient is NULL AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                            cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ r JOIN Patient pa ON r.idpatient = pa.idpatient JOIN TypePatient t ON pa.idtype = t.idtype WHERE r.numcompte = '" + r.dgvRecette.Rows[i].Cells[0].Value.ToString() + "' AND t.nomtype = '" + r.dgvRecette.Columns[j].HeaderText + "' AND r.date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
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

        public void AfficherResume(AdminCasMedecin r)
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
                        //cmd = new SqlCommand("SELECT COUNT(c.idconsultation) FROM Consultation c JOIN PriseSigneVitaux psv ON c.idprise = psv.idprise JOIN Recette_ r ON psv.idrecette = r.idrecette WHERE idmedecin = '" + r.dgvResume.Rows[i].Cells[0].Value.ToString() + "' AND categorie = 'service' AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') AND c.date_consultation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                        cmd = new SqlCommand("SELECT COUNT(idprise) FROM PriseSigneVitaux WHERE idmedecin = '" + r.dgvResume.Rows[i].Cells[0].Value.ToString() + "'", con);
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
        private void AfficherGraphique(AdminCasMedecin a)
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
                case "pharma": cmd = new SqlCommand("SELECT designation FROM Pharmacie", con); break;
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
        public void Enregistrer(StockNouveau s)
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
        public void ModifierProduit(StockNouveau s)
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
        public void SupprimerProduit(StockNouveau s)
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
                MessageBox.Show("Il existe un stock de ce produit,\npour raison de cohérence, il ne peut être supprimé","Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public void Annuler(StockNouveau s)
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
        public void Afficher(StockNouveau s, string motif)
        {
            
        }
        public int CompterMvtStock(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT 
                (SELECT COUNT(idsortie) FROM SortieStock WHERE idstock = @id) + 
                (SELECT COUNT(idcom) FROM LigneCommande WHERE idstock = @id) + 
                (SELECT COUNT(idstockph) FROM LigneStockPharma WHERE idstock = @id)";
                cmd = new SqlCommand(cmdtxt, con);
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
        
        private int AjouterLigneStock(int idproduit, int qtestock, string CMM, string forme, string dosage, string lot, string expiration, double prixachat, double prixvente)
        {
            id = NouveauID("stock");
            if (CMM == "") CMM = "0";
            if (dosage == "") dosage = "RAS";
            if (lot == "") lot = "RAS";
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneStock values (@id, @idproduit, @qte, @CMM, @forme, @dosage, @numlot, @expiration, @prix_achat, @prix_vente)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idproduit", idproduit);
                cmd.Parameters.AddWithValue("@qte", qtestock); // stock initial = 0
                cmd.Parameters.AddWithValue("@CMM", CMM);// CMM initial = 0
                cmd.Parameters.AddWithValue("@forme",forme);
                cmd.Parameters.AddWithValue("@dosage", dosage);
                cmd.Parameters.AddWithValue("@numlot", lot);
                cmd.Parameters.AddWithValue("@expiration", expiration);
                cmd.Parameters.AddWithValue("@prix_achat", prixachat);
                cmd.Parameters.AddWithValue("@prix_vente", prixvente);
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
            return id;
        }
        List<int> pharma;
        public List<int> IdPharmacie()
        {
            pharma = new List<int>();
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idpharma FROM Pharmacie", con);
                dr = cmd.ExecuteReader();
                pharma.Clear();
                while (dr.Read())
                {
                    pharma.Add(Convert.ToInt32(dr[0].ToString()));
                }                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return pharma;
        }
        private void AjouterLigneStockPharma(int idstock, int qtestock)
        {
            IdPharmacie();
            for (int i = 0; i < pharma.Count; i++)
            {
                id = NouveauID("stockpha");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into LigneStockPharma values (@id, @idpharma, @idstock, @qte)", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@idpharma", pharma[i]);
                    cmd.Parameters.AddWithValue("@idstock", idstock);
                    cmd.Parameters.AddWithValue("@qte", qtestock);
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
        }
        public void AjouterStock(StockNouveau s)
        {
            s.idstock = AjouterLigneStock(
                s.idproduit,
                0,
                s.txtCMM.Text,
                s.cboForme.Text,
                s.txtDosage.Text,
                "RAS",
                "RAS",
                0,
                0
                );
            AjouterLigneStockPharma(s.idstock, 0);
            Annuler(s);
        }
        private void AjouterStock(StockApproAutre s)
        {
            if (s.cboForme.Text != "")
            {                
                s.idstock = AjouterLigneStock(
                s.idproduit,
                Convert.ToInt32(s.txtQteAppro.Text),
                s.txtCMM.Text,
                s.cboForme.Text,
                s.txtDosage.Text,
                s.txtNumLot.Text,
                s.expirationlot,
                Convert.ToDouble(s.txtPrixAchat.Text),
                Convert.ToDouble(s.txtPrixVente.Text)
                );
                AjouterLigneStockPharma(s.idstock, 0);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierStock(StockNouveau s)
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
        public void SupprimerStock(StockNouveau s)
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
        private int TotalEntreeStock(int idstock, int idpharma, string motif)
        {
            int id = 0;
            con.Open();
            try
            {
                if (motif == "pharma")
                {
                    cmdtxt = @"SELECT SUM(qteservie)
                    FROM ApproPharma a
                    JOIN CommandePharma c ON a.idcomph = c.idcomph
                    JOIN LigneStockPharma sp ON c.idstockph = sp.idstockph
                    WHERE sp.idpharma = @idpharma AND sp.idstockph = @idstock";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idpharma", idpharma);
                }
                else
                {
                    cmdtxt = @"SELECT SUM(qteajoute)
                    FROM LigneAppro a
                    JOIN LigneCommande c ON a.idcom = c.idcom
                    JOIN LigneStock s ON c.idstock = s.idstock
                    WHERE s.idstock = @idstock";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@idstock", idstock);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    if (dr[0].ToString() != "")
                        id = Convert.ToInt32(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        private int TotalSortieStock(int idstock, int idpharma, string motif)
        {
            int id = 0;
            con.Open();
            try
            {
                if (motif == "pharma")
                {
                    cmdtxt = @"SELECT SUM(qteservie)
                    FROM SortiePharma s
                    JOIN LigneStockPharma sp ON s.idstockph = sp.idstockph
                    WHERE sp.idpharma = @idpharma AND sp.idstockph = @idstock";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idpharma", idpharma);
                }
                else
                {
                    cmdtxt = @"SELECT SUM(qteservie)
                    FROM SortieStock s
                    JOIN LigneStock sp ON s.idstock = sp.idstock
                    WHERE sp.idstock = @idstock";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@idstock", idstock);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "")
                        id = Convert.ToInt32(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        long entierlong;
        public long QteStock(int idstock, int idpharma, string motif)
        {
            entierlong = 0;
            con.Open();
            try
            {
                if (motif == "pharma")
                {
                    cmdtxt = @"SELECT (SELECT qtestock FROM LigneStockPharma WHERE idstockph = @id) +
                    (SELECT COALESCE(SUM(qteservie),0)
                    FROM ApproPharma a
                    JOIN CommandePharma c ON a.idcomph = c.idcomph
                    JOIN LigneStockPharma sp ON c.idstockph = sp.idstockph
                    WHERE sp.idpharma = @idpharma AND sp.idstockph = @id) -
                    (SELECT COALESCE(SUM(qteservie), 0) 
                    FROM SortiePharma s 
                    JOIN LigneStockPharma sp ON s.idstockph = sp.idstockph 
                    WHERE sp.idpharma = @idpharma AND sp.idstockph = @id)";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idpharma", idpharma);
                }
                else
                {
                    cmdtxt = @"SELECT (SELECT qtestock from LigneStock where idstock = @id) + 
                    (SELECT COALESCE(SUM(qteajoute),0)
                    FROM LigneAppro a
                    JOIN LigneCommande c ON a.idcom = c.idcom
                    JOIN LigneStock s ON c.idstock = s.idstock
                    WHERE s.idstock = @id) -
                    (SELECT COALESCE(SUM(qteservie), 0) 
                    FROM SortieStock s 
                    JOIN LigneStock sp ON s.idstock = sp.idstock 
                    WHERE sp.idstock = @id)"; 
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "")
                        entierlong = Convert.ToInt64(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return entierlong;
        }
        public int StockGlobalPharma(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT SUM(qtestock) FROM LigneStockPharma WHERE idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "") 
                        id = Convert.ToInt32(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id + EntreesGlobalPharma(idstock) - SortiesGlobalPharma(idstock);
        }
        private int EntreesGlobalPharma(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT SUM(qteservie) FROM ApproPharma a JOIN CommandePharma c ON a.idcomph = c.idcomph JOIN LigneStockPharma sp ON sp.idstockph = c.idstockph WHERE idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "") 
                        id = Convert.ToInt32(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        private int SortiesGlobalPharma(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT SUM(qteservie) FROM SortiePharma s JOIN LigneStockPharma sp ON sp.idstockph = s.idstockph WHERE idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr[0].ToString() != "") 
                        id = Convert.ToInt32(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
       
        #endregion

        #region PHARMACIE
        public void AfficherSousForm(PharmacieMDI ph, Recette childForm)
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
        public void AfficherSousForm(PharmacieMDI ph, PharmacieVente childForm)
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
            childForm.idpharma = ph.idpharma;//Cette valeur changera selon la pharmacie
            childForm.idutilisateur = ph.idutilisateur;
            childForm.Show();
        }

        public void AfficherSousForm(PharmacieMDI ph, StockProduit child)
        {
            if (ph.activeForm != null)
                ph.activeForm.Close();
            ph.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            ph.pnlChildForm.Controls.Add(child);
            ph.pnlChildForm.Tag = child;
            child.BringToFront();
            child.poste = "pharmacie";
            child.idpharma = ph.idpharma;//Trouver l'id de la pharma qui se connecte
            child.btnNouveauStock.Visible = false;
            child.btnPharmacie.Visible = false;
            child.Show();
        }
        public void AfficherSousForm(PharmacieMDI ph, StockAlerte childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ph.pnlChildForm.Controls.Add(childForm);
            ph.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = ph.idpharma;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        public void AfficherSousForm(PharmacieMDI ph, FormUtilisation childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ph.pnlChildForm.Controls.Add(childForm);
            ph.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "pharmacie";
            childForm.idpharma = ph.idpharma;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        public void AfficherSousForm(PharmacieMDI ph, StockHistoCommande childForm)
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
            childForm.idpharma = ph.idpharma;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        public void AfficherSousForm(PharmacieMDI ph, StockInventaire childForm)
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
            childForm.idpharma = ph.idpharma;//Trouver l'id de la pharma qui se connecte
            childForm.Show();
        }
        
        #endregion

        #region GESTION_STOCKS
        public void AfficherSousForm(StockMDI s, StockProduit childForm)
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
        public void AfficherSousForm(StockMDI s, StockHistoCommande childForm)
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
        public void AfficherSousForm(StockMDI s, StockApproCom childForm)
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
        public void AfficherSousForm(StockMDI s, Form childForm)
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
        public void AfficherSousForm(StockMDI s, StockInventaire childForm)
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

        public void ServirSortieStock(StockProduit s, StockSortie com)
        {
            s.btnDemande.Enabled = false;
            com.poste = s.poste;
            com.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
            com.txtLibelle.Text = string.Format("{0}, {1}, {2}",
                s.dgvStock.CurrentRow.Cells[1].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[4].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[5].Value.ToString());

            com.txtQteStock.Text = s.dgvStock.CurrentRow.Cells[2].Value.ToString();
            com.motif_ajout = "demande";
            com.txtQteCom.Focus();
            com.ShowDialog();
            com.Close();
        }
        public void PerteSortieStock(StockProduit s, StockSortie ss)
        {
            s.btnPerte.Enabled = false;
            ss.Text = "SSM - Perte";
            ss.poste = s.poste;
            ss.motif_ajout = "perte";
            ss.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
            ss.txtLibelle.Text = string.Format("{0}, {1}, {2}",
                s.dgvStock.CurrentRow.Cells[1].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[4].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[5].Value.ToString());

            ss.txtQteStock.Text = s.dgvStock.CurrentRow.Cells[2].Value.ToString();
            ss.txtQteCom.Enabled = false;
            ss.cboPoste.Enabled = false;
            ss.txtQteCom.Focus();
            ss.ShowDialog();
            ss.Close();
        }
        public void RetourEnStock(StockProduit s, StockRetour com)
        {
            s.btnRetour.Enabled = false;
            com.poste = s.poste;
            com.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
            com.txtLibelle.Text = string.Format("{0}, {1}, {2}",
                s.dgvStock.CurrentRow.Cells[1].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[4].Value.ToString(),
                s.dgvStock.CurrentRow.Cells[5].Value.ToString());

            com.txtQte.Focus();
            com.ShowDialog();
            com.Close();
        }
        public void AjouterRetourEnStock(StockRetour c)
        {
            if (c.poste == "stock")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE LigneStock SET qtestock = qtestock + @qte WHERE idstock = @idstock", con);
                    cmd.Parameters.AddWithValue("@idstock", c.idstock);
                    cmd.Parameters.AddWithValue("@qte", Convert.ToInt32(c.txtQte.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE LigneStockPharma SET qtestock = qtestock + @qte WHERE idstockph = @idstock", con);
                    cmd.Parameters.AddWithValue("@idstock", c.idstock);
                    cmd.Parameters.AddWithValue("@qte", Convert.ToInt32(c.txtQte.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        private void AjouterSortie(StockSortie c)
        {
            if(c.poste == "stock")
            {
                id = ce.NouveauID("sortie");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (c.motif_ajout == "perte")
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
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date_jour", c.dtpDateJour.Text);
                    cmd.Parameters.AddWithValue("@idstock", c.idstock);
                    cmd.Parameters.AddWithValue("@qte_dem", Convert.ToInt32(c.txtQteCom.Text));
                    cmd.Parameters.AddWithValue("@qteservie", Convert.ToInt32(c.txtQteServie.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(c);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
            {
                id = ce.NouveauID("sortiepha");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (c.motif_ajout == "perte")
                    {
                        cmd = new SqlCommand("insert into SortiePharma (idsortie, date_jour, idstockph, qte_dem, qteservie, motif) values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif)", con);
                        cmd.Parameters.AddWithValue("@motif", c.motif_ajout);
                    }
                    else
                    {
                        cmd = new SqlCommand("insert into SortiePharma values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif, @idposte)", con);
                        cmd.Parameters.AddWithValue("@motif", "servir une demande");
                        cmd.Parameters.AddWithValue("@idposte", c.idposte);
                    }
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date_jour", c.dtpDateJour.Text);
                    cmd.Parameters.AddWithValue("@idstock", c.idstock);
                    cmd.Parameters.AddWithValue("@qte_dem", Convert.ToInt32(c.txtQteCom.Text));
                    cmd.Parameters.AddWithValue("@qteservie", Convert.ToInt32(c.txtQteServie.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(c);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        public void AjouterSortieStock(StockSortie ss)
        {
            if (ss.motif_ajout == "perte")
            {
                ss.txtQteCom.Text = ss.txtQteServie.Text; //qtecom est toujours = qteservie en cas de perte
                AjouterSortie(ss);
            }
            if (ss.txtQteCom.Text != "" && ss.txtQteServie.Text != "" && ss.cboPoste.Text != "")
            {
                if (int.Parse(ss.txtQteCom.Text) <= int.Parse(ss.txtQteStock.Text))
                {
                    if (int.Parse(ss.txtQteCom.Text) == int.Parse(ss.txtQteServie.Text))
                    {
                        AjouterSortie(ss);                       
                    }
                    else
                        MessageBox.Show("Erreur! La quantité servie doit être égale à celle requise", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Erreur! La quantité requise dépasse le stock disponilbe", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Erreur! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s)", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Annuler(StockSortie c)
        {
            c.txtQteCom.Text = "";
            c.txtQteServie.Text = "";
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboPoste.SelectedText = "";
            c.cboPoste.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtQteCom.Focus();
        }
        public void AjouterPharmacie(StockProduit s, StockPharmacie sp)
        {
            s.btnPharmacie.Enabled = false;
            sp.idstock = s.idstock;
            sp.ShowDialog();
            sp.Close();
        }

        public void FicheStock(StockProduit s, StockFicheStock f, string motif)
        {
            // le stock initial du stock sélectionné
            f.poste = s.poste;
            f.idstock = Convert.ToInt32(s.dgvStock.CurrentRow.Cells[0].Value);
            f.motif = motif;
            f.lblProduit.Text = string.Format("{0}, {1}, {2}",
                s.dgvStock.CurrentRow.Cells[1].Value,
                s.dgvStock.CurrentRow.Cells[4].Value,
                s.dgvStock.CurrentRow.Cells[5].Value);
            con.Open();
            try
            {
                if (f.poste == "pharmacie")
                    cmd = new SqlCommand("SELECT qtestock FROM LigneStockPharma WHERE idstockph = " + f.idstock + "", con);
                else
                    cmd = new SqlCommand("SELECT qtestock FROM LigneStock WHERE idstock = " + f.idstock + "", con);

                dr = cmd.ExecuteReader();
                f.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    f.dgvProduit.Rows.Add();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[0].Value = "Initial";
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[2].Value = 0;
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[3].Value = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            f.ShowDialog();
            s.btnFicheStock.Enabled = false;
        }
        public void NouveauStock(StockProduit s, StockNouveau n)
        {
            n.poste = s.poste;
            n.ShowDialog();
        }
        public void HistoriqueStock(StockFicheStock f)
        {
            //Entrées
            con.Open();
            if (f.poste == "pharmacie")
            {
                cmdtxt = @"SELECT date_appro, SUM(qteservie) 
                        FROM ApproPharma ap 
                        JOIN CommandePharma cp ON ap.idcomph = cp.idcomph
                        JOIN LigneStockPharma sp ON sp.idstockph = cp.idstockph 
                        WHERE sp.idstockph= @idstock GROUP BY date_appro";

            }
            else
            {
                cmdtxt = @"SELECT date_appro, SUM(qteajoute) 
                        FROM LigneAppro ap 
                        JOIN LigneCommande c ON ap.idcom = c.idcom
                        JOIN LigneStock s ON s.idstock = c.idstock 
                        WHERE s.idstock= @idstock GROUP BY date_appro";

            }
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@idstock", f.idstock);
            try
            {
                dr = cmd.ExecuteReader();
                f.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    f.dgvProduit.Rows.Add();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString().Substring(0, 10);
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[2].Value = "";
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[3].Value = Convert.ToInt32(f.dgvProduit.Rows[f.dgvProduit.RowCount - 2].Cells[3].Value) +
                                                                                  Convert.ToInt32(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            //Sorties
            con.Open();
            if (f.poste == "pharmacie")
            {
                cmdtxt = @"SELECT date_jour, SUM(qteservie) 
                        FROM SortiePharma s 
                        JOIN LigneStockPharma sp ON sp.idstockph = s.idstockph 
                        WHERE sp.idstockph= @idstock GROUP BY date_jour";

            }
            else
            {
                cmdtxt = @"SELECT date_jour, SUM(qteservie) 
                        FROM SortieStock ss 
                        JOIN LigneStock s ON s.idstock = ss.idstock 
                        WHERE s.idstock= @idstock GROUP BY date_jour";

            }
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@idstock", f.idstock);
            try
            {
                dr = cmd.ExecuteReader();
                f.dgvProduit.Rows.Clear();
                while (dr.Read())
                {
                    f.dgvProduit.Rows.Add();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString().Substring(0, 10);
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[1].Value = "";
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[3].Value = Convert.ToInt32(f.dgvProduit.Rows[f.dgvProduit.RowCount - 2].Cells[3].Value) -
                                                                                  Convert.ToInt32(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void EntreeSortieStock(StockFicheStock f, string motif)
        {
            if (f.dtpDateDe.Value.Date <= f.dtpDateA.Value.Date)
            {
                if (motif == "entrée")
                {
                    EntreeStock(f);
                    f.dgvProduit.Columns[3].Visible = false;
                }
                else if (motif == "sortie")
                {
                    SortieStock(f);
                    f.dgvProduit.Columns[3].Visible = false;
                }
                else
                {
                    EntreeStock(f);
                    SortieStock(f);
                }
            }
            else MessageBox.Show("Vérifiez que les dates sont ordonnées du l'inférieur au supérieur", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void SortieStock(StockFicheStock f)
        {
            con.Open();
            if (f.poste == "pharmacie")
            {
                cmdtxt = @"SELECT date_jour, SUM(qteservie) 
                        FROM SortiePharma s 
                        JOIN LigneStockPharma sp ON sp.idstockph = s.idstockph 
                        WHERE sp.idstockph= @idstock AND date_jour BETWEEN @dateDe AND @dateA
                        GROUP BY date_jour";

            }
            else
            {
                cmdtxt = @"SELECT date_jour, SUM(qteservie) 
                        FROM SortieStock ss 
                        JOIN LigneStock s ON s.idstock = ss.idstock 
                        WHERE s.idstock= @idstock AND date_jour BETWEEN @dateDe AND @dateA
                        GROUP BY date_jour";

            }
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@idstock", f.idstock);
            cmd.Parameters.AddWithValue("@dateDe", f.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", f.dtpDateA.Value.Date);
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f.dgvProduit.Rows.Add();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString().Substring(0, 10);
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[1].Value = "";
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[3].Value = Convert.ToInt32(f.dgvProduit.Rows[f.dgvProduit.RowCount - 2].Cells[3].Value) - Convert.ToInt32(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        private void EntreeStock(StockFicheStock f)
        {
            con.Open();
            if (f.poste == "pharmacie")
            {
                cmdtxt = @"SELECT date_appro, SUM(qteservie) 
                        FROM ApproPharma ap 
                        JOIN CommandePharma cp ON ap.idcomph = cp.idcomph
                        JOIN LigneStockPharma sp ON sp.idstockph = cp.idstockph 
                        WHERE sp.idstockph= @idstock AND date_appro BETWEEN @dateDe AND @dateA
                        GROUP BY date_appro";
            }
            else
            {
                cmdtxt = @"SELECT date_appro, SUM(qteajoute) 
                        FROM LigneAppro ap 
                        JOIN LigneCommande c ON ap.idcom = c.idcom
                        JOIN LigneStock s ON s.idstock = c.idstock 
                        WHERE s.idstock= @idstock AND date_appro BETWEEN @dateDe AND @dateA
                        GROUP BY date_appro";
            }
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@idstock", f.idstock);
            cmd.Parameters.AddWithValue("@dateDe", f.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", f.dtpDateA.Value.Date);
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    f.dgvProduit.Rows.Add();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString().Substring(0, 10);
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[2].Value = "";
                    f.dgvProduit.Rows[f.dgvProduit.RowCount - 1].Cells[3].Value = Convert.ToInt32(f.dgvProduit.Rows[f.dgvProduit.RowCount - 2].Cells[3].Value) + Convert.ToInt32(dr[1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close(); 
        }
        public void ImprimerFicheStock(StockFicheStock f, FormImpression imp)
        {
            imp.Text = "SSM - Fiche de stock";
            imp.beneficiaire = f.lblProduit.Text;
            imp.bonrequisition = f.poste;
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("produit", imp.beneficiaire),
                new ReportParameter("poste", imp.bonrequisition)
            };
            List<FicheStock> list = new List<FicheStock>();
            list.Clear();

            for (int i = 0; i < f.dgvProduit.RowCount; i++)
            {
                FicheStock ligne = new FicheStock
                {
                    num = (i+1).ToString(),
                    date_jour = f.dgvProduit.Rows[i].Cells[0].Value.ToString(),
                    entree = f.dgvProduit.Rows[i].Cells[1].Value.ToString(),
                    sortie = f.dgvProduit.Rows[i].Cells[2].Value.ToString(),
                    stock = f.dgvProduit.Rows[i].Cells[3].Value.ToString(),
                };
                list.Add(ligne);
            }
            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.FicheStock.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
            imp.Close();
        }
        public void ChargerProduit(StockNouveau s, string motif)
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
        public void ChargerStock(StockNouveau s)
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

        ClasseElements ce = new ClasseElements();
        public void Stocks(StockProduit s)
        {
            con.Open();
            try
            {
                if (s.poste == "pharmacie")
                {
                    if(s.txtRecherche.Text == "")
                        cmdtxt = @"SELECT idstockph as ID, nomproduit AS Produit, sp.qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStockPharma sp
                            JOIN LigneStock s ON sp.idstock = s.idstock
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND sp.idpharma = '" + s.idpharma + "' ORDER BY nomproduit";
                    else
                        cmdtxt = @"SELECT idstockph as ID, nomproduit AS Produit, sp.qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStockPharma sp
                            JOIN LigneStock s ON sp.idstock = s.idstock
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND sp.idpharma = '" + s.idpharma + "' AND nomproduit LIKE '" + s.txtRecherche.Text.Replace("'", "") + "%' ORDER BY nomproduit";
                }
                else
                {
                    if(s.txtRecherche.Text == "")
                        cmdtxt = @"SELECT idstock as ID, nomproduit AS Produit, qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStock s
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " ORDER BY nomproduit";
                    else
                        cmdtxt = @"SELECT idstock as ID, nomproduit AS Produit, qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStock s
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND nomproduit LIKE '" + s.txtRecherche.Text.Replace("'", "") + "%' ORDER BY nomproduit";
                }
                cmd = new SqlCommand(cmdtxt, con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                s.dgvStock.DataSource = dt;
                ce.FigerColonne(s.dgvStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            TotalStock(s, "");
        }
        public void AlerteStock(StockProduit s)
        {
            con.Open();
            try
            {
                if (s.poste == "pharmacie")
                {
                    if (s.txtRecherche.Text == "")
                        cmdtxt = @"SELECT idstockph as ID, nomproduit AS Produit, sp.qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStockPharma sp
                            JOIN LigneStock s ON sp.idstock = s.idstock
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND sp.idpharma = '" + s.idpharma + "' AND sp.qtestock < 200 ORDER BY nomproduit";
                    else
                        cmdtxt = @"SELECT idstockph as ID, nomproduit AS Produit, sp.qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStockPharma sp
                            JOIN LigneStock s ON sp.idstock = s.idstock
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND sp.idpharma = '" + s.idpharma + "' AND sp.qtestock < 200 AND nomproduit LIKE '" + s.txtRecherche.Text.Replace("'", "") + "%' ORDER BY nomproduit";
                }
                else
                {
                    if (s.txtRecherche.Text == "")
                        cmdtxt = @"SELECT idstock as ID, nomproduit AS Produit, qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStock s
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = " + s.idcat + " AND qtestock < 200 ORDER BY nomproduit";
                    else
                        cmdtxt = @"SELECT idstock as ID, nomproduit AS Produit, qtestock AS Qté, CMM, forme AS Forme, dosage AS Dosage, numlot AS Lot, expiration AS Expiration, prixunitaire AS [Prix U.] 
                            FROM LigneStock s
                            JOIN Produit p ON s.idproduit = p.idproduit
                            JOIN CategorieProduit c ON p.idcat = c.idcat
                            WHERE p.idcat = "+s.idcat+" AND qtestock < 200 AND nomproduit LIKE '" + s.txtRecherche.Text.Replace("'", "") + "%' ORDER BY nomproduit";
                }
                cmd = new SqlCommand(cmdtxt, con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                s.dgvStock.DataSource = dt;
                ce.FigerColonne(s.dgvStock);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            TotalStock(s, "alerte");
        }
        private void TotalStock(StockProduit s, string motif)
        {
            if (s.dgvStock.RowCount != 0)
            {
                for (int i = s.dgvStock.RowCount - 1; i >= 0; i--)
                {
                    if (s.poste == "pharmacie")
                    {
                        s.dgvStock.Rows[i].Cells[2].Value = QteStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value), s.idpharma, "pharma");
                    }
                    else
                    {
                        s.dgvStock.Rows[i].Cells[2].Value = QteStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value), s.idpharma, "stock");
                    }
                    if (motif == "alerte" && Convert.ToInt32(s.dgvStock.Rows[i].Cells[2].Value) > 200)
                    {
                        s.dgvStock.Rows.RemoveAt(s.dgvStock.Rows[i].Index);
                    }
                }
            }
        }
        public void PreparerCommandde(StockProduit s, StockAlerte sa)
        {
            s.btnCmdPrep.Enabled = false;
            if (s.dgvStock.RowCount > 0)
            {
                foreach (DataGridViewRow row in s.dgvStock.SelectedRows)
                {
                    sa.dgvStock.Rows.Add();
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[0].Value = row.Cells[0].Value;
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[1].Value = row.Cells[1].Value;
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[2].Value = row.Cells[4].Value;
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[3].Value = row.Cells[5].Value;
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[4].Value = row.Cells[2].Value;
                    sa.dgvStock.Rows[sa.dgvStock.RowCount - 1].Cells[5].Value = 0;
                }
                sa.poste = s.poste;
                sa.ShowDialog();
                sa.Close();
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AfficherCommande(StockHistoCommande c, string motif)
        {
            if (c.dtpDateDe.Value.Date <= c.dtpDateA.Value.Date)
            {
                if (c.cboCategorie.Text != "")
                {
                    con.Open();
                    try
                    {
                        if (c.poste == "pharmacie")
                        {
                            if (motif == "recherche")
                                cmdtxt = @"SELECT c.idcomph, date_com, nomproduit, forme, dosage, qtecom, SUM(qteservie) AS qteservie  
                                FROM CommandePharma c
                                JOIN LigneStockPharma sp ON c.idstockph = sp.idstockph
                                JOIN LigneStock s ON sp.idstock = s.idstock
                                JOIN Produit p ON s.idproduit = p.idproduit
                                LEFT JOIN ApproPharma a ON a.idcomph = c.idcomph
                                WHERE date_com BETWEEN @dateDe AND @dateA AND 
                                idpharma = '" + c.idpharma + "' AND idcat = '" + c.idcat + "' AND nomproduit LIKE '" + c.txtRecherche.Text + "%' GROUP BY c.idcomph, date_com, nomproduit, forme, dosage, qtecom";
                            else
                                cmdtxt = @"SELECT c.idcomph, date_com, nomproduit, forme, dosage, qtecom, SUM(qteservie) AS qteservie  
                                FROM CommandePharma c
                                JOIN LigneStockPharma sp ON c.idstockph = sp.idstockph
                                JOIN LigneStock s ON sp.idstock = s.idstock
                                JOIN Produit p ON s.idproduit = p.idproduit
                                LEFT JOIN ApproPharma a ON a.idcomph = c.idcomph
                                WHERE date_com BETWEEN @dateDe AND @dateA AND 
                                idpharma = '" + c.idpharma + "' AND idcat = '" + c.idcat + "' GROUP BY c.idcomph, date_com, nomproduit, forme, dosage, qtecom ";
                        }
                        else
                        {
                            if (motif == "recherche")
                                cmdtxt = @"SELECT c.idcom, date_com, nomproduit, forme, dosage, qtedem, SUM(qteajoute) AS qteservie 
                                FROM LigneCommande c
                                JOIN LigneStock s ON c.idstock = s.idstock
                                JOIN Produit p ON s.idproduit = p.idproduit
                                LEFT JOIN LigneAppro a ON a.idcom = c.idcom
                                WHERE date_com BETWEEN @dateDe AND @dateA AND 
                                idcat = '" + c.idcat + "' AND nomproduit LIKE '" + c.txtRecherche.Text + "%' GROUP BY c.idcom, date_com, nomproduit, forme, dosage, qtedem";
                            else
                                cmdtxt = @"SELECT c.idcom, date_com, nomproduit, forme, dosage, qtedem, SUM(qteajoute) AS qteservie 
                                FROM LigneCommande c
                                JOIN LigneStock s ON c.idstock = s.idstock
                                JOIN Produit p ON s.idproduit = p.idproduit
                                LEFT JOIN LigneAppro a ON a.idcom = c.idcom
                                WHERE date_com BETWEEN @dateDe AND @dateA AND 
                                idcat = '" + c.idcat + "' GROUP BY c.idcom, date_com, nomproduit, forme, dosage, qtedem";
                        }
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                        dr = cmd.ExecuteReader();
                        c.dgv.Rows.Clear();
                        while (dr.Read())
                        {
                            c.dgv.Rows.Add();
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();

                            if (dr[6].ToString() != "") 
                                c.dgv.Rows[c.dgv.RowCount - 1].Cells[6].Value = dr[6].ToString();
                            else
                                c.dgv.Rows[c.dgv.RowCount - 1].Cells[6].Value = 0;
                            c.dgv.Rows[c.dgv.RowCount - 1].Cells[7].Value = Convert.ToInt32(c.dgv.Rows[c.dgv.RowCount - 1].Cells[5].Value) - Convert.ToInt32(c.dgv.Rows[c.dgv.RowCount - 1].Cells[6].Value);
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();                   
                }
                else MessageBox.Show("Aucune catégorie n'est sélectionnée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Vérifiez que les dates sont ordonnées du l'inférieur au supérieur", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void TrouverStockPharma(StockInventaire s)
        {
            con.Open();
            try
            {
                
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = 0;
                }
            }
            catch(Exception ex)
            {

            }
            con.Close();
        }
        public void AfficherStockProduit(StockInventaire s)
        {
            con.Open();
            try
            {
                if (s.poste == "pharmacie")
                {
                    s.cboDepot.Enabled = false;
                }
                if (s.poste == "pharmacie"||s.cboDepot.Text != "")
                {
                    cmdtxt = @"SELECT idstockph, nomproduit, forme, dosage, sp.idstock 
                    FROM LigneStockPharma sp
                    JOIN LigneStock s ON sp.idstock = s.idstock
                    JOIN Produit p ON p.idproduit = s.idproduit
                    WHERE idpharma = "+s.idpharma+"";
                    cmd = new SqlCommand(cmdtxt, con);                 
                }
                else
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
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = 0; //qte
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = 0;
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = 0;
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = 0;
                    if (s.poste == "pharmacie" || s.cboDepot.Text != "")
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = dr[4].ToString();
                    else
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (s.dgvStock.RowCount != 0)
            {
                //Qte stock pour la pharmacie
                if (s.poste == "pharmacie" || s.cboDepot.Text != "")
                {
                    for (int i = 0; i < s.dgvStock.RowCount; i++)
                    {
                        s.dgvStock.Rows[i].Cells[4].Value = QteStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value), s.idpharma, "pharma");
                        //s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value
                    }
                }                   
                else
                {
                    for (int i = 0; i < s.dgvStock.RowCount; i++)
                    {
                        s.dgvStock.Rows[i].Cells[4].Value = QteStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value), s.idpharma, "stock") ;
                    }
                }                
            }            
        }
        public void TrouverQteStock(StockInventaire s)
        {
            AfficherStockProduit(s);
            
            for (int i = 0; i < s.dgvStock.RowCount; i++)
            {
                //EntréeS;
                con.Open();
                try
                {
                    if(s.poste == "pharmacie"||s.cboDepot.Text != "")
                        cmdtxt = @"SELECT SUM(qteservie) entree
                        FROM ApproPharma ap 
                        JOIN CommandePharma cp ON ap.idcomph = cp.idcomph
                        JOIN LigneStockPharma sp ON cp.idstockph = sp.idstockph                        
                        WHERE idpharma = '" + s.idpharma + "' AND sp.idstockph = @idstock AND date_appro BETWEEN @dateDe AND @dateA";
                    else
                        cmdtxt = @"SELECT SUM(qteajoute) entree
                        FROM LigneAppro a
                        JOIN LigneCommande c ON a.idcom = c.idcom
                        JOIN LigneStock s ON c.idstock = s.idstock
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
               
                //SortieStock
                con.Open();
                try
                {
                    if (s.poste == "pharmacie" || s.cboDepot.Text != "")
                        cmdtxt = @"SELECT SUM(qteservie) sortie
                        FROM SortiePharma sph 
                        JOIN LigneStockPharma sp ON sph.idstockph = sp.idstockph                       
                        WHERE idpharma = '" + s.idpharma + "' AND sp.idstockph = @idstock AND date_jour BETWEEN @dateDe AND @dateA";
                    else
                        cmdtxt = @"SELECT SUM(qteservie) sortie
                        FROM LigneStock s
                        JOIN SortieStock ss ON ss.idstock = s.idstock
                        WHERE s.idstock = @idstock AND date_jour BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idstock", s.dgvStock.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@dateDe", s.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", s.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                            s.dgvStock.Rows[i].Cells[6].Value = Convert.ToInt32(dr[0].ToString());
                        //Convert.ToInt32(s.dgvStock.Rows[i].Cells[6].Value) + Convert.ToInt32(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                //Calcul Valeur stock
                if (s.poste == "pharmacie" || s.cboDepot.Text != "") 
                    s.dgvStock.Rows[i].Cells[7].Value = Convert.ToInt32(s.dgvStock.Rows[i].Cells[4].Value) * PrixStock(Convert.ToInt32(s.dgvStock.Rows[i].Cells[8].Value), "achat");
                else
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
        public void AjouterCommande(StockAlerte s, string poste)
        {
            s.ajout_effectue = false;
            for (int i = s.dgvStock.RowCount - 1; i >= 0; i--)
            {
                s.idstock = Convert.ToInt32(s.dgvStock.Rows[i].Cells[0].Value);
                try
                {
                    if (Convert.ToInt32(s.dgvStock.Rows[i].Cells[5].Value.ToString()) > 0)
                    {
                        if (VerifierCommande(s.idstock, s.dtpDateJour.Text, poste) == 0)
                        {
                            if (poste == "stock")
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
                                    cmd.Parameters.AddWithValue("@qtecom", s.dgvStock.Rows[i].Cells[5].Value.ToString());
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
                                    cmd.Parameters.AddWithValue("@qtecom", s.dgvStock.Rows[i].Cells[5].Value.ToString());
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
                    MessageBox.Show("Valeur incorrecte", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (s.ajout_effectue)
            {
                MessageBox.Show("Commande ajoutée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                s.dgvStock.Rows.Clear();
            }
        }
        private int VerifierCommande(int idstock, string date_jour, string poste)
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
        public void MiseAJourCommande(StockHistoCommande c, string poste)
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
        public void ImprimerBonCommande(StockApproCom a, FormImpression imp)
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
        public void ImprimerHistoCommande(StockHistoCommande a, FormImpression imp)
        {
            if (a.dgv.RowCount != 0)
            {
                imp.Text = "SSM - Historique de Commande";

                List<BonHistoCommande> list = new List<BonHistoCommande>();
                list.Clear();

                for (int i = 0; i < a.dgv.RowCount; i++)
                {
                    BonHistoCommande bc = new BonHistoCommande
                    {
                        id = list.Count + 1,
                        date_com = a.dgv.Rows[i].Cells[1].Value.ToString(),
                        produit = a.dgv.Rows[i].Cells[2].Value.ToString(),
                        forme = a.dgv.Rows[i].Cells[3].Value.ToString(),
                        dosage = a.dgv.Rows[i].Cells[4].Value.ToString(),
                        qtedem = a.dgv.Rows[i].Cells[5].Value.ToString(),
                        qteservie = a.dgv.Rows[i].Cells[6].Value.ToString(),
                        qtereste = a.dgv.Rows[i].Cells[7].Value.ToString(),
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
        public void AfficherSousForm(StockMDI s, ReceptionRapport childForm)
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
        public void HistoriqueApproStockAutre(ComptabiliteMDI c, StockApprov childForm)
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
        public void AfficherToutStock(ReceptionRapport s)
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
        public void DiminuerStock(StockAlerte c)
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
        #endregion

        #region STOCK_PHARMA
        public int VerifierStockPharma(StockPharmacie s)
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
        
        public void Enregistrer(StockPharmacie s)
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
        public void AjouterNouvellePharma(StockPharmacie p)
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
                    AjouterServiceDemandeur(p.txtPharmacie.Text);
                    
                    //Ajouter un compte utilisateur
                    AjouterNouvelUtilisateur(p.txtPharmacie.Text, "pharmacie", p.txtPharmacie.Text);
                }
                else MessageBox.Show("Cette pharmacie existe déjà dans le système", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            p.txtPharmacie.Enabled = false;
            p.txtPharmacie.Text = "";
            p.btnValider.Enabled = false;
        }
        public void AjouterServiceDemandeur(string service)
        {
            id = NouveauID("poste");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into ServiceDemandeur values (@idposte, @nomposte)", con);
                cmd.Parameters.AddWithValue("@idposte", id);
                cmd.Parameters.AddWithValue("@nomposte", service);
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
        public void AjouterNouvelUtilisateur(string utilisateur, string poste, string specification)
        {
            id = NouveauID("user");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Utilisateur values (@id, @util, @mot, @poste, @specification)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@util", utilisateur);
                cmd.Parameters.AddWithValue("@mot", "123456");
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.Parameters.AddWithValue("@specification", specification);
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
        public void ApprovisionnerStock2(StockApproCom a, StockApproAutre ap)
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
        public void EnregistrerAppro(StockApprov a)
        {
            if(a.poste == "comptable")
            {
                for (int i = 0; i < a.dgvAppro.RowCount; i++)
                {
                    a.idAppro = ce.NouveauID("appro");
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
                for (int i = 0; i < a.dgvAppro.RowCount; i++)
                {
                    a.idAppro = ce.NouveauID("appropharma");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ApproPharma values (@idapproph, @date_appro, @idcomph, @qteservie)", con);
                        cmd.Parameters.AddWithValue("@idapproph", a.idAppro);
                        cmd.Parameters.AddWithValue("@date_appro", a.dtpDateJour.Text);
                        cmd.Parameters.AddWithValue("@idcomph", a.dgvAppro.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@qteservie", a.dgvAppro.Rows[i].Cells[6].Value.ToString());
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public void AjouterProduit(StockApproAutre a)
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
        public void Annuler(StockApproAutre a)
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
        public void AjouterApproAutre(StockApproAutre a)
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
        public void ChargerProduit(StockApproAutre s, string motif)
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
        private int TotalApproAjoute(int idcom, string motif)
        {
            id = 0;
            con.Open();
            try
            {
                if (motif == "appro")
                    cmd = new SqlCommand("SELECT COUNT(qteajoute), SUM(qteajoute) FROM LigneAppro WHERE idcom = '" + idcom + "'", con);
                else
                    cmd = new SqlCommand("SELECT COUNT(qteservie), SUM(qteservie) FROM ApproPharma WHERE idcomph = '" + idcom + "'", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() != "0")
                    id = Convert.ToInt32(dr[1].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void ApprovisionnerStock(StockApproCom a, StockApprov ap)
        {
            if (a.dgvCommande.RowCount != 0)
            {
                ap.poste = a.poste;
                ap.categorie_produit = a.cboCategorie.Text;
                ap.idexercice = a.idexercice;
                for (int i = 0; i < a.dgvCommande.RowCount; i++)
                {
                    if (ap.poste == "comptable")
                    {
                        if (Convert.ToInt32(a.dgvCommande.Rows[i].Cells[5].Value) - TotalApproAjoute(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[0].Value), "appro") > 0)
                        {
                            ap.dgvAppro.Rows.Add();
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[0].Value = a.dgvCommande.Rows[i].Cells[0].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}, {2}",
                            a.dgvCommande.Rows[i].Cells[2].Value.ToString(),
                            a.dgvCommande.Rows[i].Cells[3].Value.ToString(),
                            a.dgvCommande.Rows[i].Cells[4].Value.ToString());

                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[2].Value = "";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[3].Value = "";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[4].Value = a.dgvCommande.Rows[i].Cells[5].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[5].Value = Convert.ToInt32(a.dgvCommande.Rows[i].Cells[5].Value) - TotalApproAjoute(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[0].Value), "appro");
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[6].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[7].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[8].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[9].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[12].Value = "RAS";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[13].Value = a.dgvCommande.Rows[i].Cells[6].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[10].Value = PrixStock(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[6].Value), "vente");
                            if (ap.categorie_produit.ToLower() == "pharmaceutique")
                                ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[14].Value = "OUI";
                            else
                                ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[14].Value = "NON";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[15].Value = a.dgvCommande.Rows[i].Cells[7].Value;
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(a.dgvCommande.Rows[i].Cells[5].Value) - TotalApproAjoute(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[0].Value), "") > 0)
                        {
                            ap.dgvAppro.Rows.Add();
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[0].Value = a.dgvCommande.Rows[i].Cells[0].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}, {2}",
                            a.dgvCommande.Rows[i].Cells[2].Value.ToString(),
                            a.dgvCommande.Rows[i].Cells[3].Value.ToString(),
                            a.dgvCommande.Rows[i].Cells[4].Value.ToString());

                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[2].Value = "";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[3].Value = "";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[4].Value = a.dgvCommande.Rows[i].Cells[5].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[5].Value = Convert.ToInt32(a.dgvCommande.Rows[i].Cells[5].Value) - TotalApproAjoute(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[0].Value), "");
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[6].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[7].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[8].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[9].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[12].Value = "RAS";
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[13].Value = a.dgvCommande.Rows[i].Cells[6].Value;
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[10].Value = PrixStock(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[6].Value), "vente");
                        }
                    }
                }
                if (ap.dgvAppro.RowCount != 0)
                {
                    ////Ligne total
                    //ap.dgvAppro.Rows.Add();
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[0].Value = "";
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[1].Value = "Total appro.";
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                    //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].ReadOnly = true;

                    if (ap.poste == "comptable" && ap.categorie_produit.ToLower() == "pharmaceutique")
                    {
                        ap.dgvAppro.Columns[2].ReadOnly = false;
                        ap.dgvAppro.Columns[3].ReadOnly = false;
                        ap.checkBox2.Enabled = false;
                    }
                    else if (ap.poste != "comptable")
                    {
                        ap.depot = a.cboDepot.Text;//Le dépôt à approvisionner
                        ap.txtTaux.Enabled = false;
                        ap.checkBox2.Enabled = false;
                        ap.txtValeurMin.Enabled = false;
                        ap.dgvAppro.Columns[2].Visible = false;
                        ap.dgvAppro.Columns[3].Visible = false;
                        for (int i = 7; i < ap.dgvAppro.ColumnCount; i++)
                        {
                            ap.dgvAppro.Columns[i].Visible = false;
                        }
                        //ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Visible = false;
                    }
                    ap.ShowDialog();
                    ap.Close();
                }
                else
                    MessageBox.Show("Aucune ligne à approvisionner n'a été trouvée", "Approvisionnement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Aucune commande n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Approvisionner(StockApprov ap)
        {
            for (int i = ap.dgvAppro.RowCount-1; i >= 0; i--)
            {
                if (ap.poste == "comptable")
                {
                    if (Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[11].Value) == 0)
                    {
                        ap.dgvAppro.Rows.RemoveAt(ap.dgvAppro.Rows[i].Index);
                    }
                }
                else
                {
                    if (Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[6].Value) == 0)
                    {
                        ap.dgvAppro.Rows.RemoveAt(ap.dgvAppro.Rows[i].Index);
                    }
                }
            }
            if (ap.dgvAppro.RowCount != 0)
            {
                if (ap.poste == "comptable")
                {
                    ap.lotvalide = true;
                    for (int i = 0; i < ap.dgvAppro.RowCount; i++)
                    {
                        if (ap.dgvAppro.Rows[i].Cells[14].Value.ToString() == "OUI")
                        {
                            if (ap.dgvAppro.Rows[i].Cells[2].Value.ToString() == "" || ap.dgvAppro.Rows[i].Cells[3].Value.ToString() == "")
                                ap.lotvalide = false;
                        }
                    }
                    if (ap.lotvalide)
                    {
                        EnregistrerAppro(ap);
                        MiseAJourLigneStock(ap);
                    }
                    else
                        MessageBox.Show("Fournissez le numéro lot et la date d'expiration pour tout produit expirable", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    EnregistrerAppro(ap);
                    MiseAJourLigneStock(ap);
                }
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void CalculLigne(StockApprov a)
        {
            for (int i = 3; i < a.dgvAppro.ColumnCount; i++)
            {
                if (i == 3)
                {
                    if (a.dgvAppro.CurrentRow.Cells[2].Value.ToString() != "")
                    {
                        a.dgvAppro.CurrentRow.Cells[2].Style.BackColor = Color.Lavender;
                        a.dgvAppro.CurrentRow.Cells[2].Style.SelectionBackColor = Color.LightSteelBlue;
                    }
                    else
                    {
                        a.dgvAppro.CurrentRow.Cells[2].Style.BackColor = Color.IndianRed;
                        a.dgvAppro.CurrentRow.Cells[2].Style.SelectionBackColor = Color.IndianRed;
                    }
                }
                else if (i >= 6 && i < 9)
                {
                    try
                    {
                        if (Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[i].Value) >= 0)
                        {
                            if (Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[6].Value) <= Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[5].Value))
                            {
                                if (Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[7].Value) > 0)
                                {
                                    if (a.txtTaux.Text == "")
                                        a.txtTaux.Text = "20";
                                    a.dgvAppro.CurrentRow.Cells[9].Value = Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[8].Value) + Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[8].Value) * Convert.ToDouble(a.txtTaux.Text) / 100;
                                    if (a.txtValeurMin.Text != "")
                                        a.dgvAppro.CurrentRow.Cells[9].Value = Convert.ToInt32(a.txtValeurMin.Text) * Math.Ceiling(Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[9].Value) / Convert.ToInt32(a.txtValeurMin.Text));
                                    a.dgvAppro.CurrentRow.Cells[11].Value = Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[6].Value) * Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[8].Value);
                                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                                    for (int j = 0; j < a.dgvAppro.RowCount - 1; j++)
                                    {
                                        a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = Convert.ToDouble(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value) + Convert.ToDouble(a.dgvAppro.Rows[j].Cells[11].Value);
                                    }
                                }
                                else
                                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                            }
                            else
                            {
                                MessageBox.Show("La quantité approvisionnée ne doit pas dépasser le reste à approvisionner", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                a.dgvAppro.CurrentRow.Cells[6].Value = 0;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Valeur négative non autorisée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            a.dgvAppro.CurrentCell.Value = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La valeur saisie est invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        a.dgvAppro.CurrentCell.Value = 0;
                    }
                }
            }
        }
        public void AfficherCommande(StockApproCom a, string motif)
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
                        where date_com BETWEEN @dateDe AND @dateA AND idcat = @idcat";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idcat", a.idcat);
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    a.dgvCommande.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvCommande.Rows.Add();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
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
        public void TrouverApproCommande(StockApproCom a)
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
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }

        public void MiseAJourAppro(StockApproCom a)
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

        public void MiseAJourLigneStock(StockApprov ap)
        {
            if(ap.poste == "comptable")
            {
                for (int i = 0; i < ap.dgvAppro.RowCount; i++)
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
                            cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, prix_achat = @prix_achat, prixunitaire = @prix where idstock = @id", con);
                            cmd.Parameters.AddWithValue("@prix", ap.prixvente);
                            cmd.Parameters.AddWithValue("@numlot", ap.dgvAppro.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@expiration", ap.dgvAppro.Rows[i].Cells[3].Value.ToString());
                        }
                        else if (ap.categorie_produit.ToLower() != "pharmaceutique" && ap.dgvAppro.Rows[i].Cells[2].Value.ToString() != "" && ap.dgvAppro.Rows[i].Cells[3].Value.ToString() != "")
                        {
                            cmd = new SqlCommand("update LigneStock set numlot = @numlot, expiration = @expiration, prix_achat = @prix_achat where idstock = @id", con);
                            cmd.Parameters.AddWithValue("@numlot", ap.dgvAppro.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@expiration", ap.dgvAppro.Rows[i].Cells[3].Value.ToString());
                        }
                        else
                            cmd = new SqlCommand("update LigneStock set prix_achat = @prix_achat where idstock = @id", con);
                        cmd.Parameters.AddWithValue("@id", ap.dgvAppro.Rows[i].Cells[13].Value.ToString());
                        cmd.Parameters.AddWithValue("@prix_achat", ap.prix_achat);

                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }               
            }
            else //Ajouter une sortie stock par ligne Appro
            {
                for (int i = 0; i < ap.dgvAppro.RowCount; i++)
                {
                    ap.idposte = TrouverId("poste", ap.depot);
                    id = NouveauID("sortie");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into SortieStock values (@id, @date_jour, @idstock, @qte_dem, @qteservie, @motif, @idposte)", con);
                        cmd.Parameters.AddWithValue("@motif", "servir une demande");
                        cmd.Parameters.AddWithValue("@idposte", ap.idposte);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@date_jour", ap.dtpDateJour.Text);
                        cmd.Parameters.AddWithValue("@idstock", Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[13].Value));
                        cmd.Parameters.AddWithValue("@qte_dem", Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[4].Value));
                        cmd.Parameters.AddWithValue("@qteservie", Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[6].Value));
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
            ap.dgvAppro.Rows.Clear();
            MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region APPRO_STOCK_SECONDAIRES
        public void AfficherCommandePha(StockApproCom a, string motif)
        {
            if (a.cboCategorie.Text != "" && a.cboDepot.Text != "")
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
                        WHERE idpharma = @idpharma AND categorie = @categ 
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
                        WHERE idpharma = @idpharma AND categorie = @categ 
                        AND date_com BETWEEN @dateDe AND @dateA";
                        
                    }
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@categ", a.cboCategorie.Text);
                    cmd.Parameters.AddWithValue("@idpharma", a.idpharma);
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                    dr = cmd.ExecuteReader();
                    a.dgvCommande.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvCommande.Rows.Add();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvCommande.Rows[a.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
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
            else MessageBox.Show("Vérifiez qu'une catégorie et un dépôt sont sélectionnés", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void TrouverApproCommandePha(StockApproCom a)
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
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[4].Value = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        #endregion

        #region UTILISATEUR
        public void Enregistrer(AdminUtilisateur u)
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
        public void Annuler(AdminUtilisateur c)
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
        public void Modifier(AdminUtilisateur u)
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
        public void Modifier(ConnexionPass c)
        {
            if(TestMotdePass(c))
            {
                if (c.txtNouveauMdPass.Text == c.txtConfirmerMdPass.Text && c.txtNouveauMdPass.Text != "11111111" && c.txtNouveauMdPass.Text != "12345678")
                {
                    if(c.txtNouveauMdPass.Text.Length >= 6)
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
                        MessageBox.Show("Le mot de passe doit avoir une taille miniamale de 6 caractères", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        c.txtNouveauMdPass.Select();
                    }
                }
                else
                    MessageBox.Show("Confirmation du nouveau mot de passe invalide! \n\nLe mot de passe ne doit pas être si facile que 111111 ou 123456", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Supprimer(AdminUtilisateur c)
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
        public void Afficher(AdminUtilisateur c)
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
        public void Recuperer(AdminUtilisateur c)
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
    public class FicheStock
    {
        public string num { get; set; }
        public string date_jour { get; set; }
        public string entree { get; set; }
        public string sortie { get; set; }
        public string stock { get; set; }
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
