using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
    class Filme_atorDAL
    {

        public static void CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme_ator](
                             filme_idfilme int NOT NULL
                             ator_idator int NOT NULL
                             PRIMARY KEY (filme_idfilme, ator_idator))";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            db.NonQuery(query, dictionary);


        }

        public static int Create(Filme_ator fa)
        {

            Database db = new Database();
            string query = @"INSERT INTO [dbo].[Filme_ator] ([filme_idfilme], [ator_idator]) VALUES (@filme_idfilme ,@ator_idator)";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@filme_idfilme", fa.Filme_idfilme);
            dictionary.Add("@ator_idator", fa.Ator_idator);


            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }


        public static List<Filme_ator> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT * FROM Filme_ator";
            List<Filme_ator> lista = new List<Filme_ator>();

            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                Filme_ator fa = new Filme_ator();
                fa.Filme_idfilme = (int)row["filme_idfilme"];
                fa.Ator_idator = (int)row["ator_idator"];


                lista.Add(fa);
            }
            row.Close();

            return lista;

        }

        public static int Update(Filme_ator fa)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Filme_ator] SET [filme_idfilme] = @filme_idfilme, [ator_idator] = @ator_idator WHERE Id =@ator_idator AND filme_idfilme = @filme_idfilme ; ";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@filme_idfilme", fa.Filme_idfilme);
            dictionary.Add("@ator_idator", fa.Ator_idator);


            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Filme_ator fa)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme_ator] WHERE ator_idator = @ator_idator AND filme_idfilme = @filme_idfilme";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@filme_idfilme", fa.Filme_idfilme);
            dictionary.Add("@ator_idator", fa.Ator_idator);

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }
    }
}
