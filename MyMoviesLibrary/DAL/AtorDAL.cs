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
                Ator.Lastupdate = DateTime.Now;
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
            string query = @"INSERT INTO [dbo].[Ator] ([idator], [nome], [datanascimento]) VALUES (@idator, @nome, @datanascimento)";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idator", a.Idator);
            dictionary.Add("@nome", a.Nome);
            dictionary.Add("@datanascimento", a.Datanascimento);

            Ator.Lastupdate = DateTime.Now;
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
            if (!row.HasRows)
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
            string query = "UPDATE [dbo].[Ator] SET [datanascimento] = @datanascimento WHERE Idator =@Idator ; ";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@datanascimento", a.Datanascimento);

            Ator.Lastupdate = DateTime.Now;
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Ator a)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Ator] WHERE id=@idator";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@datanascimento", a.Datanascimento);

            Ator.Lastupdate = DateTime.Now;
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }
    }
}
