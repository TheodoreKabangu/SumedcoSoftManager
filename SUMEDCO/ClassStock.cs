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
        float idfloat = 0F;
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
                case "condition": cmdtxt = "select max(idcondition) from Conditionnement"; break;
                case "stockpharma": cmdtxt = "select max(idstockpharma) from LigneStockPharma"; break;
                case "autreproduit": cmdtxt = "select max(idproduit) from ProduitAutreStock"; break;
                case "commande": cmdtxt = "select max(idcommande) from LigneCommande"; break;
                case "appro": cmdtxt = "select max(idappro) from LigneAppro"; break;
                case "approautre": cmdtxt = "select max(idappro) from LigneApproAutreStock"; break;
                case "requisition": cmdtxt = "select max(idrequisition) from LigneRequisition"; break;
                case "requisitionautre": cmdtxt = "select max(idrequisition) from LigneRequisitionAutre"; break;
                case "mouvement": cmdtxt = "select max(idmouvement) from Mouvement"; break;
                case "mouvementautre": cmdtxt = "select max(idmvt) from MouvementAutreStock"; break;
                case "mouvementpharma": cmdtxt = "select max(idmvtpharma) from MouvementPharma"; break;
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
                        r.Show();
                    }
                    else if (c.poste == "recette")
                    {
                        MFormRecette rec = new MFormRecette();
                        rec.idutilisateur = id;
                        rec.Show();
                    }
                    else if (c.poste == "infirmier")
                    {
                        MFormInfirmerie inf = new MFormInfirmerie();
                        inf.idutilisateur = id;
                        inf.Show();
                    }
                    else if (c.poste == "médecin")
                    {
                        if (chaine == c.medecin)
                        {
                            MFormConsultation cons = new MFormConsultation();
                            cons.idmedecin = c.idmedecin;
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
                        ab.Show();
                    }
                    else if (c.poste == "dépense")
                    {
                        MFormDepense d = new MFormDepense();
                        d.idutilisateur = id;
                        d.Show();
                    }
                    else if (c.poste == "comptable")
                    {
                        MFormComptabilite co = new MFormComptabilite();
                        co.idutilisateur = id;
                        co.Show();
                    }
                    else if (c.poste == "pharmacie")
                    {
                        MFormPharmacie ph = new MFormPharmacie();
                        ph.idutilisateur = id;
                        ph.Show();
                    }
                    else if (c.poste == "stock")
                    {
                        MFormStock s = new MFormStock();
                        s.idutilisateur = id;
                        s.Show();
                    }
                    
                    if (c.access_autorise)
                        c.Close();
            }
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
        public void AfficherSousForm(MFormAdmin a, FormStockPharma childForm)
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
        public void ChargerLigneStock(FormFactureProduit2 f)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select idstock, conditionnement, dosage, forme, numlot, prixunitaire from LigneStock where idproduit= @idproduit", con);
                cmd.Parameters.AddWithValue("@idproduit", id);
                dr = cmd.ExecuteReader();
                f.dgvStock.Rows.Clear();
                id = 0;
                while (dr.Read())
                {
                    f.dgvStock.Rows.Add();
                    f.dgvStock.Rows[id].Cells[0].Value = dr[0].ToString();
                    f.dgvStock.Rows[id].Cells[1].Value = dr[1].ToString();
                    f.dgvStock.Rows[id].Cells[2].Value = dr[2].ToString();
                    f.dgvStock.Rows[id].Cells[3].Value = dr[3].ToString();
                    f.dgvStock.Rows[id].Cells[4].Value = dr[4].ToString();
                    f.dgvStock.Rows[id].Cells[6].Value = dr[5].ToString();
                    id += 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            for (int i = 0; i < f.dgvStock.RowCount; i++)
            {
                f.dgvStock.Rows[i].Cells[5].Value = DateExpNumLot(f.dgvStock.Rows[i].Cells[4].Value.ToString());
            }
        }
        public int VerifierNomProduit(string nomproduit, string descriptif, string motif)
        {
            id = 0;
            con.Open();
            try
            {
                if (motif == "produit")
                    cmd = new SqlCommand("select count(nomproduit) from Produit where nomproduit = @nomproduit", con);
                else
                {
                    cmd = new SqlCommand("select count(nomproduit) from ProduitAutreStock where nomproduit = @nomproduit and descriptif = @descriptif", con);
                    cmd.Parameters.AddWithValue("@descriptif", descriptif);
                }
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
        public void Enregistrer(FormProduitPharma p)
        {
            if(p.txtProduit.Text !="")
            {
                if (VerifierNomProduit(p.txtProduit.Text, "", "produit") == 0)
                {
                    p.idproduit = NouveauID("produit");
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Produit values (@id, @nom)", con);
                        cmd.Parameters.AddWithValue("@id", p.idproduit);
                        cmd.Parameters.AddWithValue("@nom", p.txtProduit.Text);
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
                    Annuler(p);
                    Afficher(p, "");
                }
                else MessageBox.Show("Le nom du produit fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Modifier(FormProduitPharma p)
        {
            if (p.txtProduit.Text != "")
            {
                if (VerifierNomProduit(p.txtProduit.Text, "", "produit") == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update Produit set nomproduit = @nom where idproduit = @id", con);
                        cmd.Parameters.AddWithValue("@id", p.idproduit);
                        cmd.Parameters.AddWithValue("@nom", p.txtProduit.Text);
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
                    Annuler(p);
                    Afficher(p, "");
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
        public void Supprimer(FormProduitPharma p)
        {
            if (CompterStockProduit(p.idproduit) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from Produit where idproduit = @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idproduit);
                    cmd.Transaction = tx;
                    cmd.ExecuteNonQuery();
                    tx.Commit();
                    MessageBox.Show("Supprimé avec succès", "Mise à jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    p.dgvProduit.Rows.RemoveAt(p.dgvProduit.CurrentRow.Index);
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

        #region AUTRE_PRODUIT
        public void Enregistrer(FormProduitAutreStock p)
        {
            if (p.txtProduit.Text != "" && p.cboCompte.Text != "" && p.cboUnite.Text != "")
            {
                if (VerifierNomProduit(p.txtProduit.Text, p.txtDescriptif.Text, "autreproduit") == 0)
                {
                    p.idproduit = NouveauID("autreproduit");
                    if (p.txtCMM.Text == "0") p.txtCMM.Text = "0";
                    if (p.txtDescriptif.Text == "") p.txtDescriptif.Text = "RAS";
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into ProduitAutreStock values (@id, @numcompte, @nom, @unite, @qte, @CMM, @descriptif)", con);
                        cmd.Parameters.AddWithValue("@id", p.idproduit);
                        cmd.Parameters.AddWithValue("@nom", p.txtProduit.Text);
                        cmd.Parameters.AddWithValue("@numcompte", p.numcompte);
                        cmd.Parameters.AddWithValue("@unite", p.cboUnite.Text);
                        cmd.Parameters.AddWithValue("@qte", "0"); //Qté initiale = 0
                        cmd.Parameters.AddWithValue("@CMM", p.txtCMM.Text);
                        cmd.Parameters.AddWithValue("@descriptif", p.txtDescriptif.Text);
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
                    Annuler(p);
                    Afficher(p, "");
                }
                else MessageBox.Show("Le stock du produit fourni existe déjà", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Modifier(FormProduitAutreStock p)
        {
            if (p.txtProduit.Text != "" && p.cboCompte.Text !="" && p.cboUnite.Text !="" && p.txtCMM.Text !="")
            {
                if (VerifierNomProduit(p.txtProduit.Text, p.txtDescriptif.Text, "autreproduit") == 0)
                {
                    if (p.txtDescriptif.Text == "") p.txtDescriptif.Text = "RAS";
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update ProduitAutreStock set nomproduit = @nom, numcompte= @numcompte, unite= @unite, CMM= @CMM, descriptif = @descriptif where idproduit = @id", con);
                        cmd.Parameters.AddWithValue("@id", p.idproduit);
                        cmd.Parameters.AddWithValue("@nom", p.txtProduit.Text);
                        cmd.Parameters.AddWithValue("@numcompte", p.numcompte);
                        cmd.Parameters.AddWithValue("@unite", p.cboUnite.Text);
                        cmd.Parameters.AddWithValue("@CMM", p.txtCMM.Text);
                        cmd.Parameters.AddWithValue("@descriptif", p.txtDescriptif.Text);

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
                    Annuler(p);
                    Afficher(p, "");
                }
                else MessageBox.Show("Le stock du produit fourni existe déjà", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public int CompterMvtAutreProduit(int idproduit)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idmvt) from MouvementAutreStock where idproduit = @id", con);
                cmd.Parameters.AddWithValue("@id", idproduit);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void Supprimer(FormProduitAutreStock p)
        {
            if (CompterMvtAutreProduit(p.idproduit) == 0)
            {
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("delete from ProduitAutreStock where idproduit = @id", con);
                    cmd.Parameters.AddWithValue("@id", p.idproduit);
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
                p.dgvProduit.Rows.RemoveAt(p.dgvProduit.CurrentRow.Index);
            }
            else
                MessageBox.Show("Ce produit est déjà impliqué dans les stocks,\npour raison de cohérence, il ne peut être supprimé", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Recuperer(FormProduitAutreStock p)
        {
            if (p.dgvProduit.RowCount != 0)
            {
                p.idproduit = int.Parse(p.dgvProduit.CurrentRow.Cells[0].Value.ToString());
                p.numcompte = p.dgvProduit.CurrentRow.Cells[1].Value.ToString();
                
                p.cboCompte.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboCompte.Text = p.dgvProduit.CurrentRow.Cells[2].Value.ToString();
                p.cboCompte.DropDownStyle = ComboBoxStyle.DropDownList;

                p.txtProduit.Text = p.dgvProduit.CurrentRow.Cells[3].Value.ToString();
                
                p.cboUnite.DropDownStyle = ComboBoxStyle.DropDown;
                p.cboUnite.Text = p.dgvProduit.CurrentRow.Cells[4].Value.ToString();
                p.cboUnite.DropDownStyle = ComboBoxStyle.DropDownList;
                p.txtCMM.Text = p.dgvProduit.CurrentRow.Cells[6].Value.ToString();

                p.btnModifier.Enabled = true;
                p.btnSupprimer.Enabled = true;
                p.btnEnregistrer.Enabled = false;
            }
        }
        public void Afficher(FormProduitAutreStock p, string motif)
        {
            con.Open();
            try
            {
                if(motif == "recherche")
                {
                    if (p.cboCompte.Text != "")
                    {
                        cmd = new SqlCommand("select * from ProduitAutreStock where numcompte= @numcompte", con);
                        cmd.Parameters.AddWithValue("@numcompte", p.numcompte);
                    }
                    else if (p.cboCompte.Text == "" && p.txtProduit.Text != "")
                        cmd = new SqlCommand("select * from ProduitAutreStock where nomproduit like '" + p.txtProduit.Text + "%'", con);
                    if (p.cboCompte.Text != "" || p.cboCompte.Text == "" && p.txtProduit.Text != "")
                    {
                        dr = cmd.ExecuteReader();
                        p.dgvProduit.Rows.Clear();
                        while (dr.Read())
                        {
                            p.dgvProduit.Rows.Add();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[3].Value = dr[2].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[4].Value = dr[3].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[5].Value = dr[4].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[6].Value = dr[5].ToString();
                            p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[7].Value = dr[6].ToString();
                        }
                    }
                    if (p.cboCompte.Text == "" && p.txtProduit.Text == "")
                        MessageBox.Show("Précisez la catégorie ou le produit dont vous voulez afficher les résultats", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cmd = new SqlCommand("select * from ProduitAutreStock where idproduit= @idproduit", con);
                    cmd.Parameters.AddWithValue("@idproduit", p.idproduit);
                    dr = cmd.ExecuteReader();
                    p.dgvProduit.Rows.Clear();
                    while (dr.Read())
                    {
                        p.dgvProduit.Rows.Add();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[3].Value = dr[2].ToString();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[4].Value = dr[3].ToString();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[5].Value = dr[4].ToString();
                        p.dgvProduit.Rows[p.dgvProduit.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    }
                }                
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Annuler(FormProduitAutreStock p)
        {
            p.cboCompte.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboCompte.Text = "";
            p.cboCompte.DropDownStyle = ComboBoxStyle.DropDownList;
            p.txtProduit.Text = "";
            p.cboUnite.DropDownStyle = ComboBoxStyle.DropDown;
            p.cboUnite.SelectedText = "";
            p.cboUnite.DropDownStyle = ComboBoxStyle.DropDownList;
            p.dgvProduit.Rows.Clear();
            p.btnModifier.Enabled = false;
            p.btnSupprimer.Enabled = false;
            p.btnEnregistrer.Enabled = true;
        }
        #endregion

        #region STOCK_PRODUIT
        public void Annuler(FormProduitPharmaStock s)
        {
            s.btnModifier.Enabled = false;
            s.dgvStock.Rows.Clear();
            s.btnSupprimer.Enabled = false;
            s.btnEnregistrer.Enabled = true;
            s.cboConditionnement.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboConditionnement.SelectedText = "";
            s.cboConditionnement.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtDosage.Text = "";
            s.cboForme.DropDownStyle = ComboBoxStyle.DropDown;
            s.cboForme.SelectedText = "";
            s.cboForme.DropDownStyle = ComboBoxStyle.DropDownList;
            s.txtCMM.Text = "";
        }
        public void Afficher(FormProduitPharmaStock s, string motif)
        {
            con.Open();
            try
            {
                if (motif == "recherche")
                {
                    if (s.cboProduit.Text != "")
                    {
                        cmd = new SqlCommand("select idstock, idproduit, conditionnement, dosage, forme, CMM from LigneStock where idproduit = @id", con);
                        cmd.Parameters.AddWithValue("@id", s.idproduit);
                    }
                }
                else
                {
                    cmd = new SqlCommand("select idstock, idproduit, conditionnement, dosage, forme, CMM from LigneStock where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                }

                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = dr[5].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            for (int i = 0; i < s.dgvStock.RowCount; i++)
            {
                s.dgvStock.Rows[i].Cells[2].Value = TrouverNom("produit", int.Parse(s.dgvStock.Rows[i].Cells[1].Value.ToString()));
            }
        }
        public int CompterMvtStock(int idstock)
        {
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(id) form Mouvement where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public int VerifierLigneStock(FormProduitPharmaStock s)
        {
            //Vérifier plutôt le numLot à l'approvisionnement s'il existe déjà!!!
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select count(idstock) from LigneStock where idproduit = @idproduit and conditionnement = @condition and dosage= @dosage and forme= @forme", con);
                cmd.Parameters.AddWithValue("@idproduit", s.idproduit);
                cmd.Parameters.AddWithValue("@condition", s.cboConditionnement.Text);
                cmd.Parameters.AddWithValue("@dosage", s.txtDosage.Text);
                cmd.Parameters.AddWithValue("@forme", s.cboForme.Text);
                dr = cmd.ExecuteReader();
                dr.Read();
                id = int.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return id;
        }
        public void AjouterStockPharma(FormProduitPharmaStock s)
        {
            s.idstockpharma = NouveauID("stockpharma");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneStockPharma values (@id, @idstock, @qte)", con);
                cmd.Parameters.AddWithValue("@id", s.idstockpharma);
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
        public void Enregistrer(FormProduitPharmaStock s)
        {
            if (s.cboProduit.Text != "" && s.cboConditionnement.Text != "" && s.txtDosage.Text != "" && s.cboForme.Text != "")
            {
                if (VerifierLigneStock(s) == 0)
                {
                    s.idstock = NouveauID("stock");
                    if (s.txtCMM.Text == "") s.txtCMM.Text = "0";
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into LigneStock values (@id, @idproduit, @condition, @dosage, @forme, @numlot, @prix, @qte, @CMM)", con);
                        cmd.Parameters.AddWithValue("@id", s.idstock);
                        cmd.Parameters.AddWithValue("@idproduit", s.idproduit);
                        cmd.Parameters.AddWithValue("@condition", s.cboConditionnement.Text);
                        cmd.Parameters.AddWithValue("@dosage", s.txtDosage.Text);
                        cmd.Parameters.AddWithValue("@forme", s.cboForme.Text);
                        cmd.Parameters.AddWithValue("@numlot", "0");
                        cmd.Parameters.AddWithValue("@prix", "0");
                        cmd.Parameters.AddWithValue("@qte", "0"); // chaque stock commence avec une quantité de 0
                        cmd.Parameters.AddWithValue("@CMM", s.txtCMM.Text);
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
                    //Une ligne du Stock pharmacie
                    AjouterStockPharma(s);
                    MessageBox.Show("Enregistré avec succès", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Annuler(s);
                    Afficher(s, "");
                }
                else MessageBox.Show("Les valeurs fournies correspondent à une ligne de stock déjà existante", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Modifier(FormProduitPharmaStock s)
        {
            if (s.cboProduit.Text != "" && s.cboConditionnement.Text != "" && s.txtDosage.Text != "" && s.cboForme.Text != "")
            {
                if (s.txtCMM.Text == "") s.txtCMM.Text = "0";
                con.Open();
                SqlTransaction tx = con.BeginTransaction();
                try
                {
                    cmd = new SqlCommand("update LigneStock set  idproduit= @idproduit, conditionnement= @condition, dosage= @dosage, forme = @forme, CMM= @CMM where idstock = @id", con);
                    cmd.Parameters.AddWithValue("@id", s.idstock);
                    cmd.Parameters.AddWithValue("@idproduit", s.idproduit);
                    cmd.Parameters.AddWithValue("@condition", s.cboConditionnement.Text);
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
                Afficher(s, "");
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Supprimer(FormProduitPharmaStock s)
        {
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
        public void Recuperer(FormProduitPharmaStock s)
        {
            if(s.dgvStock.RowCount !=0)
            {
                s.idstock = int.Parse(s.dgvStock.CurrentRow.Cells[0].Value.ToString());
                s.idproduit = int.Parse(s.dgvStock.CurrentRow.Cells[1].Value.ToString());
                s.cboProduit.DropDownStyle = ComboBoxStyle.DropDown;
                s.cboProduit.Text = s.dgvStock.CurrentRow.Cells[2].Value.ToString();
                s.cboProduit.DropDownStyle = ComboBoxStyle.DropDownList;

                s.cboConditionnement.DropDownStyle = ComboBoxStyle.DropDown;
                s.cboConditionnement.Text = s.dgvStock.CurrentRow.Cells[3].Value.ToString();
                s.cboConditionnement.DropDownStyle = ComboBoxStyle.DropDownList;

                s.txtDosage.Text = s.dgvStock.CurrentRow.Cells[4].Value.ToString();

                s.cboForme.DropDownStyle = ComboBoxStyle.DropDown;
                s.cboForme.Text = s.dgvStock.CurrentRow.Cells[5].Value.ToString();
                s.cboForme.DropDownStyle = ComboBoxStyle.DropDownList;
                
                s.txtCMM.Text = s.dgvStock.CurrentRow.Cells[6].Value.ToString();                
            }
        }
        public string TrouverLibelleStock(int idstock)
        {
            string chaine = "";
            id = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select idproduit, conditionnement, dosage, forme, numlot from LigneStock where idstock = @idstock", con);
                cmd.Parameters.AddWithValue("@idstock", idstock);
                dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    id = int.Parse(dr[0].ToString());
                    chaine = string.Format("{0} {1} {2} {3}", dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            return string.Format("{0} {1}", TrouverNom("produit", id), chaine);
        }
        public void DetailsStock(FormPrescription p)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select conditionnement, dosage, forme, numlot, prixunitaire from LigneStock where idstock = @idstock", con);
                cmd.Parameters.AddWithValue("@idstock", p.idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                p.txtConditionnement.Text = dr[0].ToString();
                p.txtDosage.Text = dr[1].ToString();
                p.txtForme.Text = dr[2].ToString();
                p.txtNumLot.Text = dr[3].ToString();
                p.prixunitaire = int.Parse(dr[4].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            p.lblDate.Text = "Expire en ";
            p.lblDate.Text = String.Format("{0}{1}", p.lblDate.Text, DateExpNumLot(p.txtNumLot.Text));
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
        public float PrixStock(int idstock)
        {
            idfloat = 0;
            con.Open();
            try
            {
                cmd = new SqlCommand("select prixunitaire from LigneStock where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                dr = cmd.ExecuteReader();
                dr.Read();
                idfloat = float.Parse(dr[0].ToString());
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            return idfloat;
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
        public void EnregistrerRequisition(FormCommande c, string dest)
        {
            c.idrequisition = NouveauID("requisition");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneRequisition values (@id, @date_jour, @idstock, @qterequise, @qteaccordee)", con);
                cmd.Parameters.AddWithValue("@id", c.idrequisition);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Text);
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
        public void EnregistrerRequisition(FormCommandeAutre c, string dest)
        {
            c.idrequisition = NouveauID("requisitionautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneRequisitionAutre values (@id, @date_jour, @idproduit, @qterequise, @qteaccordee)", con);
                cmd.Parameters.AddWithValue("@id", c.idrequisition);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idproduit", c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@qterequise", c.dgvCommande.CurrentRow.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@qteaccordee", c.dgvCommande.CurrentRow.Cells[6].Value.ToString());
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
        public void AfficherSousForm(MFormPharmacie ph, FormBonRecette childForm)
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
        public void Encaisser(MFormPharmacie ph, FormBonRecette childForm)
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
            childForm.lblCaisseCDF.Visible = false;
            childForm.lblCaisseUSD.Visible = false;
            childForm.poste = "recette";
            childForm.Show();
        }

        public void AfficherSousForm(MFormPharmacie c, FormStockPharma childForm)
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
            childForm.btnNouveauStock.Enabled = false;
            childForm.dgvStock.Columns[9].Visible = false;    
            childForm.Show();
        }
        public void AfficherSousForm(MFormPharmacie c, FormConsultation childForm)
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
            childForm.Show();
        }
        #endregion

        #region GESTION_STOCKS_PHARMA
        public void AfficherSousForm(MFormStock s, FormStockPharma childForm)
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
            childForm.btnEditerRequisition.Enabled = false;
            childForm.Show();
        }
        public void HistoriqueApproStockPharma(FormApproStockPharma a)
        {
            a.poste = "stock";
            a.Show();
        }
        public void HistoriqueApproStockPharma(MFormComptabilite c, FormApproStockPharma childForm)
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
        public void AfficherToutStock(FormStockPharma s)
        {
            if (s.poste == "pharmacie")
            {
                con.Open();
                try
                {
                    cmd = new SqlCommand("select * from LigneStockPharma ", con);
                    dr = cmd.ExecuteReader();
                    s.dgvStock.Rows.Clear();
                    while (dr.Read())
                    {
                        s.dgvStock.Rows.Add();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = dr[2].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[9].Value = "";
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[10].Value = dr[1].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                if (s.dgvStock.RowCount > 0)
                {
                    DetailsStock2(s.dgvStock);
                }
            }
            else
            {
                con.Open();
                try
                {
                    cmd = new SqlCommand("select * from LigneStock ", con);
                    dr = cmd.ExecuteReader();
                    s.dgvStock.Rows.Clear();
                    while (dr.Read())
                    {
                        s.dgvStock.Rows.Add();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[2].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[3].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = dr[4].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = dr[5].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = dr[6].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = dr[7].ToString();
                        s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[9].Value = dr[8].ToString();
                    }
                }
                catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                con.Close();
                if (s.dgvStock.RowCount > 0)
                {
                    for (int i = 0; i < s.dgvStock.RowCount; i++)
                    {
                        s.dgvStock.Rows[i].Cells[2].Value = TrouverNom("produit", int.Parse(s.dgvStock.Rows[i].Cells[1].Value.ToString()));
                    }
                }
            }
        }
        public void AfficherStocksProduit(FormStockPharma s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneStock where idproduit = @id", con);
                cmd.Parameters.AddWithValue("@id", s.idproduit);
                dr = cmd.ExecuteReader();
                s.dgvStock.Rows.Clear();
                while (dr.Read())
                {
                    s.dgvStock.Rows.Add();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[3].Value = dr[2].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[4].Value = dr[3].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[7].Value = dr[6].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[8].Value = dr[7].ToString();
                    s.dgvStock.Rows[s.dgvStock.RowCount - 1].Cells[9].Value = dr[8].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            for (int i = 0; i < s.dgvStock.RowCount; i++)
            {
                s.dgvStock.Rows[i].Cells[2].Value = TrouverNom("produit", int.Parse(s.dgvStock.Rows[i].Cells[1].Value.ToString()));
            }
            s.btnStock.Enabled = false;
        }
        public void FicheStock(FormStockPharma s)
        {
            // Afficher tous les mouvements concernant le stock sélectionné
            s.btnFicheStock.Enabled = false;
        }
        public void EntreesStock(FormStockPharma s)
        {
            // Afficher tous les mouvements concernant le stock sélectionné
            s.btnEntrees.Enabled = false;
        }
        public void SortiesStock(FormStockPharma s)
        {
            // Afficher tous les mouvements concernant le stock sélectionné
            s.btnSorties.Enabled = false;
        }
        public void HistoriqueCommandes(FormStockPharma s, FormCommandeRapport c)
        {
            c.btnQuitter.Visible = false;
            c.poste = s.poste;
            c.Text = "Historique des commandes";
            c.Show();
        }
        public void HistoriqueCommandes(FormStockAutreProduit s, FormCommandeRapport2 c)
        {
            c.btnQuitter.Visible = false;
            c.poste = s.poste;
            c.Text = "Historique des commandes";
            c.Show();
        }
        public void AlertesStock(FormStockPharma s)
        {
            if(s.dgvStock.RowCount >0)
            {
                for (int i = 0; i < s.dgvStock.RowCount; i++)
                {
                    if (int.Parse(s.dgvStock.Rows[i].Cells[8].Value.ToString()) < int.Parse(s.dgvStock.Rows[i].Cells[9].Value.ToString()) * 0.8)
                        s.dgvStock.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                }
            }
        }

        #endregion

        #region COMMANDE_PRODUIT_PHARMA
        public void EnregistrerCommande(FormCommande c)
        {
            c.idcommande = NouveauID("commande");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneCommande values (@id, @date_jour, @idstock, @qtecommande, @qteservie)", con);
                cmd.Parameters.AddWithValue("@id", c.idcommande);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idstock", c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@qtecommande", c.dgvCommande.CurrentRow.Cells[8].Value.ToString());
                cmd.Parameters.AddWithValue("@qteservie", "0");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void MiseAJourCommande(FormCommandeRapport c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneCommande set qteservie = @qteservie where idcommande = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idcommande);
                cmd.Parameters.AddWithValue("@qteservie", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Mouvements: sortie stock
            EnregistrerMvmt(c);
            //Mouvements: entrée pharma
            EnregistrerMvmt(c, "pharmacie");
        }
        public void AfficherTouteCommande(FormCommandeRapport c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneCommande ", con);
                dr = cmd.ExecuteReader();
                c.dgvCommande.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvCommande.Rows.Add();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[8].Value = dr[3].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[9].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            DetailsStock(c.dgvCommande);
        }
        public void AfficherCommandeProduit(FormCommandeRapport s)
        {
            //
        }
        public void AfficherCommandePeriode(FormCommandeRapport s)
        {
            //
        }
        public void ValiderCommande(FormCommande c, FormCom com, string motif)
        {
            com.idstock = int.Parse(c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1} {2} {3}",
                c.dgvCommande.CurrentRow.Cells[3].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[4].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[5].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[6].Value.ToString());
            com.txtQteStock.Text = c.dgvCommande.CurrentRow.Cells[7].Value.ToString();
            com.txtQteCom.Focus();
            if (!c.dgvCommande.CurrentRow.Cells[9].Visible)
            {
                com.txtQteServie.Enabled = false;
                com.txtDest.Enabled = false;
            }
            com.poste = c.poste;
            com.ShowDialog();
            if (com.fermeture_succes)
            {
                c.dgvCommande.CurrentRow.Cells[8].Value = com.txtQteCom.Text;
                if (c.dgvCommande.CurrentRow.Cells[9].Visible)
                    c.dgvCommande.CurrentRow.Cells[9].Value = com.txtQteServie.Text;
                if (motif == "demandeAppro")
                {
                    EnregistrerAppro(c);
                }
                else if (motif == "commande")
                {
                    EnregistrerCommande(c);
                }
                else
                {
                    EnregistrerRequisition(c, com.txtDest.Text);
                }
            }
            com.Close();
            c.btnQteCom.Enabled = false;
        }
        public void ServirCommande(FormCommandeRapport c, FormCom com)
        {
            com.idstock = int.Parse(c.dgvCommande.CurrentRow.Cells[2].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1} {2} {3}",
                c.dgvCommande.CurrentRow.Cells[4].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[5].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[6].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[7].Value.ToString());

            com.txtQteStock.Text = QteStock(c.idstock, "pharma").ToString();
            com.txtQteCom.Text = c.dgvCommande.CurrentRow.Cells[8].Value.ToString();
            com.txtQteCom.Enabled = false;
            com.txtQteServie.Focus();
            com.ShowDialog();
            if (com.fermeture_succes)
            {
                c.dgvCommande.CurrentRow.Cells[9].Value = com.txtQteServie.Text;
                MiseAJourCommande(c);
            }
            com.Close();
            c.btnServir.Enabled = false;
        }
        public void EditerCommande(FormStockPharma s, FormCommande c, string motif)
        {
            if (s.dgvStock.RowCount > 0)
            {
                for (int i = 0; i < s.dgvStock.RowCount; i++)
                {
                    if (s.dgvStock.Rows[i].Selected)
                    {
                        c.dgvCommande.Rows.Add();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[0].Value = c.dgvCommande.RowCount;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[1].Value = s.dgvStock.Rows[i].Cells[0].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[2].Value = s.dgvStock.Rows[i].Cells[1].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[3].Value = s.dgvStock.Rows[i].Cells[2].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[4].Value = s.dgvStock.Rows[i].Cells[3].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[5].Value = s.dgvStock.Rows[i].Cells[4].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[6].Value = s.dgvStock.Rows[i].Cells[5].Value;
                        if (motif == "commande")
                            c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[7].Value = QteStock(int.Parse(s.dgvStock.Rows[i].Cells[10].Value.ToString()), "pharma");
                        else
                            c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[7].Value = s.dgvStock.Rows[i].Cells[8].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[8].Value = "";
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[9].Value = "";

                    }
                }
                c.poste = s.poste;
                if (motif == "demandeAppro")
                {
                    c.Text = "SSM - Demande d'approvisionnement";
                }
                else if (motif == "commande")
                {
                    c.Text = "SSM - Nouvelle commande";
                }
                else
                {
                    c.Text = "SSM - Nouvelle réquisition";
                    c.dgvCommande.Columns[9].Visible = true;
                }
                c.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne à éditer n'a été trouvée pour la commande", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            s.btnEditerRequisition.Enabled = false;
            s.btnEditerCommande.Enabled = false;
        }

        ReportDataSource rs = new ReportDataSource();
        public void ImprimerBonCommande(FormApproStockPharma a, FormImpression imp)
        {
            if (a.dgvAppro.RowCount != 0)
            {
                imp.Text = "SSM - Bon de Commande";

                List<BonCommandePharma> list = new List<BonCommandePharma>();
                list.Clear();

                for (int i = 0; i < a.dgvAppro.RowCount; i++)
                {
                    if (a.dgvAppro.Rows[i].Cells[10].Value.ToString() == "0")
                    {
                        a.bon_valide = true;
                        BonCommandePharma bc = new BonCommandePharma
                        {
                            id = list.Count + 1,
                            produit = a.dgvAppro.Rows[i].Cells[4].Value.ToString(),
                            condition = a.dgvAppro.Rows[i].Cells[5].Value.ToString(),
                            dosage = a.dgvAppro.Rows[i].Cells[6].Value.ToString(),
                            forme = a.dgvAppro.Rows[i].Cells[7].Value.ToString(),
                        };
                        list.Add(bc);
                    }
                }
                if (a.bon_valide)
                {
                    rs.Name = "DataSet1";
                    rs.Value = list;
                    imp.reportViewer1.LocalReport.DataSources.Clear();
                    imp.reportViewer1.LocalReport.DataSources.Add(rs);
                    imp.reportViewer1.LocalReport.ReportEmbeddedResource = "SUMEDCO.BonCommandePharma.rdlc";
                    imp.ShowDialog();
                }
                else
                    MessageBox.Show("Aucune ligne non approvisionnée n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Aucune ligne n'a été trouvée", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        #endregion
        
        #region COMMANDE_AUTRE_PRODUIT
        public void AfficherTouteCommande(FormCommandeRapport2 c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneRequisitionAutre ", con);
                dr = cmd.ExecuteReader();
                c.dgvCommande.Rows.Clear();
                while (dr.Read())
                {
                    c.dgvCommande.Rows.Add();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[5].Value = dr[3].ToString();
                    c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[6].Value = dr[4].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            ProduitUnite(c.dgvCommande);
        }
        public void AfficherCommandeProduit(FormCommandeRapport2 s)
        {
            //
        }
        public void AfficherCommandePeriode(FormCommandeRapport2 s)
        {
            //
        }
        public void ValiderCommande(FormCommandeAutre c, FormComAutre com, string motif)
        {
            com.idproduit = int.Parse(c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
            com.txtLibelle.Text = string.Format("{0} {1}",
                c.dgvCommande.CurrentRow.Cells[2].Value.ToString(),
                c.dgvCommande.CurrentRow.Cells[3].Value.ToString());
            com.txtQteStock.Text = c.dgvCommande.CurrentRow.Cells[4].Value.ToString();
            com.txtQteCom.Focus();
            if (!c.dgvCommande.CurrentRow.Cells[6].Visible)
            {
                com.txtQteServie.Enabled = false;
                com.txtDest.Enabled = false;
            }
            com.motif = c.motif;
            com.ShowDialog();
            if (com.fermeture_succes)
            {
                c.dgvCommande.CurrentRow.Cells[5].Value = com.txtQteCom.Text;
                if (c.dgvCommande.CurrentRow.Cells[6].Visible)
                    c.dgvCommande.CurrentRow.Cells[6].Value = com.txtQteServie.Text;
                if (motif == "commande")
                    EnregistrerAppro(c);
                else
                    EnregistrerRequisition(c, com.txtDest.Text);
            }
            com.Close();
            c.btnQteCom.Enabled = false;
        }
        public void EditerCommande(FormStockAutreProduit s, FormCommandeAutre c, string motif)
        {
            if (s.dgvStock.RowCount > 0)
            {
                for (int i = 0; i < s.dgvStock.RowCount; i++)
                {
                    if (s.dgvStock.Rows[i].Selected)
                    {
                        c.dgvCommande.Rows.Add();
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[0].Value = c.dgvCommande.RowCount;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[1].Value = s.dgvStock.Rows[i].Cells[0].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[2].Value = s.dgvStock.Rows[i].Cells[2].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[3].Value = s.dgvStock.Rows[i].Cells[3].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[4].Value = s.dgvStock.Rows[i].Cells[4].Value;
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[5].Value = "";
                        c.dgvCommande.Rows[c.dgvCommande.RowCount - 1].Cells[6].Value = "";
                    }
                }
                c.motif = motif;
                if (motif == "commande")
                {
                    c.Text = "SSM - Nouvelle commande";
                }
                else
                {
                    c.Text = "SSM - Nouvelle réquisition";
                    c.dgvCommande.Columns[6].Visible = true;
                }
                c.ShowDialog();
            }
            else
                MessageBox.Show("Aucune ligne à éditer n'a été trouvée pour la commande", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            s.btnEditerRequisition.Enabled = false;
            s.btnEditerCommande.Enabled = false;
        }
        #endregion 

        #region GESTION_STOCKS_AUTRE
        public void AfficherSousForm(MFormStock s, FormStockAutreProduit childForm)
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
        public void HistoriqueApproStockAutre(FormApproStockAutre a)
        {
            a.poste = "stock";
            a.Show();
        }
        public void HistoriqueApproStockAutre(MFormComptabilite c, FormApproStockAutre childForm)
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
        public void AfficherToutStock(FormStockAutreProduit s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from ProduitAutreStock ", con);
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
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void AfficherStocksProduit(FormStockAutreProduit s)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from ProduitAutreStock where idproduit = @id", con);
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
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            s.btnStock.Enabled = false;
        }
        #endregion

        #region MOUVEMENT_STOCK
        public void EnregistrerMvmt(FormApproPharma a)
        {
            //Enregistre le mouvement à l'approvisionnement
            a.idmvmt = NouveauID("mouvement");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Mouvement values (@id, @date_jour, @operation, @idstock, @quantite)", con);
                cmd.Parameters.AddWithValue("@id", a.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", a.dtpDateJour.Value);
                cmd.Parameters.AddWithValue("@operation", "entrée");
                cmd.Parameters.AddWithValue("@idstock", a.idstock);
                cmd.Parameters.AddWithValue("@quantite", a.txtQteAjout.Text);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void EnregistrerMvmt(FormCommandeRapport c)
        {
            //Enregistre le mouvement à l'approvisionnement
            c.dtpDateA.ResetText(); //pour utiliser cette date comme date du jour
            c.idmvmt = NouveauID("mouvement");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Mouvement values (@id, @date_jour, @operation, @idstock, @quantite)", con);
                cmd.Parameters.AddWithValue("@id", c.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateA.Value);
                cmd.Parameters.AddWithValue("@operation", "sortie");
                cmd.Parameters.AddWithValue("@idstock", c.idstock);
                cmd.Parameters.AddWithValue("@quantite", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Stock principal diminue
            DiminuerStock(c);
        }
        public void DiminuerStock(FormCommandeRapport c)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneStock set qtestock = qtestock - @qteservie where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", c.idstock);
                cmd.Parameters.AddWithValue("@qteservie", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EnregistrerMvmt(FormApproAutre a)
        {
            //Enregistre le mouvement à l'approvisionnement
            a.idmvmt = NouveauID("mouvementautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into MouvementAutreStock values (@id, @date_jour, @operation, @idproduit, @quantite, @destination)", con);
                cmd.Parameters.AddWithValue("@id", a.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", a.dtpDateJour.Value);
                cmd.Parameters.AddWithValue("@operation", "entrée");
                cmd.Parameters.AddWithValue("@idproduit", a.idproduit);
                cmd.Parameters.AddWithValue("@quantite", a.txtQteAjout.Text);
                cmd.Parameters.AddWithValue("@destination", "stock");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void EnregistrerMvmt(FormCommandeAutre c, string dest)
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
                cmd.Parameters.AddWithValue("@quantite", c.dgvCommande.CurrentRow.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void EnregistrerMvmt(FormCommande c, string dest)
        {
            //Enregistre le mouvement à la requisition
            c.idmvmt = NouveauID("mouvementpharma");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into MouvementPharma values (@id, @date_jour, @operation, @idstock, @quantite, @dest)", con);
                cmd.Parameters.AddWithValue("@id", c.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateCom.Value);
                cmd.Parameters.AddWithValue("@operation", "sortie");
                cmd.Parameters.AddWithValue("@idstock", c.idstock);
                cmd.Parameters.AddWithValue("@quantite", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Stock pharma diminue
            MiseAJourStockPharma(c.idstock, int.Parse(c.dgvCommande.CurrentRow.Cells[9].Value.ToString()), "reduire");
        }
        public void MiseAJourStockPharma(int idstock, int qte, string motif)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                if(motif =="reduire")
                    cmd = new SqlCommand("update LigneStockPharma set qtestockpharma = qtestockpharma - @qteservie where idstock = @id", con);
                else
                    cmd = new SqlCommand("update LigneStockPharma set qtestockpharma = qtestockpharma + @qteservie where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id",idstock);
                cmd.Parameters.AddWithValue("@qteservie", qte);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EnregistrerMvmt(FormCommandeRapport c, string dest)
        {
            //Enregistre le mouvement à la requisition
            c.dtpDateA.ResetText(); //pour utiliser cette date comme date du jour
            c.idmvmt = NouveauID("mouvementpharma");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into MouvementPharma values (@id, @date_jour, @operation, @idstock, @quantite, @dest)", con);
                cmd.Parameters.AddWithValue("@id", c.idmvmt);
                cmd.Parameters.AddWithValue("@date_jour", c.dtpDateA.Value);
                cmd.Parameters.AddWithValue("@operation", "entrée");
                cmd.Parameters.AddWithValue("@idstock", c.idstock);
                cmd.Parameters.AddWithValue("@quantite", c.dgvCommande.CurrentRow.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@dest", dest);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            //Stock pharma augmente
            MiseAJourStockPharma(c.idstock, int.Parse(c.dgvCommande.CurrentRow.Cells[9].Value.ToString()), "ajouter");
        }
        public void Afficher(FormMouvement m)
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

        #region LOT_PRODUIT
        public int VerifierNumLot(string numlot, string motif)
        {
            id =0;
            if(motif =="stock")
                cmd = new SqlCommand("select count(numlot) from LigneStock where numlot = @numlot", con);
            else
                cmd = new SqlCommand("select count(numlot) from Lot where numlot = @numlot", con);
            con.Open();
            try
            {
                cmd.Parameters.AddWithValue("@numlot", numlot);
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
        
        public void Enregistrer(FormLot lot)
        {
            if (lot.txtNumLot.Text != "" && lot.cboMois.Text !="" && lot.nudAnnee.Text !="")
            {
                if (VerifierNumLot(lot.txtNumLot.Text, "lot") == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("insert into Lot values (@numlot, @date_exp, @idproduit)", con);
                        cmd.Parameters.AddWithValue("@numlot", lot.txtNumLot.Text);
                        cmd.Parameters.AddWithValue("@date_exp", string.Format("{0}/{1}",lot.cboMois.Text, lot.nudAnnee.Text));
                        cmd.Parameters.AddWithValue("@idproduit", lot.idproduit);
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
                    lot.fermeture_succes = true;
                    lot.Hide();
                }
                else MessageBox.Show("Le numéro de lot fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Modifier(FormLot lot)
        {
            if (lot.txtNumLot.Text != "" && lot.cboMois.Text != "" && lot.nudAnnee.Text != "")
            {
                if (VerifierNumLot(lot.txtNumLot.Text, "lot") == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("update Lot set numlot= @numlot, date_expiration= @date_exp where numlot = @num", con);
                        cmd.Parameters.AddWithValue("@numlot", lot.txtNumLot.Text);
                        cmd.Parameters.AddWithValue("@date_exp", string.Format("{0}/{1}", lot.cboMois.Text, lot.nudAnnee.Text));
                        cmd.Parameters.AddWithValue("@num", lot.numlot);
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
                    lot.fermeture_succes = true;
                    lot.Hide();
                }
                else MessageBox.Show("Le numéro de lot fourni est déjà utilisé", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Désolé! Champ(s) obligatoire(s) vide(s)\nRemplissez-le(s).", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public void Supprimer(FormLot lot)
        {
            if (VerifierNumLot(lot.txtNumLot.Text, "lot") == 1)
            {
                if (VerifierNumLot(lot.txtNumLot.Text, "stock") == 0)
                {
                    con.Open();
                    SqlTransaction tx = con.BeginTransaction();
                    try
                    {
                        cmd = new SqlCommand("delete from Lot where numlot = @numlot", con);
                        cmd.Parameters.AddWithValue("@numlot", lot.txtNumLot.Text);
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
                    lot.fermeture_succes = false;
                    lot.Hide();
                }
                else MessageBox.Show("Le numéro de lot fourni est déjà impliqué dans les stocks,\npour raison de cohérence, il ne peut être supprimé");
            }
            else MessageBox.Show("Le numéro de lot fourni n'est pas reconnu", "Valeur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region APPRO_PRODUIT_PHARMA
        public void Annuler(FormApproPharma a)
        {

        }
        public void ServirApproPharma(FormApproStockPharma a, FormApproPharma appro)
        {
            if (a.dgvAppro.CurrentRow.Cells[12].Value.ToString() != "0,00")
            {
                MessageBox.Show("Demande déjà servie", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                appro.txtLibelle.Text = string.Format("{0} {1} {2} {3}",
                a.dgvAppro.CurrentRow.Cells[4].Value.ToString(),
                a.dgvAppro.CurrentRow.Cells[5].Value.ToString(),
                a.dgvAppro.CurrentRow.Cells[6].Value.ToString(),
                a.dgvAppro.CurrentRow.Cells[7].Value.ToString());

                appro.txtQteDem.Text = a.dgvAppro.CurrentRow.Cells[8].Value.ToString();
                appro.txtQteAppro.Focus();
                appro.idstock = a.idstock;
                appro.ShowDialog();
                if (appro.fermeture_succes)
                {
                    a.dgvAppro.CurrentRow.Cells[9].Value = appro.txtQteAppro.Text;
                    a.dgvAppro.CurrentRow.Cells[10].Value = appro.txtQteAjout.Text;
                    a.dgvAppro.CurrentRow.Cells[11].Value = appro.txtPrixAchat.Text;
                    a.dgvAppro.CurrentRow.Cells[12].Value = appro.txtTaux.Text;
                    a.dgvAppro.CurrentRow.Cells[13].Value = appro.txtPrixVente.Text;
                    MiseAJourAppro(a);
                    EnregistrerLot(appro.txtNumLot.Text, appro.cboMois.Text + "/" + appro.nudAnnee.Value, a.idproduit);
                    MiseAJourLigneStock(a.idstock, appro.txtNumLot.Text, double.Parse(appro.txtPrixVente.Text), int.Parse(appro.txtQteAjout.Text));
                    EnregistrerMvmt(appro);
                }
                appro.Close();
                a.btnServir.Enabled = false;
            }
        }
        public void EnregistrerAppro(FormCommande c)
        {
            c.idAppro = NouveauID("appro");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneAppro values (@id, @date_dem, @idstock, @prix_achat, @taux, @qtedem, @qteappro, @qteajoute)", con);
                cmd.Parameters.AddWithValue("@id", c.idAppro);
                cmd.Parameters.AddWithValue("@date_dem", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idstock", c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@prix_achat", "0");
                cmd.Parameters.AddWithValue("@taux", "0");
                cmd.Parameters.AddWithValue("@qtedem", c.dgvCommande.CurrentRow.Cells[8].Value.ToString());
                cmd.Parameters.AddWithValue("@qteappro", "0");
                cmd.Parameters.AddWithValue("@qteajoute", "0");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void AfficherTouteDemandeAppro(FormApproStockPharma a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneAppro ", con);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[8].Value = dr[5].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[9].Value = dr[6].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[10].Value = dr[7].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[12].Value = dr[4].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[13].Value = float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value.ToString()) +
                        float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value.ToString()) * float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[12].Value.ToString()) / 100;

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            DetailsStock(a.dgvAppro);
        }
        public void AfficherApproProduit(FormStockPharma s)
        {
            //
        }
        public void AfficherApproPeriode(FormApproStockPharma a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneAppro where date_dem between @dateDe and @dateA", con);
                cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[8].Value = dr[5].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[9].Value = dr[6].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[10].Value = dr[7].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value = dr[3].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[12].Value = dr[4].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[13].Value = float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value.ToString()) +
                        float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[11].Value.ToString()) * float.Parse(a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[12].Value.ToString()) / 100;

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            DetailsStock(a.dgvAppro);
        }
        public void MiseAJourAppro(FormApproStockPharma a)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneAppro set qteappro = @qteappro, qteajoute = @qteajoute, prix_achat = @prix_achat, taux = @taux where idappro = @id", con);
                cmd.Parameters.AddWithValue("@id", a.idAppro);
                cmd.Parameters.AddWithValue("@qteappro", a.dgvAppro.CurrentRow.Cells[9].Value.ToString());
                cmd.Parameters.AddWithValue("@qteajoute", a.dgvAppro.CurrentRow.Cells[10].Value.ToString());
                cmd.Parameters.AddWithValue("@prix_achat", double.Parse(a.dgvAppro.CurrentRow.Cells[11].Value.ToString()));
                cmd.Parameters.AddWithValue("@taux", double.Parse(a.dgvAppro.CurrentRow.Cells[12].Value.ToString()));
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void EnregistrerLot(string numlot, string dateExp, int idproduit)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into Lot values (@numlot, @date_exp, @idproduit)", con);
                cmd.Parameters.AddWithValue("@numlot", numlot);
                cmd.Parameters.AddWithValue("@date_exp", dateExp);
                cmd.Parameters.AddWithValue("@idproduit", idproduit);
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
        public void MiseAJourLigneStock(int idstock, string numlot, double prixunitaire, int qteajoute)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneStock set numlot = @numlot, prixunitaire = @prix, qtestock = qtestock + @qte where idstock = @id", con);
                cmd.Parameters.AddWithValue("@id", idstock);
                cmd.Parameters.AddWithValue("@numlot", numlot);
                cmd.Parameters.AddWithValue("@prix", prixunitaire);
                cmd.Parameters.AddWithValue("@qte", qteajoute);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
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
        public void ServirApproAutre(FormApproStockAutre a, FormApproAutre appro)
        {
            appro.idproduit = int.Parse(a.dgvAppro.CurrentRow.Cells[2].Value.ToString());
            appro.txtLibelle.Text = string.Format("{0} {1}",
                a.dgvAppro.CurrentRow.Cells[3].Value.ToString(),
                a.dgvAppro.CurrentRow.Cells[4].Value.ToString());

            appro.idproduit = a.idproduit;
            appro.txtQteAppro.Focus();
            if (a.dgvAppro.CurrentRow.Cells[8].Value.ToString() != "0,00")
            {
                if (MessageBox.Show("Demande déjà servie\n\nY a-t-il un autre descriptif pour le même stock?", "Nouveau stock", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    appro.txtQteDem.Text = (int.Parse(a.dgvAppro.CurrentRow.Cells[5].Value.ToString()) - int.Parse(a.dgvAppro.CurrentRow.Cells[6].Value.ToString())).ToString();
                    appro.ShowDialog();
                    if (appro.fermeture_succes)
                    {
                        if(appro.chboxLot.Checked)
                        {
                            a.dgvAppro.CurrentRow.Cells[6].Value = int.Parse(a.dgvAppro.CurrentRow.Cells[6].Value.ToString()) + int.Parse(appro.txtQteAppro.Text);
                            a.dgvAppro.CurrentRow.Cells[7].Value = int.Parse(a.dgvAppro.CurrentRow.Cells[7].Value.ToString()) + int.Parse(appro.txtQteAjout.Text);
                            a.dgvAppro.CurrentRow.Cells[8].Value = appro.txtPrixAchat.Text;
                            NouveauStock(appro);
                            MiseAJourAppro(a);
                            EnregistrerMvmt(appro);
                        }
                        else
                            MessageBox.Show("Le numéro lot et sa date d'expiration doivent être fournis", "Attention !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                appro.txtQteDem.Text = a.dgvAppro.CurrentRow.Cells[5].Value.ToString();
                appro.ShowDialog();
                if (appro.fermeture_succes)
                {
                    a.dgvAppro.CurrentRow.Cells[6].Value = appro.txtQteAppro.Text;
                    a.dgvAppro.CurrentRow.Cells[7].Value = appro.txtQteAjout.Text;
                    a.dgvAppro.CurrentRow.Cells[8].Value = appro.txtPrixAchat.Text;
                    MiseAJourAppro(a);
                    MiseAJourStockAutre(appro);
                    EnregistrerMvmt(appro);
                }
            }
            appro.Close();
            a.btnServir.Enabled = false;
        }
        public void EnregistrerAppro(FormCommandeAutre c)
        {
            c.idAppro = NouveauID("approautre");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into LigneApproAutreStock values (@id, @date_dem, @idproduit, @prix_achat, @qtedem, @qteappro, @qteajoute)", con);
                cmd.Parameters.AddWithValue("@id", c.idAppro);
                cmd.Parameters.AddWithValue("@date_dem", c.dtpDateCom.Text);
                cmd.Parameters.AddWithValue("@idproduit", c.dgvCommande.CurrentRow.Cells[1].Value.ToString());
                cmd.Parameters.AddWithValue("@prix_achat", "0");
                cmd.Parameters.AddWithValue("@qtedem", c.dgvCommande.CurrentRow.Cells[5].Value.ToString());
                cmd.Parameters.AddWithValue("@qteappro", "0");
                cmd.Parameters.AddWithValue("@qteajoute", "0");
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            con.Close();
        }
        public void AfficherTouteDemandeAppro(FormApproStockAutre a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneApproAutreStock ", con);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[7].Value = dr[6].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[8].Value = dr[3].ToString();

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            ProduitUnite(a.dgvAppro);
        }
        public void AfficherApproProduit(FormApproStockAutre s)
        {
            //
        }
        public void AfficherApproPeriode(FormApproStockAutre a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from LigneApproAutreStock where date_dem between @dateDe and @dateA", con);
                cmd.Parameters.AddWithValue("@dateDe", a.dtpDateDe.Text);
                cmd.Parameters.AddWithValue("@dateA", a.dtpDateA.Text);
                dr = cmd.ExecuteReader();
                a.dgvAppro.Rows.Clear();
                while (dr.Read())
                {
                    a.dgvAppro.Rows.Add();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[0].Value = dr[0].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[1].Value = dr[1].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[2].Value = dr[2].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[5].Value = dr[4].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[6].Value = dr[5].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[7].Value = dr[6].ToString();
                    a.dgvAppro.Rows[a.dgvAppro.RowCount - 1].Cells[8].Value = dr[3].ToString();

                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            ProduitUnite(a.dgvAppro);
        }
        public void MiseAJourAppro(FormApproStockAutre a)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update LigneApproAutreStock set qteappro = @qteappro, qteajoute = @qteajoute, prix_achat = @prix_achat where idappro = @id", con);
                cmd.Parameters.AddWithValue("@id", a.idAppro);
                cmd.Parameters.AddWithValue("@qteappro", a.dgvAppro.CurrentRow.Cells[6].Value.ToString());
                cmd.Parameters.AddWithValue("@qteajoute", a.dgvAppro.CurrentRow.Cells[7].Value.ToString());
                cmd.Parameters.AddWithValue("@prix_achat", a.dgvAppro.CurrentRow.Cells[8].Value.ToString());
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void MiseAJourStockAutre(FormApproAutre a)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update ProduitAutreStock set descriptif = @descriptif where idproduit = @idproduit", con);
                cmd.Parameters.AddWithValue("@idproduit", a.idproduit);
                cmd.Parameters.AddWithValue("@descriptif", a.descriptif);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void NouveauStock(FormApproAutre a)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select * from ProduitAutreStock where idproduit= @idproduit", con);
                cmd.Parameters.AddWithValue("@idproduit", a.idproduit);
                dr = cmd.ExecuteReader();
                id = 0;
                while (dr.Read())
                {
                    a.valeurstock[id] = dr[1].ToString();
                    a.valeurstock[id + 1] = dr[2].ToString();
                    a.valeurstock[id + 2] = dr[3].ToString();
                    a.valeurstock[id + 3] = dr[4].ToString();
                    a.valeurstock[id + 4] = dr[5].ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
            a.idproduit = NouveauID("autreproduit");
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("insert into ProduitAutreStock values (@id, @numcompte, @nom, @unite, @qte, @CMM, @descriptif)", con);
                cmd.Parameters.AddWithValue("@id", a.idproduit);
                cmd.Parameters.AddWithValue("@nom", a.valeurstock[0]);
                cmd.Parameters.AddWithValue("@numcompte", a.valeurstock[1]);
                cmd.Parameters.AddWithValue("@unite", a.valeurstock[2]);
                cmd.Parameters.AddWithValue("@qte", a.valeurstock[3]); //Qté initiale = 0
                cmd.Parameters.AddWithValue("@CMM", a.valeurstock[4]);
                cmd.Parameters.AddWithValue("@descriptif", a.descriptif);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
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
    public class BonCommandePharma
    {
        public int id { get; set; }
        public string produit { get; set; }
        public string condition { get; set; }
        public string dosage { get; set; }
        public string forme { get; set; }
    }
}
