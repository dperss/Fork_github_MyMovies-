using MyMoviesLibrary.BL;
using System;

namespace MyMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Filme_escritor b = new Filme_escritor(1,2);
            b.Delete(b);
            

            Console.WriteLine("Hello World!");
        }
    }

}
