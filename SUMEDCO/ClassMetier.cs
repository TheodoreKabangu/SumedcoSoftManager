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

namespace SUMEDCO
{
    public class ClassMetier
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        ComboBox cbo = new ComboBox();
        private long id = 0,
                    nbreligne= 0;
        private string nom = "", 
            cmdtxt1 = "", 
            cmdtxt2 = "",
            cmdtxt3 = "",
            tel = "", 
            contact = "", 
            telcontact="";
        
        private bool cmdStatut = true;
              
        //METHODES COMMUNES
        //=======================================================
        public string TestEntier(string chaine, long valeur)
        {
            if (chaine != "")
            {
                try
                {
                    valeur = long.Parse(chaine);
                }
                catch (Exception)
                {
                    MessageBox.Show("Caractère interdit! Saisissez seuls les nombres entiers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return chaine.Substring(0, chaine.Length-1);
                }
            }
            if (valeur == 0)
                return "";
            else
                return valeur.ToString();
        }
        public string Vider(string chaine)
        {
            if (chaine.Contains("Recherche"))
                chaine = "";
            return chaine;
        }
        public long NouveauID(string concerne)
        {
            switch (concerne)
            {
                case "abonne": cmdtxt1 = "select max(idabonne) from Abonne"; break;
                case "patient": cmdtxt1 = "select max(idpatient) from Patient"; break;
                case "consultation": cmdtxt1 = "select max(idconsultation) from Consultation"; break;
                case "plainte": cmdtxt1 = "select max(idplainte) from LignePlainte"; break;
                case "prescription": cmdtxt1 = "select max(idprescription) from LignePrescription"; break;
                case "service": cmdtxt1 = "select max(idservice) from ServiceDemande"; break;
                case "recette": cmdtxt1 = "select max(idrecette) from Recette"; break;
                case "requisition": cmdtxt1 = "select max(idrequisition) from Requisition"; break;
                case "commande": cmdtxt1 = "select max(idcommande) from Commande"; break;
                case "appro": cmdtxt1 = "select max(idappro) from Appro"; break;
                case "produit": cmdtxt1 = "select max(idproduit) from Produit"; break;
                case "forme": cmdtxt1 = "select max(idforme) from Forme"; break;
                case "condition": cmdtxt1 = "select max(idcondition) from Condition"; break;
                case "medecin": cmdtxt1 = "select max(idmedecin) from Medecin"; break;
                case "maladie": cmdtxt1 = "select max(idmaladie) from Maladie"; break;
                case "signe": cmdtxt1 = "select max(idparametre) from Parametre"; break;
                case "categorie": cmdtxt1 = "select max(idcategorie) from Categorie"; break;
                case "operation": cmdtxt1 = "select max(idoperation) from Operation"; break;

            }           
            cmd = new SqlCommand(cmdtxt1, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr[0].ToString() == "")
                    id = 1;
                else
                    id = long.Parse(dr[0].ToString()) + 1;// +1 pour un nouveau id
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public long TrouverIdPatient(string nompatient)
        {
            cmd = new SqlCommand("select idpatient from Patient where noms = '" + nompatient + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        //=======================================================

        /*
         * ======================================================
         * COMPTABILITE
         * ======================================================
         */
        public void ChargerCboCompte(FormComptabilite2 c)
        {
            cmd = new SqlCommand("select numcompte from Compte where classe = " + c.cboClasse.Text + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                c.cboNumCompte.Items.Clear();
                while (dr.Read())
                {
                    c.cboNumCompte.Items.Add(dr[0].ToString());
                }               
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public long TrouverNumCompte(FormComptabilite2 c)
        {
            cmd = new SqlCommand("select numcompte from Compte where libellecompte = '" + c.cboTypeJournal.Text + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public string TrouverLibelleCompte(string numcompte)
        {
            cmd = new SqlCommand("select libellecompte from Compte where numcompte = " + numcompte + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public long VerifierTaux(string dateTaux, string motif)
        {
            if(motif == "valeur")
                cmd = new SqlCommand("select taux from Date_operation where date_operation = '" + dateTaux + "'", con);
            else
                cmd = new SqlCommand("select count(taux) from Date_operation where date_operation = '" + dateTaux + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
                if (id == 0)
                    MessageBox.Show("Valeur taux non trouvée pour la date : " + dateTaux, "Vérification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show("E " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public bool Enregistrer(DateTaux d)
        {
            if(d.txtTaux.Text!="")
            {
                cmd = new SqlCommand("insert into Date_operation values ('" + d.dtpTaux.Text + "', " + d.txtTaux.Text + ")", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmdStatut = true;
                }
            }
            else
            {
                cmdStatut = false;
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return cmdStatut;
        }
        public void Annuler(FormComptabilite2 c)
        {
            c.cboTypeJournal.DropDownStyle = ComboBoxStyle.DropDownList;
            c.txtLibelle.Text = "";
            c.txtNumPiece.Text = "";
            c.txtMontant.Text = "";
            c.cboDebitCredit.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboDebitCredit.SelectedText = "";
            c.cboDebitCredit.DropDownStyle = ComboBoxStyle.DropDownList;
            c.cboClasse.DropDownStyle = ComboBoxStyle.DropDown;
            c.cboClasse.SelectedText = "";
            c.cboClasse.DropDownStyle = ComboBoxStyle.DropDownList;
            c.cboNumCompte.SelectedText = "";
            c.dgvCompte.Rows.Clear();

        }
        public bool Enregistrer(FormComptabilite2 c)
        {
            cmdStatut = true;
            if (c.txtLibelle.Text != "" && c.txtNumPiece.Text != "" && c.dgvCompte.RowCount > 0)
            {
                cmd = new SqlCommand("insert into Operation values (" + c.idoperation + ", '" + c.lblDateOperation.Text + "','" + c.txtLibelle.Text + "','" + c.txtNumPiece.Text + "','" + c.cboTypeJournal.Text + "')", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    for (int i = 0; i < c.dgvCompte.RowCount;i++)
                    {
                        cmd = new SqlCommand("insert into OperationCompte values (" + c.idoperation + ", '" + c.dgvCompte.Rows[i].Cells[1].Value.ToString() + "','" + c.dgvCompte.Rows[i].Cells[2].Value.ToString() + "','" + c.dgvCompte.Rows[i].Cells[3].Value.ToString() + "')", con);
                        cmd.ExecuteNonQuery();

                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmdStatut = false;
                }
            }
            else
            {
                cmdStatut = false;
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return cmdStatut;
        }
        public double MontantCompte(long numcompte, string motif)
        {
            double valeur = 0; 
            if(motif == "debit")
                cmd = new SqlCommand("select debit from Compte where numcompte = " + numcompte + "", con);
            else
                cmd = new SqlCommand("select credit from Compte where numcompte = "+numcompte+"", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                valeur = double.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valeur;
        }
        public void MiseAjourMontantCompte(FormComptabilite2 c)
        {
            for (int i = 0; i < c.dgvCompte.RowCount;i++)
            {

                cmd = new SqlCommand("update Compte set debit= debit + " + double.Parse(c.dgvCompte.Rows[i].Cells[2].Value.ToString()) + ", credit = credit + " + double.Parse(c.dgvCompte.Rows[i].Cells[3].Value.ToString()) + " where numcompte=" + c.dgvCompte.Rows[i].Cells[1].Value.ToString() + " ", con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void ChargerJournal(FormComptabilite2 c)
        {
            cmd = new SqlCommand("select Operation.idoperation, dateoperation, numpiece, designation, numcompte, montantdebit, montantcredit from Operation, OperationCompte where Operation.idoperation = OperationCompte.idoperation", con);
            da = new SqlDataAdapter(cmd);
            try
            {
                dt.Clear();
                con.Open();
                da.Fill(dt);
                nbreligne = dt.Rows.Count;
                c.dgv2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            c.dgv1.Rows.Clear();
            for (int i = 0; i < nbreligne; i++)
            {
                c.dgv1.Rows.Add();
                c.dgv1.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
                c.dgv1.Rows[i].Cells[1].Value = c.dgv2.Rows[i].Cells[1].Value;
                c.dgv1.Rows[i].Cells[2].Value = c.dgv2.Rows[i].Cells[2].Value;
                c.dgv1.Rows[i].Cells[3].Value = c.dgv2.Rows[i].Cells[3].Value;
                c.dgv1.Rows[i].Cells[4].Value = c.dgv2.Rows[i].Cells[4].Value;
                c.dgv1.Rows[i].Cells[5].Value = c.dgv2.Rows[i].Cells[5].Value;
                c.dgv1.Rows[i].Cells[6].Value = c.dgv2.Rows[i].Cells[6].Value;
            }
        }
        public void ChargerCompteOperation(FormComptabilite2 c)
        {
            cmd = new SqlCommand("select distinct numcompte from OperationCompte", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                c.cboGrandLivre.Items.Clear();
                while (dr.Read())
                {
                    c.cboGrandLivre.Items.Add(dr[0].ToString());
                }
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void ChargerGrandLivre(FormComptabilite2 c, string motif)
        {
            if(motif!="tout")
            {
                c.lblIntitule.Text = TrouverLibelleCompte(c.txtNumCompte.Text);
                cmd = new SqlCommand("select Operation.idoperation, dateoperation, numpiece, designation, montantdebit, montantcredit, montantdebit-montantcredit as Solde from Operation, OperationCompte where numcompte=" + c.txtNumCompte.Text + " and Operation.idoperation = OperationCompte.idoperation", con);
                da = new SqlDataAdapter(cmd);
                try
                {
                    dt2.Clear();
                    con.Open();
                    da.Fill(dt2);
                    nbreligne = dt2.Rows.Count;
                    c.dgv2.DataSource = dt2;
                    con.Close();
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                c.dgvGrandLivre.Rows.Clear();
                for (int i = 0; i < nbreligne; i++)
                {
                    c.dgvGrandLivre.Rows.Add();
                    c.dgvGrandLivre.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
                    c.dgvGrandLivre.Rows[i].Cells[1].Value = c.dgv2.Rows[i].Cells[1].Value;
                    c.dgvGrandLivre.Rows[i].Cells[2].Value = c.dgv2.Rows[i].Cells[2].Value;
                    c.dgvGrandLivre.Rows[i].Cells[3].Value = c.dgv2.Rows[i].Cells[3].Value;
                    c.dgvGrandLivre.Rows[i].Cells[4].Value = c.dgv2.Rows[i].Cells[4].Value;
                    c.dgvGrandLivre.Rows[i].Cells[5].Value = c.dgv2.Rows[i].Cells[5].Value;
                    if(i==0)
                        c.dgvGrandLivre.Rows[i].Cells[6].Value = c.dgv2.Rows[i].Cells[6].Value;
                    else
                        c.dgvGrandLivre.Rows[i].Cells[6].Value = double.Parse(c.dgvGrandLivre.Rows[i - 1].Cells[6].Value.ToString()) + double.Parse(c.dgv2.Rows[i].Cells[6].Value.ToString());
                }
            }
            else
            {
                c.dgvGrandLivre.Rows.Clear();
                ChargerCompteOperation(c);
                for(int j=0; j< c.cboGrandLivre.Items.Count; j++)
                {
                    cmd = new SqlCommand("select Operation.idoperation, dateoperation, numpiece, designation, montantdebit, montantcredit, montantdebit-montantcredit as Solde from Operation, OperationCompte where numcompte=" + c.cboGrandLivre.Items[j].ToString() + " and Operation.idoperation = OperationCompte.idoperation", con);
                    da = new SqlDataAdapter(cmd);
                    try
                    {
                        dt2.Clear();
                        con.Open();
                        da.Fill(dt2);
                        nbreligne = dt2.Rows.Count;
                        c.dgv2.DataSource = dt2;
                        con.Close();
                    }
                    catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    c.dgvGrandLivre.Rows.Add();
                    c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[3].Value = c.cboGrandLivre.Items[j].ToString();
                    for (int i = 0; i < nbreligne; i++)
                    {
                        c.dgvGrandLivre.Rows.Add();
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[1].Value = c.dgv2.Rows[i].Cells[1].Value;
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[2].Value = c.dgv2.Rows[i].Cells[2].Value;
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[3].Value = c.dgv2.Rows[i].Cells[3].Value;
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[4].Value = c.dgv2.Rows[i].Cells[4].Value;
                        c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[5].Value = c.dgv2.Rows[i].Cells[5].Value;
                        if (i == 0)
                            c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[6].Value = c.dgv2.Rows[i].Cells[6].Value;
                        else
                            c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 1].Cells[6].Value = double.Parse(c.dgvGrandLivre.Rows[c.dgvGrandLivre.RowCount - 2].Cells[6].Value.ToString()) + double.Parse(c.dgv2.Rows[i].Cells[6].Value.ToString());

                    }
                }
            }
            
        }
        public void ChargerBalance(FormComptabilite2 c)
        {
            cmd = new SqlCommand("select numcompte, sum(montantdebit) as Débit, sum(montantcredit) as Crédit from OperationCompte group by numcompte", con);
            da = new SqlDataAdapter(cmd);
            try
            {
                dt.Clear();
                con.Open();
                da.Fill(dt);
                nbreligne = dt.Rows.Count;
                c.dgv2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            c.dgvBalance.Rows.Clear();
            for (int i = 0; i < nbreligne; i++)
            {
                c.dgvBalance.Rows.Add();
                c.dgvBalance.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
                c.dgvBalance.Rows[i].Cells[1].Value = TrouverLibelleCompte(c.dgv2.Rows[i].Cells[0].Value.ToString());
                c.dgvBalance.Rows[i].Cells[2].Value = 0;
                c.dgvBalance.Rows[i].Cells[3].Value = 0;
                c.dgvBalance.Rows[i].Cells[4].Value = c.dgv2.Rows[i].Cells[1].Value;
                c.dgvBalance.Rows[i].Cells[5].Value = c.dgv2.Rows[i].Cells[2].Value;
                if (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()) > double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()))
                    c.dgvBalance.Rows[i].Cells[6].Value = (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()))-(double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()));
                else if(double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()) < double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString()))
                    c.dgvBalance.Rows[i].Cells[7].Value = (double.Parse(c.dgvBalance.Rows[i].Cells[3].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[5].Value.ToString())) - (double.Parse(c.dgvBalance.Rows[i].Cells[2].Value.ToString()) + double.Parse(c.dgvBalance.Rows[i].Cells[4].Value.ToString()));
                else
                {
                    c.dgvBalance.Rows[i].Cells[6].Value = 0;
                    c.dgvBalance.Rows[i].Cells[7].Value = 0;
                }
            }
        }

        /*
         * ======================================================
         * PATIENT
         * ======================================================
         */
        public string FormerNoms(string nom, string postnom, string prenom)
        {
            if (nom + postnom + prenom == "")
                nom = "Noms";
            else
                nom = string.Format("{0} {1} {2}", nom, postnom, prenom);
            return nom;
        }
        public long TrouverIdAbonne(string nomabonne)
        {
            cmd = new SqlCommand("select idabonne from Abonne where nomabonne = '" + nomabonne + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public string TrouverNomAbonne(long idabonne)
        {
            cmd = new SqlCommand("select nomabonne from Abonne where idabonne = '" + idabonne + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string CalculerAgePatient(string chaine)
        {
            if (chaine == "")
                chaine = "Age :";
            else
            {
                if ((DateTime.Now.Year - int.Parse(chaine)) < 1)
                    chaine = "Age : moins d'un an";
                else
                    chaine = string.Format("Age : {0} ans", (DateTime.Now.Year - int.Parse(chaine)));
            }
            return chaine;
        }
        
        bool found = false;
        /*
         * ====================================================
         * PRODUIT
         * ====================================================
         */        /*
         * ====================================================
         * FICHE
         * ====================================================
         */
        public void GenererFiche(string noms, string sexe, string age, string adresse, string personnecontact)
        {
            ////créer l'application
            //Word.Application objWord = new Word.Application();
            //objWord.Visible = true;
            //objWord.WindowState = Word.WdWindowState.wdWindowStateMaximize;

            ////créer le document Word
            //Word.Document objDoc = objWord.Documents.Add();
            //objDoc.Range(Type.Missing, Type.Missing).Font.Name = "Tahoma";
            //objDoc.Range(Type.Missing, Type.Missing).Font.Size = 10;
            ////objDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
            //// créer les paragraphes
            //Word.Paragraph objpara1, objpara2, objpara3, objpara4;

            //objpara1 = objDoc.Paragraphs.Add();
            ////Premier tableau pour avant le titre
            //Word.Table table; table = objDoc.Tables.Add(objpara1.Range, 1, 1, Type.Missing, Type.Missing);
            //table.Cell(1, 1).Range.Font.Size = 8;
            //table.Cell(1, 1).Range.Text = "QUALITE - COMPETENCE - HUMANISME\r\nPOLYCLINIQUE SUMEDCO\r\n345, Avenue Inga, Quartier Minkoka, Commune de Dibindi, Ville de Mbujimayi, Province du Kasaï Oriental, RDC\r\nTéléphone: 243851453595-243816096706-243854630801\r\nemail: sumedcombujimayi@gmail.com";
            //table.Cell(1, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //table.Cell(1, 1).Range.Font.Bold = 8;
            //table.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;

            ////table.Cell(2, 1).Range.Paragraphs.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            ////table.Cell(2, 1).Range.Font.Bold = 0;
            ////table.Cell(2, 1).Range.InlineShapes.AddPicture(@"C:\Program Files (x86)\TaxCollector\img1.png", true, true, Type.Missing);
            
            //// titre
            //objpara1.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //objpara2 = objDoc.Paragraphs.Add();
            //objpara2.Range.Font.Bold = 10;
            //objpara2.Range.Text = "\nFICHE DE CONSULTATION\n";

            //objpara2.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //objpara3 = objDoc.Paragraphs.Add();
            //Word.Table table1; table1 = objDoc.Tables.Add(objpara3.Range, 1, 1, Type.Missing, Type.Missing);
            //table1.Cell(1, 1).Range.Text = string.Format("Noms: {0} Sexe: {1}\nAge: {2} Adresse: {3} ZS/HZS\nPersonne à contacter: {4}\nTA:....................Poids:....................T°:....................P':....................R':....................\n", noms, sexe, age, adresse, personnecontact);
            //table1.Cell(1, 1).Range.ParagraphFormat.SpaceAfter = 0;
            
            //objpara4 = objDoc.Paragraphs.Add();
            //objpara4.Range.Text = "\n";
            ////Premier tableau pour avant le titre
            //Word.Table table2; table2 = objDoc.Tables.Add(objpara4.Range, 37, 3, true, true);
            //table2.Range.Font.Bold = 0;
            //table2.Cell(1, 1).Range.Text = "Date";
            //table2.Cell(1, 2).Range.Text = "Description";
            //table2.Cell(1, 3).Range.Text = "Observation";
            //noms = "Fiche_"+noms;
            //objDoc.SaveAs2(@"C:\Users\Public\Documents\"+noms+".docx");
        }
        /*
         * ====================================================
         * CONSULTATION
         * ====================================================
         */
        public void ChargerParametre(FormConsultation c)
        {
            //cmd = new SqlCommand("select * from Parametre", con);
            //try
            //{
            //    con.Open();
            //    dr = cmd.ExecuteReader();
            //    c.dgvParametre.Rows.Clear();
            //    while (dr.Read())
            //    {
            //        c.dgvParametre.Rows.Add();
            //        c.dgvParametre.Rows[c.dgvParametre.RowCount - 1].Cells[0].Value = dr[0].ToString();
            //        c.dgvParametre.Rows[c.dgvParametre.RowCount - 1].Cells[1].Value = dr[1].ToString();
            //        c.dgvParametre.Rows[c.dgvParametre.RowCount - 1].Cells[2].Value = "";
            //    }
            //    con.Close();
            //}
            //catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public string TrouverNomPatient(long idpatient)
        {
            cmd = new SqlCommand("select noms from Patient where idpatient = " + idpatient + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit noms de Patient
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string TrouverSexePatient(long idpatient)
        {
            cmd = new SqlCommand("select sexe from Patient where idpatient = " + idpatient + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit sexe de Patient
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string TrouverAgePatient(long idpatient)
        {
            cmd = new SqlCommand("select anneenaiss from Patient where idpatient = " + idpatient + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit anneenaiss de Patient
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return CalculerAgePatient(nom);
        }
        public long TrouverIdMedecin(string nomsmedecin)
        {
            cmd = new SqlCommand("select idmedecin from Medecin where nomsmedecin = '" + nomsmedecin + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //id reçoit la valeur de idmedecin
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public string TrouverNomMedecin(long idmedecin)
        {
            cmd = new SqlCommand("select nomsmedecin from Medecin where idmedecin = '" + idmedecin + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit la valeur de nomsmedecin
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public void AfficherDGVConsultation(MFormConsultation c)
        {
            //cmd = new SqlCommand("select * from Consultation where dateconsultation = '" + DateTime.Now.ToShortDateString() + "' or dateconsultation = '" + DateTime.Now.Date.AddDays(-1).ToShortDateString() + "'", con);
            //da = new SqlDataAdapter(cmd);
            //try
            //{
            //    dt.Clear();
            //    con.Open();
            //    da.Fill(dt);
            //    nbreligne = dt.Rows.Count;
            //    c.dgv2.DataSource = dt;
            //    con.Close();
            //}
            //catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //c.dgv1.Rows.Clear();
            //for (int i = 0; i < nbreligne; i++)
            //{
            //    c.dgv1.Rows.Add();
            //    c.dgv1.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
            //    c.dgv1.Rows[i].Cells[1].Value = TrouverNomPatient(long.Parse(c.dgv2.Rows[i].Cells[1].Value.ToString()));
            //    c.dgv1.Rows[i].Cells[2].Value = TrouverNomMedecin(long.Parse(c.dgv2.Rows[i].Cells[2].Value.ToString()));
            //    c.dgv1.Rows[i].Cells[3].Value = c.dgv2.Rows[i].Cells[3].Value;
            //    c.dgv1.Rows[i].Cells[4].Value = c.dgv2.Rows[i].Cells[4].Value;
            //    c.dgv1.Rows[i].Cells[5].Value = c.dgv2.Rows[i].Cells[5].Value;
            //    c.dgv1.Rows[i].Cells[6].Value = c.dgv2.Rows[i].Cells[6].Value;
            //    c.dgv1.Rows[i].Cells[7].Value = c.dgv2.Rows[i].Cells[7].Value;
            //    c.dgv1.Rows[i].Cells[8].Value = c.dgv2.Rows[i].Cells[8].Value;
            //}
            //c.lblTotal.Text = string.Format("Total : {0}", c.dgv1.RowCount);
        }
        public void TrouverPlaintePrescription(MFormConsultation c)
        {
            //cmd = new SqlCommand("select idplainte,numplainte,signe,duree,intensite from LignePlainte where idconsultation=" + int.Parse(c.dgv1.CurrentRow.Cells[0].Value.ToString()) + "", con);
            //da = new SqlDataAdapter(cmd);
            //try
            //{
            //    dt2.Clear();
            //    con.Open();
            //    da.Fill(dt2);
            //    nbreligne = dt2.Rows.Count;
            //    c.dgv2.DataSource = dt2;
            //    con.Close();
            //}
            //catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //c.dgvPlainte.Rows.Clear();
            //for (int i = 0; i < nbreligne; i++)
            //{
            //    c.dgvPlainte.Rows.Add();
            //    c.dgvPlainte.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
            //    c.dgvPlainte.Rows[i].Cells[1].Value = c.dgv2.Rows[i].Cells[1].Value;
            //    c.dgvPlainte.Rows[i].Cells[2].Value = c.dgv2.Rows[i].Cells[2].Value;
            //    c.dgvPlainte.Rows[i].Cells[3].Value = c.dgv2.Rows[i].Cells[3].Value;
            //    c.dgvPlainte.Rows[i].Cells[4].Value = c.dgv2.Rows[i].Cells[4].Value;
            //}
            //cmd = new SqlCommand("select idprescription,numprescription,libelleprescription from LignePrescription where idconsultation=" + int.Parse(c.dgv1.CurrentRow.Cells[0].Value.ToString()) + "", con);
            //da = new SqlDataAdapter(cmd);
            //try
            //{
            //    dt3.Clear();
            //    con.Open();
            //    da.Fill(dt3);
            //    nbreligne = dt3.Rows.Count;
            //    c.dgv2.DataSource = dt3;
            //    con.Close();
            //}
            //catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            //c.dgvPrescription.Rows.Clear();
            //for (int i = 0; i < nbreligne; i++)
            //{
            //    c.dgvPrescription.Rows.Add();
            //    c.dgvPrescription.Rows[i].Cells[0].Value = c.dgv2.Rows[i].Cells[0].Value;
            //    c.dgvPrescription.Rows[i].Cells[1].Value = c.dgv2.Rows[i].Cells[1].Value;
            //    c.dgvPrescription.Rows[i].Cells[2].Value = c.dgv2.Rows[i].Cells[2].Value;
            //}
        }

        /*
         * ====================================================
         * FORME, CONDITIONNEMENT, COMPTE, MALADIE, SIGNE (ITEM), CATEGORIE
         * ====================================================
         */
        /*
         * ====================================================
         * REQUISITION
         * ====================================================
         */
        public long TrouverStock(long idproduit, long idforme, long idcondition)
        {          
            cmd = new SqlCommand("select stockdispo from Stock where idproduit = " + idproduit + " and idforme=" + idforme + " and idcondition=" + idcondition + " ", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //id reçoit la valeur de stockdispo
                id = long.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public long TrouverIdForme(string libelle)
        {
            cmd = new SqlCommand("select idforme from Forme where libelleforme = '" + libelle + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Forme\n\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public long TrouverIdCondition(string libelle)
        {
            cmd = new SqlCommand("select idcondition from Condition where libellecondition = '" + libelle + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("Conditionnement\n\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public string TrouverNomProduit(long idproduit)
        {
            cmd = new SqlCommand("select nomproduit from Produit where idproduit = '" + idproduit + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit nomproduit de Produit
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string SpecificationProduit(long idproduit, long idforme, long idcondition)
        {
            cmd = new SqlCommand("select specification from Stock where idproduit = " + idproduit + " and idforme=" + idforme + " and idcondition=" + idcondition + " ", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit specification de Produit
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string LibelleForme(int idforme)
        {
            cmd = new SqlCommand("select libelleforme from Forme where idforme = '" + idforme + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit libelleforme de Forme
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public string LibelleCondition(int idcondition)
        {
            cmd = new SqlCommand("select libellecondition from Condition where idcondition = '" + idcondition + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit libellecondition de Condition
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public long TrouverIdService(string nomservice)
        {
            cmd = new SqlCommand("select idservice from ServiceDemande where nomservice = '" + nomservice + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return id;
        }
        public string TrouverNomService(long idservice)
        {
            cmd = new SqlCommand("select nomservice from ServiceDemande where idservice = '" + idservice + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit nomservice de ServiceDemande
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
        public long TrouverPrixService(long idservice)
        {
            cmd = new SqlCommand("select prixservice from ServiceDemande where idservice = '" + idservice + "'", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //id reçoit le prixservice de ServiceDemande
                montant = long.Parse(dr[0].ToString());
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return montant;
        }
        long montant = 0;

        /*
         * ====================================================
         * TRESORERIE
         * ====================================================
         */
        public string TrouverLibelleCompte(int numcompte)
        {
            cmd = new SqlCommand("select libellecompte from Compte where numcompte = " + numcompte + "", con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                //nom reçoit libellecompte de Compte
                nom = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            return nom;
        }
    }
}
