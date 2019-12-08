using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
    class AtorDAL
    {
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Ator] (
                            [idator] INT IDENTITY(1,1)         NOT NULL,
                            [nome]          VARCHAR (100) NOT NULL,
                            [datanascimento]         VARCHAR (10) NOT NULL,
                            PRIMARY KEY CLUSTERED ([idator] ASC));";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();


            try
            {
                db.NonQuery(query, dictionary);
                return true;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return false;
            }

        }

        public static int Create(Ator a)
        { //ver se é void e por parametros

            Database db = new Database();
            string query = @"INSERT INTO [dbo].[Ator] ( [nome], [datanascimento]) VALUES (@nome, @datanascimento)";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@nome", a.Nome);
            dictionary.Add("@datanascimento", a.Datanascimento);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }


        public static List<Ator> ReadAll()
        {
            Database db = new Database();
            Ator a;
            List<Ator> alist = new List<Ator>();
            string query = "SELECT * FROM Ator";
            SqlDataReader row = db.Query(query, null);
            if (row == null)
                return null;
            while (row.Read())
            {
                a = new Ator();
                a.Idator = (int)row["idator"];
                a.Nome = (string)row["nome"];
                a.Datanascimento = (string)row["datanascimento"];
                alist.Add(a);
            }
            row.Close();
            return alist;


        }

        public static int Update(Ator a)
        {
            Database db = new Database();
            string query = "UPDATE [Ator] SET[nome] = @nome, [datanascimento] = @datanascimento WHERE idator = @idator;";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idator", a.Idator);
            dictionary.Add("@nome", a.Nome);
            dictionary.Add("@datanascimento", a.Datanascimento);

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Ator a)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Ator] WHERE idator=@idator";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@idator", a.Idator);

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }

        public static int ReSeed(int number)
        {
            Database db = new Database();
            string query = "DBCC CHECKIDENT(Ator, RESEED, @number);";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@number", number);
            return db.NonQuery(query, dictionary);
        }
    }
}
