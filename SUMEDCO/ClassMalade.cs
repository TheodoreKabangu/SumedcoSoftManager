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
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString2"].ConnectionString;
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
                case "abonne": cmdtxt = "select max(idabonne) from Abonne"; break;
                case "patient": cmdtxt = "select max(idpatient) from Patient"; break;
                case "consultation": cmdtxt = "select max(idconsultation) from Consultation"; break;
                case "renseignement": cmdtxt = "select max(id) from Renseignement"; break;
                case "prescription": cmdtxt = "select max(idpresc) from Prescription"; break;
                case "service": cmdtxt = "select max(idservice) from ServiceDemande"; break;
                case "medecin": cmdtxt = "select max(idmedecin) from Medecin"; break;
                case "maladie": cmdtxt = "select max(idmaladie) from Maladie"; break;
                case "message": cmdtxt = "select max(idmessage) from MedecinMessage"; break;
                case "agenda": cmdtxt = "select max(id) from LigneAgendaPatient"; break;
                case "sv": cmdtxt = "select max(id) from LigneSigneVital"; break;
                case "svc": cmdtxt = "select max(id) from SigneVitalConsultation"; break;
                case "s": cmdtxt = "select max(idsigne) from SigneVital"; break;
                case "exa": cmdtxt = "select max(idresultat) from ResultatExamen"; break;
                case "maladiediagnostic": cmdtxt = "select max(id) from MaladieConsultation"; break;
                case "rdv": cmdtxt = "select max(idrendezvous) from Rendezvous"; break;
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
                case "maladie": cmdtxt = "select idmaladie from Maladie where nommaladie = @nom"; break;
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
                case "casconsultation": cmdtxt = "select cas from LigneAgendaPatient where idpatient = @id"; break;
                case "maladie": cmdtxt = "select nommaladie from Maladie where idmaladie= @id"; break;
                case "signevital": cmdtxt = "select nomsigne from SigneVital where idsigne= @id"; break;
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
        public void AfficherSousForm(MFormInfirmerie i, FormAgenda childForm)
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
            childForm.btnSigne.Enabled = true;
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
        public void AfficherSousForm(MFormInfirmerie r, FormBonRecette childForm)
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
        public void AfficherSousForm(MFormConsultation c, FormConsultation childForm)
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
        public void AfficherSousForm(MFormConsultation c, FormAgenda childForm)
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
            childForm.btnSigne.Enabled = true;
            childForm.btnConsulter.Enabled = true;
            childForm.idmedecin = c.idmedecin;
            childForm.Show();
        }
        public void AfficherSousForm(MFormConsultation c, FormExamen childForm)
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
            childForm.cboCatService.Enabled = false;
            childForm.cboService.Enabled = false;
            childForm.btnNouveau.Enabled = false;
            childForm.idmedecin = c.idmedecin;
            childForm.Show();
        }
        public void AfficherSousForm(MFormConsultation c, FormPrescription childForm)
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
        public void AfficherPourDate(FormConsultation c)
        {
            con.Open();
            try
            {
                if (c.idmedecin != 0)
                {
                    cmd = new SqlCommand("select * from Consultation where date_consultation between @dtpdateDe and @dtpdateA and idmedecin= @idmedecin", con);
                    cmd.Parameters.AddWithValue("@idmedecin", c.idmedecin);
                }
                else
                {
                    cmd = new SqlCommand("select * from Consultation where date_consultation between @dtpdateDe and @dtpdateA", con);
                }
                cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                c.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPatient.Rows.Add();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[3].Value = dr[4].ToString();                  
                }
            }
            catch (Exception ex)
            {MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            for (int i = 0; i < c.dgvPatient.RowCount; i++)
            {
                c.dgvPatient.Rows[i].Cells[4].Value = TrouverNom("patient", int.Parse(c.dgvPatient.Rows[i].Cells[3].Value.ToString()));
            }
        }
        public void AfficherPourPatient(FormConsultation c)
        {
            con.Open();
            try
            {
                if (c.idmedecin != 0)
                {
                    cmd = new SqlCommand("select * from Consultation, Patient where date_consultation between @dtpdateDe and @dtpdateA and idmedecin= @idmedecin and Consultation.idpatient = Patient.idpatient and noms like '" + c.txtPatient.Text + "%'", con);
                    cmd.Parameters.AddWithValue("@idmedecin", c.idmedecin);
                }
                else
                {
                    cmd = new SqlCommand("select * from Consultation, Patient where date_consultation between @dtpdateDe and @dtpdateA and Consultation.idpatient = Patient.idpatient and noms like '" + c.txtPatient.Text + "%'", con);
                }
                cmd.Parameters.AddWithValue("@dtpdateDe", c.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dtpdateA", c.dtpDateA.Text);
                
                dr = cmd.ExecuteReader();
                c.dgvPatient.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvPatient.Rows.Add();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvPatient.Rows[c.dgvPatient.RowCount - 1].Cells[3].Value = dr[4].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            for (int i = 0; i < c.dgvPatient.RowCount; i++)
            {
                c.dgvPatient.Rows[i].Cells[4].Value = TrouverNom("patient", int.Parse(c.dgvPatient.Rows[i].Cells[3].Value.ToString()));
            }
        }
        public void Afficher(FormConsultation c)
        {
            if (c.txtPatient.Text == "")
                AfficherPourDate(c);
            else if (c.txtPatient.Text != "")
                AfficherPourPatient(c);
        }
        public void SigneVitalConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select SigneVital.idsigne, nomsigne, valeur from SigneVital, SigneVitalConsultation where SigneVital.idsigne = SigneVitalConsultation.idsigne and idconsultation = @id", con);
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
        public void VoirSigneVitalConsultation(int idconsultation, FormSigneVital sv)
        {
            if(!rubriques.Contains("signe vital"))
            {
                con.Open();
                try
                {
                    sv.idconsultation = idconsultation;
                    cmd = new SqlCommand("select id, SigneVital.idsigne, nomsigne, valeur from SigneVital, SigneVitalConsultation where SigneVital.idsigne = SigneVitalConsultation.idsigne and idconsultation = @id", con);
                    cmd.Parameters.AddWithValue("@id", idconsultation);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        sv.dgvSigne.Rows.Add();
                        sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                sv.motif = "consultation";
                sv.MaximizeBox = false;
                sv.MinimizeBox = false;
                sv.MaximumSize = sv.Size;
                sv.MinimumSize = sv.Size;
                sv.panel2.Visible = true;
                sv.lblNum.Visible = true;
                sv.lblNom.Visible = true;
                sv.btnValider.Enabled = false;
                sv.btnMAJ.Enabled = true;
                sv.Text = "SSM - Signes Vitaux";
                rubriques.Add("signe vital");
                sv.Show();
            }
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
        public void VoirRenseignement(int idconsultation, FormConsulter c, string label)
        {
            con.Open();
            try
            {
                c.idconsultation = idconsultation;
                cmd = new SqlCommand("select id, libelle from Renseignement where label= @label and idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@label", label);
                cmd.Parameters.AddWithValue("@id", idconsultation);
                dr = cmd.ExecuteReader();
                switch (label)
                {
                    case "plainte":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvPlainte.Rows.Add();
                                c.dgvPlainte.Columns[0].Visible = false;
                                c.dgvPlainte.Rows[c.dgvPlainte.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvPlainte.Rows[c.dgvPlainte.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[1];
                            c.btnHisto2.Enabled = false;
                            c.btnModifierPlainte.Enabled = true;
                            c.btnSupprimerPlainte.Enabled = true;
                        }
                        break;
                    case "historique":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvHisto.Rows.Add();
                                c.dgvHisto.Columns[0].Visible = false;
                                c.dgvHisto.Rows[c.dgvHisto.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvHisto.Rows[c.dgvHisto.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[2];
                            c.btnAntecedent2.Enabled = false;
                            c.btnModifierHisto.Enabled = true;
                            c.btnSupprimerHisto.Enabled = true;
                        }
                        break;
                    case "antécédent":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvAntecedent.Rows.Add();
                                c.dgvAntecedent.Columns[0].Visible = false;
                                c.dgvAntecedent.Rows[c.dgvAntecedent.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvAntecedent.Rows[c.dgvAntecedent.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[3];
                            c.btnComplement2.Enabled = false;
                            c.btnModifierAntecedent.Enabled = true;
                            c.btnSupprimerAntecedent.Enabled = true;
                        }
                        break;
                    case "complément":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvComplement.Rows.Add();
                                c.dgvComplement.Columns[0].Visible = false;
                                c.dgvComplement.Rows[c.dgvComplement.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvComplement.Rows[c.dgvComplement.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[4];
                            c.btnExamPhys.Enabled = false;
                            c.btnModifierComplement.Enabled = true;
                            c.btnSupprimerComplement.Enabled = true;
                        }
                        break;
                    case "examen physique":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvExamPhys.Rows.Add();
                                c.dgvExamPhys.Columns[0].Visible = false;
                                c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                chaine = dr[1].ToString();
                                c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[1].Value = chaine.Substring(0, chaine.IndexOf(":"));
                                c.dgvExamPhys.Rows[c.dgvExamPhys.RowCount - 1].Cells[2].Value = chaine.Substring(chaine.IndexOf(":") + 2);
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[5];
                            c.btnPrediagnostic2.Enabled = false;
                            c.btnModifierExamPhys.Enabled = true;
                            c.btnSupprimerExamPhys.Enabled = true;
                        }
                        break;
                    case "prédiagnostic":
                        if(!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvPrediagnostic.Rows.Add();
                                c.dgvPrediagnostic.Columns[0].Visible = false;
                                c.dgvPrediagnostic.Rows[c.dgvPrediagnostic.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvPrediagnostic.Rows[c.dgvPrediagnostic.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[6];
                            c.btnLabo2.Enabled = false;
                            c.btnModifierPrediag.Enabled = true;
                            c.btnSupprimerPrediag.Enabled = true;
                        }
                        break;
                    case "autre prescription":
                        if (!rubriques.Contains(label))
                        {
                            while (dr.Read())
                            {
                                c.dgvAutrePresc.Rows.Add();
                                c.dgvAutrePresc.Columns[0].Visible = false;
                                c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[0].Value = dr[0].ToString();
                                c.dgvAutrePresc.Rows[c.dgvAutrePresc.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            };
                            c.tabControl1.SelectedTab = c.tabControl1.TabPages[10];
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
            if(!rubriques.Contains(label))
            {
                rubriques.Add(label);
                c.motif = "modifier";
                c.panel2.Enabled = false;
                c.Show();
            }
        }
        public void VoirResultatExamenLabo(int idconsultation, FormConsulter c, string label)
        {
            if (!rubriques.Contains(label))
            {
                con.Open();
                try
                {
                    c.idconsultation = idconsultation;
                    cmd = new SqlCommand("select idresultat, nomexamen, resultat from ResultatExamen where idconsultation = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idconsultation);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c.dgvLabo.Rows.Add();
                        c.dgvLabo.Columns[0].Visible = false;
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        c.dgvLabo.Rows[c.dgvLabo.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                rubriques.Add(label);
                c.motif = "modifier";
                c.btnDiagnostic2.Enabled = false;
                c.panel2.Enabled = false;
                c.tabControl1.SelectedTab = c.tabControl1.TabPages[7];
                c.btnModifierBonLabo.Enabled = true;
                c.btnSupprimerBonLabo.Enabled = true;
                c.Show();
            }
        }
        public void VoirMaladieDiagnostic(int idconsultation, FormConsulter c, string label)
        {
            if (!rubriques.Contains(label))
            {
                con.Open();
                try
                {
                    c.idconsultation = idconsultation;
                    cmd = new SqlCommand("select id, nommaladie, observation from MaladieConsultation, Maladie where MaladieConsultation.idmaladie = Maladie.idmaladie and idconsultation = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idconsultation);
                    dr = cmd.ExecuteReader();
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

                rubriques.Add(label);
                c.motif = "modifier";
                c.btnPrescription2.Enabled = false;
                c.panel2.Enabled = false;
                c.tabControl1.SelectedTab = c.tabControl1.TabPages[8];
                c.btnModifierDiagno.Enabled = true;
                c.btnSupprimerDiagno.Enabled = true;
                c.Show();
            }
        }
        public void VoirPrescription(int idconsultation, FormConsulter c, string label)
        {
            if (!rubriques.Contains(label))
            {
                con.Open();
                try
                {
                    c.idconsultation = idconsultation;
                    cmd = new SqlCommand("select idpresc, produit, qteprescrite, detail from Prescription where idconsultation = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idconsultation);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        c.dgvPresc.Rows.Add();
                        c.dgvPresc.Columns[0].Visible = false;
                        c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[2].Value = dr[2].ToString();
                        c.dgvPresc.Rows[c.dgvPresc.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();

                rubriques.Add(label);
                c.motif = "modifier";
                c.panel2.Enabled = false;
                c.tabControl1.SelectedTab = c.tabControl1.TabPages[10];
                c.btnModifierPresc.Enabled = true;
                c.btnSupprimerPresc.Enabled = true;
                c.Show();
            }
        }
        public void ResultatExamenConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select idresultat, nomexamen, resultat from ResultatExamen where idconsultation = @id", con);
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
                cmd = new SqlCommand("select id, nommaladie, observation from MaladieConsultation, Maladie where MaladieConsultation.idmaladie = Maladie.idmaladie and idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void PrescriptionConsultation(FormConsultationDossier cd)
        {
            con.Open();
            try
            {
                id = 0;
                cmd = new SqlCommand("select idpresc, produit, qteprescrite, detail from Prescription where idconsultation = @id", con);
                cmd.Parameters.AddWithValue("@id", cd.idconsultation);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    cd.dgvDetail.Rows.Add();
                    id++;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = id;
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = string.Format("{0}: {1}: {2}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
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
            cd.idmedecin = c.idmedecin;
            cd.idconsultation = int.Parse(c.dgvPatient.CurrentRow.Cells[0].Value.ToString());
            cd.idpatient = int.Parse(c.dgvPatient.CurrentRow.Cells[3].Value.ToString());
            cd.patient = TrouverNom("patient", cd.idpatient);
            cd.medecin = TrouverNom("medecin", cd.idmedecin);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "SIGNES VITAUX";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            SigneVitalConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PLAINTES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "plainte");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "HISTORIQUE DE LA MALADIE";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "historique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "ANTECEDENTS MEDICAUX";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "antécédent");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "COMPLEMENT D'ANAMNESE";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "complément");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PHYSIQUES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "examen physique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PREDIAGNOSTIC";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "prédiagnostic");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS LABO & RESULTATS";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            ResultatExamenConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "MALADIES TROUVEES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            MaladieConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS PRODUITS";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            PrescriptionConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "autre prescription");

            cd.Text = "SSM - Dossier médical " + cd.patient;
            cd.ShowDialog();
        }
        public void DetailsConsultation(FormConsultationDossier cd)
        {
            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "SIGNES VITAUX";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            SigneVitalConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PLAINTES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "plainte");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "HISTORIQUE DE LA MALADIE";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "historique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "ANTECEDENTS MEDICAUX";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "antécédent");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "COMPLEMENT D'ANAMNESE";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "complément");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS PHYSIQUES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "examen physique");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PREDIAGNOSTIC";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "prédiagnostic");

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "EXAMENS LABO & RESULTATS";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            ResultatExamenConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "MALADIES TROUVEES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            MaladieConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS PRODUITS";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            PrescriptionConsultation(cd);

            cd.dgvDetail.Rows.Add();
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[0].Value = "";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[2].Value = "PRESCRIPTIONS AUTRES";
            cd.dgvDetail.Rows[cd.dgvDetail.RowCount - 1].Cells[3].Value = "Modifier";
            RenseignementConsultation(cd, "autre prescription");
        }
        public void ModifierDossier(FormConsultationDossier c)
        {
            switch (c.dgvDetail.CurrentRow.Cells[2].Value.ToString())
            {
                case "SIGNES VITAUX": VoirSigneVitalConsultation(c.idconsultation, new FormSigneVital());
                    break;
                case "PLAINTES": VoirRenseignement(c.idconsultation, new FormConsulter(), "plainte");
                    break;
                case "HISTORIQUE DE LA MALADIE": VoirRenseignement(c.idconsultation, new FormConsulter(), "historique");
                    break;
                case "ANTECEDENTS MEDICAUX": VoirRenseignement(c.idconsultation, new FormConsulter(), "antécédent");
                    break;
                case "COMPLEMENT D'ANAMNESE": VoirRenseignement(c.idconsultation, new FormConsulter(), "complément");
                    break;
                case "EXAMENS PHYSIQUES": VoirRenseignement(c.idconsultation, new FormConsulter(), "examen physique");
                    break;
                case "PREDIAGNOSTIC": VoirRenseignement(c.idconsultation, new FormConsulter(), "prédiagnostic");
                    break;
                case "EXAMENS LABO & RESULTATS": VoirResultatExamenLabo(c.idconsultation, new FormConsulter(), "examen labo");
                    break;
                case "MALADIES TROUVEES": VoirMaladieDiagnostic(c.idconsultation, new FormConsulter(), "diagnostic");
                    break;
                case "PRESCRIPTIONS FAITES":
                    VoirPrescription(c.idconsultation, new FormConsulter(), "prescription");
                    VoirRenseignement(c.idconsultation, new FormConsulter(), "autre prescription");
                    break;
                default: MessageBox.Show("Clquez sur <<Modifier>> pour mettre à jour la rubrique concernée", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
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
        
        DataGridView dgv = new DataGridView();
        public void RecupererSigneVital(FormRenseignement r)
        {
            dgv.AllowUserToAddRows = false;
            dgv.Columns.Clear();
            dgv.Columns.Add("column0", "signe");
            dgv.Columns.Add("column1", "valeur");
            con.Open();
            try
            {
                cmd = new SqlCommand("select idsigne, valeur from LigneSigneVital where idligneagenda= @id", con);
                cmd.Parameters.AddWithValue("@id", r.idligneagenda);
                dr = cmd.ExecuteReader();
                dgv.Rows.Clear();
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void AjouterSigneVitalConsultation(FormConsulter r)
        {
            for (int i = 0; i < r.dgvSigneVital.RowCount; i++)
            {
                r.idsigne = NouveauID("svc");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into SigneVitalConsultation values (@id, @idconsultation, @idsigne, @valeur)", con);
                    cmd.Parameters.AddWithValue("@id", r.idsigne);
                    cmd.Parameters.AddWithValue("@idconsultation", r.idconsultation);
                    cmd.Parameters.AddWithValue("@idsigne", r.dgvSigneVital.Rows[i].Cells[1].Value.ToString());
                    cmd.Parameters.AddWithValue("@valeur", r.dgvSigneVital.Rows[i].Cells[3].Value.ToString());
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
        public void EnregistrerConsultation(FormConsulter r)
        {
            r.idconsultation = NouveauID("consultation");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (r.txtRepondant.Enabled)
                {
                    cmd = new SqlCommand("insert into Consultation values (@id, @date, @type, @idmedecin, @idpatient, @repondant, @lien)", con);
                    cmd.Parameters.AddWithValue("@repondant", r.txtRepondant.Text);
                    cmd.Parameters.AddWithValue("@lien", r.cboLienRepondant.Text);
                }
                else
                    cmd = new SqlCommand("insert into Consultation(idconsultation, date_consultation, type, idmedecin, idpatient) values (@id, @date, @type, @idmedecin, @idpatient)", con);

                cmd.Parameters.AddWithValue("@id", r.idconsultation);
                cmd.Parameters.AddWithValue("@date", r.dtpDate.Value);
                cmd.Parameters.AddWithValue("@type", r.type_consultation);
                cmd.Parameters.AddWithValue("@idmedecin", r.idmedecin);
                cmd.Parameters.AddWithValue("@idpatient", r.idpatient);
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
            AjouterSigneVitalConsultation(r);
            //ValiderStatutConsultation(r.idligneagenda);
            r.btnRendezVous.Enabled = true;
            r.tabControl1.SelectedTab = r.tabControl1.TabPages[1];
        }
        public void ExamenPhysique(FormConsulter r, FormExamenPhysique ex)
        {
            foreach (string item in ex.cboExamenPhysique.Items)
            {
                ex.dgv.Rows.Add();
                ex.dgv.Rows[ex.dgv.RowCount - 1].Cells[0].Value = ex.dgv.RowCount;
                ex.dgv.Rows[ex.dgv.RowCount - 1].Cells[1].Value = item;
            }
            ex.Text = "SSM - Examens physiques";
            ex.ShowDialog();
            if (ex.fermeture_succes)
            {
                for (int i = 0; i < ex.dgv.RowCount; i++)
                {
                    if (ex.dgv.Rows[i].Selected)
                    {
                        r.dgvExamPhys.Rows.Add();
                        r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount - 1].Cells[0].Value = r.dgvExamPhys.RowCount;
                        r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount - 1].Cells[1].Value = ex.dgv.Rows[i].Cells[1].Value.ToString();
                        r.dgvExamPhys.Rows[r.dgvExamPhys.RowCount - 1].Cells[2].Value = "RAS";
                    }

                }
            }
            ex.Close();
        }
        public void AjouterRenseignement(DataGridView dgv, string label, int idconsultation)
        {
            if (dgv.RowCount != 0)
            {
                id = 0;
                if (label != "examen physique")
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        id = NouveauID("renseignement");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into Renseignement(id,label,idconsultation,libelle) values (@id, @label, @idconsultation, @libelle)", con);
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
                }
                else
                {
                    for (int i = 0; i < dgv.RowCount; i++)
                    {
                        id = NouveauID("renseignement");
                        con.Open();
                        SqlTransaction tx = con.BeginTransaction();
                        try
                        {
                            cmd = new SqlCommand("insert into Renseignement(id,label,idconsultation,libelle) values (@id, @label, @idconsultation, @libelle)", con);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@label", label);
                            cmd.Parameters.AddWithValue("@idconsultation", idconsultation);
                            cmd.Parameters.AddWithValue("@libelle", string.Format("{0}: {1}", dgv.Rows[i].Cells[1].Value.ToString(), dgv.Rows[i].Cells[2].Value.ToString()));
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
                MessageBox.Show("Enregistré(s) avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgv.Rows.Clear();
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterExamenLabo(FormConsulter exa)
        {
            if (exa.dgvLabo.RowCount != 0)
            {
                for (int i = 0; i < exa.dgvLabo.RowCount; i++)
                {
                    exa.idresultat = NouveauID("exa");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ResultatExamen values(@idresult, @idconsult, @examen, @resultat)", con);
                        cmd.Parameters.AddWithValue("@idresult", exa.idresultat);
                        cmd.Parameters.AddWithValue("@idconsult", exa.idconsultation);
                        cmd.Parameters.AddWithValue("@examen", exa.dgvLabo.Rows[i].Cells[1].Value.ToString());
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
                GenererBonExamen(exa, new FormImpression());
                exa.dgvLabo.Rows.Clear();
            }
            else MessageBox.Show("Aucune ligne de bon labo n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                for (int i = 0; i < m.dgv.RowCount; i++)
                {
                    if (m.dgv.Rows[i].Selected)
                    {
                        c.dgvDiagnostic.Rows.Add();
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[0].Value = c.dgvDiagnostic.RowCount;
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[1].Value = m.dgv.Rows[i].Cells[1].Value.ToString();
                        c.dgvDiagnostic.Rows[c.dgvDiagnostic.RowCount - 1].Cells[2].Value = "RAS";
                    }

                }
            }
            m.Close();
        }
        public void AjouterMaladieDiagnostic(FormConsulter c)
        {
            if (c.dgvDiagnostic.RowCount != 0)
            {
                for (int i = 0; i < c.dgvDiagnostic.RowCount; i++)
                {
                    c.idmaladie = NouveauID("maladiediagnostic");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into MaladieConsultation values (@id, @idmaladie, @idconsultation, @observation)", con);
                        cmd.Parameters.AddWithValue("@id", c.idmaladie);
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
        public void Prescrire(FormConsulter c, FormFactureProduit2 f)
        {
            f.ShowDialog();
            if (f.fermeture_succes)
            {
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
        public void AjouterPrescription(FormConsulter p)
        {
            if (p.dgvPresc.RowCount > 0)
            {
                for (int i = 0; i < p.dgvPresc.RowCount; i++)
                {
                    p.idprescription = NouveauID("prescription");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Prescription values (@id, @produit, @qte, @detail, @idconsultation)", con);
                        cmd.Parameters.AddWithValue("@id", p.idprescription);
                        cmd.Parameters.AddWithValue("@produit", p.dgvPresc.Rows[i].Cells[1].Value.ToString());
                        cmd.Parameters.AddWithValue("@qte", p.dgvPresc.Rows[i].Cells[2].Value.ToString());
                        cmd.Parameters.AddWithValue("@detail", p.dgvPresc.Rows[i].Cells[3].Value.ToString());
                        cmd.Parameters.AddWithValue("@idconsultation", p.idconsultation);
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
                p.dgvPresc.Rows.Clear();
            }
            else
            {
                MessageBox.Show("Aucune ligne de prescription n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ModifierRenseignement(DataGridView dgv, string label)
        {
            if (dgv.RowCount != 0)
            {
                if (label != "examen physique")
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
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update Renseignement set libelle= @libelle where id = @id", con);
                        cmd.Parameters.AddWithValue("@id", dgv.CurrentRow.Cells[0].Value.ToString());
                        cmd.Parameters.AddWithValue("@libelle", string.Format("{0}: {1}", dgv.CurrentRow.Cells[1].Value.ToString(), dgv.CurrentRow.Cells[2].Value.ToString()));
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
                MessageBox.Show("Modifiée avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public void ModifierExamenLabo(FormConsulter exa)
        {
            if (exa.dgvLabo.RowCount != 0)
            {
                con.Open();
                exa.idresultat = int.Parse(exa.dgvLabo.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update ResultatExamen set resultat= @resultat where idresultat = @idresult", con);
                    cmd.Parameters.AddWithValue("@idresult", exa.idresultat);
                    cmd.Parameters.AddWithValue("@resultat", exa.dgvLabo.CurrentRow.Cells[2].Value.ToString());
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
            else MessageBox.Show("Aucune ligne de bon labo n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void SupprimerExamenLabo(FormConsulter exa)
        {
            if (exa.dgvLabo.RowCount != 0)
            {
                con.Open();
                exa.idresultat = int.Parse(exa.dgvLabo.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from ResultatExamen where idresultat = @idresult", con);
                    cmd.Parameters.AddWithValue("@idresult", exa.idresultat);
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
            }
            else MessageBox.Show("Aucune ligne de bon labo n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierMaladieDiagnostic(FormConsulter c)
        {
            if (c.dgvDiagnostic.RowCount != 0)
            {
                con.Open();
                c.idmaladie = int.Parse(c.dgvDiagnostic.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update MaladieConsultation set observation = @observation where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idmaladie);
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
                c.idmaladie = int.Parse(c.dgvDiagnostic.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from MaladieConsultation where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", c.idmaladie);
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
            }
            else MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ModifierPrescription(FormConsulter p)
        {
            if (p.dgvPresc.RowCount > 0)
            {
                con.Open();
                p.idprescription = int.Parse(p.dgvPresc.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Prescription set qteprescrite = @qte, detail = @detail where idpresc = @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idprescription);
                    cmd.Parameters.AddWithValue("@qte", p.dgvPresc.CurrentRow.Cells[2].Value.ToString());
                    cmd.Parameters.AddWithValue("@detail", p.dgvPresc.CurrentRow.Cells[3].Value.ToString());
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
        public void SupprimerPrescription(FormConsulter p)
        {
            if (p.dgvPresc.RowCount > 0)
            {
                con.Open();
                p.idprescription = int.Parse(p.dgvPresc.CurrentRow.Cells[0].Value.ToString());
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Prescription where idpresc = @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idprescription);
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
            }
            else
            {
                MessageBox.Show("Aucune ligne de prescription n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Enregistrer(FormRenseignement r)
        {
            if (r.dgv1.RowCount != 0)
            {
                // AjouterRenseignement(r);
                if (r.cboMotif.Text == "prédiagnostic")
                {
                    ValiderStatutConsultation(r.idligneagenda);
                    r.Hide();
                }
                else if (r.cboMotif.Text == "plainte")
                {
                    r.dgv1.Rows.Clear();
                    r.cboMotif.Items.Clear();
                    r.cboMotif.Items.Add("historique");
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDown;
                    r.cboMotif.Text = "historique";
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (r.cboMotif.Text == "historique")
                {
                    r.dgv1.Rows.Clear();
                    r.cboMotif.Items.Clear();
                    r.cboMotif.Items.Add("antécédent");
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDown;
                    r.cboMotif.Text = "antécédent";
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (r.cboMotif.Text == "antécédent")
                {
                    r.dgv1.Rows.Clear();
                    r.cboMotif.Items.Clear();
                    r.cboMotif.Items.Add("complément");
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDown;
                    r.cboMotif.Text = "complément";
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (r.cboMotif.Text == "complément")
                {
                    r.dgv1.Rows.Clear();
                    r.cboMotif.Items.Clear();
                    r.cboMotif.Items.Add("examen physique");
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDown;
                    r.cboMotif.Text = "examen physique";
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDownList;
                    r.btnNouveau.Enabled = true;
                    r.dgv1.Columns[2].Visible = true;
                    r.dgv1.Columns[1].HeaderText = "Examen";
                    r.dgv1.Columns[2].HeaderText = "Observation";
                    //ExamenPhysique(r);
                }
                else if (r.cboMotif.Text == "examen physique")
                {
                    r.dgv1.Rows.Clear();
                    r.cboMotif.Items.Clear();
                    r.cboMotif.Items.Add("prédiagnostic");
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDown;
                    r.cboMotif.Text = "prédiagnostic";
                    r.cboMotif.DropDownStyle = ComboBoxStyle.DropDownList;
                    r.dgv1.Columns[2].Visible = false;
                    r.btnNouveau.Enabled = false;
                }
                r.txtLibelle.Focus();
            }
            else
            {
                MessageBox.Show("Aucune ligne n'a été trouvée", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ExamenPhysique(FormRenseignement r, FormExamenPhysique exp)
        {
            exp.fermeture_succes = false;
            exp.dgv.Rows.Add();
            exp.dgv.Rows[exp.dgv.RowCount - 1].Cells[0].Value = r.dgv1.RowCount + 1;
            exp.dgv.Rows[exp.dgv.RowCount - 1].Cells[1].Value = "";
            exp.dgv.Rows[exp.dgv.RowCount - 1].Cells[2].Value = "";
            exp.ShowDialog();
            if (exp.fermeture_succes)
            {
                r.dgv1.Rows.Add();
                r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[0].Value = exp.dgv.Rows[0].Cells[0].Value;
                r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[1].Value = exp.dgv.Rows[0].Cells[1].Value;
                r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[2].Value = exp.dgv.Rows[0].Cells[2].Value;
            }
            exp.Close();
        }
        public void Afficher(FormRenseignement r, string motif)
        {
            if (motif == "")
                cmd = new SqlCommand("select id, libelle, label from Renseignement where idconsultation= @id", con);
            else
            {
                cmd = new SqlCommand("select id, libelle, label from Renseignement where idconsultation= @id and label= @label", con);
                cmd.Parameters.AddWithValue("@label", motif);
            }
            cmd.Parameters.AddWithValue("@id", r.idconsultation);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    r.dgv1.Rows.Add();
                    r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    r.dgv1.Rows[r.dgv1.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            r.dgv1.Columns[2].Visible = true;
        }
        public void ImprimerDossier(FormConsultationDossier d, FormImpression imp)
        {
            if (d.dgvDetail.RowCount != 0)
            {
                imp.idconsultation = d.idconsultation;
                imp.patient = d.patient;
                imp.idmedecin = d.idmedecin;
                imp.medecin = d.medecin;
                imp.numfiche = string.Format("{0}-{1}-{2}", DateConsultation(imp.idconsultation).Substring(0, 10), imp.idconsultation, imp.idmedecin);
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
        public void NouveauRDV(int idconsultation, FormConsulterRendezVous r)
        {
            r.idconsultation = idconsultation;
            r.ShowDialog();
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
                    cmd = new SqlCommand("insert into Rendezvous values (@id, @daterdv, @heure, @idconsultation)", con);
                    cmd.Parameters.AddWithValue("@id", c.idrdv);
                    cmd.Parameters.AddWithValue("@daterdv", c.dtpDaterdv.Text);
                    cmd.Parameters.AddWithValue("@heure", string.Format("{0}:{1}", c.cboHeure.Text, c.cboMinute.Text));
                    cmd.Parameters.AddWithValue("@idconsultation", c.idconsultation);
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
                chaine = (DateTime.Now.Year - int.Parse(chaineDate.Substring(chaineDate.IndexOf("/") + 1)))+" ans et " + Math.Abs(DateTime.Now.Month - int.Parse(chaineDate.Substring(0, chaineDate.IndexOf("/"))))+" mois";
            }
            return chaine;
        }
        public void ChargerCombo(ComboBox combo, string motif)
        {
            switch (motif)
	        {
                case "médecin": cmd = new SqlCommand("select nommedecin from Medecin", con); break;
                case "typepatient": cmd = new SqlCommand("select nomtype from TypePatient", con); break;
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
        public void CompterCasMedecin(FormPatient p)
        {
            cmd = new SqlCommand("select idmedecin, count(id) from LigneAgendaPatient group by idmedecin", con);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                p.dgvMedecin.Rows.Clear();
                while (dr.Read())
                {
                    p.dgvMedecin.Rows.Add();
                    p.dgvMedecin.Rows[p.dgvMedecin.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvMedecin.Rows[p.dgvMedecin.RowCount - 1].Cells[2].Value = dr[1].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);}
            con.Close();
            for (int i = 0; i < p.dgvMedecin.RowCount; i++)
                p.dgvMedecin.Rows[i].Cells[1].Value = TrouverNom("medecin", int.Parse(p.dgvMedecin.Rows[i].Cells[0].Value.ToString()));
        }
        public int CompterConsultation(int idpatient)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idconsultation) from Consultation where idpatient = @idpatient", con);
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
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (p.txtTel.Text == "") p.txtTel.Text = "243";
                if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "NULL";
                if (p.txtTelContact.Text == "") p.txtTelContact.Text = "243";

                cmd = new SqlCommand("insert into Patient values (@id, @date_entree, @nom, @sexe, @age, @adresse, @tel, @contact, @telcontact, @idtype)", con);
                cmd.Parameters.AddWithValue("@id", p.idpatient);
                cmd.Parameters.AddWithValue("@date_entree", p.dtpDateEntree.Value);
                cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                cmd.Parameters.AddWithValue("@age", p.age);
                cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
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
        public void Enregistrer(FormPatient p)
        {
            p.idpatient = NouveauID("patient");
            if (p.cboTypePatient.Text == "payant")
            {
                FormFactureService f = new FormFactureService();
                f.nouveau_patient = true;
                f.btnExit.Visible = false;
                f.cboTypeFacture.Items.Remove("différé");
                f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDown;
                f.cboTypeFacture.Text = "immédiat";
                f.cboTypeFacture.DropDownStyle = ComboBoxStyle.DropDownList;
                f.txtPayeur.Text = p.txtNom.Text;
                f.idpatient = p.idpatient;
                f.cas = p.cas;
                f.MaximumSize = f.Size;
                f.ControlBox = false;
                f.Text = "SSM - Facturation des services";
                f.ShowDialog();
                if (f.nouveau_patient)
                {
                    EnregistrerPatient(p);
                    EnregistrerAgenda(p);
                    Annuler(p);
                    Afficher(p, "");
                }
                f.Close();
            }
            else
            {
                EnregistrerPatient(p);
                if (p.cboTypePatient.Text == "abonné")
                {
                    cc.NouvelAbonne(p);
                }
                else if (p.cboTypePatient.Text == "employé")
                {
                    cc.NouvelEmploye(p);
                }
                EnregistrerAgenda(p);
                Annuler(p);
                Afficher(p, "");
            }
        }
        public void Modifier(FormPatient p)
        {
            if (p.txtNom.Text != "" && p.cboSexe.Text != "" && p.txtMois.Text !="" && p.txtAnnee.Text != "" && p.txtAdresse.Text != "")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    if (p.txtTel.Text == "") p.txtTel.Text = "243";
                    if (p.txtPersonContact.Text == "") p.txtPersonContact.Text = "NULL";
                    if (p.txtTelContact.Text == "") p.txtTelContact.Text = "243";

                    cmd = new SqlCommand("update Patient set date_entree= @date_entree, noms= @nom, sexe= @sexe, age= @age, adresse= @adresse, telephone= @tel, personnecontact= @contact, telephonecontact= @telcontact, idtype= @idtype where idpatient= @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idpatient);
                    cmd.Parameters.AddWithValue("@date_entree", p.dtpDateEntree.Text);
                    cmd.Parameters.AddWithValue("@nom", p.txtNom.Text);
                    cmd.Parameters.AddWithValue("@sexe", p.cboSexe.Text);
                    cmd.Parameters.AddWithValue("@age", p.age);
                    cmd.Parameters.AddWithValue("@adresse", p.txtAdresse.Text);
                    cmd.Parameters.AddWithValue("@tel", p.txtTel.Text);
                    cmd.Parameters.AddWithValue("@contact", p.txtPersonContact.Text);
                    cmd.Parameters.AddWithValue("@telcontact", p.txtTelContact.Text);
                    cmd.Parameters.AddWithValue("@idtype", p.idtypepatient);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    p.btnModifier.Enabled = false;
                    p.btnModifier.Text = "Modifier";
                    MessageBox.Show("Modifié avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(p);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Afficher(p, "");
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void Supprimer(FormPatient p)
        {
            if(CompterConsultation(p.idpatient)==0)
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
                    Annuler(p);
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
                Afficher(p, "");
            }
            else
                MessageBox.Show("Ce patient est déjà impliqué dans au moins une consultation ,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        public void Afficher(FormPatient p, string motif)
        {
            if(motif =="recherche")
            {
                if (p.txtRecherche.Text != "" && p.txtRecherche.Text != "Nom du patient")
                {
                    con.Open();
                    cmd = new SqlCommand("select * from Patient where noms like '" + p.txtRecherche.Text + "%'", con);
                    try
                    {
                        dr = cmd.ExecuteReader();
                        p.dgvPatient.Rows.Clear();
                        while (dr.Read())
                        {
                            p.dgvPatient.Rows.Add();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[2].Value = dr[2].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[3].Value = dr[3].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[4].Value = dr[4].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[5].Value = dr[5].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[6].Value = dr[6].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[7].Value = dr[7].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[8].Value = dr[8].ToString();
                            p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[9].Value = dr[9].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    con.Close();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[10].Value = TrouverNom("typepatient", int.Parse(p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[9].Value.ToString()));
                }
                else MessageBox.Show("Aucun nom de patient n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                con.Open();
                try
                {
                    cmd = new SqlCommand("select * from Patient where idpatient= @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idpatient);
                    dr = cmd.ExecuteReader();
                    p.dgvPatient.Rows.Clear();
                    dr.Read();
                    p.dgvPatient.Rows.Add();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[4].Value = dr[4].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[5].Value = dr[5].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[6].Value = dr[6].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[7].Value = dr[7].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[8].Value = dr[8].ToString();
                    p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[9].Value = dr[9].ToString();
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[10].Value = TrouverNom("typepatient", int.Parse(p.dgvPatient.Rows[p.dgvPatient.RowCount - 1].Cells[9].Value.ToString()));
            }
        }
        public void Recuperer(FormPatient p)
        {
            if(p.dgvPatient.RowCount !=0)
            {
                p.cboTypePatient.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboTypePatient.Text = p.dgvPatient.CurrentRow.Cells[10].Value.ToString();
                p.cboTypePatient.DropDownStyle = ComboBoxStyle.DropDownList;
                p.idtypepatient = int.Parse(p.dgvPatient.CurrentRow.Cells[9].Value.ToString());

                p.dtpDateEntree.Text = p.dgvPatient.CurrentRow.Cells[1].Value.ToString();
                p.txtNom.Text = p.dgvPatient.CurrentRow.Cells[2].Value.ToString();

                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboSexe.Text = p.dgvPatient.CurrentRow.Cells[3].Value.ToString();
                p.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;

                p.txtAnnee.Text = p.dgvPatient.CurrentRow.Cells[4].Value.ToString();
                p.txtAdresse.Text = p.dgvPatient.CurrentRow.Cells[5].Value.ToString();
                p.txtTel.Text = p.dgvPatient.CurrentRow.Cells[6].Value.ToString();
                p.txtPersonContact.Text = p.dgvPatient.CurrentRow.Cells[7].Value.ToString();
                p.txtTelContact.Text = p.dgvPatient.CurrentRow.Cells[8].Value.ToString();

                p.cboTypePatient.Select();
            }
        }
        public void Annuler(FormPatient p)
        {
            p.cboTypePatient.Items.Clear();
            p.cboMedecin.Items.Clear();
            p.txtNom.Text = "";
            p.cboSexe.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboSexe.SelectedText = "";
            p.cboSexe.DropDownStyle = ComboBoxStyle.DropDownList;
            p.txtMois.Text = "";
            p.txtAnnee.Text = "";
            p.txtAdresse.Text = "";
            p.txtTel.Text = "";
            p.txtPersonContact.Text = "";
            p.txtTelContact.Text = "";
            p.txtRecherche.Text = "";
            p.btnAffecter.Enabled = false;
            p.btnReaffecter.Enabled = false;
            p.btnRetirer.Enabled = false;
            p.btnEnregistrer.Enabled = true;
            p.lblAge.Text = "Age :";
        }
        public string TrouverPatientPayant(FormFacture f)
        {
            nom = "";
            con.Open();
            try
            {
                cmd = new SqlCommand("select noms from Patient where idpatient= @idpatient and idtype= @idtype", con);
                cmd.Parameters.AddWithValue("@idpatient", f.txtIdPatient.Text);
                cmd.Parameters.AddWithValue("@idtype", f.idtypepatient);
                dr = cmd.ExecuteReader();
                dr.Read();
                nom = dr[0].ToString();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return nom;
        }
        public void Abonne(FormPatient p, FormAbonne a)
        {
            a.btnModifier.Enabled = false;
            a.btnAfficher.Enabled = false;
            a.btnSupprimer.Enabled = false;
            a.btnAnnuler.Enabled = true;
            a.nouveau_patient = true;
            a.cboTypePatient.Enabled = false;
            a.cboEntreprise.Enabled = true;
            a.cboTypeAbonne.Enabled = true;
            a.txtReference.Enabled = true;
            a.cboEntreprise.Select();
            a.ControlBox = false;
            a.MaximumSize = a.Size;
            a.MinimumSize = a.Size;
            a.btnQuitter.Visible = false;
            a.ShowDialog();
            if (a.fermeture_succes)
            {
                p.identreprise = a.identreprise;
                p.idtypeabonne = a.idtypeabonne;
                p.refabonne = a.txtReference.Text;
            }
            else
            {
                p.cboTypePatient.Items.Clear();
            }
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

        #region AGENDA
        public int VerifierCasAgenda(FormPatient p)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) from LigneAgendaPatient where idpatient= @id", con);
                cmd.Parameters.AddWithValue("@id", p.idpatient);
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
        public void EnregistrerAgenda(FormPatient p)
        {
            p.idligneagenda = NouveauID("agenda");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if (p.cboTypePatient.Text != "payant")
                {
                    cmd = new SqlCommand("insert into LigneAgendaPatient(id, cas, idpatient, idmedecin, caisse) values (@id, @cas, @idpatient, @idmedecin, @caisse)", con);
                    cmd.Parameters.AddWithValue("@caisse", "OK");
                }
                else
                {
                    cmd = new SqlCommand("insert into LigneAgendaPatient(id, cas, idpatient, idmedecin) values (@id, @cas, @idpatient, @idmedecin)", con);
                }
                cmd.Parameters.AddWithValue("@id", p.idligneagenda);
                cmd.Parameters.AddWithValue("@cas", p.cas);
                cmd.Parameters.AddWithValue("@idpatient", p.idpatient);
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
            CompterCasMedecin(p);
            //if(p.poste == "infirmerie")
            //{
            //    con.Open();
            //    SqlTransaction tx2 = con.BeginTransaction();
            //    try
            //    {
            //        cmd = new SqlCommand("update LigneAgendaPatient set caisse = 'OK'  where id = @id", con);
            //        cmd.Parameters.AddWithValue("@id", p.idligneagenda);
            //        cmd.Transaction = tx2;
            //        cmd.ExecuteNonQuery();
            //        tx2.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        tx2.Rollback();
            //        MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    con.Close();
            //}
        }
        public bool ModifierAgenda(FormPatient p, string motif)
        {
            cmdStatut = true;
            if (motif == "retirer")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from LigneAgendaPatient where idpatient = @idpatient", con);
                    cmd.Parameters.AddWithValue("@idpatient", p.idpatient);
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
            }
            else
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update LigneAgendaPatient set cas = @cas, idmedecin = @idmedecin where idpatient = @idpatient", con);
                    cmd.Parameters.AddWithValue("@idpatient", p.idpatient);
                    cmd.Parameters.AddWithValue("@cas", p.cas);
                    cmd.Parameters.AddWithValue("@idmedecin", p.idmedecin);
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
            }
            CompterCasMedecin(p);
            return cmdStatut;
        }
        public void ChargerAgendaPatient(FormAgenda a)
        {
            cmd = new SqlCommand("select * from LigneAgendaPatient where idpatient= @idpatient", con);
            cmd.Parameters.AddWithValue("@idpatient", a.idpatient);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                a.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAgenda.Rows.Add();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[6].Value = dr[4].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[7].Value = dr[5].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[8].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < a.dgvAgenda.RowCount; i++)
            {
                a.dgvAgenda.Rows[i].Cells[4].Value = TrouverNom("patient", int.Parse(a.dgvAgenda.Rows[i].Cells[2].Value.ToString()));
                a.dgvAgenda.Rows[i].Cells[5].Value = TrouverNom("medecin", int.Parse(a.dgvAgenda.Rows[i].Cells[3].Value.ToString()));
                AgeSexeDatePatient(a, i);
                a.dgvAgenda.Rows[i].Cells[12].Value = TrouverNom("typepatient", int.Parse(a.dgvAgenda.Rows[i].Cells[12].Value.ToString()));
            }
        }
        public void AgeSexeDatePatient(FormAgenda a, int idligne)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select date_entree, sexe, age, idtype from Patient where idpatient= @id", con);
                cmd.Parameters.AddWithValue("@id", a.dgvAgenda.Rows[idligne].Cells[2].Value.ToString());
                dr = cmd.ExecuteReader();
                dr.Read();
                a.dgvAgenda.Rows[idligne].Cells[9].Value = dr[0].ToString().Substring(0, 10);
                a.dgvAgenda.Rows[idligne].Cells[10].Value = dr[1].ToString();
                a.dgvAgenda.Rows[idligne].Cells[11].Value = dr[2].ToString();
                a.dgvAgenda.Rows[idligne].Cells[12].Value = dr[3].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ChargerAgendaMedecin(FormAgenda a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneAgendaPatient where idmedecin = @id", con);
                cmd.Parameters.AddWithValue("@id", a.idmedecin);
                dr = cmd.ExecuteReader();
                a.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAgenda.Rows.Add();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[6].Value = dr[4].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[7].Value = dr[5].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[8].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < a.dgvAgenda.RowCount; i++)
            {
                a.dgvAgenda.Rows[i].Cells[4].Value = TrouverNom("patient", int.Parse(a.dgvAgenda.Rows[i].Cells[2].Value.ToString()));
                a.dgvAgenda.Rows[i].Cells[5].Value = TrouverNom("medecin", int.Parse(a.dgvAgenda.Rows[i].Cells[3].Value.ToString()));
                AgeSexeDatePatient(a, i);
                a.dgvAgenda.Rows[i].Cells[12].Value = TrouverNom("typepatient", int.Parse(a.dgvAgenda.Rows[i].Cells[12].Value.ToString()));
            }
        }
        public void ChargerAgenda(FormAgenda a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneAgendaPatient where signev is NULL", con);
                dr = cmd.ExecuteReader();
                a.dgvAgenda.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAgenda.Rows.Add();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[3].Value = dr[3].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[6].Value = dr[4].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[7].Value = dr[5].ToString();
                    a.dgvAgenda.Rows[a.dgvAgenda.RowCount - 1].Cells[8].Value = dr[6].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < a.dgvAgenda.RowCount; i++)
            {
                a.dgvAgenda.Rows[i].Cells[4].Value = TrouverNom("patient", int.Parse(a.dgvAgenda.Rows[i].Cells[2].Value.ToString()));
                a.dgvAgenda.Rows[i].Cells[5].Value = TrouverNom("medecin", int.Parse(a.dgvAgenda.Rows[i].Cells[3].Value.ToString()));
                AgeSexeDatePatient(a, i);
                a.dgvAgenda.Rows[i].Cells[12].Value = TrouverNom("typepatient", int.Parse(a.dgvAgenda.Rows[i].Cells[12].Value.ToString()));
            }
        }
        public void ActualiserLigneAgenda(FormAgenda a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select caisse, signev, consultation from LigneAgendaPatient where id= @id", con);
                cmd.Parameters.AddWithValue("@id", a.idligne);
                dr = cmd.ExecuteReader();
                dr.Read();
                a.dgvAgenda.CurrentRow.Cells[6].Value = dr[0].ToString();
                a.dgvAgenda.CurrentRow.Cells[7].Value = dr[1].ToString();
                a.dgvAgenda.CurrentRow.Cells[8].Value = dr[2].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        public void ValiderStatutCaisse(FormAgenda a)
        {
            if (a.dgvAgenda.CurrentRow.Cells[6].Value.ToString() != "OK")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update LigneAgendaPatient set caisse = 'OK' where id = @id", con);
                    cmd.Parameters.AddWithValue("@id", a.idligne);
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
                ActualiserLigneAgenda(a);
            }
            else
            {
                MessageBox.Show("Consultation déjà validée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void ValiderStatutSignesVitaux(int idligneagenda)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneAgendaPatient set signev = 'OK' where id = @id", con);
                cmd.Parameters.AddWithValue("@id", idligneagenda);
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
        public void ValiderStatutConsultation(int idligneagenda)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneAgendaPatient set consultation = 'OK' where id = @id", con);
                cmd.Parameters.AddWithValue("@id", idligneagenda);
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
            RetirerPatientAgenda(idligneagenda);
        }
        public void RetirerPatientAgenda(int idligneagenda)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("delete from LigneAgendaPatient where id = @id and consultation = 'OK'", con);
                cmd.Parameters.AddWithValue("@id", idligneagenda);
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
        public void InvaliderStatutCaisse(FormAgenda a)
        {
            if (a.dgvAgenda.CurrentRow.Cells[7].Value.ToString() != "OK")
            {
                if (a.dgvAgenda.CurrentRow.Cells[6].Value.ToString() == "OK")
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update LigneAgendaPatient set caisse = NULL  where id = @id", con);
                        cmd.Parameters.AddWithValue("@id", a.idligne);
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
                    ActualiserLigneAgenda(a);
                }
                else MessageBox.Show("Consultation non encore validée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else MessageBox.Show("Le cas sélectionné est déjà impliqué dans le prélèvement des signes vitaux, pour garder la cohérence, il ne peut être invalidé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void AjouterServicePourNonPayant(FormAgenda a, FormSigneVital s, FormAbonneService ab)
        {
            ab.txtAbonne.Text = a.dgvAgenda.CurrentRow.Cells[4].Value.ToString();
            ab.typepatient = a.dgvAgenda.CurrentRow.Cells[12].Value.ToString();
            if (ab.typepatient == "abonné")
            {
                ab.Text = "SSM - Services aux abonnés";
                ab.idabonne = cc.TrouverId("abonneconsulte", a.dgvAgenda.CurrentRow.Cells[2].Value.ToString());
            }
            else
            {
                ab.Text = "SSM - Services aux employés";
                ab.idabonne = cc.TrouverId("employeconsulte", a.dgvAgenda.CurrentRow.Cells[2].Value.ToString());
            }
            ab.dgvService.Rows.Add();
            if (a.dgvAgenda.CurrentRow.Cells[1].Value.ToString() == "nouveau")
            {
                ab.dgvService.Rows[0].Cells[0].Value = cc.TrouverId("service", "consultation nouveau cas");
                ab.dgvService.Rows[0].Cells[1].Value = "consultation nouveau cas";
            }
            else if (a.dgvAgenda.CurrentRow.Cells[1].Value.ToString() == "ancien")
            {
                ab.dgvService.Rows[0].Cells[0].Value = cc.TrouverId("service", "consultation ancien cas");
                ab.dgvService.Rows[0].Cells[1].Value = "consultation ancien cas";
            }
            else
            {
                ab.dgvService.Rows[0].Cells[0].Value = cc.TrouverId("service", "consultation urgence");
                ab.dgvService.Rows[0].Cells[1].Value = "consultation urgence";
            }
            ab.consulte = true;
            ab.btnAfficher.Enabled = false;
            ab.btnPlus.Enabled = false;
            ab.btnRetirer.Enabled = false;
            ab.ShowDialog();
            if (ab.fermeture_succes)
                SignesVitaux(a, s);
        }
        public void SignesVitaux(FormAgenda a, FormSigneVital sv)
        {
            if (a.dgvAgenda.RowCount != 0)
            {
                if (a.dgvAgenda.CurrentRow.Cells[6].Value.ToString() == "OK")
                {
                    if (a.dgvAgenda.CurrentRow.Cells[7].Value.ToString() != "OK")
                    {
                        sv.motif = "soin";
                        sv.lblNum.Text = a.dgvAgenda.CurrentRow.Cells[0].Value.ToString();
                        sv.lblNom.Text = a.dgvAgenda.CurrentRow.Cells[4].Value.ToString();
                        sv.MaximizeBox = false;
                        sv.MinimizeBox = false;
                        sv.MaximumSize = sv.Size;
                        sv.MinimumSize = sv.Size;
                        sv.panel2.Visible = true;
                        sv.lblNum.Visible = true;
                        sv.lblNom.Visible = true;
                        sv.Text = "SSM - Signes Vitaux";
                        ChargerSignesVitaux(sv);
                        sv.ShowDialog();
                        ActualiserLigneAgenda(a);
                    }
                    else if(MessageBox.Show("Valeurs déjà enregistrées pour ce patient\n\nVoulez-vous les modifier ?", "Valeur", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.Yes)
                    {
                        sv.motif = "soin";
                        sv.lblNum.Text = a.dgvAgenda.CurrentRow.Cells[0].Value.ToString();
                        sv.lblNom.Text = a.dgvAgenda.CurrentRow.Cells[4].Value.ToString();
                        sv.MaximizeBox = false;
                        sv.MinimizeBox = false;
                        sv.MaximumSize = sv.Size;
                        sv.MinimumSize = sv.Size;
                        sv.panel2.Visible = true;
                        sv.lblNum.Visible = true;
                        sv.lblNom.Visible = true;
                        sv.btnValider.Enabled = false;
                        sv.btnMAJ.Enabled = true;
                        sv.Text = "SSM - Signes Vitaux";
                        ValeurSigneVitaux(sv.dgvSigne, int.Parse(sv.lblNum.Text));
                        sv.ShowDialog();
                    }
                }
                else MessageBox.Show("Le patient sélectionné n'a pas encore payé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        List<string> numagenda = new List<string>();
        public void Consultation(FormAgenda a, FormConsulter c)
        {           
            if(a.dgvAgenda.RowCount != 0)
            {
                if (a.dgvAgenda.CurrentRow.Cells[7].Value.ToString() == "OK")
                {
                    if (a.dgvAgenda.CurrentRow.Cells[8].Value.ToString() != "OK")
                    {
                        if (!numagenda.Contains(a.dgvAgenda.CurrentRow.Cells[0].Value.ToString()))
                        {
                            c.dgvAgenda.Rows.Add();
                            c.dgvAgenda.Rows[0].Cells[0].Value = a.dgvAgenda.CurrentRow.Cells[0].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[1].Value = a.dgvAgenda.CurrentRow.Cells[1].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[2].Value = a.dgvAgenda.CurrentRow.Cells[2].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[3].Value = a.dgvAgenda.CurrentRow.Cells[3].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[4].Value = a.dgvAgenda.CurrentRow.Cells[4].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[5].Value = a.dgvAgenda.CurrentRow.Cells[5].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[6].Value = a.dgvAgenda.CurrentRow.Cells[9].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[7].Value = a.dgvAgenda.CurrentRow.Cells[10].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[8].Value = a.dgvAgenda.CurrentRow.Cells[11].Value.ToString();
                            c.dgvAgenda.Rows[0].Cells[9].Value = a.dgvAgenda.CurrentRow.Cells[12].Value.ToString();

                            c.idligneagenda = int.Parse(c.dgvAgenda.CurrentRow.Cells[0].Value.ToString());
                            c.type_consultation = a.dgvAgenda.CurrentRow.Cells[1].Value.ToString();
                            c.idpatient = int.Parse(a.dgvAgenda.CurrentRow.Cells[2].Value.ToString());
                            c.idmedecin = int.Parse(a.dgvAgenda.CurrentRow.Cells[3].Value.ToString());

                            ValeurSigneVitaux(c.dgvSigneVital, int.Parse(c.dgvAgenda.CurrentRow.Cells[0].Value.ToString()));
                            c.Text = "SSM - Dossier " + c.dgvAgenda.CurrentRow.Cells[4].Value.ToString();

                            numagenda.Add(a.dgvAgenda.CurrentRow.Cells[0].Value.ToString());
                            c.Show();
                        }
                    }
                    else MessageBox.Show("Le patient sélectionné est déjà consulté", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else MessageBox.Show("Valeurs des signes vitaux manquantes pour le patient sélectionné", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void ImprimerAgenda(FormAgenda a, FormImpression imp)
        {
            if (a.dgvAgenda.RowCount != 0)
            {
                imp.Text = "SSM - Agenda patients à consulter";

                List<AgendaPatient> list = new List<AgendaPatient>();
                list.Clear();

                for (int i = 0; i < a.dgvAgenda.RowCount; i++)
                {
                    AgendaPatient ag = new AgendaPatient
                    {
                        id = list.Count + 1,
                        cas = a.dgvAgenda.Rows[i].Cells[1].Value.ToString(),
                        patient = a.dgvAgenda.Rows[i].Cells[4].Value.ToString(),
                        medecin = a.dgvAgenda.Rows[i].Cells[5].Value.ToString(),
                        caisse = a.dgvAgenda.Rows[i].Cells[6].Value.ToString(),
                        signesvit = a.dgvAgenda.Rows[i].Cells[7].Value.ToString(),
                        consultation = a.dgvAgenda.Rows[i].Cells[8].Value.ToString(),
                        dateentree = a.dgvAgenda.Rows[i].Cells[9].Value.ToString()
                    };
                    list.Add(ag);
                }
                rs.Name = "DataSet1";
                rs.Value = list;
                imp.reportViewer1.LocalReport.DataSources.Clear();
                imp.reportViewer1.LocalReport.DataSources.Add(rs);
                imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.AgendaPatient.rdlc";
                imp.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region BON_EXAMEN
        public void BonExamen(FormRenseignement r, FormExamen exa)
        {
            exa.txtPatient.Text = r.txtPatient.Text;
            exa.txtMedecin.Text = r.txtMedecin.Text;
            exa.idmedecin = r.idmedecin;
            exa.idconsultation = r.idconsultation;
            exa.dgv1.Columns[2].Visible = false;
            exa.txtLibelle.Enabled = false;
            exa.btnValider.Enabled = false;
            exa.btnQuitter.Visible = false;
            exa.MaximizeBox = false;
            exa.MinimizeBox = false;
            exa.MaximumSize = exa.Size;
            exa.Text = "SSM - Bon d'examens";
            exa.ShowDialog();
            r.Close();
        }
        public void MesConsultations(FormExamen exa, FormConsultation c)
        {
            exa.txtMedecin.Text = TrouverNom("medecin", exa.idmedecin);
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
                exa.idconsultation = c.idconsultation;
                exa.txtPatient.Text = TrouverNom("patient", c.idpatient);
                ChargerExamen(exa);
            }
            else exa.Close();
            c.Close();
        }
        public void ValiderLigne(FormExamen exa)
        {
            exa.ajoutvalide = true;           
            if (exa.dgv1.RowCount > 0)
            {
                if (exa.cboService.Enabled)
                {
                    for (int i = 0; i < exa.dgv1.RowCount; i++)
                    {
                        if (exa.dgv1.Rows[i].Cells[1].Value.ToString() == exa.cboService.Text)
                        {
                            MessageBox.Show("Cet examen est déjà affecté à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            i += exa.dgv1.RowCount;
                            exa.ajoutvalide = false;
                        }
                    }
                }
                if (exa.ajoutvalide) AjouterLigne(exa);
            }
            else AjouterLigne(exa);
        }
        public void AjouterLigne(FormExamen exa)
        {
            if (!exa.cboService.Enabled)
            {
                if (exa.txtLibelle.Text != "")
                {
                    exa.dgv1.CurrentRow.Cells[2].Value = exa.txtLibelle.Text;
                }
                else
                {
                    MessageBox.Show("Aucun libellé n'a été fourni", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                exa.txtLibelle.Text = "";
                exa.txtLibelle.Focus();
            }
            else
            {
                exa.dgv1.Rows.Add();
                exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[0].Value = exa.dgv1.RowCount;
                exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[1].Value = exa.cboService.Text;
            }           
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
        public void GenererBonExamen(FormConsulter exa, FormImpression imp)
        {
            imp.idconsultation = exa.idconsultation;
            imp.patient = exa.dgvAgenda.Rows[0].Cells[4].Value.ToString();
            imp.idmedecin = exa.idmedecin;
            imp.medecin = exa.dgvAgenda.Rows[0].Cells[5].Value.ToString();
            imp.numfiche = string.Format("{0}-{1}-{2}", DateConsultation(imp.idconsultation).Substring(0, 10), imp.idconsultation, imp.idmedecin);
            imp.Text = "SSM - Bon d'examens";

            List<BonExamen> list = new List<BonExamen>();
            list.Clear();

            for (int i = 0; i < exa.dgvLabo.RowCount; i++)
            {
                BonExamen be = new BonExamen
                {
                    numexamen = exa.dgvLabo.Rows[i].Cells[0].Value.ToString(),
                    examen = exa.dgvLabo.Rows[i].Cells[1].Value.ToString(),
                };
                list.Add(be);
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
        public void ChargerExamen(FormExamen exa)
        {
            cmd = new SqlCommand("select idresultat, nomexamen, resultat from ResultatExamen where idconsultation= @id", con);
            cmd.Parameters.AddWithValue("@id", exa.idconsultation);
            con.Open();
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    exa.dgv1.Rows.Add();
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[2].Value = dr[2].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            exa.dgv1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            exa.dgv1.Columns[2].Visible = true;
        }
        public void ExamenPhysique(FormExamen exa, FormExamenPhysique exp)
        {
            exp.fermeture_succes = false;
            exp.dgv.Rows.Add();
            exp.dgv.Rows[0].Cells[0].Value = exa.dgv1.RowCount + 1;
            exp.dgv.Rows[0].Cells[1].Value = "";
            exp.dgv.Rows[0].Cells[2].Value = "";
            exp.ShowDialog();
            if (exp.fermeture_succes)
            {
                exa.ajoutvalide = true;
                for (int i = 0; i < exa.dgv1.RowCount; i++)
                {
                    if (exa.dgv1.Rows[i].Cells[1].Value.ToString() == exp.dgv.Rows[0].Cells[1].Value.ToString())
                    {
                        MessageBox.Show("Cet examen est déjà affecté à la liste", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        i += exa.dgv1.RowCount;
                        exa.ajoutvalide = false;
                    }
                }
                if(exa.ajoutvalide)
                {
                    exa.dgv1.Rows.Add();
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[0].Value = exp.dgv.Rows[0].Cells[0].Value;
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[1].Value = exp.dgv.Rows[0].Cells[1].Value;
                    exa.dgv1.Rows[exa.dgv1.RowCount - 1].Cells[2].Value = "";
                }
            }
            exp.Close();
        }
        #endregion

        #region PRESCRIPTION
        public void AjouterLigne(FormPrescription f)
        {
            f.txtTotal.Text = "0";
            f.dgvFacture.Rows.Add();
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[0].Value = f.idstock;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[1].Value = f.dgvFacture.RowCount;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[2].Value = string.Format("{0} {1} {2} {3} {4}", f.cboProduit.Text, f.txtConditionnement.Text, f.txtDosage.Text, f.txtForme.Text, f.txtNumLot.Text);
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value = f.prixunitaire;
            if (f.txtQte.Text == "") f.txtQte.Text = "1";
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value = f.txtQte.Text;
            f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[5].Value = double.Parse(f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[3].Value.ToString()) * int.Parse(f.dgvFacture.Rows[f.dgvFacture.RowCount - 1].Cells[4].Value.ToString());
            for (int i = 0; i < f.dgvFacture.RowCount; i++)
            {
                f.txtTotal.Text = (double.Parse(f.txtTotal.Text) + double.Parse(f.dgvFacture.Rows[i].Cells[5].Value.ToString())).ToString("0.00");
            }
            Annuler(f);
        }
        public void ValiderLigne(FormPrescription f)
        {
            if (f.cboStock.Text != "")
            {
                f.ajoutvalide = true;
                if (f.dgvFacture.RowCount > 0)
                {
                    for (int i = 0; i < f.dgvFacture.RowCount; i++)
                    {
                        if (f.dgvFacture.Rows[i].Cells[0].Value.ToString() == f.idstock.ToString())
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
                MessageBox.Show("Aucun stock d'un produit n'a été sélectionné", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                f.cboStock.Select();
            }
        }
        public void Prescription(FormMaladieDiagnostic md, FormPrescription p)
        {
            p.idconsultation = md.idconsultation;
            p.idmedecin = md.idmedecin;
            p.Show();
            md.Close();
        }
        public void Annuler(FormPrescription p)
        {
            p.cboProduit.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboProduit.SelectedText = "";
            p.cboProduit.DropDownStyle = ComboBoxStyle.DropDownList;
            p.cboStock.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboStock.SelectedText = "";
            p.cboStock.DropDownStyle = ComboBoxStyle.DropDownList;
            p.idstock = 0;
            p.txtConditionnement.Text = "";
            p.txtDosage.Text = "";
            p.txtForme.Text = "";
            p.txtNumLot.Text = "";
            p.lblDate.Text = "Expire en ";
            p.txtQte.Text = "1";
        }

        //public void GenererBonExamen(FormPrescription p, FormImpression imp)
        //{
        //    imp.idconsultation = p.idconsultation;
        //    imp.patient = p.txtPatient.Text;
        //    imp.idmedecin = p.idmedecin;
        //    imp.medecin = p.txtMedecin.Text;
        //    imp.numfiche = string.Format("{0}-{1}-{2}", DateConsultation(imp.idconsultation).Substring(0, 10), imp.idconsultation, imp.idmedecin);

        //    List<BonExamen> list = new List<BonExamen>();
        //    list.Clear();

        //    for (int i = 0; i < p.dgvFacture.RowCount; i++)
        //    {
        //        BonExamen be = new BonExamen
        //        {
        //            numexamen = p.dgvFacture.Rows[i].Cells[0].Value.ToString(),
        //            examen = p.dgvFacture.Rows[i].Cells[1].Value.ToString(),
        //        };
        //        list.Add(be);
        //    }

        //    ReportParameter[] rparams = new ReportParameter[]
        //    {
        //        new ReportParameter("numfiche", imp.numfiche),
        //        new ReportParameter("patient", imp.patient),
        //        new ReportParameter("medecin", imp.medecin)
        //    };
        //    rs.Name = "DataSet1";
        //    rs.Value = list;
        //    imp.reportViewer1.LocalReport.DataSources.Clear();
        //    imp.reportViewer1.LocalReport.DataSources.Add(rs);
        //    imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonExamen.rdlc";
        //    imp.reportViewer1.LocalReport.SetParameters(rparams);
        //    imp.MaximumSize = imp.Size;
        //    imp.MaximizeBox = false;
        //    imp.MinimizeBox = false;
        //    imp.ShowDialog();
        //    p.Close();
        //}
        public void MesConsultations(FormPrescription p, FormConsultation c)
        {
            p.txtMedecin.Text = TrouverNom("medecin", p.idmedecin);
            c.MaximizeBox = false;
            c.MinimizeBox = false;
            c.MaximumSize = c.Size;
            c.MinimumSize = c.Size;
            c.idmedecin = p.idmedecin;
            c.btnQuitter.Visible = false;
            c.Text = "SSM - Mes consultations";
            c.ShowDialog();
            if (c.fermeture_succes)
            {
                p.idconsultation = c.idconsultation;
                p.txtPatient.Text = TrouverNom("patient", c.idpatient);
            }
            else p.Close();
            c.Close();
        }

        #endregion

        #region MALADIE_DIAGNOSTIC
        public void MaladieDiagnostic(FormExamen exa, FormMaladieDiagnostic md)
        {
            md.idconsultation = exa.idconsultation;
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
        public void ChargerSignesVitaux(FormSigneVital sv)
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
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[1].Value = dr[0].ToString();
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[2].Value = dr[1].ToString();
                    sv.dgvSigne.Rows[sv.dgvSigne.RowCount - 1].Cells[3].Value = "";
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
                ChargerSignesVitaux(sv);
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
                ValiderStatutSignesVitaux(int.Parse(sv.lblNum.Text));
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
                ChargerSignesVitaux(sv);
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
                ChargerSignesVitaux(sv);
            }
            else
                MessageBox.Show("Ce signe est déjà impliqué dans les consultations effectuées,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Annuler(sv);
        }
        public void ValeurSigneVitaux(DataGridView dgv, int idligneagenda)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select id, idsigne, valeur from LigneSigneVital where idligneagenda = @id", con);
                cmd.Parameters.AddWithValue("@id", idligneagenda);
                dr = cmd.ExecuteReader();
                id = 0;
                while (dr.Read())
                {
                    dgv.Rows.Add();
                    dgv.Rows[dgv.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    dgv.Rows[dgv.RowCount - 1].Cells[1].Value = dr[1].ToString();
					dgv.Rows[dgv.RowCount - 1].Cells[3].Value = dr[2].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Cells[2].Value = TrouverNom("signevital", int.Parse(dgv.Rows[i].Cells[1].Value.ToString()));
            }
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
        public void AfficherMedecin(FormMedecin m)
        {
            cmd = new SqlCommand("select * from Medecin", con);
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
            m.cboUtilisateur.Items.Clear();
        }
        public bool Enregistrer(FormMedecin m)
        {
            cmdStatut = true;
            if (m.txtNom.Text != "" && m.txtNumOrdre.Text != "" && m.txtTel.Text != "" && m.cboUtilisateur.Text != "")
            {
                m.idmedecin = NouveauID("medecin");
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("insert into Medecin values (@id, @nom, @numordre, @tel, @util)", con);
                    cmd.Parameters.AddWithValue("@id", m.idmedecin);
                    cmd.Parameters.AddWithValue("@nom", m.txtNom.Text);
                    cmd.Parameters.AddWithValue("@numordre", m.txtNumOrdre.Text);
                    cmd.Parameters.AddWithValue("@tel", m.txtTel.Text);
                    cmd.Parameters.AddWithValue("@util", m.cboUtilisateur.Text);
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
            }
            else
            {
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmdStatut = false;
            }
            return cmdStatut;
        }
        public bool Modifier(FormMedecin m)
        {
            m.btnModifier.Enabled = false;
            m.btnEnregistrer.Enabled = true;
            cmdStatut = true;
            if (m.txtNom.Text != "Noms" && m.txtNumOrdre.Text != "" && m.txtTel.Text != "" && m.cboUtilisateur.Text !="")
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update Medecin set nommedecin= @nom, numordre= @numordre, telmedecin= @tel, utilisateur= @util where idmedecin= @id", con);
                    cmd.Parameters.AddWithValue("@nom", m.txtNom.Text);
                    cmd.Parameters.AddWithValue("@numordre", m.txtNumOrdre.Text);
                    cmd.Parameters.AddWithValue("@tel", m.txtTel.Text);
                    cmd.Parameters.AddWithValue("@util", m.cboUtilisateur.Text);
                    cmd.Parameters.AddWithValue("@id", id);
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
            }
            else
            {
                cmdStatut = false;
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return cmdStatut;
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
                AfficherMedecin(m);
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