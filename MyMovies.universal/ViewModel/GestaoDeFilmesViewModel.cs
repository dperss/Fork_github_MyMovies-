using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    public class GestaoDeFilmesViewModel
    {
        ObservableCollection<Filme> _filmes;
        Filme _filme;
        public Filme SelectedFilme
        {
            get
            {
                return _filme;
            }
            set
            {
                _filme = value;
            }
        }
        public GestaoDeFilmesViewModel()
        {
            List<Filme> lista = Filme.ReadAll();
            if(lista == null)
            {
                Filme.CreateTable();
                _filmes = new ObservableCollection<Filme>();
            }
            else
            {
                _filmes = new ObservableCollection<Filme>(lista);
            }
           
        }
        public ObservableCollection<Filme> Filmes
        {
            get
            {
                return _filmes;

            }
            set 
            {
                _filmes = value;
            }

        }

        public bool CreateFilme(Filme f)
        {
            if (f.Create() == 1)
            {
                Filmes.Add(f);
                return true;
            }
            return false;
        }
        
        public bool UpdateFilme() 
        {
            if (SelectedFilme.Update() == 1)
            {
                return true;
            }

            return false;
        }

        public bool DeleteFilme()
        {
            if (SelectedFilme.Delete() == 1)
            {
                if (SelectedFilme.Idfilme == Filmes.Count)
                {
                    Filmes.Remove(SelectedFilme);
                    Filme.ReSeed(Filmes.Count);
                }
                else
                {

                    foreach (Filme f in Filmes)
                    {
                        if (f.Idfilme > SelectedFilme.Idfilme)
                            f.Idfilme -= 1;
                    }
                    Filmes.Remove(SelectedFilme);
                    Filme.CreateFromObservableCollection(Filmes);
                }

                return true;
            }
            return false;
        }
        public bool Add_Linha()
        {
            Filme f = new Filme();
            f.Idfilme = Filmes.Count + 1;
            return CreateFilme(f);
        }
    }
}
