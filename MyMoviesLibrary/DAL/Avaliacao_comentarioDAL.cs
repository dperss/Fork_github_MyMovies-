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
            string query = "INSERT INTO[dbo].[Avaliacao_comentario]([idavaliacao_comentario],[avaliacao],[comentario],[idutilizador],[idfilme])VALUES(@id,@avaliacao,@comentario,@idu,@idf);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", a.Idavaliacao_comentario);
            d.Add("@avalicao", a.Avaliacao);
            d.Add("@comentario", a.Comentario);
            d.Add("@idu", a.Idutilizador);
            d.Add("@idf", a.Idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }

        public static List<Avaliacao_comentario> ReadIdUtilizador(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "SELECT * FROM Avaliacao_comentario WHERE idutilizador=@idu";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Avaliacao_comentario> alist = new List<Avaliacao_comentario>();
            d.Add("@idu", a.Idutilizador);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                a = new Avaliacao_comentario();
                a.Idavaliacao_comentario = (int)row["idavaliacao_comentario"];
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
                a.Idutilizador = (int)row["idutilizador"];
                a.Idfilme = (int)row["idfilme"];
                alist.Add(a);
            }
            row.Close();
            return alist;
        }
        public static List<Avaliacao_comentario> ReadIdFilme(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "SELECT * FROM Avaliacao_comentario WHERE idfilme=@idf";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Avaliacao_comentario> alist = new List<Avaliacao_comentario>();
            d.Add("@idf", a.Idfilme);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                a = new Avaliacao_comentario();
                a.Idavaliacao_comentario = (int)row["idavaliacao_comentario"];
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
                a.Idutilizador = (int)row["idutilizador"];
                a.Idfilme = (int)row["idfilme"];
                alist.Add(a);
            }
            row.Close();
            return alist;
        }

        public static Avaliacao_comentario ReadId(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "SELECT * FROM Avalicao_comentario WHERE idavaliacao_comentario=@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", a.Idavaliacao_comentario);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                a.Idavaliacao_comentario = (int)row["idavaliacao_comentario"];
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
                a.Idutilizador = (int)row["idutilizador"];
                a.Idfilme = (int)row["idfilme"];
            }
            row.Close();
            return a;
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
                a.Idavaliacao_comentario = (int)row["idavaliacao_comentario"];
                a.Avaliacao = (int)row["avaliacao"];
                a.Comentario = (string)row["comentario"];
                a.Idutilizador = (int)row["idutilizador"];
                a.Idfilme = (int)row["idfilme"];
                alist.Add(a);
            }
            row.Close();
            return alist;

        }
        public static int Update(Avaliacao_comentario a)
        {
            Database db = new Database();
            string query = "UPDATE [Avaliacao_comentario] SET[avaliacao] = @avaliacao, [comentario] = @comentario, [idutilizador] = @idu, [idfilme] = @idf WHERE idavaliacao_comentario = @id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", a.Idavaliacao_comentario);
            d.Add("@avaliacao", a.Avaliacao);
            d.Add("@comentario", a.Comentario);
            d.Add("@idu", a.Idutilizador);
            d.Add("@idf", a.Idfilme);
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
            string query = "DELETE FROM [dbo].[Avaliacao_comentario] WHERE idavaliacao_comentario =@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", a.Idavaliacao_comentario);
            int result = db.NonQuery(query, d);
            db.Close();
            return result;
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Avaliacao_comentario] (
                             [idavaliacao_comentario] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                             [avaliacao] INT NOT NULL,
                             [comentario] varchar(300) NOT NULL,
                             [idutilizador] INT NOT NULL,
                             [idfilme] INT NOT NULL,
                             );
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

