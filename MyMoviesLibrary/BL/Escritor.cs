using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
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
        public int Create()
        {
            return EscritorDAL.Create(this);
        }
        public List<Escritor> ReadNome()
        {
            return EscritorDAL.ReadNome(this);
        }
        public Escritor ReadId()
        {
            return EscritorDAL.ReadId(this);
        }
        public static List<Escritor> ReadAll()
        {
            return EscritorDAL.ReadAll();
        }
        public int Update()
        {
            return EscritorDAL.Update(this);
        }
        public int Delete()
        {
            return EscritorDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return EscritorDAL.CreateTable();
        }
        public static int ReSeed(int number)
        {
            return EscritorDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Escritor> collection)
        {
            return EscritorDAL.CreateFromObservableCollection(collection);
        }
    }
}
