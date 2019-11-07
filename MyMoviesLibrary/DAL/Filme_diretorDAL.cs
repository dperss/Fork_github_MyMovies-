﻿using MyMovies.DAL;
using MyMoviesLibrary.BL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyMoviesLibrary.DAL
{
    class Filme_diretorDAL
    {

        public static void CreateTable()
        {
            Database db = new Database();
            string query = @""; //VER
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            db.NonQuery(query, dictionary);


        }

        public static int Create(Filme_diretor fd)
        { //ver se é void e por parametros

            Database db = new Database();
            string query = @""; //VER

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("@filme_idfilme", fd.Filme_idfime);
            dictionary.Add("@diretor_iddiretor", fd.Diretor_iddiretor);


            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }


        public static List<Filme_diretor> ReadAll()
        {
            Database db = new Database();
            string query = "SELECT * FROM Filme_diretor";
            List<Filme_diretor> lista = new List<Filme_diretor>();

            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                Filme_diretor fd = new Filme_diretor();
                fd.Filme_idfime= (int)row["filme_idfilme"];
                fd.Diretor_iddiretor = (int)row["diretor_iddiretor"];


                lista.Add(fd);
            }
            row.Close();

            return lista;

        }

        public static int Update(Filme_diretor fd)
        {
            Database db = new Database();
            string query = "UPDATE [dbo].[Filme_diretor] SET [filme_idfilme] = @filme_idfilme WHERE Id =@diretor_iddiretor ; "; //VER
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@filme_idfilme", fd.Filme_idfime);
            dictionary.Add("@diretor_iddiretor", fd.Diretor_iddiretor);


            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;
        }

        public static int Delete(Filme_diretor fd)
        {

            Database db = new Database();
            string query = "DELETE FROM [dbo].[Filme_diretor] WHERE "; //VER
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@filme_idfilme", fd.Filme_idfime);
            dictionary.Add("@diretor_iddiretor", fd.Diretor_iddiretor);

            int result = db.NonQuery(query, dictionary);
            db.Close();
            return result;


        }

    }
}
