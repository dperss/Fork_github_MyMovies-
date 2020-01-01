using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    public class Filme_ator 
    {
        int _Filme_idfilme;
        int _Ator_idator;

        public int Filme_idfilme
        {
            get
            {
                return _Filme_idfilme;
            }
            set
            {
                _Filme_idfilme = value;
            }
        }
        public int Ator_idator
        {
            get
            {
                return _Ator_idator;
            }
            set
            {
                _Ator_idator = value;
            }
        }

        public int Create()
        {

            return Filme_atorDAL.Create(this); //Este metodo vai ser estatico
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
