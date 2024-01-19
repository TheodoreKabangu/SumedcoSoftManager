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
using System.IO;

namespace SUMEDCO
{
    class ClassMalade
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        int id = 0;
        bool cmdStatut;
        string cmdtxt = "", chaine= "";
        
        #region METHODES GENERALES
        public int NouveauID(string concerne)
        {
            id = 0;
            switch (concerne)
            {
                case "recette": cmdtxt = "select max(idrecette) from Recette"; break;
                case "patient": cmdtxt = "select max(idpatient) from Patient"; break;
                case "consultation": cmdtxt = "select max(idconsultation) from Consultation"; break;
                case "renseignement": cmdtxt = "select max(id) from Renseignement"; break;
                case "prescription": cmdtxt = "select max(idprescription) from Prescription"; break;
                case "service": cmdtxt = "select max(idservice) from ServiceDemande"; break;
                case "medecin": cmdtxt = "select max(idmedecin) from Medecin"; break;
                case "maladie": cmdtxt = "select max(idmaladie) from Maladie"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
                case "examenphysique": cmdtxt = "select max(idexamen) from ExamenPhysique"; break;
                case "svc": cmdtxt = "select max(id) from SigneVitalConsultation"; break;
                case "s": cmdtxt = "select max(idsigne) from SigneVital"; break;
                case "rdv": cmdtxt = "select max(idrendezvous) from Rendezvous"; break;
                case "prise": cmdtxt = "select max(idprise) from PriseSigneVitaux"; break;
                case "consultationdossier": cmdtxt = "select max(id) from ConsultationDossier"; break;
                case "agendalabo": cmdtxt = "select max(id) from AgendaLabo"; break;
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
        long valeur;
        string nom;
        public void TestEntier(TextBox txt)
        {
            valeur = 0;
            if (txt.Text != "")
            {
                try
                {
                    valeur = long.Parse(txt.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt.Text = txt.Text.Substring(0, txt.Text.Length - 1);
                }
            }
            if (valeur == 0)
                txt.Text= "";
            else
                txt.Text= valeur.ToString();
        }

        public int TrouverId(string motif, string nom)
        {
            id = 0;
            switch(motif)
            {
                case "medecin": cmdtxt = "select idmedecin from Medecin where nommedecin = @nom"; break;
                case "pharmacie": cmdtxt = "select idpharma from Pharmacie where designation = @nom"; break;
                case "typepatient": cmdtxt = "select idtype from TypePatient where nomtype = @nom"; break;
                case "typepatient2": cmdtxt = "select idtype from Patient where noms = @nom"; break;
                case "maladie": cmdtxt = "select idmaladie from Maladie where nommaladie = @nom"; break;
                case "patient": cmdtxt = "select idpatient from Patient where noms = @nom"; break;
                case "entreprise": cmdtxt = "select identreprise from Entreprise where nomentreprise = @nom"; break;
                case "autorisation": cmdtxt = "select id from Autorisations where libelle = @nom"; break;
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
                case "medecin": cmdtxt = "select nommedecin from Medecin where idmedecin = @id"; break;
                case "patient": cmdtxt = "select noms from Patient where idpatient = @id"; break;
                case "typepatient": cmdtxt = "select nomtype from TypePatient where idtype = @id"; break;
                case "numcompte_entreprise": cmdtxt = "select numcompte from Entreprise where identreprise = @id"; break;
                case "maladie": cmdtxt = "select nommaladie from Maladie where idmaladie= @id"; break;
                case "signevital": cmdtxt = "select nomsigne from SigneVital where idsigne= @id"; break;
                case "poste": cmdtxt = "select poste from Utilisateur where id= @id"; break;
                case "autorisation": cmdtxt = "select etat from Autorisations where id= @id"; break;
                case "entreprise": cmdtxt = "select nomentreprise from Entreprise where identreprise = @id"; break;
                case "typeabonne": cmdtxt = "select typeabonne from TypeAbonne where idtypeabonne = @id"; break;
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
        #endregion

        private Form activeForm = null;

        #region INFIRMERIE
        public void AfficherSousForm(MFormInfirmerie i, FormAgendaNursing childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            i.pnlChildForm.Controls.Add(childForm);
            i.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        public void AfficherSousForm(MFormInfirmerie i, FormPatientRecherche childForm)
        {
            if (i.activeForm != null)
                i.activeForm.Close();
            i.activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            i.pnlChildForm.Controls.Add(childForm);
            i.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.poste = "infirmerie";
            childForm.Show();
        }
        public void AfficherSousForm(MFormInfirmerie r, FormRecette childForm)
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
        public void AfficherSousForm(MFormInfirmerie r, Form childForm)
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
        #endregion
        
        List<string> rubriques = new List<string>();

        #region CONSULTATIONN
        
        public void ChargerPriseSigneVitaux(FormConsulterPrise c, string motif)
        {
            con.Open();
            try
            {

                if (motif == "recherche")
                {
                    cmdtxt = @"SELECT idprise, p.idpatient, noms, idrecette 
                    FROM PriseSigneVitaux ps 
                    JOIN Patient p ON ps.idpatient = p.idpatient
                    WHERE date_prise BETWEEN @dtpdateDe AND @dtpdateA 
                    AND idmedecin = '" + c.idmedecin + "'";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                }
                else
                {
                    cmdtxt = @"SELECT idprise, p.idpatient, noms, idrecette 
                    FROM PriseSigneVitaux ps 
                    JOIN Patient p ON ps.idpatient = p.idpatient
                    WHERE date_prise = '" + DateTime.Now.ToShortDateString() + "' AND idmedecin = '" + c.idmedecin + "'";
                    cmd = new SqlCommand(cmdtxt, con);
                }
                dr = cmd.ExecuteReader();
                c.dgvPrise.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPrise.Rows.Add();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public int IdConsultationPrise(int idprise)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idconsultation FROM Consultation WHERE idprise = '" + idprise + "'", con);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void PatientConsulte(DataGridView dgv, int idpatient)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT noms, sexe, age, adresse, situation, telephone, pers_contact, tel_contact, nomtype, idpatient, identreprise 
                FROM Patient p
                JOIN TypePatient tp ON p.idtype = tp.idtype
                WHERE p.idpatient = " + idpatient + "";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add(11);
                    dgv.Rows[0].Cells[0].Value = "Noms";
                    dgv.Rows[1].Cells[0].Value = "Sexe";
                    dgv.Rows[2].Cells[0].Value = "Age";
                    dgv.Rows[3].Cells[0].Value = "Adresse";
                    dgv.Rows[4].Cells[0].Value = "Situation";
                    dgv.Rows[5].Cells[0].Value = "Téléphone";
                    dgv.Rows[6].Cells[0].Value = "Pers. contact";
                    dgv.Rows[7].Cells[0].Value = "Tél. pers. contact";
                    dgv.Rows[8].Cells[0].Value = "Type";
                    dgv.Rows[9].Cells[0].Value = "ID";
                    dgv.Rows[10].Cells[0].Value = "Entreprise";

                    dgv.Rows[0].Cells[1].Value = dr[0].ToString();
                    dgv.Rows[1].Cells[1].Value = dr[1].ToString();
                    dgv.Rows[2].Cells[1].Value = dr[2].ToString();
                    dgv.Rows[3].Cells[1].Value = dr[3].ToString();
                    dgv.Rows[4].Cells[1].Value = dr[4].ToString();
                    dgv.Rows[5].Cells[1].Value = dr[5].ToString();
                    dgv.Rows[6].Cells[1].Value = dr[6].ToString();
                    dgv.Rows[7].Cells[1].Value = dr[7].ToString();
                    dgv.Rows[8].Cells[1].Value = dr[8].ToString();
                    dgv.Rows[9].Cells[1].Value = dr[9].ToString();
                    dgv.Rows[10].Cells[1].Value = dr[10].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if (dgv.Rows[8].Cells[1].Value.ToString().Contains("abonné"))
                dgv.Rows[10].Cells[1].Value = TrouverNom("entreprise", Convert.ToInt32(dgv.Rows[10].Cells[1].Value.ToString()));
            else
                dgv.Rows[10].Visible = false;
        }
        public void Consultation(FormConsulterPrise cp, FormConsulter c)
        {
            c.idconsultation = cp.idconsultation;
            c.idpatient = cp.idpatient;
            c.idmedecin = cp.idmedecin;
            c.idprise = cp.idprise;
            c.type_patient = cp.dgvPatient.Rows[8].Cells[1].Value.ToString();
            PatientConsulte(c.dgvPatient, c.idpatient);

            ValeurSigneVitaux(c.dgvSigneVital, c.idprise);
            c.Text = "SSM - Dossier " + cp.dgvPrise.CurrentRow.Cells[2].Value.ToString();

            c.Show();
            c.Close();
        }
        public void AjouterFichePatient(FormConsulter c)
        {
            if (c.txtFiche.Text != "")
            {
                using (Stream stream = File.OpenRead(c.txtFiche.Text))
                {
                    //binarisation du fichier preuve
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    var fichier = new FileInfo(c.txtFiche.Text);
                    string ext = fichier.Extension;
                    string nomfichier = fichier.Name;
                    //enregistrement
                    id = NouveauID("consultationdossier");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("INSERT INTO ConsultationDossier VALUES (@id, @idconsultation, @fichier, @nomfichier, @ext)", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@fichier", buffer);
                        cmd.Parameters.AddWithValue("@nomfichier", nomfichier);
                        cmd.Parameters.AddWithValue("@ext", ext);

                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Ajouté avec succès", "Requête", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    c.txtFiche.Clear();
                }
            }
            else
            {
                MessageBox.Show("Désolé! Champs obligatoire(s) vide(s)", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AfficherSousForm(MFormConsultation c, FormConsultationDossier childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idmedecin = c.idmedecin;
            childForm.Show();
        }
        public void RechercheConsultation(FormConsultationDossier cd, FormConsultation c)
        {
            c.idmedecin = cd.idmedecin;
            c.ShowDialog();
            if (!c.fermeture_succes)
            {
                cd.Close();
                c.Close();
            }
            else
            {
                DetailsConsultation(c, cd);
                c.Close();
            }
        }
        public void AfficherSousForm(MFormConsultation c, FormConsulterPrise childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idmedecin = c.idmedecin;
            childForm.idutilisateur = c.idutilisateur;
            childForm.Show();
        }
        public void AfficherSousForm(MFormConsultation c, FormMessageHisto childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = c.idmedecin;
            childForm.Show();
        }
        public void AfficherSousForm(MFormComptabilite c, FormMessageHisto childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = c.idutilisateur;
            childForm.Show();
        }
        public void AfficherSousForm(MFormConsultation c, FormConsultationStat childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            c.pnlChildForm.Controls.Add(childForm);
            c.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idmedecin = c.idmedecin;
            childForm.Show();
        }
        
        public void Afficher(FormConsultation c, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (c.txtNom.Text == "")
                    {
                        cmdtxt = @"select idconsultation, noms, repondant, lienrepondnant, p.idprise, p.idpatient  
                        from Consultation c 
                        JOIN PriseSigneVitaux p ON c.idprise = p.idprise 
                        JOIN Patient pa ON p.idpatient = pa.idpatient
                        where date_consultation between @dtpdateDe and @dtpdateA 
                        and idmedecin= @idmedecin";
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idmedecin", c.idmedecin);
                    }
                    else
                    {
                        cmdtxt = @"select idconsultation, noms, repondant, lienrepondnant, p.idprise, p.idpatient  
                        from Consultation c 
                        JOIN PriseSigneVitaux p ON c.idprise = p.idprise 
                        JOIN Patient pa ON p.idpatient = pa.idpatient
                        where date_consultation between @dtpdateDe and @dtpdateA 
                        and noms LIKE '" + c.txtNom.Text.Replace("'", "") + "%'";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);

                }
                else if (motif == "patient")
                {
                    cmdtxt = @"select idconsultation, noms, repondant, lienrepondnant, p.idprise, p.idpatient 
                    from Consultation c 
                    JOIN PriseSigneVitaux p ON c.idprise = p.idprise 
                    JOIN Patient pa ON p.idpatient = pa.idpatient
                    where date_consultation between @dtpdateDe and @dtpdateA 
                    and pa.idpatient = @idpatient";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idpatient", c.idpatient);
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                }
                else
                {
                    cmdtxt = @"select idconsultation, noms, repondant, lienrepondnant, p.idprise, p.idpatient 
                    from Consultation c 
                    JOIN PriseSigneVitaux p ON c.idprise = p.idprise 
                    JOIN Patient pa ON p.idpatient = pa.idpatient
                    where date_consultation = '" + DateTime.Now.ToShortDateString() + "' and idmedecin= @idmedecin";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@idmedecin", c.idmedecin);
                }
                dr = cmd.ExecuteReader();
                c.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPatient.Rows.Add();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[5].Value = dr[5].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void FichiersConsultation(FormConsultation c)
        {
            con.Open();
            try
            {               
                cmdtxt = @"SELECT id, nomfichier, extfichier FROM ConsultationDossier WHERE idconsultation = @id";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                dr = cmd.ExecuteReader();
                c.dgvDossier.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvDossier.Rows.Add();
                    c.dgvDossier.Rows[c.dgvDossier.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvDossier.Rows[c.dgvDossier.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvDossier.Rows[c.dgvDossier.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void OuvrirFicheManuscrite(FormConsultation c)
        {
            c.btnFiche.Enabled = false;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT fichier, nomfichier, extfichier FROM ConsultationDossier WHERE id = @id", con);
                cmd.Parameters.AddWithValue("@id", c.iddossier);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    var fichier = (byte[])dr[0];
                    var nomfichier = dr[1].ToString();
                    var ext = dr[2].ToString();
                    var newfile = nomfichier.Replace(ext, "");
                    File.WriteAllBytes(newfile, fichier);
                    System.Diagnostics.Process.Start(newfile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void SigneVitalConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("SELECT TOP 5 s.idsigne, nomsigne, valeur, unite FROM SigneVital s JOIN ValeurSigneVitaux vs ON vs.idsigne = s.idsigne WHERE idprise = '" + cd.idprise + "'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = dr[1].ToString() + ": " + dr[2].ToString() + " " + dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void RenseignementConsultation(FormConsultationDossier cd, string label)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select id, libelle from Renseignement where label= @label and idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@label", label);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ExamenPhysiqueConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("SELECT ve.idexamen, examen, valeur FROM ValeurExamenPhysique ve JOIN ExamenPhysique e ON ve.idexamen = e.idexamen WHERE idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = dr[1].ToString() + ": " + dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        
        public void VoirExamenPhysique(FormConsulter c)
        {
             con.Open();
            try
            {
                cmd = new SqlCommand("select ve.idexamen, examen, valeur FROM ValeurExamenPhysique ve JOIN ExamenPhysique e ON e.idexamen = ve.idexamen WHERE idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                dr = cmd.ExecuteReader();
                c.dgvExamPhys.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvExamPhys.Rows.Add();
                    c.dgvExamPhys.Columns[0].Visible = false;
                    c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
           if(c.dgvExamPhys.RowCount != 0)
           {
               c.btnModifierExamPhys.Enabled = true;
               c.btnSupprimerExamPhys.Enabled = true;
           }
        }
        public void VoirRenseignement(FormConsulter c, string label)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT id, libelle FROM Renseignement WHERE label= @label AND idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@label", label);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                dr = cmd.ExecuteReader();
                switch (label)
                {
                    case "plainte":
                        c.dgvPlainte.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvPlainte.Rows.Add();
                                c.dgvPlainte.Columns[0].Visible = false;
                                c.dgvPlainte.Rows[c.dgvPlainte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvPlainte.Rows[c.dgvPlainte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvPlainte.RowCount != 0)
                        {
                            c.btnModifierPlainte.Enabled = true;
                            c.btnSupprimerPlainte.Enabled = true;
                        }                            
                        break;
                    case "historique":
                        c.dgvHisto.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvHisto.Rows.Add();
                                c.dgvHisto.Columns[0].Visible = false;
                                c.dgvHisto.Rows[c.dgvHisto.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvHisto.Rows[c.dgvHisto.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvHisto.RowCount != 0)
                        {
                            c.btnModifierHisto.Enabled = true;
                            c.btnSupprimerHisto.Enabled = true;
                        }
                        break;
                    case "antécédent":
                        c.dgvAntecedent.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvAntecedent.Rows.Add();
                                c.dgvAntecedent.Columns[0].Visible = false;
                                c.dgvAntecedent.Rows[c.dgvAntecedent.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvAntecedent.Rows[c.dgvAntecedent.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvAntecedent.RowCount != 0)
                        {
                            c.btnModifierAntecedent.Enabled = true;
                            c.btnSupprimerAntecedent.Enabled = true;
                        }
                        break;
                    case "complément":
                        c.dgvComplement.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvComplement.Rows.Add();
                                c.dgvComplement.Columns[0].Visible = false;
                                c.dgvComplement.Rows[c.dgvComplement.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvComplement.Rows[c.dgvComplement.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvComplement.RowCount != 0)
                        {
                            c.btnModifierComplement.Enabled = true;
                            c.btnSupprimerComplement.Enabled = true;
                        }
                        break;                    
                    case "prédiagnostic":
                        c.dgvPrediagnostic.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvPrediagnostic.Rows.Add();
                                c.dgvPrediagnostic.Columns[0].Visible = false;
                                c.dgvPrediagnostic.Rows[c.dgvPrediagnostic.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvPrediagnostic.Rows[c.dgvPrediagnostic.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvPrediagnostic.RowCount != 0)
                        {
                            c.btnModifierPrediag.Enabled = true;
                            c.btnSupprimerPrediag.Enabled = true;
                        }
                        break;
                    case "autre":
                        c.dgvAutrePresc.Rows.Clear();
                        while (dr.Read())
                            {
                                c.dgvAutrePresc.Rows.Add();
                                c.dgvAutrePresc.Columns[0].Visible = false;
                                c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                        if (c.dgvAutrePresc.RowCount != 0)
                        {
                            c.btnModifierAutrePresc.Enabled = true;
                            c.btnSupprimerAutrePresc.Enabled = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void VoirMaladieDiagnostic(FormConsulter c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT mc.idmaladie, nommaladie, observation from MaladieConsultation mc JOIN Maladie m ON mc.idmaladie = m.idmaladie WHERE idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                dr = cmd.ExecuteReader();
                c.dgvDiagnostic.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvDiagnostic.Rows.Add();
                    c.dgvDiagnostic.Columns[0].Visible = false;
                    c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            if(c.dgvDiagnostic.RowCount != 0)
            {
                c.btnModifierDiagno.Enabled = true;
                c.btnSupprimerDiagno.Enabled = true;
            }
        }
        public void VoirPrescription(FormConsulter c, FormConsulterPresc exa, string categorie)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idprescription, libelle, observation, date_jour, categorie FROM Prescription WHERE idconsultation = @id AND categorie = @categorie", con);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                cmd.Parameters.AddWithValue("@categorie", categorie);
                dr = cmd.ExecuteReader();
                exa.dgvPresc.Rows.Clear();
                while (dr.Read())
                {
                    exa.dgvPresc.Rows.Add();
                    exa.dgvPresc.Rows[exa.dgvPresc.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    exa.dgvPresc.Rows[exa.dgvPresc.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    exa.dgvPresc.Rows[exa.dgvPresc.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    exa.dgvPresc.Rows[exa.dgvPresc.RowCount - 1].Cells[3].Value = dr[3].ToString().Substring(0,10);
                    exa.dgvPresc.Rows[exa.dgvPresc.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (exa.dgvPresc.RowCount != 0)
            {
                exa.idconsultation = c.idconsultation; 
                exa.ShowDialog();
            }
            else
                MessageBox.Show("Aucun élément n'a été trouvé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        public void PrescriptionConsultation(FormConsultationDossier cd, string categorie)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("SELECT idprescription, libelle, observation, date_jour, categorie FROM Prescription WHERE idconsultation = @id AND categorie = @categorie", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                cmd.Parameters.AddWithValue("@categorie", categorie);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = string.Format("{0}, {1}, {2}, {3}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void MaladieConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id=0;
                cmd = new SqlCommand("SELECT mc.idmaladie, nommaladie, observation from MaladieConsultation mc JOIN Maladie m ON mc.idmaladie = m.idmaladie WHERE idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = dr[1].ToString() + ": " + dr[2].ToString(); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void DetailsConsultation(FormConsultation c, FormConsultationDossier cd)
        {
            cd.idconsultation = c.idconsultation;
            cd.patient = c.dgvPatient.CurrentRow.Cells[1].Value.ToString();
            cd.idprise = int.Parse(c.dgvPatient.CurrentRow.Cells[4].Value.ToString());
            cd.idpatient = TrouverId("patient", cd.patient);
            cd.medecin = TrouverNom("medecin", cd.idmedecin);
            PatientConsulte(cd.dgvPatient, cd.idpatient);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "SIGNES VITAUX";
            SigneVitalConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PLAINTES";
            RenseignementConsultation(cd, "plainte");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "HISTORIQUE DE LA MALADIE";
            RenseignementConsultation(cd, "historique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "ANTECEDENTS MEDICAUX";
            RenseignementConsultation(cd, "antécédent");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "COMPLEMENT D'ANAMNESE";
            RenseignementConsultation(cd, "complément");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PHYSIQUES";
            ExamenPhysiqueConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PREDIAGNOSTIC";
            RenseignementConsultation(cd, "prédiagnostic");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PARACL. & RESULTATS";
            PrescriptionConsultation(cd, "examen para");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "DIAGNOSTICS";
            MaladieConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS PRODUITS";
            PrescriptionConsultation(cd, "produit");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            PrescriptionConsultation(cd, "autre");

        }
        public void DetailsConsultation(FormConsultationDossier cd)
        {
            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "SIGNES VITAUX";
            SigneVitalConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PLAINTES";
            RenseignementConsultation(cd, "plainte");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "HISTORIQUE DE LA MALADIE";
            RenseignementConsultation(cd, "historique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "ANTECEDENTS MEDICAUX";
            RenseignementConsultation(cd, "antécédent");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "COMPLEMENT D'ANAMNESE";
            RenseignementConsultation(cd, "complément");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PHYSIQUES";
            ExamenPhysiqueConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PREDIAGNOSTIC";
            RenseignementConsultation(cd, "prédiagnostic");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PARACL. & RESULTATS";
            PrescriptionConsultation(cd, "examen para");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "DIAGNOSTICS";
            MaladieConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS PRODUITS";
            PrescriptionConsultation(cd, "produit");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            PrescriptionConsultation(cd, "autre");
        }
        public void ModifierExamenPhysique(FormConsulter c)
        {
            if (c.dgvExamPhys.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update ValeurExamenPhysique set valeur = @valeur where idconsultation = @idconsultation and idexamen = @idexamen", con);
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Parameters.AddWithValue("@idexamen", c.dgvExamPhys.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@valeur", c.dgvExamPhys.CurrentRow.Cells[2].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerExamenPhysique(FormConsulter c)
        {
            if (c.dgvExamPhys.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from ValeurExamenPhysique where idconsultation = @idconsultation and idexamen = @idexamen", con);
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Parameters.AddWithValue("@idexamen", c.dgvExamPhys.CurrentRow.Cells[0].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.dgvExamPhys.Rows.RemoveAt(c.dgvExamPhys.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region CONSULTER
        
        public void RemplirNumLigne(DataGridView dgv, int colonne)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[colonne].Value = i + 1;
            }
        }        
        
        public void AjouterConsultation(FormConsulterPrise cp)
        {
            cp.idconsultation = NouveauID("consultation");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (cp.txtRepondant.Text != "" && cp.cboLienRepondant.Text != "")
                {
                    cmd = new SqlCommand("insert into Consultation (idconsultation, date_consultation, repondant, lienrepondnant, idprise) values (@id, @date, @repondant, @lien, @idprise)", con);
                    cmd.Parameters.AddWithValue("@repondant", cp.txtRepondant.Text);
                    cmd.Parameters.AddWithValue("@lien", cp.cboLienRepondant.Text);
                }
                else
                    cmd = new SqlCommand("insert into Consultation(idconsultation, date_consultation, idprise) values (@id, @date, @idprise)", con);

                cmd.Parameters.AddWithValue("@id", cp.idconsultation);
                cmd.Parameters.AddWithValue("@date", cp.dtpDate.Value);
                cmd.Parameters.AddWithValue("@idprise", cp.idprise);
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
            cc.RecetteServiOK(cp.idrecette, cp.idutilisateur, "OK");
            Consultation(cp, new FormConsulter());           
        }
        public void ExamenPhysique(FormConsulter r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from ExamenPhysique", con);
                dr = cmd.ExecuteReader();
                r.dgvExamPhys.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvExamPhys.Rows.Add();
                    r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount -1].Cells[0].Value = dr[0].ToString();
                    r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount - 1].Cells[2].Value = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AjouterValeurExamenPhysique(FormConsulter c)
        {
            if (c.dgvExamPhys.RowCount != 0)
            {
                for (int i = 0; i < c.dgvExamPhys.RowCount; i++)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ValeurExamenPhysique values (@idconsultation, @idexamen, @valeur)", con);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@idexamen", c.dgvExamPhys.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@valeur", c.dgvExamPhys.Rows[i].Cells[2].Value.ToString());
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
                c.dgvExamPhys.Rows.Clear();
                MessageBox.Show("Enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterRenseignement(DataGridView dgv, string label, int idconsultation)
        {
            if (dgv.RowCount != 0)
            {
                id = 0;
                for (int i = 0; i < dgv.RowCount; i++)
                {
                    id = NouveauID("renseignement");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Renseignement values (@id, @label, @idconsultation, @libelle)", con);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@label", label);
                        cmd.Parameters.AddWithValue("@idconsultation", idconsultation);
                        cmd.Parameters.AddWithValue("@libelle", dgv.Rows[i].Cells[1].Value.ToString());
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
                dgv.Rows.Clear();
                MessageBox.Show("Enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterPrescription(FormConsulter c, string label)
        {
            cmdStatut = false;
            if(label == "examen para")
            {
                for (int i = 0; i < c.dgvLabo.RowCount; i++)
                {
                    id = NouveauID("prescription");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Prescription values (@idprescription, @idconsultation, @date_jour, @categorie, @libelle, @observation)", con);
                        cmd.Parameters.AddWithValue("@idprescription", id);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@categorie", label);
                        cmd.Parameters.AddWithValue("@libelle", c.dgvLabo.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@observation", "RAS");
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
                }
            }
            else if (label == "autre")
            {
                for (int i = 0; i < c.dgvAutrePrescS.RowCount; i++)
                {
                    id = NouveauID("prescription");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Prescription values (@idprescription, @idconsultation, @date_jour, @categorie, @libelle, @observation)", con);
                        cmd.Parameters.AddWithValue("@idprescription", id);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@categorie", label);
                        cmd.Parameters.AddWithValue("@libelle", c.dgvAutrePrescS.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@observation", "RAS");
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
                }
            }
            else if (label == "produit")
            {
                for (int i = 0; i < c.dgvPresc.RowCount; i++)
                {
                    id = NouveauID("prescription");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Prescription values (@idprescription, @idconsultation, @date_jour, @categorie, @libelle, @observation)", con);
                        cmd.Parameters.AddWithValue("@idprescription", id);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                        cmd.Parameters.AddWithValue("@categorie", label);
                        cmd.Parameters.AddWithValue("@libelle", string.Format("{0}, Qté {1}, Posologie {2}", c.dgvPresc.Rows[i].Cells[1].Value.ToString(), c.dgvPresc.Rows[i].Cells[2].Value.ToString(), c.dgvPresc.Rows[i].Cells[3].Value.ToString()));
                        cmd.Parameters.AddWithValue("@observation", "RAS");
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
                }
            }
            if(cmdStatut)
            {
                c.dgvPresc.Rows.Clear();
                c.dgvAutrePrescS.Rows.Clear();
                c.dgvAutrePresc.Rows.Clear();
                MessageBox.Show("Enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AjouterExamenPara(FormConsulter c, FormFactureService f)
        {
            if (c.dgvLabo.RowCount != 0)
            {
                f.idpayeur = int.Parse(c.dgvPatient.Rows[9].Cells[1].Value.ToString());
                f.btnAnnuler.Enabled = false;
                f.txtPayeur.Text = c.dgvPatient.Rows[0].Cells[1].Value.ToString();                
                f.txtPayeur.Enabled = false;
                f.txtTel.Enabled = false;
                f.txtRecherche.Enabled = false;
                f.btnRecherche.Enabled = false;
                f.btnExit.Visible = false;
                f.Text = "Facturation Examens";
                f.recettePatientConsulte = true;
                f.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();
                if (f.type_patient != "payant" && f.type_patient != "cas social")
                {
                    f.cboTypeFacture.Items.Remove("immédiat");
                    f.poste = "abonné";
                }
                else
                    f.poste = "réception";
                for (int i = 0; i < c.dgvLabo.RowCount; i++)
                {
                    if (c.dgvLabo.Rows[i].Cells[0].Value.ToString() != "")
                    {
                        f.dgvFacture.Rows.Add();
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = c.dgvLabo.Rows[i].Cells[0].Value;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f.dgvFacture.RowCount;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = c.dgvLabo.Rows[i].Cells[2].Value;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = c.dgvLabo.Rows[i].Cells[3].Value;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = c.dgvLabo.Rows[i].Cells[4].Value;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = c.dgvLabo.Rows[i].Cells[5].Value;
                        f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[6].Value = c.dgvLabo.Rows[i].Cells[6].Value;
                    }
                }
                cc.CalculerTotal(f.dgvFacture, f.txtTotal);
                f.ShowDialog();
                if (f.fermeture_succes)
                {
                    AjouterPrescription(c, "examen para");
                    MessageBox.Show("Enregistrée(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Generer le bon d'examens
                    GenererBonExamen(c, new FormImpression());
                    c.dgvLabo.Rows.Clear();
                }
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void MaladieDiagnostic(FormConsulter c, FormMaladie m)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from Maladie", con);
                dr = cmd.ExecuteReader();
                m.dgv.Rows.Clear();
                while (dr.Read())
                {
                    m.dgv.Rows.Add();
                    m.dgv.Rows[m.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    m.dgv.Rows[m.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            m.ShowDialog();
            if (m.fermeture_succes)
            {
                c.dgvDiagnostic.Rows.Clear();
                for (int i = 0; i < m.dgv.RowCount; i++)
                {
                    if (m.dgv.Rows[i].Selected)
                    {
                        c.dgvDiagnostic.Rows.Add();
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[0].Value = m.dgv.Rows[i].Cells[0].Value.ToString();
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[1].Value = m.dgv.Rows[i].Cells[1].Value.ToString();
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[2].Value = "RAS";
                    }

                }
            }
            m.Close();
        }
        public void AjouterDiagnostics(FormConsulter c)
        {
            if (c.dgvDiagnostic.RowCount != 0)
            {
                for (int i = 0; i < c.dgvDiagnostic.RowCount; i++)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into MaladieConsultation values (@idmaladie, @idconsultation, @observation)", con);
                        cmd.Parameters.AddWithValue("@idmaladie", c.dgvDiagnostic.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@observation", c.dgvDiagnostic.Rows[i].Cells[2].Value.ToString());
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
                MessageBox.Show("Enregistrée(s) avec succès", "Enregitrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.dgvDiagnostic.Rows.Clear();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Prescrire(FormConsulter c, FormFactureProduit f)
        {
            f.idpayeur = int.Parse(c.dgvPatient.Rows[9].Cells[1].Value.ToString());
            f.btnAnnuler.Enabled = false;
            f.txtPayeur.Text = c.dgvPatient.Rows[0].Cells[1].Value.ToString();            
            f.txtPayeur.Enabled = false;
            f.txtTel.Enabled = false;
            f.btnExit.Visible = false;
            f.Text = "Facturation Produits";
            f.recettePatientConsulte = true;
            f.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();
            if (f.type_patient != "payant" && f.type_patient != "cas social")
            {
                f.cboTypeFacture.Items.Remove("immédiat");
                f.poste = "abonné";
            }
            else
                f.poste = "réception";
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            if (f.fermeture_succes)
            {
                c.dgvPresc.Rows.Clear();
                for (int i = 0; i < f.dgvFacture.RowCount; i++)
                {
                    c.dgvPresc.Rows.Add();
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[0].Value = f.dgvFacture.Rows[i].Cells[0].Value;
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[1].Value = f.dgvFacture.Rows[i].Cells[2].Value;
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[2].Value = f.dgvFacture.Rows[i].Cells[4].Value;
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[3].Value = "";
                }
            }
            f.Close();
        }
        public void AutrePrescription(FormConsulter c, FormFactureService f)
        {
            f.idpayeur = int.Parse(c.dgvPatient.Rows[9].Cells[1].Value.ToString());
            f.btnAnnuler.Enabled = false;
            f.txtPayeur.Text = c.dgvPatient.Rows[0].Cells[1].Value.ToString();           
            f.txtPayeur.Enabled = false;
            f.txtTel.Enabled = false;           
            f.btnExit.Visible = false;
            f.Text = "Facturation Service";
            f.recettePatientConsulte = true;
            f.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();
            if (f.type_patient != "payant" && f.type_patient != "cas social")
            {
                f.cboTypeFacture.Items.Remove("immédiat");
                f.poste = "abonné";
            }
            else
                f.poste = "réception";
            cc.ChargerCategorie(f, "");
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ShowDialog();
            if (f.fermeture_succes)
            {
                for (int i = 0; i < f.dgvFacture.RowCount; i++)
                {
                    c.dgvAutrePresc.Rows.Add();
                    c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[0].Value = f.dgvFacture.Rows[i].Cells[0].Value;
                    c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[1].Value = f.dgvFacture.Rows[i].Cells[2].Value;
                }
            }
            f.Close();
        }
        public void AjouterRendezVous(FormConsulter c, FormConsulterRendezVous cr)
        {
            cr.idconsultation = c.idconsultation;
            cr.ShowDialog();
            cr.Close();
        }
        
        public void ModifierRenseignement(DataGridView dgv)
        {
            if (dgv.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Renseignement set libelle= @libelle where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", dgv.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@libelle", dgv.CurrentRow.Cells[1].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerRenseignement(DataGridView dgv)
        {
            if (dgv.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Renseignement where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", dgv.CurrentRow.Cells[0].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv.Rows.RemoveAt(dgv.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public void ModifierPrescription(FormConsulterPresc exa)
        {
            if (exa.dgvPresc.CurrentRow.Cells[2].Value.ToString() != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Prescription SET libelle = @libelle, observation= @resultat WHERE idprescription = " + exa.dgvPresc.CurrentRow.Cells[0].Value.ToString() + "", con);
                    cmd.Parameters.AddWithValue("@libelle", exa.dgvPresc.CurrentRow.Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@resultat", exa.dgvPresc.CurrentRow.Cells[2].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Mise à jour réussie", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exa.btnEnregistrer.Enabled = false;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune valeur n'est fournie", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerPrescription(FormConsulterPresc exa)
        {
            if (exa.dgvPresc.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("DELETE FROM Prescription WHERE idprescription = " + exa.dgvPresc.CurrentRow.Cells[0].Value.ToString() + "", con);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    exa.btnSupprimer.Enabled = false;
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                exa.dgvPresc.Rows.RemoveAt(exa.dgvPresc.CurrentRow.Index);
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public void ModifierMaladieDiagnostic(FormConsulter c)
        {
            if (c.dgvDiagnostic.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update MaladieConsultation set observation = @observation where idmaladie = @idmaladie and idconsultation = @idconsultation", con);
                    cmd.Parameters.AddWithValue("@idmaladie", c.dgvDiagnostic.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Parameters.AddWithValue("@observation", c.dgvDiagnostic.CurrentRow.Cells[2].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerMaladieDiagnostic(FormConsulter c)
        {
            if (c.dgvDiagnostic.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from MaladieConsultation where idmaladie = @idmaladie and idconsultation = @idconsultation", con);
                    cmd.Parameters.AddWithValue("@idmaladie", c.dgvDiagnostic.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.dgvDiagnostic.Rows.RemoveAt(c.dgvDiagnostic.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierPrescription(FormConsulter c)
        {
            if (c.dgvPresc.RowCount > 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update PrescriptionProduit set quantite = @quantite, posologie = @posologie where idstock = @idstock and idconsultation = @idconsultation", con);
                    cmd.Parameters.AddWithValue("@idstock", c.dgvPresc.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Parameters.AddWithValue("@quantite", c.dgvPresc.CurrentRow.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@posologie", c.dgvPresc.CurrentRow.Cells[3].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Aucune ligne de prescription n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void SupprimerPrescription(FormConsulter c)
        {
            if (c.dgvPresc.RowCount > 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from PrescriptionProduit where idstock = @idstock and idconsultation = @idconsultation", con);
                    cmd.Parameters.AddWithValue("@idstock", c.dgvPresc.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    c.dgvPresc.Rows.RemoveAt(c.dgvPresc.CurrentRow.Index);
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
                MessageBox.Show("Aucune ligne de prescription n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ImprimerDossier(FormConsultationDossier d, FormImpression imp)
        {
            if (d.dgvDetail.RowCount != 0)
            {
                imp.idconsultation = d.idconsultation;
                imp.patient = d.patient;
                imp.idmedecin = d.idmedecin;
                imp.medecin = d.medecin;
                imp.numfiche = string.Format("{0}-{1}-{2}", DateConsultation(imp.idconsultation), imp.idconsultation, imp.idmedecin);
                imp.Text = "SSM - Dossier patient";

                List<DossierPatient> list = new List<DossierPatient>();
                list.Clear();

                for (int i = 0; i < d.dgvDetail.RowCount; i++)
                {
                    DossierPatient ag = new DossierPatient
                    {
                        id = d.dgvDetail.Rows[i].Cells[0].Value.ToString(),
                        libelle = d.dgvDetail.Rows[i].Cells[2].Value.ToString(),
                    };
                    list.Add(ag);
                }

                ReportParameter[] rparams = new ReportParameter[]
                {
                new ReportParameter("numfiche", imp.numfiche),
                new ReportParameter("patient", imp.patient),
                new ReportParameter("medecin", imp.medecin)
                };
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.DossierPatient.rdlc";
                imp.reportViewer1.LocalReport.SetParameters(rparams);
                imp.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ImprimerOrdonnance(FormConsulter c, FormImpression imp)
        {
            if(c.dgvPresc.RowCount!=0)
            {
                imp.idconsultation = c.idconsultation;
                imp.patient = c.dgvPatient.Rows[0].Cells[1].Value.ToString();
                imp.idmedecin = c.idmedecin;
                imp.age = c.dgvPatient.Rows[2].Cells[1].Value.ToString();
                imp.sexe = c.dgvPatient.Rows[1].Cells[1].Value.ToString();
                imp.medecin = TrouverNom("medecin", imp.idmedecin);
                imp.Text = "SSM - Ordonnance médicale";

                List<Ordonnance> list = new List<Ordonnance>();
                list.Clear();

                for (int i = 0; i < c.dgvPresc.RowCount; i++)
                {
                    Ordonnance ord = new Ordonnance
                    {
                        id = i + 1,
                        produit = c.dgvPresc.Rows[i].Cells[1].Value.ToString(),
                        quantite = c.dgvPresc.Rows[i].Cells[2].Value.ToString(),
                        posologie = c.dgvPresc.Rows[i].Cells[3].Value.ToString(),
                    };
                    list.Add(ord);
                }

                ReportParameter[] rparams = new ReportParameter[]
                {
                    new ReportParameter("nompatient", imp.patient),
                    new ReportParameter("medecin", imp.medecin),
                    new ReportParameter("age", imp.age),
                    new ReportParameter("sexe", imp.sexe)
                };
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonOrdonnance.rdlc";
                imp.reportViewer1.LocalReport.SetParameters(rparams);
                imp.MaximumSize = imp.Size;
                imp.MaximizeBox = false;
                imp.MinimizeBox = false;
                imp.ShowDialog();
            }
        }
        #endregion

        #region RENDEZ-VOUS
        private void TrouverRDVMedecin(FormConsultationStat s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idrendezvous, date_rendezvous, heure, observation from Rendezvous, Consultation, PriseSigneVitaux where Rendezvous.idconsultation = Consultation.idconsultation and Consultation.idprise = PriseSigneVitaux.idprise and idmedecin = '"+s.idmedecin+"'", con);
                dr = cmd.ExecuteReader();
                s.dgvRdv.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvRdv.Rows.Add();
                    s.dgvRdv.Rows[s.dgvRdv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvRdv.Rows[s.dgvRdv.RowCount - 1].Cells[1].Value = s.dgvRdv.RowCount;
                    s.dgvRdv.Rows[s.dgvRdv.RowCount - 1].Cells[2].Value = dr[1].ToString().Substring(0, 10);
                    s.dgvRdv.Rows[s.dgvRdv.RowCount - 1].Cells[3].Value = dr[2].ToString().Substring(0, 5);
                    s.dgvRdv.Rows[s.dgvRdv.RowCount - 1].Cells[4].Value = dr[3].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ResumeCas(FormConsultationStat s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idservice, nomservice FROM Service WHERE nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence')", con);
                dr = cmd.ExecuteReader();
                s.dgvResume.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvResume.Rows.Add();
                    s.dgvResume.Rows[s.dgvResume.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvResume.Rows[s.dgvResume.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvResume.Rows[s.dgvResume.RowCount - 1].Cells[2].Value = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if(s.dgvResume.RowCount !=0)
            {
                for (int i = 0; i < s.dgvResume.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("SELECT COUNT(c.idconsultation) FROM Consultation c JOIN PriseSigneVitaux psv ON c.idprise = psv.idprise JOIN Recette_ r ON psv.idrecette = r.idrecette WHERE idmedecin = '" + s.idmedecin + "' AND r.libelle LIKE '" + s.dgvResume.Rows[i].Cells[1].Value.ToString() + "%' AND c.date_consultation BETWEEN '"+s.dtpDateDe.Text+"' AND '"+s.dtpDateA.Text+"'", con);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            s.dgvResume.Rows[i].Cells[2].Value = dr[0].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                TrouverRDVMedecin(s);
            }
        }
        public void AjouterOBsRDV(FormConsultationStat s)
        {
            s.btnEnregistrer.Enabled = false;
            if (s.dgvRdv.CurrentRow.Cells[4].Value.ToString().ToUpper() != "RAS" && s.dgvRdv.CurrentRow.Cells[4].Value.ToString() != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Rendezvous set observation = @obs where idrendezvous = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.dgvRdv.CurrentRow.Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@obs", s.dgvRdv.CurrentRow.Cells[4].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Ajouté avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void Afficher(FormConsulterRendezVous r)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idrendezvous, date_rendezvous, heure from Rendezvous where idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", r.idconsultation);
                dr = cmd.ExecuteReader();
                r.dgvRdv.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvRdv.Rows.Add();
                    r.dgvRdv.Rows[r.dgvRdv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgvRdv.Rows[r.dgvRdv.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    r.dgvRdv.Rows[r.dgvRdv.RowCount - 1].Cells[2].Value = dr[2].ToString().Substring(0, 5);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherRDVConsultation(int idconsultation, FormConsulterRendezVous r)
        {
            r.idconsultation = idconsultation;
            Afficher(r);
            r.ShowDialog();
        }
        public void Enregistrer(FormConsulterRendezVous c)
        {
            if (c.cboHeure.Text != "" && c.cboMinute.Text != "")
            {
                c.idrdv = NouveauID("rdv");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Rendezvous values (@id, @daterdv, @heure, @idconsultation, @obs)", con);
                    cmd.Parameters.AddWithValue("@id", c.idrdv);
                    cmd.Parameters.AddWithValue("@daterdv", c.dtpDaterdv.Text);
                    cmd.Parameters.AddWithValue("@heure", string.Format("{0}:{1}", c.cboHeure.Text, c.cboMinute.Text));
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                    cmd.Parameters.AddWithValue("@obs", "RAS");
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
                Afficher(c);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormConsulterRendezVous c)
        {
            if (c.cboHeure.Text != "" && c.cboMinute.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Rendezvous set date_rendezvous = @daterdv, heure = @heure where idrendezvous = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idrdv);
                    cmd.Parameters.AddWithValue("@daterdv", c.dtpDaterdv.Text);
                    cmd.Parameters.AddWithValue("@heure", string.Format("{0}:{1}", c.cboHeure.Text, c.cboMinute.Text));
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
                Afficher(c);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        public void Supprimer(FormConsulterRendezVous c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("delete from Rendezvous where idrendezvous = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idrdv);
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
            Afficher(c);
        }
        #endregion

        ClassCompta cc = new ClassCompta();
        ClassStock cs = new ClassStock();

        #region PATIENT
        public void AgePatient(FormPatient p)
        {
            if (p.txtAnnee.Text.Length == 4)
            {
                if (int.Parse(p.txtAnnee.Text) > DateTime.Now.Year)
                {
                    MessageBox.Show("L'année de naissance doit être inférieure ou égale à l'année en cours", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    p.txtAnnee.Text = p.txtAnnee.Text.Substring(0, p.txtAnnee.Text.Length - 1);
                    p.btnAnnuler.Select();
                }
                else if (int.Parse(p.txtAnnee.Text) == DateTime.Now.Year)
                {
                    if (int.Parse(p.txtMois.Text) > DateTime.Now.Month)
                    {
                        MessageBox.Show("Le mois de naissance doit être inférieur ou égal au mois en cours", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        p.txtMois.Text = p.txtMois.Text.Substring(0, p.txtMois.Text.Length - 1);
                        p.btnAnnuler.Select();
                    }
                    else if (int.Parse(p.txtMois.Text) == DateTime.Now.Month)
                    {
                        p.lblAge.Text = "< 1 mois";
                    }
                    else
                        p.lblAge.Text = string.Format("{0} mois", DateTime.Now.Month - int.Parse(p.txtMois.Text));
                }
                else
                {
                    if (DateTime.Now.Month < int.Parse(p.txtMois.Text))
                    {
                        if (((DateTime.Now.Year - int.Parse(p.txtAnnee.Text)) - 1) > 0)
                            p.lblAge.Text = string.Format("{0} an(s) et {1} mois", ((DateTime.Now.Year - int.Parse(p.txtAnnee.Text)) - 1), (12 - Math.Abs(DateTime.Now.Month - int.Parse(p.txtMois.Text))));
                        else
                            p.lblAge.Text = string.Format("{0} mois", (12 - Math.Abs(DateTime.Now.Month - int.Parse(p.txtMois.Text))));
                    }
                    else if (DateTime.Now.Month == int.Parse(p.txtMois.Text))
                    {
                        p.lblAge.Text = string.Format("{0} an(s)", (DateTime.Now.Year - int.Parse(p.txtAnnee.Text)));
                    }
                    else
                    {
                        p.lblAge.Text = string.Format("{0} an(s) et {1} mois", ((DateTime.Now.Year - int.Parse(p.txtAnnee.Text))), (DateTime.Now.Month - int.Parse(p.txtMois.Text)));
                    }
                }
            }
        }
        public void ChargerCombo(ComboBox combo, string motif)
        {
            switch (motif)
	        {
                case "médecin": cmd = new SqlCommand("select nommedecin from Medecin", con); break;
                case "typepatient": cmd = new SqlCommand("select nomtype from TypePatient", con); break;
                case "autorisation": cmd = new SqlCommand("select libelle from Autorisations", con); break;
                case "pharmacie": cmd = new SqlCommand("select designation from Pharmacie", con); break;
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
        public int NbConsultationPatient(int idpatient)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idconsultation) from Consultation, PriseSigneVitaux, Patient where Consultation.idprise = PriseSigneVitaux.idprise and PriseSigneVitaux.idpatient = Patient.idpatient and Patient.idpatient = @idpatient", con);
                cmd.Parameters.AddWithValue("@idpatient", idpatient);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void EnregistrerPatient(FormPatient p)
        {            
            if (p.cboTypePatient.Text != "" && p.cboTypeFacture.Text != "" && p.txtNom.Text != "" && p.cboSexe.Text != "" && p.txtAnnee.Text != "" && p.txtAdresse.Text != "" && p.service != "")
            {
                p.idpatient = NouveauID("patient");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (p.txtTel.Text == "") p.txtTel.Text = "243";
                    if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "RAS";
                    if (p.txtTelContact.Text == "") p.txtTelContact.Text = "243";
                    //Si le patient est abonné
                    if (p.cboTypePatient.Text.Contains("abonné"))
                    {
                        cmd = new SqlCommand("insert into Patient values (@id, @nom, @sexe, @age, @adresse, @situation, @tel, @contact, @telcontact, @idtype, @idtypeabonne, @identreprise, @num_service)", con);
                        cmd.Parameters.AddWithValue("@idtypeabonne", p.idtypeabonne);
                        cmd.Parameters.AddWithValue("@identreprise", p.identreprise);
                        cmd.Parameters.AddWithValue("@num_service", p.txtNumService.Text);
                    }
                    else //Si le patient n'est pas abonné
                    {
                        cmd = new SqlCommand("insert into Patient (idpatient, noms, sexe, age, adresse, situation, telephone, pers_contact, tel_contact, idtype) values (@id, @nom, @sexe, @age, @adresse, @situation, @tel, @contact, @telcontact, @idtype)", con);             
                    }
                    cmd.Parameters.AddWithValue("@id", p.idpatient);
                    cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                    cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                    cmd.Parameters.AddWithValue("@age", p.lblAge.Text);
                    cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                    cmd.Parameters.AddWithValue("@situation", p.zonesante);
                    cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                    cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                    cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                    cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
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
                //Recette
                p.type_patient = p.cboTypePatient.Text;
                AjouterRecetteCas(p);               
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AjouterRecetteCas(FormPatient p)
        {
            //Ajoute la recette
            cc.AjouterRecette(p.cboTypeFacture.Text, p.lblDate.Text, "706101", p.service, 1, cc.PrixService(cc.TrouverId("service", p.service)), "service", p.idpatient);

            ////Ecriture comptable              
            if (p.cboTypeFacture.Text == "différé")
            {
                if (p.type_patient.Contains("abonné"))
                    p.numcomptediffere = TrouverNom("numcompte_entreprise", p.identreprise);
                else if (p.type_patient == "employé")
                    p.numcomptediffere = cc.TrouverId("numcompte", "Médecine du travail et pharmacie").ToString();
                else if (p.type_patient == "cas social")
                    p.numcomptediffere = cc.TrouverId("numcompte", "Frais médicaux & Pharmaceutiques Cas sociaux").ToString();
                else if (p.type_patient == "payant")
                    p.numcomptediffere = "4711";

                p.idoperation = cc.AjouterOperation(p.lblDate.Text, "FAC_DIFF", cc.TrouverId("typejournal", "ventes"), p.idexercice);
                p.numcompte = cc.TrouverNom("numcompte_service", cc.TrouverId("service", p.service));
                cc.AjouterEcriture(p.idoperation, p.numcomptediffere, p.numcompte, cc.PrixService(cc.TrouverId("service", p.service)), cc.PrixService(cc.TrouverId("service", p.service)), "Vente - service à crédit");

            }
            Annuler(p);
        }
        public void Modifier(FormPatient p)
        {
            if (p.cboTypePatient.Text != "" && p.txtNom.Text != "" && p.cboSexe.Text != "" && p.txtAnnee.Text != "" && p.txtMois.Text != "" && p.txtAdresse.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (p.txtTel.Text == "") p.txtTel.Text = "RAS";
                    if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "RAS";
                    if (p.txtTelContact.Text == "") p.txtTelContact.Text = "RAS";

                    if (p.cboTypePatient.Text.Contains("abonné"))
                    {
                        cmd = new SqlCommand("UPDATE Patient set noms= @nom, sexe= @sexe, age= @age, adresse= @adresse, situation= @situation, telephone= @tel, pers_contact= @contact, tel_contact= @telcontact, idtype= @idtype, idtypeabonne = @idtypeabonne, identreprise = @identreprise, num_service = @num_service  where idpatient= @id", con);
                        cmd.Parameters.AddWithValue("@idtypeabonne", p.idtypeabonne);
                        cmd.Parameters.AddWithValue("@identreprise", p.identreprise);
                        cmd.Parameters.AddWithValue("@num_service", p.txtNumService.Text);
                    }
                    else
                    {
                        cmd = new SqlCommand("UPDATE Patient set noms= @nom, sexe= @sexe, age= @age, adresse= @adresse, situation= @situation, telephone= @tel, pers_contact= @contact, tel_contact= @telcontact, idtype= @idtype  where idpatient= @id", con);                        
                    }
                    cmd.Parameters.AddWithValue("@id", p.idpatient);
                    cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                    cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                    cmd.Parameters.AddWithValue("@age", p.lblAge.Text);
                    cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                    cmd.Parameters.AddWithValue("@situation", p.zonesante);
                    cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                    cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                    cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                    cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    //p.btnModifier.Enabled = false;
                    MessageBox.Show("Modifié avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(p);
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
        private int NbRecettePatient(int idpatient)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT COUNT(idrecette) FROM Recette_ WHERE idpatient = @id", con);
                cmd.Parameters.AddWithValue("@id", idpatient);
                dr = cmd.ExecuteReader();
                if(dr.Read())
                    id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return id;
        }
        public void Supprimer(FormPatientRecherche p)
        {
            if (NbRecettePatient(p.idpatient) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Patient where idpatient = @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idpatient);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p.dgv.Rows.RemoveAt(p.dgv.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
            else
                MessageBox.Show("Ce patient est déjà impliqué dans les opérations,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public void AfficherPatient(FormPatientRecherche p)
        {
            if (p.txtRecherche.Text != "")
            {
                try
                {
                    if (!p.poste.Contains("abonné"))
                    {
                        con.Open();
                        cmdtxt = @"SELECT idpatient, noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype 
                        FROM Patient p
                        JOIN TypePatient tp ON p.idtype = tp.idtype
                        WHERE nomtype IN ('payant', 'cas social') AND noms like '" + p.txtRecherche.Text + "%'";
                        cmd = new SqlCommand(cmdtxt, con);
                        dr = cmd.ExecuteReader();
                        p.dgv.Rows.Clear();
                        while (dr.Read())
                        {
                            p.dgv.Rows.Add();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[6].Value = dr[6].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                        }
                        con.Close();
                    }
                    else
                    {
                        con.Open();
                        cmdtxt = @"SELECT idpatient, noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype,idtypeabonne,identreprise,num_service 
                        FROM Patient p
                        JOIN TypePatient tp ON p.idtype = tp.idtype
                        WHERE nomtype NOT IN ('payant', 'cas social') AND noms like '" + p.txtRecherche.Text + "%'";
                        cmd = new SqlCommand(cmdtxt, con);
                        dr = cmd.ExecuteReader();
                        p.dgv.Rows.Clear();
                        while (dr.Read())
                        {
                            p.dgv.Rows.Add();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[6].Value = dr[6].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[10].Value = dr[10].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[11].Value = dr[11].ToString();
                            p.dgv.Rows[p.dgv.RowCount - 1].Cells[12].Value = dr[12].ToString(); 

                        }
                        con.Close();
                        if(p.dgv.RowCount != 0)
                        {
                            for (int i = 0; i < p.dgv.RowCount; i++)
                            {
                                if (p.dgv.Rows[i].Cells[9].Value.ToString().Contains("abonné"))
                                {
                                    p.dgv.Rows[i].Cells[10].Value = TrouverNom("typeabonne", Convert.ToInt32(p.dgv.Rows[i].Cells[10].Value));
                                    p.dgv.Rows[i].Cells[11].Value = TrouverNom("entreprise", Convert.ToInt32(p.dgv.Rows[i].Cells[11].Value));
                                }
                            }                           
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Aucun nom de patient n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Recuperer(FormPatientRecherche r, FormPatient p)
        {
            if(r.dgv.RowCount !=0)
            {
                p.idpatient = r.idpatient;
                p.txtNom.Text = r.dgv.CurrentRow.Cells[1].Value.ToString();
                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboSexe.Text = r.dgv.CurrentRow.Cells[2].Value.ToString();
                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;

                p.txtAdresse.Text = r.dgv.CurrentRow.Cells[4].Value.ToString();
                p.txtTel.Text = r.dgv.CurrentRow.Cells[6].Value.ToString();
                p.txtPersonContact.Text = r.dgv.CurrentRow.Cells[7].Value.ToString();
                p.txtTelContact.Text = r.dgv.CurrentRow.Cells[8].Value.ToString();
                p.btnModifier.Enabled = true;
                p.btnEnregistrer.Enabled = false;
                p.poste = r.poste;
                p.cboTypePatient.Select();
                p.groupBox1.Enabled = false;
                p.ShowDialog();
                AfficherPatient(r);
            }
        }
        public void Annuler(FormPatient p)
        {
            p.cboTypePatient.Items.Clear();
            p.txtNom.Text = "";
            p.txtMois.Text = "";
            p.txtAnnee.Text = "";
            p.txtAdresse.Text = "";
            p.txtTel.Text = "";
            p.txtPersonContact.Text = "";
            p.txtTelContact.Text = "";
            p.btnAffecter.Enabled = false;
            p.lblAge.Text = "Age :";
        }
        #endregion

        #region AGENDA_NURSING
        public void ChargerAgenda(FormAgendaNursing a, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (a.checkBox2.Checked)
                    {
                        if (a.txtNom.Text == "")
                        {
                            cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient 
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            JOIN TypePatient tp ON p.idtype = tp.idtype 
                            WHERE statut_caisse = 'OK' AND nomtype LIKE 'abonné%' AND numcompte = '706101' 
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                            cmd = new SqlCommand(cmdtxt, con);
                        }
                        else
                        {
                            cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            JOIN TypePatient tp ON p.idtype = tp.idtype 
                            WHERE statut_caisse = 'OK' AND nomtype LIKE 'abonné%' AND numcompte = '706101'
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') 
                            AND date_operation BETWEEN @dateDe AND @dateA 
                            AND noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'";
                            cmd = new SqlCommand(cmdtxt, con);
                        }
                    }
                    else
                    {
                        if (a.txtNom.Text == "")
                        {
                            cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient 
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            WHERE statut_caisse = 'OK' AND numcompte = '706101'
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                            cmd = new SqlCommand(cmdtxt, con);
                        }
                        else
                        {
                            cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient 
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            WHERE statut_caisse = 'OK' AND numcompte = '706101'
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') 
                            AND date_operation BETWEEN @dateDe AND @dateA 
                            AND noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'";
                            cmd = new SqlCommand(cmdtxt, con);
                        }
                    }
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                }
                else
                {
                    if (a.checkBox2.Checked)
                    {
                        cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient 
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            JOIN TypePatient tp ON p.idtype = tp.idtype 
                            WHERE statut_caisse = 'OK' AND nomtype LIKE 'abonné%' AND numcompte = '706101'
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') 
                            AND date_operation = '" + DateTime.Now.ToShortDateString() + "'";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    else
                    {
                        cmdtxt = @"SELECT idrecette, date_operation, noms, libelle,r.idpatient 
                            FROM Recette_ r
                            JOIN Patient p ON r.idpatient = p.idpatient
                            WHERE statut_caisse = 'OK' AND numcompte = '706101' 
                            AND libelle IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence')
                            AND date_operation = '" + DateTime.Now.ToShortDateString() + "'";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                }
                dr = cmd.ExecuteReader();
                a.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAgenda.Rows.Add();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[4].Value = "";
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[5].Value = "";
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[6].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();

            if(a.dgvAgenda.RowCount != 0)
            {
                for (int i = 0; i < a.dgvAgenda.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmdtxt = @"SELECT nommedecin, idprise 
                        FROM PriseSigneVitaux p
                        JOIN Medecin m ON p.idmedecin = m.idmedecin
                        WHERE idrecette = @idrecette";
                        cmd = new SqlCommand(cmdtxt, con);
                        cmd.Parameters.AddWithValue("@idrecette", Convert.ToInt32(a.dgvAgenda.Rows[i].Cells[0].Value));
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            a.dgvAgenda.Rows[i].Cells[4].Value = dr[0].ToString();
                            a.dgvAgenda.Rows[i].Cells[5].Value = dr[1].ToString();
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
        public void AjouterPrise(FormPriseSigneVital p)
        {
            p.btnEnregistrer.Enabled = false;
            if (p.cboMedecin.Text != "" && p.dgvSigne.Rows[p.dgvSigne.RowCount - 1].Cells[2].Value.ToString() != "")
            {
                if(p.reaffecter)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("UPDATE PriseSigneVitaux SET date_prise = @date_prise, idmedecin = @idmedecin WHERE idprise = @idprise", con);
                        cmd.Parameters.AddWithValue("@idprise", p.idprise);
                        cmd.Parameters.AddWithValue("@idmedecin", p.idmedecin);
                        cmd.Parameters.AddWithValue("@date_prise", p.dtpDateDe.Text);
                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Cas réaffecté avec succès", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();

                    //Mise à jour des valeurs
                    for (int i = 0; i < p.dgvSigne.RowCount; i++)
                    {
                        con.Open();
                        tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("UPDATE ValeurSigneVitaux SET valeur = @valeur WHERE idprise = @idprise AND idsigne = @idsigne", con);
                            cmd.Parameters.AddWithValue("@idprise", p.idprise);
                            cmd.Parameters.AddWithValue("@idsigne", p.dgvSigne.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@valeur", p.dgvSigne.Rows[i].Cells[2].Value.ToString());
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
                else
                {
                    p.idprise = NouveauID("prise");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("INSERT INTO PriseSigneVitaux VALUES (@idprise, @date_prise, @idpatient, @idmedecin, @idrecette)", con);
                        cmd.Parameters.AddWithValue("@idprise", p.idprise);
                        cmd.Parameters.AddWithValue("@date_prise", p.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@idpatient", p.idpatient);
                        cmd.Parameters.AddWithValue("@idmedecin", p.idmedecin);
                        cmd.Parameters.AddWithValue("@idrecette", p.idrecette);

                        cmd.Transaction = tx;
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                        MessageBox.Show("Cas affecté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();

                    //Ajout des valeurs
                    for (int i = 0; i < p.dgvSigne.RowCount; i++)
                    {
                        con.Open();
                        tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("INSERT INTO ValeurSigneVitaux VALUES (@idprise, @idsigne, @valeur)", con);
                            cmd.Parameters.AddWithValue("@idprise", p.idprise);
                            cmd.Parameters.AddWithValue("@idsigne", p.dgvSigne.Rows[i].Cells[0].Value.ToString());
                            cmd.Parameters.AddWithValue("@valeur", p.dgvSigne.Rows[i].Cells[2].Value.ToString());
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
                
                //valider fermeture
                p.fermeture_succes = true;
                p.Hide();

            }
            else
            {
                MessageBox.Show("Au moins une valeur manque", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void CompterCasMedecin(FormPriseSigneVital p)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT idmedecin, nommedecin FROM Medecin", con);
                dr = cmd.ExecuteReader();
                p.dgvMedecin.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvMedecin.Rows.Add();
                    p.dgvMedecin.Rows[p.dgvMedecin.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvMedecin.Rows[p.dgvMedecin.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();

            if (p.dgvMedecin.RowCount != 0)
            {
                for (int i = 0; i < p.dgvMedecin.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("SELECT COUNT(idprise) FROM PriseSigneVitaux WHERE date_prise = '" + DateTime.Now.ToShortDateString() + "' AND idmedecin = '" + p.dgvMedecin.Rows[i].Cells[0].Value.ToString() + "'", con);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            p.dgvMedecin.Rows[i].Cells[2].Value = dr[0].ToString();
                        }
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public void AffecterCas(FormAgendaNursing a, FormPriseSigneVital p)
        {
            a.btnAffecter.Enabled = false;
            if(a.dgvAgenda.CurrentRow.Cells[4].Value.ToString() == "")
            {
                p.idrecette = Convert.ToInt32(a.dgvAgenda.CurrentRow.Cells[0].Value);
                p.txtPatient.Text = a.dgvAgenda.CurrentRow.Cells[2].Value.ToString();
                p.idpatient = a.idpatient;
                CompterCasMedecin(p);
                p.reaffecter = false;
                p.ShowDialog();
                if (p.fermeture_succes)
                {
                    a.dgvAgenda.CurrentRow.Cells[4].Value = p.cboMedecin.Text;
                    a.dgvAgenda.CurrentRow.Cells[5].Value = p.idprise;
                }
                p.Close();
            }
            else
            {
                MessageBox.Show("Ce cas est déjà effecté au médecin " + a.dgvAgenda.CurrentRow.Cells[4].Value.ToString(), "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ReaffecterCas(FormAgendaNursing a, FormPriseSigneVital p)
        {
            a.btnReaffecter.Enabled = false;
            if (a.dgvAgenda.CurrentRow.Cells[4].Value.ToString() != "")
            {
                p.txtPatient.Text = a.dgvAgenda.CurrentRow.Cells[2].Value.ToString();
                p.idrecette = Convert.ToInt32(a.dgvAgenda.CurrentRow.Cells[0].Value);
                p.idprise = Convert.ToInt32(a.dgvAgenda.CurrentRow.Cells[5].Value);
                p.idpatient = a.idpatient;
                CompterCasMedecin(p);
                p.reaffecter = true;

                //Charger les valeurs signes vitaux
                ValeurSigneVitaux(p.dgvSigne, p.idprise);

                p.ShowDialog();
                if (p.fermeture_succes)
                {
                    a.dgvAgenda.CurrentRow.Cells[4].Value = p.cboMedecin.Text;
                    a.dgvAgenda.CurrentRow.Cells[5].Value = p.idprise;
                }
                p.Close();
            }
            else
            {
                MessageBox.Show("Ce cas n'est pas encore effecté à un médecin. Affectez-le" , "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region AGENDA_IMAGERIE
        public void AfficherSousForm(MFormEchoRadio ec, FormAgendaEcho childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ec.pnlChildForm.Controls.Add(childForm);
            ec.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = ec.idutilisateur;
            childForm.Show();
        }
        public void AfficherSousForm(MFormEchoRadio ec, FormAgendaLaboResult childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            ec.pnlChildForm.Controls.Add(childForm);
            ec.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = ec.idutilisateur;
            childForm.poste = "echo";
            childForm.btnValider.Enabled = false;
            childForm.Show();
        }
        public void AfficherAgendaEcho(FormAgendaEcho a, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (a.cboService.Text == "")
                    {
                        if (a.txtNom.Text != "")
                            cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte IN ('706110', '706111') AND statut_caisse = 'OK' AND date_operation BETWEEN '" + a.dtpDateDe.Text + "' AND '" + a.dtpDateA.Text + "' AND noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'", con);
                        else
                            cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte IN ('706110', '706111') AND statut_caisse = 'OK' AND date_operation BETWEEN '" + a.dtpDateDe.Text + "' AND '" + a.dtpDateA.Text + "'", con);
                    }
                    else
                    {
                        if (a.txtNom.Text != "")
                            cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte = '" + a.numcompte + "' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + a.dtpDateDe.Text + "' AND '" + a.dtpDateA.Text + "' AND noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'", con);
                        else
                            cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte = '" + a.numcompte + "' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + a.dtpDateDe.Text + "' AND '" + a.dtpDateA.Text + "'", con);
                    }
                }
                else
                    cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte IN ('706110', '706111') AND statut_caisse = 'OK' AND date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                dr = cmd.ExecuteReader();
                a.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvPatient.Rows.Add();
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void TrouverRecettePatient(DataGridView dgv, int idpatient, DateTimePicker dtpDe, DateTimePicker dtpA, string motif)
        {
            if(motif=="labo")
                cmd = new SqlCommand("SELECT idrecette, date_operation, libelle, statut_caisse, servi  FROM Recette_ WHERE numcompte = '706112' AND idpatient = @idpatient AND date_operation BETWEEN @dateDe AND @dateA", con);
            else
                cmd = new SqlCommand("SELECT idrecette, date_operation, libelle, statut_caisse, servi  FROM Recette_ WHERE numcompte IN ('706110', '706111') AND idpatient = @idpatient AND date_operation BETWEEN @dateDe AND @dateA", con);
            cmd.Parameters.AddWithValue("@idpatient", idpatient);
            cmd.Parameters.AddWithValue("@dateDe", dtpDe.Text);
            cmd.Parameters.AddWithValue("@dateA", dtpA.Text);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ServirEchoRadio(FormAgendaEcho a, FormAgendaLaboRslt r)
        {
            a.btnServir.Enabled = false;
            r.txtPatient.Text = a.dgvPatient.CurrentRow.Cells[1].Value.ToString();
            r.idrecette = Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value);
            r.txtExamen.Text = a.dgvRecette.CurrentRow.Cells[2].Value.ToString();
            r.txtResultat.Focus();
            r.ShowDialog();
            if (r.fermeture_succes)
            {
                cc.RecetteServiOK(Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value), a.idutilisateur, "OK");
                //Recharger les services
                TrouverRecettePatient(a.dgvRecette, Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[0].Value), a.dtpDateDe, a.dtpDateA, "echo");
            }
            r.Close();
        }
        public void AnnulerCasEchoRadio(FormAgendaEcho a)
        {
            a.btnAnnuler.Enabled = false;
            cc.RecetteServiOK(Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value), a.idutilisateur, "");
            //Recharger les services
            TrouverRecettePatient(a.dgvRecette, Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[0].Value), a.dtpDateDe, a.dtpDateA, "echo");
        }
        #endregion

        #region LABORATOIRE
        public void AfficherSousForm(MFormLabo l, FormAgendaLabo childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            l.pnlChildForm.Controls.Add(childForm);
            l.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = l.idutilisateur;
            childForm.Show();
        }
        public void AfficherSousForm(MFormLabo l, FormAgendaLaboResult childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            l.pnlChildForm.Controls.Add(childForm);
            l.pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.idutilisateur = l.idutilisateur;
            childForm.poste = "labo";
            childForm.btnValider.Enabled = false;
            childForm.Show();
        }
        public void AfficherAgendaLabo(FormAgendaLabo l, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (l.txtNom.Text != "")
                        cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte = '706112' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + l.dtpDateDe.Text + "' AND '" + l.dtpDateA.Text + "' AND noms LIKE '" + l.txtNom.Text.Replace("'", "") + "%'", con);
                    else
                        cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte = '706112' AND statut_caisse = 'OK' AND date_operation BETWEEN '" + l.dtpDateDe.Text + "' AND '" + l.dtpDateA.Text + "'", con);
                }
                else
                    cmd = new SqlCommand("SELECT DISTINCT p.idpatient, noms FROM Patient p JOIN Recette_ r ON r.idpatient = p.idpatient WHERE numcompte = '706112' AND statut_caisse = 'OK' AND date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                dr = cmd.ExecuteReader();
                l.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    l.dgvPatient.Rows.Add();
                    l.dgvPatient.Rows[l.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    l.dgvPatient.Rows[l.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ServirCasLabo(FormAgendaLabo a, FormAgendaLaboRslt r)
        {
            a.btnServir.Enabled = false;
            r.txtPatient.Text = a.dgvPatient.CurrentRow.Cells[1].Value.ToString();
            r.idrecette = Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value);
            r.txtExamen.Text = a.dgvRecette.CurrentRow.Cells[2].Value.ToString() ;
            r.txtResultat.Focus();
            r.ShowDialog();
            if(r.fermeture_succes)
            {
                cc.RecetteServiOK(Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value), a.idutilisateur, "OK");
                //Recharger les services
                TrouverRecettePatient(a.dgvRecette, Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[0].Value), a.dtpDateDe, a.dtpDateA, "labo");
            }
            r.Close();
        }
        public void AnnulerCasLabo(FormAgendaLabo a)
        {
            a.btnAnnuler.Enabled = false;
            cc.RecetteServiOK(Convert.ToInt32(a.dgvRecette.CurrentRow.Cells[0].Value), a.idutilisateur, "");
            //Recharger les services
            TrouverRecettePatient(a.dgvRecette, Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[0].Value), a.dtpDateDe, a.dtpDateA, "labo");
        }
        public void AfficherResultat(DataGridView dgv, string patient, DateTimePicker dtpDe, DateTimePicker dtpA, string motif)
        {
            if (motif == "labo")
            {
                if(patient == "")
                {
                    cmdtxt = @"SELECT id, date_jour, noms, libelle, resultat, observation 
                    FROM AgendaLabo a
                    JOIN Recette_ r ON r.idrecette = a.idrecette 
                    JOIN Patient p ON r.idpatient = p.idpatient
                    WHERE numcompte = 706112 AND date_jour BETWEEN @dateDe AND @dateA";
                }
                else
                {
                    cmdtxt = @"SELECT id, date_jour, noms, libelle, resultat, observation 
                    FROM AgendaLabo a
                    JOIN Recette_ r ON r.idrecette = a.idrecette 
                    JOIN Patient p ON r.idpatient = p.idpatient
                    WHERE numcompte = 706112 AND noms LIKE LIKE '" + patient.Replace("'", "") + "%' date_jour BETWEEN @dateDe AND @dateA";
                }
                cmd = new SqlCommand(cmdtxt, con);

            }
            else
            {
                if (patient == "")
                {
                    cmdtxt = @"SELECT id, date_jour, noms, libelle, resultat, observation 
                    FROM AgendaLabo a
                    JOIN Recette_ r ON r.idrecette = a.idrecette 
                    JOIN Patient p ON r.idpatient = p.idpatient
                    WHERE numcompte IN ('706110', '706111') AND date_jour BETWEEN @dateDe AND @dateA";
                }
                else
                {
                    cmdtxt = @"SELECT id, date_jour, noms, libelle, resultat, observation 
                    FROM AgendaLabo a
                    JOIN Recette_ r ON r.idrecette = a.idrecette 
                    JOIN Patient p ON r.idpatient = p.idpatient
                    WHERE numcompte IN ('706110', '706111') AND noms LIKE LIKE '" + patient.Replace("'", "") + "%' date_jour BETWEEN @dateDe AND @dateA";
                }
                cmd = new SqlCommand(cmdtxt, con);
            }
            cmd.Parameters.AddWithValue("@dateDe", dtpDe.Text);
            cmd.Parameters.AddWithValue("@dateA", dtpA.Text);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString().Substring(0, 10);
                    dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[4].Value = dr[4].ToString();
					dgv.Rows[dgv.RowCount - 1].Cells[5].Value = dr[5].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ModifierResultatLabo(FormAgendaLaboResult a, FormAgendaLaboRslt r)
        {
            r.txtPatient.Text = a.dgvResult.CurrentRow.Cells[2].Value.ToString();
            id = Convert.ToInt32(a.dgvResult.CurrentRow.Cells[0].Value);
            r.txtExamen.Text = a.dgvResult.CurrentRow.Cells[3].Value.ToString();
            r.txtResultat.Text = a.dgvResult.CurrentRow.Cells[4].Value.ToString();
            r.txtObs.Text = a.dgvResult.CurrentRow.Cells[5].Value.ToString();
            r.ShowDialog();
            if (r.fermeture_succes)
            {
                AfficherResultat(a.dgvResult, a.txtNom.Text, a.dtpDateDe, a.dtpDateA, a.poste);
            }
            r.Close();
        }
        public void Enregistrer(FormAgendaLaboRslt a)
        {
            if(a.txtResultat.Text != "" && a.txtObs.Text != "")
            {
                id = NouveauID("agendalabo");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("INSERT INTO AgendaLabo VALUES (@id, @date_jour, @idrecette, @resultat, @obs)", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date_jour", a.dtpDate_Jour.Text);
                    cmd.Parameters.AddWithValue("@idrecette", a.idrecette);
                    cmd.Parameters.AddWithValue("@resultat", a.txtResultat.Text);
                    cmd.Parameters.AddWithValue("@obs", a.txtObs.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                a.fermeture_succes = true;
                a.Hide();
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Modifier(FormAgendaLaboRslt a)
        {
            if (a.txtResultat.Text != "" && a.txtObs.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE AgendaLabo SET date_jour = @date_jour, resultat = @resultat, observation = @obs WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@date_jour", a.dtpDate_Jour.Text);
                    cmd.Parameters.AddWithValue("@resultat", a.txtResultat.Text);
                    cmd.Parameters.AddWithValue("@obs", a.txtObs.Text);
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
                a.fermeture_succes = true;
                a.Hide();
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        #endregion

        #region BON_EXAMEN
        
        ReportDataSource rs = new ReportDataSource();
        public string DateConsultation(int idconsultation)
        {
            chaine = "";
            con.Open();
            try
            {
                cmd = new SqlCommand("select date_consultation from Consultation where idconsultation= @id", con);
                cmd.Parameters.AddWithValue("@id", idconsultation);
                dr = cmd.ExecuteReader();
                dr.Read();
                chaine = dr[0].ToString();
            }
            catch (Exception ex){ MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            con.Close();
            return chaine.Substring(0, 10);
        }
        public void GenererBonExamen(FormConsulter c, FormImpression imp)
        {
            if (c.dgvLabo.RowCount != 0)
            {
                imp.idconsultation = c.idconsultation;
                imp.patient = c.dgvPatient.Rows[0].Cells[1].Value.ToString();
                imp.idmedecin = c.idmedecin;
                imp.age = c.dgvPatient.Rows[2].Cells[1].Value.ToString();
                imp.sexe = c.dgvPatient.Rows[1].Cells[1].Value.ToString();
                imp.medecin = TrouverNom("medecin", imp.idmedecin);
                imp.numfiche = string.Format("{0}-{1}-{2}", DateConsultation(imp.idconsultation), imp.idconsultation, imp.idmedecin);
                imp.Text = "SSM - Bon d'examens";

                List<BonExamen> list = new List<BonExamen>();
                list.Clear();

                for (int i = 0; i < c.dgvLabo.RowCount; i++)
                {
                    BonExamen be = new BonExamen
                    {
                        numexamen = c.dgvLabo.Rows[i].Cells[0].Value.ToString(),
                        examen = c.dgvLabo.Rows[i].Cells[2].Value.ToString(),
                    };
                    list.Add(be);
                }

                ReportParameter[] rparams = new ReportParameter[]
                {
                    new ReportParameter("numfiche", imp.numfiche),
                    new ReportParameter("patient", imp.patient),
                    new ReportParameter("medecin", imp.medecin),
                    new ReportParameter("age", imp.age),
                    new ReportParameter("sexe", imp.sexe)
                };
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonExamen.rdlc";
                imp.reportViewer1.LocalReport.SetParameters(rparams);
                imp.MaximumSize = imp.Size;
                imp.MaximizeBox = false;
                imp.MinimizeBox = false;
                imp.ShowDialog();
            }
        }
        public void AjouterResultatLabo(FormConsulter exa)
        {
            for (int i = 0; i < exa.dgvLabo.RowCount; i++)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update ResultatExamen set resultat = @resultat where idresultat= @idresult", con);
                    cmd.Parameters.AddWithValue("@idresult", exa.dgvLabo.Rows[i].Cells[0].Value.ToString());
                    cmd.Parameters.AddWithValue("@resultat", exa.dgvLabo.Rows[i].Cells[2].Value.ToString());
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
            MessageBox.Show("Résultats enregistrés avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void ChargerExamen(FormPriseSigneVital exa)
        {
            cmd = new SqlCommand("select idresultat, nomexamen, resultat from ResultatExamen where idconsultation= @id", con);
            cmd.Parameters.AddWithValue("@id", exa.idrecette);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    exa.dgvSigne.Rows.Add();
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            exa.dgvSigne.SelectionMode = DataGridViewSelectionMode.CellSelect;
            exa.dgvSigne.Columns[2].Visible = true;
        }
        public void ExamenPhysique(FormPriseSigneVital exa, FormFacture exp)
        {
            exp.fermeture_succes = false;
            exp.dgv.Rows.Add();
            exp.dgv.Rows[0].Cells[0].Value = exa.dgvSigne.RowCount + 1;
            exp.dgv.Rows[0].Cells[1].Value = "";
            exp.dgv.Rows[0].Cells[2].Value = "";
            exp.ShowDialog();
            if (exp.fermeture_succes)
            {
                exa.fermeture_succes = true;
                for (int i = 0; i < exa.dgvSigne.RowCount; i++)
                {
                    if (exa.dgvSigne.Rows[i].Cells[1].Value.ToString() == exp.dgv.Rows[0].Cells[1].Value.ToString())
                    {
                        MessageBox.Show("Cet examen est déjà affecté à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        i += exa.dgvSigne.RowCount;
                        exa.fermeture_succes = false;
                    }
                }
                if(exa.fermeture_succes)
                {
                    exa.dgvSigne.Rows.Add();
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[0].Value = exp.dgv.Rows[0].Cells[0].Value;
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[1].Value = exp.dgv.Rows[0].Cells[1].Value;
                    exa.dgvSigne.Rows[exa.dgvSigne.RowCount - 1].Cells[2].Value = "";
                }
            }
            exp.Close();
        }
        #endregion


        #region MALADIE_DIAGNOSTIC
        public void MaladieDiagnostic(FormPriseSigneVital exa, FormMaladieDiagnostic md)
        {
            md.idconsultation = exa.idrecette;
            md.ShowDialog();
        }
        public void Annuler(FormMaladie m)
        {
            m.txtLibelle.Text = "";
            m.btnModifier.Enabled = false;
            m.btnSupprimer.Enabled = false;
            m.btnEnregistrer.Enabled = true;
        }
        public void Afficher(FormMaladie m, string motif)
        {
            con.Open();
            try
            {
                if(motif =="recherche") cmd = new SqlCommand("select * from Maladie where nommaladie like '"+m.txtLibelle.Text+"%'", con);
                else cmd = new SqlCommand("select * from Maladie", con);
                
                dr = cmd.ExecuteReader();
                m.dgv.Rows.Clear();
                while(dr.Read())
                {
                    m.dgv.Rows.Add();
                    m.dgv.Rows[m.dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    m.dgv.Rows[m.dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
                Annuler(m);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void Afficher(FormMaladieDiagnostic md)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idmaladie, observation  from MaladieConsultation where idconsultation= @id", con);
                cmd.Parameters.AddWithValue("@id", md.idconsultation);
                dr = cmd.ExecuteReader();
                md.dgv1.Rows.Clear();
                while (dr.Read())
                {
                    md.dgv1.Rows.Add();
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[0].Value = md.dgv1.RowCount;
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[3].Value = dr[1].ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < md.dgv1.RowCount; i++)
            {
                md.dgv1.Rows[i].Cells[2].Value = TrouverNom("maladie", int.Parse(md.dgv1.Rows[i].Cells[1].Value.ToString()));
            }
        }
        public void Enregistrer(FormMaladie m)
        {
            if(m.txtLibelle.Text !="")
            {
                m.idmaladie = NouveauID("maladie");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Maladie values(@idmaladie, @maladie)", con);
                    cmd.Parameters.AddWithValue("@idmaladie", m.idmaladie);
                    cmd.Parameters.AddWithValue("@maladie", m.txtLibelle.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(m);
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
        public void Modifier(FormMaladie m)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Maladie set nommaladie= @maladie where idmaladie= @idmaladie", con);
                cmd.Parameters.AddWithValue("@idmaladie", m.idmaladie);
                cmd.Parameters.AddWithValue("@maladie", m.txtLibelle.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Annuler(m);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            Afficher(m, "");
        }
        public int CompterLigneMaladie(int idmaladie)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) from MaladieConsultation where idmaladie= @idmaladie", con);
                cmd.Parameters.AddWithValue("@idmaladie", idmaladie);
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
        public int CompterLigneConsultationMaladie(int idconsultation)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) from MaladieConsultation where idconsultation= @idconsultation", con);
                cmd.Parameters.AddWithValue("@idconsultation", idconsultation);
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
        public void Supprimer(FormMaladie m)
        {
            if(CompterLigneMaladie(m.idmaladie)==0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Maladie where idmaladie= @idmaladie", con);
                    cmd.Parameters.AddWithValue("@idmaladie", m.idmaladie);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(m);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Afficher(m, "");
            }
            else
                MessageBox.Show("Cette maladie est déjà impliquée dans au moins une consultation ,\npour raison de cohérence, elle ne peut être supprimée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
 
        }
        public void NouvelleMaladie(FormMaladieDiagnostic md, FormMaladie m)
        {
            m.fermeture_succes = false;
            //m.MaximumSize = m.Size;
            //m.MinimumSize = m.Size;
            //m.MinimizeBox = false;
            //m.MaximizeBox = false;
            m.ShowDialog();
            if (m.fermeture_succes)
            {
                
            }
            m.Close();
        }
        public void AjouterLigne(FormMaladieDiagnostic md)
        {
            if (md.txtLibelle.Text == "") md.txtLibelle.Text = "RAS";
            if (md.btnModifier.Enabled) md.dgv1.CurrentRow.Cells[3].Value = md.txtLibelle.Text;
            else
            {
                if (md.cboMaladie.Text != "")
                {
                    md.dgv1.Rows.Add();
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[0].Value = md.dgv1.RowCount;
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[1].Value = md.idmaladie;
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[2].Value = md.cboMaladie.Text;
                    md.dgv1.Rows[md.dgv1.RowCount - 1].Cells[3].Value = md.txtLibelle.Text;
                }
                else MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ValiderLigne(FormMaladieDiagnostic md)
        {
            md.ajoutvalide = true;
            if (md.dgv1.RowCount > 0)
            {
                for (int i = 0; i < md.dgv1.RowCount; i++)
                {
                    if (md.dgv1.Rows[i].Cells[1].Value.ToString() == md.idmaladie.ToString())
                    {
                        MessageBox.Show("Cette maladie est déjà affectée à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        i += md.dgv1.RowCount;
                        md.ajoutvalide = false;
                    }
                }
                if (md.ajoutvalide) AjouterLigne(md);
            }
            else AjouterLigne(md);
        }
        public void Enregistrer(FormMaladieDiagnostic c)
        {
            
        }
        public void Modifier(FormMaladieDiagnostic md)
        {
            if (md.cboMaladie.Text != "" && md.txtLibelle.Text !="")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update MaladieConsultation set observation= @observation where id= @id", con);
                    cmd.Parameters.AddWithValue("@id", md.id);
                    cmd.Parameters.AddWithValue("@observation", md.dgv1.CurrentRow.Cells[3].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                md.txtLibelle.Text = "RAS";
                Afficher(md);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Supprimer(FormMaladieDiagnostic md)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("delete from MaladieConsultation where id= @id", con);
                cmd.Parameters.AddWithValue("@id", md.id);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Supprimée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            md.txtLibelle.Text = "RAS";
            Afficher(md);
        }
        #endregion

        #region SIGNES VITAUX
        public void ChargerSignesVitaux(FormPriseSigneVital sv)
        {
            cmd = new SqlCommand("select * from SigneVital", con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                sv.dgvSigne.Rows.Clear();
                while (dr.Read())
                {
                    sv.dgvSigne.Rows.Add();
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[2].Value = "";
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[3].Value = dr[2].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void ModifierSigneVitalConsultation(FormSigneVital sv)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update SigneVitalConsultation set valeur = @valeur where id= @id", con);
                cmd.Parameters.AddWithValue("@id", sv.dgvSigne.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@valeur", sv.dgvSigne.CurrentRow.Cells[3].Value.ToString());
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
        }
        public void ModifierLigneSigneVital(FormSigneVital sv)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneSigneVital set valeur = @valeur where id= @id", con);
                cmd.Parameters.AddWithValue("@id", sv.dgvSigne.CurrentRow.Cells[0].Value.ToString());
                cmd.Parameters.AddWithValue("@valeur", sv.dgvSigne.CurrentRow.Cells[3].Value.ToString());
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
        }
        public void ModifierSigneVital(FormSigneVital sv)
        {
            if (sv.txtSigneVital.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update SigneVital set nomsigne = @nom where idsigne = @id", con);
                    cmd.Parameters.AddWithValue("@id", sv.idligne);
                    cmd.Parameters.AddWithValue("@nom", sv.txtSigneVital.Text);
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
                //ChargerSignesVitaux(sv);
                Annuler(sv);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EnregistrerLigneSigneVital(FormSigneVital sv)
        {
            if (sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[3].Value.ToString() != "")
            {
                for (int i = 0; i < sv.dgvSigne.RowCount; i++)
                {
                    sv.idligne = NouveauID("sv");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into LigneSigneVital values (@id, @idligneag, @idsigne, @valeur)", con);
                        cmd.Parameters.AddWithValue("@id", sv.idligne);
                        cmd.Parameters.AddWithValue("@idligneag", sv.lblNum.Text);
                        cmd.Parameters.AddWithValue("@idsigne", sv.dgvSigne.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@valeur", sv.dgvSigne.Rows[i].Cells[3].Value.ToString());
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
                //ValiderStatutSignesVitaux(int.Parse(sv.lblNum.Text));
                sv.Close();
            }
            else
            {
                MessageBox.Show("Au moins une valeur manque", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void EnregistrerSigneVital(FormSigneVital sv)
        {
            if (sv.txtSigneVital.Text != "")
            {
                sv.idligne = NouveauID("s");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into SigneVital values (@id, @signe)", con);
                    cmd.Parameters.AddWithValue("@id", sv.idligne);
                    cmd.Parameters.AddWithValue("@signe", sv.txtSigneVital.Text);
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
                MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //ChargerSignesVitaux(sv);
                Annuler(sv);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public int CompterLigneSigne(int idsigne)
        {
            id= 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idsigne) from SigneVitalConsultation where idsigne= @id", con);
                cmd.Parameters.AddWithValue("@id", idsigne);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void Supprimer(FormSigneVital sv)
        {
            if(CompterLigneSigne(sv.idligne)==0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from SigneVital where idsigne = @id", con);
                    cmd.Parameters.AddWithValue("@id", sv.idligne);
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
                //ChargerSignesVitaux(sv);
            }
            else
                MessageBox.Show("Ce signe est déjà impliqué dans les consultations effectuées,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Annuler(sv);
        }
        public void ValeurSigneVitaux(DataGridView dgv, int idprise)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT TOP 5 s.idsigne, nomsigne, valeur, unite 
                FROM SigneVital s
                JOIN ValeurSigneVitaux vs ON s.idsigne = vs.idsigne
                WHERE idprise = " + idprise + "";
                cmd = new SqlCommand(cmdtxt, con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
					dgv.Rows[dgv.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[3].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
		}
        public void Annuler(FormSigneVital sv)
        {
            sv.btnEnregistrer.Enabled = true;
            sv.btnModifier.Enabled = false;
            sv.btnSupprimer.Enabled = false;
            sv.txtSigneVital.Text = "";
            sv.txtSigneVital.Focus();
        }
        #endregion

        #region MEDECIN
        public void Recuperer(FormMedecin m)
        {
            if(m.dgvMedecin.RowCount !=0)
            {
                m.idmedecin = int.Parse(m.dgvMedecin.CurrentRow.Cells[0].Value.ToString());
                m.txtNom.Text = m.dgvMedecin.CurrentRow.Cells[1].Value.ToString();
                m.txtNumOrdre.Text = m.dgvMedecin.CurrentRow.Cells[2].Value.ToString();
                m.txtTel.Text = m.dgvMedecin.CurrentRow.Cells[3].Value.ToString();
                m.txtNom.Focus();
                m.btnModifier.Enabled = true;
                m.btnSupprimer.Enabled = true;
                m.btnEnregistrer.Enabled = false;
            }
        }
        public void AfficherMedecin(FormMedecin m, string motif)
        {
            if (motif == "recherche") cmd = new SqlCommand("select * from Medecin", con);
            else cmd = new SqlCommand("select * from Medecin where idmedecin = "+m.idmedecin+"", con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                m.dgvMedecin.Rows.Clear();
                while (dr.Read())
                {
                    m.dgvMedecin.Rows.Add();
                    m.dgvMedecin.Rows[m.dgvMedecin.RowCount -1].Cells[0].Value = dr[0].ToString();
                    m.dgvMedecin.Rows[m.dgvMedecin.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    m.dgvMedecin.Rows[m.dgvMedecin.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    m.dgvMedecin.Rows[m.dgvMedecin.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    m.dgvMedecin.Rows[m.dgvMedecin.RowCount - 1].Cells[4].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Annuler(FormMedecin m)
        {
            m.btnEnregistrer.Enabled = true;
            m.btnModifier.Enabled = false;
            m.btnSupprimer.Enabled = false;
            m.txtNom.Text = "";
            m.txtNumOrdre.Text = "";
            m.txtTel.Text = "";
            m.txtNom.Focus();
        }
        

        public void Enregistrer(FormMedecin m)
        {
            if (m.txtNom.Text != "" && m.txtNumOrdre.Text != "" && m.txtTel.Text != "")
            {
                m.idmedecin = NouveauID("medecin");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Medecin values (@id, @nom, @numordre, @tel)", con);
                    cmd.Parameters.AddWithValue("@id", m.idmedecin);
                    cmd.Parameters.AddWithValue("@nom", m.txtNom.Text);
                    cmd.Parameters.AddWithValue("@numordre", m.txtNumOrdre.Text);
                    cmd.Parameters.AddWithValue("@tel", m.txtTel.Text);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfficherMedecin(m, "");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                //Ajouter comme service demandeur
                cs.AjouterServiceDemandeur(m.txtNom.Text);
                
                //Ajouter un compte utilisateur
                cs.AjouterNouvelUtilisateur(m.txtNom.Text, "médecin", m.txtNom.Text);

                Annuler(m);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Modifier(FormMedecin m)
        {
            if (m.txtNom.Text != "Noms" && m.txtNumOrdre.Text != "" && m.txtTel.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Medecin set nommedecin= @nom, numordre= @numordre, telmedecin= @tel where idmedecin= @id", con);
                    cmd.Parameters.AddWithValue("@nom", m.txtNom.Text);
                    cmd.Parameters.AddWithValue("@numordre", m.txtNumOrdre.Text);
                    cmd.Parameters.AddWithValue("@tel", m.txtTel.Text);
                    cmd.Parameters.AddWithValue("@id", m.idmedecin);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Modifié avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AfficherMedecin(m, "");
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Annuler(m);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Supprimer(FormMedecin m)
        {
            if (m.idmedecin != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Medecin where idmedecin= @id", con);
                    cmd.Parameters.AddWithValue("@id", m.idmedecin);
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
                Annuler(m);
                m.dgvMedecin.Rows.RemoveAt(m.dgvMedecin.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Identifiant du médecin non reconnu.", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region MESSAGERIE
        public void Annuler(FormMessage m)
        {
            m.cboMedecin.DropDownStyle = ComboBoxStyle.DropDown;
            m.cboMedecin.SelectedText = "";
            m.cboMedecin.DropDownStyle = ComboBoxStyle.DropDownList;
            m.txtObjet.Text = "";
            m.txtMessage.Text = "";
            m.cboMedecin.Select();
        }
        public void ModifierStatut(FormMessage m)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Message set statutmsg = @statut where idmessage = @id", con);
                cmd.Parameters.AddWithValue("@id", m.idmessage);
                cmd.Parameters.AddWithValue("@statut", "Lu");
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
        public void Enregistrer(FormMessage m)
        {
            if(m.btnEnvoyer.Text == "Envoyer")
            {
                m.idmessage = NouveauID("message");
                if (m.repondre) m.txtObjet.Text = "Rép: " + m.txtObjet.Text;
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Message values (@id, @exp, @dest, @objet, @msg, @date_jour, @heure, @statut)", con);
                    cmd.Parameters.AddWithValue("@id", m.idmessage);
                    cmd.Parameters.AddWithValue("@exp", m.idexpediteur);
                    cmd.Parameters.AddWithValue("@dest", m.iddest);
                    cmd.Parameters.AddWithValue("@objet", m.txtObjet.Text);
                    cmd.Parameters.AddWithValue("@msg", m.txtMessage.Text);
                    cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@heure", DateTime.Now.ToShortTimeString());
                    cmd.Parameters.AddWithValue("@statut", "Non lu");
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Messagé envoyé", "Envoi du message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Annuler(m);
            }
            else
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("UPDATE Message set destinataire = @dest, objet = @objet, msg = @msg, date_jour = @date_jour, heure= @heure where idmessage = @id", con);
                    cmd.Parameters.AddWithValue("@id", m.idmessage);
                    cmd.Parameters.AddWithValue("@dest", m.iddest);
                    cmd.Parameters.AddWithValue("@objet", m.txtObjet.Text);
                    cmd.Parameters.AddWithValue("@msg", string.Format("mdf: {0}", m.txtMessage.Text));
                    cmd.Parameters.AddWithValue("@date_jour", DateTime.Now.ToShortDateString());
                    cmd.Parameters.AddWithValue("@heure", DateTime.Now.ToShortTimeString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Messagé envoyé", "Envoi du message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void ChargerDestinataire(ComboBox combo, int id)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT utilisateur FROM Utilisateur WHERE id <> @id", con);
                cmd.Parameters.AddWithValue("@id", id);
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
        public void NouveauMessage(FormMessageHisto c, FormMessage m)
        {
            m.idexpediteur = c.idutilisateur;
            m.cboMedecin.Select();
            m.ShowDialog();
            m.Close();
        }
        public void Modifier(FormMessageHisto c, FormMessage m)
        {
            c.btnModifier.Enabled = false;
            m.idexpediteur = c.idutilisateur;
            m.idmessage = c.idmessage;
            m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[2].Value.ToString();
            m.txtMessage.Text = c.dgvMessage.CurrentRow.Cells[3].Value.ToString();
            //m.cboMedecin.Items.Add(TrouverNom("medecin", m.iddestinataire));
            m.modification = true;
            m.btnEnvoyer.Text = "Modifier";
            m.ShowDialog();
            m.Close();
        }
        public void Repondre(FormMessageHisto c, FormMessage m)
        {
            c.btnRepondre.Enabled = false;
            m.idexpediteur = c.idutilisateur;
            m.repondre = true;
            m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[2].Value.ToString();
            m.txtMessage.Focus();
            m.ShowDialog();
            m.Close();
        }
        public void VoirMessage(FormMessageHisto c, FormMessage m)
        {
            m.lblTitre.Text = "Message";
            m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[2].Value.ToString();
            m.idmessage = c.idmessage;
            m.txtMessage.Text = Message(m.idmessage); //Trouver le message
            m.txtMessage.Enabled = false;
            m.txtObjet.Enabled = false;
            m.label1.Visible = false;
            m.cboMedecin.Visible = false;
            m.btnAnnuler.Enabled = false;
            m.btnEnvoyer.Enabled = false;            
            m.ShowDialog();
            m.Close();
            ModifierStatut(m);
        }
        private string Message(long idmessage)
        {
            con.Open();
            cmd = new SqlCommand("SELECT msg from Message where idmessage = @id", con);
            cmd.Parameters.AddWithValue("@id", idmessage);
            dr = cmd.ExecuteReader();
            while (dr.Read())
	        {
	           chaine = dr[0].ToString();
	        }
            con.Close();
            return chaine;
        }
        public void MsgReçus(FormMessageHisto c)
        {
            c.dgvMessage.Columns[1].HeaderText = "Expéditeur";
            con.Open();
            cmdtxt = @"SELECT idmessage, utilisateur, objet, msg, date_jour, heure, statutmsg 
            FROM Message m
            JOIN Utilisateur u ON m.expediteur = u.id
            WHERE destinataire = @iduser and date_jour BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@iduser", c.idutilisateur);
            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
            c.dgvMessage.Rows.Clear();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.dgvMessage.Rows.Add();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Selected = false;
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[0].Value = dr[0].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[1].Value = dr[1].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[2].Value = dr[2].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[3].Value = dr[3].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[4].Value = dr[4].ToString().Substring(0, 10);
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[5].Value = dr[5].ToString().Substring(0,5);
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[6].Value = dr[6].ToString();
                if (c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[6].Value.ToString() == "Non lu")
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
            con.Close();
        }
        public void MsgEnvoyés(FormMessageHisto c)
        {
            c.dgvMessage.Columns[1].HeaderText = "Destinataire";
            con.Open();
            cmdtxt = @"SELECT idmessage, utilisateur, objet, msg, date_jour, heure, statutmsg 
            FROM Message m
            JOIN Utilisateur u ON m.destinataire = u.id
            WHERE expediteur = @iduser and date_jour BETWEEN @dateDe AND @dateA";
            cmd = new SqlCommand(cmdtxt, con);
            cmd.Parameters.AddWithValue("@iduser", c.idutilisateur);
            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
            c.dgvMessage.Rows.Clear();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                c.dgvMessage.Rows.Add();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Selected = false;
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[0].Value = dr[0].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[1].Value = dr[1].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[2].Value = dr[2].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[3].Value = dr[3].ToString();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[4].Value = dr[4].ToString().Substring(0, 10);
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[5].Value = dr[5].ToString().Substring(0, 5);
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[6].Value = dr[6].ToString();
            }
            con.Close();
        }
        #endregion       
    }
    public class BonExamen
    {
        public string numexamen { get; set; }
        public string examen { get; set; }
    }
    public class Ordonnance
    {
        public int id { get; set; }
        public string produit { get; set; }
        public string quantite { get; set; }
        public string posologie { get; set; }
    }
    public class DossierPatient
    {
        public string id { get; set; }
        public string libelle { get; set; }
    }
}