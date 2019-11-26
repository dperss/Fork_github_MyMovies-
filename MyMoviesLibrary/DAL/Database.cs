using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MyMovies.DAL
{
    public class Database
    {

        private SqlConnection connection;
        public Database()
        {
            string server = "projetodai.database.windows.net";
            string user = "mig50";
            string pass = "ProjetoDAI202019";
            this.connection = new SqlConnection($"Server=tcp:{server},1433;Initial Catalog=ProjetoDAI;Persist Security Info=False;User ID={user};Password={pass};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            this.connection.Open();
        }


        public void Close()
        { //metodo que fecha a base de dados 


            connection.Close();

        }

        public SqlDataReader Query(string query, Dictionary<string, object> dic)
        {


            SqlCommand command = new SqlCommand(query, connection);

            if (dic != null)
            {
                foreach (KeyValuePair<string, object> keys in dic)
                {
                    command.Parameters.AddWithValue(keys.Key, keys.Value);

                }
            }

            return command.ExecuteReader();
        }

        public int NonQuery(string query, Dictionary<string, object> dic)
        {
            SqlCommand command = new SqlCommand(query, connection);

            if (dic != null)
            {
                foreach (KeyValuePair<string, object> keys in dic)
                {

                    command.Parameters.AddWithValue(keys.Key, keys.Value);
                }
                

            }

            return command.ExecuteNonQuery();
        }



    }


}