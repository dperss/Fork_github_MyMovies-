using System;
using System.Collections.Generic;
using System.Text;
using MyMoviesLibrary.DAL;

namespace MyMoviesLibrary.BL
{
    public class Filme_escritor
    {
        public int filme_idfilme { get; set; }
        public int escritor_idescritor { get; set; }
        public Filme_escritor() { }
        public Filme_escritor(int filme_idfilme, int escritor_idescritor)
        {
            this.filme_idfilme = filme_idfilme;
            this.escritor_idescritor = escritor_idescritor;
        }

        public bool CreateTable()
        {
            return Filme_escritorDAL.CreateTable();
        }
        public int Create(Filme_escritor u)
        {
            return Filme_escritorDAL.Create(u);
        }
        public List<Filme_escritor> ReadAll()
        {
            return Filme_escritorDAL.ReadAll();
        }
        public int Delete(Filme_escritor u)
        {
            return Filme_escritorDAL.Delete(u);
        }
    }





}
