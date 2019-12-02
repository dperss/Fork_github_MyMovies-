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
                            [Idfilme] INT          NOT NULL,
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
            string query = "INSERT INTO[dbo].[Filme]([Idfilme],[nome],[duracao],[ano])VALUES(@id,@nome,@duracao,@ano);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", f.Idfilme);
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

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }









    }
}
