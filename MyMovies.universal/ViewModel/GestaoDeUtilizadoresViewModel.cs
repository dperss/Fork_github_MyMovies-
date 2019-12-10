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
        ObservableCollection<Utilizador> _utilizadores;
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
            List<Utilizador> lista = Utilizador.ReadAll();
            if(lista == null)
            {
                Utilizador.CreateTable();
                _utilizadores = new ObservableCollection<Utilizador>();
            }
            else
            {
                _utilizadores = new ObservableCollection<Utilizador>(lista);
            }
        }

        public ObservableCollection<Utilizador> Utilizadores
        {
            get
            {
                return _utilizadores;
            }
            set
            {
                _utilizadores = value;
            }
        }

        public bool CreateUtilizador(Utilizador u)
        {
            if(u.Create() == 1)
            {
                Utilizadores.Add(u);
                return true;
            }
            return false;
        }
        public bool UpdateUtilizador()
        {
            if(SelectedUtilizador.Update() == 1)
            {
                return true;
            }
            return false;
        }
        public bool DeleteUtilizador()
        {
            if (SelectedUtilizador.Delete() == 1)
            {
                Utilizadores.Remove(SelectedUtilizador);
                Utilizador.ReSeed(Utilizadores.Count);
                return true;
            }
            return false;
        }

        public bool Add_Linha()
        {
            Utilizador u = new Utilizador();
            u.Idutilizador = Utilizadores.Count + 1;
            return CreateUtilizador(u);
        }
        public bool Login(Utilizador u)
        {
            Utilizador c = new Utilizador();

            c.Email = u.Email;
            c.ReadEmail();

            if (c.Password == u.Password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
