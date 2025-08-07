using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SUMEDCO
{
    public class DataLoader
    {
        private readonly string _connectionString;

        public DataLoader(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task LoadReceptionDataAsync(DataGridView dgv, string query, DateTimePicker dtpDe, DateTimePicker dtpA)
        {
            try
            {
                // Run DB query on background thread
                DataTable dataTable = await Task.Run(() => GetReceptionReportData(query, dtpDe, dtpA));

                // Update UI safely on the main thread
                dgv.Invoke(new Action(() =>
                {
                    dgv.DataSource = dataTable;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données: " + ex.Message);
            }
        }
        public async Task LoadAbonneDataAsync(DataGridView dgv, int entreprise, DateTimePicker dtpDe, DateTimePicker dtpA)
        {
            try
            {
                // Run DB query on background thread
                DataTable dataTable = await Task.Run(() => GetAbonneReportData(entreprise, dtpDe, dtpA));

                // Update UI safely on the main thread
                dgv.Invoke(new Action(() =>
                {
                    dgv.DataSource = dataTable;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données: " + ex.Message);
            }
        }
        public async Task LoadPatientDataAsync(DataGridView dgv, string query)
        {
            try
            {
                // Run DB query on background thread
                DataTable dataTable = await Task.Run(() => GetPatientData(query));

                // Update UI safely on the main thread
                dgv.Invoke(new Action(() =>
                {
                    dgv.DataSource = dataTable;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données: " + ex.Message);
            }
        }
        private DataTable GetPatientData(string query)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            {
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        private DataTable GetReceptionReportData(string query, DateTimePicker dtpDe, DateTimePicker dtpA)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dateDe", dtpDe.Text);
            cmd.Parameters.AddWithValue("@dateA", dtpA.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            {
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        SqlCommand cmd;
        private DataTable GetAbonneReportData(int entreprise, DateTimePicker dtpDe, DateTimePicker dtpA)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(_connectionString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "ConsommationAbonne";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntrepriseId", entreprise);
            cmd.Parameters.AddWithValue("@StartDate", dtpDe.Text);
            cmd.Parameters.AddWithValue("@EndDate", dtpA.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            {
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        public async Task LoadOperationAsync(ComptaOperation op, string query)
        {
            try
            {
                // Run DB query on background thread
                DataTable dataTable = await Task.Run(() => GetOperation(query, op));

                // Update UI safely on the main thread
                op.dgvOperation.Invoke(new Action(() =>
                {
                    op.dgvOperation.DataSource = dataTable;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données: " + ex.Message);
            }
        }
        public async Task LoadOpertationJournalAsync(ComptaOperation op, string query)
        {
            try
            {
                // Run DB query on background thread
                DataTable dataTable = await Task.Run(() => GetOperationJournal(query, op));

                // Update UI safely on the main thread
                op.dgvOperation.Invoke(new Action(() =>
                {
                    op.dgvOperation.DataSource = dataTable;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement de données: " + ex.Message);
            }
        }
        private DataTable GetOperationJournal(string query, ComptaOperation op)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@typejournal", op.idtypejournal);
            cmd.Parameters.AddWithValue("@idexercice", op.idexercice);
            cmd.Parameters.AddWithValue("@dateDe", op.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", op.dtpDateA.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            {
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
        private DataTable GetOperation(string query, ComptaOperation op)
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@idexercice", op.idexercice);
            cmd.Parameters.AddWithValue("@dateDe", op.dtpDateDe.Text);
            cmd.Parameters.AddWithValue("@dateA", op.dtpDateA.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            {
                conn.Open();
                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
