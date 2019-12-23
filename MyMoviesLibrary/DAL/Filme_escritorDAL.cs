using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies.BL;



namespace MyMovies.DAL
{
    class Filme_escritorDAL
    {

        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Filme_escritor] (
                             filme_idfilme int NOT NULL,
                             escritor_idescritor int NOT NULL
                             PRIMARY KEY (filme_idfilme, escritor_idescritor));
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
            string query = "INSERT INTO[dbo].[Filme_escritor]([filme_idfilme],[escritor_idescritor])VALUES(@filme_idfilme, @escritor_idescritor);";
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
            string query = "DELETE FROM [dbo].[Filme_escritor] WHERE filme_idfilme = @filme_idfilme AND escritor_idescritor = @escritor_idescritor;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", u.filme_idfilme);
            d.Add("@escritor_idescritor", u.escritor_idescritor);
            return db.NonQuery(query, d);
        }

        public static int Update(Filme_escritor u)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Filme_escritor] SET[escritor_idescritor] = @escritor_idescritor, filme_idfilme = @filme_idfilme  WHERE filme_idfilme = @filme_idfilme AND escritor_idescritor = escritor_idescritor;";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@filme_idfilme", u.filme_idfilme);
            dictionary.Add("@escritor_idescritor", u.escritor_idescritor);
            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

    }

}