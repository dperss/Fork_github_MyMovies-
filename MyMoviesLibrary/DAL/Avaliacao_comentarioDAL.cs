using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies.BL;



namespace MyMovies.DAL
{
    public class Avaliacao_comentarioDAL
    {
        public static int Create(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Avaliacao_comentario]([avaliacao],[comentario],[utilizador_idutilizador],[filme_idfilme])VALUES(@avaliacao,@comentario,@idu,@idf);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@avaliacao", a.Avaliacao);
            d.Add("@comentario", a.Comentario);
            d.Add("@idu", a.Idutilizador);
            d.Add("@idf", a.Idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                return 0;
            }
        }

        public static Avaliacao_comentario ReadUtilizadorFilme(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "SELECT comentario, avaliacao FROM Avaliacao_comentario WHERE utilizador_idutilizador=@idu AND filme_idfilme = @idf";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idu", a.Idutilizador);
            d.Add("@idf", a.Idfilme);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
            }
            row.Close();
            db.Close();
            return a;
        }
        public static List<Avaliacao_comentario> ReadClassificacoesFilme(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "SELECT avaliacao FROM Avaliacao_comentario WHERE idfilme=@idf";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Avaliacao_comentario> alist = new List<Avaliacao_comentario>();
            d.Add("@idf", a.Idfilme);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                a = new Avaliacao_comentario();
                a.Avaliacao = (int)row["avaliacao"];
                alist.Add(a);
            }
            row.Close();
            db.Close();
            return alist;
        }
        public static List<Avaliacao_comentario> ReadAll()
        {
            Database db = new Database();
            Avaliacao_comentario a;
            List<Avaliacao_comentario> alist = new List<Avaliacao_comentario>();
            string query = "SELECT * FROM Avaliacao_comentario";
            SqlDataReader row = db.Query(query, null);
            if (!row.HasRows)
                return null;
            while (row.Read())
            {
                a = new Avaliacao_comentario();
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
                a.Idutilizador = (int)row["idutilizador"];
                a.Idfilme = (int)row["idfilme"];
                alist.Add(a);
            }
            row.Close();
            return alist;

        }
        public static List<Avaliacao_comentario> ReadAllComentariosFilme(Avaliacao_comentario ac)
        {
            Database db = new Database();
            string query = "SELECT comentario, Utilizador.nome as nome, utilizador_idutilizador as idutilizador FROM Avaliacao_comentario " +
                "JOIN Utilizador ON Avaliacao_comentario.utilizador_idutilizador = Utilizador.idutilizador " +
                "WHERE filme_idfilme = @idfilme AND comentario != '';";
            List<Avaliacao_comentario> aclist = new List<Avaliacao_comentario>();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@idfilme", ac.Idfilme);
            SqlDataReader row = db.Query(query, dictionary);
            if (row == null)
                return null;
            while (row.Read())
            {
                ac = new Avaliacao_comentario();
                ac.Comentario = (string)row["comentario"];
                ac.NomeUtilizador = (string)row["nome"];
                ac.Idutilizador = (int)row["idutilizador"];
                aclist.Add(ac);
            }
            row.Close();
            db.Close();
            return aclist;
        }
        public static int UpdateAvaliacao(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "UPDATE [Avaliacao_comentario] SET[avaliacao] = @avaliacao WHERE utilizador_idutilizador = @idutilizador AND filme_idfilme = @idfilme";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@avaliacao", a.Avaliacao);
            d.Add("@idutilizador", a.Idutilizador);
            d.Add("@idfilme", a.Idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int UpdateComentario(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "UPDATE [Avaliacao_comentario] SET[comentario] = @comentario WHERE utilizador_idutilizador = @idutilizador AND filme_idfilme = @idfilme";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@comentario", a.Comentario);
            d.Add("@idutilizador", a.Idutilizador);
            d.Add("@idfilme", a.Idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Delete(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "DELETE FROM [dbo].[Avaliacao_comentario] WHERE utilizador_idutilizador = @idutilizador AND filme_idfilme = @idfilme";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idutilizador", a.Idutilizador);
            d.Add("@idfilme", a.Idfilme);
            int result = db.NonQuery(query, d);
            db.Close();
            return result;
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Avaliacao_comentario] (
                             utilizador_idutilizador int FOREIGN KEY REFERENCES Utilizador(idutilizador) NOT NULL,
                             filme_idfilme int FOREIGN KEY REFERENCES Filme(idfilme) NOT NULL,
                             avaliacao INT NOT NULL,
                             comentario varchar(300) NOT NULL
                             PRIMARY KEY(utilizador_idutilizador, filme_idfilme));
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
    }
}

