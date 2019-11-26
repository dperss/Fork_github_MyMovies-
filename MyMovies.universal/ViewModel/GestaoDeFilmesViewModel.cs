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
        DateTime Lastupdate { get; set; }

        public GestaoDeFilmesViewModel()
        {
            List<Filme> lista = Filme.ReadAll();
            filmes = new ObservableCollection<Filme>(lista);
            Lastupdate = DateTime.Now;
        }
        public ObservableCollection<Filme> Filmes
        {
            get
            {
                if (this.Lastupdate >= Filme.Lastupdate)
                {
                    return filmes;
                }
                else
                {
                    List<Filme> lista = Filme.ReadAll();
                    filmes = new ObservableCollection<Filme>(lista);
                    Lastupdate = DateTime.Now;
                    return filmes;
                }

            }

        }

        public void CreateFilme()
        {

        }
    }
}
