using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using MyMovies.BL;

namespace MyMovies.DAL
{
    class BibliotecaDAL
    {
        public static bool CreateTable()
        {
            Database db = new Database();
            string query = @"CREATE TABLE [dbo].[Biblioteca] (
                             utilizador_idutilizador int FOREIGN KEY REFERENCES Utilizador(idutilizador) NOT NULL,
                             filme_idfilme int FOREIGN KEY REFERENCES Filme(idfilme) NOT NULL,
                             categoria varchar(10) NOT NULL CHECK (categoria IN('favorito', 'visto', 'para_ver'))
                             PRIMARY KEY (utilizador_idutilizador, filme_idfilme, categoria));
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
        public static int Create(Biblioteca u)
        {
            Database db = new Database();
            string query = "INSERT INTO[dbo].[Biblioteca]([utilizador_idutilizador],[filme_idfilme],[categoria])VALUES(@idutilizador,@idfilme,@categoria);";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idutilizador", u.Utilizador_idutilizador);
            d.Add("@idfilme", u.Filme_idfilme);
            d.Add("@categoria", u.Categoria.ToString());
            try
            {
                return db.NonQuery(query, d);
            }
            catch (System.Data.SqlClient.SqlException)
            {
                return 0;
            }
        }
        public static List<Biblioteca> ReadAll()
        {
            Database db = new Database();
            Biblioteca b;
            List<Biblioteca> blist = new List<Biblioteca>();
            string query = "SELECT * FROM Biblioteca";
            SqlDataReader row = db.Query(query, null);
            while (row.Read())
            {
                b = new Biblioteca();
                b.Utilizador_idutilizador = (int)row["utilizador_idutilizador"];
                if (((string)row["categoria"]).Equals("favorito"))
                    b.Categoria = Categoria.favorito;
                else if (((string)row["categoria"]).Equals("visto"))
                    b.Categoria = Categoria.visto;
                else
                    b.Categoria = Categoria.para_ver;
                blist.Add(b);
            }
            row.Close();
            db.Close();
            return blist;

        }
        public static List<Biblioteca> ReadUtilizadorFilme(Biblioteca b)
        {
            Database db = new Database();
            List<Biblioteca> blist = new List<Biblioteca>();
            string query = "SELECT categoria FROM Biblioteca WHERE utilizador_idutilizador=@idutilizador AND filme_idfilme=@idfilme";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idutilizador", b.Utilizador_idutilizador);
            d.Add("@idfilme", b.Filme_idfilme);
            SqlDataReader row = db.Query(query, d);
            if(row == null)
            {
                return null;
            }
            while (row.Read())
            {
                b = new Biblioteca();
                if (((string)row["categoria"]).Equals("favorito"))
                    b.Categoria = Categoria.favorito;
                else if (((string)row["categoria"]).Equals("visto"))
                    b.Categoria = Categoria.visto;
                else
                    b.Categoria = Categoria.para_ver;
                blist.Add(b);
            }
            row.Close();
            db.Close();
            return blist;
        }

        public static int Delete(Biblioteca b)
        {
            Database db = new Database();
            string query = "DELETE FROM Biblioteca WHERE utilizador_idutilizador = @idutilizador AND filme_idfilme = @idfilme AND categoria = @categoria";
            Dictionary<string, object> d = new Dictionary<string, object>();
            d.Add("@idutilizador", b.Utilizador_idutilizador);
            d.Add("@idfilme", b.Filme_idfilme);
            d.Add("@categoria", b.Categoria.ToString()) ;
            return db.NonQuery(query, d);
        }
    }
}

