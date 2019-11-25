using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP.ViewModels
{
    public class GestaoDeUtilizadoresViewModel
    {
        ObservableCollection<Utilizador> utilizadores;
        DateTime Lastupdate { get; set; }
        public GestaoDeUtilizadoresViewModel()
        {
            List <Utilizador> lista = Utilizador.ReadAll();
            utilizadores = new ObservableCollection<Utilizador>(lista);
            Lastupdate = DateTime.Now;
        }
        public ObservableCollection<Utilizador> Utilizadores {
            get
            {
                if (this.Lastupdate >= Utilizador.Lastupdate)
                {
                    return utilizadores;
                }
                else
                {
                    List<Utilizador> lista = Utilizador.ReadAll();
                    utilizadores = new ObservableCollection<Utilizador>(lista);
                    Lastupdate = DateTime.Now;
                    return utilizadores;
                }
                
            }
         
        }

        public void CreateUtilizador()
        {

        }
    }
}
