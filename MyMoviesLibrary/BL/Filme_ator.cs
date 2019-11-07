using MyMoviesLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoviesLibrary.BL
{
    public class Filme_ator 
    {
        public int Filme_idfilme { get; set; }
        public int Ator_idator { get; set; }


        public static int Create(Filme_ator fa)
        {

            return Filme_atorDAL.Create(fa); //Este metodo vai ser estatico
        }
        public static int Update(Filme_ator fa)
        {
            return Filme_atorDAL.Update(fa);
        }

        public static int Delete(Filme_ator fa)
        {
            return Filme_atorDAL.Delete(fa);
        }
        public static void CreateTable()
        {
            Filme_atorDAL.CreateTable();
        }

        public static List<Filme_ator> ReadAll()
        {
            return Filme_ator.ReadAll();
        }

    }
}
