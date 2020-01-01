using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Filme_escritor
    {
        int _Filme_idfilme;
        int _Escritor_idescritor;

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
        public int Escritor_idescritor
        {
            get
            {
                return _Escritor_idescritor;
            }
            set
            {
                _Escritor_idescritor = value;
            }
        }
        public Filme_escritor() { }
        public Filme_escritor(int filme_idfilme, int escritor_idescritor)
        {
            this.Filme_idfilme = filme_idfilme;
            this.Escritor_idescritor = escritor_idescritor;
        }

        public static bool CreateTable()
        {
            return Filme_escritorDAL.CreateTable();
        }
        public int Create()
        {
            return Filme_escritorDAL.Create(this);
        }
        public static List<Filme_escritor> ReadAll()
        {
            return Filme_escritorDAL.ReadAll();
        }
        public int Delete()
        {
            return Filme_escritorDAL.Delete(this);
        }
    }





}
