using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMoviesLibrary.BL;

namespace MyMoviesLibrary.DAL
{
    class Filmes_bibliotecaDAL
    {
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filmes_biblioteca] (
                             idfilmes_biblioteca INTEGER PRIMARY KEY NOT NULL,
                             tipo nvarchar(50) NOT NULL,
                             utilizador_idutilizador INTEGER NOT NULL,
                             filme_idfilme INTEGER NOT NULL,);
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
        public static int Create(Filmes_biblioteca u)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filmes_biblioteca]([idfilmes_biblioteca],[tipo],[utilizador_idutilizador],[filme_idfilme])VALUES(@idfilmes_biblioteca,@tipo,@utilizador_idutilizador,@filme_idfilme);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idfilmes_biblioteca", u.idfilmes_biblioteca);
            d.Add("@tipo", u.tipo);
            d.Add("@utilizador_idutilizador", u.utilizador_idutilizador);
            d.Add("@filme_idfilme", u.filme_idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Update(Filmes_biblioteca u)
        {
            Database db = new Database();
            string query = "UPDATE [Filmes_biblioteca] SET[tipo] = @tipo,[utilizador_idutilizador]=@utilizador_idutilizador,[filme_idfilme]=@filme_idfilme WHERE idfilmes_biblioteca = @idfilmes_biblioteca;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idfilmes_biblioteca", u.idfilmes_biblioteca);
            d.Add("@tipo", u.tipo);
            d.Add("@utilizador_idutilizador", u.utilizador_idutilizador);
            d.Add("@filme_idfilme", u.filme_idfilme);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Filmes_biblioteca> ReadAll()
        {
            Database db = new Database();
            Filmes_biblioteca u;
            List<Filmes_biblioteca> ulist = new List<Filmes_biblioteca>();
            string query = "SELECT * FROM Filmes_biblioteca";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                u = new Filmes_biblioteca();
                u.idfilmes_biblioteca = (int)row["idfilmes_biblioteca"];
                u.tipo = (int)row["tipo"];
                u.utilizador_idutilizador = (int)row["utilizador_idutilizador"];
                u.filme_idfilme = (int)row["filme_idfilme"];
                ulist.Add(u);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Filmes_biblioteca u)
        {
            Database db = new Database();
            string query = "DELETE FROM Filmes_biblioteca WHERE idfilmes_biblioteca =@idfilmes_biblioteca;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idfilmes_biblioteca", u.idfilmes_biblioteca);
            return db.NonQuery(query, d);
        }
    }
}

