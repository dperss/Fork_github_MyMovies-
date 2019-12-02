using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMovies.BL;


namespace MyMovies.universal.ViewModel
{
    public class GestaoDeAtoresViewModel
    {
        ObservableCollection<Ator> atores;
        public GestaoDeAtoresViewModel()
        {
            List<Ator> lista = Ator.ReadAll();
            atores = new ObservableCollection<Ator>(lista);
        }
        public ObservableCollection<Ator> Atores
        {
            get
            {
                    return atores;

            }

        }

        public bool CreateAtor(Ator a)
        {
            if (Ator.Create(a) == 1)
            {
                atores.Add(a);
                return true;
            }
            return false;
        }
    }
}
