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
                case "payeur": cmdtxt = "select max(idpayeur) from Payeur"; break;
                case "recette": cmdtxt = "select max(idrecette) from Recette"; break;
                case "patient": cmdtxt = "select max(idpatient) from Patient"; break;
                case "consultation": cmdtxt = "select max(idconsultation) from Consultation"; break;
                case "renseignement": cmdtxt = "select max(id) from Renseignement"; break;
                case "prescription": cmdtxt = "select max(idpresc) from Prescription"; break;
                case "service": cmdtxt = "select max(idservice) from ServiceDemande"; break;
                case "medecin": cmdtxt = "select max(idmedecin) from Medecin"; break;
                case "maladie": cmdtxt = "select max(idmaladie) from Maladie"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
                case "examenphysique": cmdtxt = "select max(idexamen) from ExamenPhysique"; break;
                case "sv": cmdtxt = "select max(id) from LigneSigneVital"; break;
                case "svc": cmdtxt = "select max(id) from SigneVitalConsultation"; break;
                case "s": cmdtxt = "select max(idsigne) from SigneVital"; break;
                case "rdv": cmdtxt = "select max(idrendezvous) from Rendezvous"; break;
                case "prise": cmdtxt = "select max(idprise) from PriseSigneVitaux"; break;
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
        public void AfficherSousForm(MFormInfirmerie i, FormPatient childForm)
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
            if (i.statut == "nouveau")
            {
                childForm.txtRecherche.Enabled = false;
                childForm.btnRecherche.Enabled = false;
            }
            else
                childForm.btnEnregistrer.Enabled = false;
            childForm.statut = i.statut;
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
                    cmd = new SqlCommand("SELECT idprise, noms, PriseSigneVitaux.idrecette FROM PriseSigneVitaux, Patient, Recette WHERE PriseSigneVitaux.idrecette = Recette.idrecette AND PriseSigneVitaux.idpatient = Patient.idpatient AND date_prise between @dtpdateDe and @dtpdateA AND idmedecin = '" + c.idmedecin + "'", con);
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                }
                else
                    cmd = new SqlCommand("SELECT idprise, noms, PriseSigneVitaux.idrecette FROM PriseSigneVitaux, Patient, Recette WHERE PriseSigneVitaux.idrecette = Recette.idrecette AND PriseSigneVitaux.idpatient = Patient.idpatient AND date_prise = '" + DateTime.Now.ToShortDateString() + "' AND idmedecin = '" + c.idmedecin + "'", con);
                dr = cmd.ExecuteReader();
                c.dgvPrise.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPrise.Rows.Add();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPrise.Rows[c.dgvPrise.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if(c.dgvPrise.RowCount != 0)
            {
                for (int i = 0; i < c.dgvPrise.RowCount; i++)
                {
                    con.Open();
                    try
                    {
                        cmd = new SqlCommand("SELECT RecetteService.idservice FROM RecetteService, Service WHERE idrecette = '" + c.dgvPrise.Rows[i].Cells[2].Value.ToString() + "' AND RecetteService.idservice = Service.idservice AND nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence')", con);
                        dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            c.dgvPrise.Rows[i].Cells[3].Value = dr[0].ToString();
                        }
                    }
                    catch (Exception ex)
                    { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    con.Close();
                }
            }
        }
        public int IdConsultationPrise(int idprise)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select idconsultation from Consultation WHERE idprise = '" + idprise + "'", con);
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
                cmd = new SqlCommand("SELECT noms, sexe, age, adresse, situation, telephone, pers_contact, tel_contact, nomtype, idpayeur FROM Patient, TypePatient, Payeur WHERE Patient.idtype = TypePatient.idtype AND Patient.idpatient = Payeur.idpatient AND Patient.idpatient = '" + idpatient + "'", con);
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add(10);
                    dgv.Rows[0].Cells[0].Value = "Noms";
                    dgv.Rows[1].Cells[0].Value = "Sexe";
                    dgv.Rows[2].Cells[0].Value = "Age";
                    dgv.Rows[3].Cells[0].Value = "Adresse";
                    dgv.Rows[4].Cells[0].Value = "Situation";
                    dgv.Rows[5].Cells[0].Value = "Téléphone";
                    dgv.Rows[6].Cells[0].Value = "Pers. contact";
                    dgv.Rows[7].Cells[0].Value = "Tél. pers. contact";
                    dgv.Rows[8].Cells[0].Value = "Type";
                    dgv.Rows[9].Cells[0].Value = "Payeur";

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
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Consultation(FormConsulterPrise cp, FormConsulter c)
        {
            c.idconsultation = cp.idconsultation;
            c.idpatient = cp.idpatient;
            c.idmedecin = cp.idmedecin;
            c.idprise = cp.idprise;
            c.type_patient = cp.dgvPatient.Rows[8].Cells[1].Value.ToString();
            PatientConsulte(c.dgvPatient, c.idpatient);
            
            ValeurSigneVitaux(c.dgvSigneVital, int.Parse(cp.dgvPrise.CurrentRow.Cells[0].Value.ToString()));
            c.Text = "SSM - Dossier " + cp.dgvPrise.CurrentRow.Cells[1].Value.ToString();

            c.Show();
        }
        public void AjouterResultatExamen(FormConsulter c, string categorie, FormResultatExamen r)
        {
            r.idconsultation = c.idconsultation;
            r.categorie = categorie;
            con.Open();
            try
            {

                cmd = new SqlCommand("SELECT PrescriptionService.idservice, nomservice, observation FROM PrescriptionService, Service WHERE categorie = '" + categorie + "' AND idconsultation = '" + r.idconsultation + "' AND PrescriptionService.idservice = Service.idservice", con);
                dr = cmd.ExecuteReader();
                r.dgvExamen.Rows.Clear();
                while (dr.Read())
                {
                    r.dgvExamen.Rows.Add();
                    r.dgvExamen.Rows[r.dgvExamen.RowCount - 1].Cells[0].Value = r.dgvExamen.RowCount;
                    r.dgvExamen.Rows[r.dgvExamen.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    r.dgvExamen.Rows[r.dgvExamen.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    r.dgvExamen.Rows[r.dgvExamen.RowCount - 1].Cells[3].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            if (r.dgvExamen.RowCount != 0)
            {
                r.ShowDialog();
                r.Close();
            }
            else
                MessageBox.Show("Aucun élément n'a été trouvé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void AfficherSousForm(MFormConsultation c, FormPriseSigneVital childForm)
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
        public void AfficherSousForm(MFormConsultation c, FormMedecinHistoChat childForm)
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
            childForm.idexpediteur = c.idmedecin;
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
                    cmd = new SqlCommand("select idconsultation, noms, repondant, lienrepondnant, Consultation.idprise from Consultation, PriseSigneVitaux, Patient where Consultation.idprise = PriseSigneVitaux.idprise and PriseSigneVitaux.idpatient = Patient.idpatient and date_consultation between @dtpdateDe and @dtpdateA and idmedecin= @idmedecin", con);
                    cmd.Parameters.AddWithValue("@idmedecin", c.idmedecin);
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);

                }
                else if (motif == "patient")
                {
                    cmd = new SqlCommand("select idconsultation, noms, repondant, lienrepondnant, Consultation.idprise from Consultation, PriseSigneVitaux, Patient where Consultation.idprise = PriseSigneVitaux.idprise and PriseSigneVitaux.idpatient = Patient.idpatient and date_consultation between @dtpdateDe and @dtpdateA and Patient.idpatient = @idpatient", con);
                    cmd.Parameters.AddWithValue("@idpatient", c.idpatient);
                    cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                }
                else
                {
                    cmd = new SqlCommand("select idconsultation, noms, repondant, lienrepondnant, Consultation.idprise from Consultation, PriseSigneVitaux, Patient where Consultation.idprise = PriseSigneVitaux.idprise and PriseSigneVitaux.idpatient = Patient.idpatient and date_consultation = '" + DateTime.Now.ToShortDateString() + "' and idmedecin= @idmedecin", con);
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
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        
        public void SigneVitalConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select SigneVital.idsigne, nomsigne, valeur from ValeurSigneVitaux, SigneVital where ValeurSigneVitaux.idprise = '" + cd.idprise + "' and SigneVital.idsigne = ValeurSigneVitaux.idsigne", con);
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
                cmd = new SqlCommand("select ValeurExamenPhysique.idexamen, examen, valeur from ValeurExamenPhysique, ExamenPhysique where idconsultation = @id and ExamenPhysique.idexamen = ValeurExamenPhysique.idexamen", con);
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
                cmd = new SqlCommand("select ValeurExamenPhysique.idexamen, examen, valeur from ValeurExamenPhysique, ExamenPhysique where idconsultation = @id and ExamenPhysique.idexamen = ValeurExamenPhysique.idexamen", con);
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
                cmd = new SqlCommand("select id, libelle from Renseignement where label= @label and idconsultation = @id", con);
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
                cmd = new SqlCommand("select MaladieConsultation.idmaladie, nommaladie, observation from MaladieConsultation, Maladie where MaladieConsultation.idmaladie = Maladie.idmaladie and idconsultation = @id", con);
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
        public void VoirPrescriptionProduit(FormConsulter c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select PrescriptionProduit.idstock, nomproduit, forme, dosage, quantite, posologie from PrescriptionProduit, LigneStock, Produit where idconsultation = @id and PrescriptionProduit.idstock = LigneStock.idstock and LigneStock.idproduit = Produit.idproduit", con);
                cmd.Parameters.AddWithValue("@id", c.idconsultation);
                dr = cmd.ExecuteReader();
                c.dgvPresc.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPresc.Rows.Add();
                    c.dgvPresc.Columns[0].Visible = false;
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[1].Value = string.Format("{0}, {1}, {2}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[2].Value = dr[4].ToString();
                    c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[3].Value = dr[5].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            if (c.dgvPresc.RowCount != 0)
            {
                c.btnModifierPresc.Enabled = true;
                c.btnSupprimerPresc.Enabled = true;
            }
        }
        
        public void PrescriptionService(FormConsultationDossier cd, string motif)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select PrescriptionService.idservice, nomservice, observation from PrescriptionService, Service where PrescriptionService.idservice = Service.idservice and categorie = '" + motif + "' and idconsultation = @id", con);
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
        public void MaladieConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id=0;
                cmd = new SqlCommand("select MaladieConsultation.idmaladie, nommaladie, observation from MaladieConsultation, Maladie where MaladieConsultation.idmaladie = Maladie.idmaladie and idconsultation = @id", con);
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
        public void PrescriptionProduit(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select PrescriptionProduit.idstock, nomproduit, forme, dosage, quantite, posologie from PrescriptionProduit, LigneStock, Produit where PrescriptionProduit.idstock = LigneStock.idstock and LigneStock.idproduit = Produit.idproduit and idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = string.Format("{0}: {1}: {2}: {3}: {4}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
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
            PrescriptionService(cd, "examen para");

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
            PrescriptionProduit(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS SERVICES";
            PrescriptionService(cd, "autre");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            RenseignementConsultation(cd, "autre");

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
            PrescriptionService(cd, "examen para");

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
            PrescriptionProduit(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS SERVICES";
            PrescriptionService(cd, "autre");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            RenseignementConsultation(cd, "autre");
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

        #region RENSEIGNEMENT
        public void Annuler(FormRenseignement r)
        {
            r.txtLibelle.Text = "";
            r.btnRetirer.Enabled = false;
            r.txtLibelle.Focus();
        }
        public void AjouterLigne(FormRenseignement r)
        {
            r.dgv1.Rows.Add();
            r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[0].Value = r.dgv1.RowCount;
            r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[1].Value = r.txtLibelle.Text;
        }
        public void ValiderLigne(FormRenseignement r)
        {
            if (r.txtLibelle.Text != "")
            {
                if (r.btnRetirer.Enabled)
                    r.dgv1.CurrentRow.Cells[1].Value = r.txtLibelle.Text;
                else
                {
                    if (r.cboMotif.Text == "examen physique")
                        r.dgv1.CurrentRow.Cells[2].Value = r.txtLibelle.Text;
                    else
                    {
                        if (r.dgv1.RowCount > 0)
                        {
                            r.ajoutvalide = true;
                            for (int i = 0; i < r.dgv1.RowCount; i++)
                            {
                                if (r.dgv1.Rows[i].Cells[1].Value.ToString() == r.txtLibelle.Text)
                                {
                                    r.ajoutvalide = false;
                                    i += r.dgv1.RowCount;
                                }
                            }
                            if (r.ajoutvalide) AjouterLigne(r);
                        }
                        else AjouterLigne(r);
                    }
                }
            }
            else
            {
                MessageBox.Show("Aucune valeur n'a été fournie", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Annuler(r);
        }
        
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
                    cmd = new SqlCommand("insert into Consultation values (@id, @date, @idprise, @repondant, @lien)", con);
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
            cc.MAJRecetteServi(cp.idrecette, "service", cp.idservice, cp.idutilisateur, "OK");
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
                MessageBox.Show("Enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv.Rows.Clear();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterPrescriptionService(FormConsulter c, string label, DataGridView dgv)
        {
            for (int i = 0; i < dgv.RowCount; i++)
            {
                if (dgv.Rows[i].Cells[0].Value.ToString() != "")
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into PrescriptionService values (@idconsultation, @idservice, @categorie, @observation)", con);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@idservice", dgv.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@categorie", label);
                        cmd.Parameters.AddWithValue("@observation", "");
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
        }
        public void AjouterExamenPara(FormConsulter c, FormFactureService f)
        {
            if (c.dgvLabo.RowCount != 0)
            {
                f.idpayeur = int.Parse(c.dgvPatient.Rows[9].Cells[1].Value.ToString());
                f.cboPayeur.Enabled = false;
                f.btnAnnuler.Enabled = false;
                f.txtPayeur.Text = c.dgvPatient.Rows[0].Cells[1].Value.ToString();
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDown;
                f.cboPayeur.Text = "patient";
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDownList;
                f.cboPayeur.Enabled = false;
                f.txtPayeur.Enabled = false;
                f.txtContacts.Enabled = false;
                f.txtRecherche.Enabled = false;
                f.btnRecherche.Enabled = false;
                f.btnExit.Visible = false;
                f.Text = "Facturation Examens";
                f.recettePatientConsulte = true;
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
                    }
                }
                cc.CalculerTotal(f.dgvFacture, f.txtTotal);
                f.ShowDialog();
                if (f.fermeture_succes)
                {
                    AjouterPrescriptionService(c, "examen para", c.dgvLabo);
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
            f.cboPayeur.Items.Remove("passant");
            f.txtPayeur.Enabled = false;
            f.txtContacts.Enabled = false;
            f.btnExit.Visible = false;
            f.Text = "Facturation Produits";
            f.recettePatientConsulte = true;
            f.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();
            if(f.type_patient == "abonné")
                f.cboTypeFacture.Items.Remove("immédiat");
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
            f.cboPayeur.Items.Remove("passant");
            f.txtPayeur.Enabled = false;
            f.txtContacts.Enabled = false;           
            f.btnExit.Visible = false;
            f.Text = "Facturation Service";
            f.recettePatientConsulte = true;
            f.type_patient = c.dgvPatient.Rows[8].Cells[1].Value.ToString();
            if (f.type_patient == "abonné")
                f.cboTypeFacture.Items.Remove("immédiat");
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
        public void AjouterPrescription(FormConsulter c)
        {
            if (c.dgvPresc.RowCount > 0)
            {
                for (int i = 0; i < c.dgvPresc.RowCount; i++)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into PrescriptionProduit (idconsultation, idstock, quantite, posologie) values (@idconsultation, @idstock, @quantite, @posologie)", con);
                        cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
                        cmd.Parameters.AddWithValue("@idstock", c.dgvPresc.Rows[i].Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@quantite", c.dgvPresc.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@posologie", c.dgvPresc.Rows[i].Cells[3].Value.ToString());
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
                MessageBox.Show("Enregistrée(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                c.dgvPresc.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Aucune ligne de prescription n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        public void ModifierPrescriptionService(FormResultatExamen exa)
        {
            if (exa.dgvExamen.CurrentRow.Cells[3].Value.ToString() != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update PrescriptionService set observation= @resultat where idconsultation = '" + exa.idconsultation + "' AND idservice = '"+exa.dgvExamen.CurrentRow.Cells[1].Value.ToString()+"' AND categorie = '"+exa.categorie+"'", con);
                    cmd.Parameters.AddWithValue("@resultat", exa.dgvExamen.CurrentRow.Cells[3].Value.ToString());
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
            else MessageBox.Show("Aucune valeur n'est fournie", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerPrescriptionService(FormResultatExamen exa)
        {
            exa.btnSupprimer.Enabled = false;
            if (exa.dgvExamen.RowCount != 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("DELETE FROM PrescriptionService where idconsultation = '" + exa.idconsultation + "' AND idservice = '" + exa.dgvExamen.CurrentRow.Cells[1].Value.ToString() + "' AND categorie = '" + exa.categorie + "'", con);
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
                exa.dgvExamen.Rows.RemoveAt(exa.dgvExamen.CurrentRow.Index);
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
                        cmd = new SqlCommand("SELECT COUNT(c.idconsultation) FROM Consultation c JOIN PriseSigneVitaux psv ON c.idprise = psv.idprise JOIN Recette r ON psv.idrecette = r.idrecette JOIN RecetteService rs ON r.idrecette = rs.idrecette WHERE idmedecin = '" + s.idmedecin + "' AND rs.idservice = '" + s.dgvResume.Rows[i].Cells[0].Value.ToString() + "' AND c.date_consultation BETWEEN '"+s.dtpDateDe.Text+"' AND '"+s.dtpDateA.Text+"'", con);
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
        
        #region PATIENT
        public string AgePatient(string chaineDate)
        {
            chaine = "";
            if (chaineDate == "")
                chaine = "Age :";
            else
            {
                if ((12 - Math.Abs(DateTime.Now.Month - int.Parse(chaineDate.Substring(0, chaineDate.IndexOf("/"))))) < 12)
                    chaine = (DateTime.Now.Year - int.Parse(chaineDate.Substring(chaineDate.IndexOf("/") + 1)) - 1) + " ans et " + (12 - Math.Abs(DateTime.Now.Month - int.Parse(chaineDate.Substring(0, chaineDate.IndexOf("/"))))) + " mois";
                else
                    chaine = 1 + (DateTime.Now.Year - int.Parse(chaineDate.Substring(chaineDate.IndexOf("/") + 1)) - 1) + " ans";
            }
            return chaine;
        }
        public void ChargerCombo(ComboBox combo, string motif)
        {
            switch (motif)
	        {
                case "médecin": cmd = new SqlCommand("select nommedecin from Medecin", con); break;
                case "typepatient": cmd = new SqlCommand("select nomtype from TypePatient", con); break;
                case "autorisation": cmd = new SqlCommand("select libelle from Autorisations", con); break;
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

            if(p.dgvMedecin.RowCount != 0)
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
                    if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "NULL";
                    if (p.txtTelContact.Text == "") p.txtTelContact.Text = "243";
                    //Si le patient est abonné
                    if (p.cboTypePatient.Text.Contains("abonné"))
                    {
                        cmd = new SqlCommand("insert into Patient values (@id, @nom, @sexe, @age, @adresse, @situation, @tel, @contact, @telcontact, @idtype, @idtypeabonne, @identreprise, @num_service)", con);
                        cmd.Parameters.AddWithValue("@id", p.idpatient);
                        cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                        cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                        cmd.Parameters.AddWithValue("@age", p.age);
                        cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                        cmd.Parameters.AddWithValue("@situation", p.zonesante);
                        cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                        cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                        cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                        cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                        cmd.Parameters.AddWithValue("@idtypeabonne", p.idtypeabonne);
                        cmd.Parameters.AddWithValue("@identreprise", p.identreprise);
                        cmd.Parameters.AddWithValue("@num_service", p.num_service);
                    }
                    else //Si le patient n'est pas abonné
                    {
                        cmd = new SqlCommand("insert into Patient (idpatient, noms, sexe, age, adresse, situation, telephone, pers_contact, tel_contact, idtype) values (@id, @nom, @sexe, @age, @adresse, @situation, @tel, @contact, @telcontact, @idtype)", con);
                        cmd.Parameters.AddWithValue("@id", p.idpatient);
                        cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                        cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                        cmd.Parameters.AddWithValue("@age", p.age);
                        cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                        cmd.Parameters.AddWithValue("@situation", p.zonesante);
                        cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                        cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                        cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                        cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                    }
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

                //Ajouter le payeur
                p.idpayeur = NouveauID("payeur");
                con.Open();
                tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Payeur (idpayeur, nompayeur, idpatient) values (@idpayeur, @nompayeur, @idpatient)", con);
                    cmd.Parameters.AddWithValue("@idpayeur", p.idpayeur);
                    cmd.Parameters.AddWithValue("@nompayeur", "patient");
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

                //Recette
                p.type_patient = p.cboTypePatient.Text;
                AjouterRecetteCas(p);               
                AfficherPatient(p.dgvPatient, p.txtRecherche, "", p.poste, p.idpatient);
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AjouterRecetteCas(FormPatient p)
        {
            //Ajoute la recette
            p.idrecette = cc.AjouterRecette(p.idrecette, p.cboTypeFacture.Text, p.lblDateOperation.Text, "patient", p.idpayeur, "service");

            //Ajouter la consultation
            cc.AjouterServiceRecette(p.idrecette, cc.TrouverId("service", p.service));
            ////Ecriture comptable              
            if (p.cboTypeFacture.Text == "différé")
            {
                if (p.type_patient.Contains("abonné"))
                    p.numcomptediffere = TrouverNom("numcompte_entreprise", p.identreprise);
                else if (p.type_patient == "employé")
                    p.numcomptediffere = cc.TrouverId("numcompte", "Médecine du travail et pharmacie").ToString();
                else if (p.type_patient == "cas social")
                    p.numcomptediffere = cc.TrouverId("numcompte", "Frais médicaux & Pharmaceutiques Cas sociaux").ToString();
                else if (p.type_patient == "payant" && p.cboTypeFacture.Text == "différé")
                    p.numcomptediffere = "4711";
                p.idoperation = cc.NouveauID("operation");
                if (cc.AjouterOperation(p.idoperation, p.lblDateOperation.Text, string.Format("R_{0}", p.idrecette), cc.TrouverId("typejournal", "ventes"), p.idexercice, p.idrecette, "recette"))
                {
                    p.numcompte = cc.TrouverNom("numcompte_service", cc.TrouverId("service", p.service));
                    cc.AjouterEcriture(p.idoperation, p.numcomptediffere, p.numcompte, cc.PrixService(cc.TrouverId("service", p.service)), cc.PrixService(cc.TrouverId("service", p.service)), "Vente - service à crédit");
                }
            }
            MessageBox.Show("Ajouté avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    if (p.txtTel.Text == "") p.txtTel.Text = "243";
                    if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "NULL";
                    if (p.txtTelContact.Text == "") p.txtTelContact.Text = "243";

                    if (p.cboTypePatient.Text.Contains("abonné"))
                    {
                        cmd = new SqlCommand("update Patient set noms= @nom, sexe= @sexe, age= @age, adresse= @adresse, situation= @situation, telephone= @tel, pers_contact= @contact, tel_contact= @telcontact, idtype= @idtype, idtypeabonne = @idtypeabonne, identreprise = @identreprise, num_service = @num_service  where idpatient= @id", con);
                        cmd.Parameters.AddWithValue("@id", p.idpatient);
                        cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                        cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                        cmd.Parameters.AddWithValue("@age", p.age);
                        cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                        cmd.Parameters.AddWithValue("@situation", p.zonesante);
                        cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                        cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                        cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                        cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                        cmd.Parameters.AddWithValue("@idtypeabonne", p.idtypeabonne);
                        cmd.Parameters.AddWithValue("@identreprise", p.identreprise);
                        cmd.Parameters.AddWithValue("@num_service", p.num_service);
                    }
                    else
                    {
                        cmd = new SqlCommand("update Patient set noms= @nom, sexe= @sexe, age= @age, adresse= @adresse, situation= @situation, telephone= @tel, pers_contact= @contact, tel_contact= @telcontact, idtype= @idtype  where idpatient= @id", con);
                        cmd.Parameters.AddWithValue("@id", p.idpatient);
                        cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                        cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                        cmd.Parameters.AddWithValue("@age", p.age);
                        cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                        cmd.Parameters.AddWithValue("@situation", p.zonesante);
                        cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                        cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                        cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                        cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                    }

                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    p.btnModifier.Enabled = false;
                    MessageBox.Show("Modifié avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(p);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                AfficherPatient(p.dgvPatient, p.txtRecherche, "", p.poste, p.idpatient);
                p.btnModifier.Enabled = false;
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Supprimer(FormPatient p)
        {
            //Condition
            MessageBox.Show("Pour supprimer ce patient il faut :\n1.Supprimer les recettes qui le concernent\n2.Revenir supprimer le patient");
            /*
             * le nombre de consultation doit être 0
             * le nombre de prise doit etre 0
             * supprimer le patient et sa ligne dans Payeur
             */
            //if (NbConsultationPatient(p.idpatient) == 0)
            //{
            //    con.Open();
            //    SqlTransaction tx = con.BeginTransaction();
            //    try
            //    {
            //        cmd = new SqlCommand("delete from Patient where idpatient = @id", con);
            //        cmd.Parameters.AddWithValue("@id", p.idpatient);
            //        cmd.Transaction = tx;
            //        cmd.ExecuteNonQuery();
            //        tx.Commit();
            //        MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Annuler(p);
            //    }
            //    catch (Exception ex)
            //    {
            //        tx.Rollback();
            //        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    con.Close();
            //    Afficher(p, "");
            //}
            //else
            //    MessageBox.Show("Ce patient est déjà impliqué dans au moins une consultation ,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public void AfficherPatient(DataGridView dgv, TextBox txt, string motif, string poste, int idpatient)
        {
            if(motif =="recherche")
            {
                if (txt.Text != "" && txt.Text != "Nom du patient" && txt.Text != "Numéro service")
                {
                    con.Open();
                    try
                    {
                        if (!poste.Contains("abonné"))
                        {
                            cmd = new SqlCommand("select Patient.idpatient,idpayeur,noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype from Patient, Payeur, TypePatient where Patient.idpatient = Payeur.idpatient and Patient.idtype = TypePatient.idtype and noms like '" + txt.Text + "%'", con);
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
                                dgv.Rows[dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[10].Value = dr[10].ToString();
                            }
                        }
                        else
                        {
                            cmd = new SqlCommand("select Patient.idpatient,idpayeur,noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype,typeabonne,nomentreprise,num_service from Patient, Payeur, TypePatient, TypeAbonne, Entreprise where Patient.idpatient = Payeur.idpatient and Patient.idtype = TypePatient.idtype and Patient.idtypeabonne = TypeAbonne.idtypeabonne and Patient.identreprise = Entreprise.identreprise and noms like '" + txt.Text + "%'", con);
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
                                dgv.Rows[dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[10].Value = dr[10].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[11].Value = dr[11].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[12].Value = dr[12].ToString();
                                dgv.Rows[dgv.RowCount - 1].Cells[13].Value = dr[13].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                }
                else MessageBox.Show("Aucun nom de patient n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                try
                {
                    if (poste != "abonné")
                    {
                        cmd = new SqlCommand("select Patient.idpatient,idpayeur,noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype from Patient, Payeur, TypePatient where Patient.idpatient = Payeur.idpatient and Patient.idtype = TypePatient.idtype and Patient.idpatient = '" + idpatient + "'", con);
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
                            dgv.Rows[dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[10].Value = dr[10].ToString();
                        }
                    }
                    else
                    {
                        cmd = new SqlCommand("select Patient.idpatient,idpayeur,noms,sexe,age,adresse,situation,telephone,pers_contact,tel_contact,nomtype,typeabonne,nomentreprise,num_service from Patient, Payeur, TypePatient, TypeAbonne, Entreprise where Patient.idpatient = Payeur.idpatient and Patient.idtype = TypePatient.idtype and Patient.idtypeabonne = TypeAbonne.idtypeabonne and Patient.identreprise = Entreprise.identreprise and Patient.idpatient = '" + idpatient + "'", con);
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
                            dgv.Rows[dgv.RowCount - 1].Cells[7].Value = dr[7].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[8].Value = dr[8].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[9].Value = dr[9].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[10].Value = dr[10].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[11].Value = dr[11].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[12].Value = dr[12].ToString();
                            dgv.Rows[dgv.RowCount - 1].Cells[13].Value = dr[13].ToString();
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
        public void Recuperer(FormPatient p)
        {
            if(p.dgvPatient.RowCount !=0)
            {
                p.txtNom.Text = p.dgvPatient.CurrentRow.Cells[2].Value.ToString();

                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboSexe.Text = p.dgvPatient.CurrentRow.Cells[3].Value.ToString();
                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;

                p.txtAdresse.Text = p.dgvPatient.CurrentRow.Cells[5].Value.ToString();
                p.txtTel.Text = p.dgvPatient.CurrentRow.Cells[7].Value.ToString();
                p.txtPersonContact.Text = p.dgvPatient.CurrentRow.Cells[8].Value.ToString();
                p.txtTelContact.Text = p.dgvPatient.CurrentRow.Cells[9].Value.ToString();

                p.cboTypePatient.Select();
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
            p.txtRecherche.Text = "Nom du patient";
            p.btnAffecter.Enabled = false;
            p.lblAge.Text = "Age :";
            p.rbNouveau.Checked = false;
            p.rbUrgence.Checked = false;
            p.checkBox1.Checked = false;
            p.btnModifier.ForeColor = SystemColors.ControlText;
            p.btnModifier.BackColor = Color.FromArgb(230, 230, 255);
        }
        public void TrouverPatient(FormFactureService f, FormFacturePatient p)
        {
            p.poste = f.poste;
            p.type_facture = f.cboTypeFacture.Text;
            p.ShowDialog();
            if(p.fermeture_succes)
            {
                f.idpayeur = int.Parse(p.dgvPatient.CurrentRow.Cells[1].Value.ToString());
                f.txtPayeur.Text = p.dgvPatient.CurrentRow.Cells[2].Value.ToString();
                f.numcomptediffere = p.numcomptediffere;
            }
            else
            {
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDown;
                f.cboPayeur.SelectedText = "";
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            p.Close();
        }
        public void TrouverPatient(FormFactureProduit f, FormFacturePatient p)
        {
            p.poste = f.poste;
            p.type_facture = f.cboTypeFacture.Text;
            p.ShowDialog();
            if (p.fermeture_succes)
            {
                f.idpayeur = int.Parse(p.dgvPatient.CurrentRow.Cells[1].Value.ToString());
                f.txtPayeur.Text = p.dgvPatient.CurrentRow.Cells[2].Value.ToString();
                f.numcomptediffere = p.numcomptediffere;                
            }
            else
            {
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDown;
                f.cboPayeur.SelectedText = "";
                f.cboPayeur.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            p.Close();
        }
        public void AjouterAbonne(FormPatient p, FormAbonne a)
        {
            a.cboEntreprise.Select();
            a.ShowDialog();
            if (a.fermeture_succes)
            {
                p.identreprise = a.identreprise;
                p.idtypeabonne = a.idtypeabonne;
                p.num_service = a.txtReference.Text;
            }
            else
                p.cboTypePatient.Items.Clear();
            a.Close();
        }
        public void AfficherPatient(DataGridView dgv, int idpatient, int start)
        {
            for(int i=0; i < dgv.RowCount; i++)
            {
                con.Open();
                cmd = new SqlCommand("select noms, sexe, age from Patient where idpatient = @idpatient", con);
                cmd.Parameters.AddWithValue("@idpatient", dgv.Rows[i].Cells[idpatient].Value.ToString());
                try
                {
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dgv.Rows[i].Cells[start].Value = dr[0].ToString();
                        dgv.Rows[i].Cells[start + 1].Value = dr[1].ToString();
                        dgv.Rows[i].Cells[start + 2].Value = dr[2].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
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
                            cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur,TypePatient where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Patient.idtype = TypePatient.idtype and TypePatient.nomtype = 'abonné' and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation between @dateDe and @dateA", con);
                        else
                            cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur,TypePatient where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Patient.idtype = TypePatient.idtype and TypePatient.nomtype = 'abonné' and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation between @dateDe and @dateA and noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'", con);
                    }
                    else
                    {
                        if (a.txtNom.Text == "") 
                            cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation between @dateDe and @dateA", con);
                        else
                            cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation between @dateDe and @dateA and noms LIKE '" + a.txtNom.Text.Replace("'", "") + "%'", con);
                    }
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                }
                else
                {
                    if (a.checkBox2.Checked)
                        cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur,TypePatient where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Patient.idtype = TypePatient.idtype and TypePatient.nomtype = 'abonné' and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                    else
                        cmd = new SqlCommand("select Recette.idrecette, date_operation, nomservice, noms from Recette, RecetteService, Service, Patient, Payeur where Recette.statut_caisse = 'OK' AND Recette.idpayeur = Payeur.idpayeur and Payeur.idpatient = Patient.idpatient and Recette.idrecette = RecetteService.idrecette and RecetteService.idservice = Service.idservice and nomservice IN ('Consultation ancien cas', 'Consultation nouveau cas', 'Consultation urgence') and date_operation = '" + DateTime.Now.ToShortDateString() + "'", con);
                }
                dr = cmd.ExecuteReader();
                a.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAgenda.Rows.Add();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[4].Value = "";
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[5].Value = "";
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
                        cmd = new SqlCommand("select nommedecin, idprise from PriseSigneVitaux, Medecin where PriseSigneVitaux.idrecette = "+a.dgvAgenda.Rows[i].Cells[0].Value.ToString()+" and PriseSigneVitaux.idmedecin = Medecin.idmedecin and PriseSigneVitaux.date_prise = '" + DateTime.Now.ToShortDateString() + "'", con);
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
            if (p.cboMedecin.Text != "" && p.dgvSigne.Rows[p.dgvSigne.RowCount - 1].Cells[2].Value.ToString() != "")
            {
                if(p.reaffecter)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("UPDATE PriseSigneVitaux SET idmedecin = @idmedecin WHERE idprise = @idprise", con);
                        cmd.Parameters.AddWithValue("@idprise", p.idprise);
                        cmd.Parameters.AddWithValue("@idmedecin", p.idmedecin);
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
                        cmd = new SqlCommand("INSERT INTO PriseSigneVitaux VALUES (@idprise, @date_prise, @idpatient, @idrecette, @idmedecin)", con);
                        cmd.Parameters.AddWithValue("@idprise", p.idprise);
                        cmd.Parameters.AddWithValue("@date_prise", p.dtpDateDe.Text);
                        cmd.Parameters.AddWithValue("@idpatient", p.idpatient);
                        cmd.Parameters.AddWithValue("@idrecette", p.idrecette);
                        cmd.Parameters.AddWithValue("@idmedecin", p.idmedecin);
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
                
                MessageBox.Show("Cas affecté avec succès", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //valider fermeture
                p.fermeture_succes = true;
                p.Hide();

            }
            else
            {
                MessageBox.Show("Au moins une valeur manque", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void AffecterCas(FormAgendaNursing a, FormPriseSigneVital p)
        {
            a.btnAffecter.Enabled = false;
            if(a.dgvAgenda.CurrentRow.Cells[4].Value.ToString() == "")
            {
                p.idpatient = TrouverId("patient", a.dgvAgenda.CurrentRow.Cells[3].Value.ToString());
                p.txtPatient.Text = a.dgvAgenda.CurrentRow.Cells[3].Value.ToString();
                p.idrecette = int.Parse(a.dgvAgenda.CurrentRow.Cells[0].Value.ToString());
                CompterCasMedecin(p);
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
                p.idpatient = TrouverId("patient", a.dgvAgenda.CurrentRow.Cells[3].Value.ToString());
                p.txtPatient.Text = a.dgvAgenda.CurrentRow.Cells[3].Value.ToString();
                p.idrecette = int.Parse(a.dgvAgenda.CurrentRow.Cells[0].Value.ToString());
                p.idprise = int.Parse(a.dgvAgenda.CurrentRow.Cells[5].Value.ToString());
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
        public void AfficherAgendaEcho(FormAgendaEcho a)
        {
            con.Open();
            try
            {              
                if (a.checkBox1.Checked)
                {
                    cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                    FROM Recette r
                    JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                    JOIN Service s ON rs.idservice = s.idservice
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    JOIN Patient pa ON p.idpatient = pa.idpatient
                    WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                    AND date_operation = @daterecette
                    UNION
                    SELECT r.idrecette, date_operation, p.nompayeur 
                    FROM Recette r 
                    JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                    JOIN Service s ON rs.idservice = s.idservice
                    JOIN Payeur p ON r.idpayeur = p.idpayeur
                    WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                    AND date_operation = @daterecette";
                    cmd = new SqlCommand(cmdtxt, con);
                    cmd.Parameters.AddWithValue("@daterecette", DateTime.Now.ToShortDateString());
                }
                else
                {
                    if (a.cboService.Text == "" && a.txtNom.Text == "")
                    {
                        cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                        FROM Recette r
                        JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                        JOIN Service s ON rs.idservice = s.idservice
                        JOIN Payeur p ON r.idpayeur = p.idpayeur
                        JOIN Patient pa ON p.idpatient = pa.idpatient
                        WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                        AND date_operation BETWEEN @dateDe AND @dateA
                        UNION
                        SELECT r.idrecette, date_operation, p.nompayeur 
                        FROM Recette r 
                        JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                        JOIN Service s ON rs.idservice = s.idservice
                        JOIN Payeur p ON r.idpayeur = p.idpayeur
                        WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    else if (a.cboService.Text != "" && a.txtNom.Text == "")
                    {
                        if (a.cboService.Text == "Radiologie")
                            cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                            FROM Recette r
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            JOIN Patient pa ON p.idpatient = pa.idpatient
                            WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110') 
                            AND date_operation BETWEEN @dateDe AND @dateA
                            UNION
                            SELECT r.idrecette, date_operation, p.nompayeur 
                            FROM Recette r 
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706110') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                        else
                            cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                            FROM Recette r
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            JOIN Patient pa ON p.idpatient = pa.idpatient
                            WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706111') 
                            AND date_operation BETWEEN @dateDe AND @dateA
                            UNION
                            SELECT r.idrecette, date_operation, p.nompayeur 
                            FROM Recette r 
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            WHERE r.statut_caisse = 'OK' AND s.numcompte IN ('706111') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    else if (a.cboService.Text == "" && a.txtNom.Text != "")
                    {
                        cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                        FROM Recette r
                        JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                        JOIN Service s ON rs.idservice = s.idservice
                        JOIN Payeur p ON r.idpayeur = p.idpayeur
                        JOIN Patient pa ON p.idpatient = pa.idpatient
                        WHERE noms LIKE '"+a.txtNom.Text.Replace("'", "")+@"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                        AND date_operation BETWEEN @dateDe AND @dateA
                        UNION
                        SELECT r.idrecette, date_operation, p.nompayeur 
                        FROM Recette r 
                        JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                        JOIN Service s ON rs.idservice = s.idservice
                        JOIN Payeur p ON r.idpayeur = p.idpayeur
                        WHERE p.nompayeur LIKE '" + a.txtNom.Text.Replace("'", "") + @"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706110', '706111') 
                        AND date_operation BETWEEN @dateDe AND @dateA";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    else if (a.cboService.Text != "" && a.txtNom.Text != "")
                    {
                        if (a.cboService.Text == "Radiologie")
                            cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                            FROM Recette r
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            JOIN Patient pa ON p.idpatient = pa.idpatient
                            WHERE noms LIKE '" + a.txtNom.Text.Replace("'", "") + @"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706110') 
                            AND date_operation BETWEEN @dateDe AND @dateA
                            UNION
                            SELECT r.idrecette, date_operation, p.nompayeur 
                            FROM Recette r 
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            WHERE p.nompayeur LIKE '" + a.txtNom.Text.Replace("'", "") + @"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706110') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                        else
                            cmdtxt = @"SELECT r.idrecette, date_operation, noms 
                            FROM Recette r
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            JOIN Patient pa ON p.idpatient = pa.idpatient
                            WHERE noms LIKE '" + a.txtNom.Text.Replace("'", "") + @"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706111') 
                            AND date_operation BETWEEN @dateDe AND @dateA
                            UNION
                            SELECT r.idrecette, date_operation, p.nompayeur 
                            FROM Recette r 
                            JOIN RecetteService rs ON r.idrecette = rs.idrecette 
                            JOIN Service s ON rs.idservice = s.idservice
                            JOIN Payeur p ON r.idpayeur = p.idpayeur
                            WHERE p.nompayeur LIKE '" + a.txtNom.Text.Replace("'", "") + @"%' AND r.statut_caisse = 'OK' AND s.numcompte IN ('706111') 
                            AND date_operation BETWEEN @dateDe AND @dateA";
                        cmd = new SqlCommand(cmdtxt, con);
                    }
                    cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                    cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                }
                dr = cmd.ExecuteReader();
                a.dgvPatient.Rows.Clear();
                a.dgvService.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvPatient.Rows.Add();
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[0].Value = a.dgvPatient.RowCount;
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    a.dgvPatient.Rows[a.dgvPatient.RowCount - 1].Cells[3].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void AfficherServiceAgenda(FormAgendaEcho a)
        {
            con.Open();
            try
            {
                cmdtxt = @"SELECT rs.idservice, nomservice, servi 
                FROM RecetteService rs
                JOIN Recette r ON r.idrecette = rs.idrecette 
                JOIN Service s ON rs.idservice = s.idservice
                WHERE r.idrecette = @idrecette AND s.numcompte IN ('706110', '706111')";
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@idrecette", Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[1].Value));
                dr = cmd.ExecuteReader();
                a.dgvService.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvService.Rows.Add();
                    a.dgvService.Rows[a.dgvService.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvService.Rows[a.dgvService.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvService.Rows[a.dgvService.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ServirCasEcho(FormAgendaEcho a)
        {
            a.btnServir.Enabled = false;
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("UPDATE RecetteService SET servi = 'OK', idutilisateur = @idutilisateur WHERE idrecette = @idrecette AND idservice = @idservice", con);
                cmd.Parameters.AddWithValue("@idrecette", Convert.ToInt32(a.dgvPatient.CurrentRow.Cells[1].Value));
                cmd.Parameters.AddWithValue("@idservice", Convert.ToInt32(a.dgvService.CurrentRow.Cells[0].Value));
                cmd.Parameters.AddWithValue("@idutilisateur", Convert.ToInt32(a.dgvService.CurrentRow.Cells[0].Value));
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
                MessageBox.Show("Servi avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            //Recharger les services
            AfficherServiceAgenda(a);
        }
        #endregion

        #region BON_EXAMEN
        public void BonExamen(FormRenseignement r, FormPriseSigneVital exa)
        {
            exa.txtPatient.Text = r.txtPatient.Text;
            exa.idmedecin = r.idmedecin;
            exa.idrecette = r.idconsultation;
            exa.dgvSigne.Columns[2].Visible = false;
            exa.btnQuitter.Visible = false;
            exa.MaximizeBox = false;
            exa.MinimizeBox = false;
            exa.MaximumSize = exa.Size;
            exa.Text = "SSM - Bon d'examens";
            exa.ShowDialog();
            r.Close();
        }
        public void MesConsultations(FormPriseSigneVital exa, FormConsultation c)
        {
            //exa.txtMedecin.Text = TrouverNom("medecin", exa.idmedecin);
            c.MaximizeBox = false;
            c.MinimizeBox = false;
            c.MaximumSize = c.Size;
            c.MinimumSize = c.Size;
            c.idmedecin = exa.idmedecin;
            c.btnQuitter.Visible = false;
            c.Text = "SSM - Mes consultations";
            c.ShowDialog();
            if (c.fermeture_succes)
            {
                exa.idrecette = c.idconsultation;
                exa.txtPatient.Text = TrouverNom("patient", c.idpatient);
                ChargerExamen(exa);
            }
            else exa.Close();
            c.Close();
        }
        public void ValiderLigne(FormPriseSigneVital exa)
        {
            //exa.ajoutvalide = true;           
            //if (exa.dgv1.RowCount > 0)
            //{
            //    if (exa.cboService.Enabled)
            //    {
            //        for (int i = 0; i < exa.dgv1.RowCount; i++)
            //        {
            //            if (exa.dgv1.Rows[i].Cells[1].Value.ToString() == exa.cboService.Text)
            //            {
            //                MessageBox.Show("Cet examen est déjà affecté à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                i += exa.dgv1.RowCount;
            //                exa.ajoutvalide = false;
            //            }
            //        }
            //    }
            //    if (exa.ajoutvalide) AjouterLigne(exa);
            //}
            //else AjouterLigne(exa);
        }
        public void AjouterLigne(FormPriseSigneVital exa)
        {
            //if (!exa.cboService.Enabled)
            //{
            //    if (exa.txtLibelle.Text != "")
            //    {
            //        exa.dgv1.CurrentRow.Cells[2].Value = exa.txtLibelle.Text;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Aucun libellé n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    exa.txtLibelle.Text = "";
            //    exa.txtLibelle.Focus();
            //}
            //else
            //{
            //    exa.dgv1.Rows.Add();
            //    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[0].Value = exa.dgv1.RowCount;
            //    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[1].Value = exa.cboService.Text;
            //}           
        }
        
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
                cmd = new SqlCommand("select SigneVital.idsigne, nomsigne, valeur, unite from ValeurSigneVitaux, SigneVital where ValeurSigneVitaux.idsigne = SigneVital.idsigne AND ValeurSigneVitaux.idprise = "+idprise+"", con);
                dr = cmd.ExecuteReader();
                id = 0;
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
                FormUtilisateur u = new FormUtilisateur();
                u.cboPoste.Items.Clear();
                u.cboPoste.Items.Add("médecin");
                u.btnExit.Visible = false;
                u.nouveau_medecin = true;
                u.ShowDialog();
                if (u.fermeture_succes)
                {
                    m.idmedecin = NouveauID("medecin");
                    m.utilisateur = u.txtSpecification.Text;
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Medecin values (@id, @nom, @numordre, @tel, @util)", con);
                        cmd.Parameters.AddWithValue("@id", m.idmedecin);
                        cmd.Parameters.AddWithValue("@nom", m.txtNom.Text);
                        cmd.Parameters.AddWithValue("@numordre", m.txtNumOrdre.Text);
                        cmd.Parameters.AddWithValue("@tel", m.txtTel.Text);
                        cmd.Parameters.AddWithValue("@util", m.utilisateur);
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
                    Annuler(m);
                }
                u.Close();
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
        public string Utilisateur(int idmedecin)
        {
            chaine = "";
            try
            {
                con.Open();
                cmd = new SqlCommand("select utilisateur from Medecin where idmedecin = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                dr = cmd.ExecuteReader();
                dr.Read();
                chaine = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return chaine;
        }
        #endregion

        #region CHAT_MEDECIN
        public void Annuler(FormMedecinMessage m)
        {
            m.cboMedecin.DropDownStyle = ComboBoxStyle.DropDown;
            m.cboMedecin.SelectedText = "";
            m.cboMedecin.DropDownStyle = ComboBoxStyle.DropDownList;
            m.txtObjet.Text = "";
            m.txtMessage.Text = "";
            m.cboMedecin.Select();
        }
        public void ModifierStatut(FormMedecinMessage m)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update MedecinMessage set statutmsg = @statut where idmessage = @id", con);
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
        public void Enregistrer(FormMedecinMessage m)
        {
            if(m.btnEnvoyer.Text == "Envoyer")
            {
                m.idmessage = NouveauID("message");
                if (m.repondre) m.txtObjet.Text = "Réponse: " + m.txtObjet.Text;
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into MedecinMessage values (@id, @exp, @dest, @objet, @msg, @date_jour, @heure, @statut)", con);
                    cmd.Parameters.AddWithValue("@id", m.idmessage);
                    cmd.Parameters.AddWithValue("@exp", m.idexpediteur);
                    cmd.Parameters.AddWithValue("@dest", m.iddestinataire);
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
                    cmd = new SqlCommand("update MedecinMessage set destinataire = @dest, objet = @objet, msg = @msg, date_jour = @date_jour, heure= @heure where idmessage = @id", con);
                    cmd.Parameters.AddWithValue("@id", m.idmessage);
                    cmd.Parameters.AddWithValue("@dest", m.iddestinataire);
                    cmd.Parameters.AddWithValue("@objet", m.txtObjet.Text);
                    cmd.Parameters.AddWithValue("@msg", m.txtMessage.Text);
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
                cmd = new SqlCommand("select nommedecin from Medecin where idmedecin <> @id", con);
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
        public void NouveauMessage(FormMedecinHistoChat c, FormMedecinMessage m)
        {
            m.idexpediteur = c.idexpediteur;
            m.cboMedecin.Select();
            m.ShowDialog();
            Afficher(c);
        }
        public void Modifier(FormMedecinHistoChat c, FormMedecinMessage m)
        {
            if (c.dgvMessage.CurrentRow.Cells[1].Value.ToString() == c.idexpediteur.ToString())
            {
                m.idexpediteur = c.idexpediteur;
                m.idmessage = c.idmessage;
                m.iddestinataire = c.iddestinataire;
                m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[3].Value.ToString();
                m.txtObjet.Enabled = false;
                m.txtMessage.Text = c.dgvMessage.CurrentRow.Cells[4].Value.ToString();
                m.cboMedecin.Items.Add(TrouverNom("medecin", m.iddestinataire));
                m.modification = true;
                m.btnEnvoyer.Text = "Modifier";
                m.ShowDialog();
                Afficher(c);
            }
            else
                MessageBox.Show("Vous ne pouvez pas modifier un message dont vous n'êtes pas expéditeur", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.btnModifier.Enabled = false;
        }
        public void Repondre(FormMedecinHistoChat c, FormMedecinMessage m)
        {
            if (c.dgvMessage.CurrentRow.Cells[1].Value.ToString() != c.idexpediteur.ToString())
            {
                m.idexpediteur = c.iddestinataire;
                m.iddestinataire = int.Parse(c.dgvMessage.CurrentRow.Cells[1].Value.ToString());
                m.repondre = true;
                m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[3].Value.ToString();
                m.txtMessage.Focus();
                m.ShowDialog();
                Afficher(c);
            }
            else
                MessageBox.Show("Vous ne pouvez pas répondre à un message dont vous êtes expéditeur", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            c.btnRepondre.Enabled = false;
        }
        public void VoirMessage(FormMedecinHistoChat c, FormMedecinMessage m)
        {
            m.lblTitre.Text = "Lire le message";
            m.txtMessage.Text = c.dgvMessage.CurrentRow.Cells[4].Value.ToString();
            m.txtObjet.Text = c.dgvMessage.CurrentRow.Cells[3].Value.ToString();
            m.txtMessage.Enabled = false;
            m.txtObjet.Enabled = false;
            m.label1.Visible = false;
            m.cboMedecin.Visible = false;
            m.btnAnnuler.Enabled = false;
            m.btnEnvoyer.Enabled = false;
            m.idmessage = c.idmessage;
            m.ShowDialog();
            ModifierStatut(m);
            Afficher(c);
        }
        public ComboBox DateMessage(FormMedecinHistoChat c)
        {
            var combo = new ComboBox();
            con.Open();
            cmd = new SqlCommand("select distinct date_jour from MedecinMessage where date_jour between @dateDe and @dateA and expediteur = @exp or date_jour between @dateDe and @dateA and destinataire = @dest", con);
            cmd.Parameters.AddWithValue("@dateDe", c.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", c.dtpDateA.Text);
            cmd.Parameters.AddWithValue("@exp", c.idexpediteur);
            cmd.Parameters.AddWithValue("@dest", c.idexpediteur);
            dr = cmd.ExecuteReader();
            combo.Items.Clear();
            while (dr.Read())
	        {
	           combo.Items.Add(dr[0].ToString());
	        }
            con.Close();
            return combo;
        }
        public void Afficher(FormMedecinHistoChat c)
        {
            var combo = new ComboBox();
            c.dgvMessage.Rows.Clear();
            foreach (var item in DateMessage(c).Items)
            {
                c.dgvMessage.Rows.Add();
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Selected = false; //desélectionne
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[1].Value = "";
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[4].Value = item;
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
                c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].DefaultCellStyle.BackColor = Color.Silver;
                con.Open();
                cmd = new SqlCommand("select idmessage, expediteur, objet, msg, heure, destinataire, statutmsg from MedecinMessage where expediteur = @exp and date_jour= '" + item + "' or destinataire = @dest and date_jour= '" + item + "'", con);
                cmd.Parameters.AddWithValue("@exp", c.idexpediteur);
                cmd.Parameters.AddWithValue("@dest", c.idexpediteur);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    c.dgvMessage.Rows.Add();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Selected = false;
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[7].Value = dr[6].ToString();
                    if (c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].Cells[7].Value.ToString() == "Non lu")
                        c.dgvMessage.Rows[c.dgvMessage.RowCount - 1].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
                con.Close();
            }
            if (c.dgvMessage.RowCount != 0)
            {
                for (int i = 0; i < c.dgvMessage.RowCount; i++)
                {
                    if (c.dgvMessage.Rows[i].Cells[1].Value.ToString() != "")
                    {
                        if (c.dgvMessage.Rows[i].Cells[1].Value.ToString() == c.idexpediteur.ToString())
                            c.dgvMessage.Rows[i].Cells[2].Value = "Vous à \n" + "Dr " + TrouverNom("medecin", int.Parse(c.dgvMessage.Rows[i].Cells[6].Value.ToString()));
                        else
                            c.dgvMessage.Rows[i].Cells[2].Value = "Dr "+TrouverNom("medecin", int.Parse(c.dgvMessage.Rows[i].Cells[1].Value.ToString()))+ " à \nVous";
                    }
                }
            }
        }
        #endregion       
    }
    public class BonExamen
    {
        public string numexamen { get; set; }
        public string examen { get; set; }
    }
    public class AgendaPatient
    {
        public int id { get; set; }
        public string cas { get; set; }
        public string patient { get; set; }
        public string medecin { get; set; }
        public string caisse { get; set; }
        public string signesvit { get; set; }
        public string consultation { get; set; }
        public string dateentree { get; set; }
    }
    public class DossierPatient
    {
        public string id { get; set; }
        public string libelle { get; set; }
    }
}