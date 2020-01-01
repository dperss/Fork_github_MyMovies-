using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies.BL;

namespace MyMovies.DAL
{
    class filme_generoDAL
    {

        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme_genero] (filme_idfilme INT FOREIGN KEY REFERENCES Filme(idfilme) NOT NULL,
                             genero_idgenero INT FOREIGN KEY REFERENCES Genero(idgenero) NOT NULL
                             PRIMARY KEY (filme_idfilme, genero_idgenero));
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
        public static int Create(Filme_genero fg)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filme_genero]([filme_idfilme],[genero_idgenero])VALUES(@filme_idfilme,@genero_idgenero);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", fg.Filme_idfilme);
            d.Add("@genero_idgenero", fg.Genero_idgenero);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Filme_genero> ReadAll()
        {
            Database db = new Database();
            Filme_genero u;
            List<Filme_genero> ulist = new List<Filme_genero>();
            string query = "SELECT * FROM Filme_genero";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                u = new Filme_genero();
                u.Filme_idfilme = (int)row["filme_idfilme"];
                u.Genero_idgenero = (int)row["genero_idgenero"];

                ulist.Add(u);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Filme_genero fg)
        {
            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme_genero] WHERE filme_idfilme = @filme_idfilme AND genero_idgenero = @genero_idgenero;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", fg.Filme_idfilme);
            d.Add("@genero_idgenero", fg.Genero_idgenero);
            return db.NonQuery(query, d);
        }
    }
}

