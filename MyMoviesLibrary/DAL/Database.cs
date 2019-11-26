using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MyMovies.DAL
{
    public class Database
    {
        SqlConnection connection;
        public Database()
        {
            string server = "projetodai.database.windows.net";
            string user = "mig50";
            string pass = "ProjetoDAI202019";
            this.connection = new SqlConnection($"Server=tcp:{server},1433;Initial Catalog=ProjetoDAI;Persist Security Info=False;User ID={user};Password={pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            this.connection.Open();
        }

        public void Close()
        {
            this.connection.Close();
        }
        public SqlDataReader Query(string query, Dictionary<string, object> d)
        {
            SqlCommand command = new SqlCommand(query, this.connection);
            if (d != null)
            {
                foreach (KeyValuePair<string, object> s in d)
                {
                    command.Parameters.AddWithValue(s.Key, s.Value);
                }
            }
            return command.ExecuteReader();
        }

        public int NonQuery(string query, Dictionary<string, object> d)
        {
            SqlCommand command = new SqlCommand(query, this.connection);
            if (d != null)
            {
                foreach (KeyValuePair<string, object> s in d)
                {
                    command.Parameters.AddWithValue(s.Key, s.Value);
                }
            }
            return command.ExecuteNonQuery();
        }



    }
}