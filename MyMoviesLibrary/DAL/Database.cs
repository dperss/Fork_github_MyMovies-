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
            //... codigo de conecção à base dados e abertura (sql connection e o open)
            //estava a dar erro aqui pq fiz primeiro SqlConnection connection = new .... não é preciso pq ja esta criado em cima e estou a criar 2x
            connection = new SqlConnection("Server=tcp:dpersss.database.windows.net,1433;Initial Catalog=AID_teste;Persist Security Info=False;User ID=dpers;Password=Hct4k#qap0YgwPcp;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            connection.Open();
        }


        public void Close()
        { //metodo que fecha a base de dados 


            connection.Close();

        }

        public SqlDataReader Query(string query, Dictionary<string, string> dic)
        {


            SqlCommand command = new SqlCommand(query, connection);

            if (dic != null)
            {
                foreach (KeyValuePair<string, string> keys in dic)
                {
                    command.Parameters.AddWithValue(keys.Key, keys.Value);

                }
            }

            SqlDataReader row = command.ExecuteReader();
            return row;
        }

        public int NonQuery(string query, Dictionary<string, object> dic)
        {
            int result = 0;
            SqlCommand command = new SqlCommand(query, connection);

            if (dic != null)
            {
                foreach (KeyValuePair<string, object> keys in dic)
                {

                    command.Parameters.AddWithValue(keys.Key, keys.Value);
                }
                result = command.ExecuteNonQuery(); //devolve 0 ou 1

            }

            return result;
        }



    }


}