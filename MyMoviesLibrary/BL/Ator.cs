using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace MyMovies.BL
{
    public class Ator : INotifyPropertyChanged
    {
        int _Idator;
        string _Nome;
        string _Datanascimento;
        public int Idator { 
            get 
            {
                return _Idator;
            }
            set 
            {
                _Idator = value;
                Onchanged("Idator");
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
                Onchanged("Nome");
            }
        }
        public string Datanascimento
        {
            get
            {
                return _Datanascimento;
            }
            set
            {
                _Datanascimento = value;
                Onchanged("Datanascimento");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Ator()
        {
            Nome = "";
            Datanascimento = "";
        }
        public override String ToString()
        {
            return $"Id: {Idator}" +
                $"\nNome: {Nome}" +
                $"\nData de Nascimento: {Datanascimento}";
        }
        public int Create()
        {

            return AtorDAL.Create(this); 
        }
        public int Update()
        {
            return AtorDAL.Update(this);
        }

        public int Delete()
        {
            return AtorDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return AtorDAL.CreateTable();
        }

        public static List<Ator> ReadAll()
        {
            return AtorDAL.ReadAll();
        }
        public void Onchanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
        public static int ReSeed(int number)
        {
            return AtorDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Ator> collection)
        {
            return AtorDAL.CreateFromObservableCollection(collection);
        }


    }
}

