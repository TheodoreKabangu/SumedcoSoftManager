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
    class ClassCompta: ClasseElements
    {
        private DataLoader _dataLoader;
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
        ClasseExercice exer = new ClasseExercice();
        public void AfficherSousForm(RecetteMDI r, Recette childForm)
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
        public void AfficherSousForm(RecetteMDI r, RecetteJournal childForm)
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
        public void AfficherSousForm(ReceptionMDI r, ReceptionPatient childForm)
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
            else if (motif == "exercice")
            {
                cmd = new SqlCommand("SELECT exercice FROM Exercice", con);
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
        
        public void ChargerRubriqueExamen(MedConsulter c)
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
        public void AutresExamens(MedConsulter c, FormFacture ex)
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
        private void PayementAbonne(TresoEntree t)
        {
            AjouterPayement(
                t.lblDateJour.Text,
                Convert.ToDouble(t.txtMontant.Text),
                t.cboMonnaie.Text,
                t.dgvBon.CurrentRow.Cells[0].Value.ToString(),
                string.Format("Payement abonnés par {0}", t.dgvBon.CurrentRow.Cells[1].Value.ToString())
                            );
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
        public void AnnulerPayement(Recette b, FormPayements p)
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
        public void AgendaCaisse(Recette b, LaboResult a)
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
        public void Afficher(LaboResult a, string motif)
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
        public void Annuler(LaboResult a)
        {
            
        }
        public void Recuperer(LaboResult a)
        {
            
        }
        public void Modifier(LaboResult a)
        {
            
        }
        public void Supprimer(LaboResult a)
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
        public void PayementDette(LaboResult a)
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
        public void AfficherSousForm(TresorerieMDI d, TresoSortie childForm)
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
        public void AfficherSousForm(TresorerieMDI d, TresoEntree childForm)
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
        
        public void ChargerCompte(ComptaPlan d)
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
        public string CompteDepense(ComptaPlan c, string motif)
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
        public void CompteClasse(ComptaPlan c)
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
            
        }
        public void Valider(TresoSortie d)
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
        public void Annuler(TresoSortie d)
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
        private void AjouterDepense(TresoSortie d)
        {

        }

        public void Enregistrer(TresoSortie d)
        {
            //if (d.dgvEcriture.RowCount != 0 && d.txtBeneficiaire.Text != "" && d.cboCaisseDepense.Text != "" && d.txtNumRequisition.Text != "")
            //{
            //    //Montant en lettres
            //    d.montantdecaisse = Convert.ToDouble(d.dgvEcriture.Rows[d.dgvEcriture.RowCount-1].Cells[3].Value);
            //    if (d.montantdecaisse.ToString().Contains(","))
            //    {
            //        chaine = NumbersToWords(long.Parse(d.montantdecaisse.ToString().Substring(0, d.montantdecaisse.ToString().IndexOf(","))));
            //        chaine = string.Format("{0} virgule {1}", chaine, NumbersToWords(long.Parse(d.montantdecaisse.ToString().Substring(d.montantdecaisse.ToString().IndexOf(",") + 1))));
            //    }
            //    else chaine = NumbersToWords(long.Parse(d.montantdecaisse.ToString()));
            //    if (d.cboCaisseDepense.Text == "CDF")
            //        d.txtMontantLettre.Text = chaine.Substring(0, 1).ToUpper() + chaine.Substring(1) + " francs congolais";
            //    else if (d.cboCaisseDepense.Text == "USD")
            //        d.txtMontantLettre.Text = chaine.Substring(0, 1).ToUpper() + chaine.Substring(1) + " dollars américains";

            //    if (d.soldeCaisse >= d.montantdecaisse)
            //    {                   
            //        //Dépenses
            //        AjouterDepense(d);

            //        //Ecriture comptables
            //        d.idoperation = AjouterOperation(d.lblDateOperation.Text, "DEP", TrouverId("typejournal", d.caisse), d.idexercice);
            //        for (int i = 0; i < d.dgvEcriture.RowCount - 1; i++)
            //        {
            //            if (d.cboCaisseDepense.Text == "CDF")
            //                DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value), d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
            //            else
            //                DebiterCompte(d.idoperation, d.dgvEcriture.Rows[i].Cells[0].Value.ToString(), Convert.ToDouble(d.dgvEcriture.Rows[i].Cells[2].Value) * d.taux, d.dgvEcriture.Rows[i].Cells[1].Value.ToString());
            //        }
            //        CrediterCompte(d.idoperation, d.numcompte, d.montantdecaisse, d.dgvEcriture.Rows[d.dgvEcriture.RowCount - 1].Cells[1].Value.ToString());

            //        ArchiverBon("dépense", d.iddepense);
            //        ImprimerBon(d, new FormImpression());
            //        Annuler(d);
            //    }
            //    else
            //        MessageBox.Show("Solde caisse insuffisant", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void AjouterEncaissement(TresoEntree d)
        {

        }
        public void Annuler(TresoEntree t)
        {
            t.txtMontant.Text = "";
            t.cboEncaisser.DropDownStyle = ComboBoxStyle.DropDown;
            t.cboEncaisser.SelectedText = "";
            t.cboEncaisser.DropDownStyle = ComboBoxStyle.DropDownList;
            t.dgvBon.Rows.Clear();
        }
        public void Encaisser(TresoEntree d)
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

        #endregion

        #region SERVICE
        public void Enregistrer(Service s)
        {
            if(s.cboCatService.Text !="" && s.txtNomService.Text !="" && s.txtPrixService.Text !="" && s.cboSpecification.Text != "")
            {
                s.idservice = NouveauID("service");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Service values (@id, @nom, @prix, @specification, @numcompte)", con);
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
        public void Modifier(Service s)
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
        public void Supprimer(Service s)
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
        public void Annuler(Service s)
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
        public void Afficher(Service s)
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
        public void Recuperer(Service s)
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

        ClassStock cs = new ClassStock();
        ClasseElements ce = new ClasseElements();

        #region COMPTABILITE

        public void AfficherSousForm(ComptabiliteMDI c, StockApproCom childForm)
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

        public void Enregistrer(ComptaExercice c)
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
        public void Afficher(ComptaExercice c)
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
        public void Supprimer(ComptaExercice c)
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
        
        public void AfficherOperations(ComptabiliteMDI c, ComptaOperation child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }
        public void AfficherGrandLivre(ComptabiliteMDI c, ComptaGdLivre child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
        }
        public void AfficherBilan(ComptabiliteMDI c, ComptaBilan child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);         
        }
        public void AfficherSousForm(ComptabiliteMDI c, Form child)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(child);
            c.pnlChildForm.Tag = child;
            child.BringToFront();
            child.Show();
        }
        public void PlanComptes(ComptabiliteMDI c, ComptaComptes child)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(child);
            c.pnlChildForm.Tag = child;
            child.BringToFront();
            child.type_comptabilite = c.type_comptabilite;
            child.Show();
        }
        public void AfficherFluxTresorerie(ComptabiliteMDI c, TresoFlux child)
        {
            if (c.activeForm != null)
                c.activeForm.Close();
            c.activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(child);
            c.pnlChildForm.Tag = child;
            child.BringToFront();
            child.btnEntree.Enabled = false;
            child.btnSortie.Enabled = false;
            child.btnPrepEcriture.Enabled = true;
            child.affectation = c.affectation;
            child.Show();
        }
        public void AfficherTableauFluxT(ComptabiliteMDI c, ComptaTableauFlux child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AfficherBalance(ComptabiliteMDI c, ComptaBalance child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                con.Open();
                cmd = new SqlCommand("SELECT idexercice from Exercice where statut IS NULL", con);
                dr = cmd.ExecuteReader();
                dr.Read();
                child.idexercice = int.Parse(dr[0].ToString());
                con.Close();

                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AfficherResultat(ComptabiliteMDI c, ComptaResultat child)
        {
            id = exer.NbExerciceEncours();
            if (id == 1)
            {
                child.idexercice = exer.ExerciceEncours();
                if (c.activeForm != null)
                    c.activeForm.Close();
                c.activeForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                child.Dock = DockStyle.Fill;
                c.pnlChildForm.Controls.Add(child);
                c.pnlChildForm.Tag = child;
                child.BringToFront();
                child.type_comptabilite = c.type_comptabilite;
                child.Show();
            }
            else
                MessageBox.Show("Besoin d'un exercice comptable en cours. Contactez le comptable de l'entreprise", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        public int VerifierNumCompte(string numcompte, string libelle)
        {
            id = 0;
            con.Open();
            cmd = new SqlCommand("SELECT COUNT(numcompte) FROM Compte WHERE numcompte= @num OR libellecompte= @libelle", con);
            cmd.Parameters.AddWithValue("@num", numcompte);
            cmd.Parameters.AddWithValue("@libelle", libelle);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        bool ajoutvalide;
        public void Enregistrer(ComptaComptes c)
        {
            ajoutvalide = false;
            for(int i= c.dgvCompte.RowCount-1; i>=0; i--)
            {
                if (c.dgvCompte.Rows[i].Cells[0].Value.ToString() != "" && c.dgvCompte.Rows[i].Cells[1].Value.ToString() != "" && c.dgvCompte.Rows[i].Cells[2].Value.ToString() != "" && c.dgvCompte.Rows[i].Cells[3].Value.ToString() != "")
                {
                    if (VerifierNumCompte(c.dgvCompte.Rows[i].Cells[0].Value.ToString(), c.dgvCompte.Rows[i].Cells[1].Value.ToString()) == 0)
                    {
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            if (c.type_comptabilite == "routine") 
                                cmd = new SqlCommand("INSERT INTO Compte VALUES (@numcompte, @libelle, @ref_debit, @ref_credit)", con);
                            else
                                cmd = new SqlCommand("INSERT INTO Compteprojet VALUES (@numcompte, @libelle, @ref_debit, @ref_credit)", con);
                            cmd.Parameters.AddWithValue("@numcompte", c.dgvCompte.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@libelle", c.dgvCompte.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.AddWithValue("@ref_debit", c.dgvCompte.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.AddWithValue("@ref_credit", c.dgvCompte.Rows[i].Cells[3].Value.ToString());
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            ajoutvalide = true;
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
                        MessageBox.Show("Ce compte exite déjà dans le système", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (ajoutvalide) MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            c.dgvCompte.Rows.Clear();
        }
        public void Modifier(ComptaComptes c)
        {
            if (c.dgvCompte.Rows[0].Cells[0].Value.ToString() != "" && c.dgvCompte.Rows[0].Cells[1].Value.ToString() != "" && c.dgvCompte.Rows[0].Cells[2].Value.ToString() != "" && c.dgvCompte.Rows[0].Cells[3].Value.ToString() != "")
            {
                if (VerifierNumCompte(c.dgvCompte.Rows[0].Cells[0].Value.ToString(), c.dgvCompte.Rows[0].Cells[1].Value.ToString()) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        if (c.type_comptabilite == "routine") 
                            cmd = new SqlCommand("UPDATE Compte SET numcompte = @newcompte, libellecompte= @libelle, ref_debit = @ref_debit, ref_credit = @ref_credit WHERE numcompte= @numcompte", con);
                        else
                            cmd = new SqlCommand("UPDATE Compteprojet SET numcompte = @newcompte, libellecompte= @libelle, ref_debit = @ref_debit, ref_credit = @ref_credit WHERE numcompte= @numcompte", con);
                        cmd.Parameters.AddWithValue("@numcompte", c.numcompte);
                        cmd.Parameters.AddWithValue("@newcompte", c.dgvCompte.Rows[0].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@libelle", c.dgvCompte.Rows[0].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@ref_debit", c.dgvCompte.Rows[0].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@ref_credit", c.dgvCompte.Rows[0].Cells[3].Value.ToString());
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        c.btnModifier.Enabled = false;
                        MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Ce compte exite déjà dans le système", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int CompterOperationCompte(string numcompte, string type_comptabilite)
        {
            id = 0;
            con.Open();

            if (type_comptabilite == "routine") 
                cmd = new SqlCommand("SELECT COUNT(id) FROM OperationCompte WHERE numcompte = @numcompte", con);
            else
                cmd = new SqlCommand("SELECT COUNT(id) FROM OperationCompteprojet WHERE numcompte = @numcompte", con);
            cmd.Parameters.AddWithValue("@numcompte", numcompte);
            dr = cmd.ExecuteReader();
            dr.Read();
            id = int.Parse(dr[0].ToString());
            con.Close();
            return id;
        }
        public void Supprimer(ComptaComptes c)
        {
           if(CompterOperationCompte(c.dgvCompte.CurrentRow.Cells[0].Value.ToString(), c.type_comptabilite)==0)
           {
               con.Open();
               SqlTransaction tx = con.BeginTransaction();
               try
               {
                   if (c.type_comptabilite == "routine") 
                       cmd = new SqlCommand("DELETE FROM Compte WHERE numcompte= @numcompte", con);
                   else
                       cmd = new SqlCommand("DELETE FROM Compteprojet WHERE numcompte= @numcompte", con);
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
        public void Afficher(ComptaComptes c)
        {
            c.dgvCompte.ReadOnly = true;
            c.dgvCompte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            c.btnAjouter.Enabled = false;
            con.Open();
            try
            {
                if(c.type_comptabilite== "routine")
                {
                    if (c.cboClasse.Text != "" && c.txtRecherche.Text == "")
                    {
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' ORDER BY numcompte", con);

                    }
                    else if (c.cboClasse.Text != "" && c.txtRecherche.Text != "")
                    {
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compte WHERE numcompte like '" + c.cboClasse.Text + "%' AND libellecompte LIKE '%" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY numcompte", con);
                    }
                    else if (c.cboClasse.Text == "" && c.txtRecherche.Text != "")
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compte WHERE libellecompte LIKE '%" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY libellecompte", con);
                }
                else
                {
                    if (c.cboClasse.Text != "" && c.txtRecherche.Text == "")
                    {
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compteprojet WHERE numcompte like '" + c.cboClasse.Text + "%' ORDER BY numcompte", con);

                    }
                    else if (c.cboClasse.Text != "" && c.txtRecherche.Text != "")
                    {
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compteprojet WHERE numcompte like '" + c.cboClasse.Text + "%' AND libellecompte LIKE '%" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY numcompte", con);
                    }
                    else if (c.cboClasse.Text == "" && c.txtRecherche.Text != "")
                        cmd = new SqlCommand("SELECT numcompte, libellecompte, ref_debit, ref_credit FROM Compteprojet WHERE libellecompte LIKE '%" + c.txtRecherche.Text.Replace("'", "") + "%' ORDER BY libellecompte", con);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public void AfficherRapportGlobal(ComptaRecetteDepense r)
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
        private void MontantRapportGlobal(ComptaRecetteDepense r)
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
        public void CalculerTotauxRapportGlobal(ComptaRecetteDepense r)
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
        public int AjouterOperation(string date_jour, int idtypejournal, int idexercice, string type_comptabilite)
        {
            if (type_comptabilite == "routine")
            {
                id = ce.NouveauID("operation");
                cmd = new SqlCommand("INSERT INTO Operation VALUES (@id, @date_jour, @idtypejournal, @idexercice)", con);
            }
            else
            {
                id = ce.NouveauID("operationprojet");
                cmd = new SqlCommand("INSERT INTO Operationprojet VALUES (@id, @date_jour, @idtypejournal, @idexercice)", con);
            }
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {

                MessageBox.Show("" + date_jour.Length);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@date_jour", date_jour);
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
        public void CrediterCompte(int idoperation, string numpiece, string comptecredit, double mcredit, string libelle, string type_comptabilite)
        {
            //Montant crédit
            if (type_comptabilite == "routine")
            {
                id = ce.NouveauID("operationcompte");
                cmd = new SqlCommand("INSERT INTO OperationCompte VALUES (@id, @idoperation, @numpiece, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit, @numcompte)", con);
            }
            else
            {
                id = ce.NouveauID("operationcompteprojet");
                cmd = new SqlCommand("INSERT INTO OperationCompteprojet VALUES (@id, @idoperation, @numpiece, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit, @numcompte)", con);
            }
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idoperation", idoperation);
                cmd.Parameters.AddWithValue("@numpiece", numpiece);
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
        public void DebiterCompte(int idoperation, string numpiece, string comptedebit, double mdebit, string libelle, string type_comptabilite)
        {
            //Montant débit
            if (type_comptabilite == "routine")
            {
                id = ce.NouveauID("operationcompte");
                cmd = new SqlCommand("INSERT INTO OperationCompte VALUES (@id, @idoperation, @numpiece, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit, @numcompte)", con);
            }
            else
            {
                id = ce.NouveauID("operationcompteprojet");
                cmd = new SqlCommand("INSERT INTO OperationCompteprojet VALUES (@id, @idoperation, @numpiece, @mdebit, @mcredit, @libelle, @soldeouvdebit, @soldeouvcredit, @numcompte)", con);
            }

            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {              
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idoperation", idoperation);
                cmd.Parameters.AddWithValue("@numpiece", numpiece);
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
        public void InitialiserCompteExercice()
        {
            
        }
        public void Enregistrer(ComptaEcriture c)
        {
            if (c.dgvEcriture.RowCount > 1 && c.cboTypeJournal.Text != "")
            {
                if (c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value != "" &&
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value != "" &&
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value != "" &&
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value != "" &&
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value != "")
                {
                    //Ajouter la ligne de totaux
                    TotalDebitCredit(c.dgvEcriture, 3, 4, 0);
                    if (Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[3].Value) ==
                        Convert.ToDouble(c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[4].Value))
                    {
                        c.idoperation = AjouterOperation(c.lblDateOperation.Text, c.idtypejournal, c.idexercice, c.type_comptabilite);
                        for (int i = 0; i < c.dgvEcriture.RowCount - 1; i++)
                        {
                            if (Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[3].Value) != 0)
                                DebiterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), c.dgvEcriture.Rows[i].Cells[1].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[3].Value), c.dgvEcriture.Rows[i].Cells[2].Value.ToString(), c.type_comptabilite);
                            if (Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[4].Value) != 0)
                                CrediterCompte(c.idoperation, c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), c.dgvEcriture.Rows[i].Cells[1].Value.ToString(), Convert.ToDouble(c.dgvEcriture.Rows[i].Cells[4].Value), c.dgvEcriture.Rows[i].Cells[2].Value.ToString(), c.type_comptabilite);
                        }
                        c.dgvEcriture.Rows.Clear();
                        MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else MessageBox.Show("Opération non équilibrée", "Attention !!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else MessageBox.Show("Rassurez-vous que la dernière écriture contient toutes les valeurs", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Vérifiez que les champ(s) ont des valeurs et que l'écriture est complète (débit et crédit)", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void TotalDebitCredit(DataGridView dgv, int i_debit, int i_credit, int index_total)
        {
            if(dgv.Rows[dgv.RowCount-1].Cells[0].Value.ToString()=="Totaux")
            {
                dgv.Rows.RemoveAt(dgv.Rows[dgv.RowCount - 1].Index);
                dgv.Rows.Add();
                dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                dgv.Rows[dgv.RowCount - 1].Cells[index_total].Value = "Totaux";
                dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value = 0;
                dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value = (Convert.ToDouble(dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value) + Convert.ToDouble(dgv.Rows[i].Cells[i_debit].Value));
                    dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value = (Convert.ToDouble(dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value) + Convert.ToDouble(dgv.Rows[i].Cells[i_credit].Value));
                }
            }
            else
            {
                dgv.Rows.Add();
                dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
                dgv.Rows[dgv.RowCount - 1].Cells[index_total].Value = "Totaux";
                dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value = 0;
                dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value = 0;
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value = (Convert.ToDouble(dgv.Rows[dgv.RowCount - 1].Cells[i_debit].Value) + Convert.ToDouble(dgv.Rows[i].Cells[i_debit].Value));
                    dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value = (Convert.ToDouble(dgv.Rows[dgv.RowCount - 1].Cells[i_credit].Value) + Convert.ToDouble(dgv.Rows[i].Cells[i_credit].Value));
                }
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
        public async void Afficher(ComptaOperation c)
        {           
            c.sommeCredit = 0; c.sommeDebit = 0;
            _dataLoader = new DataLoader(conString);

            con.Open();
            try
            {
                if (c.type_comptabilite == "routine")
                {
                    if (c.cboTypeJournal.Text != "")
                    {
                        cmdtxt = @"SELECT o.idoperation AS ID, date_operation AS Date, numpiece AS [N° pièce], libelle AS Libellé, numcompte AS Compte, COALESCE(montantdebit,0) AS Débit, COALESCE(montantcredit, 0) AS Crédit
                    FROM Operation o
                    JOIN OperationCompte oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                        // Load data asynchronously without freezing UI
                        await _dataLoader.LoadOpertationJournalAsync(c, cmdtxt);
                    }
                    else
                    {
                        cmdtxt = @"SELECT o.idoperation AS ID, date_operation AS Date, numpiece AS [N° pièce], libelle AS Libellé, numcompte AS Compte, COALESCE(montantdebit,0) AS Débit, COALESCE(montantcredit, 0) AS Crédit
                    FROM Operation o
                    JOIN OperationCompte oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                        //Load data
                        await _dataLoader.LoadOperationAsync(c, cmdtxt);
                    }
                }
                else
                {
                    if (c.cboTypeJournal.Text != "")
                    {
                        cmdtxt = @"SELECT SELECT o.idoperation AS ID, date_operation AS Date, numpiece AS [N° pièce], libelle AS Libellé, numcompte AS Compte, COALESCE(montantdebit,0) AS Débit, COALESCE(montantcredit, 0) AS Crédit
                    FROM Operation o
                    JOIN OperationCompteprojet oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND idtypejournal = @typejournal AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                        //Load data
                        await _dataLoader.LoadOpertationJournalAsync(c, cmdtxt);
                    }
                    else
                    {
                        cmdtxt = @"SELECT o.idoperation AS ID, date_operation AS Date, numpiece AS [N° pièce], libelle AS Libellé, numcompte AS Compte, COALESCE(montantdebit,0) AS Débit, COALESCE(montantcredit, 0) AS Crédit
                    FROM Operation o
                    JOIN OperationCompteprojet oc ON o.idoperation = oc.idoperation
                    WHERE idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantdebit != 0
                    OR idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA AND montantcredit != 0";
                        //Load data
                        await _dataLoader.LoadOperationAsync(c, cmdtxt);
                    }
                }

                for (int i = 0; i < c.dgvOperation.RowCount;i++)
                {
                    c.sommeDebit += Convert.ToDouble(c.dgvOperation.Rows[i].Cells[5].Value);
                    c.sommeCredit += Convert.ToDouble(c.dgvOperation.Rows[i].Cells[6].Value);
                }
                c.lblDebit.Text = c.sommeDebit.ToString("0.00");
                c.lblCredit.Text = c.sommeCredit.ToString("0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AjouterSolde(ComptaOperation c)
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
        public void ChargerCompte(ComptaGdLivre c)
        {
            if (c.txtRecherche.Text == "")
            {
                cmdtxt = @"SELECT c.numcompte, libellecompte, soldeouvedebit, soldeouvecredit  
                FROM Compte c
                JOIN OperationCompte o ON c.numcompte = o.numcompte
                JOIN Operation op ON o.idoperation = op.idoperation
                WHERE idexercice = @idexercice AND montantdebit = 0 AND montantcredit = 0";
            }
            else
                cmdtxt = @"SELECT c.numcompte, libellecompte, soldeouvedebit, soldeouvecredit
                FROM Compte c
                JOIN OperationCompte o ON c.numcompte = o.numcompte
                JOIN Operation op ON o.idoperation = op.idoperation
                WHERE idexercice = @idexercice AND montantdebit = 0 AND montantcredit = 0 AND libellecompte LIKE '" + c.txtRecherche.Text.Replace("'", "") + "%'";
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
        public void AfficherMouvement(ComptaGdLivre c, string numcompte)
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

        private void AutresCreances(ComptaBilan c, string motif)
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
        
        string[] cpte_2_solde = { "BE", "BW", "DI", "DW" };
        private List<double> TresoBilan(string ref_code, string motif, int exercice, DateTimePicker dateDe, DateTimePicker dateA)
        {
            list_solde.Clear();
            con.Open();
            try
            {
                if (motif == "debit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_debit = @ref 
                        AND c.numcompte NOT LIKE '52%' AND c.numcompte NOT LIKE '53%' 
                        AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_debit";
                else if (motif == "credit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_credit = @ref 
                        AND c.numcompte LIKE '56%' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_credit";
                if (motif == "debit_")
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_debit = @ref AND c.numcompte LIKE '52%' AND o.date_operation BETWEEN @dateDe AND @dateA 
                        OR o.idexercice = @idexercice AND ref_debit = @ref AND c.numcompte LIKE '53%' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_debit";
                else if (motif == "credit_")
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_credit = @ref AND c.numcompte LIKE '52%' AND o.date_operation BETWEEN @dateDe AND @dateA 
                        OR o.idexercice = @idexercice AND ref_credit = @ref AND c.numcompte LIKE '53%' AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_credit";
                
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", exercice);
                cmd.Parameters.AddWithValue("@ref", ref_code);
                cmd.Parameters.AddWithValue("@dateDe", dateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", dateA.Text);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list_solde.Add(Convert.ToDouble(dr[0].ToString()));
                    list_solde.Add(Convert.ToDouble(dr[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return list_solde;
        }
        List<double> list_solde = new List<double>();
        private List<double> SoldeRef(string ref_code, string motif, int exercice, DateTimePicker dateDe, DateTimePicker dateA)
        {
            list_solde.Clear(); list_solde.Add(0); list_solde.Add(0);

            con.Open();
            try
            {
                if(motif == "debit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte NOT LIKE '28%' AND c.numcompte NOT LIKE '29%' 
                        AND ref_debit = @ref AND ref_credit IS NULL AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_debit";
                else if (motif == "credit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte NOT LIKE '28%' AND c.numcompte NOT LIKE '29%' 
                        AND ref_credit = @ref AND ref_debit IS NULL AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_credit";
                else if (motif == "debit_credit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte NOT LIKE '28%' AND c.numcompte NOT LIKE '29%' 
                        AND ref_debit = @ref AND ref_credit IS NOT NULL AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_debit";
                else if (motif == "credit_debit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte NOT LIKE '28%' AND c.numcompte NOT LIKE '29%' 
                        AND ref_credit = @ref AND ref_debit IS NOT NULL AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_credit";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", exercice);
                cmd.Parameters.AddWithValue("@ref", ref_code);
                cmd.Parameters.AddWithValue("@dateDe", dateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", dateA.Text);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list_solde.Add(Convert.ToDouble(dr[0].ToString()));
                    list_solde.Add(Convert.ToDouble(dr[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return list_solde;
        }
        private List<double> SoldeCompte(string numcompte, string motif, int exercice, DateTimePicker dateDe, DateTimePicker dateA)
        {
            list_solde.Clear();
            con.Open();
            try
            {
                if (motif == "debit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '"+numcompte+
                        "%' AND o.date_operation BETWEEN @dateDe AND @dateA GROUP BY ref_debit";
                else if (motif == "credit")
                    cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND c.numcompte LIKE '"+numcompte+
                        "%' AND o.date_operation BETWEEN @dateDe AND @dateA GROUP BY ref_credit";

                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idexercice", exercice);
                cmd.Parameters.AddWithValue("@dateDe", dateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", dateA.Text);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list_solde.Add(Convert.ToDouble(dr[0].ToString()));
                    list_solde.Add(Convert.ToDouble(dr[1].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return list_solde;
        }
        private void AfficherActif(ComptaBilan c)
        {
            for (int i = 0; i < c.dgvActif.RowCount; i++)
            {
                list_solde = SoldeRef(c.dgvActif.Rows[i].Cells[0].Value.ToString(), "debit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                c.dgvActif.Rows[i].Cells[3].Value = list_solde[0];
                c.dgvActif.Rows[i].Cells[6].Value = list_solde[1];
                //Le cas de solde débiteur ou créditeur
                if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == "BE" || c.dgvActif.Rows[i].Cells[0].Value.ToString() == "BW")
                {
                    list_solde = SoldeRef(c.dgvActif.Rows[i].Cells[0].Value.ToString(), "debit_credit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                    if (list_solde[0] > 0)
                    {
                        c.dgvActif.Rows[i].Cells[3].Value = Convert.ToDouble(c.dgvActif.Rows[i].Cells[3].Value) + list_solde[0];
                        c.dgvActif.Rows[i].Cells[6].Value = Convert.ToDouble(c.dgvActif.Rows[i].Cells[6].Value) + list_solde[1];
                    }
                }               
                //Amortissement & depréciation
                if (c.dgvActif.Rows[i].Cells[0].Value.ToString().StartsWith("A"))
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT 
                    ((SUM(montantdebit)-SUM(montantcredit)) +
                    (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS Solde 
                    FROM OperationCompte oc 
                    JOIN Operation o ON oc.idoperation = o.idoperation
                    JOIN Compte c ON oc.numcompte = c.numcompte
                    WHERE o.idexercice = @idexercice AND c.numcompte LIKE '28%' AND ref_debit = @ref AND o.date_operation BETWEEN @dateDe AND @dateA 
                    OR o.idexercice = @idexercice AND c.numcompte LIKE '29%' AND ref_debit = @ref AND o.date_operation BETWEEN @dateDe AND @dateA 
                    GROUP BY ref_debit";

                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idexercice", c.idexercice);
                        cmd.Parameters.AddWithValue("@ref", c.dgvActif.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);

                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (dr[0].ToString() != "")
                                c.dgvActif.Rows[i].Cells[4].Value = Convert.ToDouble(dr[0].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    //Calcul du net
                    c.dgvActif.Rows[i].Cells[5].Value = Convert.ToDouble(c.dgvActif.Rows[i].Cells[3].Value) - Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value);
                }
            }
            CalculerTotalBilan(c.dgvActif, 3);
        }
        private void AfficherPassif(ComptaBilan c)
        {
            for (int i = 0; i < c.dgvPassif.RowCount; i++)
            {
                if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == "DH" || c.dgvActif.Rows[i].Cells[0].Value.ToString() == "DY")
                {
                    list_solde = SoldeRef(c.dgvPassif.Rows[i].Cells[0].Value.ToString(), "credit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                    c.dgvActif.Rows[i].Cells[3].Value = list_solde[0];
                    c.dgvActif.Rows[i].Cells[4].Value = list_solde[1];                   
                }               
                //Le cas de solde débiteur ou créditeur
                else if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == "DI" || c.dgvActif.Rows[i].Cells[0].Value.ToString() == "DW")
                {
                    list_solde = SoldeRef(c.dgvPassif.Rows[i].Cells[0].Value.ToString(), "credit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                    c.dgvActif.Rows[i].Cells[3].Value = list_solde[0];
                    c.dgvActif.Rows[i].Cells[4].Value = list_solde[1];
                    list_solde = SoldeRef(c.dgvPassif.Rows[i].Cells[0].Value.ToString(), "credit_debit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                    if (list_solde[0] > 0)
                    {
                        c.dgvActif.Rows[i].Cells[3].Value = Convert.ToDouble(c.dgvPassif.Rows[i].Cells[3].Value) + list_solde[0];
                        c.dgvActif.Rows[i].Cells[4].Value = Convert.ToDouble(c.dgvPassif.Rows[i].Cells[4].Value) + list_solde[1];
                    }
                }
                else
                {
                    list_solde = SoldeRef(c.dgvPassif.Rows[i].Cells[0].Value.ToString(), "debit", c.idexercice, c.dtpDateDe, c.dtpDateA);
                    c.dgvActif.Rows[i].Cells[3].Value = list_solde[0];
                    c.dgvActif.Rows[i].Cells[4].Value = list_solde[1];
                }
                                
            }
            //resultat
            //c.dgvPassif.Rows[7].Cells[3].Value = Convert.ToDouble(c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[6].Value) - Convert.ToDouble(c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[3].Value);
            CalculerTotalBilan(c.dgvPassif, 3);
        }
        public void AfficherBilan(ComptaBilan c)
        {
            AfficherActif(c);
            AfficherPassif(c);
            CalculerSousTotauxBilan(c);
        }
        private void RubriquesActif(ComptaBilan c)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT ref, libelle, note FROM RubriqueEtatFin WHERE etat = 'actif'";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                c.dgvActif.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvActif.Rows.Add();
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[3].Value = 0;
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[4].Value = 0;
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[5].Value = 0;
                    c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[6].Value = 0;
                }
                c.dgvActif.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        private void RubriquesPassif(ComptaBilan c)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT ref, libelle, note FROM RubriqueEtatFin WHERE etat = 'passif'";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                c.dgvPassif.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPassif.Rows.Add();
                    c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[3].Value = 0;
                    c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[4].Value = 0;
                }
                c.dgvPassif.ClearSelection();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Rubriques(ComptaBilan c)
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
        private void CalculerSousTotauxBilan(ComptaBilan c)
        {
            //total actif immobilisé
            for (int i = 3; i < 7; i++)
            {
                c.dgvActif.Rows[17].Cells[i].Value = 0;
                for (int j = 0; j < 17; j++)
                {
                    c.dgvActif.Rows[17].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[17].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }
            //total actif circulant
            for (int i = 3; i < 7; i++)
            {
                c.dgvActif.Rows[23].Cells[i].Value = 0;
                for (int j = 19; j < 23; j++)
                {
                    c.dgvActif.Rows[23].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[23].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }
            //total tresorerie actif
            for (int i = 3; i < 7; i++)
            {
                c.dgvActif.Rows[27].Cells[i].Value = 0;
                for (int j = 24; j < 27; j++)
                {
                    c.dgvActif.Rows[27].Cells[i].Value = Convert.ToDouble(c.dgvActif.Rows[27].Cells[i].Value) + Convert.ToDouble(c.dgvActif.Rows[j].Cells[i].Value);
                }
            }

            //total fonds propres et assmilées
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[10].Cells[i].Value = 0;
                for (int j = 0; j < 10; j++)
                {
                    c.dgvPassif.Rows[10].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[10].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            //total dettes fin. et res. assmilées 
            //for (int i = 3; i < 5; i++)
            //{
            //    c.dgvPassif.Rows[14].Cells[i].Value = 0;
            //    for (int j = 11; j < 14; j++)
            //    {
            //        c.dgvPassif.Rows[14].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[14].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
            //    }
            //}
            
            //total ressources stables
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[19].Cells[i].Value = 0;
                for (int j = 0; j < 19; j++)
                {
                    c.dgvPassif.Rows[19].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[19].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            //total passif circulant
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[24].Cells[i].Value = 0;
                for (int j = 20; j < 24; j++)
                {
                    c.dgvPassif.Rows[24].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[24].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
            //total tresorerie passif
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[26].Cells[i].Value = 0;
                for (int j = 25; j < 26; j++)
                {
                    c.dgvPassif.Rows[26].Cells[i].Value = Convert.ToDouble(c.dgvPassif.Rows[26].Cells[i].Value) + Convert.ToDouble(c.dgvPassif.Rows[j].Cells[i].Value);
                }
            }
        }
        public void ImprimerActif(ComptaBilan c, FormImpression imp)
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
                    noteActif = c.dgvActif.Rows[i].Cells[2].Value.ToString(),
                    brut = Convert.ToDouble(c.dgvActif.Rows[i].Cells[3].Value),
                    amortDeprec = Convert.ToDouble(c.dgvActif.Rows[i].Cells[4].Value),
                    net = Convert.ToDouble(c.dgvActif.Rows[i].Cells[5].Value),
                    exercicepasse = Convert.ToDouble(c.dgvActif.Rows[i].Cells[6].Value)
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
        public void ImprimerPassif(ComptaBilan c, FormImpression imp)
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
        public void ImprimerToutBilan(ComptaBilan c, FormImpression imp)
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
        public void ImprimerBilan(ComptaBilan c)
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
        public void ImprimerGdLivre(ComptaGdLivre c, FormImpression imp)
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
        public void CalculerBalance(ComptaBalance c)
        {
            con.Open();
            try
            {
               cmdtxt = @"SELECT oc.numcompte, libellecompte, SUM(soldeouvedebit), 
                SUM(soldeouvecredit), SUM(montantdebit), SUM(montantcredit) 
                FROM OperationCompte oc
                JOIN Operation o ON oc.idoperation = o.idoperation
                JOIN Compte c ON oc.numcompte = c.numcompte
                WHERE idexercice = @idexercice AND date_operation BETWEEN @dateDe AND @dateA
                GROUP BY oc.numcompte, libellecompte";
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
        public void ImprimerBalance(ComptaBalance c, FormImpression imp)
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
        private void SupprimerLigne(ComptaBalance c, int nbligne)
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
        string[] rublist_TR= {"RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "XA", "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI", "TJ", "TK", "TL", "XB", "XC", "TM", "TN", "XD", "XE"};
        public void RubriquesResultat(ComptaResultat c)
        {
            c.dgvResultat.Rows.Clear();
            for (int i = 0; i < rublist_TR.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT ref, libelle, descriptif, note FROM RubriqueEtatFin WHERE etat = 'TR' AND ref= @reference";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@reference", rublist_TR[i]);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c.dgvResultat.Rows.Add();
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[4].Value = 0;
                        c.dgvResultat.Rows[c.dgvResultat.RowCount - 1].Cells[5].Value = 0;
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            c.dgvResultat.ClearSelection();
        }
        public void CalculerResultat(ComptaResultat c)
        {
            for (int i = 0; i < c.dgvResultat.RowCount; i++)
            {
                con.Open();
                try
                {
                    if (c.dgvResultat.Rows[i].Cells[0].Value.ToString().StartsWith("T") && c.dgvResultat.Rows[i].Cells[0].Value.ToString() !="TM")
                        cmdtxt = @"SELECT 
                        ((SUM(montantdebit)-SUM(montantcredit)) +
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit))) AS SoldeActuel,
                        (SUM(soldeouvedebit)-SUM(soldeouvecredit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_debit = @ref AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_debit";
                    else
                        cmdtxt = @"SELECT 
                        ((SUM(montantcredit)-SUM(montantdebit)) +
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit))) AS SoldeActuel,
                        (SUM(soldeouvecredit)-SUM(soldeouvedebit)) AS  SoldePasse
                        FROM OperationCompte oc 
                        JOIN Operation o ON oc.idoperation = o.idoperation
                        JOIN Compte c ON oc.numcompte = c.numcompte
                        WHERE o.idexercice = @idexercice AND ref_credit = @ref AND o.date_operation BETWEEN @dateDe AND @dateA
                        GROUP BY ref_credit";

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
        public void CalculerTotalResultat(ComptaResultat c)
        {
            //XA = RA à RG
            c.dgvResultat.Rows[8].Cells[4].Value = 0;
            c.dgvResultat.Rows[8].Cells[5].Value = 0;
            for (int i = 0; i < 8; i++)
            {
                c.dgvResultat.Rows[8].Cells[4].Value = double.Parse(c.dgvResultat.Rows[8].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[8].Cells[5].Value = double.Parse(c.dgvResultat.Rows[8].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //XB = TA à TL
            c.dgvResultat.Rows[21].Cells[4].Value = 0;
            c.dgvResultat.Rows[21].Cells[5].Value = 0;
            for (int i = 9; i < 21; i++)
            {
                c.dgvResultat.Rows[21].Cells[4].Value = double.Parse(c.dgvResultat.Rows[21].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[4].Value.ToString());
                c.dgvResultat.Rows[21].Cells[5].Value = double.Parse(c.dgvResultat.Rows[21].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[i].Cells[5].Value.ToString());
            }
            //XC = XA - XB
            c.dgvResultat.Rows[22].Cells[4].Value = 0;
            c.dgvResultat.Rows[22].Cells[5].Value = 0;
            c.dgvResultat.Rows[22].Cells[4].Value = double.Parse(c.dgvResultat.Rows[8].Cells[4].Value.ToString()) - double.Parse(c.dgvResultat.Rows[21].Cells[4].Value.ToString());
            c.dgvResultat.Rows[22].Cells[5].Value = double.Parse(c.dgvResultat.Rows[8].Cells[5].Value.ToString()) - double.Parse(c.dgvResultat.Rows[21].Cells[5].Value.ToString());
            //XD = TM - TN
            c.dgvResultat.Rows[25].Cells[4].Value = 0;
            c.dgvResultat.Rows[25].Cells[5].Value = 0;
            c.dgvResultat.Rows[25].Cells[4].Value = double.Parse(c.dgvResultat.Rows[23].Cells[4].Value.ToString()) - double.Parse(c.dgvResultat.Rows[24].Cells[4].Value.ToString());
            c.dgvResultat.Rows[25].Cells[5].Value = double.Parse(c.dgvResultat.Rows[23].Cells[5].Value.ToString()) - double.Parse(c.dgvResultat.Rows[24].Cells[5].Value.ToString());
            //XE = XC + XD
            c.dgvResultat.Rows[26].Cells[4].Value = 0;
            c.dgvResultat.Rows[26].Cells[5].Value = 0;
            c.dgvResultat.Rows[26].Cells[4].Value = double.Parse(c.dgvResultat.Rows[22].Cells[4].Value.ToString()) + double.Parse(c.dgvResultat.Rows[25].Cells[4].Value.ToString());
            c.dgvResultat.Rows[26].Cells[5].Value = double.Parse(c.dgvResultat.Rows[22].Cells[5].Value.ToString()) + double.Parse(c.dgvResultat.Rows[25].Cells[5].Value.ToString());
        }
        public void ImprimerResultat(ComptaResultat c, FormImpression imp)
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
        string[] rublist_TFT = { "ZA", "ZA_", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "ZB", "ZB_", "FI", "FJ", "FK", "FL", "ZC", "ZC_", "FM", "FN", "FO", "ZD", "ZD_", "FP", "FQ", "ZE", "ZE_", "ZF", "ZG"};
        public void RubriquesTFT(ComptaTableauFlux c)
        {
            c.dgvTFT.Rows.Clear();
            for (int i = 0; i < rublist_TFT.Length; i++)
            {
                con.Open();
                try
                {
                    cmdtxt = @"SELECT ref, libelle, descriptif,note FROM RubriqueEtatFin WHERE etat = 'TFT' AND ref= @reference";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@reference", rublist_TFT[i]);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c.dgvTFT.Rows.Add();
                        c.dgvTFT.Rows[c.dgvTFT.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvTFT.Rows[c.dgvTFT.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        c.dgvTFT.Rows[c.dgvTFT.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        c.dgvTFT.Rows[c.dgvTFT.RowCount - 1].Cells[3].Value = dr[3].ToString();
                        c.dgvTFT.Rows[c.dgvTFT.RowCount - 1].Cells[4].Value = 0;
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
            }
            c.dgvTFT.ClearSelection();            
        }
        public void CalculerTFT(ComptaTableauFlux c)
        {
            TresoresireBilan(c);
            MontantResultatTFT(c);
            MontantBilanTFT(c);
            MontantBalanceTFT(c);
            CalculerSousTotauxTFT(c);
        }

        private void TresoresireBilan(ComptaTableauFlux c)
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
                        AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

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
                            AND o.date_operation BETWEEN @dateDe AND @dateA";


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
                        AND ref = 'BS' AND o.date_operation BETWEEN @dateDe AND @dateA";

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
        public void ImprimerTFT(ComptaTableauFlux c, FormImpression imp)
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
        private void MontantResultatTFT(ComptaTableauFlux c)
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
        private void MontantBilanTFT(ComptaTableauFlux c)
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
        private void MontantBalanceTFT(ComptaTableauFlux c)
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
        private double BalanceMvtCrediteur(ComptaTableauFlux c, int compte)
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
        private double BalanceMvtDebiteur(ComptaTableauFlux c, int compte)
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
        private double BalanceDiffMvt(ComptaTableauFlux c, int compte)
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
        private void CalculerSousTotauxTFT(ComptaTableauFlux c)
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
        public void RubriqueStatService(AdminStatService s)
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
        public void AjouterColonneMois(AdminStatService s)
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
        public void AfficherCasConsultation(AdminStatService s)
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
        public void AfficherCas(AdminStatService s)
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
        public void ImprimerRapportStat(AdminStatService s, FormImpression imp)
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
    
    public class Bilan_Actif
    {
        public string refActif { get; set; }
        public string rubriqueActif { get; set; }
        public string noteActif { get; set; }
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
