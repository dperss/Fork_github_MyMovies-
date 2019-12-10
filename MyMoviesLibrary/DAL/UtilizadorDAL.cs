using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMovies.DAL
{
    public class UtilizadorDAL
    {
        public static int Create(Utilizador u)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Utilizador]([nome],[email],[password],[tipo])VALUES(@nome,@email,@password,@tipo);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            //d.Add("@id", u.Idutilizador);
            d.Add("@nome", u.Nome);
            d.Add("@email", u.Email);
            d.Add("@password", u.Password);
            d.Add("@tipo", u.Tipo.ToString());
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        
        public static List<Utilizador> ReadNome(Utilizador u)
        {
            Database db = new Database();
            string query = "SELECT * FROM Utilizador WHERE nome=@nome";
            Dictionary<string, object> d = new Dictionary<string, object>();
            List<Utilizador> ulist = new List<Utilizador>();
            d.Add("@nome", u.Nome);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                u = new Utilizador();
                u.Idutilizador = (int)row["idutilizador"];
                u.Nome = (string)row["nome"];
                u.Email = (string)row["email"];
                u.Password = (string)row["password"];
                if (((string)row["tipo"]).Equals("admin"))
                    u.Tipo = Tipo.admin;
                else
                    u.Tipo = Tipo.user;
                ulist.Add(u);
            }
            row.Close();
            return ulist;
        }
        public static Utilizador ReadId(Utilizador u)
        {
            Database db = new Database();
            string query = "SELECT * FROM Utilizador WHERE idutilizador=@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id",u.Idutilizador);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                u.Idutilizador = (int)row["idutilizador"];
                u.Nome = (string)row["nome"];
                u.Email = (string)row["email"];
                u.Password = (string)row["password"];
                if (((string)row["tipo"]).Equals("admin"))
                    u.Tipo = Tipo.admin;
                else
                    u.Tipo = Tipo.user;
            }
            row.Close();
            return u;
        }
        public static Utilizador ReadEmail(Utilizador u)
        {
            Database db = new Database();
            string query = "SELECT * FROM Utilizador WHERE email=@email;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@email", u.Email);
            SqlDataReader row = db.Query(query, d);
            if (row.HasRows == false)
                return null;
            while (row.Read())
            {
                u.Idutilizador = (int)row["idutilizador"];
                u.Nome = (string)row["nome"];
                u.Email = (string)row["email"];
                u.Password = (string)row["password"];
                if (((string)row["tipo"]).Equals("admin"))
                    u.Tipo = Tipo.admin;
                else
                    u.Tipo = Tipo.user;
            }
            row.Close();
            return u;
        }
        public static List<Utilizador> ReadAll()
        {
            Database db = new Database();
            Utilizador u;
            List<Utilizador> ulist = new List<Utilizador>();
            string query = "SELECT * FROM Utilizador";
            SqlDataReader row = db.Query(query, null);
            if (row == null)
                return null;
            while (row.Read())
            {
                u = new Utilizador();
                u.Idutilizador = (int)row["idutilizador"];
                u.Nome = (string)row["nome"];
                u.Email = (string)row["email"];
                u.Password = (string)row["password"];
                if (((string)row["tipo"]).Equals("admin"))
                    u.Tipo = Tipo.admin;
                else
                    u.Tipo = Tipo.user;
                ulist.Add(u);
            }
            row.Close();
            return ulist;
            
        }
        public static int Update(Utilizador u)
        {
            Database db = new Database();
            string query = "UPDATE [Utilizador] SET[nome] = @nome, [email] = @email, [password] = @password, [tipo] = @tipo WHERE idutilizador = @id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", u.Idutilizador);
            d.Add("@nome", u.Nome);
            d.Add("@email", u.Email);
            d.Add("@password", u.Password);
            d.Add("@tipo", u.Tipo.ToString());
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static int Delete(Utilizador u)
        {
            Database db = new Database();
            string query = "DELETE FROM Utilizador WHERE idutilizador = @id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", u.Idutilizador);
            return db.NonQuery(query, d);
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Utilizador] (
                             idutilizador INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
                             nome varchar(100) NOT NULL,
                             email varchar(100) NOT NULL,
                             password varchar(45) NOT NULL,
                             tipo varchar(10) NOT NULL CHECK (tipo IN('admin', 'user')));
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
            string query = "DBCC CHECKIDENT(Utilizador, RESEED, @number);";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@number", number);
            return db.NonQuery(query, dictionary);
        }
    }
}
