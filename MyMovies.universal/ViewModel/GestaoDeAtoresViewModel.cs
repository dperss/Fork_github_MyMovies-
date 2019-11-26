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
        DateTime Lastupdate { get; set; }
        public GestaoDeAtoresViewModel()
        {
            List<Ator> lista = Ator.ReadAll();
            atores = new ObservableCollection<Ator>(lista);
            Lastupdate = DateTime.Now;
        }
        public ObservableCollection<Ator> Atores
        {
            get
            {
                if (this.Lastupdate >= Ator.Lastupdate)
                {
                    return atores;
                }
                else
                {
                    List<Ator> lista = Ator.ReadAll();
                    atores = new ObservableCollection<Ator>(lista);
                    Lastupdate = DateTime.Now;
                    return atores;
                }

            }

        }

        public void CreateAtor()
        {

        }
    }
}
