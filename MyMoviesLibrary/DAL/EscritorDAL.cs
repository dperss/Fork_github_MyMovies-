using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using FilmesLibrary.BL;

namespace FilmesLibrary.DAL
{
    class EscritorDAL
    {
        public static int Create(Escritor e)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Escritor]([idescritor],[nome])VALUES(@id,@nome);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", e.Idescritor);
            d.Add("@nome", e.Nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Escritor> ReadNome(Escritor e)
        {
            Database db = new Database();
            string query = "SELECT * FROM Escritor WHERE nome=@nome";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Escritor> elist = new List<Escritor>();
            d.Add("@nome", e.Nome);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                e = new Escritor();
                e.Idescritor = (int)row["idescritor"];
                e.Nome = (string)row["nome"];
                elist.Add(e);
            }
            row.Close();
            return elist;
        }
        public static Escritor ReadId(Escritor e)
        {
            Database db = new Database();
            string query = "SELECT * FROM Escritor WHERE idescritor=@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", e.Idescritor);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                e.Idescritor = (int)row["idescritor"];
                e.Nome = (string)row["nome"];
            }
            row.Close();
            return e;
        }
        public static List<Escritor> ReadAll()
        {
            Database db = new Database();
            Escritor e;
            List<Escritor> elist = new List<Escritor>();
            string query = "SELECT * FROM Escritor";
            SqlDataReader row = db.Query(query, null);
            if (!row.HasRows)
                return null;
            while (row.Read())
            {
                e = new Escritor();
                e.Idescritor = (int)row["idescritor"];
                e.Nome = (string)row["nome"];
                elist.Add(e);
            }
            row.Close();
            return elist;
        }
        public static int Update(Escritor e)
        {
            Database db = new Database();
            string query = "UPDATE [Escritor] SET[nome] = @nome WHERE idescritor = @id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", e.Idescritor);
            d.Add("@nome", e.Nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Delete(Escritor e)
        {
            Database db = new Database();
            string query = "DELETE FROM Escritor WHERE idescritor =@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", e.Idescritor);
            return db.NonQuery(query, d);
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Escritor] (
                             idescritor INT PRIMARY KEY NOT NULL,
                             nome varchar(100) NOT NULL,
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
