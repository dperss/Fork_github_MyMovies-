using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int Create()
        {
            return DiretorDAL.Create(this);
        }
        public List<Diretor> ReadNome()
        {
            return DiretorDAL.ReadNome(this);
        }
        public Diretor ReadId()
        {
            return DiretorDAL.ReadId(this);
        }
        public static List<Diretor> ReadAll()
        {
            return DiretorDAL.ReadAll();
        }
        public int Update()
        {
            return DiretorDAL.Update(this);
        }
        public int Delete()
        {
            return DiretorDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return DiretorDAL.CreateTable();
        }
        public static int ReSeed(int number)
        {
            return DiretorDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Diretor> collection)
        {
            return DiretorDAL.CreateFromObservableCollection(collection);
        }


    }
}
