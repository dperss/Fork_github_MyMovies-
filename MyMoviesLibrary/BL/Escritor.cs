using System;
using System.Collections.Generic;
using System.Text;
using FilmesLibrary.DAL;

namespace FilmesLibrary.BL
{
    public class escritor
    {
        public int Idescritor { get; set; }
        public string Nome { get; set; }

        public escritor() { }

        public escritor(int id, string nome)
        {
            this.Idescritor = id;
            this.Nome = nome;
        }
        public override String ToString()
        {
            return $"Id: {Idescritor}" +
                $"\nNome: {Nome}";
        }
        public static int Create(escritor e)
        {
            return escritorDAL.Create(e);
        }
        public static List<escritor> ReadNome(escritor e)
        {
            return escritorDAL.ReadNome(e);
        }
        public static escritor ReadId(escritor e)
        {
            return escritorDAL.ReadId(e);
        }
        public static List<escritor> ReadAll()
        {
            return escritorDAL.ReadAll();
        }
        public static int Update(escritor e)
        {
            return escritorDAL.Update(e);
        }
        public static int Delete(escritor e)
        {
            return escritorDAL.Delete(e);
        }
        public static bool CreateTable()
        {
            return escritorDAL.CreateTable();
        }
    }
}
