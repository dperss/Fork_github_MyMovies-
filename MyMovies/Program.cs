using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyMoviesLibrary.BL;
using MyMoviesLibrary.DAL;

namespace MyMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            bool x;

            Filme_escritor a = new Filme_escritor();
            x = a.CreateTable();


            Console.WriteLine(x);
           
        }
    }

}
