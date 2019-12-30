using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies.BL;

namespace MyMovies.DAL
{
    class GeneroDAL
    {

        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Genero] (
                             nome VARCHAR(50) PRIMARY KEY NOT NULL);
                             ";
            try
            {
                db.NonQuery(query, null);
                return true;

            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }

        }
        public static int Create(Genero u)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Genero]([nome])VALUES(@nome);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@nome", u.nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Genero> ReadAll()
        {
            Database db = new Database();
            Genero u;
            List<Genero> ulist = new List<Genero>();
            string query = "SELECT * FROM Genero";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                u = new Genero();
                u.nome = (string)row["nome"];

                ulist.Add(u);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Genero u)
        {
            Database db = new Database();
            string query = "DELETE FROM Genero WHERE nome =@nome;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@nome", u.nome);
            return db.NonQuery(query, d);
        }
    }
}
