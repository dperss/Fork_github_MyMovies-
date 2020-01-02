using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Escritor : INotifyPropertyChanged
    {
        int _Idescritor;
        string _Nome;

        public int Idescritor
        {
            get
            {
                return _Idescritor;
            }
            set
            {
                if(_Idescritor != value)
                {
                    _Idescritor = value;
                    Onchanged("Idescritor");
                }
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
                if (Nome != value)
                {
                    _Nome = value;
                    Onchanged("Nome");
                }
            }
        }

        public Escritor() {
            Nome = "";
        }

        public Escritor(int id, string nome)
        {
            this.Idescritor = id;
            this.Nome = nome;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        public void Onchanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
    }
}
