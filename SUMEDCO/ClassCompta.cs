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
    class ClassCompta
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        string chaine= "", cmdtxt = "", nom = "";
        int id = 0;
        double valeur;
        #region METHODES GENERALES
        public int TrouverId(string motif, string nom)
        {
            id = 0;
            switch (motif)
            {
                case "service": cmdtxt = "select idservice from Service where nomservice = @nom"; break;
                case "numcompte": cmdtxt = "select numcompte from Compte where libellecompte = @nom"; break;
                case "entreprise": cmdtxt = "select identreprise from Entreprise where nomentreprise = @nom"; break;
                case "typeabonne": cmdtxt = "select idtypeabonne from Typeabonne where typeabonne = @nom"; break;
                case "typejournal": cmdtxt = "select idtypejournal from TypeJournal where typejournal = @nom"; break;
                case "numcompteAchat": cmdtxt = "select numcompte from Compte Where numcompte like '601%' and libellecompte like '%" + nom.ToLower() + "'"; break;
                case "numcompteVariation": cmdtxt = "select numcompte from Compte Where numcompte like '603%' and libellecompte like '%" + nom.ToLower() + "'"; break;
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
            nom = "";
            switch (motif)
            {
                case "numcompte_service": cmdtxt = "select numcompte from Service where idservice = @id"; break;
                case "service": cmdtxt = "select nomservice from Service where idservice = @id"; break;
                case "entreprise": cmdtxt = "select nomentreprise from Entreprise where identreprise = @id"; break;
                case "typeabonne": cmdtxt = "select typeabonne from TypeAbonne where idtypeabonne = @id"; break;
                case "compte": cmdtxt = "select libellecompte from Compte where numcompte = @id"; break;
                case "poste": cmdtxt = "select poste from Utilisateur where id= @id"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
            }
            con.Open();
            try
            {                
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                dr.Read();
                nom = dr[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return nom;
        }
        public int NouveauID(string concerne)
        {
            id = 0;
            switch (concerne)
            {
                case "payement": cmdtxt = "select max(idpayement) from Payement"; break;
                case "service": cmdtxt = "select max(idservice) from Service"; break;
                case "recette": cmdtxt = "select max(idrecette) from Recette_"; break;
                case "depense": cmdtxt = "select max(iddepense) from Depense"; break;
                case "payeur": cmdtxt = "select max(idpatient) from Patient"; break;
                case "operation": cmdtxt = "select max(idoperation) from Operation"; break;
                case "operationcompte": cmdtxt = "select max(id) from OperationCompte"; break;
                case "exercice": cmdtxt = "select max(idexercice) from Exercice"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
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

        #region RECETTE
        public void ActualiserDesign(Panel pnlSousMenu)
        {
            pnlSousMenu.Visible = false;
        }
        public void CacherSousMenu(Panel pnlSousMenu)
        {
            if (pnlSousMenu.Visible == true)
                pnlSousMenu.Visible = false;
        }
        public void AfficherSousForm(RecetteMDI r, Form childForm)
        {
            if (r.activeForm != null)
                r.activeForm.Close();
            r.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            r.pnlChildForm.Controls.Add(childForm);
            r.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void AfficherSousForm(RecetteMDI r, FormPayements childForm)
        {
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
            childForm.Show();
        }
        ExerciceClasse exer = new ExerciceClasse();
        public void AfficherSousForm(RecetteMDI r, FormRecette childForm)
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
                childForm.poste = "recette";
                childForm.idutilisateur = r.idutilisateur;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
        }
        public void AfficherSousForm(RecetteMDI r, FormRecetteJournal childForm)
        {
            if (r.activeForm != null)
                r.activeForm.Close();
            r.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            r.pnlChildForm.Controls.Add(childForm);
            r.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.btnImprimer.Enabled = false;
            childForm.idutilisateur = r.idutilisateur;
            childForm.Show();
        }

        public void AfficherSousForm(ReceptionMDI r, Form childForm)
        {
            if (r.activeForm != null)
                r.activeForm.Close();
            r.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            r.pnlChildForm.Controls.Add(childForm);
            r.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        
        public void AfficherSousForm(ReceptionMDI r, FormFactureService childForm)
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
        public void AfficherSousForm(ReceptionMDI r, FormPatientRecherche childForm)
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
                childForm.poste = TrouverNom("poste", r.idutilisateur);
                childForm.dgv.Columns[10].Visible = false;
                childForm.dgv.Columns[11].Visible = false;
                childForm.dgv.Columns[12].Visible = false;
                childForm.infirmier_autorise = r.infirmier_autorise;
                
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
        }
        #endregion

        #region DATE_TAUX
        public void Enregistrer(DateTaux d)
        {
            if (d.txtTaux.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Date_operation values (@date, @taux)", con);
                    cmd.Parameters.AddWithValue("@date",d.dtpTaux.Value.Date);
                    cmd.Parameters.AddWithValue("@taux", d.txtTaux.Text);
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
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int VerifierTaux(DateTime dateTaux, string motif)
        {
            id = 0;
            con.Open();
            try
            {
                if (motif == "valeur")
                    cmd = new SqlCommand("select taux from Date_operation where date_operation = @dateTaux", con);
                else
                    cmd = new SqlCommand("select count(taux) from Date_operation where date_operation = @dateTaux", con);
                cmd.Parameters.AddWithValue("@dateTaux", dateTaux);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    id = int.Parse(dr[0].ToString());
                if (id == 0)
                    MessageBox.Show("Valeur taux non trouvée pour la date : " + dateTaux.ToShortDateString(), "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public int ChangerDate(DateTaux d, Form f, Label lblDate, Label lblTaux)
        {
            id = 0;
            d.ShowDialog();
            if (!d.fermeture_succes)
            {
                f.Close();
            }
            else
            {
                lblDate.Text = d.dtpTaux.Text;
                id = VerifierTaux(d.dtpTaux.Value.Date, "valeur");
                lblTaux.Text = id + " CDF";      
            }
            d.Close();
            return id;
        }
        public int ChangerDate(Form f, DateTaux d)
        {
            id = 0;
            d.ShowDialog();
            if (!d.fermeture_succes)
            {
                f.Close();
            }
            else
            {
                id = VerifierTaux(d.dtpTaux.Value.Date, "valeur");
            }
            d.Close();
            return id;
        }

        #endregion

        #region FACTURATION

        public void AjouterRecette(string statut_facture, string date, string numcompte, string libelle, int qtedem, double prix, string categorie, int idpayeur)
        {
            id = NouveauID("recette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (statut_facture == "différé")
                {
                    cmd = new SqlCommand("insert into Recette_ (idrecette, statut_facture, date_operation, numcompte, libelle, qtedem, prix, categorie, idpatient,  statut_caisse) values (@idrecette, @statut_facture, @date_operation, @numcompte, @libelle, @qtedem, @prix, @categorie, @idpatient, @statut_caisse)", con);
                    cmd.Parameters.AddWithValue("@statut_caisse", "OK");
                }
                else
                    cmd = new SqlCommand("insert into Recette_ (idrecette, statut_facture, date_operation, numcompte, libelle, qtedem, prix, categorie, idpatient) values (@idrecette, @statut_facture, @date_operation, @numcompte, @libelle, @qtedem, @prix, @categorie, @idpatient)", con);
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
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public int AjouterPayeur(string noms, string sexe, string tel)
        {
            if (tel == "") tel = "RAS";
            id = NouveauID("payeur");

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
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public void Enregistrer(FormFactureService f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.txtPayeur.Enabled)
                {
                    
                        //Ajouter le payeur
                        f.idpayeur = AjouterPayeur(f.txtPayeur.Text, f.cboSexe.Text, f.txtTel.Text);

                        //Ajout de services de la recette
                        for (int i = 0; i < f.dgvFacture.RowCount; i++)
                        {
                            AjouterRecette(f.cboTypeFacture.Text, f.lblDate.Text, f.dgvFacture.Rows[i].Cells[6].Value.ToString(), f.dgvFacture.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(f.dgvFacture.Rows[i].Cells[4].Value), Convert.ToDouble(f.dgvFacture.Rows[i].Cells[3].Value), "service", f.idpayeur);
                        }
                }
                else
                {
                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterRecette(f.cboTypeFacture.Text, f.lblDate.Text, f.dgvFacture.Rows[i].Cells[6].Value.ToString(), f.dgvFacture.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(f.dgvFacture.Rows[i].Cells[4].Value), Convert.ToDouble(f.dgvFacture.Rows[i].Cells[3].Value), "service", f.idpayeur);
                    }
                }
                //Cas de facture différé
                if (f.cboTypeFacture.Text == "différé")
                {
                    f.idoperation = AjouterOperation(f.lblDate.Text, "FAC_DIFF", TrouverId("typejournal", "ventes"), f.idexercice);
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        f.numcompte = TrouverNom("numcompte_service", int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()));
                        AjouterEcriture(f.idoperation, f.numcomptediffere, f.numcompte, double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), "Vente - service à crédit");
                    }
                }
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Annuler(f);
                if (f.recettePatientConsulte)
                {
                    f.fermeture_succes = true;
                    f.Hide();
                }
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        
        
        public void Generer()
        {
            string filecontent = "texte à enregistrer";
            var sfd = new SaveFileDialog();
            sfd.FileName = "SSM Dernier Bon Recette";
            sfd.DefaultExt = ".txt";
            sfd.OverwritePrompt = false;
            sfd.Filter = "Fichiers texte|*.txt";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Stream mystream = sfd.OpenFile();
                    if (mystream != null)
                    {
                        using (mystream)
                        {
                            using (StreamWriter writer = new StreamWriter(mystream, UnicodeEncoding.UTF8))
                            {
                                writer.Write(filecontent);
                            }
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        public void ArchiverBon(string motif, int numbon)
        {
            string fileName = "";
            if (motif == "recette")
                fileName = @"C:\Users\Public\Documents\SSM_Dernier_NumBonPayement.txt";
            else
                fileName = @"C:\Users\Public\Documents\SSM_Dernier_NumBonDepense.txt";
            string filecontent = String.Format("==============================================\nSUMEDCO Soft Manager (S.S.M.)\nCarnet des {0}s\n==============================================\nDernier N° de bon utilisé : {1}\nDate et Heure : {2} à {3}\n", motif, numbon, DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());

            try
            {
                if (File.Exists(fileName)) File.Delete(fileName);
                using (FileStream fs = File.Create(fileName))
                {
                    byte[] text = new UTF8Encoding(true).GetBytes(filecontent);
                    fs.Write(text, 0, text.Length);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void TrouverService(FormFacture exa, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if(exa.type_patient.Contains("abonné")) //un abonné paye le double pour les services
                        cmd = new SqlCommand("select idservice, nomservice, prixservice * 2 from Service where numcompte = '" + exa.numcompte + "' and nomservice like '" + exa.txtRecherche.Text + "%' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                    else
                        cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte = '" + exa.numcompte + "' and nomservice like '" + exa.txtRecherche.Text + "%' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                }
                else
                {
                    if (exa.type_patient.Contains("abonné"))
                        cmd = new SqlCommand("select idservice, nomservice, prixservice * 2 from Service where numcompte = '" + exa.numcompte + "' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                    else
                        cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte = '" + exa.numcompte + "' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                }
                
                dr = cmd.ExecuteReader();
                exa.dgv.Rows.Clear();
                while (dr.Read())
                {
                    exa.dgv.Rows.Add();
                    exa.dgv.Rows[exa.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    exa.dgv.Rows[exa.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    exa.dgv.Rows[exa.dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerService(FormFactureService f, FormFacture exa)
        {
            exa.Text = string.Format("SSM - Service à facturer", chaine);
            exa.numcompte = f.dgv1.CurrentRow.Cells[0].Value.ToString();
            exa.type_patient = f.type_patient;
            
            TrouverService(exa, "");
            exa.ShowDialog();
            if (exa.fermeture_succes)
            {
                for (int i = 0; i < exa.dgv.RowCount; i++)
                {
                    f.ajoutvalide = true;
                    if (exa.dgv.Rows[i].Selected)
                    {
                        for (int j = 0; j < f.dgvFacture.RowCount; j++)
                        {
                            if(exa.dgv.Rows[i].Cells[0].Value.ToString() == f.dgvFacture.Rows[j].Cells[0].Value.ToString())
                            {
                                f.ajoutvalide = false;
                                MessageBox.Show("Le service sur la ligne "+(i+1)+" existe déjà sur la facture", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                j += f.dgvFacture.RowCount;
                            }
                        }
                        if(f.ajoutvalide)
                        {
                            f.dgvFacture.Rows.Add();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = exa.dgv.Rows[i].Cells[0].Value.ToString();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f.dgvFacture.RowCount;
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = exa.dgv.Rows[i].Cells[1].Value.ToString();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = exa.dgv.Rows[i].Cells[2].Value.ToString();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = 1;
							f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = exa.dgv.Rows[i].Cells[2].Value.ToString();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[6].Value = exa.numcompte;
                        }
                    }

                }
            }
            exa.Close();           
            //Calcul de total
            CalculerTotal(f.dgvFacture, f.txtTotal);
        }
        public void ChargerCategorie(FormFactureService f, string motif)
        {
            con.Open();
            if(motif == "recherche")
                cmd = new SqlCommand("select numcompte, libellecompte from Compte Where libellecompte like '" + f.txtRecherche.Text + "%' and numcompte like '7061%' or libellecompte like '" + f.txtRecherche.Text + "%' and numcompte like '70780%' order by libellecompte", con);
            else
                cmd = new SqlCommand("select numcompte, libellecompte from Compte Where numcompte like '7061%' or numcompte like '70780%' order by libellecompte", con);
            try
            {
                dr = cmd.ExecuteReader();
                f.dgv1.Rows.Clear();
                while (dr.Read())
                {
                    f.dgv1.Rows.Add();
                    f.dgv1.Rows[f.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    f.dgv1.Rows[f.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerCombo(string motif, ComboBox combo, int id)
        {
            if(motif=="catservice")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte like '7061%' or numcompte like '70780%'", con);
            }
            else if (motif == "specificationservice")
            {
                cmd = new SqlCommand("SELECT DISTINCT specification FROM Service WHERE specification IS NOT NULL", con);
            }
            else if(motif=="service")
            {
                cmd = new SqlCommand("select nomservice from Service where numcompte = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }
            else if(motif =="entreprise")
            {
                cmd = new SqlCommand("select nomentreprise from Entreprise", con);
            }
            else if(motif =="typeabonne")
            {
                cmd = new SqlCommand("select typeabonne from TypeAbonne, EntrepriseTypeAbonne, Entreprise where TypeAbonne.idtypeabonne = EntrepriseTypeAbonne.idtypeabonne and EntrepriseTypeAbonne.identreprise= Entreprise.identreprise and  Entreprise.identreprise= @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }
            else if(motif == "depense")
            {
                cmd = new SqlCommand("select libellecompte from Compte where numcompte not like '1%' or numcompte not like '7%' ", con);
            }
            else if(motif == "typejournal")
            {
                cmd = new SqlCommand("select typejournal from TypeJournal", con);
            }
            else if (motif == "payeurdifféré")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte = '411100'", con);
            }
            else if (motif == "stock")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte like '33%' and numcompte <> '33' and numcompte <> '33000'", con);
            }
            else if (motif == "categorie")
            {
                cmd = new SqlCommand("select categorie from CategorieProduit", con);
            }
            else if (motif == "poste")
            {
                cmd = new SqlCommand("select nomposte from ServiceDemandeur", con);
            }
            else if (motif == "pharma")
            {
                cmd = new SqlCommand("select designation from Pharmacie", con);
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
            catch (Exception ex) { 
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();               
        }
        
        public void ChargerRubriqueExamen(FormConsulter c)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT s.numcompte, specification
                FROM Service s
                JOIN Compte c ON s.numcompte = c.numcompte
                Where s.numcompte like '70611%' AND specification is NOT NULL
                GROUP BY s.numcompte, specification
                ORDER BY specification";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                c.dgvLabo.Rows.Clear();
                while (dr.Read())
                {
                    c.dgv1.Rows.Add();
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString().ToUpper();
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void CalculerTotal(DataGridView dgv, TextBox txt)
        {
            if(dgv.RowCount != 0)
            {
                txt.Text = "0";
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    dgv.Rows[i].Cells[1].Value = i + 1;
                    if (Convert.ToDouble(dgv.Rows[i].Cells[5].Value) > 0)
                    {
                        txt.Text = (Convert.ToDouble(txt.Text) + Convert.ToDouble(dgv.Rows[i].Cells[5].Value)).ToString("0.00");
                    }

                }
            }
        }
        public void ChargerExamens(FormConsulter c, FormFacture e)
        {
            chaine = c.dgv1.CurrentRow.Cells[1].Value.ToString();
            e.txtRecherche.Enabled = false;
            e.btnRecherche.Enabled = false;
            c.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();

            con.Open();
            try
            {
                if (c.type_patient.Contains("abonné"))
                    cmd = new SqlCommand("select idservice, nomservice, prixservice * 2 from Service where numcompte = '" + c.dgv1.CurrentRow.Cells[0].Value.ToString() + "' and specification = '" + chaine + "'", con);
                else
                    cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte = '" + c.dgv1.CurrentRow.Cells[0].Value.ToString() + "' and specification = '" + chaine + "'", con);
                
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    e.dgv.Rows.Add();
                    e.dgv.Rows[e.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    e.dgv.Rows[e.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    e.dgv.Rows[e.dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            e.Text = string.Format("SSM - Examens ({0})", chaine);
            e.ShowDialog();
            if (e.fermeture_succes)
            {
                //id = c.dgvLabo.CurrentRow.Index;
                c.dgvLabo.Rows.Add();
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = "";
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = chaine;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].ReadOnly = true;
                
                for (int i = 0; i < e.dgv.RowCount; i++)
                {
                    if (e.dgv.Rows[i].Selected)
                    {
                        c.dgvLabo.Rows.Add();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = e.dgv.Rows[i].Cells[0].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = e.dgv.Rows[i].Cells[1].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[3].Value = e.dgv.Rows[i].Cells[2].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[4].Value = 1;
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[5].Value = e.dgv.Rows[i].Cells[2].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[6].Value = c.dgv1.CurrentRow.Cells[0].Value.ToString();
                    }

                }
            }
            e.Close();
            //Calcul de total
            CalculerTotal(c.dgvLabo, c.txtTotal);
        }
        public void AutresExamens(FormConsulter c, FormFacture ex)
        {
            ex.btnPlusExamPhys.Enabled = true;
            ex.dgv.ReadOnly = false;
            ex.dgv.Columns[0].ReadOnly = true;
            ex.dgv.Columns[2].ReadOnly = true;
            ex.txtRecherche.Enabled = false;
            ex.btnRecherche.Enabled = false;
            ex.dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            ex.Text = "SSM - Autres Examens";
            ex.ShowDialog();
            if (ex.fermeture_succes)
            {
                c.dgvLabo.Rows.Add();
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = "";
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[1].Value = "AUTRES";
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = "";
                c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].ReadOnly = false;
                for (int i = 0; i < ex.dgv.RowCount; i++)
                {
                    if (ex.dgv.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        c.dgvLabo.Rows.Add();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = ex.dgv.Rows[i].Cells[0].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = ex.dgv.Rows[i].Cells[1].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[3].Value = 0;
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[4].Value = 1;
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[5].Value = 0;
                    }

                }
            }
            ex.Close();
        }
        
        public double PrixService(int idservice)
        {
            valeur = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select prixservice from Service where idservice = @id", con);
                cmd.Parameters.AddWithValue("@id", idservice);
                dr = cmd.ExecuteReader();
                dr.Read();
                valeur = double.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return valeur;
        }
        public void ChargerProduit(FormFactureProduit f, string motif)
        {
            con.Open();
            if (motif == "recherche")
                cmd = new SqlCommand("select idproduit, nomproduit from Produit, CategorieProduit where Produit.idcat = CategorieProduit.idcat and categorie= 'Pharmaceutique' and nomproduit like '" + f.txtRecherche.Text + "%' order by nomproduit", con);
            else
                cmd = new SqlCommand("select idproduit, nomproduit from Produit, CategorieProduit where Produit.idcat = CategorieProduit.idcat and categorie= 'Pharmaceutique' order by nomproduit", con);
            try
            {
                dr = cmd.ExecuteReader();
                f.dgv1.Rows.Clear();
                while (dr.Read())
                {
                    f.dgv1.Rows.Add();
                    f.dgv1.Rows[f.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    f.dgv1.Rows[f.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        
        public void ChargerStockProduit(FormFactureProduit f, FormFactureProduit2 fp)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idstock, forme, dosage, prixunitaire, qtestock FROM LigneStock WHERE idproduit = @id", con);
                cmd.Parameters.AddWithValue("@id", f.dgv1.CurrentRow.Cells[0].Value.ToString());
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    fp.dgvStock.Rows.Add();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[5].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (fp.dgvStock.RowCount != 0)
            {
                //Ajout stock principal
                for (int i = 0; i < fp.dgvStock.RowCount; i++)
                {
                    fp.dgvStock.Rows[i].Cells[4].Value = cs.QteStock(Convert.ToInt32(fp.dgvStock.Rows[i].Cells[0].Value), 0, "stock");
                }
                //Ajout stock pharma
                for (int i = 0; i < fp.dgvStock.RowCount; i++)
                {
                    fp.dgvStock.Rows[i].Cells[4].Value = Convert.ToInt32(fp.dgvStock.Rows[i].Cells[4].Value) + cs.StockGlobalPharma(Convert.ToInt32(fp.dgvStock.Rows[i].Cells[0].Value));
                }
            }          

            fp.Text = "SSM - Produits à facturer";
            fp.ShowDialog();
            if (fp.fermeture_succes)
            {
                for (int i = fp.dgvStock.RowCount-1; i >= 0; i--)
                {
                    f.ajoutvalide = true;
                    try
                    {
                        if (fp.dgvStock.Rows[i].Cells[5].Value.ToString() != "" &&
                            Convert.ToInt32(fp.dgvStock.Rows[i].Cells[5].Value) > 0 &&
                            Convert.ToInt32(fp.dgvStock.Rows[i].Cells[4].Value) >
                            Convert.ToInt32(fp.dgvStock.Rows[i].Cells[5].Value))
                        {
                            for (int j = 0; j < f.dgvFacture.RowCount; j++)
                            {
                                if (fp.dgvStock.Rows[i].Cells[0].Value.ToString() == f.dgvFacture.Rows[j].Cells[0].Value.ToString())
                                {
                                    f.ajoutvalide = false;
                                    MessageBox.Show("La ligne " + (i + 1) + " existe déjà sur la facture", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    j += f.dgvFacture.RowCount;
                                }
                            }
                            if (f.ajoutvalide)
                            {
                                f.dgvFacture.Rows.Add();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = fp.dgvStock.Rows[i].Cells[0].Value.ToString();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f.dgvFacture.RowCount;
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = string.Format("{0}, {1}, {2}", f.dgv1.CurrentRow.Cells[1].Value.ToString(), fp.dgvStock.Rows[i].Cells[1].Value.ToString(), fp.dgvStock.Rows[i].Cells[2].Value.ToString());
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = fp.dgvStock.Rows[i].Cells[3].Value.ToString();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = fp.dgvStock.Rows[i].Cells[5].Value.ToString();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = (Convert.ToDouble(fp.dgvStock.Rows[i].Cells[3].Value) * Convert.ToInt32(fp.dgvStock.Rows[i].Cells[5].Value)).ToString("0.00");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La quantité doit être un entier supérieur à 0 et inférieur au stock disponible\n"+ex.Message, "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            fp.Close();
            //Calcul de total
            CalculerTotal(f.dgvFacture, f.txtTotal);
        }
        public void Annuler(FormFactureService f)
        {
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboTypeFacture.SelectedText = "";
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtPayeur.Text = "";
            f.txtTel.Text = "";
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Clear();
            f.btnRetirer.Enabled = false;
            f.btnRetirerTout.Enabled = false;
        }
        public void Annuler(FormFactureProduit f)
        {
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboTypeFacture.SelectedText = "";
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtPayeur.Text = "";
            f.txtTel.Text = "";
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Clear();
            f.btnRetirer.Enabled = false;
            f.btnRetirerTout.Enabled = false;
        }        
        
        public void Enregistrer(FormFactureProduit f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.txtPayeur.Enabled)
                {
                    //Ajouter le payeur

                    f.idpayeur = AjouterPayeur(f.txtPayeur.Text, f.cboSexe.Text, f.txtTel.Text);

                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterRecette(f.cboTypeFacture.Text, f.lblDate.Text, "701100", f.dgvFacture.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(f.dgvFacture.Rows[i].Cells[4].Value), Convert.ToDouble(f.dgvFacture.Rows[i].Cells[3].Value), "produit", f.idpayeur);
                    }
                }
                else
                {
                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterRecette(f.cboTypeFacture.Text, f.lblDate.Text, "701100", f.dgvFacture.Rows[i].Cells[2].Value.ToString(), Convert.ToInt32(f.dgvFacture.Rows[i].Cells[4].Value), Convert.ToDouble(f.dgvFacture.Rows[i].Cells[3].Value), "produit", f.idpayeur);
                    }
                }
                //Cas de facture différé
                if (f.cboTypeFacture.Text == "différé")
                {
                    f.idoperation = AjouterOperation(f.lblDate.Text, "FAC_DIFF", TrouverId("typejournal", "ventes"), f.idexercice);
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterEcriture(f.idoperation, f.numcomptediffere, "701100", double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), "Vente - produit à crédit");
                    }
                }
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);                              
            }
            else
            { MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public void AfficherRapportRecette(FormReceptionRapport r)
        {
            con.Open();
            try
            {
                if (r.cboStatut.Text == "" && r.cboCategorie.Text == "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.categorie, r.qtedem, r.prix, p.noms, r.libelle, r.statut_facture, libellecompte, statut_caisse, servi 
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient
                    JOIN Compte c ON r.numcompte = c.numcompte    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else if (r.cboStatut.Text != "" && r.cboCategorie.Text == "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.categorie, r.qtedem, r.prix, p.noms, r.libelle, r.statut_facture, libellecompte, statut_caisse, servi 
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient
                    JOIN Compte c ON r.numcompte = c.numcompte    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND r.statut_facture = @statut";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@statut", r.cboStatut.Text);

                }
                else if (r.cboStatut.Text == "" && r.cboCategorie.Text != "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.categorie, r.qtedem, r.prix, p.noms, r.libelle, r.statut_facture, libellecompte, statut_caisse, servi 
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient
                    JOIN Compte c ON r.numcompte = c.numcompte    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND r.categorie = @categ";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@categ", r.cboCategorie.Text);
                }
                else if (r.cboStatut.Text != "" && r.cboCategorie.Text != "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.categorie, r.qtedem, r.prix, p.noms, r.libelle, r.statut_facture, libellecompte, statut_caisse, servi 
                    FROM Recette_ r
                    JOIN Patient p ON p.idpatient = r.idpatient
                    JOIN Compte c ON r.numcompte = c.numcompte    
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND r.statut_facture = @statut AND r.categorie = @categ";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@statut", r.cboStatut.Text);
                    cmd.Parameters.AddWithValue("@categ", r.cboCategorie.Text);
                }
                cmd.Parameters.AddWithValue("@dateDe", r.dtpDe.Text);
                cmd.Parameters.AddWithValue("@dateA", r.dtpA.Text);

                dr = cmd.ExecuteReader();
                r.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRecette.Rows.Add();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value = Convert.ToInt32(dr[3].ToString()) * Convert.ToDouble(dr[4].ToString());
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[7].Value = dr[6].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[8].Value = dr[7].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[9].Value = dr[8].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[10].Value = dr[9].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[11].Value = dr[10].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if(r.dgvRecette.RowCount != 0)
            {
                r.dgvRecette.Rows.Add();
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = "Totaux";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[3].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[4].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value = 0;
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[6].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[7].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[8].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[9].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[10].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[11].Value = "";
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;

                for (int i = 0; i < r.dgvRecette.RowCount-1; i++)
                {
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value = Convert.ToDouble(r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value) + Convert.ToDouble(r.dgvRecette.Rows[i].Cells[5].Value);
                }
            }
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
        public void SupprimerRecette(FormReceptionRapport r)
        {
            if (RecetteNonServi(Convert.ToInt32(r.dgvRecette.CurrentRow.Cells[0].Value)) >= 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("DELETE FROM Recette_ where idrecette = @id", con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(r.dgvRecette.CurrentRow.Cells[0].Value));

                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    r.btnSupprimer.Enabled = false;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                r.dgvRecette.Rows.RemoveAt(r.dgvRecette.CurrentRow.Index);
            }
            else
                MessageBox.Show("Cette recette est déjà payée,\npour raison de cohérence, elle ne peut être supprimée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region CAISSE_RECETTE
        public string CompteService(int idservice)
        {
            chaine = "";
            con.Open();
            try
            {
                cmd = new SqlCommand("select numcompte from Service where idservice = @id", con);
                cmd.Parameters.AddWithValue("@id", idservice);
                dr = cmd.ExecuteReader();
                dr.Read();
                chaine = dr[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return chaine;
        }
        public void AfficherRecette(FormRecette b, string motif)
        {
            con.Open();
            try
            {
                if(motif == "recherche")
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
        public void AjouterPayement(string date_jour, double montant, string monnaie, string numcompte, string libelle)
        {
            id = NouveauID("payement");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("INSERT INTO Payement(idpayement, date_operation, montant, monnaie, numcompte, libelle) VALUES (@idpayement, @date_operation, @montant, @monnaie, @numcompte, @libelle)", con);
                cmd.Parameters.AddWithValue("@idpayement", id);
                cmd.Parameters.AddWithValue("@date_operation", date_jour);
                cmd.Parameters.AddWithValue("@montant", montant);
                cmd.Parameters.AddWithValue("@monnaie", monnaie);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@libelle", libelle);

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
        public void StatutCaisseOK(int idrecette, string motif)
        {
            con.Open();
            try
            {
                if (motif == "OK")
                    cmd = new SqlCommand("UPDATE Recette_ SET statut_caisse = 'OK' WHERE idrecette = "+idrecette+"", con);
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
                if(statut == "OK")
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
        public void ValiderPayement(FormRecette b)
        {
            if (b.dgvRecette.RowCount != 0)
            {
                //Ajouter payement
                for (int i = b.dgvRecette.RowCount-1; i >= 0; i--)
                {
                    if(b.dgvRecette.Rows[i].Selected)
                    {
                        AjouterPayement(
                            b.lblDateJour.Text, 
                            Convert.ToDouble(b.dgvRecette.Rows[i].Cells[2].Value), 
                            b.cboMonnaie.Text, 
                            b.dgvRecette.Rows[i].Cells[7].Value.ToString(), 
                            string.Format("{0} par {1}", b.dgvRecette.Rows[i].Cells[3].Value.ToString(), b.dgvPatient.CurrentRow.Cells[1].Value.ToString())
                            );
                        
                        //MAJ statut caisse de la recette
                        StatutCaisseOK(Convert.ToInt32(b.dgvRecette.Rows[i].Cells[0].Value), "OK");
                        
                        //Ecriture comptable
                        if (b.dgvRecette.Rows[i].Cells[8].Value.ToString()=="immédiat")
                        {
                            b.idoperation = AjouterOperation(b.lblDateJour.Text, "FAC_IMM", TrouverId("typejournal", b.caisse), b.idexercice);
                            valeur = Convert.ToDouble(b.dgvRecette.Rows[i].Cells[2].Value);
                            
                            if (b.numcompte == "571201") //perçu en USD
                                AjouterEcriture(b.idoperation, b.numcompte, b.dgvRecette.Rows[i].Cells[7].Value.ToString(), (valeur / b.taux), valeur, string.Format("Vente - {0}", b.dgvRecette.Rows[i].Cells[4].Value.ToString()));
                            else
                                AjouterEcriture(b.idoperation, b.numcompte, b.dgvRecette.Rows[i].Cells[7].Value.ToString(), valeur, valeur, string.Format("Vente - {0}", b.dgvRecette.Rows[i].Cells[4].Value.ToString()));
                        }
                        //retrait de la ligne
                        b.dgvRecette.Rows.RemoveAt(b.dgvRecette.Rows[i].Index);
                    }                   
                }
                b.btnValider.Enabled = false;
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            SoldesCaisse(b.lblCaisseCDF, b.lblCaisseUSD, "recette");
        }
        private void PayementAbonne(FormTresoEntree t)
        {
            AjouterPayement(
                t.lblDateJour.Text,
                Convert.ToDouble(t.txtMontant.Text),
                t.cboMonnaie.Text,
                t.dgvBon.CurrentRow.Cells[0].Value.ToString(),
                string.Format("Payement abonnés par {0}", t.dgvBon.CurrentRow.Cells[1].Value.ToString())
                            );

            t.idoperation = AjouterOperation(t.lblDateJour.Text, "FAC_DIFF", TrouverId("typejournal", "ventes"), t.idexercice);
            valeur = double.Parse(t.txtMontant.Text);
            if (t.cboMonnaie.Text == "USD") //perçu en USD
                AjouterEcriture(t.idoperation, t.numcompte, t.dgvBon.CurrentRow.Cells[0].Value.ToString(), valeur, (valeur * t.taux), string.Format("Payement abonnés par {0}", t.dgvBon.CurrentRow.Cells[1].Value.ToString()));
            else
                AjouterEcriture(t.idoperation, t.numcompte, t.dgvBon.CurrentRow.Cells[0].Value.ToString(), valeur, valeur, string.Format("Payement abonnés par {0}", t.dgvBon.CurrentRow.Cells[1].Value.ToString()));

            SoldesCaisse(t.lblCaisseCDF, t.lblCaisseUSD, "dépense");
        }

        public void PayerRecette(FormPayement p)
        {
            p.txtMontant.Text = "0";
            for (int i = p.dgvCompte.RowCount-1; i >=0 ; i--)
            {
                if (Convert.ToDouble(p.dgvCompte.Rows[i].Cells[2].Value) == 0)
                    p.dgvCompte.Rows.RemoveAt(i);
                else
                    p.txtMontant.Text = (Convert.ToDouble(p.txtMontant.Text) + Convert.ToDouble(p.dgvCompte.Rows[i].Cells[2].Value)).ToString("0.00");
            }
            if(p.dgvCompte.RowCount != 0)
            {
                if (p.txtMontant.Text != "" && p.cboMonnaie.Text != "")
                {
                    //Montant en lettres
                    p.montantLettre = TestMontant(p.txtMontant);
                    if (p.montantLettre != "")
                    {
                        if (p.cboMonnaie.Text == "CDF")
                            p.txtMontantLettre.Text = p.montantLettre.Substring(0, 1).ToUpper() + p.montantLettre.Substring(1) + " francs congolais";
                        else
                            p.txtMontantLettre.Text = p.montantLettre.Substring(0, 1).ToUpper() + p.montantLettre.Substring(1) + " dollars américains";
                    }

                    if (p.montant_recette >= double.Parse(p.txtMontant.Text))
                    {
                        //AjouterPayement(p);
                    }
                    else
                        MessageBox.Show("Le montant perçu doit être inférieur ou égal aux " + p.montant_recette + " à payer", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Champs obligatoires vides(s)\nRemplissez-les", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Le montant ne peut être 0", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void TrouverRecettePatient(FormRecette b)
        {
            cmd = new SqlCommand("SELECT idrecette, date_operation, prix * qtedem, libelle, categorie, statut_caisse, servi, numcompte,statut_facture  FROM Recette_ WHERE idpatient = @idpatient", con);
            cmd.Parameters.AddWithValue("@idpatient", Convert.ToInt32(b.dgvPatient.CurrentRow.Cells[0].Value));
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
            if(b.dgvRecette.RowCount!= 0)
            {
                //Ligne total
                b.dgvRecette.Rows.Add();
                b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                
                b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[1].Value = "Total";
                b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value = 0;
                for (int i = 0; i < b.dgvRecette.RowCount-1; i++)
                {
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value = Convert.ToDouble(b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value) + Convert.ToDouble(b.dgvRecette.Rows[i].Cells[2].Value);
                }
            }
            b.btnValider.Enabled = false;
            b.btnAnnulerPayement.Enabled = false;
        }
        private void CalculerTotauxPayement(FormRecette b)
        {
            //cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE idrecette = '" + b.idrecette + "' AND raison_retrait is NULL GROUP BY monnaie", con);
            //con.Open();
            //try
            //{
            //    dr = cmd.ExecuteReader();
            //    b.dgvTotaux.Rows.Clear();
            //    while (dr.Read())
            //    {
            //        b.dgvTotaux.Rows.Add();
            //        b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[0].Value = dr[0].ToString();
            //        b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = dr[1].ToString();
            //    }
            //    b.dgvTotaux.Rows.Add();
            //    b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[0].Value = "T.CDF";
            //    if(b.dgvTotaux.RowCount == 2)
            //    {
            //        b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 2].Cells[1].Value;
            //    }
            //    else
            //        b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = double.Parse(b.dgvTotaux.Rows[0].Cells[1].Value.ToString()) + double.Parse(b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 2].Cells[1].Value.ToString()) * b.taux;
            //    b.total_payement = 0;
            //    if (b.dgvPaye.RowCount != 0)
            //        b.total_payement = double.Parse(b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value.ToString());
            //}
            //catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //con.Close();
        }
        public void AnnulerPayement(FormPayements p)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("UPDATE Payement SET raison_retrait = @raison WHERE idpayement = " + p.dgvPayement.CurrentRow.Cells[0].Value + "", con);
                cmd.Parameters.AddWithValue("@raison", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), p.cboAnnulation.Text));
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Opération effectuée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //composer le message
            chaine = string.Format("Annulation du payement {0} pour {1}\nDate:{2}\nMontant:{3} {4}\nCompte:{5}",
                p.dgvPayement.CurrentRow.Cells[0].Value.ToString(),
                p.cboAnnulation.Text,
                p.dgvPayement.CurrentRow.Cells[1].Value.ToString(),
                p.dgvPayement.CurrentRow.Cells[2].Value.ToString(),
                p.dgvPayement.CurrentRow.Cells[3].Value.ToString(),
                p.dgvPayement.CurrentRow.Cells[4].Value.ToString());
            //Signaler au comptable
            MessageAuComptable(p.idutilisateur, chaine, "payement");
        }
        private void MessageAuComptable(int idutilisateur, string message, string type_operation)
        {
            valeur = cs.TrouverId("utilisateur", "comptable");
            id = NouveauID("message");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("INSERT INTO Message VALUES (@id, @exp, @dest, @objet, @msg, @date_jour, @heure, @statut)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@exp", idutilisateur);
                cmd.Parameters.AddWithValue("@dest", valeur);
                cmd.Parameters.AddWithValue("@objet", "Annulation " + type_operation);
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@heure", DateTime.Now.ToShortTimeString());
                cmd.Parameters.AddWithValue("@statut", "Non lu");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void AnnulerPayement(FormRecette b, FormPayements p)
        {
            p.dtpDateDe.Text = b.dgvRecette.CurrentRow.Cells[1].Value.ToString();
            p.dtpDateA.Text = b.dgvRecette.CurrentRow.Cells[1].Value.ToString();
            AfficherPayement(p);
            p.dgvPayement.Columns[4].Visible = false;
            p.btnQuitter.Enabled = false;
            p.StartPosition = FormStartPosition.CenterParent;
            p.annuler_recette = true;
            p.ShowDialog();
            if(p.fermeture_succes)
            {
                StatutCaisseOK(Convert.ToInt32(b.dgvRecette.CurrentRow.Cells[0].Value), "");
            }

        }

        public void ImprimerBon(FormPayement p)
        {
            //A revoir
            FormImpression imp = new FormImpression();
            imp.numbon = p.idrecette;
            imp.payeur = p.txtPayeur.Text;
            imp.montantchiffre = p.txtMontant.Text;
            imp.montantlettre = p.txtMontantLettre.Text;
            imp.monnaie = p.cboMonnaie.Text;
            imp.motif = p.categorie_recette;
            
            imp.date_jour = p.lblDateOperation.Text;
            imp.Text = "SSM - Reçu de payement";
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("numbon", imp.numbon.ToString()),
                new ReportParameter("payeur", imp.payeur),
                new ReportParameter("montantlettre", imp.montantlettre),
                new ReportParameter("montantchiffre", imp.montantchiffre),
                new ReportParameter("monnaie", imp.monnaie),
                new ReportParameter("motif", imp.motif),
                new ReportParameter("date_jour", imp.date_jour)
            };

            List<DetailBonrecette> list = new List<DetailBonrecette>();
            list.Clear();

            for (int i = 0; i < p.dgvCompte.RowCount; i++)
            {
                DetailBonrecette actif = new DetailBonrecette
                {
                    id = (i+1).ToString(),
                    libelle = p.dgvCompte.Rows[i].Cells[1].Value.ToString(),
                    montant = p.dgvCompte.Rows[i].Cells[2].Value.ToString()
                };
                list.Add(actif);
            }

            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonRecette.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.MaximumSize = imp.Size;
            imp.MaximizeBox = false;
            imp.MinimizeBox = false;
            
            ArchiverBon("recette", p.idpayement);
            imp.ShowDialog();
            imp.Close();
        }
        
        public void TotauxProduitService(FormRecetteJournal b)
        {
            b.dgvProduitService.Rows.Clear();
            b.dgvProduitService.Rows.Add(3);
            b.dgvProduitService.Rows[0].Cells[0].Value = "Médicaments";
            b.dgvProduitService.Rows[0].Cells[1].Value = TotalRecetteCompte("701100", "CDF", b);
            b.dgvProduitService.Rows[0].Cells[2].Value = TotalRecetteCompte("701100", "USD", b);

            b.dgvProduitService.Rows[1].Cells[0].Value = "Services";
            b.dgvProduitService.Rows[1].Cells[1].Value = TotalRecetteCompte("service", "CDF", b);
            b.dgvProduitService.Rows[1].Cells[2].Value = TotalRecetteCompte("service", "USD", b);

            b.dgvProduitService.Rows[2].Cells[0].Value = "Totaux";
            b.dgvProduitService.Rows[2].Cells[1].Value = Convert.ToDouble(b.dgvProduitService.Rows[0].Cells[1].Value) + Convert.ToDouble(b.dgvProduitService.Rows[1].Cells[1].Value);
            b.dgvProduitService.Rows[2].Cells[2].Value = Convert.ToDouble(b.dgvProduitService.Rows[0].Cells[2].Value) + Convert.ToDouble(b.dgvProduitService.Rows[1].Cells[2].Value);
        }
        private double TotalRecetteCompte(string numcompte, string monnaie, FormRecetteJournal b)
        {

            valeur = 0;
            con.Open();
            try
            {
                if(numcompte != "service")
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) FROM Payement 
                    WHERE raison_retrait is NULL AND numcompte = @numcompte 
                    AND  monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                else
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) FROM Payement 
                    WHERE raison_retrait is NULL AND numcompte LIKE '7061%' 
                    AND  monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@monnaie", monnaie);
                cmd.Parameters.AddWithValue("@dateDe", b.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", b.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() != "0")
                    valeur = double.Parse(dr[1].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return valeur;
        }
        public void AfficherRapport(FormRecetteJournal b, FormRecetteRapport r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '701100%' OR numcompte LIKE '7061%' OR numcompte LIKE '70780%'", con);
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

            DateTime t;
            TimeSpan s = b.dtpDateA.Value.Date - b.dtpDateDe.Value.Date;
            t = b.dtpDateDe.Value.Date;
            if (s.TotalDays > 0 && b.dtpDateA.Value.Month == b.dtpDateDe.Value.Month)
            {
                for (int i = 0; i < s.TotalDays + 1; i++)
                {
                    r.dgvRecette.Columns.Add("column_" + (i), t.AddDays(i).Day.ToString());
                    r.dgvRecette.Columns[r.dgvRecette.ColumnCount - 1].Width = 30;
                    r.dgvRecette.Columns[r.dgvRecette.ColumnCount - 1].MinimumWidth = 30;
                }               
                r.ShowDialog();
                r.Close();
            }
            else
                MessageBox.Show("La première date doit être inférieure à la deuxième", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            b.checkBox1.Checked = false;
        }
        public void RubriquesRecettes(FormRecetteJournal b)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '701100%' OR numcompte LIKE '7061%' OR numcompte LIKE '70780%'", con);
                dr = cmd.ExecuteReader();
                b.dgvRecette.Rows.Clear();
                while(dr.Read())
                {
                    b.dgvRecette.Rows.Add();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value = "0";
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[3].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            
            TotauxProduitService(b);
        }
        public void TotalPayementCategorie(FormRecetteJournal b)
        {
            for (int i = 0; i < b.dgvRecette.RowCount; i++)
            {
                if (b.dgvRecette.Rows[i].Cells[0].Value.ToString() == "701100")
                {
                    b.dgvRecette.Rows[i].Cells[2].Value = TotalRecetteCompte("701100", "CDF", b);
                    b.dgvRecette.Rows[i].Cells[3].Value = TotalRecetteCompte("701100", "USD", b);
                }
                else
                {
                    b.dgvRecette.Rows[i].Cells[2].Value = TotalRecetteCompte(b.dgvRecette.Rows[i].Cells[0].Value.ToString(), "CDF", b);
                    b.dgvRecette.Rows[i].Cells[3].Value = TotalRecetteCompte(b.dgvRecette.Rows[i].Cells[0].Value.ToString(), "USD", b);
                }
            }
        }

        public void AfficherPayement(FormPayements r)
        {
            if (r.cboMonnaie.Text != "")
            {
                if (r.cboCatPaye.Text == "")
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else if (r.cboCatPaye.Text == "Annulé")
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE raison_retrait IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@monnaie", r.cboMonnaie.Text);
            }
            else
            {
                if (r.cboCatPaye.Text == "")
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else if (r.cboCatPaye.Text == "Annulé")
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE raison_retrait IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else
                {
                    cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, libellecompte, libelle, raison_retrait 
                    FROM Payement p
                    JOIN Compte c ON p.numcompte = c.numcompte
                    WHERE raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                }
            }
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                r.dgvPayement.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvPayement.Rows.Add();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0,10);
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if(r.dgvPayement.RowCount != 0)
            {
                //Ajouter les colonnes totaux
                if (r.cboMonnaie.Text != "")
                {
                    if (r.cboCatPaye.Text == "")
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                    else if (r.cboCatPaye.Text == "Annulé")
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE raison_retrait IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                    else
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                    cmd.Parameters.AddWithValue("@monnaie", r.cboMonnaie.Text);
                }
                else
                {
                    if (r.cboCatPaye.Text == "") 
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
                    else if (r.cboCatPaye.Text == "Annulé")
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE raison_retrait IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
                    else
                        cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE raison_retrait IS NULL AND date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
                }
                cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
                cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
                con.Open();
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        r.dgvPayement.Rows.Add();
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[0].Value = "";
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[1].Value = "Total " + dr[0].ToString();
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[2].Value = dr[1].ToString();
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[3].Value = "";
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[4].Value = "";
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[5].Value = "";
                        r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[6].Value = "";
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        public void ImprimerRapportRecette(FormRecetteJournal b, FormImpression imp)
        {
            imp.Text = string.Format("{0} {1}_{2}_{3}", "SSM - Rapport recette", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

            List<Rapport_recette> list = new List<Rapport_recette>();
            list.Clear();

            for (int i = 0; i < b.dgvRecette.RowCount; i++)
            {
                Rapport_recette r = new Rapport_recette
                {
                    id = (i+1).ToString(),
                    categorie = b.dgvRecette.Rows[i].Cells[1].Value.ToString(),
                    montantCDF = b.dgvRecette.Rows[i].Cells[2].Value.ToString(),
                    montantUSD = b.dgvRecette.Rows[i].Cells[3].Value.ToString()
                };
                list.Add(r);
            }
            Rapport_recette r2 = new Rapport_recette
            {
                id = "",
                categorie = "Totaux",
                montantCDF = b.dgvProduitService.Rows[2].Cells[1].Value.ToString(),
                montantUSD = b.dgvProduitService.Rows[2].Cells[2].Value.ToString()
            };
            list.Add(r2);

            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.RapportRecette.rdlc";
            imp.ShowDialog();
            imp.Close();
        }
        #endregion

        #region PHARMACIE
        public void TrouverPatientRecetteProduit(FormPhamaVente p, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (p.txtNom.Text != "")
                        cmd = new SqlCommand("SELECT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE categorie = 'produit' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + p.dtpDateDe.Text + "' AND '" + p.dtpDateA.Text + "' AND noms LIKE '"+p.txtNom.Text.Replace("'", "")+"%'", con);
                    else
                        cmd = new SqlCommand("SELECT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE categorie = 'produit' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + p.dtpDateDe.Text + "' AND '" + p.dtpDateA.Text + "'", con);
                }
                else
                    cmd = new SqlCommand("SELECT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE categorie = 'produit' AND statut_caisse = 'OK' AND date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                dr = cmd.ExecuteReader();
                p.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvPatient.Rows.Add();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void RecetteProduit(FormPhamaVente p)
        {
            cmd = new SqlCommand("SELECT idrecette, date_operation, libelle, qtedem, statut_caisse, servi  FROM Recette_ WHERE idpatient = @idpatient AND categorie = 'produit' AND date_operation BETWEEN @dateDe AND @dateA", con);
            cmd.Parameters.AddWithValue("@idpatient", Convert.ToInt32(p.dgvPatient.CurrentRow.Cells[0].Value));
            cmd.Parameters.AddWithValue("@dateDe", p.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", p.dtpDateA.Text);

            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                p.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvRecette.Rows.Add();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[5].Value = dr[5].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            p.btnAnnuler.Enabled = false;
            p.btnValider.Enabled = false;
        }
        private void ModifierStockPha(FormPhamaVente p, FormStockProduit s)
        {
            s.poste = "pharmacie";
            s.idpharma = p.idpharma;
            s.btnNouveauStock.Visible = false;
            s.btnStockPha.Visible = false;
            s.cboCategorie.Enabled = false;
            s.txtRecherche.Enabled = false;
            s.btnRecherche.Enabled = false;
            s.valider_vente = true;
            s.StartPosition = FormStartPosition.CenterParent;
            s.btnExit.Visible = false;
            s.qtedem = Convert.ToInt32(p.dgvRecette.CurrentRow.Cells[3].Value);
            s.idproduit = cs.TrouverId("produit", p.dgvRecette.CurrentRow.Cells[2].Value.ToString().Substring(0, p.dgvRecette.CurrentRow.Cells[2].Value.ToString().IndexOf(",")));
            s.nomproduit = p.dgvRecette.CurrentRow.Cells[2].Value.ToString().Substring(0, p.dgvRecette.CurrentRow.Cells[2].Value.ToString().IndexOf(","));
            cs.ChargerStockProduit(s, "");           
            s.ShowDialog();
            if(s.vente_effectue)
            {
                RecetteServiOK(Convert.ToInt32(p.dgvRecette.CurrentRow.Cells[0].Value), p.idutilisateur, "OK");
            }
            s.Close();
        }
        public void ServirRecette(FormPhamaVente p, string motif)
        {
            p.btnValider.Enabled = false;
            p.btnAnnuler.Enabled = false;
            if(p.dgvRecette.RowCount != 0)
            {
                
                if (motif == "OK")
                {
                    //Sortie de stock Pharma                   
                    ModifierStockPha(p, new FormStockProduit());
                    RecetteProduit(p);
                }
                else
                {
                    //Retour en stock Pharma
                    RecetteServiOK(Convert.ToInt32(p.dgvRecette.CurrentRow.Cells[0].Value), p.idutilisateur, "");
                    ModifierStockPha(p, new FormStockProduit());
                    RecetteProduit(p);
                }
                
            }
            //Enregistrer les mouvements de stock Pharma
        }
        #endregion

        #region AGENDA CAISSE
        public double MontantAgendaCaisse(int numbon)
        {
            valeur = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select sum(montantpaye) from AgendaCaisse where numbon = @numbon", con);
                cmd.Parameters.AddWithValue("@numbon", numbon);
                dr = cmd.ExecuteReader();
                dr.Read();
                valeur = double.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return valeur;
        }
        public void AgendaCaisse(FormRecette b, FormAgendaLaboResult a)
        {
            
        }
        public void Enregistrer(int numbon, double montanttotal, double montantpaye, string date_jour)
        {
            id = 0;
            id = NouveauID("agendacaisse");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into AgendaCaisse values(@idligne, @numbon, @montanttotal, @montantpaye, @date_jour, @idoperation, @regulation)", con);
                cmd.Parameters.AddWithValue("@idligne", id);
                cmd.Parameters.AddWithValue("@numbon", numbon);
                cmd.Parameters.AddWithValue("@montanttotal", montanttotal);
                cmd.Parameters.AddWithValue("@montantpaye", montantpaye);
                cmd.Parameters.AddWithValue("@date_jour", date_jour);
                cmd.Parameters.AddWithValue("@idoperation", 0);
                cmd.Parameters.AddWithValue("@regulation", "RAS");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void Afficher(FormAgendaLaboResult a, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    cmd = new SqlCommand("select * from AgendaCaisse where idligne= @idligne", con);
                    cmd.Parameters.AddWithValue("@idligne", a.dgvResult.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    cmd = new SqlCommand("select * from AgendaCaisse where numbon= @numbon", con);
                    //cmd.Parameters.AddWithValue("@numbon", a.txtNumBon.Text);
                }
                dr = cmd.ExecuteReader();
                a.dgvResult.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvResult.Rows.Add();
                    a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    if(a.dgvResult.RowCount > 1)
                        a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[4].Value = double.Parse(a.dgvResult.Rows[a.dgvResult.RowCount - 2].Cells[4].Value.ToString()) - double.Parse(a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[3].Value.ToString());
                    else
                        a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[4].Value = double.Parse(a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[2].Value.ToString()) - double.Parse(a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[3].Value.ToString());
                    a.dgvResult.Rows[a.dgvResult.RowCount - 1].Cells[5].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Annuler(FormAgendaLaboResult a)
        {
            
        }
        public void Recuperer(FormAgendaLaboResult a)
        {
            
        }
        public void Modifier(FormAgendaLaboResult a)
        {
            
        }
        public void Supprimer(FormAgendaLaboResult a)
        {
            id = int.Parse(a.dgvResult.CurrentRow.Cells[0].Value.ToString());
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("delete from AgendaCaisse where idligne = @idligne", con);
                cmd.Parameters.AddWithValue("@idligne", id);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            MiseAjourRegulation(id, a.idoperation, "Supprimer");
            a.dgvResult.Rows.RemoveAt(a.dgvResult.CurrentRow.Index);
            Annuler(a);
        }
        public void MiseAjourRegulation(int idligne, int idoperation, string regulation)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (regulation == "")
                {
                    cmd = new SqlCommand("update AgendaCaisse set idoperation = @idoperation where idligne = @idligne", con);
                    cmd.Parameters.AddWithValue("@idoperation", idoperation);
                }
                else
                {
                    cmd = new SqlCommand("update AgendaCaisse set regulation = @regulation where idligne = @idligne", con);
                    cmd.Parameters.AddWithValue("@regulation", regulation);
                }
                cmd.Parameters.AddWithValue("@idligne", idligne);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void PayementDette(FormAgendaLaboResult a)
        {
            //a.idoperation = NouveauID("operation");
            //Enregistrer(int.Parse(a.txtNumBon.Text), double.Parse(a.txtMontantTotal.Text), double.Parse(a.txtMontantPaye.Text), a.dtpDateJour.Value.ToString());
            //MiseAjourRegulation(id, a.idoperation, "");

            //if (EnregistrerOperation(a.idoperation, a.dtpDateJour.Text, "Recouvrement sur crédit", string.Format("BR_{0}", a.txtNumBon.Text), TrouverId("typejournal", "ventes")))
            //{
            //    EnregistrerEcriture(a.id, a.idoperation, a.numcompte, double.Parse(a.txtMontantPaye.Text), 0);
            //    EnregistrerEcriture(a.id, a.idoperation, "411100", 0, double.Parse(a.txtMontantPaye.Text));
            //}
        }
        #endregion

        ReportDataSource rs = new ReportDataSource();

        #region DEPENSE
        public void AfficherSousForm(TresorerieMDI d, FormTresoSortie childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (d.activeForm != null)
                    d.activeForm.Close();
                d.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                d.pnlChildForm.Controls.Add(childForm);
                d.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.idutilisateur = d.idutilisateur;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public void AfficherSousForm(TresorerieMDI d, FormTresoEntree childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (d.activeForm != null)
                    d.activeForm.Close();
                d.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                d.pnlChildForm.Controls.Add(childForm);
                d.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.idutilisateur = d.idutilisateur;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }
        public void AfficherSousForm(TresorerieMDI d, FormTresoJournal childForm)
        {
            if (d.activeForm != null)
                d.activeForm.Close();
            d.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            d.pnlChildForm.Controls.Add(childForm);
            d.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.btnDepenseCompte.Visible = false;
            childForm.idutilisateur = d.idutilisateur;
            childForm.Show();
        }
        public void ChargerCompte(FormComptaPlan d)
        {
            con.Open();
            try
            {
                if (d.cboClasse.Text != "" && d.txtRecherche.Text == "")
                    cmd = new SqlCommand("select numcompte, libellecompte from Compte Where categorie = 'P' and numcompte like '" + d.cboClasse.Text + "%' order by numcompte", con);
                else if (d.cboClasse.Text != "" && d.txtRecherche.Text != "")
                    cmd = new SqlCommand("select numcompte, libellecompte from Compte Where categorie = 'P' and numcompte like '" + d.cboClasse.Text + "%' and libellecompte LIKE '" + d.txtRecherche.Text + "%' order by libellecompte", con);
                dr = cmd.ExecuteReader();
                d.dgv1.Rows.Clear();
                while (dr.Read())
                {
                    d.dgv1.Rows.Add();
                    d.dgv1.Rows[d.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    d.dgv1.Rows[d.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public string CompteDepense(FormComptaPlan c, string motif)
        {
            chaine = "";
            if (motif == "trésorerie")
                c.cboClasse.Items.AddRange(new string[] { "2", "3", "4", "6" });
            else
                c.cboClasse.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8" });            
            c.ShowDialog();
            if(c.fermeture_succes)
            {
                chaine = c.dgvCompte.CurrentRow.Cells[0].Value.ToString();
            }
            c.Close();
            return chaine;
        }
        public void CompteClasse(FormComptaPlan c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select numcompte, libellecompte from Compte where numcompte like '" + c.numcompte + "%' and categorie IN ('U', 'UU') order by libellecompte", con);
                dr = cmd.ExecuteReader();
                c.dgvCompte.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvCompte.Rows.Add();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ContrePartie(DataGridView dgv, int col_debit, int col_credit)
        {
            dgv.Rows[dgv.RowCount - 1].Cells[col_credit].Value = "0";
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[dgv.RowCount - 1].Cells[col_credit].Value = double.Parse(dgv.Rows[dgv.RowCount - 1].Cells[col_credit].Value.ToString()) + double.Parse(dgv.Rows[i].Cells[col_debit].Value.ToString());
            }
        }
        public void Valider(FormTresoSortie d)
        {
            if (d.dgvEcriture.RowCount != 0)
            {
                d.dgvEcriture.Rows.RemoveAt(d.dgvEcriture.RowCount - 1);

                d.dgvEcriture.Rows.Add();
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[0].Value = d.txtCompte.Text;
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = d.txtMotif.Text;
                if (d.cboCaisseDepense.Text == d.cboMonnaie.Text)
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = d.txtMontant.Text;
                else if (d.cboCaisseDepense.Text == "CDF" && d.cboMonnaie.Text == "USD")
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = Convert.ToDouble(d.txtMontant.Text) * d.taux;
                else if (d.cboCaisseDepense.Text == "USD" && d.cboMonnaie.Text == "CDF")
                {
                    if ((Convert.ToDouble(d.txtMontant.Text) / d.taux) >= 5)
                    {
                        d.txtMontant.Text = ((int)(Convert.ToDouble(d.txtMontant.Text) / d.taux) * d.taux).ToString();
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = (int)(Convert.ToDouble(d.txtMontant.Text) / d.taux);                        
                    }
                    else
                    {
                        MessageBox.Show("Impossible de sortir moins de 5 USD", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                    }
                }
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[3].Value = "0";

                d.dgvEcriture.Rows.Add();
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[0].Value = d.numcompte;
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                for (int i = 0; i < d.dgvEcriture.RowCount-1; i++)
                {
                    if (d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value == "") 
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = d.dgvEcriture.Rows[i].Cells[1].Value.ToString();
                    else
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}", d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value.ToString(), d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                }
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = "0";

                ContrePartie(d.dgvEcriture, 2, 3);
            }
            else
            {
                d.dgvEcriture.Rows.Add();
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[0].Value = d.txtCompte.Text;
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = d.txtMotif.Text;
                if (d.cboCaisseDepense.Text == d.cboMonnaie.Text)
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = d.txtMontant.Text;
                else if (d.cboCaisseDepense.Text == "CDF" && d.cboMonnaie.Text == "USD")
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = Convert.ToDouble(d.txtMontant.Text) * d.taux;
                else if (d.cboCaisseDepense.Text == "USD" && d.cboMonnaie.Text == "CDF")
                {
                    if ((Convert.ToDouble(d.txtMontant.Text) / d.taux) >= 5)
                    {
                        d.txtMontant.Text = ((int)(Convert.ToDouble(d.txtMontant.Text) / d.taux) * d.taux).ToString();
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = (int)(Convert.ToDouble(d.txtMontant.Text) / d.taux);
                    }
                    else
                    {
                        MessageBox.Show("Impossible de sortir moins de 5 USD", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                    }
                }
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[3].Value = "0";

                d.dgvEcriture.Rows.Add();
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[0].Value = d.numcompte;
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value = d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 2].Cells[1].Value.ToString();
                d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = "0";

                ContrePartie(d.dgvEcriture, 2, 3);
            }
            d.txtMontant.Text = "";
            d.txtCompte.Text = "";
            d.txtMotif.Text = "";
            d.txtMontant.Focus();
        }
        public string TestMontant(TextBox txt)
        {
            valeur = 0;
            chaine = "";
            if (txt.Text != "")
            {
                try
                {
                    valeur = Convert.ToDouble(txt.Text);
                    if (txt.Text.Contains(","))
                    {
                        chaine = NumbersToWords(long.Parse(txt.Text.Substring(0, txt.Text.IndexOf(","))));
                        chaine = string.Format("{0} virgule {1}", chaine, NumbersToWords(long.Parse(txt.Text.Substring(txt.Text.IndexOf(",") + 1))));
                    }
                    else chaine = NumbersToWords(long.Parse(txt.Text));

                }
                catch (Exception)
                {
                    MessageBox.Show("Erreur! Vérifiez que le montant est correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Select();

                }
            }
            return chaine;
        }
        public string NumbersToWords(long number)
        {
            if (number == 0) return "zéro";

            if (number < 0) return "moins " + NumbersToWords(Math.Abs(number));

            string words = "";
            //valeur de test : 156789
            if ((number / 1000000000) > 0)
            {
                if ((number / 1000000000) == 1)
                    words += NumbersToWords(number / 1000000000) + " milliard ";
                else
                    words += NumbersToWords(number / 1000000000) + " milliards ";

                number %= 1000000000;
            }
            if ((number / 1000000) > 0)
            {
                if ((number / 1000000) == 1)
                    words += NumbersToWords(number / 1000000) + " million ";
                else
                    words += NumbersToWords(number / 1000000) + " millions ";

                number %= 1000000;
            }
            if ((number / 1000) > 0)
            {
                if ((number / 1000) > 1) words += NumbersToWords(number / 1000) + " milles ";
                else
                    words += "mille ";

                number %= 1000;
            }
            if ((number / 100) > 0)
            {
                if ((number / 100) == 1)
                    words += "cent ";
                else
                    words += NumbersToWords(number / 100) + " cents ";

                number %= 100;
            }
            if (number > 0)
            {
                //if (words != "") words += " ";
                var unites = new[] { "zéro", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf", "dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix sept", "dix huit", "dix neuf" };
                var dizaines = new[] { "zéro", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "septante", "quatre-vingt", "nonante" };

                if (number < 20) words += unites[number];
                else
                {
                    words += dizaines[number / 10];
                    if ((number % 10) > 0)
                    {
                        if (unites[number % 10] == "un")
                            words += "-et-un";
                        else
                            words += " " + unites[number % 10];
                    }
                }
            }
            return words;
        }
        public void Annuler(FormTresoSortie d)
        {
            d.txtNumRequisition.Text = "";
            d.cboCaisseDepense.DropDownStyle = ComboBoxStyle.DropDown;
            d.cboCaisseDepense.SelectedText = "";
            d.cboCaisseDepense.DropDownStyle = ComboBoxStyle.DropDownList;            
            d.txtBeneficiaire.Text = "";
            d.txtMontant.Text = "";
            d.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
            d.cboMonnaie.SelectedText = "";
            d.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
            d.txtCompte.Text = "";
            d.txtMotif.Text = "";
            d.cboCaisseDepense.Enabled = true;
            d.txtMontantLettre.Text = "";
            d.dgvEcriture.Rows.Clear();
            d.txtNumRequisition.Focus();
        }
        private void AjouterDepense(FormTresoSortie d)
        {
            for (int i = 0; i < d.dgvEcriture.RowCount - 1; i++)
            {
                d.iddepense = NouveauID("depense");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Depense (iddepense, date_operation, beneficiaire, refrequisition, numcompte, motifdepense, montant, monnaie) VALUES (@iddepense, @date_operation, @beneficiaire, @refrequisition, @numcompte, @motifdepense, @montant, @monnaie)", con);
                    cmd.Parameters.AddWithValue("@iddepense", d.iddepense);
                    cmd.Parameters.AddWithValue("@date_operation", d.lblDateOperation.Text);
                    cmd.Parameters.AddWithValue("@beneficiaire", d.txtBeneficiaire.Text);
                    cmd.Parameters.AddWithValue("@refrequisition", d.txtNumRequisition.Text);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvEcriture.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@motifdepense", d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@montant", d.dgvEcriture.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", d.cboCaisseDepense.Text);
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
            MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void Enregistrer(FormTresoSortie d)
        {
            if (d.dgvEcriture.RowCount != 0 && d.txtBeneficiaire.Text != "" && d.cboCaisseDepense.Text != "" && d.txtNumRequisition.Text != "")
            {
                //Montant en lettres
                d.montantdecaisse = Convert.ToDouble(d.dgvEcriture.Rows[d.dgvEcriture.RowCount-1].Cells[3].Value);
                if (d.montantdecaisse.ToString().Contains(","))
                {
                    chaine = NumbersToWords(long.Parse(d.montantdecaisse.ToString().Substring(0, d.montantdecaisse.ToString().IndexOf(","))));
                    chaine = string.Format("{0} virgule {1}", chaine, NumbersToWords(long.Parse(d.montantdecaisse.ToString().Substring(d.montantdecaisse.ToString().IndexOf(",") + 1))));
                }
                else chaine = NumbersToWords(long.Parse(d.montantdecaisse.ToString()));
                if (d.cboCaisseDepense.Text == "CDF")
                    d.txtMontantLettre.Text = chaine.Substring(0, 1).ToUpper() + chaine.Substring(1) + " francs congolais";
                else if (d.cboCaisseDepense.Text == "USD")
                    d.txtMontantLettre.Text = chaine.Substring(0, 1).ToUpper() + chaine.Substring(1) + " dollars américains";

                if (d.soldeCaisse >= d.montantdecaisse)
                {                   
                    //Dépenses
                    AjouterDepense(d);

                    //Ecriture comptables
                    d.idoperation = AjouterOperation(d.lblDateOperation.Text, "DEP", TrouverId("typejournal", d.caisse), d.idexercice);
                    for (int i = 0; i < d.dgvEcriture.RowCount - 1; i++)
                    {
                        if (d.cboCaisseDepense.Text == "CDF")
                            DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value), d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                        else
                            DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value) * d.taux, d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    }
                    CrediterCompte(d.idoperation, d.numcompte, d.montantdecaisse, d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());

                    ArchiverBon("dépense", d.iddepense);
                    ImprimerBon(d, new FormImpression());
                    Annuler(d);
                    SoldesCaisse(d.lblCaisseCDF, d.lblCaisseUSD, "dépense");
                }
                else
                    MessageBox.Show("Solde caisse insuffisant", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AnnulerDepense(FormTresoJournal d, FormTresoDepense td)
        {
            td.ShowDialog();
            if(td.fermeture_succes)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Depense SET raison_retrait = @raison WHERE iddepense = " + d.dgvBon.CurrentRow.Cells[0].Value + "", con);
                    cmd.Parameters.AddWithValue("@raison", string.Format("{0}, {1}", DateTime.Now.ToShortDateString(), td.txtRaison_retrait.Text));
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Opération effectuée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                //composer le message
                chaine = string.Format("Annulation dépense {0} pour {1}\nDate:{2}\nMontant:{3} {4}\nCompte:{5}",
                    d.dgvBon.CurrentRow.Cells[0].Value.ToString(),
                    d.dgvBon.CurrentRow.Cells[7].Value.ToString(),
                    d.dgvBon.CurrentRow.Cells[1].Value.ToString(),
                    d.dgvBon.CurrentRow.Cells[2].Value.ToString(),
                    d.dgvBon.CurrentRow.Cells[3].Value.ToString(),
                    d.dgvBon.CurrentRow.Cells[8].Value.ToString());
                //Signaler au comptable
                MessageAuComptable(d.idutilisateur, chaine, "dépense");
                AfficherTresoRapport(d);
            }
            td.Close();
        }
        public void ImprimerBon(FormTresoSortie d, FormImpression imp)
        {
            imp.beneficiaire = d.txtBeneficiaire.Text;
            imp.montantlettre = d.txtMontantLettre.Text;
            imp.montantchiffre = d.montantdecaisse.ToString();
            imp.monnaie = d.cboCaisseDepense.Text;
            imp.motif = d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value.ToString();
            imp.date_jour = d.lblDateOperation.Text;
            imp.bonrequisition = d.txtNumRequisition.Text;

            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("numbon", ""),
                new ReportParameter("beneficiare", imp.beneficiaire),
                new ReportParameter("montantlettre", imp.montantlettre),
                new ReportParameter("montantchiffre", imp.montantchiffre),
                new ReportParameter("monnaie", imp.monnaie),
                new ReportParameter("motif", imp.motif),
                new ReportParameter("requisition", imp.bonrequisition),
                new ReportParameter("date_jour", imp.date_jour)
            };
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonDepense.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.MaximumSize = imp.Size;
            imp.MaximizeBox = false;
            imp.MinimizeBox = false;
            imp.Text = "Bon de sortie de caisse";
            imp.ShowDialog();
        }
        public void AjouterEncaissement(FormTresoEntree d)
        {
            if (d.cboEncaisser.Text == "rapport de recettes")
            {
                for (int i = 0; i < d.dgvBon.RowCount; i++)
                {
                    if (d.dgvBon.Rows[i].Cells[0].Value.ToString() == "571101")
                    {
                        //AjouterOperation()
                        d.caisse = "Caisse en CDF Dépenses";
                        d.idoperation = AjouterOperation(d.lblDateJour.Text, "RAP REC CDF", TrouverId("typejournal", d.caisse), d.idexercice);
                        AjouterEcriture(d.idoperation, "585000", "571101", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes CDF");
                        AjouterEcriture(d.idoperation, "571102", "585000", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes CDF");

                    }
                    else if (d.dgvBon.Rows[i].Cells[0].Value.ToString() == "571201")
                    {
                        //AjouterOperation()
                        d.caisse = "Caisse en USD Dépenses";
                        d.idoperation = AjouterOperation(d.lblDateJour.Text, "RAP REC USD", TrouverId("typejournal", d.caisse), d.idexercice);
                        AjouterEcriture(d.idoperation, "585000", "571201", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()) * d.taux, double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes USD");
                        AjouterEcriture(d.idoperation, "571202", "585000", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()) * d.taux, "Rapport de recettes USD");

                    }
                }
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d.cboEncaisser.Text == "virement bancaire")
            {
                if (d.txtMontant.Text != "")
                {
                    if (d.dgvBon.CurrentRow.Cells[0].Value.ToString() == "521100")
                    {
                        //AjouterOperation()
                        d.caisse = "Banque en CDF";
                        d.idoperation = AjouterOperation(d.lblDateJour.Text, "VIR CDF", TrouverId("typejournal", d.caisse), d.idexercice);
                        AjouterEcriture(d.idoperation, "585000", "521100", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text), "Virement en CDF");
                        AjouterEcriture(d.idoperation, "571102", "585000", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text), "Virement en CDF");

                    }
                    else if (d.dgvBon.CurrentRow.Cells[0].Value.ToString() == "521500")
                    {
                        //AjouterOperation()
                        d.caisse = "Banque Equity USD";
                        d.idoperation = AjouterOperation(d.lblDateJour.Text, "VIR USD", TrouverId("typejournal", d.caisse), d.idexercice);
                        AjouterEcriture(d.idoperation, "585000", "521500", double.Parse(d.txtMontant.Text) * d.taux, double.Parse(d.txtMontant.Text), "Virement en USD");
                        AjouterEcriture(d.idoperation, "571202", "585000", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text) * d.taux, "Virement en USD");

                    }
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Aucun montant n'est fourni pour ce virement", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (d.txtMontant.Text != "")
                {
                    PayementAbonne(d);
                }
                else
                    MessageBox.Show("Aucun montant n'est fourni pour ce virement", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Annuler(d);
            SoldesCaisse(d.lblCaisseCDF, d.lblCaisseUSD, "dépense");

        }
        public void Annuler(FormTresoEntree t)
        {
            t.txtMontant.Text = "";
            t.cboEncaisser.DropDownStyle = ComboBoxStyle.DropDown;
            t.cboEncaisser.SelectedText = "";
            t.cboEncaisser.DropDownStyle = ComboBoxStyle.DropDownList;
            t.dgvBon.Rows.Clear();
        }
        public void Encaisser(FormTresoEntree d)
        {
            if(d.cboEncaisser.Text != "")
            {
                if (d.cboEncaisser.Text == "payement par les abonnés")
                {
                    cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '41110%' and numcompte != '411100'", con);
                    d.cboMonnaie.Enabled = true;
                    d.dgvBon.Columns[2].Visible = false;
                }
                else if (d.cboEncaisser.Text == "rapport de recettes")
                {
                    cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte IN ('571101','571201')", con);
                    d.cboMonnaie.Enabled = false;
                    d.dgvBon.Columns[2].Visible = true;
                }
                else
                {
                    cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '521%' AND categorie IN ('U', 'UU')", con);
                    d.cboMonnaie.Enabled = false;
                    d.dgvBon.Columns[2].Visible = false;
                }
                con.Open();
                try
                {
                    dr = cmd.ExecuteReader();
                    d.dgvBon.Rows.Clear();
                    while (dr.Read())
                    {
                        d.dgvBon.Rows.Add();
                        d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[1].Value = dr[1].ToString();                       
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                if(d.dgvBon.RowCount != 0)
                {
                    for (int i = 0; i < d.dgvBon.RowCount; i++)
                    {
                        d.dgvBon.Rows[i].Cells[2].Value = SoldeCompte(d.dgvBon.Rows[i].Cells[0].Value.ToString());
                    }
                }                
            }
        }
        public void AfficherTresoRapport(FormTresoJournal d)
        {
            if (d.cboMonnaie.Text != "")
            {
                cmdtxt = @"SELECT iddepense,date_operation,montant,monnaie,beneficiaire,motifdepense,refrequisition,raison_retrait, numcompte  
                FROM Depense
                WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);
            }
            else
            {
                cmdtxt = @"SELECT iddepense,date_operation,montant,monnaie,beneficiaire,motifdepense,refrequisition,raison_retrait, numcompte 
                FROM Depense
                WHERE date_operation BETWEEN @dateDe AND @dateA";
                cmd = new SqlCommand(cmdtxt, con);
            }
            cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                d.dgvBon.Rows.Clear();
                while (dr.Read())
                {
                    d.dgvBon.Rows.Add();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[6].Value = dr[6].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[7].Value = dr[7].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[8].Value = dr[8].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

            //Ajouter les totaux
            if (d.cboMonnaie.Text != "")
            {
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Depense WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);               
            }
            else
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Depense WHERE date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
            cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    d.dgvBon.Rows.Add();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[0].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[1].Value = "Total " + dr[0].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[3].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[4].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[5].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[6].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[7].Value = "";
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[8].Value = "";
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        private void RapportTresoCDFUSD(FormTresoRapport d)
        {           
            // Trouver les montants
            if (d.dgvBon.RowCount != 0)
            {
                for (int i = 0; i < d.dgvBon.RowCount; i++)
                {
                    //CDF
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'CDF' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[3].Value = dr[1].ToString();
                        else
                            d.dgvBon.Rows[i].Cells[3].Value = 0;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                    //USD
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'USD' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[4].Value = dr[1].ToString();
                        else
                            d.dgvBon.Rows[i].Cells[4].Value = 0;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        private void RapportTresoCDF(FormTresoRapport d)
        {
            // Trouver les montants
            if (d.dgvBon.RowCount != 0)
            {
                for (int i = 0; i < d.dgvBon.RowCount; i++)
                {
                    //CDF
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'CDF' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[3].Value = dr[1].ToString();
                        else
                            d.dgvBon.Rows[i].Cells[3].Value = 0;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                    //USD en CDF
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'USD' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[3].Value = Convert.ToDouble(d.dgvBon.Rows[i].Cells[3].Value) + Convert.ToDouble(dr[1].ToString()) * d.taux;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        private void RapportTresoUSD(FormTresoRapport d)
        {
            // Trouver les montants
            if (d.dgvBon.RowCount != 0)
            {
                for (int i = 0; i < d.dgvBon.RowCount; i++)
                {                   
                    //USD
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'USD' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[4].Value = dr[1].ToString();
                        else
                            d.dgvBon.Rows[i].Cells[4].Value = 0;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                    //CDF en USD
                    cmdtxt = @"SELECT COUNT(montant), SUM(montant) 
                        FROM Depense d 
                        JOIN Compte c ON d.numcompte = c.numcompte
                        WHERE monnaie = 'CDF' AND d.numcompte = @numcompte 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvBon.Rows[i].Cells[1].Value.ToString());
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        dr.Read();
                        if (int.Parse(dr[0].ToString()) > 0)
                            d.dgvBon.Rows[i].Cells[4].Value = Convert.ToDouble(d.dgvBon.Rows[i].Cells[4].Value) + Convert.ToDouble(dr[1].ToString()) / d.taux;
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public void AfficherTresoJournal(FormTresoRapport d)
        {
            cmdtxt = @"SELECT d.numcompte, c.libellecompte 
                FROM Depense d 
                JOIN Compte c ON d.numcompte = c.numcompte
                WHERE date_operation BETWEEN @dateDe AND @dateA
                GROUP BY d.numcompte, c.libellecompte";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", d.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", d.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                d.dgvBon.Rows.Clear();
                while (dr.Read())
                {
                    d.dgvBon.Rows.Add();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[0].Value = d.dgvBon.RowCount;
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[3].Value = 0;
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[4].Value = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

            if (d.cboMonnaie.Text == "" || d.cboMonnaie.Text == "CDF-USD")
            {
                RapportTresoCDFUSD(d);
            }
            else if (d.cboMonnaie.Text == "CDF")
            {
                RapportTresoCDF(d);
            }
            else if (d.cboMonnaie.Text == "USD")
            {
                RapportTresoUSD(d);
            }
        }
        #endregion

        #region SERVICE
        public void Enregistrer(FormService s)
        {
            if(s.cboCatService.Text !="" && s.txtNomService.Text !="" && s.txtPrixService.Text !="" && s.cboSpecification.Text != "")
            {
                s.idservice = NouveauID("service");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Service values (@id, @nom, @prix, @numcompte, @specification)", con);
                    cmd.Parameters.AddWithValue("@id", s.idservice);
                    cmd.Parameters.AddWithValue("@nom", s.txtNomService.Text);
                    cmd.Parameters.AddWithValue("@prix", s.txtPrixService.Text);
                    cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
                    cmd.Parameters.AddWithValue("@specification", s.cboSpecification.Text);
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
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormService s)
        {
            if (s.cboCatService.Text != "" && s.txtNomService.Text != "" && s.txtPrixService.Text != "" && s.cboSpecification.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Service set nomservice= @nom, prixservice= @prix, numcompte= @numcompte, specification= @specification where idservice = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idservice);
                    cmd.Parameters.AddWithValue("@nom", s.txtNomService.Text);
                    cmd.Parameters.AddWithValue("@prix", s.txtPrixService.Text);
                    cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
                    cmd.Parameters.AddWithValue("@specification", s.cboSpecification.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Mofifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int CompterLigneService(int idservice)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select COUNT(idservice) from RecetteService where idservice = @id", con);
                cmd.Parameters.AddWithValue("@id", idservice);
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
        public void Supprimer(FormService s)
        {
            if(CompterLigneService(s.idservice)==0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Service where idservice = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idservice);

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
                s.dgvService.Rows.RemoveAt(s.dgvService.CurrentRow.Index);
            }
            else
                MessageBox.Show("Ce service est déjà impliqué dans les recettes facturées,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Annuler(FormService s)
        {
            s.cboSpecification.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboSpecification.SelectedText = "";
            s.cboSpecification.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtNomService.Text = "";
            s.txtPrixService.Text = "";
            s.btnModifier.Enabled = false;
            s.btnSupprimer.Enabled = false;
            s.btnEnregistrer.Enabled = true;
            s.dgvService.Rows.Clear();
            s.cboCatService.Select();
        }
        public void Afficher(FormService s)
        {
            if (s.cboCatService.Text != "" || s.txtNomService.Text != "")
            {
                con.Open();
                try
                {
                    if (s.cboCatService.Text != "")
                    {
                        cmdtxt = @"SELECT idservice, nomservice, prixservice, c.libellecompte, specification
                        FROM Service s
                        JOIN Compte c ON s.numcompte = c.numcompte
                        WHERE s.numcompte = @numcompte";
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
                    }
                    else if (s.cboCatService.Text == "" && s.txtNomService.Text != "")
                    {
                        cmdtxt = @"SELECT idservice, nomservice, prixservice, c.libellecompte, specification
                        FROM Service s
                        JOIN Compte c ON s.numcompte = c.numcompte
                        WHERE nomservice like '" + s.txtNomService.Text + "%'";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    dr = cmd.ExecuteReader();
                    s.dgvService.Rows.Clear();
                    while (dr.Read())
                    {
                        s.dgvService.Rows.Add();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            else
                MessageBox.Show("Aucun motif de recherche n'est fourni", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Recuperer(FormService s)
        {
            if(s.dgvService.RowCount > 0)
            {
                s.btnModifier.Enabled = true;
                s.btnSupprimer.Enabled = true;
                s.btnEnregistrer.Enabled = false;
                s.idservice = int.Parse(s.dgvService.CurrentRow.Cells[0].Value.ToString());
                s.txtNomService.Text = s.dgvService.CurrentRow.Cells[1].Value.ToString();
                s.txtPrixService.Text = s.dgvService.CurrentRow.Cells[2].Value.ToString();
                s.cboCatService.Select();
            }
        }
        #endregion

        #region ABONNE
        public void AfficherSousForm(AbonneMDI a, FormPatientRecherche childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (a.activeForm != null)
                    a.activeForm.Close();
                a.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                a.pnlChildForm.Controls.Add(childForm);
                a.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.poste = TrouverNom("poste", a.idutilisateur);
                childForm.infirmier_autorise = a.infirmier_autorise;
                
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public void AfficherSousForm(AbonneMDI a, Form childForm)
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

        private void AjouterRubriqueRapport(FormAbonnePersoRapport r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT libellecompte FROM Compte WHERE numcompte LIKE '701100%' OR numcompte LIKE '7061%' OR numcompte <> '707803' AND numcompte LIKE '70780%'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    r.dgvRapport.Columns.Add("c" + r.dgvRapport.ColumnCount + 1, dr[0].ToString());
                    r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].MinimumWidth = 100;
                    r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].DefaultCellStyle.Format = "N2";
                    for (int i = 0; i < r.dgvRapport.RowCount; i++)
                    {
                        r.dgvRapport.Rows[i].Cells[r.dgvRapport.ColumnCount - 1].Value = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            //Colonne de total par ligne
            r.dgvRapport.Columns.Add("c" + r.dgvRapport.ColumnCount + 1, "Total");
            r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].MinimumWidth = 100;
            r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].DefaultCellStyle.Format = "N2";
            r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Columns[r.dgvRapport.ColumnCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            for (int i = 0; i < r.dgvRapport.RowCount; i++)
            {
                r.dgvRapport.Rows[i].Cells[r.dgvRapport.ColumnCount - 1].Value = 0;
            }
            //Ligne de total par colonne
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            for (int i = 0; i < r.dgvRapport.ColumnCount; i++)
            {
                if (i < 2||i>2 && i<6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "";
                else if(i==2)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "Totaux";
                else if(i>=6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = 0;
            }
        }
        private void TrouverConsommation(FormAbonnePersoRapport r)
        {
            for (int i = 6; i < r.dgvRapport.ColumnCount-1; i++)
            {
                r.numcompte = TrouverId("numcompte", r.dgvRapport.Columns[i].HeaderText).ToString();
                for (int j = 0; j < r.dgvRapport.RowCount-1; j++)
                {
                    con.Open();
                    try
                    {

                        cmd = new SqlCommand("SELECT SUM(prix * qtedem) FROM Recette_ WHERE idpatient = @idpatient AND numcompte = @numcompte AND date_operation BETWEEN @dateDe AND @dateA", con);
                        cmd.Parameters.AddWithValue("@idpatient", Convert.ToInt32(r.dgvRapport.Rows[j].Cells[1].Value));
                        cmd.Parameters.AddWithValue("@numcompte", r.numcompte);
                        cmd.Parameters.AddWithValue("@dateDe", r.dtpDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", r.dtpA.Text);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                r.dgvRapport.Rows[j].Cells[i].Value = Convert.ToDouble(dr[0].ToString());//Additionner à ce montant le % du taux service ou produit Juin/2024
                                r.dgvRapport.Rows[j].Cells[r.dgvRapport.ColumnCount - 1].Value = Convert.ToDouble(r.dgvRapport.Rows[j].Cells[r.dgvRapport.ColumnCount - 1].Value) + Convert.ToDouble(dr[0].ToString());
                                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value) + Convert.ToDouble(dr[0].ToString());
                                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[r.dgvRapport.ColumnCount - 1].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[r.dgvRapport.ColumnCount - 1].Value) + Convert.ToDouble(dr[0].ToString());
                            }
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
        public void AfficherAbonnePerso(FormAbonnePersoRapport r)
        {            
            con.Open();
            try
            {

                if (r.checkBox1.Checked)
                {
                    cmdtxt = @"SELECT idpatient, noms, age, sexe, num_service
                    FROM Patient p
                    JOIN TypePatient tp ON p.idtype = tp.idtype
                    WHERE nomtype = 'employé'";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else
                {
                    cmdtxt = @"SELECT idpatient, noms, age, sexe, num_service
                    FROM Patient p
                    JOIN Entreprise e ON e.identreprise = p.identreprise
                    WHERE e.identreprise = @identreprise";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@identreprise", r.identreprise);
                }
                dr = cmd.ExecuteReader();
                r.dgvRapport.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = r.dgvRapport.RowCount;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if(r.dgvRapport.RowCount != 0)
            {
                AjouterRubriqueRapport(r);               
                TrouverConsommation(r);
                TotalCDFUSD(r);
            }
        }
        private void TotalCDFUSD(FormAbonnePersoRapport r)
        {
            //Ligne de total CDF
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            for (int i = 0; i < r.dgvRapport.ColumnCount; i++)
            {
                if (i < 2 || i > 2 && i < 6 || i > 6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "";
                else if (i == 2)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "Total CDF";
                else if (i == 6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = 0;
            }
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[r.dgvRapport.ColumnCount-1].Value);
            //Ligne de total USD
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            for (int i = 0; i < r.dgvRapport.ColumnCount; i++)
            {
                if (i < 2 || i > 2 && i < 6 || i > 6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "";
                else if (i == 2)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = "Total USD";
                else if (i == 6)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[i].Value = 0;
            }
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[6].Value)/r.taux;
        }
        public void ImprimerRapport(FormAbonnePersoRapport r, FormImpression imp)
        {
            
        }
        #endregion

        ClassStock cs = new ClassStock();

        #region COMPTABILITE

        public void AfficherSousForm(ComptabiliteMDI c, FormApproCommande childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.poste = "comptable";
                childForm.cboDepot.Enabled = false;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }

        public void Enregistrer(FormComptaExercice c)
        {
            c.idexercice = NouveauID("exercice");
            con.Open();
            try
            {
                
                SqlTransaction tx = con.BeginTransaction();
                cmd = new SqlCommand("INSERT INTO Exercice(idexercice, exercice) VALUES (@id, @exercice)", con);
                cmd.Parameters.AddWithValue("@id", c.idexercice);
                cmd.Parameters.AddWithValue("@exercice", c.txtexercice.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message,"Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Afficher(c);
        }
        public void Afficher(FormComptaExercice c)
        {
            con.Open();
            cmd = new SqlCommand("SELECT * from Exercice", con);
            dr = cmd.ExecuteReader();
            c.dgvExercice.Rows.Clear();
            while(dr.Read())
            {
                c.dgvExercice.Rows.Add();
                c.dgvExercice.Rows[c.dgvExercice.RowCount - 1].Cells[0].Value = dr[0].ToString();
                c.dgvExercice.Rows[c.dgvExercice.RowCount - 1].Cells[1].Value = dr[1].ToString();
                c.dgvExercice.Rows[c.dgvExercice.RowCount - 1].Cells[2].Value = dr[2].ToString();
            }           
            con.Close();
        }
        private int CompterOperation(int idexercice)
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(idoperation) from Operation where idexercice = @id", con);
            cmd.Parameters.AddWithValue("@id", idexercice);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        public void Supprimer(FormComptaExercice c)
        {
            if (CompterOperation(c.idexercice) == 0)
            {
                con.Open();
                try
                {

                    SqlTransaction tx = con.BeginTransaction();
                    cmd = new SqlCommand("DELETE FROM Exercice WHERE idexercice = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idexercice);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Mise à jour avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Afficher(c);
                c.btnSupprimer.Enabled = false;
                c.suppression = false;
            }
            else
                MessageBox.Show("Impossible de supprimer un exercice impliqué dans les opérations", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaOperation childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaGdLivre childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
        }
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaBilan childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
        }
        public void AfficherSousForm(ComptabiliteMDI c, Form childForm)
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
            childForm.Show();
        }
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaTableauFlux childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaBalance childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AfficherSousForm(ComptabiliteMDI c, FormComptaResultat childForm)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                childForm.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(childForm);
                c.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        public void Annuler(FormCompte c)
        {
            c.txtNumCompte.Clear();
            c.txtLibelle.Clear();
            c.txtRef.Clear();
            c.btnEnregistrer.Enabled = true;
            c.btnModifier.Enabled = false;
            c.cboCategorie.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboCategorie.SelectedText = "";
            c.cboCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtNumCompte.Select();
        }
        public int VerifierNumCompte(string numcompte)
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("select count(numcompte) from Compte where numcompte= @num", con);
            cmd.Parameters.AddWithValue("@num", numcompte);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        private int VerifierCompte(string libellecompte)
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("select libellecompte from Compte where libellecompte= @libelle", con);
            cmd.Parameters.AddWithValue("@libelle", libellecompte);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        public void Enregistrer(FormCompte c)
        {
            if(c.txtNumCompte.Text != "" && c.txtLibelle.Text != "")
            {
                if (VerifierNumCompte(c.txtNumCompte.Text) == 0 && VerifierCompte(c.txtLibelle.Text) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Compte values (@numcompte, @libelle, @reference, @categorie)", con);
                        cmd.Parameters.AddWithValue("@numcompte", c.txtNumCompte.Text);
                        cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                        cmd.Parameters.AddWithValue("@reference", c.txtRef.Text);
                        cmd.Parameters.AddWithValue("@categorie", c.categorie);
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
                    Annuler(c);
                }
                else
                {
                    MessageBox.Show("Le numéro de compte saisi exite déjà dans le système", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    c.txtNumCompte.Select();
                }

            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormCompte c)
        {
            if (c.txtNumCompte.Text != "" && c.txtLibelle.Text != "" && c.cboCategorie.Text != "")
            {
                if (VerifierNumCompte(c.txtNumCompte.Text) == 0 && VerifierCompte(c.txtLibelle.Text) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("UPDATE Compte SET numcompte = @newcompte, libellecompte= @libelle, categorie = @categorie, ref = @ref WHERE numcompte= @numcompte", con);
                        cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
                        cmd.Parameters.AddWithValue("@newcompte", c.txtNumCompte.Text);
                        cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                        cmd.Parameters.AddWithValue("@categorie", c.categorie);
                        cmd.Parameters.AddWithValue("@ref", c.txtRef.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        c.btnModifier.Enabled = false;
                        MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Annuler(c);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int CompterOperationCompte(string numcompte)
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("select count(id) from OperationCompte where numcompte = @numcompte", con);
            cmd.Parameters.AddWithValue("@numcompte", numcompte);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        public void Supprimer(FormComptes c)
        {
           if(CompterOperationCompte(c.dgvCompte.CurrentRow.Cells[0].Value.ToString())==0)
           {
               con.Open();
               SqlTransaction tx = con.BeginTransaction();
               try
               {
                   cmd = new SqlCommand("DELETE FROM Compte WHERE numcompte= @numcompte", con);
                   cmd.Parameters.AddWithValue("@numcompte", c.dgvCompte.CurrentRow.Cells[0].Value.ToString());
                   cmd.Transaction = tx;
                   cmd.ExecuteNonQuery();
                   tx.Commit();
                   MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   c.btnSupprimer.Enabled = false;
                   c.dgvCompte.Rows.RemoveAt(c.dgvCompte.CurrentRow.Index);
               }
               catch (Exception ex)
               {
                   tx.Rollback();
                   MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               con.Close();
           }
            else
               MessageBox.Show("Le compte sélectionné est déjà impliqué dans les opérations comptables,\npour raison de de cohérence, il ne peut être supprimé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Afficher(FormComptes c)
        {
            con.Open();
            try
            {
                if (c.cboClasse.Text != "" && c.txtRecherche.Text == "")
                {
                    if (c.cboCategorie.Text != "")
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref, categorie FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' AND categorie = '" + c.cboCategorie.Text + "' ORDER BY numcompte", con);
                    else
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref, categorie FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' ORDER BY numcompte", con);
                }
                else if (c.cboClasse.Text != "" && c.txtRecherche.Text != "")
                {
                    if (c.cboCategorie.Text != "")
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref, categorie FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' AND categorie = '" + c.cboCategorie.Text + "' AND libellecompte LIKE '"+c.txtRecherche.Text.Replace("'", "")+"%' ORDER BY numcompte", con);
                    else
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref, categorie FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' AND libellecompte LIKE '" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY numcompte", con);
                }
                else if (c.cboClasse.Text == "" && c.cboCategorie.Text == "" && c.txtRecherche.Text != "")
                    cmd = new SqlCommand("SELECT numcompte, libellecompte, ref, categorie FROM Compte WHERE libellecompte LIKE '" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY libellecompte", con);
                
                c.dgvCompte.Rows.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.dgvCompte.Rows.Add();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public void AfficherRapportGlobal(FormComptaRecetteDepense r)
        {
            for (int i = 0; i < 2; i++)
            {
                r.dgvRapport.Rows.Add();
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = 0;
                if(i == 0)
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "Recette par banque";
                else
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "Solde antérieur";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = 0;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = 0;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = "";
            }
            //Rubriques recettes
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = 0;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "RECETTES";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = "";
            cmdtxt = @"SELECT p.numcompte, c.libellecompte 
                FROM Payement p 
                JOIN Compte c ON p.numcompte = c.numcompte
                WHERE date_operation BETWEEN @dateDe AND @dateA
                GROUP BY p.numcompte, c.libellecompte";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = 0;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = 0;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = "R";
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
           
            //Rubriques dépenses
            r.dgvRapport.Rows.Add();
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = 0;
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "DEPENSES";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";
            r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = "";

            cmdtxt = @"SELECT d.numcompte, c.libellecompte 
                FROM Depense d 
                JOIN Compte c ON d.numcompte = c.numcompte
                WHERE date_operation BETWEEN @dateDe AND @dateA
                GROUP BY d.numcompte, c.libellecompte";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = "";
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = "";
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = 0;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = 0;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = "D";
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            MontantRapportGlobal(r);
            CalculerTotauxRapportGlobal(r);
        }
        private void MontantRapportGlobal(FormComptaRecetteDepense r)
        {
            //Rubriques recettes
            for (int i = 3; i < r.dgvRapport.RowCount; i++)
            {
                if(r.dgvRapport.Rows[i].Cells[6].Value.ToString() == "R")
                {
                    cmdtxt = @"SELECT COUNT(p.montant), SUM(p.montant) 
                    FROM Payement p 
                    WHERE raison_retrait IS NULL AND p.numcompte = @numcompte AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", r.dgvRapport.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", "CDF");
                    cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "0")
                                r.dgvRapport.Rows[i].Cells[2].Value = dr[1].ToString();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();

                    cmdtxt = @"SELECT COUNT(p.montant), SUM(p.montant) 
                    FROM Payement p 
                    WHERE raison_retrait IS NULL AND p.numcompte = @numcompte AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", r.dgvRapport.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", "USD");
                    cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "0")
                                r.dgvRapport.Rows[i].Cells[3].Value = dr[1].ToString();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }               
            }
            
            //Rubriques dépenses
            for (int i = 3; i < r.dgvRapport.RowCount; i++)
            {
                if (r.dgvRapport.Rows[i].Cells[6].Value.ToString() == "D")
                {
                    cmdtxt = @"SELECT COUNT(d.montant), SUM(d.montant) 
                    FROM Depense d
                    WHERE d.numcompte = @numcompte AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", r.dgvRapport.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", "CDF");
                    cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "0")
                                r.dgvRapport.Rows[i].Cells[4].Value = dr[1].ToString();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();

                    cmdtxt = @"SELECT COUNT(d.montant), SUM(d.montant) 
                    FROM Depense d
                    WHERE d.numcompte = @numcompte AND monnaie = @monnaie AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", r.dgvRapport.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", "USD");
                    cmd.Parameters.AddWithValue("@dateDe", r.dtpDateDe.Value.Date);
                    cmd.Parameters.AddWithValue("@dateA", r.dtpDateA.Value.Date);
                    con.Open();
                    try
                    {
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "0")
                                r.dgvRapport.Rows[i].Cells[5].Value = dr[1].ToString();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public void CalculerTotauxRapportGlobal(FormComptaRecetteDepense r)
        {
            try
            {
                r.dgvRapport.Rows.Add();
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "Totaux";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = 0;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = 0;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = 0;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = 0;
                for (int i = 0; i < r.dgvRapport.RowCount-1; i++)
                {
                    if (r.dgvRapport.Rows[i].Cells[2].Value.ToString() != "")
                        r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value) + Convert.ToDouble(r.dgvRapport.Rows[i].Cells[2].Value);
                    if (r.dgvRapport.Rows[i].Cells[3].Value.ToString() != "") 
                        r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value) + Convert.ToDouble(r.dgvRapport.Rows[i].Cells[3].Value);
                    if (r.dgvRapport.Rows[i].Cells[4].Value.ToString() != "") 
                        r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value) + Convert.ToDouble(r.dgvRapport.Rows[i].Cells[4].Value);
                    if (r.dgvRapport.Rows[i].Cells[5].Value.ToString() != "") 
                        r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value) + Convert.ToDouble(r.dgvRapport.Rows[i].Cells[5].Value);
                }
                r.dgvRapport.Rows.Add();
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "Solde en CDF";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = (Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[2].Value) + r.taux * Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[3].Value)) - (Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[4].Value) + r.taux * Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[5].Value));
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";

                r.dgvRapport.Rows.Add();
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = "Solde en USD";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[2].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[3].Value = (Convert.ToDouble(r.dgvRapport.Rows[r.dgvRapport.RowCount - 2].Cells[2].Value) / r.taux);
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[4].Value = "";
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = "";

                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region OPERATION_COMPTABLE
        public void Annuler(FormComptabilite c)
        {
            c.txtNumPiece.Text = "";           
            c.txtMotif.Text = "";
            c.txtMontant.Text = "";
            c.txtCompte1.Text = "";
            c.txtCompte2.Text = "";
            c.cboDebitCredit.Enabled = true;
            c.dgvEcriture.Rows.Clear();
            AnnulerApresValid(c);
        }
        public int AjouterOperation(string date_jour, string numpiece, int idtypejournal, int idexercice)
        {
            id = NouveauID("operation");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Operation(idoperation, date_operation, numpiece, idtypejournal, idexercice) values(@id, @date_jour, @numpiece, @idtypejournal, @idexercice)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date_jour", date_jour);
                cmd.Parameters.AddWithValue("@numpiece", numpiece);
                cmd.Parameters.AddWithValue("@idtypejournal", idtypejournal);
                cmd.Parameters.AddWithValue("@idexercice", idexercice);
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
            return id;
        }
        public void CrediterCompte(int idoperation, string comptecredit, double mcredit, string libelle)
        {
            //Montant crédit
            id = NouveauID("operationcompte");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into OperationCompte values (@id, @idoperation, @numcompte, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idoperation", idoperation);
                cmd.Parameters.AddWithValue("@numcompte", comptecredit);
                cmd.Parameters.AddWithValue("@mdebit", 0);
                cmd.Parameters.AddWithValue("@mcredit", mcredit);
                cmd.Parameters.AddWithValue("@libelle", libelle);
                cmd.Parameters.AddWithValue("@soldeouvdebit", 0);
                cmd.Parameters.AddWithValue("@soldeouvcredit", 0);
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
        public void DebiterCompte(int idoperation, string comptedebit, double mdebit, string libelle)
        {
            //Montant débit
            id = NouveauID("operationcompte");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into OperationCompte values(@id, @idoperation, @numcompte, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idoperation", idoperation);
                cmd.Parameters.AddWithValue("@numcompte", comptedebit);
                cmd.Parameters.AddWithValue("@mdebit", mdebit);
                cmd.Parameters.AddWithValue("@mcredit", 0);
                cmd.Parameters.AddWithValue("@libelle", libelle);
                cmd.Parameters.AddWithValue("@soldeouvdebit", 0);
                cmd.Parameters.AddWithValue("@soldeouvcredit", 0);
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
        public void AjouterEcriture(int idoperation, string comptedebit, string comptecredit, double mdebit, double mcredit, string libelle)
        {
            //Montant débit
            DebiterCompte(idoperation, comptedebit, mdebit, libelle);
            //Montant crédit
            CrediterCompte(idoperation, comptecredit, mcredit, libelle);
        }
        public void InitialiserCompteExercice()
        {
            
        }
        public void Enregistrer(FormComptabilite c)
        {
            if (c.dgvEcriture.RowCount != 0)
            {
                c.idoperation = AjouterOperation(c.lblDateOperation.Text, c.txtNumPiece.Text, c.idtypejournal, c.idexercice);
                if (c.cboDebitCredit.Text == "Crédit")
                {
                    for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                    {
                        DebiterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[2].Value), c.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    }
                    CrediterCompte(c.idoperation, c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value), c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());
                    Annuler(c);
                }
                else if (c.cboDebitCredit.Text == "Débit")
                {
                    for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                    {
                        CrediterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[3].Value), c.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    }
                    DebiterCompte(c.idoperation, c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value), c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());
                    Annuler(c);
                }
            }
            else MessageBox.Show("Aucune ligne d'écriture n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SoldesCaisse(Label lblCDF, Label lblUSD, string motif)
        {
            
            if(motif== "recette")
            {
                //solde actuel CDF
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                FROM OperationCompte op
                JOIN Operation o ON o.idoperation= op.idoperation
                WHERE op.numcompte = @numcompte AND date_operation = @date_jour";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", "571101");
                    cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[0].ToString() != "")
                        lblCDF.Text = string.Format("{0} CDF", Convert.ToDouble(dr[0].ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                //solde actuel USD
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                FROM OperationCompte op
                JOIN Operation o ON o.idoperation= op.idoperation
                WHERE op.numcompte = @numcompte AND date_operation = @date_jour";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", "571201");
                    cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[0].ToString() != "")
                        lblUSD.Text = string.Format("{0} USD", Convert.ToDouble(dr[0].ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
            {
                //solde actuel CDF
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                    FROM OperationCompte op
                    JOIN Operation o ON o.idoperation= op.idoperation
                    WHERE op.numcompte = @numcompte AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", "571102");
                    cmd.Parameters.AddWithValue("@dateDe", "01/01/" + DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToShortDateString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[0].ToString() != "")
                        lblCDF.Text = string.Format("{0} CDF", Convert.ToDouble(dr[0].ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                //solde actuel USD
                con.Open();
                try
                {
                    cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                    FROM OperationCompte op
                    JOIN Operation o ON o.idoperation= op.idoperation
                    WHERE op.numcompte = @numcompte AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@numcompte", "571202");
                    cmd.Parameters.AddWithValue("@dateDe", "01/01/" + DateTime.Now.Year);
                    cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToShortDateString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr[0].ToString() != "")
                        lblUSD.Text = string.Format("{0} USD", Convert.ToDouble(dr[0].ToString()));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            
        }
        
        //Faire que le solde se calcule par exercice comptable trouvé en cours dans le système
        //au lieu deux dates prises dans SoldeCompte()
        public double SoldeCompte(string numcompte)
        {
            valeur = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                FROM OperationCompte op
                JOIN Operation o ON o.idoperation= op.idoperation
                JOIN Exercice e ON o.idexercice = e.idexercice
                WHERE op.numcompte = @numcompte AND e.statut IS NULL";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    if (dr[0].ToString() != "")
                        valeur = Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return valeur;
        }
        public void ChargerCompte(FormFacture c, string motif)
        {            
            con.Open();
            try
			{
                if (motif == "recherche")
                    cmd = new SqlCommand("select numcompte, libellecompte from Compte where libellecompte LIKE '%" + c.txtRecherche.Text + "' OR LIKE '" + c.txtRecherche.Text + "%' OR LIKE '%" + c.txtRecherche.Text + "%'", con);
                else
                    cmd = new SqlCommand("select numcompte, libellecompte from Compte", con);
                dr = cmd.ExecuteReader();
                c.dgv.Rows.Clear();
                while (dr.Read())
                {
                    c.dgv.Rows.Add();
                    c.dgv.Rows[c.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgv.Rows[c.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgv.Rows[c.dgv.RowCount - 1].Cells[2].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if(c.dgv.RowCount != 0)
            {
                c.ShowDialog();
                if (c.fermeture_succes)
                {

                }
            }
        }
        public string CompteTypeJournal(int idtypejournal)
        {
            chaine = "";
            con.Open();
            try
            {
                cmd = new SqlCommand("select compte from TypeJournal where idtypejournal= @id", con);
                cmd.Parameters.AddWithValue("@id", idtypejournal);
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
        public void ValiderEcriture(FormComptabilite c)
        {
            if (c.txtCompte1.Text != c.txtCompte2.Text)
            {
                if (c.dgvEcriture.RowCount != 0)
                {
                    c.dgvEcriture.Rows.RemoveAt(c.dgvEcriture.RowCount - 1);

                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompte2.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = c.txtMotif.Text;
                    if (c.cboMonnaie.Text == "CDF")
                    {
                        if (c.cboDebitCredit.Text == "Crédit")
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = c.txtMontant.Text;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = c.txtMontant.Text;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        }
                    }
                    else
                    {
                        if (c.cboDebitCredit.Text == "Crédit")
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = Convert.ToDouble(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = Convert.ToDouble(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        }
                    }
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompte1.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = "";
                    for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                    {
                        if (c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value == "")
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = c.dgvEcriture.Rows[i].Cells[1].Value.ToString();
                        else
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}", c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value.ToString(), c.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    }
                    if (c.cboDebitCredit.Text == "Crédit")
                    {
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        ContrePartie(c.dgvEcriture, 2, 3);
                    }
                    else
                    {
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        ContrePartie(c.dgvEcriture, 3, 2);
                    }
                }
                else
                {
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompte2.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = c.txtMotif.Text;
                    if (c.cboMonnaie.Text == "CDF")
                    {
                        if (c.cboDebitCredit.Text == "Crédit")
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = c.txtMontant.Text;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = c.txtMontant.Text;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        }
                    }
                    else
                    {
                        if (c.cboDebitCredit.Text == "Crédit")
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = Convert.ToDouble(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = Convert.ToDouble(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        }
                    }
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompte1.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 2].Cells[1].Value.ToString();
                    if (c.cboDebitCredit.Text == "Crédit")
                    {
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = "0";
                        ContrePartie(c.dgvEcriture, 2, 3);
                    }
                    else
                    {                        
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        ContrePartie(c.dgvEcriture, 3, 2);
                    }       
                }
                AnnulerApresValid(c);
            }
            else
                MessageBox.Show("Le même numéro compte est au débit et au crédit", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void AnnulerApresValid(FormComptabilite c)
        {
            c.txtCompte2.Clear();
            c.txtMontant.Clear();
            c.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboMonnaie.SelectedText = "";
            c.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtMotif.Clear();
        }
        public void Afficher(FormComptaOperation c)
        {           
            c.sommeCredit = 0; c.sommeDebit = 0;

            con.Open();
            try
            {
                if (c.cboTypeJournal.Text != "")
                {
                    cmdtxt = @"SELECT o.idoperation, date_operation, numpiece, libelle, numcompte, montantdebit, montantcredit 
                    FROM Operation o
                    JOIN OperationCompte oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@typejournal", c.idtypejournal);
                }
                else
                {
                    cmdtxt = @"SELECT o.idoperation, date_operation, numpiece, libelle, numcompte, montantdebit, montantcredit 
                    FROM Operation o
                    JOIN OperationCompte oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                c.dgvOperation.Rows.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.dgvOperation.Rows.Add();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    if (dr[5].ToString() != "")
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    else
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = "0";
                    if (dr[6].ToString() != "")
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = dr[6].ToString();
                    else
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = "0";
                    c.sommeDebit += double.Parse(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value.ToString());
                    c.sommeCredit += double.Parse(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value.ToString());
                }
                if (c.dgvOperation.RowCount != 0)
                {
                    c.dgvOperation.Rows.Add();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "Totaux";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = c.sommeDebit;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = c.sommeCredit;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AjouterSolde(FormComptaOperation c)
        {
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "";
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "Solde";
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = "";
            if (c.sommeDebit > c.sommeCredit)
            {
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = c.sommeDebit - c.sommeCredit;
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = "";
            }
            else if (c.sommeDebit < c.sommeCredit)
            {
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = "";
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = c.sommeCredit - c.sommeDebit;
            }
            else
            {
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = "0";
                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = "0";
            }
            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            c.sommeCredit = 0; c.sommeDebit = 0;
        }
        public void ChargerCompte(FormComptaGdLivre c)
        {
            if (c.txtRecherche.Text == "")
            {
                cmdtxt = @"SELECT c.numcompte, libellecompte, soldeouvedebit, soldeouvecredit  
                FROM Compte c
                JOIN OperationCompte o ON c.numcompte = o.numcompte
                JOIN Operation op ON o.idoperation = op.idoperation
                WHERE idexercice = @idexercice AND categorie IN ('U', 'UU') AND montantdebit = 0 AND montantcredit = 0";
            }
            else
                cmdtxt = @"SELECT c.numcompte, libellecompte, soldeouvedebit, soldeouvecredit
                FROM Compte c
                JOIN OperationCompte o ON c.numcompte = o.numcompte
                JOIN Operation op ON o.idoperation = op.idoperation
                WHERE idexercice = @idexercice AND categorie IN ('U', 'UU') AND montantdebit = 0 AND montantcredit = 0 AND libellecompte LIKE '" + c.txtRecherche.Text.Replace("'", "") + "%'";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                c.dgvCompte.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvCompte.Rows.Add();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    if (dr[2].ToString().ToString() != "")
                        c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    else
                        c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[2].Value = 0;
                    if (dr[3].ToString().ToString() != "")
                        c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    else
                        c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[3].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherMouvement(FormComptaGdLivre c, string numcompte)
        {
            if (c.dtpDateDe.Value.Year == c.dtpDateA.Value.Year && c.dtpDateDe.Value.Date <= c.dtpDateA.Value.Date)
            {
                if (numcompte != "")
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT o2.idoperation, date_operation, numpiece, libelle, montantdebit, montantcredit 
                        FROM Operation o1 
                        JOIN OperationCompte o2 ON o1.idoperation = o2.idoperation 
                        WHERE idexercice = @idexercice AND numcompte = @numcompte AND montantdebit != 0 AND date_operation BETWEEN @dateDe AND @dateA 
                        OR idexercice = @idexercice AND numcompte = @numcompte AND montantcredit != 0 AND date_operation BETWEEN @dateDe AND @dateA";
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@numcompte", c.dgvCompte.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                        dr = cmd.ExecuteReader();
                        c.dgvOperation.Rows.Clear();
                        c.dgvOperation.Rows.Add();
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Solde" + c.dgvCompte.CurrentRow.Cells[0].Value.ToString();
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[2].Value);
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[3].Value);
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[2].Value) - Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[3].Value);
                        
                        while (dr.Read())
                        {
                            c.dgvOperation.Rows.Add();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = dr[3].ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = dr[4].ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = dr[5].ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value =
                                Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 2].Cells[6].Value) +
                                Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value) -
                                Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value);
                        }
                        //Totaux
                        c.dgvOperation.Rows.Add();
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Totaux";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = 0;
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = 0;
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = c.dgvOperation.Rows[c.dgvOperation.RowCount - 2].Cells[6].Value;
                        for (int i = 0; i < c.dgvOperation.RowCount - 1; i++)
                        {
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value) + Convert.ToDouble(c.dgvOperation.Rows[i].Cells[4].Value);
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value) + Convert.ToDouble(c.dgvOperation.Rows[i].Cells[5].Value);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                {
                    c.dgvOperation.Rows.Clear();
                    for (int i = 0; i < c.dgvCompte.RowCount; i++)
                    {
                        con.Open();
                        try
                        {
                            cmdtxt = @"SELECT o2.idoperation, date_operation, numpiece, libelle, montantdebit, montantcredit 
                        FROM Operation o1 
                        JOIN OperationCompte o2 ON o1.idoperation = o2.idoperation 
                        WHERE idexercice = @idexercice AND numcompte = @numcompte AND montantdebit != 0 AND date_operation BETWEEN @dateDe AND @dateA 
                        OR idexercice = @idexercice AND numcompte = @numcompte AND montantcredit != 0 AND date_operation BETWEEN @dateDe AND @dateA";
                            cmd = new SqlCommand(cmdtxt, con);
                            cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                            cmd.Parameters.AddWithValue("@numcompte", c.dgvCompte.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                            dr = cmd.ExecuteReader();

                            c.dgvOperation.Rows.Add();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Solde : " + c.dgvCompte.Rows[i].Cells[0].Value.ToString();
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = Convert.ToDouble(c.dgvCompte.Rows[i].Cells[2].Value);
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = Convert.ToDouble(c.dgvCompte.Rows[i].Cells[3].Value);
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = Convert.ToDouble(c.dgvCompte.Rows[i].Cells[2].Value) - Convert.ToDouble(c.dgvCompte.Rows[i].Cells[3].Value);

                            while (dr.Read())
                            {
                                c.dgvOperation.Rows.Add();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = dr[2].ToString();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = dr[3].ToString();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = dr[4].ToString();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = dr[5].ToString();
                                c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value =
                                    Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 2].Cells[6].Value) +
                                    Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value) -
                                    Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    //Totaux
                    c.dgvOperation.Rows.Add();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Toaux";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = 0;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = 0;

                    for (int i = 0; i < c.dgvOperation.RowCount - 1; i++)
                    {
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value) + Convert.ToDouble(c.dgvOperation.Rows[i].Cells[4].Value);
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value) + Convert.ToDouble(c.dgvOperation.Rows[i].Cells[5].Value);
                    }
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value) - Convert.ToDouble(c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value);
                }
            }
            else
                MessageBox.Show("La première date doit être inférieure ou égale à la deuxième et l'année doit être la même", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AfficherOuverture()
        {
            cmdtxt = @"SELECT oc.numcompte, libellecompte, montantdebit, montantcredit, libelle, soldeouvedebit, soldeouvecredit
            FROM OperationCompte oc
            JOIN Compte c ON c.numcompte = oc.numcompte
            JOIN Operation o ON o.idoperation = oc.idoperation
            WHERE idexercice = 1 AND libelle = 'Ouverture exercice'";
        }
        #endregion

        #region APPRO_STOCK
        public void ChargerFournisseur(ComboBox cbo)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT libellecompte FROM Compte WHERE numcompte LIKE '40110%' AND categorie = 'U' AND numcompte != '401100'", con);
                dr = cmd.ExecuteReader();
                cbo.Items.Clear();
                while (dr.Read())
                {
                    cbo.Items.Add(dr[0].ToString());
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
                if(motif == "appro") 
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

        public void ApprovisionnerStock(FormApproCommande a, FormApprov ap)
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
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[10].Value = cs.PrixStock(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[6].Value), "vente");
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
                            ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[10].Value = cs.PrixStock(Convert.ToInt32(a.dgvCommande.Rows[i].Cells[6].Value), "vente");
                        }
                    }
                }
                if (ap.dgvAppro.RowCount != 0)
                {
                    //Ligne total
                    ap.dgvAppro.Rows.Add();
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[0].Value = "";
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[1].Value = "Total appro.";
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                    ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].ReadOnly = true;



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
                        ap.cboFournisseur.Enabled = false;
                        ap.cboMonnaie.Enabled = false;
                        ap.btnNewFournisseur.Enabled = false;
                        ap.dgvAppro.Columns[2].Visible = false;
                        ap.dgvAppro.Columns[3].Visible = false;
                        for (int i = 7; i < ap.dgvAppro.ColumnCount; i++)
                        {
                            ap.dgvAppro.Columns[i].Visible = false;
                        }
                        ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Visible = false;
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
        public void CalculLigne(FormApprov a)
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
                else if(i >= 6 && i < 9)
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
        public void Approvisionner(FormApprov ap)
        {
            for (int i = ap.dgvAppro.RowCount - 1; i >= 0; i--)
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
                    if (i < ap.dgvAppro.RowCount - 1 && Convert.ToInt32(ap.dgvAppro.Rows[i].Cells[6].Value) == 0)
                    {
                        ap.dgvAppro.Rows.RemoveAt(ap.dgvAppro.Rows[i].Index);
                    }
                }
            }                     
            if(ap.dgvAppro.RowCount != 0)
            {
                //journal caisse dépenses 30==>40, 60==>63
                if (ap.poste == "comptable")
                {
                    ap.lotvalide = true;
                    for (int i = 0; i < ap.dgvAppro.RowCount - 1; i++)
                    {
                        if (ap.dgvAppro.Rows[i].Cells[14].Value.ToString() == "OUI")
                        {
                            if (ap.dgvAppro.Rows[i].Cells[2].Value.ToString() == "" || ap.dgvAppro.Rows[i].Cells[3].Value.ToString() == "")
                                ap.lotvalide = false;
                        }                        
                    }
                    if (ap.lotvalide)
                    {
                        ap.idoperation = AjouterOperation(ap.dtpDateJour.Text, "BON_LIV", TrouverId("typejournal", "achats"), ap.idexercice);
                        if (ap.cboMonnaie.Text == "CDF")
                        {
                            valeur = Convert.ToDouble(ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value);
                            AjouterEcriture(ap.idoperation, "311100", ap.compteFournis, valeur, valeur, "Appro stock");
                            AjouterEcriture(ap.idoperation, "601101", "603101", valeur, valeur, "Appro stock");
                        }
                        else
                        {
                            valeur = Convert.ToDouble(ap.dgvAppro.Rows[ap.dgvAppro.RowCount - 1].Cells[11].Value) * ap.taux;
                            AjouterEcriture(ap.idoperation, "311100", ap.compteFournis, valeur, valeur, "Appro stock");
                            AjouterEcriture(ap.idoperation, "601101", "603101", valeur, valeur, "Appro stock");
                        }
                        cs.EnregistrerAppro(ap);
                        cs.MiseAJourLigneStock(ap);                 
                    }
                    else
                        MessageBox.Show("Fournissez le numéro lot et la date d'expiration pour tout produit expirable", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cs.EnregistrerAppro(ap);
                    cs.MiseAJourLigneStock(ap);
                }
            }
        }
        #endregion
        
        ReportDataSource rs2 = new ReportDataSource();
        #region CHARGEMENT_PANELS
        public void SousMenu(Panel pnl)
        {
            if (pnl.Visible)
                pnl.Visible = false;
            else
                pnl.Visible = true;
        }
        #endregion
        
        #region BILAN

        private void AutresCreances(FormComptaBilan c, string motif)
        {
            int[] compte_creance;
            if (motif == "actif")
            {
                compte_creance = new int[] { 185, 42, 43, 44, 45, 46, 47 };
                for (int i = 0; i < compte_creance.Length; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '"+compte_creance[i]+@"%' 
                        AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) >= 0)
                                {
                                    c.dgvActif.Rows[21].Cells[4].Value = Convert.ToDouble(c.dgvActif.Rows[21].Cells[4].Value) + Convert.ToDouble(dr[0].ToString());
                                    c.dgvActif.Rows[21].Cells[7].Value = Convert.ToDouble(c.dgvActif.Rows[21].Cells[7].Value) + Convert.ToDouble(dr[1].ToString());
                                }
                            }                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else if (motif == "passif1")
            {
                compte_creance = new int[] { 42, 43, 44 };
                for (int i = 0; i < compte_creance.Length; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_creance[i] + @"%' 
                        AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) < 0)
                                {
                                    c.dgvPassif.Rows[19].Cells[3].Value = Convert.ToDouble(c.dgvPassif.Rows[19].Cells[3].Value) - Convert.ToDouble(dr[0].ToString());
                                    c.dgvPassif.Rows[19].Cells[4].Value = Convert.ToDouble(c.dgvPassif.Rows[19].Cells[4].Value) - Convert.ToDouble(dr[1].ToString());
                                }
                            }                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            else
            {
                compte_creance = new int[] { 185, 45, 46, 47 };
                for (int i = 0; i < compte_creance.Length; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_creance[i] + @"%' 
                        AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) < 0)
                                {
                                    c.dgvPassif.Rows[20].Cells[3].Value = Convert.ToDouble(c.dgvPassif.Rows[20].Cells[3].Value) - Convert.ToDouble(dr[0].ToString());
                                    c.dgvPassif.Rows[20].Cells[4].Value = Convert.ToDouble(c.dgvPassif.Rows[20].Cells[4].Value) - Convert.ToDouble(dr[1].ToString());
                                }
                            }                           
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
        private void TresorerieBilan(FormComptaBilan c, string motif)
        {
            int[] compte_treso;
            if (motif == "actif")
            {
                compte_treso = new int[] { 52, 53, 54, 55, 57, 581, 582 };
                for (int i = 0; i < compte_treso.Length; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                        AND categorie = 'U' AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) >= 0)
                                {
                                    c.dgvActif.Rows[25].Cells[4].Value = Convert.ToDouble(c.dgvActif.Rows[25].Cells[4].Value) + Convert.ToDouble(dr[0].ToString());
                                    c.dgvActif.Rows[25].Cells[7].Value = Convert.ToDouble(c.dgvActif.Rows[25].Cells[7].Value) + Convert.ToDouble(dr[1].ToString());
                                }
                            }                           
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    if(compte_treso[i]==52 || compte_treso[i]==57)
                    {
                        con.Open();
                        try
                        {
                            cmdtxt = @"SELECT 
                            ((SUM(montantdebit)-SUM(montantcredit)) +
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit))) * MAX(taux) AS SoldeActuel,
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit)) * MAX(taux) AS SoldePasse
                            FROM OperationCompte oc 
                            JOIN Operation o ON oc.idoperation = o.idoperation
                            JOIN Compte c ON oc.numcompte = c.numcompte
                            JOIN Date_operation d ON d.date_operation = o.date_operation
                            WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                            AND categorie = 'UU' AND o.date_operation BETWEEN @dateDe AND @dateA";


                            cmd = new SqlCommand(cmdtxt, con);
                            cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr[0].ToString() != "")
                                {
                                    if (Convert.ToDouble(dr[0].ToString()) >= 0)
                                    {
                                        c.dgvActif.Rows[25].Cells[4].Value = Convert.ToDouble(c.dgvActif.Rows[25].Cells[4].Value) + Convert.ToDouble(dr[0].ToString());
                                        c.dgvActif.Rows[25].Cells[7].Value = Convert.ToDouble(c.dgvActif.Rows[25].Cells[7].Value) + Convert.ToDouble(dr[1].ToString());
                                    }
                                }
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
            else
            {
                compte_treso = new int[] { 52, 53, 561, 566 };
                for (int i = 0; i < compte_treso.Length; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                        AND categorie = 'U' AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) < 0)
                                {
                                    c.dgvPassif.Rows[24].Cells[3].Value = Convert.ToDouble(c.dgvPassif.Rows[24].Cells[3].Value) - Convert.ToDouble(dr[0].ToString());
                                    c.dgvPassif.Rows[24].Cells[4].Value = Convert.ToDouble(c.dgvPassif.Rows[24].Cells[4].Value) - Convert.ToDouble(dr[1].ToString());
                                }
                            }                            
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();

                    if (compte_treso[i] == 52)
                    {
                        con.Open();
                        try
                        {
                            cmdtxt = @"SELECT 
                            ((SUM(montantdebit)-SUM(montantcredit)) +
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit))) * MAX(taux) AS SoldeActuel,
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit)) * MAX(taux) AS SoldePasse
                            FROM OperationCompte oc 
                            JOIN Operation o ON oc.idoperation = o.idoperation
                            JOIN Compte c ON oc.numcompte = c.numcompte
                            JOIN Date_operation d ON d.date_operation = o.date_operation
                            WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                            AND categorie = 'UU' AND o.date_operation BETWEEN @dateDe AND @dateA";


                            cmd = new SqlCommand(cmdtxt, con);
                            cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                if (dr[0].ToString() != "")
                                {
                                    if (Convert.ToDouble(dr[0].ToString()) < 0)
                                    {
                                        c.dgvPassif.Rows[24].Cells[3].Value = Convert.ToDouble(c.dgvPassif.Rows[24].Cells[3].Value) - Convert.ToDouble(dr[0].ToString());
                                        c.dgvPassif.Rows[24].Cells[4].Value = Convert.ToDouble(c.dgvPassif.Rows[24].Cells[4].Value) - Convert.ToDouble(dr[1].ToString());
                                    }
                                }
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
        }
        private void AfficherActif(FormComptaBilan c)
        {
            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == "BJ")
                    AutresCreances(c, "actif");
                else if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == "BS")
                    TresorerieBilan(c, "actif");
                else
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@ref", c.dgvActif.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                c.dgvActif.Rows[i].Cells[4].Value = Convert.ToDouble(dr[0].ToString());
                                c.dgvActif.Rows[i].Cells[7].Value = Convert.ToDouble(dr[1].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }               
            }

            //Amortissement
            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT 
                    ((SUM(montantcredit)-SUM(montantdebit)) +
                    (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS Solde 
                    FROM OperationCompte oc 
                    JOIN Operation o ON oc.idoperation = o.idoperation
                    JOIN Compte c ON oc.numcompte = c.numcompte
                    WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                    GROUP BY ref";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", c.dgvActif.Rows[i].Cells[0].Value.ToString()+"_");
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                            c.dgvActif.Rows[i].Cells[5].Value = Convert.ToDouble(dr[0].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                //Calcul du net
                c.dgvActif.Rows[i].Cells[6].Value = Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value) - Convert.ToDouble(c.dgvActif.Rows[i].Cells[5].Value);
            }

            CalculerTotalBilan(c.dgvActif, 4);
        }
        private void AfficherPassif(FormComptaBilan c)
        {
            for (int i = 0; i < c.dgvPassif.RowCount; i++)
            {
                if (c.dgvPassif.Rows[i].Cells[0].Value.ToString() == "DK")
                    AutresCreances(c, "passif1");
                else if (c.dgvPassif.Rows[i].Cells[0].Value.ToString() == "DM")
                    AutresCreances(c, "passif2");
                else if (c.dgvPassif.Rows[i].Cells[0].Value.ToString() == "DR")
                    TresorerieBilan(c, "passif");
                else
                {
                    con.Open();
                    try
                    {                      
                        cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@ref", c.dgvPassif.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                c.dgvPassif.Rows[i].Cells[3].Value = Convert.ToDouble(dr[0].ToString());
                                c.dgvPassif.Rows[i].Cells[4].Value = Convert.ToDouble(dr[1].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }                
            }
            CalculerTotalBilan(c.dgvPassif, 3);
            //resultat
            c.dgvPassif.Rows[7].Cells[3].Value = Convert.ToDouble(c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[6].Value) - Convert.ToDouble(c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[3].Value);
            CalculerTotalBilan(c.dgvPassif, 3);
        }
        public void AfficherBilan(FormComptaBilan c)
        {
            AfficherActif(c);
            AfficherPassif(c);
            CalculerSousTotauxBilan(c);
        }
        private void RubriquesActif(FormComptaBilan c)
        {
            c.dgvActif.Rows.Clear();
            c.dgvActif.Rows.Add(c.cboActif.Items.Count);
            for (int i = 0; i < c.cboActif.Items.Count; i++)
            {
                chaine = "";
                c.dgvActif.Rows[0].Selected = false;
                chaine = c.cboActif.Items[i].ToString();
                c.dgvActif.Rows[i].Cells[0].Value = chaine.Substring(0, 2);
                chaine = chaine.Substring(3);
                if (chaine.Contains("_"))
                {
                    c.dgvActif.Rows[i].Cells[1].Value = chaine.Substring(0, chaine.IndexOf("_"));
                    chaine = chaine.Substring(chaine.IndexOf("_") + 1);
                    c.dgvActif.Rows[i].Cells[2].Value = "";
                    c.dgvActif.Rows[i].Cells[3].Value = chaine;
                }
                else
                {
                    c.dgvActif.Rows[i].Cells[1].Value = chaine;
                    c.dgvActif.Rows[i].Cells[2].Value = "";
                    c.dgvActif.Rows[i].Cells[3].Value = "";
                }
                
                c.dgvActif.Rows[i].Cells[4].Value = 0;
                c.dgvActif.Rows[i].Cells[5].Value = 0;
                c.dgvActif.Rows[i].Cells[6].Value = 0;
                c.dgvActif.Rows[i].Cells[7].Value = 0;
            }
            c.dgvActif.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[5].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[5].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[12].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[12].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[15].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[15].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[22].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[22].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[26].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[26].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[28].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvActif.Rows[28].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
        }
        private void RubriquesPassif(FormComptaBilan c)
        {
            c.dgvPassif.Rows.Clear();
            c.dgvPassif.Rows.Add(c.cboPassif.Items.Count);
            for (int i = 0; i < c.cboPassif.Items.Count; i++)
            {
                chaine = "";
                c.dgvPassif.Rows[0].Selected = false;
                chaine = c.cboPassif.Items[i].ToString();
                c.dgvPassif.Rows[i].Cells[0].Value = chaine.Substring(0, 2);
                chaine = chaine.Substring(3);
                if (chaine.Contains("_"))
                {
                    c.dgvPassif.Rows[i].Cells[1].Value = chaine.Substring(0, chaine.IndexOf("_"));
                    chaine = chaine.Substring(chaine.IndexOf("_") + 1);
                    c.dgvPassif.Rows[i].Cells[2].Value = chaine;
                }
                else
                {
                    c.dgvPassif.Rows[i].Cells[1].Value = chaine;
                    c.dgvPassif.Rows[i].Cells[2].Value = "";
                }
                c.dgvPassif.Rows[i].Cells[3].Value = 0;
                c.dgvPassif.Rows[i].Cells[4].Value = 0;
            }
            c.dgvPassif.Rows[10].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[10].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[14].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[14].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[15].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[15].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[22].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[22].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[25].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[25].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[27].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvPassif.Rows[27].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
        }
        public void Rubriques(FormComptaBilan c)
        {
            RubriquesActif(c);
            RubriquesPassif(c);
        }
        private void CalculerTotalBilan(DataGridView dgv, int col_debut)
        {
            for (int i = col_debut; i < dgv.ColumnCount; i++)
            {
                valeur = 0;
                for (int j = 0; j < dgv.RowCount-1; j++)
                {
                    valeur += double.Parse(dgv.Rows[j].Cells[i].Value.ToString());
                }
                dgv.Rows[dgv.RowCount - 1].Cells[i].Value = valeur;
            }            
        }
        private void CalculerSousTotauxBilan(FormComptaBilan c)
        {
            //total actif immobilisé
            for (int i = 4; i < 8; i++)
            {
                c.dgvActif.Rows[15].Cells[i].Value = 0;
                for (int j = 0; j < 15; j++)
                {
                    c.dgvActif.Rows[15].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[15].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }
            //total actif circulant
            for (int i = 4; i < 8; i++)
            {
                c.dgvActif.Rows[22].Cells[i].Value = 0;
                for (int j = 16; j < 22; j++)
                {
                    c.dgvActif.Rows[22].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[22].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }
            //total tresorerie actif
            for (int i = 4; i < 8; i++)
            {
                c.dgvActif.Rows[26].Cells[i].Value = 0;
                for (int j = 23; j < 26; j++)
                {
                    c.dgvActif.Rows[26].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[26].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }

            //total capitaux propres et res. assmilées
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[10].Cells[i].Value = 0;
                for (int j = 0; j < 10; j++)
                {
                    c.dgvPassif.Rows[10].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[10].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            //total dettes fin. et res. assmilées 
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[14].Cells[i].Value = 0;
                for (int j = 11; j < 14; j++)
                {
                    c.dgvPassif.Rows[14].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[14].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            
            //total ressources stables
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[15].Cells[i].Value = 0;
                c.dgvPassif.Rows[15].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[10].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[14].Cells[i].Value);
            }
            //total passif circulant
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[22].Cells[i].Value = 0;
                for (int j = 16; j < 22; j++)
                {
                    c.dgvPassif.Rows[22].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[22].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            //total tresorerie passif
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[25].Cells[i].Value = 0;
                for (int j = 23; j < 25; j++)
                {
                    c.dgvPassif.Rows[25].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[25].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
        }
        public void ImprimerActif(FormComptaBilan c, FormImpression imp)
        {
            imp.Text = "SSM - Actif du Bilan";
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("debutperiode", c.dtpDateDe.Text),
                new ReportParameter("finperiode", c.dtpDateA.Text),
                new ReportParameter("exepasse", (c.dtpDateA.Value.Year-1).ToString())
            };
            List<Bilan_Actif> list = new List<Bilan_Actif>();
            list.Clear();

            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                Bilan_Actif actif = new Bilan_Actif
                {
                    refActif = c.dgvActif.Rows[i].Cells[0].Value.ToString(),
                    rubriqueActif = c.dgvActif.Rows[i].Cells[1].Value.ToString(),
                    placement = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                    noteActif = c.dgvActif.Rows[i].Cells[3].Value.ToString(),
                    brut = Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value),
                    amortDeprec = Convert.ToDouble(c.dgvActif.Rows[i].Cells[5].Value),
                    net = Convert.ToDouble(c.dgvActif.Rows[i].Cells[6].Value),
                    exercicepasse = Convert.ToDouble(c.dgvActif.Rows[i].Cells[7].Value)
                };
                list.Add(actif);
            }
            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BilanActif.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
        }
        public void ImprimerPassif(FormComptaBilan c, FormImpression imp)
        {
            imp.Text = "SSM - Passif du Bilan";
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("debutperiode", c.dtpDateDe.Text),
                new ReportParameter("finperiode", c.dtpDateA.Text),
                new ReportParameter("exepasse", (c.dtpDateA.Value.Year-1).ToString())
            };
            List<Bilan_Passif> list = new List<Bilan_Passif>();
            list.Clear();

            for (int i = 0; i < c.dgvPassif.RowCount; i++)
            {
                Bilan_Passif passif = new Bilan_Passif
                {
                    refPassif = c.dgvPassif.Rows[i].Cells[0].Value.ToString(),
                    rubriquePassif = c.dgvPassif.Rows[i].Cells[1].Value.ToString(),
                    notePassif = c.dgvPassif.Rows[i].Cells[2].Value.ToString(),
                    netEncours = Convert.ToDouble(c.dgvPassif.Rows[i].Cells[3].Value),
                    netPasse = Convert.ToDouble(c.dgvPassif.Rows[i].Cells[4].Value)
                };
                list.Add(passif);
            }
            rs.Name = "DataSet3";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BilanPassif.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
        }
        public void ImprimerToutBilan(FormComptaBilan c, FormImpression imp)
        {
            imp.Text = "SSM - Actif et Passif du Bilan";
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("debutperiode", c.dtpDateDe.Text),
                new ReportParameter("finperiode", c.dtpDateA.Text),
                new ReportParameter("exepasse", (c.dtpDateA.Value.Year-1).ToString())
            };

            List<Bilan_Tout> list = new List<Bilan_Tout>();
            list.Clear();

            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                if(i==0)
                {
                    Bilan_Tout bilan = new Bilan_Tout
                    {
                        refActif = c.dgvActif.Rows[i].Cells[0].Value.ToString(),
                        rubriqueActif = c.dgvActif.Rows[i].Cells[1].Value.ToString(),
                        placement = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                        noteActif = c.dgvActif.Rows[i].Cells[3].Value.ToString(),
                        brut = Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value),
                        amortDeprec = Convert.ToDouble(c.dgvActif.Rows[i].Cells[5].Value),
                        net = Convert.ToDouble(c.dgvActif.Rows[i].Cells[6].Value),
                        exercicepasse = Convert.ToDouble(c.dgvActif.Rows[i].Cells[7].Value),
                        refPassif = "",
                        rubriquePassif = "",
                        notePassif = "",
                        netEncours = Convert.ToDouble(0),
                        netPasse = Convert.ToDouble(0)
                    };
                    list.Add(bilan);
                }
                else
                {
                    Bilan_Tout bilan = new Bilan_Tout
                    {
                        refActif = c.dgvActif.Rows[i].Cells[0].Value.ToString(),
                        rubriqueActif = c.dgvActif.Rows[i].Cells[1].Value.ToString(),
                        placement = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                        noteActif = c.dgvActif.Rows[i].Cells[3].Value.ToString(),
                        brut = Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value),
                        amortDeprec = Convert.ToDouble(c.dgvActif.Rows[i].Cells[5].Value),
                        net = Convert.ToDouble(c.dgvActif.Rows[i].Cells[6].Value),
                        exercicepasse = Convert.ToDouble(c.dgvActif.Rows[i].Cells[7].Value),
                        refPassif = c.dgvPassif.Rows[i-1].Cells[0].Value.ToString(),
                        rubriquePassif = c.dgvPassif.Rows[i-1].Cells[1].Value.ToString(),
                        notePassif = c.dgvPassif.Rows[i-1].Cells[2].Value.ToString(),
                        netEncours = Convert.ToDouble(c.dgvPassif.Rows[i-1].Cells[3].Value),
                        netPasse = Convert.ToDouble(c.dgvPassif.Rows[i-1].Cells[4].Value)
                    };
                    list.Add(bilan);
                }                              
            }
            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.Bilan.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
        }
        public void ImprimerBilan(FormComptaBilan c)
        {
            if (c.cboBilan.Text != "")
            {
                if (c.cboBilan.Text == "Actif")
                    ImprimerActif(c, new FormImpression());
                else if (c.cboBilan.Text == "Passif")
                    ImprimerPassif(c, new FormImpression());
                else
                    ImprimerToutBilan(c, new FormImpression());
            }
            else
            {
                MessageBox.Show("Sélectionnez ce que vous voulez visualiser dans la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                c.cboBilan.Select();
            }
            c.btnImprimer.Enabled = false;
        }
        #endregion

        #region GRAND LIVRE
        public void ImprimerGdLivre(FormComptaGdLivre c, FormImpression imp)
        {
            imp.Text = "SSM - Grand Livre";
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("debutperiode", c.dtpDateDe.Text),
                new ReportParameter("finperiode", c.dtpDateA.Text),
                new ReportParameter("concerne", c.concerne)
            };
            List<GrandLivre> list = new List<GrandLivre>();
            list.Clear();

            for (int i = 0; i < c.dgvOperation.RowCount; i++)
            {
                GrandLivre passif = new GrandLivre
                {
                    num = c.dgvOperation.Rows[i].Cells[0].Value.ToString(),
                    date_jour = c.dgvOperation.Rows[i].Cells[1].Value.ToString(),
                    numpiece = c.dgvOperation.Rows[i].Cells[2].Value.ToString(),
                    libelle = c.dgvOperation.Rows[i].Cells[3].Value.ToString(),
                    debit = Convert.ToDouble(c.dgvOperation.Rows[i].Cells[4].Value),
                    credit = Convert.ToDouble(c.dgvOperation.Rows[i].Cells[5].Value),
                    solde = Convert.ToDouble(c.dgvOperation.Rows[i].Cells[6].Value)
                };
                list.Add(passif);
            }
            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.GrandLivre.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
            c.btnImprimerTout.Enabled = false;
            c.btnImprimer.Enabled = false;
        }
        #endregion 

        #region BALANCE
        public void CalculerBalance(FormComptaBalance c)
        {
            con.Open();
            try
            {
               cmdtxt = @"SELECT oc.numcompte, libellecompte, SUM(soldeouvedebit), 
                SUM(soldeouvecredit), SUM(montantdebit), SUM(montantcredit),
                categorie 
                FROM OperationCompte oc
                JOIN Operation o ON oc.idoperation = o.idoperation
                JOIN Compte c ON oc.numcompte = c.numcompte
                WHERE idexercice = @idexercice AND oc.numcompte NOT IN('571101','571201') AND categorie IN ('U','UU') AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY oc.numcompte, libellecompte, categorie";
               cmd = new SqlCommand(cmdtxt, con);
               cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
               cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
               cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
               dr = cmd.ExecuteReader();
               c.dgvBalance.Rows.Clear();
               while (dr.Read())
               {
                   c.dgvBalance.Rows.Add();
                   c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[0].Value = dr[0].ToString();
                   c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = dr[1].ToString();
                   if (dr[6].ToString() == "U")
                   {
                       if (dr[2].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = Convert.ToDouble(dr[2].ToString());
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = 0;
                       if (dr[3].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = Convert.ToDouble(dr[3].ToString());
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = 0;
                       if (dr[4].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = Convert.ToDouble(dr[4].ToString());
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = 0;
                       if (dr[5].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = Convert.ToDouble(dr[5].ToString());
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = 0;
                   }
                   else
                   {
                       if (dr[2].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = Convert.ToDouble(dr[2].ToString()) * c.taux;
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = 0;
                       if (dr[3].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = Convert.ToDouble(dr[3].ToString()) * c.taux;
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = 0;
                       if (dr[4].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = Convert.ToDouble(dr[4].ToString()) * c.taux;
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = 0;
                       if (dr[5].ToString() != "")
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = Convert.ToDouble(dr[5].ToString()) * c.taux;
                       else
                           c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = 0;
                   }
               }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if (c.dgvBalance.RowCount!= 0)
            {
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[0].Value = "";
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = "Totaux bilan";
                
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[0].Value = "";
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = "Totaux comptes gestion";
                              
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[0].Value = "";
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = "Totaux balance";
                
                CalculerTotalBalance(c.dgvBalance);
            }           
        }
        
        double sommeValeur = 0;
        private void CalculerTotalBalance(DataGridView dgv)
        {
            for (int i = 2; i < 6; i++)
            {
                valeur = 0;
                if(i < 4)
                {
                    for (int j = 0; j < dgv.RowCount - 3; j++)
                    {
                        valeur += Convert.ToDouble(dgv.Rows[j].Cells[i].Value);
                    }
                    dgv.Rows[dgv.RowCount - 3].Cells[i].Value = valeur;
                }
                else
                {
                    sommeValeur = 0;
                    for (int j = 0; j < dgv.RowCount - 3; j++)
                    {
                        if(Convert.ToInt16(dgv.Rows[j].Cells[0].Value.ToString().Substring(0,1))<6)
                            valeur += Convert.ToDouble(dgv.Rows[j].Cells[i].Value);
                        else
                            sommeValeur += Convert.ToDouble(dgv.Rows[j].Cells[i].Value);
                    }
                    dgv.Rows[dgv.RowCount - 3].Cells[i].Value = valeur;
                    dgv.Rows[dgv.RowCount - 2].Cells[i].Value = sommeValeur;
                }
            }
            //Solde
            dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dgv.Rows[dgv.RowCount - 3].Cells[2].Value;
            dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dgv.Rows[dgv.RowCount - 3].Cells[3].Value;
            dgv.Rows[dgv.RowCount - 1].Cells[4].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[4].Value) + Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[4].Value);
            dgv.Rows[dgv.RowCount - 1].Cells[5].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[5].Value) + Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[5].Value);
            //Par les comptes bilan
            if (Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[4].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[5].Value) < 0)
                dgv.Rows[dgv.RowCount - 3].Cells[7].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[5].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[4].Value);//solde créditeur
            else
                dgv.Rows[dgv.RowCount - 3].Cells[6].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[4].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 3].Cells[5].Value);//solde débiteur
            //Par les comptes gestion
            if (Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[4].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[5].Value) < 0)
                dgv.Rows[dgv.RowCount - 2].Cells[7].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[5].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[4].Value);//solde créditeur
            else
                dgv.Rows[dgv.RowCount - 2].Cells[6].Value = Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[4].Value) - Convert.ToDouble(dgv.Rows[dgv.RowCount - 2].Cells[5].Value);//solde débiteur
        }
        public void ImprimerBalance(FormComptaBalance c, FormImpression imp)
        {
            if (c.dgvBalance.RowCount != 0)
            {
                imp.Text = "SSM - Balance";
                ReportParameter[] rparams = new ReportParameter[]
                {
                    new ReportParameter("debutperiode", c.dtpDateDe.Text),
                    new ReportParameter("finperiode", c.dtpDateA.Text),
                    new ReportParameter("exepasse", (c.dtpDateA.Value.Date.Year-1).ToString())
                };
                List<Balance> list = new List<Balance>();
                list.Clear();

                for (int i = 0; i < c.dgvBalance.RowCount; i++)
                {
                    Balance bal = new Balance
                    {
                        numcompte = c.dgvBalance.Rows[i].Cells[0].Value.ToString(),
                        libelle = c.dgvBalance.Rows[i].Cells[1].Value.ToString(),
                        debit_ouv = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[2].Value),
                        credit_ouv = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[3].Value),
                        debit_mouv = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[4].Value),
                        credit_mouv = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[5].Value),
                        debit_fin = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[6].Value),
                        credit_fin = Convert.ToDouble(c.dgvBalance.Rows[i].Cells[7].Value)
                    };
                    list.Add(bal);
                }
                rs.Name = "DataSet2";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.Balance.rdlc";
                imp.reportViewer1.LocalReport.SetParameters(rparams);
                imp.ShowDialog();
                c.btnImprimer.Enabled = false;
            }
            else
                MessageBox.Show("Aucune n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void SupprimerLigne(FormComptaBalance c, int nbligne)
        {
            id = nbligne;
            for (int i = 0; i < c.dgvBalance.RowCount; i++)
            {
                if (double.Parse(c.dgvBalance.Rows[i].Cells[6].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[7].Value.ToString()) == 0)
                {
                    c.dgvBalance.Rows.RemoveAt(i);
                    id--;
                    break;
                }
            }
            if (nbligne > 0)
                SupprimerLigne(c, id);
        }
        #endregion

        #region TABLEAU_DE_RESULTAT
        public void RubriquesResultat(FormComptaResultat c)
        {
            c.dgvResultat.Rows.Clear();
            c.dgvResultat.Rows.Add(c.cboLibelle.Items.Count);
            for (int i = 0; i < c.cboLibelle.Items.Count; i++)
            {
                chaine = "";
                c.dgvResultat.Rows[0].Selected = false;
                chaine = c.cboLibelle.Items[i].ToString();
                c.dgvResultat.Rows[i].Cells[0].Value = chaine.Substring(0, 2);
                chaine = chaine.Substring(3);
                if (chaine.Contains("_"))
                {
                    c.dgvResultat.Rows[i].Cells[1].Value = chaine.Substring(0, chaine.IndexOf("_"));
                    chaine = chaine.Substring(chaine.IndexOf("_") + 1);
                    if (chaine.Contains("_"))
                    {
                        c.dgvResultat.Rows[i].Cells[3].Value = chaine.Substring(0, chaine.IndexOf("_"));
                        chaine = chaine.Substring(chaine.IndexOf("_") + 1);
                        c.dgvResultat.Rows[i].Cells[2].Value = chaine;
                    }
                    else
                    {
                        c.dgvResultat.Rows[i].Cells[2].Value = "";
                        c.dgvResultat.Rows[i].Cells[3].Value = chaine;
                    }
                }
                else
                {
                    c.dgvResultat.Rows[i].Cells[1].Value = chaine;
                    c.dgvResultat.Rows[i].Cells[2].Value = "";
                    c.dgvResultat.Rows[i].Cells[3].Value = "";
                }

                c.dgvResultat.Rows[i].Cells[4].Value = 0;
                c.dgvResultat.Rows[i].Cells[5].Value = 0;
            }
            c.dgvResultat.Rows[3].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[3].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[7].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[7].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[21].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[21].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[23].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[23].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[26].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[26].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[32].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[32].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[33].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[33].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[38].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[38].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[41].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvResultat.Rows[41].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
        }
        public void CalculerResultat(FormComptaResultat c)
        {
            for (int i = 0; i < c.dgvResultat.RowCount; i++)
            {
                con.Open();
                try
                {
                    if (c.dgvResultat.Rows[i].Cells[0].Value.ToString().Substring(0,1)=="R")
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";
                    else
                        cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(montantdebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(montantdebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", c.dgvResultat.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            c.dgvResultat.Rows[i].Cells[4].Value = Convert.ToDouble(dr[0].ToString());
                            c.dgvResultat.Rows[i].Cells[5].Value = Convert.ToDouble(dr[1].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            CalculerTotalResultat(c);
        }
        public void CalculerTotalResultat(FormComptaResultat c)
        {
            //TA à RB
            c.dgvResultat.Rows[3].Cells[4].Value = 0;
            c.dgvResultat.Rows[3].Cells[5].Value = 0;
            for (int i = 0; i < 3; i++)
            {
                c.dgvResultat.Rows[3].Cells[4].Value = double.Parse(c.dgvResultat.Rows[3].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[3].Cells[5].Value = double.Parse(c.dgvResultat.Rows[3].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //TA + TB + TC + TD
            c.dgvResultat.Rows[7].Cells[4].Value = 0;
            c.dgvResultat.Rows[7].Cells[5].Value = 0;
            for (int i = 0; i < 7; i++)
            {
                c.dgvResultat.Rows[7].Cells[4].Value = double.Parse(c.dgvResultat.Rows[7].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[7].Cells[5].Value = double.Parse(c.dgvResultat.Rows[7].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
                if (i == 0)
                    i += 3;
            }
            //(XB+RA+RB) + (somme TE+RJ)
            c.dgvResultat.Rows[21].Cells[4].Value = 0;
            c.dgvResultat.Rows[21].Cells[5].Value = 0;
            for (int i = 1; i < 21; i++)
            {
                c.dgvResultat.Rows[21].Cells[4].Value = double.Parse(c.dgvResultat.Rows[21].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[21].Cells[5].Value = double.Parse(c.dgvResultat.Rows[21].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
                if (i == 2)
                    i += 4;
            }
            //(XC+RK)
            c.dgvResultat.Rows[23].Cells[4].Value = 0;
            c.dgvResultat.Rows[23].Cells[5].Value = 0;
            for (int i = 21; i < 23; i++)
            {
                c.dgvResultat.Rows[23].Cells[4].Value = double.Parse(c.dgvResultat.Rows[23].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[23].Cells[5].Value = double.Parse(c.dgvResultat.Rows[23].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //(XD+TJ+RL)
            c.dgvResultat.Rows[26].Cells[4].Value = 0;
            c.dgvResultat.Rows[26].Cells[5].Value = 0;
            for (int i = 23; i < 26; i++)
            {
                c.dgvResultat.Rows[26].Cells[4].Value = double.Parse(c.dgvResultat.Rows[26].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[26].Cells[5].Value = double.Parse(c.dgvResultat.Rows[26].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //(XD+TJ+RL)
            c.dgvResultat.Rows[32].Cells[4].Value = 0;
            c.dgvResultat.Rows[32].Cells[5].Value = 0;
            for (int i = 27; i < 32; i++)
            {
                c.dgvResultat.Rows[32].Cells[4].Value = double.Parse(c.dgvResultat.Rows[32].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[32].Cells[5].Value = double.Parse(c.dgvResultat.Rows[32].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //(XE+XF)
            c.dgvResultat.Rows[33].Cells[4].Value = double.Parse(c.dgvResultat.Rows[32].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[26].Cells[4].Value.ToString());
            c.dgvResultat.Rows[33].Cells[5].Value = double.Parse(c.dgvResultat.Rows[32].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[26].Cells[5].Value.ToString());
            //(somme TN à RP)
            c.dgvResultat.Rows[38].Cells[4].Value = 0;
            c.dgvResultat.Rows[38].Cells[5].Value = 0;
            for (int i = 34; i < 38; i++)
            {
                c.dgvResultat.Rows[38].Cells[4].Value = double.Parse(c.dgvResultat.Rows[38].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[38].Cells[5].Value = double.Parse(c.dgvResultat.Rows[38].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //(XG+XH+RQ+RS)
            c.dgvResultat.Rows[41].Cells[4].Value = 0;
            c.dgvResultat.Rows[41].Cells[5].Value = 0;
            for (int i = 33; i < 41; i++)
            {
                c.dgvResultat.Rows[41].Cells[4].Value = double.Parse(c.dgvResultat.Rows[41].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[41].Cells[5].Value = double.Parse(c.dgvResultat.Rows[41].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
                if (i == 33)
                    i += 4;
            }
        }
        public void ImprimerResultat(FormComptaResultat c, FormImpression imp)
        {
            imp.Text = "SSM - Tableau de résultat";

            List<Tableau_Resultat> list = new List<Tableau_Resultat>();
            list.Clear();

            for (int i = 0; i < c.dgvResultat.RowCount; i++)
            {
                Tableau_Resultat bal = new Tableau_Resultat
                {
                    refe = c.dgvResultat.Rows[i].Cells[0].Value.ToString(),
                    libelle = c.dgvResultat.Rows[i].Cells[1].Value.ToString(),
                    signe = c.dgvResultat.Rows[i].Cells[2].Value.ToString(),
                    note = c.dgvResultat.Rows[i].Cells[3].Value.ToString(),
                    netEncours = c.dgvResultat.Rows[i].Cells[4].Value.ToString(),
                    netPasse = c.dgvResultat.Rows[i].Cells[5].Value.ToString()
                };
                list.Add(bal);
            }
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("entite", "POLYCLINIQUE SUMEDCO MBUJIMAYI"),
                new ReportParameter("adresse", "345, Inga, Minkoka, Dibindi, MBM, K.OR, RDC"),
                new ReportParameter("sigle", "NULL"),
                new ReportParameter("NCC", "A 1206584 Z"),
                new ReportParameter("datecloture", "31/12/20"),
                new ReportParameter("duree", "12"),
                new ReportParameter("NTD", "0854630801 / 0816110099")
            };

            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.TableauResultat.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
            c.btnImprimer.Enabled = false;
        }
        #endregion

        #region TABLEAU_DE_FLUX_DE_TRESORERIE
        public void RubriquesTFT(FormComptaTableauFlux c)
        {
            c.dgvTFT.Rows.Add(c.cboLibelle.Items.Count);
            for (int i = 0; i < c.cboLibelle.Items.Count; i++)
            {
                chaine = "";
                c.dgvTFT.Rows[0].Selected = false;
                chaine = c.cboLibelle.Items[i].ToString();
                
                if (chaine.StartsWith("_"))
                {
                    c.dgvTFT.Rows[i].Cells[0].Value = "";
                    c.dgvTFT.Rows[i].Cells[1].Value = chaine.Substring(1);
                }
                else
                {
                    c.dgvTFT.Rows[i].Cells[0].Value = chaine.Substring(0, 2);
                    chaine = chaine.Substring(3);
                    if (chaine.Contains("_"))
                    {
                        c.dgvTFT.Rows[i].Cells[1].Value = chaine.Substring(0, chaine.IndexOf("_"));
                        chaine = chaine.Substring(chaine.IndexOf("_") + 1);
                        c.dgvTFT.Rows[i].Cells[2].Value = chaine;
                    }
                    else
                        c.dgvTFT.Rows[i].Cells[1].Value = chaine;
                }
                c.dgvTFT.Rows[i].Cells[3].Value = "";
                c.dgvTFT.Rows[i].Cells[4].Value = 0;
            }
            c.dgvTFT.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);           
            c.dgvTFT.Rows[8].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[8].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[15].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[15].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[21].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[21].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[26].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[26].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[27].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[27].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[29].DefaultCellStyle.BackColor = Color.FromArgb(180, 200, 255);
            c.dgvTFT.Rows[29].DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 255);
        }
        public void CalculerTFT(FormComptaTableauFlux c)
        {
            TresoresireBilan(c);
            MontantResultatTFT(c);
            MontantBilanTFT(c);
            MontantBalanceTFT(c);
            CalculerSousTotauxTFT(c);
        }

        private void TresoresireBilan(FormComptaTableauFlux c)
        {
            int[] compte_treso;
            //Actif
            c.som_Treso_Actif = 0;
            compte_treso = new int[] { 52, 53, 54, 55, 57, 581, 582 };
            for (int i = 0; i < compte_treso.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT                        
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                        AND categorie = 'U' AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            if (Convert.ToDouble(dr[0].ToString()) >= 0)
                            {
                                c.som_Treso_Actif += Convert.ToDouble(dr[0].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                if (compte_treso[i] == 52 || compte_treso[i] == 57)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit)) * MAX(taux) AS SoldePasse
                            FROM OperationCompte oc 
                            JOIN Operation o ON oc.idoperation = o.idoperation
                            JOIN Compte c ON oc.numcompte = c.numcompte
                            JOIN Date_operation d ON d.date_operation = o.date_operation
                            WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                            AND categorie = 'UU' AND o.date_operation BETWEEN @dateDe AND @dateA";


                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) >= 0)
                                {
                                    c.som_Treso_Actif += Convert.ToDouble(dr[0].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            //Passif
            c.som_Treso_Passif = 0;
            compte_treso = new int[] { 52, 53, 561, 566 };
            for (int i = 0; i < compte_treso.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT 
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                        AND categorie = 'U' AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            if (Convert.ToDouble(dr[0].ToString()) < 0)
                            {
                                c.som_Treso_Passif += Convert.ToDouble(dr[0].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                if (compte_treso[i] == 52)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                            (SUM(soldeouvedebit)-SUM(soldeouvecredit)) * MAX(taux) AS SoldePasse
                            FROM OperationCompte oc 
                            JOIN Operation o ON oc.idoperation = o.idoperation
                            JOIN Compte c ON oc.numcompte = c.numcompte
                            JOIN Date_operation d ON d.date_operation = o.date_operation
                            WHERE o.idexercice = @idexercice AND c.numcompte LIKE '" + compte_treso[i] + @"%' 
                            AND categorie = 'UU' AND o.date_operation BETWEEN @dateDe AND @dateA";


                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                            {
                                if (Convert.ToDouble(dr[0].ToString()) < 0)
                                {
                                    c.som_Treso_Passif += Convert.ToDouble(dr[0].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
            }
            c.dgvTFT.Rows[0].Cells[4].Value = c.som_Treso_Actif + c.som_Treso_Passif;
        }
        public void ImprimerTFT(FormComptaTableauFlux c, FormImpression imp)
        {
            imp.Text = "SSM - Tableau de flux de trésorerie";

            List<Tableau_Resultat> list = new List<Tableau_Resultat>();
            list.Clear();

            for (int i = 0; i < c.dgvTFT.RowCount; i++)
            {
                Tableau_Resultat tft = new Tableau_Resultat
                {
                    refe = c.dgvTFT.Rows[i].Cells[0].Value.ToString(),
                    libelle = c.dgvTFT.Rows[i].Cells[1].Value.ToString(),
                    signe = c.dgvTFT.Rows[i].Cells[2].Value.ToString(),
                    note = c.dgvTFT.Rows[i].Cells[3].Value.ToString(),
                    netEncours = c.dgvTFT.Rows[i].Cells[4].Value.ToString()
                };
                list.Add(tft);
            }
            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("entite", "POLYCLINIQUE SUMEDCO MBUJIMAYI"),
                new ReportParameter("adresse", "345, Inga, Minkoka, Dibindi, MBM, K.OR, RDC"),
                new ReportParameter("sigle", "NULL"),
                new ReportParameter("NCC", "A 1206584 Z"),
                new ReportParameter("datecloture", "31/12/20"),
                new ReportParameter("duree", "12"),
                new ReportParameter("NTD", "0854630801 / 0816110099")
            };

            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.TableauFlux.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.ShowDialog();
            c.btnImprimer.Enabled = false;
        }
        private void MontantResultatTFT(FormComptaTableauFlux c)
        {
            string[]  ref_resultat = { "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI", "TK", "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI", "RJ", "RK", "RM", "RS" };
            sommeValeur += 0;
            for (int i = 0; i < ref_resultat.Length; i++)
            {
                con.Open();
                try
                {
                    if (ref_resultat[i].Substring(0, 1) == "R")
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";
                    else
                        cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(montantdebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(montantdebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", ref_resultat[i]);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            sommeValeur += Convert.ToDouble(dr[0].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			    con.Close();
            }
            c.dgvTFT.Rows[2].Cells[4].Value = sommeValeur;
        }
        private void MontantBilanTFT(FormComptaTableauFlux c)
        {
            string[] ref_bilan = { "BA", "BB"};
            for (int i = 3; i < 5; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", ref_bilan[i-3]);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            c.dgvTFT.Rows[i].Cells[4].Value = Convert.ToDouble(dr[0].ToString()) - Convert.ToDouble(dr[1].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            string[] ref_bilan2 = new string[] { "BH", "BI", "BJ" };
            c.dgvTFT.Rows[5].Cells[4].Value = 0;
            for (int i = 0; i < ref_bilan2.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", ref_bilan2[i]);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                    
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            c.dgvTFT.Rows[5].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[5].Cells[4].Value) + (Convert.ToDouble(dr[0].ToString()) - Convert.ToDouble(dr[1].ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }

            string[] ref_bilan3 = new string[] { "DH", "DI", "DJ", "DK", "DM", "DN" };
            c.dgvTFT.Rows[6].Cells[4].Value = 0;
            for (int i = 0; i < ref_bilan3.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref = @ref AND categorie = 'U' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                    cmd.Parameters.AddWithValue("@ref", ref_bilan3[i]);
                    cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() != "")
                        {
                            c.dgvTFT.Rows[6].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[6].Cells[4].Value) + (Convert.ToDouble(dr[0].ToString()) - Convert.ToDouble(dr[1].ToString()));
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            
        }
        private void MontantBalanceTFT(FormComptaTableauFlux c)
        {
            for (int i = 10; i < 15; i++)
            {
                if(i == 10)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceDiffMvt(c, 21) + BalanceDiffMvt(c, 251000); 
                }
                else if(i==11)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceDiffMvt(c, 24);
                }
                else if (i == 12)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceDiffMvt(c, 26) + BalanceDiffMvt(c, 27);
                }
                else if(i==13)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 821) + BalanceMvtCrediteur(c, 822) - BalanceDiffMvt(c, 4851) - BalanceDiffMvt(c, 4852);
                }
                else if(i==14)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 826) - BalanceDiffMvt(c, 4856);
                }
            }
            for (int i = 17; i < 21; i++)
            {
                if(i==17)
                {                   
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 10);
                }
                else if (i == 18)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 14) - BalanceDiffMvt(c, 4494) - BalanceDiffMvt(c, 4852);
                }
                else if(i==19)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 4619);                   
                }
                else if(i==20)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 465);
                }               
            }
            for (int i = 23; i < 26; i++)
            {
                if (i == 23)
                {
                    c.dgvTFT.Rows[i].Cells[4].Value = BalanceMvtCrediteur(c, 161) + BalanceMvtCrediteur(c, 162);
                }
                else if (i == 24)
                    c.dgvTFT.Rows[i].Cells[4].Value =
                        BalanceMvtCrediteur(c, 163) +
                        BalanceMvtCrediteur(c, 164) +
                        BalanceMvtCrediteur(c, 165) +
                        BalanceMvtCrediteur(c, 167) +
                        BalanceMvtCrediteur(c, 168) +
                        BalanceMvtCrediteur(c, 181) +
                        BalanceMvtCrediteur(c, 182) +
                        BalanceMvtCrediteur(c, 184);
                else if (i == 25)
                    c.dgvTFT.Rows[i].Cells[4].Value =
                        BalanceMvtDebiteur(c, 16) +
                        BalanceMvtDebiteur(c, 17) +
                        BalanceMvtDebiteur(c, 18);
            }
        }
        private double BalanceMvtCrediteur(FormComptaTableauFlux c, int compte)
        {
            sommeValeur = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montantcredit) 
                FROM OperationCompte oc
                JOIN Operation o ON oc.idoperation = o.idoperation
                JOIN Compte c ON oc.numcompte = c.numcompte
                WHERE idexercice = @idexercice AND oc.numcompte LIKE '"+compte+@"%' AND categorie = 'U' AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY oc.numcompte";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0].ToString() != "")
                        sommeValeur += Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return sommeValeur;
        }
        private double BalanceMvtDebiteur(FormComptaTableauFlux c, int compte)
        {
            sommeValeur = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montantdebit) 
                FROM OperationCompte oc
                JOIN Operation o ON oc.idoperation = o.idoperation
                JOIN Compte c ON oc.numcompte = c.numcompte
                WHERE idexercice = @idexercice AND oc.numcompte LIKE '" + compte + @"%' AND categorie = 'U' AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY oc.numcompte";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0].ToString() != "")
                        sommeValeur += Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return sommeValeur;
        }
        private double BalanceDiffMvt(FormComptaTableauFlux c, int compte)
        {
            sommeValeur = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                FROM OperationCompte oc
                JOIN Operation o ON oc.idoperation = o.idoperation
                JOIN Compte c ON oc.numcompte = c.numcompte
                WHERE idexercice = @idexercice AND oc.numcompte LIKE '"+compte+@"%' AND categorie = 'U' AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY oc.numcompte";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr[0].ToString() != "")
                        sommeValeur += Convert.ToDouble(dr[0].ToString());
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return sommeValeur;
        }
        private void CalculerSousTotauxTFT(FormComptaTableauFlux c)
        {
            //FB+FC+FD+FE
            c.dgvTFT.Rows[7].Cells[4].Value = 0;
            for (int i = 3; i < 7; i++)
            {
                if (c.dgvTFT.Rows[i].Cells[2].Value.ToString()=="+") 
                    c.dgvTFT.Rows[7].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[7].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
                else
                    c.dgvTFT.Rows[7].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[7].Cells[4].Value) - Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
            }
            //B
            c.dgvTFT.Rows[8].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[7].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[2].Cells[4].Value);
            //C
            c.dgvTFT.Rows[15].Cells[4].Value = 0;
            for (int i = 10; i < 15; i++)
            {
                if (c.dgvTFT.Rows[i].Cells[2].Value.ToString() == "+")
                    c.dgvTFT.Rows[15].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[15].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
                else
                    c.dgvTFT.Rows[15].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[15].Cells[4].Value) - Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
            }
            //D
            c.dgvTFT.Rows[21].Cells[4].Value = 0;
            for (int i = 17; i < 21; i++)
            {
                if (c.dgvTFT.Rows[i].Cells[2].Value.ToString() == "+")
                    c.dgvTFT.Rows[21].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[21].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
                else
                    c.dgvTFT.Rows[21].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[21].Cells[4].Value) - Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
            }
            //E
            c.dgvTFT.Rows[26].Cells[4].Value = 0;
            for (int i = 23; i < 26; i++)
            {
                if (c.dgvTFT.Rows[i].Cells[2].Value.ToString() == "+")
                    c.dgvTFT.Rows[26].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[26].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
                else
                    c.dgvTFT.Rows[26].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[26].Cells[4].Value) - Convert.ToDouble(c.dgvTFT.Rows[i].Cells[4].Value);
            }
            //F = D+E
            c.dgvTFT.Rows[27].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[21].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[26].Cells[4].Value);
            //G = B+C+F
            c.dgvTFT.Rows[28].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[8].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[15].Cells[4].Value) + 
                Convert.ToDouble(c.dgvTFT.Rows[27].Cells[4].Value);
            //H = G+A
            c.dgvTFT.Rows[29].Cells[4].Value = Convert.ToDouble(c.dgvTFT.Rows[0].Cells[4].Value) + Convert.ToDouble(c.dgvTFT.Rows[28].Cells[4].Value);
        }
        #endregion

        #region TYPE_JOURNAL

        #endregion

        #region ADMIN
        public int NombreConsultations()
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("select count(idservice) from Service where numcompte = '706101'", con);
            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    id = int.Parse(dr[0].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public void RubriqueStatService(FormAdminStatService s)
        {
            int index = 0;
            con.Open();
            cmd = new SqlCommand("select numcompte, libellecompte from Compte where numcompte like '7061%'", con);
            try
            {
                dr = cmd.ExecuteReader();
                s.dgvRapport.Rows.Clear();
                while (dr.Read())
                {                 
                    s.dgvRapport.Rows.Add();
                    s.dgvRapport.Rows[s.dgvRapport.RowCount - 1].Cells[0].Value = s.dgvRapport.RowCount;
                    s.dgvRapport.Rows[s.dgvRapport.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    s.dgvRapport.Rows[s.dgvRapport.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    if (dr[0].ToString() == "706101")
                    {
                        index = s.dgvRapport.Rows[s.dgvRapport.RowCount - 1].Index;
                    }
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            //Ajouter les types de consultations
            index += 1;
            s.dgvRapport.Rows.Insert(index, NombreConsultations());
            
            con.Open();
            cmd = new SqlCommand("select idservice, nomservice from Service where numcompte = '706101'", con);
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    s.dgvRapport.Rows[index].Cells[0].Value = "";
                    s.dgvRapport.Rows[index].Cells[1].Value = dr[0].ToString();
                    s.dgvRapport.Rows[index].Cells[2].Value = dr[1].ToString();
                    s.dgvRapport.Rows[index].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    index++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AjouterColonneMois(FormAdminStatService s)
        {
            id = 0;
            TimeSpan t = s.dtpDateA.Value.Date - s.dtpDateDe.Value.Date;
            if (t.TotalDays <= 0)
                MessageBox.Show("La première date doit être inférieure ou égal à la deuxième");
            else
            {
                //Ajuster les dates
                if (s.dtpDateDe.Value.Day != 1)
                    s.dtpDateDe.Value = s.dtpDateDe.Value.AddDays(-(s.dtpDateDe.Value.Day - 1));

                s.nbjours = DateTime.DaysInMonth(s.dtpDateA.Value.Year, s.dtpDateA.Value.Month);
                s.dtpDateA.Value = s.dtpDateA.Value.AddDays((s.nbjours - s.dtpDateA.Value.Day));

                //Remove months columns and initialize the dgv to the first 3 columns
                s.nbcolonne = s.dgvRapport.ColumnCount;
                if (s.nbcolonne > 3)
                {
                    for (int i = s.nbcolonne - 1; i > 2; i--)
                    {
                        s.dgvRapport.Columns.RemoveAt(i);
                    }
                }

                //Adding months columns
                for (DateTime i = s.dtpDateDe.Value.Date; i < s.dtpDateA.Value.Date; i = i.AddMonths(1))
                {
                    id++;
                    s.dgvRapport.Columns.Add("mois" + id, i.ToShortDateString().Substring(3));
                    for (int j = 0; j < s.dgvRapport.RowCount; j++)
                    {
                        s.dgvRapport.Rows[j].Cells[s.dgvRapport.ColumnCount - 1].Value = 0;
                    }
                }
                if (id > 12)
                {
                    MessageBox.Show("Le nombre total de mois a dépassé 12. Ainsi, il sera réduit à la valeur max de 12", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    s.nbcolonne = s.dgvRapport.ColumnCount;
                    if (s.nbcolonne > 15)
                    {
                        for (int i = s.nbcolonne - 1; i > 14; i--)
                        {
                            s.dgvRapport.Columns.RemoveAt(i);
                        }
                    }
                }
                //Colonne totaux
                id++;
                s.dgvRapport.Columns.Add("mois" + id, "Total");
                for (int j = 0; j < s.dgvRapport.RowCount; j++)
                {
                    s.dgvRapport.Rows[j].Cells[s.dgvRapport.ColumnCount - 1].Value = 0;
                }
            }
        }
        public void AfficherCasConsultation(FormAdminStatService s)
        {
            for (int i = 0; i < s.dgvRapport.RowCount; i++)
            {
                s.sommeligne = 0;
                id = 0;
                if (s.dgvRapport.Rows[i].Cells[1].Value.ToString() == "706101")
                    id = s.dgvRapport.Rows[i].Index;
                if(s.dgvRapport.Rows[i].Cells[0].Value.ToString() == "")
                {
                    for (int j = 3; j < s.dgvRapport.ColumnCount-1; j++)
                    {
                        s.colonne = s.dgvRapport.Columns[j].HeaderText;
                        s.nbjours = DateTime.DaysInMonth(int.Parse(s.colonne.Substring(3)), int.Parse(s.colonne.Substring(0, 2)));
                        con.Open();
                        cmd = new SqlCommand("select count(idrecette) from RecetteService where idservice = @id and date_operation between @date_De and @date_A", con);
                        cmd.Parameters.AddWithValue("@id", s.dgvRapport.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@date_De", "01/" + s.colonne);
                        cmd.Parameters.AddWithValue("@date_A", s.nbjours + "/" + s.colonne);
                        try
                        {
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                s.dgvRapport.Rows[i].Cells[j].Value = dr[0].ToString();
                                s.dgvRapport.Rows[id].Cells[j].Value = int.Parse(s.dgvRapport.Rows[id].Cells[j].Value.ToString()) + int.Parse(s.dgvRapport.Rows[i].Cells[j].Value.ToString());
                                s.sommeligne = s.sommeligne + int.Parse(s.dgvRapport.Rows[i].Cells[j].Value.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    s.dgvRapport.Rows[i].Cells[s.dgvRapport.ColumnCount - 1].Value = s.sommeligne;
                    s.dgvRapport.Rows[id].Cells[s.dgvRapport.ColumnCount - 1].Value = int.Parse(s.dgvRapport.Rows[id].Cells[s.dgvRapport.ColumnCount - 1].Value.ToString()) + s.sommeligne;
                }
            }
        }
        public void AfficherCas(FormAdminStatService s)
        {
            for (int i = 0; i < s.dgvRapport.RowCount; i++)
            {
                s.sommeligne = 0;
                if(s.dgvRapport.Rows[i].Cells[0].Value.ToString() != "" && s.dgvRapport.Rows[i].Cells[1].Value.ToString() != "706101")
                {
                    for (int j = 3; j < s.dgvRapport.ColumnCount-1; j++)
                    {
                        s.colonne = s.dgvRapport.Columns[j].HeaderText;
                        s.nbjours = DateTime.DaysInMonth(int.Parse(s.colonne.Substring(3)), int.Parse(s.colonne.Substring(0, 2)));
                        con.Open();
                        cmd = new SqlCommand("select count(idrecette) from RecetteService, Service where RecetteService.idservice = Service.idservice and numcompte = @compte and date_operation between @date_De and @date_A", con);
                        cmd.Parameters.AddWithValue("@compte", s.dgvRapport.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@date_De", "01/" + s.colonne);
                        cmd.Parameters.AddWithValue("@date_A", s.nbjours + "/" + s.colonne);
                        try
                        {
                            dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                s.dgvRapport.Rows[i].Cells[j].Value = dr[0].ToString();
                                s.sommeligne = s.sommeligne + int.Parse(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con.Close();
                    }
                    s.dgvRapport.Rows[i].Cells[s.dgvRapport.ColumnCount - 1].Value = s.sommeligne;
                }
            }
        }
        public void ImprimerRapportStat(FormAdminStatService s, FormImpression imp)
        {
            imp.Text = "SSM - Rapport Statistiques";
            List<DataGridView> list = new List<DataGridView>();
            list.Clear();
            DataGridView dgv = new DataGridView();
            for (int i = 0; i < s.dgvRapport.ColumnCount; i++)
			{
                dgv.Columns.Add(s.dgvRapport.Columns[i].Name, s.dgvRapport.Columns[i].HeaderText);
			}
          
            for (int i = 0; i < s.dgvRapport.RowCount; i++)
            {
                dgv.Rows.Add();
                for (int j = 0; j < s.dgvRapport.ColumnCount; j++)
                {
                    dgv.Rows[i].Cells[j].Value = dgv.Rows[i].Cells[j].Value;
                }
            }
            list.Add(dgv);

            rs.Name = "DataSet1";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BilanActif.rdlc";
            imp.ShowDialog();
        }
        #endregion

    }
    public class DetailBonrecette
    {
        public string id { get; set; }
        public string libelle { get; set; }
        public string montant { get; set; }
    }
    public class Rapport_recette
    {
        public string id { get; set; }
        public string categorie { get; set; }
        public string montantCDF { get; set; }
        public string montantUSD { get; set; }
    }
    public class Bilan_Actif
    {
        public string refActif { get; set; }
        public string rubriqueActif { get; set; }
        public string noteActif { get; set; }
        public string placement { get; set; }
        public double brut { get; set; }
        public double amortDeprec { get; set; }
        public double net { get; set; }
        public double exercicepasse { get; set; }
    }
    public class GrandLivre
    {
        public string num { get; set; }
        public string date_jour { get; set; }
        public string numpiece { get; set; }
        public string libelle { get; set; }
        public double debit { get; set; }
        public double credit { get; set; }
        public double solde { get; set; }
    }
    public class Bilan_Passif
    {
        public string refPassif { get; set; }
        public string rubriquePassif { get; set; }
        public string notePassif { get; set; }
        public double netEncours { get; set; }
        public double netPasse { get; set; }
    }
    public class Bilan_Tout
    {
        public string refActif { get; set; }
        public string rubriqueActif { get; set; }
        public string noteActif { get; set; }
        public string placement { get; set; }
        public double brut { get; set; }
        public double amortDeprec { get; set; }
        public double net { get; set; }
        public double exercicepasse { get; set; }
        public string refPassif { get; set; }
        public string rubriquePassif { get; set; }
        public string notePassif { get; set; }
        public double netEncours { get; set; }
        public double netPasse { get; set; }
    }
    public class Balance
    {
        public string numcompte { get; set; }
        public string libelle { get; set; }
        public double debit_ouv { get; set; }
        public double credit_ouv { get; set; }
        public double debit_mouv { get; set; }
        public double credit_mouv { get; set; }
        public double debit_fin { get; set; }
        public double credit_fin { get; set; }
    }
    public class Tableau_Resultat
    {
        public string refe { get; set; }
        public string libelle { get; set; }
        public string signe { get; set; }
        public string note { get; set; }
        public string netEncours { get; set; }
        public string netPasse { get; set; }
    }
    public class Tableau_Flux
    {
        public string refe { get; set; }
        public string libelle { get; set; }
        public string note { get; set; }
        public string netEncours { get; set; }
    }
    public class AbonnePersoRapport
    {
        public int id { get; set; }
        public string patient { get; set; }
        public string age { get; set; }
        public string sexe { get; set; }
        public string reference { get; set; }
        public string produit { get; set; }
        public string service1 { get; set; }
        public string service2 { get; set; }
        public string service3 { get; set; }
        public string service4 { get; set; }
        public string service5 { get; set; }
        public string service6 { get; set; }
        public string service7 { get; set; }
        public string service8 { get; set; }
        public string service9 { get; set; }
        public string service10 { get; set; }
        public string service11 { get; set; }
        public string service12 { get; set; }
        public string service13 { get; set; }
        public string service14 { get; set; }
        public string service15 { get; set; }
        public string service16 { get; set; }
        public string service17 { get; set; }
        public string service18 { get; set; }
        public string service19 { get; set; }
        public string service20 { get; set; }
        public string service21 { get; set; }
    }
}
