using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMovies.universal.ViewModel
{
    public class GestaoDeUtilizadoresViewModel
    {
        ObservableCollection<Utilizador> utilizadores;
        public GestaoDeUtilizadoresViewModel()
        {
            List <Utilizador> lista = Utilizador.ReadAll();
            utilizadores = new ObservableCollection<Utilizador>(lista);
        }
        public ObservableCollection<Utilizador> Utilizadores {
            get
            {
                return utilizadores;
                
            }
         
        }

        public bool CreateUtilizador(Utilizador u)
        {
            foreach(Utilizador x in utilizadores)
            {
                if (x.Email == u.Email)
                {
                    return false;
                }
            }
            if(Utilizador.Create(u) == 1)
            {
                utilizadores.Add(u);
                return true;
            }
            return false;
        }
    }
}
