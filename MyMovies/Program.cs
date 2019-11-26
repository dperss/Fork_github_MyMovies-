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
            Filme f = new Filme();
            f.Ano = "1985";
            f.Duracao = "1h56m";
            f.Idfilme = 1;
            f.Nome = "Back To The Future";
            Console.WriteLine(Filme.Create(f));

        }
    }

}
