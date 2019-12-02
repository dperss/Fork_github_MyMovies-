using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyMovies.BL;
using MyMovies.DAL;

namespace MyMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Utilizador.CreateTable());
            Utilizador u = new Utilizador();
            u.Email = "example@email.com";
            u.Nome = "Miguel";
            u.Password = "1232";
            u.Tipo = Tipo.admin;
            
            Utilizador.Create(u);
            foreach (Utilizador x in Utilizador.ReadAll())
            {
                Console.WriteLine(x);
            }
        }
    }

}
