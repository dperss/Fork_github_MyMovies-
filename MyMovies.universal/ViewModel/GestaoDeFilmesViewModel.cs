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
        ObservableCollection<Filme> filmes;

        public GestaoDeFilmesViewModel()
        {
            List<Filme> lista = Filme.ReadAll();
            filmes = new ObservableCollection<Filme>(lista);
        }
        public ObservableCollection<Filme> Filmes
        {
            get
            {
                    return filmes;

            }

        }

        public bool CreateFilme(Filme f)
        {
            if (Filme.Create(f) == 1)
            {
                filmes.Add(f);
                return true;
            }
            return false;
        }
    }
}
