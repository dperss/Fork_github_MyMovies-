using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Diretor : INotifyPropertyChanged
    {
        private int _Iddiretor;
        private string _Nome;
        public int Iddiretor
        {
            get
            {
                return _Iddiretor;
            }
            set
            {
                if(_Iddiretor!= value)
                {
                    _Iddiretor = value;
                    Onchanged("Iddiretor");
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
                if(_Nome!= value)
                {
                    _Nome = value;
                    Onchanged("Nome");
                }
            }
        }

        public Diretor() {
            Nome = "";
        }

        public Diretor(int id, string nome) {
            this.Iddiretor = id;
            this.Nome = nome;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override String ToString()
        {
            return $"{Nome}";
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
        public void Onchanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }


    }
}
