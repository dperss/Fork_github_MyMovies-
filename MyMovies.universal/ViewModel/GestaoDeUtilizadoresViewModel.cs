using MyMovies.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace MyMovies.universal.ViewModel
{
    public class GestaoDeUtilizadoresViewModel
    {
        ObservableCollection<Utilizador> utilizadores;
        Utilizador _utilizador;

        public Utilizador SelectedUtilizador
        {
            get
            {
                return _utilizador;
            }
            set
            {
                _utilizador = value;
            }
        }
        public GestaoDeUtilizadoresViewModel()
        {
            List <Utilizador> lista = Utilizador.ReadAll();
            if (lista != null)
            {
                utilizadores = new ObservableCollection<Utilizador>(lista);
            }
            else
            {
                utilizadores = new ObservableCollection<Utilizador>();
            }
        }
        public ObservableCollection<Utilizador> Utilizadores {
            get
            {
                return utilizadores;
            }
         
        }

        public bool UpdateUtilizador()
        {
            Utilizador u = utilizadores.FirstOrDefault(x=> x.Idutilizador == SelectedUtilizador.Idutilizador);
            if (u.Update() == 1)
            {
                u = SelectedUtilizador;
                return true;
            }
            
            return false;
        }

        public void AddLinha()
        {
            Utilizador u = new Utilizador();
            u.Email = "";
            u.Idutilizador = utilizadores.Count + 1;
            u.Password = "";
            u.Tipo = Tipo.user;
            u.Nome = "";
            if(u.Create() == 1)
            utilizadores.Add(u);
        }

        public bool CreateUtilizador(Utilizador u)
        {
            if (u.Create() == 1)
            {
                return true;
            }
            return false;
        }

        public bool EliminarUtilizador()
        {
            if(SelectedUtilizador == null)
            {
                return false;
            }
            if(SelectedUtilizador.Delete() == 1)
            {
                utilizadores.Remove(SelectedUtilizador);
                return true;
            }
            return false;
        }

        /*public bool CreateUtilizador(Utilizador u)
        {
            foreach(Utilizador x in utilizadores)
            {
                if (x.Email == u.Email)
                {
                    return false;
                }
            }
            if(u.Create() == 1)
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
            if (utilizador.Delete() == 1)
            {
                utilizadores.Remove(utilizador);
                return true;
            }
            return false;
        }

        public bool UpdateUtilizadores(object u)
        { 
            Utilizador utilizador = (Utilizador)u;
            foreach (Utilizador x in utilizadores)
            {
                if(utilizador.Email == x.Email && utilizador.Idutilizador != x.Idutilizador)
                {
                    return false;
                }
            }
            Utilizador ulist = utilizadores.FirstOrDefault(x=> x.Idutilizador==utilizador.Idutilizador);
            if (utilizador.Update() == 1)
            {
                ulist.Email = utilizador.Email;
                ulist.Nome = utilizador.Nome;
                ulist.Password = utilizador.Password;
                ulist.Tipo = utilizador.Tipo;
                return true;
            }
            return false;
        }

        public void AddLinha()
        {
            Utilizador u = new Utilizador();
            u.Tipo = Tipo.user;
            u.Email = "";
            u.Nome = "";
            u.Password = "";
            if (utilizadores == null)
            {
                utilizadores = new ObservableCollection<Utilizador>();
                u.Idutilizador = 1;
            }
            else
            {
                u.Idutilizador = utilizadores.Count + 1;
            }
            if (u.Create() == 1)
            {
                utilizadores.Add(u);
            }
        }

        public void CheckWhite()
        {
            foreach(Utilizador u in Utilizadores)
            {
                if (u.Email == "")
                    if (u.Delete() == 1)
                    {
                        utilizadores.Remove(u);
                    }
            }
        }*/
        
    }
}
