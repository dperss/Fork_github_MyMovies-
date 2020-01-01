using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Genero
    {
        private int _Idgenero;
        private string _Nome;

        public int Idgenero
        {
            get
            {
                return _Idgenero;
            }
            set
            {
                _Idgenero = value;
            }
        }
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                _Nome = value;
            }
        }

        public Genero() { }
        public Genero(string nome)
        {
            this.Nome = nome;
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
        public int Update()
        {
            return GeneroDAL.Update(this);
        }
        public int Delete()
        {
            return GeneroDAL.Delete(this);
        }
        public override string ToString()
        {
            return $"{Nome}";
        }
        public static int ReSeed(int number)
        {
            return GeneroDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Genero> collection)
        {
            return GeneroDAL.CreateFromObservableCollection(collection);
        }

    }
}
