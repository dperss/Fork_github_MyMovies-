using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    class GestaoDeGenerosViewModel
    {
        ObservableCollection<Genero> _generos;
        Genero _genero;

        public Genero SelectedGenero
        {
            get
            {
                return _genero;
            }
            set
            {
                _genero = value;
            }
        }
        public GestaoDeGenerosViewModel()
        {
            List<Genero> lista = Genero.ReadAll();
            if (lista == null)
            {
                Genero.CreateTable();
                Filme_genero.CreateTable();
                _generos = new ObservableCollection<Genero>();
            }
            else
            {
                _generos = new ObservableCollection<Genero>(lista);
            }
        }
        public ObservableCollection<Genero> Generos
        {
            get
            {
                return _generos;

            }
            set
            {
                _generos = value;
            }

        }

        public bool CreateGenero(Genero g)
        {
            if (g.Create() == 1)
            {
                Generos.Add(g);
                return true;
            }
            return false;
        }
        public bool UpdateGenero()
        {
            if (SelectedGenero.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public int DeleteGenero()
        {
            int ret = SelectedGenero.Delete();
            if (ret == 1)
            {
                if (SelectedGenero.Idgenero == Generos.Count)
                {
                    Generos.Remove(SelectedGenero);
                    Genero.ReSeed(Generos.Count);
                }
                else
                {

                    foreach (Genero g in Generos)
                    {
                        if (g.Idgenero > SelectedGenero.Idgenero)
                            g.Idgenero -= 1;
                    }
                    Generos.Remove(SelectedGenero);
                    Genero.CreateFromObservableCollection(Generos);
                }
            }
            return ret;
        }

        public bool Add_Linha()
        {
            Genero g = new Genero();
            g.Idgenero = Generos.Count + 1;
            return CreateGenero(g);
        }
    }
}
