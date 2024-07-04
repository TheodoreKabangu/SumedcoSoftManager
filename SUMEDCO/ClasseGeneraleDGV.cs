
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
    class ClasseGeneraleDGV
    {
        static string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
        SqlConnection con = new SqlConnection(conString);
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();
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
            con.Open();
            try
            {
                cmd = new SqlCommand("SELECT numcompte, libellecompte FROM Compte WHERE numcompte LIKE '701100%' OR numcompte LIKE '7061%' OR numcompte <> '707803' AND numcompte LIKE '70780%'", con);
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
    }
}
