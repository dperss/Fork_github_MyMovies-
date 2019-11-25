using System;
using System.Collections.Generic;
using System.Text;
using MyMoviesLibrary.DAL;

namespace MyMoviesLibrary.BL
{
    public class Diretor
    {
        public int Iddiretor { get; set; }
        public string Nome { get; set; }

        public Diretor() { }

        public Diretor(int id, string nome) {
            this.Iddiretor = id;
            this.Nome = nome;
        }
        public override String ToString()
        {
            return $"Id: {Iddiretor}" +
                $"\nNome: {Nome}";
        }
        public static int Create(Diretor dir)
        {
            return diretorDAL.Create(dir);
        }
        public static List<Diretor> ReadNome(Diretor dir)
        {
            return diretorDAL.ReadNome(dir);
        }
        public static Diretor ReadId(Diretor dir)
        {
            return diretorDAL.ReadId(dir);
        }
        public static List<Diretor> ReadAll()
        {
            return diretorDAL.ReadAll();
        }
        public static int Update(Diretor dir)
        {
            return diretorDAL.Update(dir);
        }
        public static int Delete(Diretor dir)
        {
            return diretorDAL.Delete(dir);
        }
        public static bool CreateTable()
        {
            return diretorDAL.CreateTable();
        }


    }
}
