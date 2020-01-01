using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                             idgenero int IDENTITY(1,1) PRIMARY KEY,
                             nome VARCHAR(50) UNIQUE NOT NULL);";
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
            d.Add("@nome", u.Nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Update(Genero g)
        {
            Database db = new Database();
            string query = "UPDATE [Genero] SET[nome] = @nome WHERE idgenero = @idgenero;";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idgenero", g.Idgenero);
            dictionary.Add("@nome", g.Nome);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
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
                u.Idgenero = (int)row["idgenero"];
                u.Nome = (string)row["nome"];

                ulist.Add(u);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Genero g)
        {
            Database db = new Database();
            string query = "DELETE FROM Genero WHERE idgenero =@idgenero;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idgenero", g.Idgenero);
            return db.NonQuery(query, d);
        }
        public static int ReSeed(int number)
        {
            Database db = new Database();
            string query = "DBCC CHECKIDENT(Genero, RESEED, @number);";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@number", number);
            return db.NonQuery(query, dictionary);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Genero> collection)
        {
            Database db = new Database();
            try
            {
                db.NonQuery("DELETE FROM Genero", null);
                ReSeed(0);
                foreach (Genero g in collection)
                {
                    g.Create();
                }
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
