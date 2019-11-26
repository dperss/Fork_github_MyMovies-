using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
   public class FilmeDAL
    {
        public static void CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme] (
                            [Idfilme] INT          NOT NULL,
                            [nome]          VARCHAR (10) NOT NULL,
                            [duracao]         VARCHAR (10) NOT NULL,
                            [ano]      VARCHAR (10) NOT NULL,
                            PRIMARY KEY CLUSTERED ([Idfilme] ASC));";
            Filme.Lastupdate = DateTime.Now;
            db.NonQuery(query, null);


        }

        public static int Create(Filme f)
        { //ver se é void e por parametros

            Database db = new Database();
            string query = @"INSERT INTO [dbo].[Filme] ([Idfilme], [nome], [duracao], [ano]) VALUES (@idfilme, @nome, @duracao, @ano)";

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idfilme", f.Idfilme);
            dictionary.Add("@nome", f.Nome);
            dictionary.Add("@duracao", f.Duracao);
            dictionary.Add("@ano", f.Ano);
            Filme.Lastupdate = DateTime.Now;
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }


        public static List<Filme> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT * FROM Filme";
            List<Filme> lista = new List<Filme>();

            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                Filme f = new Filme();
                f.Idfilme = (int)row["idfilme"] ;
                f.Nome = (string)row["nome"];
                f.Ano = (string)row["ano"]; //falta ver qual o tipo para ano e para a duração
                f.Duracao = (string)row ["Duracao"];
                lista.Add(f);
            }
            row.Close();

            return lista;

        }

        public static int Update(Filme f)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Filme] SET duracao=@duracao WHERE Id =@Idfilme ; ";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@duracao", f.Duracao);

            Filme.Lastupdate = DateTime.Now;
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Filme f)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme] WHERE id=@Idfilme";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@ano", f.Ano);

            Filme.Lastupdate = DateTime.Now;
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }









    }
}
