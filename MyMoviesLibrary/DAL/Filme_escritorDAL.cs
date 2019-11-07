using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMoviesLibrary.BL;



namespace MyMoviesLibrary.DAL
{
    class Filme_escritorDAL
    {

        public static bool CreateTable()
        {
            Database db = new Database();// escritor_idescritor é fk
            string query = @"CREATE TABLE [dbo].[Filme_escritor] (
                             filme_idfilme integer PRIMARY KEY NOT NULL,
                             escritor_idescritor integer ,)
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
        public static int Create(Filme_escritor u)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filme_escritor]([filme_idfilme],[escritor_idescritor])VALUES(@filme_idfilme,@escritor_idescritor);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", u.filme_idfilme);
            d.Add("@escritor_idescritor", u.escritor_idescritor);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Filme_escritor> ReadAll()
        {
            Database db = new Database();
            Filme_escritor u;
            List<Filme_escritor> ulist = new List<Filme_escritor>();
            string query = "SELECT * FROM Filme_escritor";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                u = new Filme_escritor();
                u.filme_idfilme = (int)row["filme_idfilme"];
                u.escritor_idescritor = (int)row["escritor_idescritor"];
                ulist.Add(u);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Filme_escritor u)
        {
            Database db = new Database();
            string query = "DELETE FROM Filme_escritor WHERE filme_idfilme =@filme_idfilme;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", u.filme_idfilme);
            d.Add("@escritor_idescritor", u.escritor_idescritor);
            return db.NonQuery(query, d);
        }
    }

}
