using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyMovies.BL;
using MyMovies.DAL;
using System.IO;

namespace MyMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Filme f = new Filme();
            f.Idfilme = 1;
            foreach(Ator a in f.ReadAllAtores())
            {
                Console.WriteLine(a);
            }
        }
    }

}
