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
            foreach(Utilizador u in Utilizador.ReadAll())
            {
                Console.WriteLine(u);
            }
            foreach(Ator a in Ator.ReadAll())
            {
                Console.WriteLine(a);
            }
        }
    }

}
