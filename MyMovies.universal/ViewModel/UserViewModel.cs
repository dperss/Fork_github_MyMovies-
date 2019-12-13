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
    public class UserViewModel
    {
        public Utilizador c;


        public UserViewModel()
        {
            c = new Utilizador();
        }
       
        public bool Login(Utilizador u)
        {
            
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

