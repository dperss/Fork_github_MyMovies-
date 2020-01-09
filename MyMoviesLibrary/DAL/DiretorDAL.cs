using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.BL;
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace MyMovies.DAL
{
    public class DiretorDAL
    {
        public static int Create(Diretor dir)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Diretor]([iddiretor],[nome])VALUES(@id,@nome);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", dir.Iddiretor);
            d.Add("@nome", dir.Nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Diretor> ReadNome(Diretor dir)
        {
            Database db = new Database();
            string query = "SELECT * FROM Diretor WHERE nome=@nome";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Diretor> dirlist = new List<Diretor>();
            d.Add("@nome", dir.Nome);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                dir = new Diretor();
                dir.Iddiretor = (int)row["iddiretor"];
                dir.Nome = (string)row["nome"];
                dirlist.Add(dir);
            }
            row.Close();
            return dirlist;
        }
        public static Diretor ReadId(Diretor dir)
        {
            Database db = new Database();
            string query = "SELECT * FROM Diretor WHERE iddiretor=@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", dir.Iddiretor);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                dir.Iddiretor = (int)row["iddiretor"];
                dir.Nome = (string)row["nome"];
            }
            row.Close();
            return dir;
        }
        public static List<Diretor> ReadAll()
        {
            Database db = new Database();
            Diretor dir;
            List<Diretor> dirlist = new List<Diretor>();
            string query = "SELECT * FROM Diretor";
            SqlDataReader row = db.Query(query, null);
            if (row == null)
                return null;
            while (row.Read())
            {
                dir = new Diretor();
                dir.Iddiretor = (int)row["iddiretor"];
                dir.Nome = (string)row["nome"];
                dirlist.Add(dir);
            }
            row.Close();
            return dirlist;
        }
        public static int Update(Diretor dir)
        {
            Database db = new Database();
            string query = "UPDATE [Diretor] SET[nome] = @nome WHERE iddiretor = @id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", dir.Iddiretor);
            d.Add("@nome", dir.Nome);
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Delete(Diretor dir)
        {
            Database db = new Database();
            string query = "DELETE FROM Diretor WHERE iddiretor =@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", dir.Iddiretor);
            return db.NonQuery(query, d);
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Diretor] (
                             iddiretor INT PRIMARY KEY NOT NULL,
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
        public static int ReSeed(int number)
        {
            Database db = new Database();
            string query = "DBCC CHECKIDENT(Diretor, RESEED, @number);";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@number", number);
            return db.NonQuery(query, dictionary);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Diretor> collection)
        {
            Database db = new Database();
            try
            {
                db.NonQuery("DELETE FROM Diretor", null);
                ReSeed(0);
                foreach (Diretor d in collection)
                {
                    d.Create();
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
