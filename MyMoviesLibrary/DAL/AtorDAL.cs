using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
    class AtorDAL
    {
        public static void CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Ator] (
                            [idator] INT          NOT NULL,
                            [nome]          VARCHAR (10) NOT NULL,
                            [datanascimento]         VARCHAR (10) NOT NULL,
                            PRIMARY KEY CLUSTERED ([idator] ASC));";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            db.NonQuery(query, dictionary);


        }

        public static int Create(Ator a)
        { //ver se é void e por parametros

            Database db = new Database();
            string query = @"INSERT INTO [dbo].[Ator] ([Idator], [Nome], [Datanascimento]) VALUES (@idator, @nome, @datanascimento)";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idator", a.Idator);
            dictionary.Add("@nome", a.Nome);
            dictionary.Add("@datanascimento", a.Datanascimento);
            
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }


        public static List<Ator> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT * FROM Ator";
            List<Ator> lista = new List<Ator>();

            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                Ator a = new Ator();
                a.Idator = (int)row["idator"];
                a.Nome = (string)row["nome"];
                a.Datanascimento= (string)row["datanascimento"]; //falta ver qual o tipo para ano e para a duração
               
                lista.Add(a);
            }
            row.Close();

            return lista;

        }

        public static int Update(Ator a)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Ator] SET [datanascimento] = @datanascimento WHERE Idator =@Idator ; ";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@datanascimento", a.Datanascimento);


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

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }
    }
}
