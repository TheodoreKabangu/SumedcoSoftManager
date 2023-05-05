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
        bool cmdStatut;
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
                case "abonneconsulte": cmdtxt = "select idabonne from Abonne where idpatient = @nom"; break;
                case "employeconsulte": cmdtxt = "select idemploye from Employe where idpatient = @nom"; break;
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
                case "abonne": cmdtxt = "select nomabonne from Abonne where idabonne = @id"; break;
                case "compte": cmdtxt = "select libellecompte from Compte where numcompte = @id"; break;
                case "poste": cmdtxt = "select poste from Utilisateur where id= @id"; break;
            }
            try
            {
                con.Open();
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                dr.Read();
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public int NouveauID(string concerne)
        {
            id = 0;
            switch (concerne)
            {
                case "recetteservice": cmdtxt = "select max(idrecette) from RecetteService"; break;
                case "recetteproduit": cmdtxt = "select max(idrecette) from RecetteProduit"; break;
                case "payement": cmdtxt = "select max(idpayement) from Payement"; break;
                case "service": cmdtxt = "select max(idservice) from Service"; break;
                case "recette": cmdtxt = "select max(idrecette) from Recette"; break;
                case "depense": cmdtxt = "select max(iddepense) from Depense"; break;
                case "bondepense": cmdtxt = "select max(numbon) from BonDepense"; break;
                case "catdepense": cmdtxt = "select max(idcatdepense) from CategorieDepense"; break;
                case "payeur": cmdtxt = "select max(idpayeur) from Payeur"; break;
                case "abonneservice": cmdtxt = "select max(id) from AbonneService"; break;
                case "abonneproduit": cmdtxt = "select max(id) from AbonneProduit"; break;
                case "operation": cmdtxt = "select max(idoperation) from Operation"; break;
                case "operationcompte": cmdtxt = "select max(id) from OperationCompte"; break;
                case "exercice": cmdtxt = "select max(idexercice) from Exercice"; break;
                case "employeservice": cmdtxt = "select max(id) from EmployeService"; break;
                case "employeproduit": cmdtxt = "select max(id) from EmployeProduit"; break;
                case "agendacaisse": cmdtxt = "select max(idligne) from AgendaCaisse"; break;
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
        public void AfficherSousForm(MFormRecette r, Form childForm)
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
        public void AfficherSousForm(MFormRecette r, FormRecette childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
        }
        public void AfficherSousForm(MFormRecette r, FormRecetteJournal childForm)
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
            childForm.Show();
        }

        public void AfficherSousForm(MFormReception r, Form childForm)
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
        public void AfficherSousForm(MFormReception r, FormFactureProduit childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
        }
        public void AfficherSousForm(MFormReception r, FormFactureService childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public void AfficherSousForm(MFormReception r, FormPatient childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.dgvPatient.Columns[11].Visible = false;
                childForm.dgvPatient.Columns[12].Visible = false;
                childForm.dgvPatient.Columns[13].Visible = false;
                if (r.statut == "nouveau")
                {
                    childForm.txtRecherche.Enabled = false;
                    childForm.btnRecherche.Enabled = false;
                }
                else
                {
                    childForm.btnEnregistrer.Enabled = false;
                    childForm.rbNouveau.Text = "Ancien cas";
                }
                if (r.infirmier_autorise)
                    childForm.rbNouveau.Enabled = false;
                childForm.statut = r.statut;
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
            //Adapter l'utilisation de cette métode partout pour date et taux si possible
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

        public int AjouterRecette(int idrecette, string statut_facture, string date, string type_payeur, int idpayeur, string categorie)
        {
            idrecette = NouveauID("recette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (statut_facture == "différé")
                {
                    cmd = new SqlCommand("insert into Recette(idrecette, statut_facture, date_operation, type_payeur, idpayeur, categorie, statut_caisse) values (@idrecette, @statut_facture, @date_operation, @type_payeur, @idpayeur, @categorie, @statut_caisse)", con);
                    cmd.Parameters.AddWithValue("@statut_caisse", "OK");
                }
                else
                    cmd = new SqlCommand("insert into Recette(idrecette, statut_facture, date_operation, type_payeur, idpayeur, categorie) values (@idrecette, @statut_facture, @date_operation, @type_payeur, @idpayeur, @categorie)", con);
                cmd.Parameters.AddWithValue("@idrecette", idrecette);
                cmd.Parameters.AddWithValue("@statut_facture", statut_facture);
                cmd.Parameters.AddWithValue("@date_operation", date);
                cmd.Parameters.AddWithValue("@type_payeur", type_payeur);
                cmd.Parameters.AddWithValue("@idpayeur", idpayeur);
                cmd.Parameters.AddWithValue("@categorie", categorie);
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
            return idrecette;
        }
        public void AjouterServiceRecette(int idrecette, int idservice)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into RecetteService (idrecette, idservice) values (@idrecette, @idservice)", con);
                cmd.Parameters.AddWithValue("@idrecette", idrecette);
                cmd.Parameters.AddWithValue("@idservice", idservice);
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
        public void AjouterProduitRecette(int idrecette, int idstock, int qte)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into RecetteProduit (idrecette, idstock, qtevendue) values (@idrecette, @idstock, @qtevendue)", con);
                cmd.Parameters.AddWithValue("@idrecette", idrecette);
                cmd.Parameters.AddWithValue("@idstock", idstock);
                cmd.Parameters.AddWithValue("@qtevendue", qte);
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
        public int AjouterPayeur(int idpayeur, string nompayeur, string contact)
        {
            idpayeur = NouveauID("payeur");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Payeur (idpayeur, nompayeur, contacts) values (@idpayeur, @nompayeur, @contacts)", con);
                cmd.Parameters.AddWithValue("@idpayeur", idpayeur);
                cmd.Parameters.AddWithValue("@nompayeur", nompayeur);
                cmd.Parameters.AddWithValue("@contacts", contact);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                cmdStatut = true;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return idpayeur;
        }
        public void Enregistrer(FormFactureService f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.cboPayeur.Text == "passant")
                {
                    //Ajouter le payeur
                    f.idpayeur = AjouterPayeur(f.idpayeur, f.txtPayeur.Text, f.txtContacts.Text);
                    //Ajout recette
                    f.idrecette = AjouterRecette(f.idrecette, f.cboTypeFacture.Text, f.lblDateOperation.Text, f.cboPayeur.Text, f.idpayeur, "service");
                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterServiceRecette(f.idrecette, int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()));
                    }
                }
                else
                {
                    //Ajout recette
                    f.idrecette = AjouterRecette(f.idrecette, f.cboTypeFacture.Text, f.lblDateOperation.Text, f.cboPayeur.Text, f.idpayeur, "service");
                    //Ajout de services de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterServiceRecette(f.idrecette, int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()));
                    }
                }
                //Cas de facture différé
                if (f.cboTypeFacture.Text == "différé")
                {
                    f.idoperation = NouveauID("operation");
                    if (AjouterOperation(f.idoperation, f.lblDateOperation.Text, string.Format("R_{0}", f.idrecette), TrouverId("typejournal", "ventes"), f.idexercice, f.idrecette, "recette"))
                    {
                        for (int i = 0; i < f.dgvFacture.RowCount; i++)
                        {
                            f.numcompte = TrouverNom("numcompte_service", int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()));
                            AjouterEcriture(f.idoperation, f.numcomptediffere, f.numcompte, double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), "Vente - service à crédit");
                        }
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
                    if(exa.type_patient.Contains("abonné"))
                        cmd = new SqlCommand("select idservice, nomservice, prix_abonne from Service where numcompte = '" + exa.numcompte + "' and nomservice like '" + exa.txtRecherche.Text + "%' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                    else
                        cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte = '" + exa.numcompte + "' and nomservice like '" + exa.txtRecherche.Text + "%' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
                }
                else
                {
                    if (exa.type_patient.Contains("abonné"))
                        cmd = new SqlCommand("select idservice, nomservice, prix_abonne from Service where numcompte = '" + exa.numcompte + "' and nomservice NOT IN ('consultation ancien cas', 'consultation nouveau cas', 'consultation urgence') order by nomservice", con);
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
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte like '7061%' or numcompte like '7078%'", con);
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
                cmd = new SqlCommand("select distinct specification from Service where numcompte like '70611%' and specification is NOT NULL", con);
                dr = cmd.ExecuteReader();
                c.dgvLabo.Rows.Clear();
                while (dr.Read())
                {
                    c.dgv1.Rows.Add();
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[0].Value = c.dgv1.RowCount;
                    c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[1].Value = dr[0].ToString().ToUpper();
                }
                //Pour les examens en dehors de SUMEDCO
                c.dgv1.Rows.Add();
                c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                c.dgv1.Rows[c.dgv1.RowCount - 1].DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
                c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[0].Value = c.dgv1.RowCount;
                c.dgv1.Rows[c.dgv1.RowCount - 1].Cells[1].Value = "AUTRES";
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
                    cmd = new SqlCommand("select idservice, nomservice, prix_abonne from Service where numcompte like '70611%' and specification = '" + chaine + "'", con);
                else
                    cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte like '70611%' and specification = '" + chaine + "'", con);
                
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
                cmd = new SqlCommand("select idstock, forme, dosage, prixunitaire, qtestock from LigneStock where idproduit = @id and qtestock > 0", con);
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
                    fp.dgvStock.Rows[fp.dgvStock.RowCount - 1].Cells[5].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

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
                            Convert.ToInt32(fp.dgvStock.Rows[i].Cells[4].Value.ToString()) >
                            Convert.ToInt32(fp.dgvStock.Rows[i].Cells[5].Value.ToString()))
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
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = string.Format("{0} {1} {2}", f.dgv1.CurrentRow.Cells[1].Value.ToString(), fp.dgvStock.Rows[i].Cells[1].Value.ToString(), fp.dgvStock.Rows[i].Cells[2].Value.ToString());
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = fp.dgvStock.Rows[i].Cells[3].Value.ToString();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = fp.dgvStock.Rows[i].Cells[5].Value.ToString();
                                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = (double.Parse(fp.dgvStock.Rows[i].Cells[3].Value.ToString()) * int.Parse(fp.dgvStock.Rows[i].Cells[5].Value.ToString())).ToString("0.00");
                            }
                        }
                        else
                            f.dgvFacture.Rows.RemoveAt(f.dgvFacture.Rows[i].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("La quantité doit être un entier supérieur à 0 et inférieur au stock disponible", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboPayeur.SelectedText = "";
            f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtPayeur.Text = "";
            f.txtContacts.Text = "";
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
            f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboPayeur.SelectedText = "";
            f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDownList;
            f.txtPayeur.Text = "";
            f.txtContacts.Text = "";
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Clear();
            f.btnRetirer.Enabled = false;
            f.btnRetirerTout.Enabled = false;
        }        
        
        public void Enregistrer(FormFactureProduit f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (f.cboPayeur.Text == "passant")
                {
                    //Ajouter le payeur
                    f.idpayeur = AjouterPayeur(f.idpayeur, f.txtPayeur.Text, f.txtContacts.Text);
                    //Ajout recette
                    f.idrecette = AjouterRecette(f.idrecette, f.cboTypeFacture.Text, f.lblDateOperation.Text, f.cboPayeur.Text, f.idpayeur, "produit");
                    //Ajout de produits de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterProduitRecette(f.idrecette, int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()), int.Parse(f.dgvFacture.Rows[i].Cells[4].Value.ToString()));
                    }
                }
                else
                {
                    //Ajout recette
                    f.idrecette = AjouterRecette(f.idrecette, f.cboTypeFacture.Text, f.lblDateOperation.Text, f.cboPayeur.Text, f.idpayeur, "produit");
                    //Ajout de produits de la recette
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        AjouterProduitRecette(f.idrecette, int.Parse(f.dgvFacture.Rows[i].Cells[0].Value.ToString()), int.Parse(f.dgvFacture.Rows[i].Cells[4].Value.ToString()));
                    }
                }
                //Cas de facture différé
                if (f.cboTypeFacture.Text == "différé")
                {
                    f.idoperation = NouveauID("operation");
                    if (AjouterOperation(f.idoperation, f.lblDateOperation.Text, string.Format("R_{0}", f.idrecette), TrouverId("typejournal", "ventes"), f.idexercice, f.idrecette, "recette"))
                    {
                        for (int i = 0; i < f.dgvFacture.RowCount; i++)
                        {
                            AjouterEcriture(f.idoperation, f.numcomptediffere, "701100", double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString()), "Vente - produit à crédit");                           
                        }
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
            { MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public void AfficherRapportRecette(FormReceptionRapport r)
        {
            con.Open();
            try
            {
                if (r.cboStatut.Text == "" && r.cboCategorie.Text == "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur != 'patient' 
                    union 
                    SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, pa.noms 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    JOIN Patient pa 
                    ON p.idpatient = pa.idpatient
                    WHERE r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur = 'patient'";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                else if (r.cboStatut.Text != "" && r.cboCategorie.Text == "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    WHERE r.statut_facture = @statut AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur != 'patient' 
                    union 
                    SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, pa.noms 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    JOIN Patient pa 
                    ON p.idpatient = pa.idpatient
                    WHERE r.statut_facture = @statut AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur = 'patient'";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@statut", r.cboStatut.Text);

                }
                else if (r.cboStatut.Text == "" && r.cboCategorie.Text != "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    WHERE r.categorie = @categ AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur != 'patient' 
                    union 
                    SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, pa.noms 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    JOIN Patient pa 
                    ON p.idpatient = pa.idpatient
                    WHERE r.categorie = @categ AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur = 'patient'";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@categ", r.cboCategorie.Text);
                }
                else if (r.cboStatut.Text != "" && r.cboCategorie.Text != "")
                {
                    cmdtxt = @"SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    WHERE r.categorie = @categ AND r.statut_facture = @statut AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur != 'patient' 
                    union 
                    SELECT r.idrecette, r.date_operation, r.statut_facture, r.categorie, pa.noms 
                    FROM Recette r
                    JOIN Payeur p 
                    ON r.idpayeur = p.idpayeur 
                    JOIN Patient pa 
                    ON p.idpatient = pa.idpatient
                    WHERE r.categorie = @categ AND r.statut_facture = @statut AND r.date_operation BETWEEN @dateDe AND @dateA AND p.nompayeur = 'patient'";
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
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            MontantRapportRecette(r);
        }
        private void MontantRapportRecette(FormReceptionRapport r)
        {
            double sommeMontant = 0,
                sommePayeCDF = 0,
                sommePayeUSD = 0;
            for (int i = 0; i < r.dgvRecette.RowCount; i++)
            {
                con.Open();
                try
                {
                    valeur = 0;
                    if (r.dgvRecette.Rows[i].Cells[3].Value.ToString() == "service")
                        cmdtxt = @"SELECT COUNT(s.prixservice), SUM(s.prixservice)
                        FROM Service s
                        JOIN RecetteService rs 
                        ON rs.idservice = s.idservice 
                        JOIN Recette r 
                        ON r.idrecette = rs.idrecette 
                        WHERE r.idrecette = @idrecette";
                    else
                        cmdtxt = @"SELECT COUNT(s.prixunitaire), SUM(s.prixunitaire * rs.qtevendue)
                        FROM LigneStock s
                        JOIN RecetteProduit rs 
                        ON rs.idstock = s.idstock 
                        JOIN Recette r 
                        ON r.idrecette = rs.idrecette 
                        WHERE r.idrecette = @idrecette";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idrecette", r.dgvRecette.Rows[i].Cells[0].Value);

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (Convert.ToDouble(dr[0].ToString())>0)
                        r.dgvRecette.Rows[i].Cells[5].Value = dr[1].ToString();
                    else
                        r.dgvRecette.Rows[i].Cells[5].Value = valeur;
                    sommeMontant += Convert.ToDouble(r.dgvRecette.Rows[i].Cells[5].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                //Payé en CDF
                con.Open();
                try
                {
                    valeur = 0;
                    cmdtxt = @"SELECT COUNT(p.montant), SUM(p.montant)
                    FROM Payement p
                    JOIN Recette r 
                    ON r.idrecette = p.idrecette 
                    WHERE r.idrecette = @idrecette AND p.monnaie = 'CDF' AND p.raison_retrait is NULL";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idrecette", r.dgvRecette.Rows[i].Cells[0].Value);

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (Convert.ToDouble(dr[0].ToString()) > 0)
                        r.dgvRecette.Rows[i].Cells[6].Value = dr[1].ToString();
                    else
                        r.dgvRecette.Rows[i].Cells[6].Value = valeur;
                    sommePayeCDF += Convert.ToDouble(r.dgvRecette.Rows[i].Cells[6].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                
                //Payé en USD
                con.Open();
                try
                {
                    valeur = 0;
                    cmdtxt = @"SELECT COUNT(p.montant), SUM(p.montant)
                    FROM Payement p
                    JOIN Recette r 
                    ON r.idrecette = p.idrecette 
                    WHERE r.idrecette = @idrecette AND p.monnaie = 'USD' AND p.raison_retrait is NULL";

                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idrecette", r.dgvRecette.Rows[i].Cells[0].Value);

                    dr = cmd.ExecuteReader();
                    dr.Read();
                    if (Convert.ToDouble(dr[0].ToString()) > 0)
                        r.dgvRecette.Rows[i].Cells[7].Value = dr[1].ToString();
                    else
                        r.dgvRecette.Rows[i].Cells[7].Value = valeur;
                    sommePayeUSD += Convert.ToDouble(r.dgvRecette.Rows[i].Cells[7].Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            //Ligne total
            r.dgvRecette.Rows.Add();
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = "";
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = "";
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[2].Value = "";
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[3].Value = "";
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[4].Value = "Totaux";
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value = sommeMontant;
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[6].Value = sommePayeCDF;
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[7].Value = sommePayeUSD;
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
        }
        private int CompterPayementRecette(FormReceptionRapport r)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select COUNT(idpayement) from Payement where idrecette = @id", con);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(r.dgvRecette.CurrentRow.Cells[0].Value));
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
            r.btnSupprimer.Enabled = false;
            if(CompterPayementRecette(r)==0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Recette where idrecette = @id", con);
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(r.dgvRecette.CurrentRow.Cells[0].Value));

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
                r.dgvRecette.Rows.RemoveAt(r.dgvRecette.CurrentRow.Index);
            }
            else
                MessageBox.Show("Cette recette est déjà impliquée dans les payements,\npour raison de cohérence, elle ne peut être supprimée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            AfficherRapportRecette(r);
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
        public void AfficherRecette(FormRecette r, string motif)
        {
            con.Open();
            try
            {
                if(motif == "recherche")
                    cmd = new SqlCommand("SELECT idrecette, statut_facture, statut_caisse, categorie, type_payeur, idpayeur FROM Recette WHERE date_operation BETWEEN '" + r.dtpDateDe.Text + "' AND '" + r.dtpDateA.Text + "'", con);
                else
                    cmd = new SqlCommand("SELECT idrecette, statut_facture, statut_caisse, categorie, type_payeur, idpayeur FROM Recette WHERE statut_caisse is NULL AND date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                dr = cmd.ExecuteReader();
                r.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRecette.Rows.Add();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    r.dgvRecette.Rows[r.dgvRecette.RowCount - 1].Cells[7].Value = dr[5].ToString();

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            PayeurRecette(r.dgvRecette, 5, 6);
            MontantRecette(r.dgvRecette);
        }
        public void MontantRecette(DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                con.Open();
                try
                {
                    if (dgv.Rows[i].Cells[4].Value.ToString()=="service")
                        cmd = new SqlCommand("SELECT SUM(prixservice) FROM RecetteService, Service WHERE RecetteService.idservice = Service.idservice AND idrecette = '" + dgv.Rows[i].Cells[0].Value.ToString() + "'", con);
                    else
                        cmd = new SqlCommand("SELECT SUM(prixunitaire * qtevendue) FROM RecetteProduit, LigneStock WHERE RecetteProduit.idstock = LigneStock.idstock AND idrecette = '" + dgv.Rows[i].Cells[0].Value.ToString() + "'", con);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[2].Value = dr[0].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        public void PayeurRecette(DataGridView dgv, int col_typepayeur, int col_payeur)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[col_typepayeur].Value.ToString() == "passant")
                    cmd = new SqlCommand("SELECT nompayeur FROM Payeur, Recette WHERE Recette.idpayeur = Payeur.idpayeur AND idrecette = '" + dgv.Rows[i].Cells[0].Value.ToString() + "'", con);
                else
                    cmd = new SqlCommand("SELECT noms FROM Patient, Payeur, Recette WHERE Patient.idpatient = Payeur.idpatient AND Payeur.idpayeur = Recette.idpayeur AND idrecette = '" + dgv.Rows[i].Cells[0].Value.ToString() + "'", con);

                con.Open();
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[col_payeur].Value = dr[0].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        public void AjouterPayement(FormPayement p)
        {
            if(p.cboMonnaie.Text == "CDF")
            {
                for (int i = p.dgvCompte.RowCount - 1; i >= 0; i--)
                {
                    try
                    {
                        if (double.Parse(p.dgvCompte.Rows[i].Cells[2].Value.ToString()) >= 500)
                        {
                            p.idpayement = NouveauID("payement");
                            con.Open();
                            SqlTransaction tx = con.BeginTransaction();
                            try
                            {
                                if (p.categorie_recette == "Vente aux abonnés")
                                    cmd = new SqlCommand("INSERT INTO Payement(idpayement, montant, monnaie, date_operation, numcompte) values (@idpayement, @montant, @monnaie, @date_operation, @numcompte)", con);
                                else
                                {
                                    cmd = new SqlCommand("INSERT INTO Payement(idpayement, montant, monnaie, date_operation, idpayeur, idrecette, numcompte) values (@idpayement, @montant, @monnaie, @date_operation, @idpayeur, @idrecette, @numcompte)", con);
                                    cmd.Parameters.AddWithValue("@idpayeur", p.idpayeur);
                                    cmd.Parameters.AddWithValue("@idrecette", p.idrecette);
                                }
                                cmd.Parameters.AddWithValue("@idpayement", p.idpayement);
                                cmd.Parameters.AddWithValue("@montant", double.Parse(p.dgvCompte.Rows[i].Cells[2].Value.ToString()));
                                cmd.Parameters.AddWithValue("@monnaie", p.cboMonnaie.Text);
                                cmd.Parameters.AddWithValue("@date_operation", p.lblDateOperation.Text);
                                cmd.Parameters.AddWithValue("@numcompte", p.dgvCompte.Rows[i].Cells[0].Value.ToString());
                                cmd.Transaction = tx;
                                cmd.ExecuteNonQuery();
                                tx.Commit();
                                p.ajout_valide = true;
                            }
                            catch (Exception ex)
                            {
                                tx.Rollback();
                                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            con.Close();
                        }
                        else
                            p.dgvCompte.Rows.RemoveAt(p.dgvCompte.Rows[i].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Vérifiez que le montant sur la ligne " + (i + 1) + " soit au moins 500 CDF", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                for (int i = p.dgvCompte.RowCount - 1; i >= 0; i--)
                {
                    try
                    {
                        if (double.Parse(p.dgvCompte.Rows[i].Cells[2].Value.ToString()) >= 1)
                        {
                            p.idpayement = NouveauID("payement");
                            con.Open();
                            SqlTransaction tx = con.BeginTransaction();
                            try
                            {
                                if (p.categorie_recette == "Vente aux abonnés")
                                    cmd = new SqlCommand("INSERT INTO Payement(idpayement, montant, monnaie, date_operation, numcompte) values (@idpayement, @montant, @monnaie, @date_operation, @numcompte)", con);
                                else
                                {
                                    cmd = new SqlCommand("INSERT INTO Payement(idpayement, montant, monnaie, date_operation, idpayeur, idrecette, numcompte) values (@idpayement, @montant, @monnaie, @date_operation, @idpayeur, @idrecette, @numcompte)", con);
                                    cmd.Parameters.AddWithValue("@idpayeur", p.idpayeur);
                                    cmd.Parameters.AddWithValue("@idrecette", p.idrecette);
                                }
                                cmd.Parameters.AddWithValue("@idpayement", p.idpayement);
                                cmd.Parameters.AddWithValue("@montant", double.Parse(p.dgvCompte.Rows[i].Cells[2].Value.ToString()));
                                cmd.Parameters.AddWithValue("@monnaie", p.cboMonnaie.Text);
                                cmd.Parameters.AddWithValue("@date_operation", p.lblDateOperation.Text);
                                cmd.Parameters.AddWithValue("@numcompte", p.dgvCompte.Rows[i].Cells[0].Value.ToString());
                                cmd.Transaction = tx;
                                cmd.ExecuteNonQuery();
                                tx.Commit();
                                p.ajout_valide = true;
                            }
                            catch (Exception ex)
                            {
                                tx.Rollback();
                                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            con.Close();
                        }
                        else
                            p.dgvCompte.Rows.RemoveAt(p.dgvCompte.Rows[i].Index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Vérifiez que le montant sur la ligne " + (i + 1) + " soit au moins 1 USD", "Attention!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            if (p.ajout_valide)
            {
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ImprimerBon(p);
            }
        }
        public void MAJStatutCaisseRecette(int idrecette, string motif)
        {
            con.Open();
            try
            {
                if (motif == "OK")
                    cmd = new SqlCommand("UPDATE Recette SET statut_caisse = 'OK' WHERE idrecette = "+idrecette+"", con);
                else
                    cmd = new SqlCommand("UPDATE Recette SET statut_caisse = NULL WHERE idrecette = " + idrecette + "", con); 
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void MAJRecetteServi(int idrecette, string categorie, int id, int idutilisateur, string statut)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(statut == "OK")
                {
                    if (categorie == "service")
                        cmd = new SqlCommand("UPDATE RecetteService SET servi = 'OK', idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + " AND idservice = '" + id + "'", con);
                    else
                        cmd = new SqlCommand("UPDATE RecetteProduit SET servi = 'OK', idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + " AND idstock = '" + id + "'", con);
                }
                else
                {
                    if (categorie == "service")
                        cmd = new SqlCommand("UPDATE RecetteService SET servi = NULL, idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + " AND idservice = '" + id + "'", con);
                    else
                        cmd = new SqlCommand("UPDATE RecetteProduit SET servi = NULL, idutilisateur = '" + idutilisateur + "' WHERE idrecette = " + idrecette + " AND idstock = '" + id + "'", con);
                }
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EcritureComptable(FormRecette b)
        {
            b.idrecette = int.Parse(b.dgvRecette.CurrentRow.Cells[0].Value.ToString());

            if (b.dgvRecette.CurrentRow.Cells[4].Value.ToString() == "service")
            {                
                if (b.dgvCompte.RowCount != 0)
                {
                    //Operation comptable
                    b.idoperation = NouveauID("operation");
                    if (AjouterOperation(b.idoperation, b.lblDateOperation.Text, string.Format("R_{0}", b.idrecette), TrouverId("typejournal", b.caisse), b.idexercice, b.idrecette, "recette"))
                    {
                        for (int i = 0; i < b.dgvCompte.RowCount; i++)
                        {
                            valeur = double.Parse(b.dgvCompte.Rows[i].Cells[2].Value.ToString());
                            if (b.numcompte == "571201") //perçu en USD
                                AjouterEcriture(b.idoperation, b.numcompte, b.dgvCompte.Rows[i].Cells[0].Value.ToString(), (valeur / b.taux), valeur, "Vente - service");
                            else
                                AjouterEcriture(b.idoperation, b.numcompte, b.dgvCompte.Rows[i].Cells[0].Value.ToString(), valeur, valeur, "Vente - service");
                        }
                    }
                    b.dgvCompte.Rows.Clear();
                }
                else
                    MessageBox.Show("Aucune écriture comptable n'est faite", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //débiter la caissse au crédit du comptre de ventes de produits ph.
                b.idoperation = NouveauID("operation");
                if (AjouterOperation(b.idoperation, b.lblDateOperation.Text, string.Format("R_{0}", b.idrecette), TrouverId("typejournal", b.caisse), b.idexercice, b.idrecette, "recette"))
                {
                    valeur = double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString());
                    if (b.numcompte == "571201") //perçu en USD
                        AjouterEcriture(b.idoperation, b.numcompte, "701100", (valeur / b.taux), valeur, "Vente - produit");
                    else
                        AjouterEcriture(b.idoperation, b.numcompte, "701100", valeur, valeur, "Vente - produit");
                }
            }
            MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ValiderPayement(FormRecette b, FormPayement p)
        {
            b.btnValider.Enabled = false;
            //Ajouter le payement
            if (b.total_payement < double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString()))
            {
                p.idrecette = int.Parse(b.dgvRecette.CurrentRow.Cells[0].Value.ToString());
                p.statut_recette = b.dgvRecette.CurrentRow.Cells[1].Value.ToString();
                p.categorie_recette = "Vente au cash - " + b.dgvRecette.CurrentRow.Cells[4].Value.ToString();
                p.montant_recette = double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString());
                p.txtMontant.Text = b.dgvRecette.CurrentRow.Cells[2].Value.ToString();
                p.lblDateOperation.Text = b.lblDateOperation.Text;
                p.txtPayeur.Text = b.dgvRecette.CurrentRow.Cells[6].Value.ToString();
                p.idpayeur = int.Parse(b.dgvRecette.CurrentRow.Cells[7].Value.ToString());
                p.taux = b.taux;
                p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboMonnaie.Text = b.cboMonnaie.Text;
                p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
                p.cboMonnaie.Enabled = false;
                p.label4.Visible = false;
                p.cboAnnulation.Visible = false;
                p.dgvCompte.ReadOnly = true;

                TrouverCompteRecette(p.dgvCompte, p.idrecette);

                p.ShowDialog();
                if(p.fermeture_succes)
                {
                    //MAJ statut caisse de la recette
                    MAJStatutCaisseRecette(b.idrecette, "OK");

                    //Passer les ecritures
                    EcritureComptable(b);
                }
                AfficherRecette(b, "");
                SoldesCaisse(b.lblCaisseCDF, b.lblCaisseUSD, "recette");
            }
            else
                MessageBox.Show("Payement non autorisé pour une recette payée totalement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);           
        }
        public void PayerRecetteDiffere(FormRecette b, FormPayement p)
        {
            b.btnPayer.Enabled = false;
            if (b.total_payement < double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString()))
            {
                if(b.dgvCompte.RowCount != 0)
                {
                    p.idrecette = int.Parse(b.dgvRecette.CurrentRow.Cells[0].Value.ToString());
                    p.statut_recette = b.dgvRecette.CurrentRow.Cells[1].Value.ToString();
                    p.categorie_recette = "Vente - " + b.dgvRecette.CurrentRow.Cells[4].Value.ToString();
                    p.montant_recette = double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString());
                    p.lblDateOperation.Text = b.lblDateOperation.Text;
                    p.txtPayeur.Text = b.dgvRecette.CurrentRow.Cells[6].Value.ToString();
                    p.idpayeur = int.Parse(b.dgvRecette.CurrentRow.Cells[7].Value.ToString());
                    p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
                    p.cboMonnaie.Text = b.cboMonnaie.Text;
                    p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
                    p.cboMonnaie.Enabled = false;
                    p.taux = b.taux;
                    p.numcompteDiffere = "4711";
                    p.label4.Visible = false;
                    p.cboAnnulation.Visible = false;
                    for (int i = 0; i < b.dgvCompte.RowCount; i++)
                    {
                        p.dgvCompte.Rows.Add();
                        p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[0].Value = b.dgvCompte.Rows[i].Cells[0].Value;
                        p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[1].Value = b.dgvCompte.Rows[i].Cells[1].Value;
                        p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[2].Value = "0";
                    }
                    p.ShowDialog();
                    if(p.fermeture_succes)
                    {
                        p.idoperation = NouveauID("operation");
                        if (AjouterOperation(p.idoperation, p.lblDateOperation.Text, string.Format("R_{0}", p.idrecette), TrouverId("typejournal", p.caisse), b.idexercice, p.idrecette, "recette"))
                        {
                            valeur = double.Parse(p.txtMontant.Text);
                            if (p.cboMonnaie.Text == "USD") //perçu en USD
                                AjouterEcriture(p.idoperation, p.numcompte, p.numcompteDiffere, (valeur / p.taux), valeur, p.categorie_recette);
                            else
                                AjouterEcriture(p.idoperation, p.numcompte, p.numcompteDiffere, valeur, valeur, p.categorie_recette);
                        }
                    }
                    AfficherRecette(b, "");
                    SoldesCaisse(b.lblCaisseCDF, b.lblCaisseUSD, "recette");
                }
                else
                    MessageBox.Show("Payement recette non autorisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Payement non autorisé pour une recette payée totalement", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void PayementAbonne(FormTresoEntree t, FormPayement p)
        {
            p.idrecette = 0;
            p.statut_recette = "différé";
            p.categorie_recette = "Payement - abonnés";
            p.montant_recette = double.Parse(t.txtMontant.Text);//Ne considérer que ce qu'on paye
            p.lblDateOperation.Text = t.lblDateOperation.Text;
            p.txtPayeur.Text = t.dgvBon.CurrentRow.Cells[1].Value.ToString();
            p.idpayeur = 0;
            p.taux = t.taux;
            p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboMonnaie.Text = t.cboCaisseDepense.Text;
            p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
            p.numcompteDiffere = t.dgvBon.CurrentRow.Cells[0].Value.ToString();
            p.cboMonnaie.Enabled = false;
            p.numcompte = t.numcompte;
            p.txtMontant.Text = t.txtMontant.Text;
            p.label4.Visible = false;
            p.cboAnnulation.Visible = false;
            p.dgvCompte.ReadOnly = true;

            p.dgvCompte.Rows.Add();
            p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[0].Value = t.dgvBon.CurrentRow.Cells[0].Value;
            p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[1].Value = t.dgvBon.CurrentRow.Cells[1].Value;
            p.dgvCompte.Rows[p.dgvCompte.RowCount - 1].Cells[2].Value = t.txtMontant.Text;

            p.ShowDialog();
            if (p.fermeture_succes)
            {
                p.idoperation = NouveauID("operation");
                if (AjouterOperation(p.idoperation, p.lblDateOperation.Text, string.Format("P_{0}", p.idpayement), TrouverId("typejournal", "ventes"), t.idexercice, 0, ""))
                {
                    valeur = double.Parse(p.txtMontant.Text);
                    if (p.cboMonnaie.Text == "USD") //perçu en USD
                        AjouterEcriture(p.idoperation, p.numcompte, p.numcompteDiffere, valeur, (valeur * p.taux), p.categorie_recette);
                    else
                        AjouterEcriture(p.idoperation, p.numcompte, p.numcompteDiffere, valeur, valeur, p.categorie_recette);
                }
            }
            p.Close();
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
                        AjouterPayement(p);
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
        private void TrouverCompteRecette(DataGridView dgv, int idrecette)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT Service.numcompte, libellecompte, SUM(prixservice) FROM RecetteService, Service, Compte WHERE RecetteService.idservice = Service.idservice and Service.numcompte = Compte.numcompte and RecetteService.idrecette = '"+idrecette+"' GROUP BY Service.numcompte, libellecompte", con);
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void TrouverPayementRecette(FormRecette b)
        {
            cmd = new SqlCommand("SELECT idpayement, montant, monnaie FROM Payement WHERE idrecette = '" + b.idrecette + "' AND raison_retrait is NULL", con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                b.dgvPayement.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvPayement.Rows.Add();
                    b.dgvPayement.Rows[b.dgvPayement.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvPayement.Rows[b.dgvPayement.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvPayement.Rows[b.dgvPayement.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            b.dgvTotaux.Rows.Clear();
            if (b.dgvPayement.RowCount != 0) 
                CalculerTotauxPayement(b);
            TrouverCompteRecette(b.dgvCompte, b.idrecette);
        }
        private void CalculerTotauxPayement(FormRecette b)
        {
            cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE idrecette = '" + b.idrecette + "' AND raison_retrait is NULL GROUP BY monnaie", con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                b.dgvTotaux.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvTotaux.Rows.Add();
                    b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
                b.dgvTotaux.Rows.Add();
                b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[0].Value = "T.CDF";
                if(b.dgvTotaux.RowCount == 2)
                {
                    b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 2].Cells[1].Value;
                }
                else
                    b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value = double.Parse(b.dgvTotaux.Rows[0].Cells[1].Value.ToString()) + double.Parse(b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 2].Cells[1].Value.ToString()) * b.taux;
                b.total_payement = 0;
                if (b.dgvPayement.RowCount != 0)
                    b.total_payement = double.Parse(b.dgvTotaux.Rows[b.dgvTotaux.RowCount - 1].Cells[1].Value.ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void AnnulerPayement(FormRecette b, FormPayement p)
        {
            p.idpayement = int.Parse(b.dgvPayement.CurrentRow.Cells[0].Value.ToString());
            
            p.statut_recette = b.dgvRecette.CurrentRow.Cells[1].Value.ToString();
            p.categorie_recette = b.dgvRecette.CurrentRow.Cells[4].Value.ToString();
            p.montant_recette = double.Parse(b.dgvRecette.CurrentRow.Cells[2].Value.ToString());
            p.lblDateOperation.Text = b.lblDateOperation.Text;
            p.txtPayeur.Text = b.dgvRecette.CurrentRow.Cells[6].Value.ToString();
            p.idpayeur = int.Parse(b.dgvRecette.CurrentRow.Cells[7].Value.ToString());
            p.taux = b.taux;
            p.txtMontant.Text = b.dgvPayement.CurrentRow.Cells[1].Value.ToString();
            p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboMonnaie.Text = b.dgvPayement.CurrentRow.Cells[2].Value.ToString();
            p.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
            p.txtMontant.Enabled = false;
            p.cboMonnaie.Enabled = false;
            p.btnAjouter.Text = "Valider";
            p.cboAnnulation.Focus();

            p.ShowDialog();
            if(p.fermeture_succes)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Payement SET raison_retrait = '" + p.raison_retrait + "' WHERE idpayement = " + p.idpayement + "", con);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Opération effectuée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                //Envoyer un message au comptable pour corriger l'ecriture relative 
                //à cette recette pour annulation
            }
        }
        public int CompterRecetteBon(string motif, int numbon)
        {
            id = 0;
            con.Open();
            try
            {
                if(motif=="service") cmd = new SqlCommand("select count(idrecette) from RecetteService where numbon = @numbon", con);
                else cmd = new SqlCommand("select count(idrecette) from RecetteProduit where numbon = @numbon", con);
                cmd.Parameters.AddWithValue("@numbon", numbon);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void ImprimerBon(FormPayement p)
        {
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
            b.dgvProduitService.Rows[0].Cells[1].Value = TrouverTotal("produit", "CDF", b, "");
            b.dgvProduitService.Rows[0].Cells[2].Value = TrouverTotal("produit", "USD", b, "");

            b.dgvProduitService.Rows[1].Cells[0].Value = "Services";
            b.dgvProduitService.Rows[1].Cells[1].Value = TrouverTotal("service", "CDF", b, "");
            b.dgvProduitService.Rows[1].Cells[2].Value = TrouverTotal("service", "USD", b, "");

            b.dgvProduitService.Rows[2].Cells[0].Value = "Totaux";
            b.dgvProduitService.Rows[2].Cells[1].Value = double.Parse(b.dgvProduitService.Rows[0].Cells[1].Value.ToString()) + double.Parse(b.dgvProduitService.Rows[1].Cells[1].Value.ToString());
            b.dgvProduitService.Rows[2].Cells[2].Value = double.Parse(b.dgvProduitService.Rows[0].Cells[2].Value.ToString()) + double.Parse(b.dgvProduitService.Rows[1].Cells[2].Value.ToString());
        }
        public double TrouverTotal(string categorie, string monnaie, FormRecetteJournal b, string motif)
        {
            valeur = 0;
            con.Open();
            try
            {
                if(motif == "categorieservice")
                    cmd = new SqlCommand("SELECT COUNT(montant), SUM(montant) FROM Payement WHERE numcompte = '" + categorie + "' AND raison_retrait is NULL AND monnaie = '" + monnaie + "' AND Payement.date_operation BETWEEN '" + b.dtpDateDe.Text + "' AND '" + b.dtpDateA.Text + "'", con);
                else
                    cmd = new SqlCommand("SELECT COUNT(montant), SUM(montant) FROM Payement, Recette WHERE Payement.idrecette = Recette.idrecette AND categorie = '" + categorie + "' AND raison_retrait is NULL AND monnaie = '" + monnaie + "' AND Payement.date_operation BETWEEN '" + b.dtpDateDe.Text + "' AND '" + b.dtpDateA.Text + "'", con);
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
        public void ChargerRubriquesRecette(FormRecetteJournal b)
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
                    b.dgvRecette.Rows[i].Cells[2].Value = TrouverTotal("produit", "CDF", b, "");
                    b.dgvRecette.Rows[i].Cells[3].Value = TrouverTotal("produit", "USD", b, "");
                }
                else
                {
                    b.dgvRecette.Rows[i].Cells[2].Value = TrouverTotal(b.dgvRecette.Rows[i].Cells[0].Value.ToString(), "CDF", b, "categorieservice");
                    b.dgvRecette.Rows[i].Cells[3].Value = TrouverTotal(b.dgvRecette.Rows[i].Cells[0].Value.ToString(), "USD", b, "categorieservice");
                }
            }
        }

        public void AfficherPayement(FormPayements r)
        {
            if (r.cboMonnaie.Text != "")
            {
                cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, py.nompayeur, p.raison_retrait
                FROM Payement p
                JOIN Payeur py
                ON p.idpayeur = py.idpayeur
                WHERE py.nompayeur != 'patient' AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie
                UNION
                SELECT idpayement,date_operation,montant,monnaie, pa.noms, p.raison_retrait
                FROM Payement p
                JOIN Payeur py
                ON p.idpayeur = py.idpayeur
                JOIN Patient pa
                ON py.idpatient = pa.idpatient
                WHERE py.nompayeur = 'patient' AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@monnaie", r.cboMonnaie.Text);
            }
            else
            {
                cmdtxt = @"SELECT idpayement,date_operation,montant,monnaie, py.nompayeur, p.raison_retrait
                FROM Payement p
                JOIN Payeur py
                ON p.idpayeur = py.idpayeur
                WHERE py.nompayeur != 'patient' AND date_operation BETWEEN @dateDe AND @dateA
                UNION
                SELECT idpayement,date_operation,montant,monnaie, pa.noms, p.raison_retrait
                FROM Payement p
                JOIN Payeur py
                ON p.idpayeur = py.idpayeur
                JOIN Patient pa
                ON py.idpatient = pa.idpatient
                WHERE py.nompayeur = 'patient' AND date_operation BETWEEN @dateDe AND @dateA";
                cmd = new SqlCommand(cmdtxt, con);
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
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    r.dgvPayement.Rows[r.dgvPayement.RowCount - 1].Cells[5].Value = dr[5].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

            //Ajouter les colonnes totaux
            if (r.cboMonnaie.Text != "")
            {
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE idpayeur IS NOT NULL AND idrecette IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                cmd.Parameters.AddWithValue("@monnaie", r.cboMonnaie.Text);
            }
            else
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Payement WHERE idpayeur IS NOT NULL AND idrecette IS NOT NULL AND date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
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
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
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
        public void AfficherRecetteProduit(FormPhamaVente p, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    cmdtxt = @"SELECT idrecette, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    WHERE r.type_payeur != 'patient' AND statut_caisse = 'OK' 
                    AND categorie = 'produit' AND date_operation BETWEEN @dateDe AND @dateA
                    UNION
                    SELECT idrecette, pa.noms 
                    FROM Recette r
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    JOIN Patient pa ON p.idpatient = pa.idpatient
                    WHERE r.type_payeur = 'patient' AND statut_caisse = 'OK' 
                    AND categorie = 'produit' AND date_operation BETWEEN @dateDe AND @dateA";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dateDe", p.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", p.dtpDateA.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idrecette, p.nompayeur 
                    FROM Recette r
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    WHERE r.type_payeur != 'patient' AND statut_caisse = 'OK' 
                    AND categorie = 'produit' AND date_operation = @datejour
                    UNION
                    SELECT idrecette, pa.noms 
                    FROM Recette r
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    JOIN Patient pa ON p.idpatient = pa.idpatient
                    WHERE r.type_payeur = 'patient' AND statut_caisse = 'OK' 
                    AND categorie = 'produit' AND date_operation = @datejour";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@datejour", DateTime.Now.ToShortDateString());
                }
                dr = cmd.ExecuteReader();
                p.dgvRecette.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvRecette.Rows.Add();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvRecette.Rows[p.dgvRecette.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

        }
        public void RecetteProduit(FormPhamaVente p)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT rp.idstock, p.nomproduit, forme, dosage, qtevendue, sp.qtestock, servi, idstockph 
                FROM RecetteProduit rp
                JOIN LigneStock s ON rp.idstock = s.idstock
                JOIN LigneStockPharma sp ON s.idstock = sp.idstock
                JOIN Produit p ON s.idproduit = p.idproduit
                WHERE idrecette = @idrecette AND idpharma = @idpharma";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idrecette", p.idrecette);
                cmd.Parameters.AddWithValue("@idpharma", p.idpharma);
                dr = cmd.ExecuteReader();
                p.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvStock.Rows.Add();
                    p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[1].Value = string.Format("{0} {1} {2}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[2].Value = dr[4].ToString();
                    if (dr[5].ToString() != "")
                        p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[3].Value = dr[5].ToString();
                    else
                        p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[3].Value = "0";
                    p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[4].Value = dr[6].ToString();
                    p.dgvStock.Rows[p.dgvStock.RowCount - 1].Cells[5].Value = dr[7].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        private void MiseAjourRecetteProduit(FormPhamaVente p, string motif)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (motif == "OK")
                    cmd = new SqlCommand("UPDATE RecetteProduit SET servi = 'OK', idutilisateur = '" + p.idutilisateur + "' WHERE idrecette = '" + p.idrecette + "' AND idstock = '"+p.dgvStock.CurrentRow.Cells[0].Value.ToString()+"'", con);
                else
                    cmd = new SqlCommand("UPDATE RecetteProduit SET servi = NULL, idutilisateur = '" + p.idutilisateur + "' WHERE idrecette = '" + p.idrecette + "' AND idstock = '" + p.dgvStock.CurrentRow.Cells[0].Value.ToString() + "'", con);
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
        public void ServirRecette(FormPhamaVente p, string motif)
        {
            if(p.dgvStock.RowCount != 0)
            {
                
                if (motif == "OK")
                {
                    if (int.Parse(p.dgvStock.CurrentRow.Cells[3].Value.ToString()) > int.Parse(p.dgvStock.CurrentRow.Cells[2].Value.ToString()))
                    {
                        cs.MiseAjourQteStock(int.Parse(p.dgvStock.CurrentRow.Cells[5].Value.ToString()), int.Parse(p.dgvStock.CurrentRow.Cells[2].Value.ToString()), "pharmacie");
                        MiseAjourRecetteProduit(p, motif);
                        RecetteProduit(p);
                    }
                    else
                        MessageBox.Show("Stock insuffisant", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cs.MiseAjourQteStock(int.Parse(p.dgvStock.CurrentRow.Cells[5].Value.ToString()), -int.Parse(p.dgvStock.CurrentRow.Cells[2].Value.ToString()), "pharmacie");
                    MiseAjourRecetteProduit(p, motif);
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
        public void AgendaCaisse(FormRecette b, FormAgendaCaisse a)
        {
            a.numcompte = TrouverId("numcompte", b.caisse).ToString();
            a.lblDateOperation.Text = b.lblDateOperation.Text;
            a.lblTaux.Text = b.lblTaux.Text;
            a.txtPayeur.Text = b.dgvRecette.CurrentRow.Cells[3].Value.ToString();
            a.txtNumBon.Text = b.dgvRecette.CurrentRow.Cells[0].Value.ToString();
            //a.txtMontantTotal.Text = b.txtTotal.Text;
            a.txtReste.Text = (double.Parse(a.txtMontantTotal.Text) - MontantAgendaCaisse(int.Parse(a.txtNumBon.Text))).ToString();
            a.ShowDialog();
            //b.txtTotal.Text = a.txtMontantPaye.Text;
            //ImprimerBon(b, new FormImpression());
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
        public void Afficher(FormAgendaCaisse a, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    cmd = new SqlCommand("select * from AgendaCaisse where idligne= @idligne", con);
                    cmd.Parameters.AddWithValue("@idligne", a.dgvBon.CurrentRow.Cells[0].Value.ToString());
                }
                else
                {
                    cmd = new SqlCommand("select * from AgendaCaisse where numbon= @numbon", con);
                    cmd.Parameters.AddWithValue("@numbon", a.txtNumBon.Text);
                }
                dr = cmd.ExecuteReader();
                a.dgvBon.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvBon.Rows.Add();
                    a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    if(a.dgvBon.RowCount > 1)
                        a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[4].Value = double.Parse(a.dgvBon.Rows[a.dgvBon.RowCount - 2].Cells[4].Value.ToString()) - double.Parse(a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[3].Value.ToString());
                    else
                        a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[4].Value = double.Parse(a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[2].Value.ToString()) - double.Parse(a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[3].Value.ToString());
                    a.dgvBon.Rows[a.dgvBon.RowCount - 1].Cells[5].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Annuler(FormAgendaCaisse a)
        {
            a.txtPayeur.Text = "";
            a.txtNumBon.Text = "";
            a.txtMontantTotal.Text = "";
            a.txtReste.Text = "";
            a.txtMontantPaye.Text = "";
            a.btnModifier.Enabled = false;
            a.btnSupprimer.Enabled = false;
            a.btnEnregistrer.Enabled = true;
        }
        public void Recuperer(FormAgendaCaisse a)
        {
            if (a.dgvBon.RowCount != 0)
            {
                a.btnModifier.Enabled = true;
                a.btnSupprimer.Enabled = true;
                a.btnEnregistrer.Enabled = false;
                a.txtNumBon.Text = a.dgvBon.CurrentRow.Cells[1].Value.ToString();
                a.txtMontantTotal.Text = a.dgvBon.CurrentRow.Cells[2].Value.ToString();
                a.txtMontantPaye.Text = double.Parse(a.dgvBon.CurrentRow.Cells[3].Value.ToString()).ToString();
                a.txtReste.Text = a.dgvBon.CurrentRow.Cells[4].Value.ToString();
                a.lblDateOperation.Text = a.dgvBon.CurrentRow.Cells[5].Value.ToString();
                if (a.txtMontantPaye.Text == "0")
                    a.txtMontantPaye.Enabled = false;
                else
                    a.txtMontantPaye.Select();
            }
        }
        public void Modifier(FormAgendaCaisse a)
        {
            id = int.Parse(a.dgvBon.CurrentRow.Cells[0].Value.ToString());
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update AgendaCaisse set montantpaye = @montantpaye where idligne = @idligne", con);
                cmd.Parameters.AddWithValue("@idligne", id);
                cmd.Parameters.AddWithValue("@montantpaye", a.txtMontantPaye.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            MiseAjourRegulation(id, a.idoperation, "Modifier");
            Afficher(a, "");
            Annuler(a);
        }
        public void Supprimer(FormAgendaCaisse a)
        {
            id = int.Parse(a.dgvBon.CurrentRow.Cells[0].Value.ToString());
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
            a.dgvBon.Rows.RemoveAt(a.dgvBon.CurrentRow.Index);
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
        public void PayementDette(FormAgendaCaisse a)
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
        public void AfficherSousForm(MFormTreso d, FormTresoSortie childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

                if (d.activeForm != null)
                    d.activeForm.Close();
                d.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                d.pnlChildForm.Controls.Add(childForm);
                d.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public void AfficherSousForm(MFormTreso d, FormTresoEntree childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

                if (d.activeForm != null)
                    d.activeForm.Close();
                d.activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                d.pnlChildForm.Controls.Add(childForm);
                d.pnlChildForm.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
        }
        public void AfficherSousForm(MFormTreso d, FormTresoJournal childForm)
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
            childForm.Show();
        }
        public void ChargerCompte(FormComptaPlan d)
        {
            con.Open();
            try
            {
                if (d.cboClasse.Text != "" && d.txtRecherche.Text == "")
                    cmd = new SqlCommand("select numcompte, libellecompte from Compte Where categorie = 'P' and numcompte like '" + d.cboClasse.Text + "%' order by libellecompte", con);
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
                cmd = new SqlCommand("select numcompte, libellecompte from Compte where numcompte like '" + c.numcompte + "%' and categorie = 'U' order by libellecompte", con);
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
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(d.txtMontant.Text) * d.taux;
                else if (d.cboCaisseDepense.Text == "USD" && d.cboMonnaie.Text == "CDF")
                {
                    if ((double.Parse(d.txtMontant.Text) / d.taux) >= 5)
                    {
                        d.txtMontant.Text = ((int)(double.Parse(d.txtMontant.Text) / d.taux) * d.taux).ToString();
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = (int)(double.Parse(d.txtMontant.Text) / d.taux);                        
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
                    d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(d.txtMontant.Text) * d.taux;
                else if (d.cboCaisseDepense.Text == "USD" && d.cboMonnaie.Text == "CDF")
                {
                    if ((double.Parse(d.txtMontant.Text) / d.taux) >= 5)
                    {
                        d.txtMontant.Text = ((int)(double.Parse(d.txtMontant.Text) / d.taux) * d.taux).ToString();
                        d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[2].Value = (int)(double.Parse(d.txtMontant.Text) / d.taux);
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
                    valeur = double.Parse(txt.Text);
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
        }
        private void AjouterDepense(FormTresoSortie d)
        {
            //Bon
            d.numbon = NouveauID("bondepense");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into BonDepense values (@numbon, @date_operation, @beneficiaire, @refrequisition)", con);
                cmd.Parameters.AddWithValue("@numbon", d.numbon);
                cmd.Parameters.AddWithValue("@date_operation", d.lblDateOperation.Text);
                cmd.Parameters.AddWithValue("@beneficiaire", d.txtBeneficiaire.Text);
                cmd.Parameters.AddWithValue("@refrequisition", d.txtNumRequisition.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Depense enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            //Depenses
            for (int i = 0; i < d.dgvEcriture.RowCount - 1; i++)
            {
                d.iddepense = NouveauID("depense");
                con.Open();
                tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Depense values (@iddepense, @numcompte, @motifdepense, @montant, @monnaie, @numbon)", con);
                    cmd.Parameters.AddWithValue("@iddepense", d.iddepense);
                    cmd.Parameters.AddWithValue("@numcompte", d.dgvEcriture.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@motifdepense", d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@montant", d.dgvEcriture.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@monnaie", d.cboCaisseDepense.Text);
                    cmd.Parameters.AddWithValue("@numbon", d.numbon);
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
        public void Enregistrer(FormTresoSortie d)
        {
            if (d.dgvEcriture.RowCount != 0 && d.txtBeneficiaire.Text != "" && d.cboCaisseDepense.Text != "" && d.txtNumRequisition.Text != "")
            {
                d.montantdecaisse = double.Parse(d.dgvEcriture.Rows[d.dgvEcriture.RowCount-1].Cells[3].Value.ToString());
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
                    //Bon et dépenses
                    AjouterDepense(d);

                    //Ecriture comptables
                    d.idoperation = NouveauID("operation");
                    if (AjouterOperation(d.idoperation, d.lblDateOperation.Text, string.Format("D_{0}", d.numbon), TrouverId("typejournal", d.caisse), d.idexercice, d.numbon, "dépense"))
                    {
                        for (int i = 0; i < d.dgvEcriture.RowCount-1; i++)
                        {
                            if(d.cboCaisseDepense.Text == "CDF")
                                DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value), d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                            else
                                DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value) * d.taux, d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                        }
                        CrediterCompte(d.idoperation, d.numcompte, d.montantdecaisse, d.dgvEcriture.Rows[d.dgvEcriture.RowCount-1].Cells[1].Value.ToString());
                    }
                    ArchiverBon("dépense", d.numbon);
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
        
        public void ImprimerBon(FormTresoSortie d, FormImpression imp)
        {
            imp.numbon = d.iddepense;
            imp.beneficiaire = d.txtBeneficiaire.Text;
            imp.montantlettre = d.txtMontantLettre.Text;
            imp.montantchiffre = d.montantdecaisse.ToString();
            imp.monnaie = d.cboCaisseDepense.Text;
            imp.motif = d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value.ToString();
            imp.date_jour = d.lblDateOperation.Text;
            imp.bonrequisition = d.txtNumRequisition.Text;

            ReportParameter[] rparams = new ReportParameter[]
            {
                new ReportParameter("numbon", imp.numbon.ToString()),
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
                        d.idoperation = NouveauID("operation");
                        if (AjouterOperation(d.idoperation, d.lblDateOperation.Text, "recettes CDF", TrouverId("typejournal", d.caisse), d.idexercice, 0, ""))
                        {
                            AjouterEcriture(d.idoperation, "585000", "571101", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes CDF");
                            AjouterEcriture(d.idoperation, "571102", "585000", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes CDF");
                        }
                    }
                    else if (d.dgvBon.Rows[i].Cells[0].Value.ToString() == "571201")
                    {
                        //AjouterOperation()
                        d.caisse = "Caisse en USD Dépenses";
                        d.idoperation = NouveauID("operation");
                        if (AjouterOperation(d.idoperation, d.lblDateOperation.Text, "recettes USD", TrouverId("typejournal", d.caisse), d.idexercice, 0, ""))
                        {
                            AjouterEcriture(d.idoperation, "585000", "571201", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()) * d.taux, double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), "Rapport de recettes USD");
                            AjouterEcriture(d.idoperation, "571202", "585000", double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()), double.Parse(d.dgvBon.Rows[i].Cells[2].Value.ToString()) * d.taux, "Rapport de recettes USD");
                        }
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
                        d.idoperation = NouveauID("operation");
                        if (AjouterOperation(d.idoperation, d.lblDateOperation.Text, "VIR CDF", TrouverId("typejournal", d.caisse), d.idexercice, 0, ""))
                        {
                            AjouterEcriture(d.idoperation, "585000", "521100", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text), "Virement en CDF");
                            AjouterEcriture(d.idoperation, "571102", "585000", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text), "Virement en CDF");
                        }
                    }
                    else if (d.dgvBon.CurrentRow.Cells[0].Value.ToString() == "521500")
                    {
                        //AjouterOperation()
                        d.caisse = "Banque Equity USD";
                        d.idoperation = NouveauID("operation");
                        if (AjouterOperation(d.idoperation, d.lblDateOperation.Text, "VIR USD", TrouverId("typejournal", d.caisse), d.idexercice, 0, ""))
                        {
                            AjouterEcriture(d.idoperation, "585000", "521500", double.Parse(d.txtMontant.Text) * d.taux, double.Parse(d.txtMontant.Text), "Virement en USD");
                            AjouterEcriture(d.idoperation, "571202", "585000", double.Parse(d.txtMontant.Text), double.Parse(d.txtMontant.Text) * d.taux, "Virement en USD");
                        }
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
                    PayementAbonne(d, new FormPayement());
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
                    cmd = new SqlCommand("SELECT numcompte, libellecompte, debit - credit as solde FROM Compte WHERE numcompte LIKE '41110%' and numcompte != '411100' ", con);
                    d.cboCaisseDepense.Enabled = true;
                    d.dgvBon.Columns[2].Visible = false;
                }
                else if (d.cboEncaisser.Text == "rapport de recettes")
                {
                    cmd = new SqlCommand("SELECT numcompte, libellecompte, debit - credit as solde FROM Compte WHERE numcompte IN ('571101','571201')", con);
                    d.cboCaisseDepense.Enabled = false;
                    d.dgvBon.Columns[2].Visible = true;
                }
                else
                {
                    cmd = new SqlCommand("SELECT numcompte, libellecompte, debit - credit as solde FROM Compte WHERE numcompte LIKE '521%' AND categorie IN ('U', 'UU')", con);
                    d.cboCaisseDepense.Enabled = false;
                    d.dgvBon.Columns[2].Visible = false;
                }
                //else
                //    cmd = new SqlCommand("SELECT numcompte, libellecompte, debit - credit as solde FROM Compte WHERE numcompte IN ('585000')", con);
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
                        d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[2].Value = dr[2].ToString();                       
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
        }
        public void AfficherTresoRapport(FormTresoJournal d)
        {
            if (d.cboMonnaie.Text != "")
            {
                cmdtxt = @"SELECT iddepense,date_operation,montant,monnaie,beneficiaire,motifdepense,refrequisition 
                FROM BonDepense b
                JOIN Depense d
                ON b.numbon = d.numbon
                WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);
            }
            else
            {
                cmdtxt = @"SELECT iddepense,date_operation,montant,monnaie,beneficiaire,motifdepense,refrequisition 
                FROM BonDepense b
                JOIN Depense d
                ON b.numbon = d.numbon
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
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    d.dgvBon.Rows[d.dgvBon.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

            //Ajouter les colonnes totaux
            if (d.cboMonnaie.Text != "")
            {
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Depense d JOIN BonDepense b ON d.numbon = b.numbon WHERE date_operation BETWEEN @dateDe AND @dateA AND monnaie = @monnaie GROUP BY monnaie", con);
                cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);               
            }
            else
                cmd = new SqlCommand("SELECT monnaie, SUM(montant) FROM Depense d JOIN BonDepense b ON d.numbon = b.numbon WHERE date_operation BETWEEN @dateDe AND @dateA GROUP BY monnaie", con);
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                        JOIN BonDepense b ON d.numbon = b.numbon 
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
                JOIN BonDepense b ON d.numbon = b.numbon 
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
            if(s.cboCatService.Text !="" && s.txtNomService.Text !="" && s.txtPrixService.Text !="")
            {
                s.idservice = NouveauID("service");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Service values (@id, @nom, @prix, @numcompte)", con);
                    cmd.Parameters.AddWithValue("@id", s.idservice);
                    cmd.Parameters.AddWithValue("@nom", s.txtNomService.Text);
                    cmd.Parameters.AddWithValue("@prix", s.txtPrixService.Text);
                    cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
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
                Afficher(s, "");
            }
            else
            {
                cmdStatut = false;
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormService s)
        {
            if (s.cboCatService.Text != "" && s.txtNomService.Text != "" && s.txtPrixService.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Service set nomservice= @nom, prixservice= @prix, numcompte= @numcompte where idservice = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idservice);
                    cmd.Parameters.AddWithValue("@nom", s.txtNomService.Text);
                    cmd.Parameters.AddWithValue("@prix", s.txtPrixService.Text);
                    cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
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
                Afficher(s, ""); 

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
            s.cboCatService.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboCatService.SelectedText = "";
            s.cboCatService.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtNomService.Text = "";
            s.txtPrixService.Text = "";
            s.btnModifier.Enabled = false;
            s.btnSupprimer.Enabled = false;
            s.btnEnregistrer.Enabled = true;
            s.dgvService.Rows.Clear();
            s.cboCatService.Select();
        }
        public void Afficher(FormService s, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (s.cboCatService.Text != "")
                    {
                        cmd = new SqlCommand("select * from Service where numcompte= @numcompte", con);
                        cmd.Parameters.AddWithValue("@numcompte", s.numcompte);
                    }
                    else if (s.cboCatService.Text == "" && s.txtNomService.Text != "")
                        cmd = new SqlCommand("select * from Service where nomservice like '" + s.txtNomService.Text + "%'", con);
                    if (s.cboCatService.Text != "" || s.cboCatService.Text == "" && s.txtNomService.Text != "")
                    {
                        dr = cmd.ExecuteReader();
                        s.dgvService.Rows.Clear();
                        while (dr.Read())
                        {
                            s.dgvService.Rows.Add();
                            s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        }
                    }
                    if (s.cboCatService.Text == "" && s.txtNomService.Text == "")
                        MessageBox.Show("Précisez la catégorie ou le service dont vous voulez afficher les résultats", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cmd = new SqlCommand("select * from Service where idservice= @idservice", con);
                    cmd.Parameters.AddWithValue("@idservice", s.idservice);
                    dr = cmd.ExecuteReader();
                    s.dgvService.Rows.Clear();
                    while (dr.Read())
                    {
                        s.dgvService.Rows.Add();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        s.dgvService.Rows[s.dgvService.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    }
                }                
            }
            catch (Exception ex){ MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            con.Close();
            if(s.dgvService.RowCount > 0)
            {
                for (int i = 0; i < s.dgvService.RowCount; i++)
                {
                    s.dgvService.Rows[i].Cells[4].Value = TrouverNom("compte", int.Parse(s.dgvService.Rows[i].Cells[3].Value.ToString()));
                }
            }
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
                s.numcompte = s.dgvService.CurrentRow.Cells[3].Value.ToString();
                s.cboCatService.DropDownStyle = ComboBoxStyle.DropDown;
                s.cboCatService.Text = s.dgvService.CurrentRow.Cells[4].Value.ToString();
                s.cboCatService.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        #endregion

        #region ABONNE
        public void AfficherSousForm(MFormAbonne a, FormPatient childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                if (a.statut == "nouveau")
                {
                    childForm.txtRecherche.Enabled = false;
                    childForm.btnRecherche.Enabled = false;
                }
                else
                {
                    childForm.btnEnregistrer.Enabled = false;
                    childForm.rbNouveau.Text = "Ancien cas";
                }
                childForm.statut = a.statut;
                if (a.infirmier_autorise)
                    childForm.rbNouveau.Enabled = false;
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }
        public void AfficherSousForm(MFormAbonne a, FormAbonne childForm)
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
            childForm.btnEnregistrer.Enabled = false;
            childForm.Show();
        }
        public void AfficherSousForm(MFormAbonne r, FormFactureService childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.poste = "abonné";
                childForm.type_patient = "abonné";
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
        }
        public void AfficherSousForm(MFormAbonne r, FormFactureProduit childForm)
        {
            id = NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                childForm.idexercice = int.Parse(dr[0].ToString());
                con.Close();

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
                childForm.poste = "abonné";
                childForm.type_patient = "abonné";
                childForm.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);             
        }
        public void AfficherSousForm(MFormAbonne a, Form childForm)
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
        public void Services(FormAbonne a, FormAbonneService s)
        {
            //s.idabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
            //s.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[6].Value.ToString();
            //s.typepatient = a.cboTypePatient.Text;
            if(s.typepatient=="abonné")
                s.Text = "SSM - Services aux abonnés";
            else
                s.Text = "SSM - Services aux employés";
            s.ShowDialog();
        }
        public void Produits(FormAbonne a, FormAbonneProduit p)
        {
            //p.idabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
            //p.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[6].Value.ToString();
            //p.typepatient = a.cboTypePatient.Text;
            //if (p.typepatient == "abonné")
            //    p.Text = "SSM - Produits aux abonnés";
            //else
            //    p.Text = "SSM - Produits aux employés";
            //p.ShowDialog();
        }
        public void Annuler(FormAbonne a)
        {
            //a.dgvAbonne.Rows.Clear();
            a.cboEntreprise.Items.Clear();
            a.cboTypeAbonne.Items.Clear();
            a.txtReference.Text = "";
        }
        public void NouvelAbonne(FormPatient a)
        {
            //a.idabonne = NouveauID("abonne");
            //con.Open();
            //SqlTransaction tx = con.BeginTransaction();
            //try
            //{
            //    cmd = new SqlCommand("insert into Abonne values (@id, @identreprise, @idtypeabonne, @reference, @idpatient)", con);
            //    cmd.Parameters.AddWithValue("@id", a.idabonne);
            //    cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
            //    cmd.Parameters.AddWithValue("@idtypeabonne", a.idtypeabonne);
            //    cmd.Parameters.AddWithValue("@reference", a.refabonne);
            //    cmd.Parameters.AddWithValue("@idpatient", a.idpatient);

            //    cmd.Transaction = tx;
            //    cmd.ExecuteNonQuery();
            //    tx.Commit();
            //}
            //catch (Exception ex)
            //{
            //    tx.Rollback();
            //    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //con.Close();
        }
        private int CompterServiceAbonne(int idabonne)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) from AbonneService where idabonne= @id", con);
                cmd.Parameters.AddWithValue("@id", idabonne);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            con.Close();
            return id;
        }
        private int CompterProduitAbonne(int idabonne)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) from AbonneProduit where idabonne= @id", con);
                cmd.Parameters.AddWithValue("@id", idabonne);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void Supprimer(FormAbonne a)
        {
            if(CompterServiceAbonne(a.idabonne)== 0 && CompterProduitAbonne(a.idabonne)==0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Abonne where idabonne = @id", con);
                    cmd.Parameters.AddWithValue("@id", a.idabonne);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(a);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void RapportAbonne(FormAbonneRapport a)
        {
            a.txtTotalDollar.Text = "0";
            a.txtTotalService.Text = "0";
            a.txtTotalProduit.Text = "0";
            con.Open();
            cmd = new SqlCommand("select id, date_jour, AbonneService.idabonne, idservice from AbonneService, Abonne where Abonne.idabonne= AbonneService.idabonne and identreprise= @identreprise and date_jour between @dateDe and @dateA", con);
            cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
            cmd.Parameters.AddWithValue("@dateDe", a.dtpDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", a.dtpA.Value.Date);
            try
            {
                dr = cmd.ExecuteReader();
                a.dgvAbonneService.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAbonneService.Rows.Add();
                    a.dgvAbonneService.Rows[a.dgvAbonneService.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAbonneService.Rows[a.dgvAbonneService.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAbonneService.Rows[a.dgvAbonneService.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAbonneService.Rows[a.dgvAbonneService.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < a.dgvAbonneService.RowCount; i++)
            {
                a.dgvAbonneService.Rows[i].Cells[4].Value = TrouverNom("abonne", int.Parse(a.dgvAbonneService.Rows[i].Cells[2].Value.ToString()));
                a.dgvAbonneService.Rows[i].Cells[5].Value = TrouverNom("service", int.Parse(a.dgvAbonneService.Rows[i].Cells[3].Value.ToString()));
                a.dgvAbonneService.Rows[i].Cells[6].Value = PrixService(int.Parse(a.dgvAbonneService.Rows[i].Cells[3].Value.ToString()));
                a.txtTotalService.Text = int.Parse(a.txtTotalService.Text) + int.Parse(a.dgvAbonneService.Rows[i].Cells[6].Value.ToString()) + "";
            }
            a.txtTotalService.Text = (int.Parse(a.txtTotalService.Text) + (int.Parse(a.txtTotalService.Text) * int.Parse(a.txtTaux.Text)) / 100) + "";
            con.Open();
            cmd = new SqlCommand("select id, date_jour, AbonneProduit.idabonne, idstock, qteprise from AbonneProduit, Abonne where Abonne.idabonne= AbonneProduit.idabonne and identreprise= @identreprise and date_jour between @dateDe and @dateA", con);
            cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
            cmd.Parameters.AddWithValue("@dateDe", a.dtpDe.Value.Date);
            cmd.Parameters.AddWithValue("@dateA", a.dtpA.Value.Date);
            try
            {
                dr = cmd.ExecuteReader();
                a.dgvAbonneProduit.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAbonneProduit.Rows.Add();
                    a.dgvAbonneProduit.Rows[a.dgvAbonneProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAbonneProduit.Rows[a.dgvAbonneProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAbonneProduit.Rows[a.dgvAbonneProduit.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAbonneProduit.Rows[a.dgvAbonneProduit.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAbonneProduit.Rows[a.dgvAbonneProduit.RowCount - 1].Cells[10].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < a.dgvAbonneProduit.RowCount; i++)
            {
                a.dgvAbonneProduit.Rows[i].Cells[4].Value = TrouverNom("abonne", int.Parse(a.dgvAbonneProduit.Rows[i].Cells[2].Value.ToString()));
                a.dgvAbonneProduit.Rows[i].Cells[11].Value = cs.PrixStock(Convert.ToInt32(a.dgvAbonneProduit.Rows[i].Cells[3].Value), "vente");
                a.txtTotalProduit.Text = int.Parse(a.txtTotalProduit.Text) + int.Parse(a.dgvAbonneProduit.Rows[i].Cells[11].Value.ToString()) + "";
            }
            cs.AfficherLigneStock(a.dgvAbonneProduit);
            a.txtTotalProduit.Text = (int.Parse(a.txtTotalProduit.Text) + (int.Parse(a.txtTotalProduit.Text) * int.Parse(a.txtTaux.Text)) / 100) + "";
            DateTaux date = new DateTaux();
            if (VerifierTaux(DateTime.Now.Date, "") == 0)
            {
                date.ShowDialog();
                if (date.fermeture_succes)
                    a.txtTotalDollar.Text = (int.Parse(a.txtTotalService.Text) + int.Parse(a.txtTotalProduit.Text)) / (float)VerifierTaux(a.dtpA.Value.Date, "valeur") + "";
            }
            else
                a.txtTotalDollar.Text = (int.Parse(a.txtTotalService.Text) + int.Parse(a.txtTotalProduit.Text)) / (float)VerifierTaux(a.dtpA.Value.Date, "valeur") + "";
        }
        public void RubriquesRapport(FormAbonnePersoRapport r)
        {
            id = 0;
            valeur = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select numcompte, libellecompte from Compte where numcompte like '7061%' or numcompte like '7078%'  and numcompte <> '7078' and numcompte <> '707803'", con);
                dr = cmd.ExecuteReader();

                valeur = r.dgvRapport.ColumnCount;
                if (valeur > 7)
                {
                    for (int i = 7; i < valeur; i++)
                    {
                        r.dgvRapport.Columns.RemoveAt(7);
                    }
                }
                r.cbonumcompte.Items.Clear();
                //r.cbonumcompte.Items.Add("depense");
                r.dgvRapport.Columns.Add("column0" + id, "Lunettes/\nServices externes");
                r.cbonumcompte.Items.Add("701100");
                r.dgvRapport.Columns.Add("column00" + id, "Produits pha.");

                while (dr.Read())
                {
                    r.cbonumcompte.Items.Add(dr[0].ToString());
                    r.dgvRapport.Columns.Add("column" + id, dr[1].ToString());
                    id += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherEmploye(FormAbonnePersoRapport r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idpatient, idemploye from Employe", con);
                dr = cmd.ExecuteReader();
                r.dgvRapport.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = r.dgvRapport.RowCount;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherAbonne(FormAbonnePersoRapport r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idpatient, refabonne, idabonne from Abonne where identreprise = @identreprise ", con);
                cmd.Parameters.AddWithValue("@identreprise", r.identreprise);
                dr = cmd.ExecuteReader();
                r.dgvRapport.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRapport.Rows.Add();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[0].Value = r.dgvRapport.RowCount;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[5].Value = dr[1].ToString();
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[6].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void CalculDepense(FormAbonnePersoRapport r)
        {
            if(r.dgvRapport.RowCount != 0)
            {
                for (int i = 0; i < r.dgvRapport.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("select  monnaie, sum(montant) as total from Depense, BonDepense where Depense.numbon = BonDepense.numbon and date_operation between @dateDe and @dateA and idabonne = @idabonne group by monnaie", con);
                        cmd.Parameters.AddWithValue("@idabonne", r.dgvRapport.Rows[i].Cells[6].Value.ToString());
                        cmd.Parameters.AddWithValue("@dateDe", r.dtpDe.Value.Date);
                        cmd.Parameters.AddWithValue("@dateA", r.dtpA.Value.Date);
                        dr = cmd.ExecuteReader();
                        
                        r.dgv.Columns.Clear();
                        r.dgv.Rows.Clear();
                        r.dgv.Columns.Add("column0", "monnaie");
                        r.dgv.Columns.Add("column00", "montant");

                        while (dr.Read())
                        {
                            r.dgv.Rows.Add();
                            r.dgv.Rows[r.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            r.dgv.Rows[r.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    //Retrouver le montant et convertir
                    if (r.dgv.RowCount == 0)
                        r.dgvRapport.Rows[i].Cells[7].Value = 0;
                    else if (r.dgv.RowCount == 1) //si la 1ere ligne est la seule
                    {
                        if (r.dgv.Rows[0].Cells[0].Value.ToString() == "CDF")
                            r.dgvRapport.Rows[i].Cells[7].Value = r.dgv.Rows[0].Cells[1].Value.ToString();
                        else
                            r.dgvRapport.Rows[i].Cells[7].Value = double.Parse(r.dgv.Rows[0].Cells[1].Value.ToString()) * r.taux;
                    }
                    else
                    {
                        if (r.dgv.Rows[0].Cells[0].Value.ToString() == "USD")//si la 1ere ligne c'est USD
                            r.dgv.Rows[0].Cells[1].Value = double.Parse(r.dgv.Rows[0].Cells[1].Value.ToString()) * r.taux;
                        else//si la 2è ligne c'est USD
                            r.dgv.Rows[1].Cells[1].Value = double.Parse(r.dgv.Rows[1].Cells[1].Value.ToString()) * r.taux;

                        r.dgvRapport.Rows[i].Cells[7].Value = double.Parse(r.dgv.Rows[0].Cells[1].Value.ToString()) + double.Parse(r.dgv.Rows[1].Cells[1].Value.ToString());
                    }
                }
            }
            
        }
        public void CalculTotalService(FormAbonnePersoRapport r, int nbligne)
        {
            for (int i = 9; i < r.dgvRapport.ColumnCount; i++)
            {
                con.Open();
                try
                {

                    cmd = new SqlCommand("calcul_total", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numcompte", SqlDbType.VarChar).Value = r.cbonumcompte.Items[i - 8];//-7 pour sauter le compte de produits pha.
                    cmd.Parameters.AddWithValue("@idemploye", SqlDbType.Int).Value = r.dgvRapport.Rows[nbligne].Cells[6].Value.ToString();
                    cmd.Parameters.AddWithValue("@dateDe", SqlDbType.Date).Value = r.dtpDe.Value.Date;
                    cmd.Parameters.AddWithValue("@dateA", SqlDbType.Date).Value = r.dtpA.Value.Date;
                    SqlParameter param = new SqlParameter{
                        ParameterName = "@val",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    r.dgvRapport.Rows[nbligne].Cells[i].Value = param.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Calcul total ligne service" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void CalculTotalProduit(FormAbonnePersoRapport r, int nbligne)
        {
            con.Open();
            try
            {

                cmd = new SqlCommand("calcul_total_produit", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idemploye", SqlDbType.Int).Value = r.dgvRapport.Rows[nbligne].Cells[6].Value.ToString();
                cmd.Parameters.AddWithValue("@dateDe", SqlDbType.Date).Value = r.dtpDe.Value.Date;
                cmd.Parameters.AddWithValue("@dateA", SqlDbType.Date).Value = r.dtpA.Value.Date;
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@val",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                r.dgvRapport.Rows[nbligne].Cells[8].Value = param.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Calcul total ligne service" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void CalculTotalService2(FormAbonnePersoRapport r, int nbligne)
        {
            for (int i = 9; i < r.dgvRapport.ColumnCount; i++)
            {
                con.Open();
                try
                {

                    cmd = new SqlCommand("calcul_total2", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@numcompte", SqlDbType.VarChar).Value = r.cbonumcompte.Items[i - 8];//-7 pour sauter le compte de produits pha.
                    cmd.Parameters.AddWithValue("@idabonne", SqlDbType.Int).Value = r.dgvRapport.Rows[nbligne].Cells[6].Value.ToString();
                    cmd.Parameters.AddWithValue("@dateDe", SqlDbType.Date).Value = r.dtpDe.Value.Date;
                    cmd.Parameters.AddWithValue("@dateA", SqlDbType.Date).Value = r.dtpA.Value.Date;
                    SqlParameter param = new SqlParameter
                    {
                        ParameterName = "@val",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(param);

                    cmd.ExecuteNonQuery();
                    r.dgvRapport.Rows[nbligne].Cells[i].Value = param.Value;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void CalculTotalProduit2(FormAbonnePersoRapport r, int nbligne)
        {
            con.Open();
            try
            {

                cmd = new SqlCommand("calcul_total_produit2", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idabonne", SqlDbType.Int).Value = r.dgvRapport.Rows[nbligne].Cells[6].Value.ToString();
                cmd.Parameters.AddWithValue("@dateDe", SqlDbType.Date).Value = r.dtpDe.Value.Date;
                cmd.Parameters.AddWithValue("@dateA", SqlDbType.Date).Value = r.dtpA.Value.Date;
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@val",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                r.dgvRapport.Rows[nbligne].Cells[8].Value = param.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void CalculTotalLigne(FormAbonnePersoRapport r)
        {
            
            for (int i = 0; i < r.dgvRapport.RowCount; i++)
            {
                r.dgvRapport.Rows[i].Cells[7].Value = 0;
                CalculTotalProduit(r, i);
                CalculTotalService(r, i);
            }
        }
        public void CalculTotalLigne2(FormAbonnePersoRapport r)
        {

            for (int i = 0; i < r.dgvRapport.RowCount; i++)
            {
                CalculTotalProduit2(r, i);
                CalculTotalService2(r, i);
            }
        }
        public void CalculerTotaux(FormAbonnePersoRapport r)
        {
            try
            {
                r.dgvRapport.Columns.Add("column0000", "Total");
                r.dgvRapport.Rows.Add();
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                for (int j = 7; j < r.dgvRapport.ColumnCount; j++)
                {
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[j].Value = 0;
                }
                double sommeligne;

                for (int i = 0; i < r.dgvRapport.RowCount-1; i++)
                {
                    sommeligne = 0;
                    for (int j = 7; j < r.dgvRapport.ColumnCount-1; j++)
                    {
                        sommeligne += double.Parse(r.dgvRapport.Rows[i].Cells[j].Value.ToString());
                        r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[j].Value = double.Parse(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[j].Value.ToString()) + double.Parse(r.dgvRapport.Rows[i].Cells[j].Value.ToString());
                    }
                    r.dgvRapport.Rows[i].Cells[r.dgvRapport.ColumnCount - 1].Value = sommeligne;
                    r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[r.dgvRapport.ColumnCount - 1].Value = double.Parse(r.dgvRapport.Rows[r.dgvRapport.RowCount - 1].Cells[r.dgvRapport.ColumnCount - 1].Value.ToString()) + double.Parse(r.dgvRapport.Rows[i].Cells[r.dgvRapport.ColumnCount - 1].Value.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Calcul totaux" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ImprimerRapport(FormAbonnePersoRapport r)
        {
            r.btnImprimer.Enabled = false;
            if(r.dgvRapport.RowCount != 0)
            {
                //
            }
        }
        #endregion

        #region EMPLOYE
        public void NouvelEmploye(FormPatient p)
        {
            //p.idemploye = NouveauID("employe");
            //con.Open();
            //SqlTransaction tx = con.BeginTransaction();
            //try
            //{
            //    cmd = new SqlCommand("insert into Employe values (@id, @idpatient)", con);
            //    cmd.Parameters.AddWithValue("@id", p.idemploye);
            //    cmd.Parameters.AddWithValue("@idpatient", p.idpatient);

            //    cmd.Transaction = tx;
            //    cmd.ExecuteNonQuery();
            //    tx.Commit();
            //}
            //catch (Exception ex)
            //{
            //    tx.Rollback();
            //    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //con.Close();
        }       
        public void AfficherEmploye(FormAbonne a)
        {
            //con.Open();
            //cmd = new SqlCommand("select * from Employe", con);
            //try
            //{
            //    dr = cmd.ExecuteReader();
            //    a.dgvAbonne.Rows.Clear();
            //    while (dr.Read())
            //    {
            //        a.dgvAbonne.Rows.Add();
            //        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
            //        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[9].Value = dr[1].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //con.Close();
        }
        #endregion

        #region ABONNE_SERVICE
        public void SelectionService(FormAbonneService a, FormPayement fs)
        {
            //fs.ShowDialog();
            //if (fs.selectionvalide)
            //{
            //    a.dgvService.Rows.Clear();
            //    for (int i = 0; i < fs.dgv3.RowCount; i++)
            //    {
            //        a.dgvService.Rows.Add();
            //        a.dgvService.Rows[i].Cells[0].Value = fs.dgv3.Rows[i].Cells[0].Value.ToString();
            //        a.dgvService.Rows[i].Cells[2].Value = fs.dgv3.Rows[i].Cells[1].Value.ToString();
            //    }
            //}
            //fs.Close();
            
        }
        public void Annuler(FormAbonneService a)
        {
            a.btnEnregistrer.Enabled = true;
            a.btnModifier.Enabled = false;
            a.btnSupprimer.Enabled = false;
            a.dtpDateAbonne.ResetText();
            a.txtAbonne.Text = "";
            a.dgvService.Rows.Clear();
            a.dgvAbonne.Rows.Clear();
        }
        public void Afficher(FormAbonneService a, string motif)
        {
            if(motif == "recherche")
            {
                con.Open();
                if (a.typepatient == "abonné")
                    cmd = new SqlCommand("select id, date_jour, idpatient, idservice from AbonneService, Abonne where date_jour= @date_jour and AbonneService.idabonne = Abonne.idabonne", con);
                else
                    cmd = new SqlCommand("select id, date_jour, idpatient, idservice from EmployeService, Employe where date_jour= @date_jour and EmployeService.idemploye = Employe.idemploye", con);
                
                cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
                try
                {
                    dr = cmd.ExecuteReader();
                    a.dgvAbonne.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvAbonne.Rows.Add();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                if(a.dgvAbonne.RowCount > 0)
                {
                    for (int i = 0; i < a.dgvAbonne.RowCount; i++)
                    {
                        a.dgvAbonne.Rows[i].Cells[5].Value = TrouverNom("service", int.Parse(a.dgvAbonne.Rows[i].Cells[3].Value.ToString()));
                    }
                }
            }
            else
            {
                con.Open();
                try
                {
                    if(a.typepatient=="abonné")
                        cmd = new SqlCommand("select id, date_jour, idpatient, idservice from AbonneService, Abonne where id= @id and AbonneService.idabonne = Abonne.idabonne", con);
                    else
                        cmd = new SqlCommand("select id, date_jour, idpatient, idservice from EmployeService, Employe where id= @id and EmployeService.idemploye = Employe.idemploye", con);
                    cmd.Parameters.AddWithValue("@id", a.id);
                    dr = cmd.ExecuteReader();
                    a.dgvAbonne.Rows.Clear();
                    dr.Read();
                    a.dgvAbonne.Rows.Add();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[5].Value = TrouverNom("service", int.Parse(a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[3].Value.ToString()));
            }
        }
        public void Enregistrer(FormAbonneService a)
        {
            if (a.txtAbonne.Text != "")
            {
                if (a.typepatient == "abonné")
                {
                    a.id = NouveauID("abonneservice");
                    cmd = new SqlCommand("insert into AbonneService values (@id, @date_jour, @idabonne, @idservice)", con);
                }
                else
                {
                    a.id = NouveauID("employeservice");
                    cmd = new SqlCommand("insert into EmployeService values (@id, @date_jour, @idabonne, @idservice)", con);
                }
                cmd.Parameters.AddWithValue("@id", a.id);
                cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
                cmd.Parameters.AddWithValue("@idabonne", a.idabonne);
                for (int i = 0; i < a.dgvService.RowCount; i++)
                {
                    cmd.Parameters.AddWithValue("@idservice", a.dgvService.Rows[i].Cells[0].Value.ToString());
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
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
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Annuler(a);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        public void Modifier(FormAbonneService a, FormPayement s)
        {
            //if (a.txtAbonne.Text != "")
            //{
            //    s.ShowDialog();
            //    if(s.selectionvalide)
            //    {
            //        if(s.dgv3.RowCount == 1)
            //        {
            //            //a.idservice = s.dgv3.Rows[0].Cells[0].Value.ToString();
            //            if (a.typepatient == "abonné")
            //                cmd = new SqlCommand("update AbonneService set date_jour= @date_jour, idservice = @idservice where id = @id", con);
            //            else
            //                cmd = new SqlCommand("update EmployeService set date_jour= @date_jour, idservice = @idservice where id = @id", con);

            //            cmd.Parameters.AddWithValue("@id", a.id);
            //            cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
            //            cmd.Parameters.AddWithValue("@idservice", s.dgv3.Rows[0].Cells[0].Value.ToString());

            //            con.Open();
            //            SqlTransaction tx = con.BeginTransaction();
            //            try
            //            {
            //                cmd.Transaction = tx;
            //                cmd.ExecuteNonQuery();
            //                tx.Commit();
            //                MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                Annuler(a);
            //            }
            //            catch (Exception ex)
            //            {
            //                tx.Rollback();
            //                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            con.Close();
            //            Afficher(a, "");
            //        }
            //        else
            //            MessageBox.Show("Vous avez ajouté plus d'un service pour la mise à jour. Il en faut un seul", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    else
            //        MessageBox.Show("Aucun service n'a été sélectionné pour la mise à jour", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        public void Supprimer(FormAbonneService a)
        {
            if (a.typepatient == "abonné")
                cmd = new SqlCommand("delete from AbonneService where id = @id", con);
            else
                cmd = new SqlCommand("delete from EmployeService where id = @id", con);
            
            cmd.Parameters.AddWithValue("@id", a.id);
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Annuler(a);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Afficher(a, "");
        }
        public void Recuperer(FormAbonneService a)
        {
            if(a.dgvAbonne.RowCount !=0)
            {
                a.btnEnregistrer.Enabled = false;
                a.btnModifier.Enabled = true;
                a.btnSupprimer.Enabled = true;
                a.idservice = 0;
                a.id = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
                a.dtpDateAbonne.Text = a.dgvAbonne.CurrentRow.Cells[1].Value.ToString();
                a.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[4].Value.ToString();
            }
        }
        #endregion

        ClassStock cs = new ClassStock();

        #region ABONNE_PRODUIT
        public void Annuler(FormAbonneProduit a)
        {
            a.btnEnregistrer.Enabled = true;
            a.btnModifier.Enabled = false;
            a.btnSupprimer.Enabled = false;
            a.txtAbonne.Text = "";
        }
        public void Facturier(FormAbonneProduit f, FormFactureProduit2 f2)
        {
            //f2.ShowDialog();
            //f.dgvFacture.Rows.Clear();
            //if (f2.fermeture_succes)
            //{
            //    for (int i = 0; i < f2.dgvFacture.RowCount; i++)
            //    {
            //        f.dgvFacture.Rows.Add();
            //        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f2.dgvFacture.Rows[i].Cells[0].Value;
            //        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f2.dgvFacture.Rows[i].Cells[1].Value;
            //        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = f2.dgvFacture.Rows[i].Cells[2].Value;
            //        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f2.dgvFacture.Rows[i].Cells[3].Value;
            //        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f2.dgvFacture.Rows[i].Cells[4].Value;
            //    }
            //}
            //f2.Close();
        }
        public void Afficher(FormAbonneProduit a, string motif)
        {
                con.Open();
                if (a.typepatient == "abonné")
                    cmd = new SqlCommand("select id, date_jour, idpatient, idstock, qteprise from AbonneProduit, Abonne where date_jour= @date_jour and AbonneProduit.idabonne = Abonne.idabonne", con);
                else
                    cmd = new SqlCommand("select id, date_jour, idpatient, idstock, qteprise from EmployeProduit, Employe where date_jour= @date_jour and EmployeProduit.idemploye = Employe.idemploye", con);

                cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
                try
                {
                    dr = cmd.ExecuteReader();
                    a.dgvAbonne.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvAbonne.Rows.Add();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[10].Value = dr[4].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                cs.AfficherLigneStock(a.dgvAbonne);
        }
        public void Enregistrer(FormAbonneProduit a)
        {
            if (a.txtAbonne.Text != "")
            {
                for (int i = 0; i < a.dgvFacture.RowCount; i++)
                {
                    if (a.typepatient == "abonné")
                    {
                        a.id = NouveauID("abonneproduit");
                        cmd = new SqlCommand("insert into AbonneProduit values (@id, @date_jour, @idabonne, @idstock, @qte, @prix)", con);
                    }
                    else
                    {
                        a.id = NouveauID("employeproduit");
                        cmd = new SqlCommand("insert into EmployeProduit values (@id, @date_jour, @idabonne, @idstock, @qte, @prix)", con);
                    }
                    cmd.Parameters.AddWithValue("@id", a.id);
                    cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
                    cmd.Parameters.AddWithValue("@idabonne", a.idabonne);
                    cmd.Parameters.AddWithValue("@idstock", a.dgvFacture.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@qte", a.dgvFacture.Rows[i].Cells[4].Value.ToString());
                    cmd.Parameters.AddWithValue("@prix", double.Parse(a.dgvFacture.Rows[i].Cells[3].Value.ToString()));
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
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
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Annuler(a);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormAbonneProduit f, FormFactureProduit2 f2)
        {
            //if (f.txtAbonne.Text != "")
            //{
            //    f2.ShowDialog();
            //    if (f2.dgvFacture.RowCount == 1)
            //    {
            //        f.dgvFacture.Rows.Clear();
            //        if (f2.fermeture_succes)
            //        {
            //            for (int i = 0; i < f2.dgvFacture.RowCount; i++)
            //            {
            //                f.dgvFacture.Rows.Add();
            //                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f2.dgvFacture.Rows[i].Cells[0].Value;
            //                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f2.dgvFacture.Rows[i].Cells[1].Value;
            //                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = f2.dgvFacture.Rows[i].Cells[2].Value;
            //                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f2.dgvFacture.Rows[i].Cells[3].Value;
            //                f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f2.dgvFacture.Rows[i].Cells[4].Value;
            //            }
                        
            //            if (f.typepatient == "abonné")
            //                cmd = new SqlCommand("update AbonneProduit set date_jour= @date_jour, idstock = @idstock, qteprise = @qte, prixstock= @prix where id = @id", con);
            //            else
            //                cmd = new SqlCommand("update EmployeProduit set date_jour= @date_jour, idstock = @idstock, qteprise = @qte, prixstock= @prix where id = @id", con);

            //            cmd.Parameters.AddWithValue("@id", f.id);
            //            cmd.Parameters.AddWithValue("@date_jour", f.dtpDateAbonne.Value.Date);
            //            cmd.Parameters.AddWithValue("@idstock", f.dgvFacture.Rows[0].Cells[0].Value.ToString());
            //            cmd.Parameters.AddWithValue("@qte", f.dgvFacture.Rows[0].Cells[3].Value.ToString());
            //            cmd.Parameters.AddWithValue("@prix", f.dgvFacture.Rows[0].Cells[4].Value.ToString());
            //            con.Open();
            //            SqlTransaction tx = con.BeginTransaction();
            //            try
            //            {
            //                cmd.Transaction = tx;
            //                cmd.ExecuteNonQuery();
            //                tx.Commit();
            //                MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                Annuler(f);
            //            }
            //            catch (Exception ex)
            //            {
            //                tx.Rollback();
            //                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }
            //            con.Close();
            //        }
            //    }
            //    else
            //        MessageBox.Show("Vous devez valider une seule ligne pour la mise à jour", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        public void Supprimer(FormAbonneProduit a)
        {
            if (a.typepatient == "abonné")
                cmd = new SqlCommand("delete from AbonneProduit where id = @id", con);
            else
                cmd = new SqlCommand("delete from EmployeProduit where id = @id", con);

            cmd.Parameters.AddWithValue("@id", a.id);
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                a.dgvAbonne.Rows.RemoveAt(a.dgvAbonne.CurrentRow.Index);
                Annuler(a);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void Recuperer(FormAbonneProduit a)
        {
            if (a.dgvAbonne.RowCount != 0)
            {
                a.btnEnregistrer.Enabled = false;
                a.btnModifier.Enabled = true;
                a.btnSupprimer.Enabled = true;            
                a.id = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
                a.dtpDateAbonne.Text = a.dgvAbonne.CurrentRow.Cells[1].Value.ToString();
                a.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[4].Value.ToString();
            }
        }
        #endregion

        #region COMPTABILITE

        public void AfficherSousForm(MFormComptabilite c, FormApproCommande childForm)
        {
            id = NbExerciceEncours();
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
        private int NbExerciceEncours()
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(exercice) from Exercice where statut IS NULL", con);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        public void LancerCompta(MFormComptabilite c)
        {
            id = NbExerciceEncours();
            if (id == 0)
            {
                MessageBox.Show("Ajoutez un exercice comptable pour les opérations", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                new FormComptaExercice().ShowDialog();
            }
            else if (id > 1)
            {
                MessageBox.Show("Retenez un exercice comptable pour les opérations", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                FormComptaExercice exe = new FormComptaExercice();
                exe.suppression = true;
                exe.ShowDialog();
            }
        }
        public void AfficherSousForm(MFormComptabilite c, FormComptaOperation childForm)
        {
            id = NbExerciceEncours();
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
        public void AfficherSousForm(MFormComptabilite c, FormComptaGdLivre childForm)
        {
            id = NbExerciceEncours();
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
        public void AfficherSousForm(MFormComptabilite c, FormComptaBilan childForm)
        {
            id = NbExerciceEncours();
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
        public void AfficherSousForm(MFormComptabilite c, Form childForm)
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
        public void AfficherSousForm(MFormComptabilite c, FormComptaTableauFlux childForm)
        {
            id = NbExerciceEncours();
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
        public void AfficherSousForm(MFormComptabilite c, FormComptaBalance childForm)
        {
            id = NbExerciceEncours();
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
        public void AfficherSousForm(MFormComptabilite c, FormComptaResultat childForm)
        {
            id = NbExerciceEncours();
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
        public void Annuler(FormCompte c)
        {
            c.txtNumCompte.Text = "";
            c.txtLibelle.Text = "";
            c.txtNumCompte.Select();
            c.btnEnregistrer.Enabled = true;
            c.btnModifier.Enabled = false;
            c.btnSupprimer.Enabled = false;
            c.dgvCompte.Rows.Clear();
            c.cboCategorie.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboCategorie.SelectedText = "";
            c.cboCategorie.DropDownStyle = ComboBoxStyle.DropDownList;
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
        public void Enregistrer(FormCompte c)
        {
            if(c.txtNumCompte.Text != "" && c.txtLibelle.Text != "")
            {
                if (VerifierNumCompte(c.txtNumCompte.Text) == 0)
                {
                    c.numcompte = c.txtNumCompte.Text;
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Compte values (@numcompte, @libelle, @debit, @credit, @soldeanterieur, @reference, @categorie)", con);
                        cmd.Parameters.AddWithValue("@numcompte", c.txtNumCompte.Text);
                        cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                        cmd.Parameters.AddWithValue("@debit", "0");
                        cmd.Parameters.AddWithValue("@credit", "0");
                        cmd.Parameters.AddWithValue("@soldeanterieur", "0");
                        cmd.Parameters.AddWithValue("@reference", "0");
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
                    Afficher(c, "");
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
        public void ModifierLibelle(FormCompte c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Compte set libellecompte= @libelle, categorie = @categorie where numcompte= @numcompte", con);
                cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
                cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                cmd.Parameters.AddWithValue("@categorie", c.categorie);
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
            MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Annuler(c);
            Afficher(c, "");
        }
        public void ModifierCompte(FormCompte c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Compte set numcompte= @num, libellecompte= @libelle, categorie = @categorie where numcompte= @numcompte", con);
                cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
                cmd.Parameters.AddWithValue("@num", c.txtNumCompte.Text);
                cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                cmd.Parameters.AddWithValue("@categorie", c.categorie);

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
            MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Annuler(c);
            Afficher(c, "");
        }
        public void Modifier(FormCompte c)
        {
            if (c.txtNumCompte.Text != "" && c.txtLibelle.Text != "" && c.cboCategorie.Text != "")
            {
                if(c.numcompte == c.txtNumCompte.Text)
                {
                    ModifierLibelle(c);
                }
                else
                {
                    if(CompterOperationCompte(c.numcompte)==0)
                    {
                        ModifierCompte(c);
                    }
                    else
                    {
                        if(MessageBox.Show("Impossible de modifier un numéro de compte déjà impliqué dans les opérations\n\nVoulez-vous modifier seul le le libellé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Error)==DialogResult.Yes)
                            ModifierLibelle(c);
                    }
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
        public void Supprimer(FormCompte c)
        {
           if(CompterOperationCompte(c.numcompte)==0)
           {
               con.Open();
               SqlTransaction tx = con.BeginTransaction();
               try
               {
                   cmd = new SqlCommand("delete from Compte where numcompte= @numcompte", con);
                   cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
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
               c.dgvCompte.Rows.RemoveAt(c.dgvCompte.CurrentRow.Index);
           }
            else
               MessageBox.Show("Le compte sélectionné est déjà impliqué dans les opérations comptables,\npour raison de de cohérence, il ne peut être supprimé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Afficher(FormCompte c, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if(c.txtNumCompte.Text !="")
                        cmd = new SqlCommand("select * from Compte where numcompte like '"+c.txtNumCompte.Text+"%'", con);
                    else
                        cmd = new SqlCommand("select * from Compte", con);
                }
                else
                {
                    cmd = new SqlCommand("select * from Compte where numcompte= @numcompte", con);
                    cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
                }
                c.dgvCompte.Rows.Clear();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.dgvCompte.Rows.Add();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    c.dgvCompte.Rows[c.dgvCompte.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void Recuperer(FormCompte c)
        {
            if (c.dgvCompte.RowCount > 0)
            {
                c.numcompte = c.dgvCompte.CurrentRow.Cells[0].Value.ToString();
                c.txtNumCompte.Text = c.dgvCompte.CurrentRow.Cells[0].Value.ToString();
                c.txtLibelle.Text = c.dgvCompte.CurrentRow.Cells[1].Value.ToString();
                c.btnModifier.Enabled = true;
                c.btnSupprimer.Enabled = true;
                c.btnEnregistrer.Enabled = false;
            }
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
                JOIN BonDepense b ON d.numbon = b.numbon 
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
            for (int i = 4; i < r.dgvRapport.RowCount; i++)
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
            for (int i = 4; i < r.dgvRapport.RowCount; i++)
            {
                if (r.dgvRapport.Rows[i].Cells[6].Value.ToString() == "D")
                {
                    cmdtxt = @"SELECT COUNT(d.montant), SUM(d.montant) 
                    FROM Depense d JOIN BonDepense b ON d.numbon = b.numbon
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
                    FROM Depense d JOIN BonDepense b ON d.numbon = b.numbon
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
        }
        public bool AjouterOperation(int idoperation, string date_jour, string numpiece, int idtypejournal, int idexercice, int idsource, string source)
        {
            cmdStatut = true;
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (source == "recette")
                {
                    cmd = new SqlCommand("INSERT INTO Operation(idoperation, date_operation, numpiece, idtypejournal, idrecette, idexercice) values(@id, @date_jour, @numpiece, @idtypejournal, @idrecette, @idexercice)", con);
                    cmd.Parameters.AddWithValue("@idrecette", idsource);
                }
                else if (source == "dépense")
                {
                    cmd = new SqlCommand("insert into Operation(idoperation, date_operation, numpiece, idtypejournal, numbon, idexercice) values(@id, @date_jour, @numpiece, @idtypejournal, @numbon, @idexercice)", con);
                    cmd.Parameters.AddWithValue("@numbon", idsource);
                }
                else
                    cmd = new SqlCommand("insert into Operation(idoperation, date_operation, numpiece, idtypejournal, idexercice) values(@id, @date_jour, @numpiece, @idtypejournal, @idexercice)", con);
                cmd.Parameters.AddWithValue("@id", idoperation);
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
                cmdStatut = false;
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return cmdStatut;
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
                c.idoperation = NouveauID("operation");
                if (AjouterOperation(c.idoperation, c.lblDateOperation.Text, c.txtNumPiece.Text, c.idtypejournal, c.idexercice, 0, ""))
                {
                    if (c.cboDebitCredit.Text == "Crédit")
                    {
                        for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                        {
                            DebiterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[2].Value), c.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                        }
                        CrediterCompte(c.idoperation, c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value), c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());
                    }
                    else if (c.cboDebitCredit.Text == "Débit")
                    {
                        for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                        {
                            CrediterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[3].Value), c.dgvEcriture.Rows[i].Cells[1].Value.ToString());
                        }
                        DebiterCompte(c.idoperation, c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value), c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());
                    }
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
        public double SoldeCompte(string numcompte)
        {
            valeur = 0;
            con.Open();
            try
            {
                cmdtxt = @"SELECT SUM(montantdebit)-SUM(montantcredit) 
                FROM OperationCompte op
                JOIN Operation o ON o.idoperation= op.idoperation
                WHERE op.numcompte = @numcompte AND date_operation BETWEEN @dateDe AND @dateA";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@dateDe", "01/01/" + DateTime.Now.Year);
                cmd.Parameters.AddWithValue("@dateA", DateTime.Now.ToShortDateString());
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() != "")
                    valeur = Convert.ToDouble(dr[0].ToString());
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
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = double.Parse(c.txtMontant.Text) * c.taux;
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
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text) * c.taux;
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = "0";
                        }
                        else
                        {
                            c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value = double.Parse(c.txtMontant.Text) * c.taux;
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
            }
            else
                MessageBox.Show("Le même numéro compte est au débit et au crédit", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString();
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
                WHERE categorie IN ('U', 'UU') AND montantdebit = 0 AND montantcredit = 0";
            }
            else
                cmdtxt = @"SELECT c.numcompte, libellecompte, soldeouvedebit, soldeouvecredit
                FROM Compte c
                JOIN OperationCompte o ON c.numcompte = o.numcompte
                WHERE categorie IN ('U', 'UU') AND montantdebit = 0 AND montantcredit = 0 AND libellecompte LIKE '" + c.txtRecherche.Text.Replace("'", "") + "%'";
            cmd = new SqlCommand(cmdtxt, con);
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
        public void AfficherMouvement(FormComptaGdLivre c, string numcompte)
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
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Solde";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[2].Value);
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[3].Value);
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[2].Value) - Convert.ToDouble(c.dgvCompte.CurrentRow.Cells[3].Value);

                    while (dr.Read())
                    {
                        c.dgvOperation.Rows.Add();
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString();
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
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = "Toaux";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[2].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[3].Value = "";
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[4].Value = 0;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = 0;
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = c.dgvOperation.Rows[c.dgvOperation.RowCount - 2].Cells[6].Value;
                    for (int i = 0; i < c.dgvOperation.RowCount-1; i++)
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
                            c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[1].Value = dr[1].ToString();
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
        #endregion

        #region APPRO_STOCK
        public void ChargerFournisseur(FormApprov a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT libellecompte FROM Compte WHERE numcompte LIKE '40110%' AND categorie = 'U' AND numcompte != '401100'", con);
                dr = cmd.ExecuteReader();
                a.cboFournisseur.Items.Clear();
                while (dr.Read())
                {
                    a.cboFournisseur.Items.Add(dr[0].ToString());
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
                                if(Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[7].Value) <= Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[6].Value))
                                {
                                    if(Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[7].Value)>0)
                                    {
                                        if (a.txtTaux.Text == "")
                                            a.txtTaux.Text = "20";
                                        a.dgvAppro.CurrentRow.Cells[9].Value = Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[8].Value) + Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[8].Value) * Convert.ToDouble(a.txtTaux.Text) / 100;
                                        if (a.txtValeurMin.Text != "")
                                            a.dgvAppro.CurrentRow.Cells[9].Value = Convert.ToInt32(a.txtValeurMin.Text) * Math.Ceiling(Convert.ToDouble(a.dgvAppro.CurrentRow.Cells[9].Value) / 50);
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
                                    MessageBox.Show("La quantité ajoutée ne doit pas dépasser celle approvisionnée","Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    a.dgvAppro.CurrentRow.Cells[7].Value = 0;
                                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = 0;
                                }
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
                        ap.idoperation = NouveauID("operation");
                        if (AjouterOperation(ap.idoperation, ap.dtpDateJour.Text, "BL", TrouverId("typejournal", "achats"), ap.idexercice, 0, ""))
                        {
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
                    brut = c.dgvActif.Rows[i].Cells[4].Value.ToString(),
                    amortDeprec = c.dgvActif.Rows[i].Cells[5].Value.ToString(),
                    net = c.dgvActif.Rows[i].Cells[6].Value.ToString(),
                    exercicepasse = c.dgvActif.Rows[i].Cells[7].Value.ToString()
                };
                list.Add(actif);
            }
            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BilanActif.rdlc";
            imp.ShowDialog();
        }
        public void ImprimerPassif(FormComptaBilan c, FormImpression imp)
        {
            imp.Text = "SSM - Passif du Bilan";

            List<Bilan_Passif> list = new List<Bilan_Passif>();
            list.Clear();

            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                Bilan_Passif actif = new Bilan_Passif
                {
                    refPassif = c.dgvActif.Rows[i].Cells[0].Value.ToString(),
                    rubriquePassif = c.dgvActif.Rows[i].Cells[1].Value.ToString(),
                    notePassif = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                    netEncours = c.dgvActif.Rows[i].Cells[3].Value.ToString(),
                    netPasse = c.dgvActif.Rows[i].Cells[4].Value.ToString()
                };
                list.Add(actif);
            }
            rs.Name = "DataSet3";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BilanPassif.rdlc";
            imp.ShowDialog();
        }
        public void ImprimerToutBilan(FormComptaBilan c, FormImpression imp)
        {
            imp.Text = "SSM - Actif et Passif du Bilan";

            //Actif
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
                    brut = c.dgvActif.Rows[i].Cells[4].Value.ToString(),
                    amortDeprec = c.dgvActif.Rows[i].Cells[5].Value.ToString(),
                    net = c.dgvActif.Rows[i].Cells[6].Value.ToString(),
                    exercicepasse = c.dgvActif.Rows[i].Cells[7].Value.ToString()
                };
                list.Add(actif);
            }
            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.Bilan.rdlc";

            //Passif
            List<Bilan_Passif> list2 = new List<Bilan_Passif>();
            list2.Clear();

            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                Bilan_Passif actif = new Bilan_Passif
                {
                    refPassif = c.dgvActif.Rows[i].Cells[0].Value.ToString(),
                    rubriquePassif = c.dgvActif.Rows[i].Cells[1].Value.ToString(),
                    notePassif = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                    netEncours = c.dgvActif.Rows[i].Cells[3].Value.ToString(),
                    netPasse = c.dgvActif.Rows[i].Cells[4].Value.ToString()
                };
                list2.Add(actif);
            }
            rs2.Name = "DataSet3";
            rs2.Value = list2;
            //imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs2);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.Bilan.rdlc";
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
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = dr[2].ToString();
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = dr[3].ToString();
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = dr[4].ToString();
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = dr[5].ToString();                       
                   }
                   else
                   {
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = Convert.ToDouble(dr[2].ToString()) * c.taux;
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = Convert.ToDouble(dr[3].ToString()) * c.taux;
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = Convert.ToDouble(dr[4].ToString()) * c.taux;
                       c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = Convert.ToDouble(dr[5].ToString()) * c.taux;                     
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
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = "Totaux bilan";
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = "Totaux comptes gestion";
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
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
                        valeur += double.Parse(dgv.Rows[j].Cells[i].Value.ToString());
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
            imp.Text = "SSM - Balance";

            List<Balance> list = new List<Balance>();
            list.Clear();

            for (int i = 0; i < c.dgvBalance.RowCount; i++)
            {
                Balance bal = new Balance
                {
                    numcompte = c.dgvBalance.Rows[i].Cells[0].Value.ToString(),
                    libelle = c.dgvBalance.Rows[i].Cells[1].Value.ToString(),
                    debit_ouv = c.dgvBalance.Rows[i].Cells[2].Value.ToString(),
                    credit_ouv = c.dgvBalance.Rows[i].Cells[3].Value.ToString(),
                    debit_mouv = c.dgvBalance.Rows[i].Cells[4].Value.ToString(),
                    credit_mouv = c.dgvBalance.Rows[i].Cells[5].Value.ToString(),
                    debit_fin = c.dgvBalance.Rows[i].Cells[6].Value.ToString(),
                    credit_fin = c.dgvBalance.Rows[i].Cells[7].Value.ToString()
                };
                list.Add(bal);
            }
            rs.Name = "DataSet2";
            rs.Value = list;
            imp.reportViewer1.LocalReport.DataSources.Clear();
            imp.reportViewer1.LocalReport.DataSources.Add(rs);
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.Balance.rdlc";
            imp.ShowDialog();
            c.btnImprimer.Enabled = false;
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
                new ReportParameter("NTD", "0854630801 / 0816096706")
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
        //private void 
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
        public string brut { get; set; }
        public string amortDeprec { get; set; }
        public string net { get; set; }
        public string exercicepasse { get; set; }
    }
    public class Bilan_Passif
    {
        public string refPassif { get; set; }
        public string rubriquePassif { get; set; }
        public string notePassif { get; set; }
        public string netEncours { get; set; }
        public string netPasse { get; set; }
    }
    public class Balance
    {
        public string numcompte { get; set; }
        public string libelle { get; set; }
        public string debit_ouv { get; set; }
        public string credit_ouv { get; set; }
        public string debit_mouv { get; set; }
        public string credit_mouv { get; set; }
        public string debit_fin { get; set; }
        public string credit_fin { get; set; }
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
        public string netPasse { get; set; }
    }

}
