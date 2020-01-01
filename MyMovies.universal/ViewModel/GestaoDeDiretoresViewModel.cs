using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    class GestaoDeDiretoresViewModel
    {
        ObservableCollection<Diretor> _diretores;
        Diretor _diretor;

        public Diretor SelectedDiretor
        {
            get
            {
                return _diretor;
            }
            set
            {
                _diretor = value;
            }
        }
        public GestaoDeDiretoresViewModel()
        {
            List<Diretor> lista = Diretor.ReadAll();
            if (lista == null)
            {
                Diretor.CreateTable();
                _diretores = new ObservableCollection<Diretor>();
            }
            else
            {
                _diretores = new ObservableCollection<Diretor>(lista);
            }
        }
        public ObservableCollection<Diretor> Diretores
        {
            get
            {
                return _diretores;

            }
            set
            {
                _diretores = value;
            }

        }

        public bool CreateDiretor(Diretor d)
        {
            if (d.Create() == 1)
            {
                Diretores.Add(d);
                return true;
            }
            return false;
        }
        public bool UpdateDiretor()
        {
            if (SelectedDiretor.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteDiretor()
        {
            if (SelectedDiretor.Delete() == 1)
            {
                if (SelectedDiretor.Iddiretor == Diretores.Count)
                {
                    Diretores.Remove(SelectedDiretor);
                    Diretor.ReSeed(Diretores.Count);
                }
                else
                {

                    foreach (Diretor d in Diretores)
                    {
                        if (d.Iddiretor > SelectedDiretor.Iddiretor)
                            d.Iddiretor -= 1;
                    }
                    Diretores.Remove(SelectedDiretor);
                    Diretor.CreateFromObservableCollection(Diretores);
                }

                return true;
            }
            return false;
        }

        public bool Add_Linha()
        {
            Diretor d = new Diretor();
            d.Iddiretor = Diretores.Count + 1;
            return CreateDiretor(d);
        }
    }
}
