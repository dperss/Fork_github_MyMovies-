using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
   public class FilmeDAL
    {
        /*query: SELECT Filme.*, Escritor.nome as escritor, Filme_genero.genero_nome as genero, Diretor.nome as diretor, Ator.nome as ator
        FROM Filme 
        LEFT JOIN Filme_escritor ON Filme.idfilme = Filme_escritor.filme_idfilme 
        LEFT JOIN Escritor ON Filme_escritor.escritor_idescritor = Escritor.idescritor
        LEFT JOIN Filme_genero ON Filme.idfilme = Filme_genero.filme_idfilme
        LEFT JOIN Filme_diretor ON Filme.idfilme = Filme_diretor.filme_idfilme
        LEFT JOIN Diretor ON Filme_diretor.diretor_iddiretor = Diretor.iddiretor
        LEFT JOIN Filme_ator ON Filme.idfilme = Filme_ator.filme_idfilme
        LEFT JOIN Ator ON Filme_ator.ator_idator = Ator.idator; */
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme] (
                            [Idfilme] INT IDENTITY(1,1)         NOT NULL,
                            [nome]          VARCHAR (100) NOT NULL,
                            [duracao]         VARCHAR (10) NOT NULL,
                            [ano]      VARCHAR (10) NOT NULL,
                            [foto]     VARBINARY(max),
                            [visualizacoes] int,
                            [classificacao] int,
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
        {

            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filme]([nome],[duracao],[ano],[visualizacoes],[classificacao])VALUES(@nome,@duracao,@ano,@visualizacoes,@classificacao);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@nome", f.Nome);
            d.Add("@duracao", f.Duracao);
            d.Add("@ano", f.Ano);
            d.Add("@visualizacoes", f.Visualizacoes);
            d.Add("@classificacao", f.Classificacao);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return 0;
            }
        }


        public static List<Filme> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT idfilme, nome, duracao, ano, visualizacoes, classificacao FROM Filme";
            List<Filme> lista = new List<Filme>();

            SqlDataReader row = db.Query(query, null);
            if (row == null)
                return null;
            while (row.Read())
            {
                Filme f = new Filme();
                f.Idfilme = (int)row["idfilme"];
                f.Nome = (string)row["nome"];
                f.Ano = (string)row["ano"]; 
                f.Duracao = (string)row ["duracao"];
                f.Visualizacoes = (int)row["visualizacoes"];
                f.Classificacao = (int)row["classificacao"];
                lista.Add(f);
            }
            row.Close();

            return lista;

        }

        public static Byte[] ReadFoto(Filme f)
        {
            Database db = new Database();
            string query = "SELECT foto FROM Filme WHERE idfilme = @idfilme";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idfilme", f.Idfilme);
            SqlDataReader row = db.Query(query, dictionary);
            if(row == null)
                return null;
            while (row.Read())
            {
                if (row["foto"] != DBNull.Value)
                    f.Foto = (Byte[])row["foto"];
            }
            row.Close();
            return f.Foto;
        }
        public static List<Filme> ReadAllJoin()
        {
            Database db = new Database();
            string query = "SELECT Filme.*, Escritor.nome as escritor, Diretor.nome as diretor " +
            "FROM Filme "
        + "LEFT JOIN Filme_escritor ON Filme.idfilme = Filme_escritor.filme_idfilme " +
        "LEFT JOIN Escritor ON Filme_escritor.escritor_idescritor = Escritor.idescritor " +
        "LEFT JOIN Filme_diretor ON Filme.idfilme = Filme_diretor.filme_idfilme " +
        "LEFT JOIN Diretor ON Filme_diretor.diretor_iddiretor = Diretor.iddiretor;";
            List<Filme> lista = new List<Filme>();

            SqlDataReader row = db.Query(query, null);
            if(row == null)
                return null;
            while (row.Read())
            {
                Filme f = new Filme();
                f.Idfilme = (int)row["idfilme"];
                f.Nome = (string)row["nome"];
                f.Ano = (string)row["ano"];
                f.Duracao = (string)row["duracao"];
                if (row["foto"] != DBNull.Value)
                    f.Foto = (byte[])row["foto"];
                if(row["diretor"] != DBNull.Value)
                f.Diretor.Nome = (string)row["diretor"];
                if (row["escritor"] != DBNull.Value)
                    f.Escritor.Nome = (string)row["escritor"];

                lista.Add(f);
            }
            row.Close();

            return lista;

        }
        public static ObservableCollection<Ator> ReadAllAtores(int idfilme)
        {
            Database db = new Database();
            string query = "SELECT Ator.nome as nome_ator, Ator.idator as id_ator, Ator.datanascimento " +
                "FROM Filme " +
                "LEFT JOIN Filme_ator ON Filme.idfilme = Filme_ator.filme_idfilme " +
                "LEFT JOIN Ator ON Filme_ator.ator_idator = Ator.idator " +
                "WHERE idfilme = @id;";
            ObservableCollection<Ator> collection = new ObservableCollection<Ator>();

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", idfilme);
            SqlDataReader row = db.Query(query, d);
            if (row == null)
                return null;
            while (row.Read())
            {
                Ator a = new Ator();
                if (row["nome_ator"] == DBNull.Value)
                {
                    return collection;
                }
                a.Nome = (string)row["nome_ator"];
                a.Idator = (int)row["id_ator"];
                a.Datanascimento = (string)row["datanascimento"];
                collection.Add(a);
            }
            row.Close();

            return collection;
            }
        public static List<Genero> ReadAllGeneros(int idfilme)
        {
            Database db = new Database();
            string query = "SELECT Genero.nome as nome_genero, Genero.idgenero as id_genero " +
                "FROM Filme " +
                "LEFT JOIN Filme_genero ON Filme.idfilme = Filme_genero.filme_idfilme " +
                "LEFT JOIN Genero ON Filme_genero.genero_idgenero = Genero.idgenero " +
                "WHERE idfilme = @id;";
            List<Genero> lista = new List<Genero>();

            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", idfilme);
            SqlDataReader row = db.Query(query, d);

            if (row == null)
                return null;
            while (row.Read())
            {
                Genero g = new Genero();
                if(row["nome_genero"] == DBNull.Value)
                {
                    return lista;
                }
                g.Nome = (string)row["nome_genero"];
                g.Idgenero = (int)row["id_genero"];
                lista.Add(g);
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
        public static int UpdateVisualizacoes(Filme f)
        {
            Database db = new Database();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string query = "UPDATE Filme SET visualizacoes=@visualizacoes WHERE Idfilme=@Idfilme";
            dictionary.Add("@Idfilme", f.Idfilme);
            dictionary.Add("@visualizacoes", f.Visualizacoes);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }
        public static int UpdateClassificacao(Filme f)
        {
            Database db = new Database();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            string query = "UPDATE Filme SET classificacao=@classificacao WHERE Idfilme=@Idfilme";
            dictionary.Add("@Idfilme", f.Idfilme);
            dictionary.Add("@classificacao", f.Classificacao);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }
        public static int UpdateFoto(Filme f)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Filme] SET foto=@foto WHERE Idfilme=@Idfilme;";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@Idfilme", f.Idfilme);
            dictionary.Add("@foto", f.Foto);
            int result = db.NonQueryFotoFilme(query, dictionary);
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
        public static bool CreateFromObservableCollection(ObservableCollection<Filme> collection)
        {
            Database db = new Database();
            try
            {
                db.NonQuery("DELETE FROM Filme", null);
                ReSeed(0);
                foreach(Filme f in collection)
                {
                    f.Create();
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
