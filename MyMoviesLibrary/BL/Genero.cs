using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Genero
    {
        public string nome { set; get; }

        public Genero() { }
        public Genero(string nome)
        {
            this.nome = nome;
        }
        public bool CreateTable()
        {
            return GeneroDAL.CreateTable();
        }
        public int Create(Genero u)
        {
            return GeneroDAL.Create(u);
        }
        public List<Genero> ReadAll()
        {
            return GeneroDAL.ReadAll();
        }
        public int Delete(Genero u)
        {
            return GeneroDAL.Delete(u);
        }


    }
}
