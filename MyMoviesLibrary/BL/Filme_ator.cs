using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    public class Filme_ator 
    {
        public int Filme_idfilme { get; set; }
        public int Ator_idator { get; set; }


        public int Create()
        {

            return Filme_atorDAL.Create(this); //Este metodo vai ser estatico
        }
        public int Update()
        {
            return Filme_atorDAL.Update(this);
        }

        public int Delete()
        {
            return Filme_atorDAL.Delete(this);
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
