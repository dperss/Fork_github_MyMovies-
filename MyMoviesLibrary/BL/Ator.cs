using MyMoviesLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoviesLibrary.BL
{
    public class Ator
    {
        public int Idator { get; set; }
        public string Nome { get; set; }
        public string Datanascimento { get; set; }



        public static int Create(Ator a)
        {

            return AtorDAL.Create(a); //Este metodo vai ser estatico
        }
        public static int Update(Ator a)
        {
            return AtorDAL.Update(a);
        }

        public static int Delete(Ator a)
        {
            return AtorDAL.Delete(a);
        }
        public static void CreateTable()
        {
            AtorDAL.CreateTable();
        }

        public static List<Ator> ReadAll()
        {
            return Ator.ReadAll();
        }


    }
}

