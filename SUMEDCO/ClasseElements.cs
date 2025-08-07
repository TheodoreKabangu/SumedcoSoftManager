
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
    class ClasseElements
    {
        public string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        long valeur;

        int id = 0;
        string cmdtxt = "", chaine = "", nom = "";
        public void ChargerCombo(ComboBox cbo, string search_key)
        {
            con = new SqlConnection(conString);
            if (search_key == "entreprise")
                cmd = new SqlCommand("SELECT identreprise, nomentreprise FROM Entreprise", con);
            else if (search_key == "material")
                cmd = new SqlCommand("SELECT idmaterial, specification FROM Material", con);
            else if (search_key == "transport_type")
                cmd = new SqlCommand("SELECT id, type_name FROM TypeTransport", con);
            else if (search_key == "transport")
                cmd = new SqlCommand("SELECT idtransport, specification FROM Transport", con);
            else if (search_key == "equipment_type")
                cmd = new SqlCommand("SELECT id, type_name FROM TypeEquipment", con);
            else if (search_key == "equipment")
                cmd = new SqlCommand("SELECT idequipment, specification FROM Equipment", con);
            else if (search_key == "energy")
                cmd = new SqlCommand("SELECT idenergy, specification FROM EnergySource", con);
            else if (search_key == "waste_disposal")
                cmd = new SqlCommand("SELECT idwasted, type FROM WasteDisposal", con);
            else if (search_key == "waste_factor")
                cmd = new SqlCommand("SELECT idwastef, type FROM WasteFactor", con);
            con.Open();
            try
            {
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dt.Rows.Clear();
                da.Fill(dt);
                cbo.DataSource = dt;
                cbo.ValueMember = dt.Columns[0].ToString();
                cbo.DisplayMember = dt.Columns[1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
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
                txt.Text = "";
            else
                txt.Text = valeur.ToString();
        }
        public void TesterValeurDGV(DataGridView dgv, int index_col, int val_min)
        {
            try
            {
                if(Convert.ToInt16(dgv.CurrentRow.Cells[index_col].Value) < val_min)
                    MessageBox.Show("Valeur incorrecte! Saisissez au moins"+val_min, "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Valeur incorrecte! Saisissez seuls les nombres", "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv.CurrentRow.Cells[index_col].Value = val_min;
            }
        }
        public void TestMontantDGV(DataGridView dgv, bool negatif_interdit)
        {
            try
            {
                if(negatif_interdit)
                {
                    if (Convert.ToDouble(dgv.CurrentCell.Value) <= 0)
                    {
                        MessageBox.Show("Le montant doit être supérieur à 0", "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgv.CurrentCell.Style.BackColor = Color.IndianRed;
                        dgv.CurrentCell.Style.SelectionBackColor = Color.IndianRed;
                    }
                    else
                    {
                        dgv.CurrentCell.Style.BackColor = Color.Lavender;
                        dgv.CurrentCell.Style.SelectionBackColor = Color.LightSteelBlue;
                    }
                }
                else
                {
                    if (Convert.ToDouble(dgv.CurrentCell.Value) == 0)
                    {
                        MessageBox.Show("Le montant ne peut être 0", "Valeur !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgv.CurrentCell.Style.BackColor = Color.IndianRed;
                        dgv.CurrentCell.Style.SelectionBackColor = Color.IndianRed;
                    }
                    else
                    {
                        dgv.CurrentCell.Style.BackColor = Color.Lavender;
                        dgv.CurrentCell.Style.SelectionBackColor = Color.LightSteelBlue;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Erreur! Vérifiez que le montant est correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgv.CurrentCell.Value = 0;

            }
        }
        public void TotalColonne(DataGridView dgv, int index_col, int index_total)
        {
            dgv.Rows.Add();
            dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.ForeColor = Color.MediumBlue;
            dgv.Rows[dgv.RowCount - 1].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            dgv.Rows[dgv.RowCount - 1].Cells[index_total].Value = "Total";
            dgv.Rows[dgv.RowCount - 1].Cells[index_col].Value = 0;
            for (int i = 0; i < dgv.RowCount-1; i++)
            {               
                dgv.Rows[dgv.RowCount - 1].Cells[index_col].Value = (Convert.ToDouble(dgv.Rows[dgv.RowCount - 1].Cells[index_col].Value) + Convert.ToDouble(dgv.Rows[i].Cells[index_col].Value));
            }            
        }
        public int TrouverId(string motif, string nom)
        {
            id = 0;
            switch (motif)
            {
                case "medecin": cmdtxt = "select idmedecin from Medecin where nommedecin = @nom"; break;
                case "pharmacie": cmdtxt = "select idpharma from Pharmacie where designation = @nom"; break;
                case "typepatient": cmdtxt = "select idtype from TypePatient where nomtype = @nom"; break;
                case "typepatient2": cmdtxt = "select idtype from Patient where noms = @nom"; break;
                case "maladie": cmdtxt = "select idmaladie from Maladie where nommaladie = @nom"; break;
                case "patient": cmdtxt = "select idpatient from Patient where noms = @nom"; break;
                case "autorisation": cmdtxt = "select id from Autorisations where libelle = @nom"; break;
                case "service": cmdtxt = "select idservice from Service where nomservice = @nom"; break;
                case "numcompte": cmdtxt = "select numcompte from Compte where libellecompte = @nom"; break;
                case "entreprise": cmdtxt = "select identreprise from Entreprise where nomentreprise = @nom"; break;
                case "typeabonne": cmdtxt = "select idtypeabonne from Typeabonne where typeabonne = @nom"; break;
                case "typejournal": cmdtxt = "select idtypejournal from TypeJournal where typejournal = @nom"; break;
                case "user": cmdtxt = "select id from Utilisateur where utilisateur = @nom"; break;
                case "produit": cmdtxt = "select idproduit from Produit where nomproduit = @nom"; break;
                case "produitstock": cmdtxt = "select idproduit from LigneStock where idstock = @nom"; break;
                case "utilisateur": cmdtxt = "select id from Utilisateur where poste = @nom"; break;
                case "categorie": cmdtxt = "select idcat from CategorieProduit where categorie = @nom"; break;
                case "poste": cmdtxt = "select idposte from ServiceDemandeur where nomposte = @nom"; break;
                case "pharma": cmdtxt = "select idpharma from Pharmacie where designation = @nom"; break;
            }
            con = new SqlConnection(conString);
            con.Open();
            try
            {
                cmd = new SqlCommand(cmdtxt, con);
                cmd.Parameters.AddWithValue("@nom", nom);
                dr = cmd.ExecuteReader();
                if (dr.Read())
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
                case "autorisation": cmdtxt = "select etat from Autorisations where id= @id"; break;
                case "numcompte_service": cmdtxt = "select numcompte from Service where idservice = @id"; break;
                case "service": cmdtxt = "select nomservice from Service where idservice = @id"; break;
                case "entreprise": cmdtxt = "select nomentreprise from Entreprise where identreprise = @id"; break;
                case "typeabonne": cmdtxt = "select typeabonne from TypeAbonne where idtypeabonne = @id"; break;
                case "compte": cmdtxt = "select libellecompte from Compte where numcompte = @id"; break;
                case "poste": cmdtxt = "select poste from Utilisateur where id= @id"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
                case "produit": cmdtxt = "select nomproduit from Produit where idproduit = @id"; break;
            }
            try
            {
                con = new SqlConnection(conString);
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
                case "payement": cmdtxt = "select max(idpayement) from Payement"; break;
                case "service": cmdtxt = "select max(idservice) from Service"; break;
                case "recette": cmdtxt = "select max(idrecette) from Recette_"; break;
                case "flux": cmdtxt = "select max(idflux) from Fluxtresorerie"; break;
                case "payeur": cmdtxt = "select max(idpatient) from Patient"; break;
                case "operation": cmdtxt = "select max(idoperation) from Operation"; break;
                case "operationprojet": cmdtxt = "select max(idoperation) from Operationprojet"; break;                    
                case "operationcompte": cmdtxt = "select max(id) from OperationCompte"; break;
                case "operationcompteprojet": cmdtxt = "select max(id) from OperationCompteprojet"; break;
                case "exercice": cmdtxt = "select max(idexercice) from Exercice"; break;
                case "message": cmdtxt = "select max(idmessage) from Message"; break;
                case "patient": cmdtxt = "select max(idpatient) from Patient"; break;
                case "consultation": cmdtxt = "select max(idconsultation) from Consultation"; break;
                case "renseignement": cmdtxt = "select max(id) from Renseignement"; break;
                case "prescription": cmdtxt = "select max(idprescription) from Prescription"; break;
                case "medecin": cmdtxt = "select max(idmedecin) from Medecin"; break;
                case "maladie": cmdtxt = "select max(idmaladie) from Maladie"; break;
                case "examenphysique": cmdtxt = "select max(idexamen) from ExamenPhysique"; break;
                case "svc": cmdtxt = "select max(id) from SigneVitalConsultation"; break;
                case "s": cmdtxt = "select max(idsigne) from SigneVital"; break;
                case "rdv": cmdtxt = "select max(idrendezvous) from Rendezvous"; break;
                case "prise": cmdtxt = "select max(idprise) from PriseSigneVitaux"; break;
                case "consultationdossier": cmdtxt = "select max(id) from ConsultationDossier"; break;
                case "agendalabo": cmdtxt = "select max(id) from AgendaLabo"; break;
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
            con = new SqlConnection(conString);
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

        public void ChargerCombo(string motif, ComboBox combo, int id)
        {
            if (motif == "catservice")
            {
                cmd = new SqlCommand("select libellecompte from Compte Where numcompte like '7052%'", con);
            }
            else if (motif == "specificationservice")
            {
                cmd = new SqlCommand("SELECT DISTINCT specification FROM Service WHERE specification IS NOT NULL", con);
            }
            else if (motif == "service")
            {
                cmd = new SqlCommand("select nomservice from Service where numcompte = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }
            else if (motif == "entreprise")
            {
                cmd = new SqlCommand("select nomentreprise from Entreprise", con);
            }
            else if (motif == "typeabonne")
            {
                cmd = new SqlCommand("select typeabonne from TypeAbonne, EntrepriseTypeAbonne, Entreprise where TypeAbonne.idtypeabonne = EntrepriseTypeAbonne.idtypeabonne and EntrepriseTypeAbonne.identreprise= Entreprise.identreprise and  Entreprise.identreprise= @id", con);
                cmd.Parameters.AddWithValue("@id", id);
            }
            else if (motif == "depense")
            {
                cmd = new SqlCommand("select libellecompte from Compte where numcompte not like '1%' or numcompte not like '7%' ", con);
            }
            else if (motif == "typejournal")
            {
                cmd = new SqlCommand("select typejournal from TypeJournal", con);
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
            con = new SqlConnection(conString);
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
        public void FigerColonne(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        public void AjouterCategorieRecette(DataGridView dgv)
        {
            dgv.Rows.Add();
            dgv.Rows[0].ReadOnly = true;
            dgv.Rows[0].DefaultCellStyle.ForeColor = Color.MediumBlue;
            dgv.Rows[0].DefaultCellStyle.SelectionForeColor = Color.MediumBlue;
            con = new SqlConnection(conString);
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '7052%' AND numcompte <> '7052'", con);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dgv.Columns.Add("c" + dgv.ColumnCount + 1, dr[1].ToString());
                    dgv.Columns[dgv.ColumnCount - 1].MinimumWidth = 100;
                    dgv.Columns[dgv.ColumnCount - 1].DefaultCellStyle.Format = "N2";
                    dgv.Rows[0].Cells[dgv.ColumnCount - 1].Value = dr[0].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            dgv.ClearSelection();
        }
        public void AjouterDateEnColonne(int mois, int annee, DataGridView dgv, int nbcol_initial)
        {
            for (int i = dgv.ColumnCount-1; i >= nbcol_initial; i--)
            {
                dgv.Columns.RemoveAt(i);
            }
            valeur = DateTime.DaysInMonth(annee, mois);
            for (int i = 0; i < valeur; i++)
            {
                dgv.Columns.Add("column_" + (i), string.Format("{0}/{1}/{2}", (i+1), mois, annee));
                dgv.Columns[dgv.ColumnCount - 1].DefaultCellStyle.Format = "N2";
            }
        }
    }
}
