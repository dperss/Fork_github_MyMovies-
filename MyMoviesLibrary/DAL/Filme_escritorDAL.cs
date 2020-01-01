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
                             filme_idfilme int UNIQUE FOREIGN KEY REFERENCES Filme(idfilme) NOT NULL,
                             escritor_idescritor int FOREIGN KEY REFERENCES Escritor(idescritor) NOT NULL
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
        public static int Create(Filme_escritor fe)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Filme_escritor]([filme_idfilme],[escritor_idescritor])VALUES(@filme_idfilme, @escritor_idescritor);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", fe.Filme_idfilme);
            d.Add("@escritor_idescritor", fe.Escritor_idescritor);
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
            Filme_escritor fe;
            List<Filme_escritor> ulist = new List<Filme_escritor>();
            string query = "SELECT * FROM Filme_escritor";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                fe = new Filme_escritor();
                fe.Filme_idfilme = (int)row["filme_idfilme"];
                fe.Escritor_idescritor = (int)row["escritor_idescritor"];
                ulist.Add(fe);
            }
            row.Close();
            return ulist;

        }

        public static int Delete(Filme_escritor fe)
        {
            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme_escritor] WHERE filme_idfilme = @filme_idfilme AND escritor_idescritor = @escritor_idescritor;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@filme_idfilme", fe.Filme_idfilme);
            d.Add("@escritor_idescritor", fe.Escritor_idescritor);
            return db.NonQuery(query, d);
        }

    }

}