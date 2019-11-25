using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
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
            return DiretorDAL.Create(dir);
        }
        public static List<Diretor> ReadNome(Diretor dir)
        {
            return DiretorDAL.ReadNome(dir);
        }
        public static Diretor ReadId(Diretor dir)
        {
            return DiretorDAL.ReadId(dir);
        }
        public static List<Diretor> ReadAll()
        {
            return DiretorDAL.ReadAll();
        }
        public static int Update(Diretor dir)
        {
            return DiretorDAL.Update(dir);
        }
        public static int Delete(Diretor dir)
        {
            return DiretorDAL.Delete(dir);
        }
        public static bool CreateTable()
        {
            return DiretorDAL.CreateTable();
        }


    }
}
