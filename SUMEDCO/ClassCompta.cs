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
        int id=0;
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
                case "catservice": cmdtxt = "select libellecatservice from CategorieService where idcatservice = @id"; break;
                case "service": cmdtxt = "select nomservice from Service where idservice = @id"; break;
                case "entreprise": cmdtxt = "select nomentreprise from Entreprise where identreprise = @id"; break;
                case "typeabonne": cmdtxt = "select typeabonne from TypeAbonne where idtypeabonne = @id"; break;
                case "abonne": cmdtxt = "select nomabonne from Abonne where idabonne = @id"; break;
                case "compte": cmdtxt = "select libellecompte from Compte where numcompte = @id"; break;
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
                case "bonrecetteservice": cmdtxt = "select max(numbonS) from BonRecetteService"; break;
                case "bonrecetteproduit": cmdtxt = "select max(numbonP) from BonRecetteProduit"; break;
                case "service": cmdtxt = "select max(idservice) from Service"; break;
                case "bonrecette": cmdtxt = "select max(numbon) from BonRecette"; break;
                case "bondepense": cmdtxt = "select max(numbon) from BonDepense"; break;
                case "depense": cmdtxt = "select max(iddepense) from Depense"; break;
                case "catdepense": cmdtxt = "select max(idcatdepense) from CategorieDepense"; break;
                case "abonne": cmdtxt = "select max(idabonne) from Abonne"; break;
                case "abonneservice": cmdtxt = "select max(id) from AbonneService"; break;
                case "abonneproduit": cmdtxt = "select max(id) from AbonneProduit"; break;
                case "operation": cmdtxt = "select max(idoperation) from Operation"; break;
                case "operationcompte": cmdtxt = "select max(id) from OperationCompte"; break;
                case "employe": cmdtxt = "select max(idemploye) from Employe"; break;
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
        public void ActualiserDesign2(Panel pnlSousMenu, Panel pnlSousMenu2)
        {
            pnlSousMenu.Visible = false;
            pnlSousMenu2.Visible = false;
        }
        public void CacherSousMenu(Panel pnlSousMenu)
        {
            if (pnlSousMenu.Visible == true)
                pnlSousMenu.Visible = false;
        }
        public void AfficherSousMenu(Panel pnlSousMenu)
        {
            if (pnlSousMenu.Visible == false)
                pnlSousMenu.Visible = true;
            else
                pnlSousMenu.Visible = false;
        }
        public void AfficherSousForm(MFormRecette r, FormBonRecette childForm)
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
            childForm.poste = "recette";
            childForm.Show();
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
        public void AfficherSousForm(MFormReception r, FormBonRecette childForm)
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
            childForm.poste = "reception";
            childForm.Show();
        }
        public void AfficherSousForm(MFormReception r, FormPatient childForm)
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
            childForm.poste = "reception";
            if (r.statut == "nouveau")
            {
                childForm.txtRecherche.Enabled = false;
                childForm.btnRecherche.Enabled = false;
            }
            else
                childForm.btnEnregistrer.Enabled = false;
            childForm.statut = r.statut;
            childForm.Show();
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
                    d.txtTaux.Text = "";
                    d.fermeture_succes = true;
                    d.Hide();
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
        public void ChangerDate(DateTaux d, Form f, Label lblDate, Label lblTaux)
        {
            d.ShowDialog();
            if (!d.fermeture_succes)
            {
                f.Close();
                d.Close();
            }
            else
            {
                lblDate.Text = d.dtpTaux.Text;
                lblTaux.Text = VerifierTaux(d.dtpTaux.Value.Date, "valeur").ToString() + " CDF";
            }
        }
        #endregion

        #region FACTURATION
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
                fileName = @"C:\Users\Public\Documents\SSM_Dernier_NumBonRecette.txt";
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
        public void SelectionService(FormFactureService f, FormFactureService2 fs)
        {
            fs.ShowDialog();
            if(fs.selectionvalide)
            {
                f.dgvFacture.Rows.Clear();
                for (int i = 0; i < fs.dgv3.RowCount; i++)
                {
                    f.dgvFacture.Rows.Add();
                    f.dgvFacture.Rows[i].Cells[0].Value = fs.dgv3.Rows[i].Cells[0].Value.ToString();
                    f.dgvFacture.Rows[i].Cells[1].Value = f.dgvFacture.RowCount;
                    f.dgvFacture.Rows[i].Cells[2].Value = fs.dgv3.Rows[i].Cells[1].Value.ToString();
                    f.dgvFacture.Rows[i].Cells[3].Value = fs.dgv3.Rows[i].Cells[2].Value.ToString();
                    f.dgvFacture.Rows[i].Cells[4].Value = "1";
                    f.dgvFacture.Rows[i].Cells[5].Value = f.dgvFacture.Rows[i].Cells[3].Value.ToString();                  
                }
                for (int i = 0; i < f.dgvFacture.RowCount; i++)
                {
                    f.txtTotal.Text = (double.Parse(f.txtTotal.Text) + double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString("0.00");
                }
            }
            fs.Close();
        }
        public void ChargerService(FormFactureService2 f)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idservice, nomservice, prixservice from Service where numcompte = @id", con);
                cmd.Parameters.AddWithValue("@id", f.dgv1.CurrentRow.Cells[0].Value.ToString());
                dr = cmd.ExecuteReader();
                f.dgv2.Rows.Clear();
                while (dr.Read())
                {
                    f.dgv2.Rows.Add();
                    f.dgv2.Rows[f.dgv2.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    f.dgv2.Rows[f.dgv2.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    f.dgv2.Rows[f.dgv2.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerCategorie(FormFactureService2 f)
        {
            con.Open();
            cmd = new SqlCommand("select numcompte, libellecompte from Compte Where numcompte like '7061%' and numcompte <> '706101' or numcompte like '7078%'", con);
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
                cmd = new SqlCommand("select typeabonne from TypeAbonne, EntrepriseTypeAbonne, Entreprise where TypeAbonne.idtypeabonne= EntrepriseTypeAbonne.idtypeabonne and EntrepriseTypeAbonne.identreprise= Entreprise.identreprise and  Entreprise.identreprise= @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }
            else if(motif == "depense")
            {
                cmd = new SqlCommand("select libellecompte from Compte where numcompte not like '1%' or numcompte not like '7%' ", con);
            }
            else if(motif == "typejournal")
            {
                cmd = new SqlCommand("select typejournal from TypeJournal where compte is NULL", con);
            }
            else if (motif == "payeurdifféré")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte = '411100'", con);
            }
            else if (motif == "stock")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte like '33%' and numcompte <> '33' and numcompte <> '33000'", con);
            }
            else if (motif == "cibledepense")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where categorie = 'P'", con);
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
        public void ChargerExamenLabo(FormConsulter c, FormExamenPhysique e)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select nomservice from Service where numcompte like '70611%'", con);
                dr = cmd.ExecuteReader();
                e.dgv.Rows.Clear();
                while (dr.Read())
                {
                    e.dgv.Rows.Add();
                    e.dgv.Rows[e.dgv.RowCount - 1].Cells[0].Value = e.dgv.RowCount;
                    e.dgv.Rows[e.dgv.RowCount - 1].Cells[1].Value = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            e.Text = "SSM - Examens de labo";
            e.ShowDialog();
            if (e.fermeture_succes)
            {
                for (int i = 0; i < e.dgv.RowCount; i++)
                {
                    if (e.dgv.Rows[i].Selected)
                    {
                        c.dgvLabo.Rows.Add();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = c.dgvLabo.RowCount;
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[1].Value = e.dgv.Rows[i].Cells[1].Value.ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = "RAS";
                    }

                }
            }
            e.Close();
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
        public void ValiderLigne(FormFactureProduit2 f)
        {
            if(f.dgvStock.RowCount != 0)
            {
                if (int.Parse(f.txtQte.Text) >= 1)
                {
                    f.ajoutvalide = true;
                    if (f.dgvFacture.RowCount > 0)
                    {
                        for (int i = 0; i < f.dgvFacture.RowCount; i++)
                        {
                            if (f.dgvFacture.Rows[i].Cells[0].Value.ToString() == f.dgvStock.CurrentRow.Cells[0].Value.ToString())
                            {
                                MessageBox.Show("Ce stock est déjà affecté à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                i += f.dgvFacture.RowCount;
                                f.ajoutvalide = false;
                            }
                        }
                        if (f.ajoutvalide)
                            AjouterLigne(f);
                    }
                    else
                        AjouterLigne(f);
                }
                else
                {
                    MessageBox.Show("La quanitié doit être supérieure ou égale à 1", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    f.txtQte.Focus();
                }
            }
            else
                MessageBox.Show("Aucune ligne de stock n'a été sélectionnée", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Facturier(FormFactureProduit f, FormFactureProduit2 f2)
        {
            f2.ShowDialog();
            f.dgvFacture.Rows.Clear();
            if(f2.fermeture_succes)
            {
                for (int i = 0; i < f2.dgvFacture.RowCount; i++)
                {
                    f.dgvFacture.Rows.Add();
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f2.dgvFacture.Rows[i].Cells[0].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f2.dgvFacture.Rows[i].Cells[1].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = f2.dgvFacture.Rows[i].Cells[2].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f2.dgvFacture.Rows[i].Cells[3].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f2.dgvFacture.Rows[i].Cells[4].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = f2.dgvFacture.Rows[i].Cells[5].Value;
                }
            }
            f2.Close();
        }
        public void AjouterLigne(FormFactureProduit2 f)
        {
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Add();
            chaine = string.Format("{0} {1} {2} {3} {4}", 
                f.txtProduit.Text, 
                f.dgvStock.CurrentRow.Cells[1].Value.ToString(), 
                f.dgvStock.CurrentRow.Cells[2].Value.ToString(), 
                f.dgvStock.CurrentRow.Cells[3].Value.ToString(), 
                f.dgvStock.CurrentRow.Cells[4].Value.ToString());

            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f.dgvStock.CurrentRow.Cells[0].Value;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f.dgvFacture.RowCount;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = chaine;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f.dgvStock.CurrentRow.Cells[6].Value;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f.txtQte.Text;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = double.Parse(f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value.ToString()) * int.Parse(f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value.ToString());
            for (int i = 0; i < f.dgvFacture.RowCount; i++)
            {
                f.txtTotal.Text = (double.Parse(f.txtTotal.Text) + double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString("0.00");
            }
        }
        public void Annuler(FormFactureService f)
        {
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDown;
            f.cboTypeFacture.SelectedText = "";
            f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDownList;
            f.cboPayeurDiffere.Items.Clear();
            f.cboPayeurDiffere.Enabled = false;
            f.txtPayeur.Text = "";
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
            f.cboPayeurDiffere.Items.Clear();
            f.cboPayeurDiffere.Enabled = false;
            f.txtPayeur.Text = "";
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Clear();
        }
        public bool EnregistrerBon(FormFactureService f)
        {
            cmdStatut = true;
            f.numbon = NouveauID("bonrecette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into BonRecette(numbon, statut, date_operation, payeur, idpatient, categorie) values (@numbon, @statut, @date, @payeur, @idpatient, @categorie)", con);
                cmd.Parameters.AddWithValue("@numbon", f.numbon);
                cmd.Parameters.AddWithValue("@date", f.lblDateOperation.Text);
                cmd.Parameters.AddWithValue("@statut", f.cboTypeFacture.Text);
                cmd.Parameters.AddWithValue("@payeur", f.txtPayeur.Text);
                cmd.Parameters.AddWithValue("@idpatient", f.idpatient);
                cmd.Parameters.AddWithValue("@categorie", "service");
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
        public bool EnregistrerBon(FormFactureProduit f)
        {
            cmdStatut = true;
            f.numbon = NouveauID("bonrecette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into BonRecette(numbon, statut, date_operation, payeur, idpatient, categorie) values (@numbon, @statut, @date, @payeur, @idpatient, @categorie)", con);
                cmd.Parameters.AddWithValue("@numbon", f.numbon);
                cmd.Parameters.AddWithValue("@date", f.lblDateOperation.Text);
                cmd.Parameters.AddWithValue("@statut", f.cboTypeFacture.Text);
                cmd.Parameters.AddWithValue("@payeur", f.txtPayeur.Text);
                cmd.Parameters.AddWithValue("@idpatient", f.idpatient);
                cmd.Parameters.AddWithValue("@categorie", "produit");
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
        public void Enregistrer(FormFactureProduit f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (EnregistrerBon(f))
                {
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        f.numbonP = NouveauID("bonrecetteproduit");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into BonRecetteProduit (numbonP, numbon, idstock, qtevendue, statut) values (@numbonP, @numbon, @idstock, @qte, @statut)", con);
                            cmd.Parameters.AddWithValue("@numbonP", f.numbonP);
                            cmd.Parameters.AddWithValue("@numbon", f.numbon);
                            cmd.Parameters.AddWithValue("@idstock", f.dgvFacture.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@qte", f.dgvFacture.Rows[i].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@statut", "valide");
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
                    if (f.cboTypeFacture.Text == "différé")
                    {
                        //Enregistrer la dette dans AgendaCaisse
                        Enregistrer(f.numbon, double.Parse(f.txtTotal.Text), 0, f.lblDateOperation.Text);
                        
                        f.idoperation = NouveauID("operation");
                        if (EnregistrerOperation(f.idoperation, f.lblDateOperation.Text, "Vente de produits à crédit - " + f.cboPayeurDiffere.Text, string.Format("BR_{0}", f.numbon), TrouverId("typejournal", "ventes")))
                        {
                            EnregistrerEcriture(f.id, f.idoperation, f.numcompteDiffere, double.Parse(f.txtTotal.Text), 0);
                            EnregistrerEcriture(f.id, f.idoperation, f.numcompte, 0, double.Parse(f.txtTotal.Text));
                        }
                    }
                    MessageBox.Show("Facture enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(f);
                    ArchiverBon("recette", f.numbon);
                }
            }
            else
            { 
                MessageBox.Show("Aucune ligne de facture n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Enregistrer(FormFactureService f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (EnregistrerBon(f))
                {
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        f.numbonS = NouveauID("bonrecetteservice");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into BonRecetteService (numbonS, numbon, idservice, qtevendue, statut) values (@numbonS, @numbon, @idservice, @qte, @statut)", con);
                            cmd.Parameters.AddWithValue("@numbonS", f.numbonS);
                            cmd.Parameters.AddWithValue("@numbon", f.numbon);
                            cmd.Parameters.AddWithValue("@idservice", f.dgvFacture.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@qte", f.dgvFacture.Rows[i].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@statut", "valide");
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
                    if(f.cboTypeFacture.Text=="différé")
                    {
                        //Enregistrer la dette dans AgendaCaisse
                        Enregistrer(f.numbon, double.Parse(f.txtTotal.Text), 0, f.lblDateOperation.Text);
                        
                        f.idoperation = NouveauID("operation");
                        if (EnregistrerOperation(f.idoperation, f.lblDateOperation.Text, "Vente de services à crédit - "+f.cboPayeurDiffere.Text, string.Format("BR_{0}", f.numbon), TrouverId("typejournal", "ventes")))
                        {
                            EnregistrerEcriture(f.id, f.idoperation, f.numcompteDiffere, double.Parse(f.txtTotal.Text), 0);
                            EnregistrerEcriture(f.id, f.idoperation, f.numcompte, 0, double.Parse(f.txtTotal.Text));
                        }
                    }
                    MessageBox.Show("Facture enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(f);
                    ArchiverBon("recette", f.numbon);
                    if (f.nouveau_patient) f.Close();
                }
            }
            else
            { MessageBox.Show("Aucune ligne de facture n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        public bool EnregistrerBon(FormPrescription f)
        {
            cmdStatut = true;
            f.numbon = NouveauID("bonrecette");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into BonRecette(numbon, statut, date_operation, payeur, idpatient, categorie) values (@numbon, @statut, @date, @payeur, @idpatient, @categorie)", con);
                cmd.Parameters.AddWithValue("@numbon", f.numbon);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToShortDateString());
                cmd.Parameters.AddWithValue("@statut", "immédiat");
                cmd.Parameters.AddWithValue("@payeur", f.txtPatient.Text);
                cmd.Parameters.AddWithValue("@idpatient", f.idpatient);
                cmd.Parameters.AddWithValue("@categorie", "produit");
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
        public void Enregistrer(FormPrescription f)
        {
            if (f.dgvFacture.RowCount > 0)
            {
                if (EnregistrerBon(f))
                {
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        f.numbonP = NouveauID("bonrecetteproduit");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into BonRecetteProduit (numbonP, numbon, idstock, qtevendue, statut) values (@numbonP, @numbon, @idstock, @qte, @statut)", con);
                            cmd.Parameters.AddWithValue("@numbonP", f.numbonP);
                            cmd.Parameters.AddWithValue("@numbon", f.numbon);
                            cmd.Parameters.AddWithValue("@idstock", f.dgvFacture.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@qte", f.dgvFacture.Rows[i].Cells[4].Value.ToString());
                            cmd.Parameters.AddWithValue("@statut", "valide");
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
                    MessageBox.Show("Enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ArchiverBon("recette", f.numbon);
                }
            }
            else
            {
                MessageBox.Show("Aucune ligne de facture n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region BONRECETTE
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
        public void RecetteService(FormBonRecette b)
        {
            if (CompterRecetteBon("service", b.numbon) == 0)
            {
                int i = 0;
                for (i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.idrecette = NouveauID("recetteservice");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into RecetteService values(@idrecette, @date_operation, @idservice, @qte, @numbon)", con);
                        cmd.Parameters.AddWithValue("@idrecette", b.idrecette);
                        cmd.Parameters.AddWithValue("@date_operation", b.lblDateOperation.Text);
                        cmd.Parameters.AddWithValue("@idservice", b.dgvFacture.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", b.dgvFacture.Rows[i].Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@numbon", b.numbon);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        i += b.dgvFacture.RowCount;
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                if (i == b.dgvFacture.RowCount)
                {
                    for (i = 0; i < b.dgvFacture.RowCount; i++)
                    {
                        b.idoperation = NouveauID("operation");
                        if (EnregistrerOperation(b.idoperation, b.lblDateOperation.Text, "Vente des services au payant cash", string.Format("BR_{0}", b.numbon), TrouverId("typejournal", b.caisse)))
                        {
                            if (b.caisse == "Caisse en CDF Recettes")
                                valeur= double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString());
                            else
                                valeur = double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString())/b.taux;

                            EnregistrerEcriture(b.id, b.idoperation, b.numcompte, valeur, 0);
                            EnregistrerEcriture(b.id, b.idoperation, CompteService(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString())), 0, valeur);
                            MiseAjourMontant(b.numcompte, valeur, "debit");
                            MiseAjourMontant(CompteService(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString())), valeur, "credit");
                        }
                    }
                    MessageBox.Show("Enregisté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if(b.dgvFacture.RowCount == 1)
                    {
                        if (b.dgvFacture.Rows[0].Cells[2].Value.ToString() == "consultation urgence" ||
                        b.dgvFacture.Rows[0].Cells[2].Value.ToString() == "consultation nouveau cas" ||
                        b.dgvFacture.Rows[0].Cells[2].Value.ToString() == "consultation ancien cas")
                            Agenda(new FormAgenda(), b);
                    }
                }
            }
            else
                MessageBox.Show("Le bon sélectionné est déjà enregistré dans les recettes", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void RecetteProduit(FormBonRecette b)
        {
            if (CompterRecetteBon("produit", b.numbon) == 0)
            {
                int i = 0;
                for (i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.idrecette = NouveauID("recetteproduit");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into RecetteProduit values(@idrecette, @date_operation, @idstock, @qte, @numbon)", con);
                        cmd.Parameters.AddWithValue("@idrecette", b.idrecette);
                        cmd.Parameters.AddWithValue("@date_operation", b.lblDateOperation.Text);
                        cmd.Parameters.AddWithValue("@idstock", b.dgvFacture.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", b.dgvFacture.Rows[i].Cells[4].Value.ToString());
                        cmd.Parameters.AddWithValue("@numbon", b.numbon);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        i += b.dgvFacture.RowCount;
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                if (i == b.dgvFacture.RowCount)
                {
                    for (i = 0; i < b.dgvFacture.RowCount; i++)
                    {
                        b.idoperation = NouveauID("operation");
                        if (EnregistrerOperation(b.idoperation, b.lblDateOperation.Text, "Vente des médicaments au payant cash", string.Format("BR_{0}", b.numbon), TrouverId("typejournal", b.caisse)))
                        {
                            if (b.caisse == "Caisse en CDF Recettes")
                                valeur = double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString());
                            else
                                valeur = double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString()) / b.taux;

                            EnregistrerEcriture(b.id, b.idoperation, b.numcompte, valeur, 0);
                            EnregistrerEcriture(b.id, b.idoperation, "701100", 0, valeur);
                            MiseAjourMontant(b.numcompte, valeur, "debit");
                            MiseAjourMontant("701100", valeur, "credit");
                            //Achats, variations de stock
                            MiseAjourMontant("603101", valeur, "debit");
                            MiseAjourMontant("311100", valeur, "credit");
                        }
                    }
                    MessageBox.Show("Enregisté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Le bon sélectionné est déjà enregistré dans les recettes", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Enregistrer(FormBonRecette b)
        {
            if (b.dgvBon.CurrentRow.Cells[5].Value.ToString() == "service")
                RecetteService(b);
            else
                RecetteProduit(b);
            ImprimerBon(b, new FormImpression());
        }
        public void ModifierStatutBon(int numbon)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update BonRecette set statut = 'immédiat' where numbon= @numbon", con);
                cmd.Parameters.AddWithValue("@numbon", numbon);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show(""+ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ActualiserBon(FormBonRecette b, string motif)
        {
            if(b.poste=="pharmacie")
            {
                if (motif == "recherche")
                {
                    cmd = new SqlCommand("select distinct BonRecette.numbon, statut, BonRecette.date_operation, payeur, idpatient, categorie from BonRecette, RecetteProduit  where BonRecette.numbon = RecetteProduit.numbon and categorie= @categ and BonRecette.date_operation between @date_op1 and @date_op2 and raisonretrait is NULL", con);
                    cmd.Parameters.AddWithValue("@categ", "produit");
                    cmd.Parameters.AddWithValue("@date_op1", b.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@date_op2", b.dtpDateA.Text);
                }
                else
                {
                    cmd = new SqlCommand("select distinct BonRecette.numbon, statut, BonRecette.date_operation, payeur, idpatient, categorie from BonRecette, RecetteProduit  where BonRecette.numbon = RecetteProduit.numbon and categorie= @categ and BonRecette.date_operation= @date_operation and raisonretrait is NULL", con);
                    cmd.Parameters.AddWithValue("@categ", "produit");
                    cmd.Parameters.AddWithValue("@date_operation", b.lblDateOperation.Text);
                }
            }
            else
            {
                if (motif == "recherche")
                {
                    cmd = new SqlCommand("select * from BonRecette where date_operation between @date_op1 and @date_op2 and raisonretrait is NULL", con);
                    cmd.Parameters.AddWithValue("@date_op1", b.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@date_op2", b.dtpDateA.Text);
                }
                else
                {
                    cmd = new SqlCommand("select * from BonRecette where date_operation= @date_operation and raisonretrait is NULL", con);
                    cmd.Parameters.AddWithValue("@date_operation", b.lblDateOperation.Text);
                }
            }
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvBon.Rows.Clear();
                while(dr.Read())
                {
                    b.dgvBon.Rows.Add();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    b.dgvBon.Rows[b.dgvBon.RowCount - 1].Cells[5].Value = dr[5].ToString();
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }           
        }
        public void DetailsService(FormBonRecette b)
        {
            cmd = new SqlCommand("select numbonS, idservice, qtevendue from BonRecetteService where numbon = @numbon", con);
            cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvFacture.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvFacture.Rows.Add();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[4].Value = dr[2].ToString();
                }
                con.Close();
                b.txtTotal.Text = 0.ToString();
                for (int i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.dgvFacture.Rows[i].Cells[2].Value = TrouverNom("service", int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[3].Value = PrixService(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[5].Value = double.Parse(b.dgvFacture.Rows[i].Cells[3].Value.ToString()) * int.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString());
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DetailsProduit(FormBonRecette b)
        {
            cmd = new SqlCommand("select idstock, qtevendue from BonRecetteProduit where numbon = @numbon", con);
            cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvFacture.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvFacture.Rows.Add();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[3].Value = dr[1].ToString();
                }
                con.Close();
                b.txtTotal.Text = 0.ToString();
                for (int i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.dgvFacture.Rows[i].Cells[1].Value = cs.TrouverLibelleStock(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[2].Value = cs.PrixStock(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[4].Value = double.Parse(b.dgvFacture.Rows[i].Cells[2].Value.ToString()) * int.Parse(b.dgvFacture.Rows[i].Cells[3].Value.ToString());
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString())).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AfficherDetailsBon(FormBonRecette b)
        {
            if(b.dgvBon.CurrentRow.Cells[5].Value.ToString()=="service")
            {
                DetailsService(b);
            }
            else
            {
                DetailsProduit(b);
            }
        }
        public void DetailsService2(FormBonRecette b)
        {
            cmd = new SqlCommand("select numbonS, idservice, qtevendue from BonRecetteService where statut= 'valide' and numbon = @numbon", con);
            cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvFacture.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvFacture.Rows.Add();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[4].Value = dr[2].ToString();
                }
                con.Close();
                b.txtTotal.Text = 0.ToString();
                for (int i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.dgvFacture.Rows[i].Cells[2].Value = TrouverNom("service", int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[3].Value = PrixService(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[5].Value = double.Parse(b.dgvFacture.Rows[i].Cells[3].Value.ToString()) * int.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString());
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DetailsProduit2(FormBonRecette b)
        {
            cmd = new SqlCommand("select numbonP, idstock, qtevendue from BonRecetteProduit where statut= 'valide' and numbon = @numbon", con);
            cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvFacture.Rows.Clear();
                while (dr.Read())
                {
                    b.dgvFacture.Rows.Add();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    b.dgvFacture.Rows[b.dgvFacture.RowCount - 1].Cells[4].Value = dr[2].ToString();
                }
                con.Close();
                b.txtTotal.Text = 0.ToString();
                for (int i = 0; i < b.dgvFacture.RowCount; i++)
                {
                    b.dgvFacture.Rows[i].Cells[2].Value = cs.TrouverLibelleStock(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[3].Value = cs.PrixStock(int.Parse(b.dgvFacture.Rows[i].Cells[1].Value.ToString()));
                    b.dgvFacture.Rows[i].Cells[5].Value = double.Parse(b.dgvFacture.Rows[i].Cells[3].Value.ToString()) * int.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString());
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AfficherDetailsBon2(FormBonRecette b)
        {
            if (b.dgvBon.CurrentRow.Cells[5].Value.ToString() == "service")
            {
                DetailsService2(b);
            }
            else
            {
                DetailsProduit2(b);
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
        public void Agenda(FormAgenda a, FormBonRecette b)
        {
            a.idpatient = b.idpatient;
            a.btnValider.Enabled = true;
            a.btnInvalider.Enabled = true;
            a.MaximumSize = a.Size;
            a.MaximizeBox = false;
            a.MinimizeBox = false;
            a.btnQuitter.Visible = false;
            a.Text = "SSM - Agenda des consultations";
            a.ShowDialog();
        }
        public void RetirerLigne(FormBonRecette b)
        {
            if (b.dgvBon.CurrentRow.Cells[5].Value.ToString() == "produit")
            {
                if (CompterRecetteBon("produit", b.numbon) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update BonRecetteProduit set statut = 'invalide', raisonretrait = @raison where numbon = @numbon and numbonP = @numbonP", con);
                        cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@numbonP", b.dgvFacture.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@raison", b.txtMotif.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        b.dgvFacture.Rows.RemoveAt(b.dgvFacture.CurrentRow.Index);
                        b.txtMotif.Text = "";
                        b.txtMotif.Enabled = false;
                        b.btnValider.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    b.txtTotal.Text = 0.ToString();
                    for (int i = 0; i < b.dgvFacture.RowCount; i++)
                    {
                        b.txtTotal.Text = (long.Parse(b.txtTotal.Text) + int.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString())).ToString();
                    }
                }
                else
                    MessageBox.Show("Le bon sélectionné est déjà impliqué dans les recettes,\npour raison de cohérence, cet élément de facture ne peut être retiré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CompterRecetteBon("service", b.numbon) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update BonRecetteService set statut = 'invalide', raisonretrait = @raison where numbon = @numbon and numbonS = @numbonS", con);
                        cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@numbonS", b.dgvFacture.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@raison", b.txtMotif.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        b.dgvFacture.Rows.RemoveAt(b.dgvFacture.CurrentRow.Index);
                        b.txtMotif.Text = "";
                        b.txtMotif.Enabled = false;
                        b.btnValider.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    b.txtTotal.Text = 0.ToString();
                    for (int i = 0; i < b.dgvFacture.RowCount; i++)
                    {
                        b.txtTotal.Text = (long.Parse(b.txtTotal.Text) + int.Parse(b.dgvFacture.Rows[i].Cells[4].Value.ToString())).ToString();
                    }
                }
                else
                    MessageBox.Show("Le bon sélectionné est déjà impliqué dans les recettes,\npour raison de cohérence, cet élément de facture ne peut être retiré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void RetirerBon(FormBonRecette b)
        {
            if (b.dgvBon.CurrentRow.Cells[5].Value.ToString() == "produit")
            {
                if (CompterRecetteBon("produit", b.numbon) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update BonRecette set raisonretrait = @raison where numbon = @numbon", con);
                        cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@raison", b.txtMotif.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        b.dgvBon.Rows.RemoveAt(b.dgvBon.CurrentRow.Index);
                        b.dgvFacture.Rows.Clear();
                        b.txtTotal.Text = 0.ToString();
                        b.txtMotif.Text = "";
                        b.txtMotif.Enabled = false;
                        b.btnValider.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                    MessageBox.Show("Le bon sélectionné est déjà impliqué dans les recettes,\npour raison de cohérence, il ne peut être retiré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (CompterRecetteBon("service", b.numbon) == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update BonRecette set raisonretrait = @raison where numbon = @numbon", con);
                        cmd.Parameters.AddWithValue("@numbon", b.dgvBon.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@raison", b.txtMotif.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        b.dgvBon.Rows.RemoveAt(b.dgvBon.CurrentRow.Index);
                        b.dgvFacture.Rows.Clear();
                        b.txtTotal.Text = 0.ToString();
                        b.txtMotif.Text = "";
                        b.txtMotif.Enabled = false;
                        b.btnValider.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else
                    MessageBox.Show("Le bon sélectionné est déjà impliqué dans les recettes,\npour raison de cohérence, il ne peut être retiré", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ImprimerBon(FormBonRecette b, FormImpression imp)
        {
            imp.numbon = b.numbon;
            imp.payeur = b.payeur;
            imp.montantlettre = TestMontant(b.txtTotal);
            imp.montantlettre = imp.montantlettre.Substring(0, 1).ToUpper() + imp.montantlettre.Substring(1);
            imp.montantchiffre = b.txtTotal.Text;
            imp.monnaie = b.cboCaisseRecette.Text;
            if(b.dgvBon.CurrentRow.Cells[5].Value.ToString() == "service")
                imp.motif = "Ventes de services";
            else
                imp.motif = "Ventes de produits";
            imp.date_jour = b.lblDateOperation.Text;
            imp.Text = "SSM - Bon de recette";
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
            imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonRecette.rdlc";
            imp.reportViewer1.LocalReport.SetParameters(rparams);
            imp.MaximumSize = imp.Size;
            imp.MaximizeBox = false;
            imp.MinimizeBox = false;
            imp.ShowDialog();
        }
        public void JournalCaisseService(FormBonRecetteJournal b)
        {
            if (b.cboMotif.Text == "Services et catégories")
            {
                cmd = new SqlCommand("select nomservice, libellecompte, prixservice * qtevendue as montant from RecetteService, Service, Compte where date_operation between @dateDe and @dateA and RecetteService.idservice= Service.idservice and Service.numcompte = Compte.numcompte", con);
                b.dgvRecette.Columns[2].Visible = true;
            }
            else
            {
                cmd = new SqlCommand("select nomservice, libellecompte, prixservice * qtevendue as montant from RecetteService, Service, Compte where date_operation between @dateDe and @dateA and RecetteService.idservice= Service.idservice and Service.numcompte = Compte.numcompte", con);
                b.dgvRecette.Columns[2].Visible = false;
            }
            cmd.Parameters.AddWithValue("@dateDe", b.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", b.dtpDateA.Text);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvRecette.Rows.Clear();
                b.txtTotal.Text = 0.ToString();
                while (dr.Read())
                {
                    b.dgvRecette.Rows.Add();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[0].Value = b.dgvRecette.RowCount;
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[3].Value.ToString())).ToString();
                }
                con.Close();
                
                //for (int i = 0; i < b.dgvRecette.RowCount; i++)
                //{
                //    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvRecette.Rows[i].Cells[3].Value.ToString())).ToString();
                //}
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void JournalCaisseProduit(FormBonRecetteJournal b)
        {
            cmd = new SqlCommand("select RecetteProduit.idstock, qtevendue from RecetteProduit where date_operation between @dateDe and @dateA", con);
            b.dgvRecette.Columns[2].Visible = false;
            cmd.Parameters.AddWithValue("@dateDe", b.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", b.dtpDateA.Text);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                b.dgvRecette.Rows.Clear();
                b.txtTotal.Text = 0.ToString();
                while (dr.Read())
                {
                    b.dgvRecette.Rows.Add();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[0].Value = b.dgvRecette.RowCount;
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    b.dgvRecette.Rows[b.dgvRecette.RowCount - 1].Cells[4].Value = dr[1].ToString();
                }
                con.Close();
                for (int i = 0; i < b.dgvRecette.RowCount; i++)
                {
                    b.dgvRecette.Rows[i].Cells[2].Value = cs.PrixStock(int.Parse(b.dgvRecette.Rows[i].Cells[1].Value.ToString()));
                    b.dgvRecette.Rows[i].Cells[3].Value = double.Parse(b.dgvRecette.Rows[i].Cells[2].Value.ToString()) * int.Parse(b.dgvRecette.Rows[i].Cells[4].Value.ToString());
                    b.txtTotal.Text = (double.Parse(b.txtTotal.Text) + double.Parse(b.dgvRecette.Rows[i].Cells[3].Value.ToString())).ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void JournalCaisseRecette(FormBonRecetteJournal b)
        {
            if (b.cboMotif.Text != "Produits")
                JournalCaisseService(b);
            else
                JournalCaisseProduit(b);
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
        public void AgendaCaisse(FormBonRecette b, FormAgendaCaisse a)
        {
            a.numcompte = TrouverId("numcompte", b.caisse).ToString();
            a.lblDateOperation.Text = b.lblDateOperation.Text;
            a.lblTaux.Text = b.lblTaux.Text;
            a.txtPayeur.Text = b.dgvBon.CurrentRow.Cells[3].Value.ToString();
            a.txtNumBon.Text = b.dgvBon.CurrentRow.Cells[0].Value.ToString();
            a.txtMontantTotal.Text = b.txtTotal.Text;
            a.txtReste.Text = (double.Parse(a.txtMontantTotal.Text) - MontantAgendaCaisse(int.Parse(a.txtNumBon.Text))).ToString();
            a.ShowDialog();
            b.txtTotal.Text = a.txtMontantPaye.Text;
            ImprimerBon(b, new FormImpression());
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
            a.idoperation = NouveauID("operation");
            Enregistrer(int.Parse(a.txtNumBon.Text), double.Parse(a.txtMontantTotal.Text), double.Parse(a.txtMontantPaye.Text), a.dtpDateJour.Value.ToString());
            MiseAjourRegulation(id, a.idoperation, "");

            if (EnregistrerOperation(a.idoperation, a.dtpDateJour.Text, "Recouvrement sur crédit", string.Format("BR_{0}", a.txtNumBon.Text), TrouverId("typejournal", "ventes")))
            {
                EnregistrerEcriture(a.id, a.idoperation, a.numcompte, double.Parse(a.txtMontantPaye.Text), 0);
                EnregistrerEcriture(a.id, a.idoperation, "411100", 0, double.Parse(a.txtMontantPaye.Text));
            }
        }
        #endregion

        ReportDataSource rs = new ReportDataSource();

        #region DEPENSE
        public void AfficherSousForm(MFormDepense d, Form childForm)
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
            childForm.Show();
        }
        public void CompteDepense(FormDepense d, FormDepenseCompte dc)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select numcompte, libellecompte from Compte where numcompte like '"+d.numcompteCategorie+"%' and categorie= 'U'", con);
                dr = cmd.ExecuteReader();
                dc.dgvCompte.Rows.Clear();
                while (dr.Read())
                {
                    dc.dgvCompte.Rows.Add();
                    dc.dgvCompte.Rows[dc.dgvCompte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dc.dgvCompte.Rows[dc.dgvCompte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            dc.ShowDialog();
            if(dc.fermeture_succes)
            {
                d.numcompte = dc.dgvCompte.CurrentRow.Cells[0].Value.ToString();
                d.txtCompte.Text = dc.dgvCompte.CurrentRow.Cells[1].Value.ToString();
                if (d.numcompte.StartsWith("31"))
                {
                    //d.numcompteAchat = TrouverId("numcompteAchat", d.txtCompte.Text).ToString();
                    d.numcompteAchat = "601101";
                    //d.numcompteVariation = TrouverId("numcompteVariation", d.txtCompte.Text).ToString();
                    d.numcompteVariation = "603101";
                    d.txtBeneficiaire.Focus();
                }
            }
            dc.Close();
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
                    txt.Text = valeur.ToString();
                    if (txt.Text.Contains(","))
                    {
                        chaine = NumbersToWords(long.Parse(txt.Text.Substring(0, txt.Text.IndexOf(","))));
                        chaine = string.Format("{0} virgule {1}", chaine, NumbersToWords(long.Parse(txt.Text.Substring(txt.Text.IndexOf(",") + 1))));
                    }
                    else chaine = NumbersToWords(long.Parse(txt.Text));
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void Annuler(FormDepense d)
        {
            d.cboCibleDepense.Items.Clear();
            d.txtCompte.Text = "";
            d.checkBox1.Checked = false;
            d.txtBeneficiaire.Text = "";
            d.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
            d.cboMonnaie.SelectedText = "";
            d.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;
            d.cboCaisseDepense.DropDownStyle = ComboBoxStyle.DropDown;
            d.cboCaisseDepense.SelectedText = "";
            d.cboCaisseDepense.DropDownStyle = ComboBoxStyle.DropDownList;
            d.cboMonnaie.Enabled = true;
            d.txtMontant.Text = "";
            d.txtMontantLettre.Text = "";
            d.txtMotif.Text = "";
            d.txtNumRequisition.Text = "";
            d.btnEnregistrer.Enabled = true;
            d.numcompteAchat = "";
            d.numcompteVariation = "";
        }
        public bool EnregistrerBon(FormDepense d)
        {
            cmdStatut = true;
            d.numbon = NouveauID("bondepense");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(d.idabonne !=0)
                {
                    cmd = new SqlCommand("insert into BonDepense(numbon, date_operation, beneficiaire, idabonne) values (@numbon, @date, @beneficiaire, @idabonne)", con);
                    cmd.Parameters.AddWithValue("@idabonne", d.idabonne);
                }
                else cmd = new SqlCommand("insert into BonDepense(numbon, date_operation, beneficiaire) values (@numbon, @date, @beneficiaire)", con);

                cmd.Parameters.AddWithValue("@numbon", d.numbon);
                cmd.Parameters.AddWithValue("@date", d.lblDateOperation.Text);
                cmd.Parameters.AddWithValue("@beneficiaire", d.txtBeneficiaire.Text);
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
        public void Enregistrer(FormDepense d)
        {
            if (d.cboCibleDepense.Text != "" && d.txtBeneficiaire.Text != "" && d.cboMonnaie.Text != "" && d.txtMontant.Text != "" && d.cboCaisseDepense.Text != "" && d.txtMotif.Text != "" && d.txtNumRequisition.Text != "")
            {
                if (d.soldeCaisse >= d.montantdecaisse)
                {
                    if (EnregistrerBon(d))
                    {
                        d.iddepense = NouveauID("depense");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into Depense values (@iddepense, @numbon, @numcompte, @motifdepense, @montant, @monnaie, @refrequisition)", con);
                            cmd.Parameters.AddWithValue("@iddepense", d.iddepense);
                            cmd.Parameters.AddWithValue("@numbon", d.numbon);
                            cmd.Parameters.AddWithValue("@numcompte", d.numcompte);
                            cmd.Parameters.AddWithValue("@motifdepense", d.txtMotif.Text);
                            cmd.Parameters.AddWithValue("@montant", d.txtMontant.Text);
                            cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);
                            cmd.Parameters.AddWithValue("@refrequisition", d.txtNumRequisition.Text);
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
                        d.idoperation = NouveauID("operation");
                        if (EnregistrerOperation(d.idoperation, d.lblDateOperation.Text, d.txtMotif.Text, string.Format("BD_{0}", d.numbon), TrouverId("typejournal", d.caisse)))
                        {
                            EnregistrerEcriture(d.id, d.idoperation, d.numcompte, d.montantdecaisse, 0);
                            EnregistrerEcriture(d.id, d.idoperation, TrouverId("numcompte", d.caisse).ToString(), 0, d.montantdecaisse);

                            if (d.numcompte.StartsWith("31") && d.numcompteAchat != "" && d.numcompteVariation != "")
                            {
                                EnregistrerEcriture(d.id, d.idoperation, d.numcompteAchat, d.montantdecaisse, 0);
                                EnregistrerEcriture(d.id, d.idoperation, d.numcompteVariation, 0, d.montantdecaisse);
                            }
                        }
                        MiseAjourMontant(TrouverId("numcompte", d.caisse).ToString(), d.montantdecaisse, "credit");

                        MessageBox.Show("Depense enregistrée avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ArchiverBon("dépense", d.numbon);
                        ImprimerBon(d, new FormImpression());
                        Annuler(d);
                    }
                }
                else
                    MessageBox.Show("Solde caisse insuffisant", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ChargerCompte(TextBox txt, ListBox list)
        {
            if(txt.Text !="")
            {
                con.Open();
                cmd = new SqlCommand("select libellecompte from Compte where libellecompte like '" + txt.Text + "%'", con);
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
        
        public void ImprimerBon(FormDepense d, FormImpression imp)
        {
            imp.numbon = d.numbon;
            imp.beneficiaire = d.txtBeneficiaire.Text;
            imp.montantlettre = d.txtMontantLettre.Text;
            imp.montantchiffre = d.txtMontant.Text;
            imp.monnaie = d.cboMonnaie.Text;
            imp.motif = d.txtMotif.Text;
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

        public void Afficher(FormDepenseRapport d)
        {
            if (d.cboChoixBon.Text != "" && d.cboMonnaie.Text !="")
            {
                if (d.cboChoixBon.Text == "bons valides")
                    cmd = new SqlCommand("select BonDepense.numbon, date_operation, beneficiaire, motifdepense, montant, monnaie, refrequisition from BonDepense, Depense where BonDepense.numbon= Depense.numbon and monnaie = @monnaie and raisonretrait is NULL and date_operation between @dateDe and @dateA", con);
                else
                    cmd = new SqlCommand("select BonDepense.numbon, date_operation, beneficiaire, motifdepense, montant, monnaie, refrequisition from BonDepense, Depense where BonDepense.numbon= Depense.numbon and monnaie = @monnaie and date_operation between @dateDe and @dateA", con);
                cmd.Parameters.AddWithValue("@monnaie", d.cboMonnaie.Text);
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

            }
            else
            {
                MessageBox.Show("Veuillez faire le choix de bons à afficher et sélectionner une monnaie unique", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                d.cboChoixBon.Select();
            }
        }
        public void SommeDepense(FormDepenseRapport r)
        {
            r.sommeDepense = 0;
            for (int i = 0; i < r.dgvBon.RowCount; i++)
			{
                con.Open();
                try
                {
                    cmd = new SqlCommand("select montant from Depense, BonDepense where Depense.numbon = BonDepense.numbon and BonDepense.numbon = @numbon", con);
                    cmd.Parameters.AddWithValue("@numbon", r.dgvBon.Rows[i].Cells[0].Value.ToString());
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    r.sommeDepense += double.Parse(dr[0].ToString());
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
			}
            MessageBox.Show(string.Format("Somme de dépenses en {0}: {1}", r.cboMonnaie.Text, r.sommeDepense.ToString("0.00")), "Calcul somme dépenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void RetirerBon(FormDepenseRapport r)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update BonDepense set raisonretrait = @raison where numbon = @numbon", con);
                cmd.Parameters.AddWithValue("@numbon", r.numbon);
                cmd.Parameters.AddWithValue("@raison", r.txtMotif.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                r.dgvBon.Rows.RemoveAt(r.dgvBon.CurrentRow.Index);
                r.txtMotif.Text = "";
                r.txtMotif.Enabled = false;
				r.btnValider.Enabled = false;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
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
        public int CompterLigneService(int idservice)
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
            if (a.activeForm != null)
                a.activeForm.Close();
            a.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            a.pnlChildForm.Controls.Add(childForm);
            a.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "abonne";
            if (a.statut == "nouveau")
            {
                childForm.txtRecherche.Enabled = false;
                childForm.btnRecherche.Enabled = false;
            }
            else
                childForm.btnEnregistrer.Enabled = false;
            childForm.statut = a.statut;
            childForm.Show();
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
            s.idabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
            s.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[6].Value.ToString();
            s.typepatient = a.cboTypePatient.Text;
            if(s.typepatient=="abonné")
                s.Text = "SSM - Services aux abonnés";
            else
                s.Text = "SSM - Services aux employés";
            s.ShowDialog();
        }
        public void Produits(FormAbonne a, FormAbonneProduit p)
        {
            p.idabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
            p.txtAbonne.Text = a.dgvAbonne.CurrentRow.Cells[6].Value.ToString();
            p.typepatient = a.cboTypePatient.Text;
            if (p.typepatient == "abonné")
                p.Text = "SSM - Produits aux abonnés";
            else
                p.Text = "SSM - Produits aux employés";
            p.ShowDialog();
        }
        public void Annuler(FormAbonne a)
        {
            a.dgvAbonne.Rows.Clear();
            a.cboEntreprise.Items.Clear();
            a.cboTypeAbonne.Items.Clear();
            a.txtReference.Text = "";
        }
        public void Afficher2(FormAbon a)
        {
            if (a.cboEntreprise.Text != "" && a.txtReference.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("select idabonne, idpatient from Abonne where identreprise= @identreprise and refabonne= @reference", con);
                cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
                cmd.Parameters.AddWithValue("@reference", a.txtReference.Text);
                try
                {
                    dr = cmd.ExecuteReader();
                    a.dgvAbonne.Rows.Clear();
                    while (dr.Read())
                    {
                        a.dgvAbonne.Rows.Add();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Désolé! Vous devez fournir l'entreprise et le numéro de référence pour cette recherche", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Afficher(FormAbonne a)
        {
            if (a.cboEntreprise.Text != "" && a.txtReference.Text == "")
            {
                cmd = new SqlCommand("select * from Abonne where identreprise= @identreprise", con);
                a.recherche_valide = true;
            }
            else if (a.cboEntreprise.Text != "" && a.txtReference.Text != "")
            {
                cmd = new SqlCommand("select * from Abonne where identreprise= @identreprise and refabonne= @reference", con);
                cmd.Parameters.AddWithValue("@reference", a.txtReference.Text);
                a.recherche_valide = true;
            }
            else a.recherche_valide = false;
            
            if(a.recherche_valide)
            {
                cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
                con.Open();
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

                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[5].Value = dr[3].ToString();
                        a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[9].Value = dr[4].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                if (a.dgvAbonne.RowCount != 0)
                {
                    for (int i = 0; i < a.dgvAbonne.RowCount; i++)
                    {
                        a.dgvAbonne.Rows[i].Cells[3].Value = TrouverNom("entreprise", int.Parse(a.dgvAbonne.Rows[i].Cells[1].Value.ToString()));
                        a.dgvAbonne.Rows[i].Cells[4].Value = TrouverNom("typeabonne", int.Parse(a.dgvAbonne.Rows[i].Cells[2].Value.ToString()));
                    }
                }
            }
            else MessageBox.Show("Désolé! Vous devez fournir l'entreprise et le numéro de référence pour cette recherche", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void NouvelAbonne(FormPatient a)
        {
            a.idabonne = NouveauID("abonne");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Abonne values (@id, @identreprise, @idtypeabonne, @reference, @idpatient)", con);
                cmd.Parameters.AddWithValue("@id", a.idabonne);
                cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
                cmd.Parameters.AddWithValue("@idtypeabonne", a.idtypeabonne);
                cmd.Parameters.AddWithValue("@reference", a.refabonne);
                cmd.Parameters.AddWithValue("@idpatient", a.idpatient);

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
        public void Recuperer(FormAbonne a)
        {
            a.btnService.Enabled = true;
            a.btnProduit.Enabled = true;
            a.btnEnregistrer.Enabled = false;
            if(a.cboTypePatient.Text == "abonné")
            {
                a.btnModifier.Enabled = true;
                a.btnSupprimer.Enabled = true;

                a.idabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[0].Value.ToString());
                a.identreprise = int.Parse(a.dgvAbonne.CurrentRow.Cells[1].Value.ToString());
                a.idtypeabonne = int.Parse(a.dgvAbonne.CurrentRow.Cells[2].Value.ToString());

                a.cboEntreprise.DropDownStyle = ComboBoxStyle.DropDown;
                a.cboEntreprise.Text = a.dgvAbonne.CurrentRow.Cells[3].Value.ToString();
                a.cboEntreprise.DropDownStyle = ComboBoxStyle.DropDownList;

                a.cboTypeAbonne.DropDownStyle = ComboBoxStyle.DropDown;
                a.cboTypeAbonne.Text = a.dgvAbonne.CurrentRow.Cells[4].Value.ToString(); ;
                a.cboTypeAbonne.DropDownStyle = ComboBoxStyle.DropDownList;

                a.txtReference.Text = a.dgvAbonne.CurrentRow.Cells[5].Value.ToString();
            }
        }
        public void Modifier(FormAbonne a)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Abonne set identreprise= @identreprise, idtypeabonne= @idtypeabonne, refabonne= @reference where idabonne = @id", con);
                cmd.Parameters.AddWithValue("@id", a.idabonne);
                cmd.Parameters.AddWithValue("@identreprise", a.identreprise);
                cmd.Parameters.AddWithValue("@idtypeabonne", a.idtypeabonne);
                cmd.Parameters.AddWithValue("@reference", a.txtReference.Text);

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
            Annuler(a);
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
                a.dgvAbonneProduit.Rows[i].Cells[11].Value = cs.PrixStock(int.Parse(a.dgvAbonneProduit.Rows[i].Cells[3].Value.ToString()));
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
            p.idemploye = NouveauID("employe");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Employe values (@id, @idpatient)", con);
                cmd.Parameters.AddWithValue("@id", p.idemploye);
                cmd.Parameters.AddWithValue("@idpatient", p.idpatient);

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
        public void AfficherEmploye(FormAbonne a)
        {
            con.Open();
            cmd = new SqlCommand("select * from Employe", con);
            try
            {
                dr = cmd.ExecuteReader();
                a.dgvAbonne.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAbonne.Rows.Add();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAbonne.Rows[a.dgvAbonne.RowCount - 1].Cells[9].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        #endregion

        #region ABONNE_SERVICE
        public void SelectionService(FormAbonneService a, FormFactureService2 fs)
        {
            fs.ShowDialog();
            if (fs.selectionvalide)
            {
                a.dgvService.Rows.Clear();
                for (int i = 0; i < fs.dgv3.RowCount; i++)
                {
                    a.dgvService.Rows.Add();
                    a.dgvService.Rows[i].Cells[0].Value = fs.dgv3.Rows[i].Cells[0].Value.ToString();
                    a.dgvService.Rows[i].Cells[2].Value = fs.dgv3.Rows[i].Cells[1].Value.ToString();
                }
            }
            fs.Close();
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
        
        public void Modifier(FormAbonneService a, FormFactureService2 s)
        {
            if (a.txtAbonne.Text != "")
            {
                s.ShowDialog();
                if(s.selectionvalide)
                {
                    if(s.dgv3.RowCount == 1)
                    {
                        //a.idservice = s.dgv3.Rows[0].Cells[0].Value.ToString();
                        if (a.typepatient == "abonné")
                            cmd = new SqlCommand("update AbonneService set date_jour= @date_jour, idservice = @idservice where id = @id", con);
                        else
                            cmd = new SqlCommand("update EmployeService set date_jour= @date_jour, idservice = @idservice where id = @id", con);

                        cmd.Parameters.AddWithValue("@id", a.id);
                        cmd.Parameters.AddWithValue("@date_jour", a.dtpDateAbonne.Value.Date);
                        cmd.Parameters.AddWithValue("@idservice", s.dgv3.Rows[0].Cells[0].Value.ToString());

                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                        MessageBox.Show("Vous avez ajouté plus d'un service pour la mise à jour. Il en faut un seul", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Aucun service n'a été sélectionné pour la mise à jour", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            f2.ShowDialog();
            f.dgvFacture.Rows.Clear();
            if (f2.fermeture_succes)
            {
                for (int i = 0; i < f2.dgvFacture.RowCount; i++)
                {
                    f.dgvFacture.Rows.Add();
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f2.dgvFacture.Rows[i].Cells[0].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f2.dgvFacture.Rows[i].Cells[1].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = f2.dgvFacture.Rows[i].Cells[2].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f2.dgvFacture.Rows[i].Cells[3].Value;
                    f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f2.dgvFacture.Rows[i].Cells[4].Value;
                }
            }
            f2.Close();
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
            if (f.txtAbonne.Text != "")
            {
                f2.ShowDialog();
                if (f2.dgvFacture.RowCount == 1)
                {
                    f.dgvFacture.Rows.Clear();
                    if (f2.fermeture_succes)
                    {
                        for (int i = 0; i < f2.dgvFacture.RowCount; i++)
                        {
                            f.dgvFacture.Rows.Add();
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f2.dgvFacture.Rows[i].Cells[0].Value;
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f2.dgvFacture.Rows[i].Cells[1].Value;
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = f2.dgvFacture.Rows[i].Cells[2].Value;
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f2.dgvFacture.Rows[i].Cells[3].Value;
                            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f2.dgvFacture.Rows[i].Cells[4].Value;
                        }
                        
                        if (f.typepatient == "abonné")
                            cmd = new SqlCommand("update AbonneProduit set date_jour= @date_jour, idstock = @idstock, qteprise = @qte, prixstock= @prix where id = @id", con);
                        else
                            cmd = new SqlCommand("update EmployeProduit set date_jour= @date_jour, idstock = @idstock, qteprise = @qte, prixstock= @prix where id = @id", con);

                        cmd.Parameters.AddWithValue("@id", f.id);
                        cmd.Parameters.AddWithValue("@date_jour", f.dtpDateAbonne.Value.Date);
                        cmd.Parameters.AddWithValue("@idstock", f.dgvFacture.Rows[0].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", f.dgvFacture.Rows[0].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@prix", f.dgvFacture.Rows[0].Cells[4].Value.ToString());
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd.Transaction = tx;
                            cmd.ExecuteNonQuery();
                            tx.Commit();
                            MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Annuler(f);
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
                    MessageBox.Show("Vous devez valider une seule ligne pour la mise à jour", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        #endregion

        #region OPERATION_COMPTABLE
        public void Annuler(FormComptabilite c)
        {
            c.txtLibelle.Text = "";
            c.txtMontant.Text = "";
            c.txtDebit.Text = "";
            c.txtCredit.Text = "";
            c.listCompte.Visible = false;
            //c.listCompteExp2.Visible = false;
            c.dgvEcriture.Rows.Clear();
        }
        public void MiseAjourMontant(string numcompte, double montant, string motif)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(motif == "debit") 
                    cmd = new SqlCommand("update Compte set debit= debit + @montant where numcompte= @numcompte", con);
                else 
                    cmd = new SqlCommand("update Compte set credit= credit + @montant where numcompte= @numcompte", con);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@montant", montant);
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
        public bool EnregistrerOperation(int idoperation, string date_jour, string libelle, string numpiece, int idtypejournal)
        {
            cmdStatut = true;
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Operation values(@id, @date_jour, @libelle, @numpiece, @idtypejournal)", con);
                cmd.Parameters.AddWithValue("@id", idoperation);
                cmd.Parameters.AddWithValue("@date_jour", date_jour);
                cmd.Parameters.AddWithValue("@libelle", libelle);
                cmd.Parameters.AddWithValue("@numpiece", numpiece);
                cmd.Parameters.AddWithValue("@idtypejournal", idtypejournal);
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
        public void EnregistrerEcriture(int id, int idoperation, string numcompte, double mdebit, double mcredit)
        {
            id = NouveauID("operationcompte");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into OperationCompte values(@id, @idoperation, @numcompte, @mdebit, @mcredit)", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@idoperation", idoperation);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                cmd.Parameters.AddWithValue("@mdebit", mdebit);
                cmd.Parameters.AddWithValue("@mcredit", mcredit);
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
        public bool EnregistrerOperation(FormComptabilite c)
        {
            cmdStatut = true;
            c.idoperation = NouveauID("operation");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Operation values(@id, @date_jour, @libelle, @numpiece, @idtypejournal)", con);
                cmd.Parameters.AddWithValue("@id", c.idoperation);
                cmd.Parameters.AddWithValue("@date_jour", c.lblDateOperation.Text);
                cmd.Parameters.AddWithValue("@libelle", c.txtLibelle.Text);
                cmd.Parameters.AddWithValue("@numpiece", c.txtNumPiece.Text);
                cmd.Parameters.AddWithValue("@idtypejournal", c.idtypejournal);
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
        public void Enregistrer(FormComptabilite c)
        {
            if (c.dgvEcriture.RowCount > 0)
            {
                c.idoperation = NouveauID("operation");
                if (EnregistrerOperation(c.idoperation, c.lblDateOperation.Text, c.txtLibelle.Text, c.txtNumPiece.Text, c.idtypejournal))
                {
                    for (int i = 0; i < c.dgvEcriture.RowCount; i++)
                    {
                        EnregistrerEcriture(
                            c.id, c.idoperation, 
                            c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), 
                            double.Parse(c.dgvEcriture.Rows[i].Cells[1].Value.ToString()), 
                            double.Parse(c.dgvEcriture.Rows[i].Cells[2].Value.ToString()));
                        
                        if (double.Parse(c.dgvEcriture.Rows[i].Cells[1].Value.ToString()) != 0)
                            MiseAjourMontant(c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), double.Parse(c.dgvEcriture.Rows[i].Cells[1].Value.ToString()), "debit");
                        else
                            MiseAjourMontant(c.dgvEcriture.Rows[i].Cells[0].Value.ToString(), double.Parse(c.dgvEcriture.Rows[i].Cells[2].Value.ToString()), "credit");
                    }
                    MessageBox.Show("Ecritures enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(c);
                }
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public double MontantCompte(string numcompte)
        {
            valeur = 0;
            con.Open();
            try
            {
                //retourner le solde actuel du compte
                cmd = new SqlCommand("select debit-credit from Compte where numcompte= @numcompte", con);
                cmd.Parameters.AddWithValue("@numcompte", numcompte);
                dr = cmd.ExecuteReader();
                dr.Read();
                valeur = double.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return valeur;
        }
        //public void ChargerCompteExp(FormComptabilite c, TextBox txt)
        //{
        //   if(txt.Text !="")
        //   {
        //       con.Open();
        //       cmd = new SqlCommand("select libellecompte from Compte where libellecompte like '" + txt.Text + "%' and numcompte like '" + c.classe + "%'", con);
        //       dr = cmd.ExecuteReader();
        //       if (txt.Name == "txtCompteExp1")
        //       {
        //           c.listCompte.Items.Clear();
        //           while (dr.Read())
        //           {
        //               c.listCompte.Items.Add(dr[0].ToString());
        //           }
        //           con.Close();
        //           if (c.listCompte.Items.Count > 0)
        //           {
        //               c.listCompte.BringToFront();
        //               c.listCompte.Visible = true;
        //           }
        //           else c.listCompte.Visible = false;
        //       }
        //       else
        //       {
        //           c.listCompteExp2.Items.Clear();
        //           while (dr.Read())
        //           {
        //               c.listCompteExp2.Items.Add(dr[0].ToString());
        //           }
        //           con.Close();
        //           if (c.listCompteExp2.Items.Count > 0)
        //           {
        //               c.listCompteExp2.BringToFront();
        //               c.listCompteExp2.Visible = true;
        //           }
        //           else c.listCompteExp2.Visible = false;
        //       }
        //   }
        //}
        //public void ChargerCompte(FormComptabilite c, TextBox txt)
        //{
        //    if(txt.Text !="")
        //    {
        //        con.Open();
        //        cmd = new SqlCommand("select libellecompte from Compte where libellecompte like '" + txt.Text + "%'", con);
        //        dr = cmd.ExecuteReader();
        //        if (txt.Name == "txtDebit")
        //        {
        //            c.listCompte.Items.Clear();
        //            while (dr.Read())
        //            {
        //                c.listCompte.Items.Add(dr[0].ToString());
        //            }
        //            con.Close();
        //            if (c.listCompte.Items.Count > 0)
        //            {
        //                c.listCompte.BringToFront();
        //                c.listCompte.Visible = true;
        //            }
        //            else c.listCompte.Visible = false;
        //        }
        //        else
        //        {
        //            c.listCompteExp2.Items.Clear();
        //            while (dr.Read())
        //            {
        //                c.listCompteExp2.Items.Add(dr[0].ToString());
        //            }
        //            con.Close();
        //            if (c.listCompteExp2.Items.Count > 0)
        //            {
        //                c.listCompteExp2.BringToFront();
        //                c.listCompteExp2.Visible = true;
        //            }
        //            else c.listCompteExp2.Visible = false;
        //        }
        //    }
        //    else
        //    {
        //        if(c.listCompte.Visible)
        //            c.listCompte.Visible = false;
        //        else if (c.listCompteExp2.Visible)
        //            c.listCompteExp2.Visible = false;
        //    }
        //}
        //public void ActiverJournal(FormComptabilite c)
        //{
        //    c.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDown;
        //    c.cboMonnaie.Text = "CDF";
        //    if (c.cboTypeJournal.Text.Contains("USD"))
        //        c.cboMonnaie.Text = "USD";
        //    c.cboMonnaie.DropDownStyle = ComboBoxStyle.DropDownList;

        //    if (!c.cboTypeJournal.Text.Contains("USD") && !c.cboTypeJournal.Text.Contains("CDF"))
        //    {
        //        c.cboMonnaie.Enabled = true;
        //        c.txtDebit.Enabled = true;
        //        c.txtCredit.Enabled = true;
        //        c.txtDebit.Text = "";
        //        c.txtCredit.Text = "";
        //        c.cboOperation.Enabled = false;
        //    }
        //    else
        //    {
        //        c.cboMonnaie.Enabled = false;
        //        c.idtypejournal = TrouverId("typejournal", c.cboTypeJournal.Text);
        //        c.numcompteJournal = CompteTypeJournal(c.idtypejournal);
        //        c.montantdebit = MontantCompte(c.numcompteJournal);
        //        c.cboOperation.Enabled = true;
        //    }
        //}
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
        public void JournalCaisseCDF(FormComptabilite c)
        {
            if (c.txtMontant.Text != "" && c.txtDebit.Text != "" && c.txtCredit.Text != "")
            {
                if (c.montantdebit >= double.Parse(c.txtMontant.Text))
                {
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCredit.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = 0;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text);
                    c.dgvEcriture.Rows.Add();
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtDebit.Text;
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text);
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = 0;

                    if (c.numcompteAchat != "" && c.numcompteVariation != "")
                    {
                        c.dgvEcriture.Rows.Add();
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.numcompteVariation;
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = 0;
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text);
                        c.dgvEcriture.Rows.Add();
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.numcompteAchat;
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text);
                        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = 0;
                    }
                    c.montantdebit -= double.Parse(c.txtMontant.Text);
                    c.txtDebit.Text = "";
                }
                else
                {
                    MessageBox.Show("Solde insuffisant pour le compte à créditer", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    c.txtMontant.Select();
                }
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void JournalVenteAuComptant(FormComptabilite c)
        {
            //if (c.txtMontant.Text != "" && c.txtDebit.Text != "" && c.txtCredit.Text != "")
            //{
            //    c.dgvEcriture.Rows.Add();
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtDebit.Text;
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text);
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = 0;
            //    c.dgvEcriture.Rows.Add();
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCredit.Text;
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = 0;
            //    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text);
                
            //    if (c.txtCompteExp1.Text != "" && c.txtCompteExp2.Text != "")
            //    {
            //        c.dgvEcriture.Rows.Add();
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompteExp1.Text;
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text);
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = 0;
            //        c.dgvEcriture.Rows.Add();
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCompteExp2.Text;
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = 0;
            //        c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text);
            //    }
            //    c.txtCredit.Text = "";
            //    c.txtCompteExp1.Text = "";
            //    c.txtCompteExp2.Text = "";
            //}
            //else
            //{
            //    MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }
        public void Ecriture(FormComptabilite c)
        {
            if (c.txtMontant.Text != "" && c.txtDebit.Text != "" && c.txtCredit.Text != "")
            {
                c.dgvEcriture.Rows.Add();
                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtCredit.Text;
                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = 0;
                if(c.cboMonnaie.Text=="USD")
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text) * c.taux;
                else
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = double.Parse(c.txtMontant.Text);
                c.dgvEcriture.Rows.Add();
                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[0].Value = c.txtDebit.Text;
                if (c.cboMonnaie.Text == "USD")
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text) * c.taux;
                else
                    c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[1].Value = double.Parse(c.txtMontant.Text);
                c.dgvEcriture.Rows[c.dgvEcriture.RowCount - 1].Cells[2].Value = 0;
               
                //c.montantdebit -= double.Parse(c.txtMontant.Text);
                c.txtDebit.Text = "";
                c.txtCredit.Text = "";
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ValiderEcriture(FormComptabilite c)
        {
            c.txtTotalDebit.Text = "0";
            c.txtTotalCredit.Text = "0";
            Ecriture(c);
            for (int i = 0; i < c.dgvEcriture.RowCount; i++)
            {
                c.txtTotalDebit.Text = (double.Parse(c.txtTotalDebit.Text) + double.Parse(c.dgvEcriture.Rows[i].Cells[1].Value.ToString())).ToString("0.00");
                c.txtTotalCredit.Text = (double.Parse(c.txtTotalCredit.Text) + double.Parse(c.dgvEcriture.Rows[i].Cells[2].Value.ToString())).ToString("0.00");
            }
        }
        public void Afficher(FormComptaOperation c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select Operation.idoperation, date_operation, numpiece, libelle, numcompte, montantdebit, montantcredit from Operation, OperationCompte where Operation.idoperation = OperationCompte.idoperation", con);
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
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    c.dgvOperation.Rows[c.dgvOperation.RowCount - 1].Cells[6].Value = dr[6].ToString();
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        #endregion
        
        ReportDataSource rs2 = new ReportDataSource();

        #region BILAN
        public void AfficherActif(FormComptaBilan c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select ref, sum(debit - credit), sum(soldeanterieur) from Compte where categorie = 'U' and ref like 'A%' or categorie = 'U' and ref like 'B%' group by ref", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chaine = dr[0].ToString();
                    for (int i = 0; i < c.dgvActif.RowCount; i++)
                    {
                        if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == chaine)
                        {
                            c.dgvActif.Rows[i].Cells[4].Value = double.Parse(dr[1].ToString());
                            c.dgvActif.Rows[i].Cells[6].Value = double.Parse(c.dgvActif.Rows[i].Cells[4].Value.ToString()) - double.Parse(c.dgvActif.Rows[i].Cells[5].Value.ToString());
                            c.dgvActif.Rows[i].Cells[7].Value = double.Parse(dr[2].ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            ActifUSD(c);
            for (int i = 4; i < 8; i++)
            {
                c.dgvActif.Rows[c.dgvActif.RowCount - 1].Cells[i].Value = CalculerTotal(c.dgvActif, i);
            }
        }
        public void ActifUSD(FormComptaBilan c)
        {
            con.Open();
            try
            {
                //cmd = new SqlCommand("select numcompte, libellecompte, debit-credit, soldeanterieur From Compte where debit + credit <> 0 and numcompte like '2%' or debit + credit <> 0 and numcompte like '3%' or debit - credit > 0 and debit + credit <> 0 and numcompte like '4%' or debit + credit <> 0 and numcompte like '5%'", con);
                cmd = new SqlCommand("select ref, sum(debit - credit), sum(soldeanterieur) from Compte where categorie = 'UU' and ref like 'B%' group by ref", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chaine = dr[0].ToString();
                    for (int i = 0; i < c.dgvActif.RowCount; i++)
                    {
                        if (c.dgvActif.Rows[i].Cells[0].Value.ToString() == chaine)
                        {
                            c.dgvActif.Rows[i].Cells[4].Value = double.Parse(c.dgvActif.Rows[i].Cells[4].Value.ToString()) + double.Parse(dr[1].ToString()) * c.taux;
                            c.dgvActif.Rows[i].Cells[6].Value = double.Parse(c.dgvActif.Rows[i].Cells[4].Value.ToString()) - double.Parse(c.dgvActif.Rows[i].Cells[5].Value.ToString());
                            c.dgvActif.Rows[i].Cells[7].Value = double.Parse(c.dgvActif.Rows[i].Cells[7].Value.ToString()) + double.Parse(dr[2].ToString()) * c.taux;
                            break;
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
        public void AfficherPassif(FormComptaBilan c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select ref, sum(credit - debit), sum(soldeanterieur) from Compte where categorie = 'U' and ref like 'C%' or categorie = 'U' and ref like 'D%' group by ref", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    chaine = dr[0].ToString();
                    for (int i = 0; i < c.dgvPassif.RowCount; i++)
                    {
                        if (c.dgvPassif.Rows[i].Cells[0].Value.ToString() == chaine)
                        {
                            c.dgvPassif.Rows[i].Cells[3].Value = double.Parse(dr[1].ToString());
                            c.dgvPassif.Rows[i].Cells[4].Value = double.Parse(dr[2].ToString());
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 3; i < 5; i++)
            {
                c.dgvPassif.Rows[c.dgvPassif.RowCount - 1].Cells[i].Value = CalculerTotal(c.dgvPassif, i);
            }
        }
        public void RubriquesActif(FormComptaBilan c)
        {
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
            c.dgvActif.Rows[0].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[5].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[12].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[15].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[22].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[26].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvActif.Rows[28].DefaultCellStyle.BackColor = Color.IndianRed;
        }
        public void RubriquesPassif(FormComptaBilan c)
        {
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
            c.dgvPassif.Rows[10].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvPassif.Rows[14].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvPassif.Rows[15].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvPassif.Rows[22].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvPassif.Rows[25].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvPassif.Rows[27].DefaultCellStyle.BackColor = Color.IndianRed;
        }
        public double CalculerTotal(DataGridView dgv, int column)
        {
            valeur = 0;
            for (int i = 0; i < dgv.RowCount; i++)
            {
                valeur += double.Parse(dgv.Rows[i].Cells[column].Value.ToString());
            }
            return valeur;
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
        public void RubriquesBalances(FormComptaBalance c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select numcompte, libellecompte, soldeanterieur, categorie from Compte", con);
                dr = cmd.ExecuteReader();
                c.dgvBalance.Rows.Clear();
                while (dr.Read())
                {
                    chaine = dr[0].ToString();
                    c.dgvBalance.Rows.Add();
                    c.dgvBalance.Rows[c.dgvBalance.RowCount-1].Cells[0].Value = dr[0].ToString();
                    c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    
                    valeur = double.Parse(dr[2].ToString());
                    if (valeur < 0)
                    {
                        c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = 0;
                        if (dr[3].ToString() != "UU")
                            c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = -valeur;
                        else
                            c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = -valeur * c.taux;
                    }
                    else if (valeur >= 0)
                    {
                        if (dr[3].ToString() != "UU")
                            c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = valeur;
                        else
                            c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = valeur * c.taux;
                        
                        c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = 0;
                    }
                    else
                    {
                        c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[2].Value = 0;
                        c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[3].Value = 0;
                    }
                    c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[4].Value = 0;
                    c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[5].Value = 0;
                    c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[6].Value = 0;
                    c.dgvBalance.Rows[c.dgvBalance.RowCount - 1].Cells[7].Value = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void CalculerBalance(FormComptaBalance c)
        {
            con.Open();
            try
            {
               cmd = new SqlCommand("select numcompte, sum(montantdebit) as Débit, sum(montantcredit) as Crédit from OperationCompte group by numcompte", con);
               dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                   chaine = dr[0].ToString();
                   for (int i = 0; i < c.dgvBalance.RowCount; i++)
                   {
                       if (c.dgvBalance.Rows[i].Cells[0].Value.ToString()== chaine)
                       {
                           c.dgvBalance.Rows[i].Cells[4].Value = double.Parse(dr[1].ToString());
                           c.dgvBalance.Rows[i].Cells[5].Value = double.Parse(dr[2].ToString());

                           if (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()) > double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()))
                               c.dgvBalance.Rows[i].Cells[6].Value = (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString())) - (double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()));
                           else if (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()) < double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()))
                               c.dgvBalance.Rows[i].Cells[7].Value = (double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString())) - (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()));
                           else
                           {
                               c.dgvBalance.Rows[i].Cells[6].Value = 0;
                               c.dgvBalance.Rows[i].Cells[7].Value = 0;
                           }
                           break;
                       }
                       
                   }
               }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
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
        public void ComptesBalance(FormComptaBalance c)
        {
            if(c.cboBalance.Text=="Tous les comptes")
            {
                RubriquesBalances(c);
                CalculerBalance(c);
            }
            else
            {
                if (c.dgvBalance.RowCount != 0)
                {
                    id = 0;
                    for (int i = 0; i < c.dgvBalance.RowCount; i++)
                    {
                        if (double.Parse(c.dgvBalance.Rows[i].Cells[6].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[7].Value.ToString()) == 0)
                            id++;
                    }
                    SupprimerLigne(c, id);
                }
                else
                    MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region TABLEAU_DE_RESULTAT
        public void RubriquesResultat(FormComptaResultat c)
        {
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
                    c.dgvResultat.Rows[i].Cells[2].Value = "";
                    c.dgvResultat.Rows[i].Cells[3].Value = chaine;
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
            c.dgvResultat.Rows[3].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[7].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[21].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[23].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[26].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[32].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[33].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[38].DefaultCellStyle.BackColor = Color.RosyBrown;
            c.dgvResultat.Rows[41].DefaultCellStyle.BackColor = Color.IndianRed;
        }
        public void CalculerResultat(FormComptaResultat c)
        {
            cmd = new SqlCommand("select numcompte, sum(montantdebit) as Débit, sum(montantcredit) as Crédit from OperationCompte group by numcompte", con);
            da = new SqlDataAdapter(cmd);
            try
            {
                dt.Clear();
                con.Open();
                da.Fill(dt);
                //dt.Rows.Count;
                //c.dgv2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
            }
        }
        public void AfficherCasConsultation(FormAdminStatService s)
        {
            for (int i = 0; i < s.dgvRapport.RowCount; i++)
            {
                id = 0;
                if (s.dgvRapport.Rows[i].Cells[1].Value.ToString() == "706101")
                    id = s.dgvRapport.Rows[i].Index;
                if(s.dgvRapport.Rows[i].Cells[0].Value.ToString() == "")
                {
                    for (int j = 3; j < s.dgvRapport.ColumnCount; j++)
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
        public void AfficherCas(FormAdminStatService s)
        {
            for (int i = 0; i < s.dgvRapport.RowCount; i++)
            {
                if(s.dgvRapport.Rows[i].Cells[0].Value.ToString() != "" && s.dgvRapport.Rows[i].Cells[1].Value.ToString() != "706101")
                {
                    for (int j = 3; j < s.dgvRapport.ColumnCount; j++)
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
        #endregion

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
