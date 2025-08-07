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
    class ConnexionClasse
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        bool cmdStatut;
        string chaine = "", cmdtxt = "", nom = "";
        int id = 0;
        double valeur;
        
        ClasseExercice exer = new ClasseExercice();
        public void ModifierMotdePasse(Connexion c, ConnexionPass cp)
        {
            cp.poste = c.poste;
            cp.txtUtilisateur.Select();
            cp.ShowDialog();
            if (cp.connexion)
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
        public void RefuserAutorisation(string compte)
        {
            con.Open();
            SqlTransaction tx = con.BeginTransaction();
            try
            {
                cmd = new SqlCommand("update Autorisations set etat = 'refusé' where libelle = '" + compte + "'", con);
                cmd.Transaction = tx;
                cmd.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            con.Close();
        }
        public void Connexion(Connexion c)
        {
            con.Open();
            try
            {
                cmd = new SqlCommand("select id, utilisateur, motdepasse, poste, specification from Utilisateur where utilisateur = @utilisateur and motdepasse = @mot and poste = @poste", con);
                cmd.Parameters.AddWithValue("@utilisateur", c.txtUtilisateur.Text);
                cmd.Parameters.AddWithValue("@mot", c.txtMotdePass.Text);
                cmd.Parameters.AddWithValue("@poste", c.poste);
                dr = cmd.ExecuteReader();
                if (dr.Read() == true)
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
            if (c.access_autorise)
            {
                if (c.poste == "admin")
                {
                    if (chaine == c.cboUtilisateur.Text)
                    {
                        AdminMDI ad = new AdminMDI();
                        ad.utilisateur = c.cboUtilisateur.Text;
                        RefuserAutorisation("infirmier - réception");
                        RefuserAutorisation("infirmier - abonné");
                        RefuserAutorisation("infirmier - médecin");
                        RefuserAutorisation("pharmacie - caisse");
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
                    ReceptionMDI r = new ReceptionMDI();
                    r.idutilisateur = id;
                    RefuserAutorisation("infirmier - réception");
                    r.Show();
                }
                else if (c.poste == "recette")
                {
                    RecetteMDI rec = new RecetteMDI();
                    rec.idutilisateur = id;
                    RefuserAutorisation("pharmacie - caisse");
                    rec.Show();
                }
                else if (c.poste == "infirmier")
                {
                    ConnexionAutorisation aut = new ConnexionAutorisation();
                    aut.idutilisateur = id;
                    aut.poste = "infirmier";
                    aut.Show();

                }
                else if (c.poste == "médecin")
                {
                    if (chaine == c.cboUtilisateur.Text)
                    {
                        MedMDI cons = new MedMDI();
                        cons.idmedecin = c.idmedecin;
                        cons.idutilisateur = id;
                        RefuserAutorisation("infirmier - médecin");
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
                    AbonneMDI ab = new AbonneMDI();
                    ab.idutilisateur = id;
                    RefuserAutorisation("infirmier - abonné");
                    ab.Show();
                }
                else if (c.poste == "dépense")
                {
                    TresorerieMDI d = new TresorerieMDI();
                    d.idutilisateur = id;
                    d.Show();
                }
                else if (c.poste == "comptable")
                {
                    ComptabiliteMDI co = new ComptabiliteMDI();
                    co.idutilisateur = id;
                    RefuserAutorisation("infirmier - réception");
                    RefuserAutorisation("infirmier - abonné");
                    RefuserAutorisation("infirmier - médecin");
                    RefuserAutorisation("pharmacie - caisse");
                    co.Show();
                }
                else if (c.poste == "pharmacie")
                {
                    if (chaine == c.cboUtilisateur.Text)
                    {
                        ConnexionAutorisation aut = new ConnexionAutorisation();
                        aut.idutilisateur = id;
                        aut.idpharma = c.idpharma;
                        aut.poste = "pharmacie";
                        aut.Show();
                    }
                    else
                    {
                        c.access_autorise = false;
                        MessageBox.Show("Accès refusé", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (c.poste == "stock")
                {
                    StockMDI s = new StockMDI();
                    s.idutilisateur = id;
                    s.Show();
                }
                else if (c.poste == "imagerie")
                {
                    EchoRadioMDI s = new EchoRadioMDI();
                    s.idutilisateur = id;
                    s.Show();
                }
                else if (c.poste == "labo")
                {
                    LaboMDI s = new LaboMDI();
                    s.idutilisateur = id;
                    s.Show();
                }

                if (c.access_autorise)
                    c.Close();
            }
        }

    }
}
