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
            
            Filme f = new Filme();
            // Filme.CreateTable();
            // f.Idfilme = 12;
            //f.Nome = "uma";
            //f.Duracao = "120min";
            //f.Ano = "10/10/2000";
            //Filme.Create(f);
           
            Ator a = new Ator();

            //Ator.CreateTable();
            // a.Idator = 1;
            //a.Nome = "Tom Cruise";
            //a.Datanascimento = "03/07/1962";
            //Ator.Create(a);

            Filme_ator fa = new Filme_ator();
            Filme_ator.CreateTable();


           
        }
    }

}
