using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
   public class FilmeDAL
    {
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme] (
                            [Idfilme] INT IDENTITY(1,1)         NOT NULL,
                            [nome]          VARCHAR (100) NOT NULL,
                            [duracao]         VARCHAR (10) NOT NULL,
                            [ano]      VARCHAR (10) NOT NULL,
                            PRIMARY KEY CLUSTERED ([Idfilme] ASC));";

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

        public static int Create(Filme f)
        { //ver se é void e por parametros

            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filme]([nome],[duracao],[ano])VALUES(@nome,@duracao,@ano);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@nome", f.Nome);
            d.Add("@duracao", f.Duracao);
            d.Add("@ano", f.Ano);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }


        public static List<Filme> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT * FROM Filme";
            List<Filme> lista = new List<Filme>();

            SqlDataReader row = db.Query(query, null);
            if (row == null)
                return null;
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
            string query = "UPDATE [dbo].[Filme] SET duracao=@duracao, nome=@nome, ano=@ano WHERE Idfilme=@Idfilme;";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@Idfilme", f.Idfilme);
            dictionary.Add("@duracao", f.Duracao);
            dictionary.Add("@nome", f.Nome);
            dictionary.Add("@ano", f.Ano);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Filme f)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme] WHERE Idfilme=@Idfilme";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@Idfilme", f.Idfilme);

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }
        
        public static int ReSeed(int number)
        {
            Database db = new Database();
            string query = "DBCC CHECKIDENT(Filme, RESEED, @number);";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@number", number);
            return db.NonQuery(query, dictionary);
        }









    }
}
