using MyMovies.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

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
        public bool DeleteUtilizadores(object u)
        {
            Utilizador utilizador = (Utilizador)u;
            if (utilizador.Email=="")
            {
                utilizadores.Remove(utilizador);
                return true;
            }
            if (Utilizador.Delete(utilizador) == 1)
            {
                utilizadores.Remove(utilizador);
                return true;
            }
            return false;
        }

        public void AddLinha()
        {
            Utilizador u = new Utilizador();
            u.Tipo = Tipo.user;
            u.Email = "";
            u.Idutilizador = utilizadores.Count + 1;
            utilizadores.Add(u);
        }
    }
}
