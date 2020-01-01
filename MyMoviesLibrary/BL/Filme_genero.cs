using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Filme_genero
    {

        int _Filme_idfilme;
        int _Genero_idgenero;

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

        public int Genero_idgenero
        {
            get
            {
                return _Genero_idgenero;
            }
            set
            {
                _Genero_idgenero = value;
            }
        }
        public Filme_genero() { }
        public Filme_genero(int filme_idfilme, int genero_idgenero)
        {
            this.Filme_idfilme = filme_idfilme;
            this.Genero_idgenero = genero_idgenero;
        }
        public static bool CreateTable()
        {
            return filme_generoDAL.CreateTable();
        }
        public int Create()
        {
            return filme_generoDAL.Create(this);
        }

        public static List<Filme_genero> ReadAll()
        {
            return filme_generoDAL.ReadAll();
        }
        public int Delete()
        {
            return filme_generoDAL.Delete(this);
        }
    }


}

