
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SUMEDCO
{
    class ClassConnexion
    {
        public SqlConnection Connexion()
        {
            string conString = ConfigurationManager.ConnectionStrings["SUMEDCO.Properties.Settings.conString1"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            return con;
        }
        
    }
}
