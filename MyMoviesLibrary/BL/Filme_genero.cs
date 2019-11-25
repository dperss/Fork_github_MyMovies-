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
        public bool CreateTable()
        {
            return filme_generoDAL.CreateTable();
        }
        public int Create(Filme_genero u)
        {
            return filme_generoDAL.Create(u);
        }
        public int Update(Filme_genero u)
        {
            return filme_generoDAL.Update(u);
        }
        public List<Filme_genero> ReadAll()
        {
            return filme_generoDAL.ReadAll();
        }
        public int Delete(Filme_genero u)
        {
            return filme_generoDAL.Delete(u);
        }
    }


}

