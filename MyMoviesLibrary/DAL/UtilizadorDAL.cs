﻿using MyMovies.BL;
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
            string query = "INSERT INTO[dbo].[Utilizador]([idutilizador],[nome],[email],[password],[tipo])VALUES(@id,@nome,@email,@password,@tipo);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", u.Idutilizador);
            d.Add("@nome", u.Nome);
            d.Add("@email", u.Email);
            d.Add("@password", u.Password);
            d.Add("@tipo", u.Tipo);
            try
            {
                Utilizador.Lastupdate = DateTime.Now;
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
        public static List<Utilizador> ReadAll()
        {
            Database db = new Database();
            Utilizador u;
            List<Utilizador> ulist = new List<Utilizador>();
            string query = "SELECT * FROM Utilizador";
            SqlDataReader row = db.Query(query, null);
            if (!row.HasRows)
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
            if (u.Tipo.ToString().Equals("admin"))
                d.Add("@tipo", "admin");
            else
                d.Add("@tipo", "user");
            try
            {
                Utilizador.Lastupdate = DateTime.Now;
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
            string query = "DELETE FROM Utilizador WHERE idutilizador =@id;";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@id", u.Idutilizador);
            return db.NonQuery(query, d);
        }
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Utilizador] (
                             idutilizador INT PRIMARY KEY NOT NULL,
                             nome varchar(100) NOT NULL,
                             email varchar(100) NOT NULL,
                             password varchar(45) NOT NULL,
                             tipo varchar(10) NOT NULL CHECK (name IN('admin', 'user')));
                             ";
            try
            {
                Utilizador.Lastupdate = DateTime.Now;
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
