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
        public static bool CreateTable()
        {
            return GeneroDAL.CreateTable();
        }
        public int Create()
        {
            return GeneroDAL.Create(this);
        }
        public static List<Genero> ReadAll()
        {
            return GeneroDAL.ReadAll();
        }
        public int Delete()
        {
            return GeneroDAL.Delete(this);
        }
        public override string ToString()
        {
            return $"{nome}";
        }


    }
}
