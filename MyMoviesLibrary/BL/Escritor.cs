using System;
using System.Collections.Generic;
using System.Text;
using MyMoviesLibrary.DAL;

namespace MyMoviesLibrary.BL
{
    public class Escritor
    {
        public int Idescritor { get; set; }
        public string Nome { get; set; }

        public Escritor() { }

        public Escritor(int id, string nome)
        {
            this.Idescritor = id;
            this.Nome = nome;
        }
        public override String ToString()
        {
            return $"Id: {Idescritor}" +
                $"\nNome: {Nome}";
        }
        public static int Create(Escritor e)
        {
            return EscritorDAL.Create(e);
        }
        public static List<Escritor> ReadNome(Escritor e)
        {
            return EscritorDAL.ReadNome(e);
        }
        public static Escritor ReadId(Escritor e)
        {
            return EscritorDAL.ReadId(e);
        }
        public static List<Escritor> ReadAll()
        {
            return EscritorDAL.ReadAll();
        }
        public static int Update(Escritor e)
        {
            return EscritorDAL.Update(e);
        }
        public static int Delete(Escritor e)
        {
            return EscritorDAL.Delete(e);
        }
        public static bool CreateTable()
        {
            return EscritorDAL.CreateTable();
        }
    }
}
