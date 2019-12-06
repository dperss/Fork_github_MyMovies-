using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Filme_genero
    {

        public int filme_idfilme { set; get; }
        public string genero_nome { set; get; }
        public Filme_genero() { }
        public Filme_genero(int filme_idfilme, string nome)
        {
            this.filme_idfilme = filme_idfilme;
            this.genero_nome = genero_nome;
        }
        public static bool CreateTable()
        {
            return filme_generoDAL.CreateTable();
        }
        public int Create()
        {
            return filme_generoDAL.Create(this);
        }
        public int Update()
        {
            return filme_generoDAL.Update(this);
        }
        public static List<Filme_genero> ReadAll()
        {
            return filme_generoDAL.ReadAll();
        }
        public int Delete()
        {
            return filme_generoDAL.Delete(this);
        }
    }


}

