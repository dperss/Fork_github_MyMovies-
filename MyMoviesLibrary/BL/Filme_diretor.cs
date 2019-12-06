using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    class Filme_diretor

    {
        public int Filme_idfime { get; set; }
        public int Diretor_iddiretor { get; set; }

        public int Create()
        {

            return Filme_diretorDAL.Create(this);
        }
        public int Update()
        {
            return Filme_diretorDAL.Update(this);
        }

        public int Delete()
        {
            return Filme_diretorDAL.Delete(this);
        }
        public static void CreateTable()
        {
            Filme_diretorDAL.CreateTable();
        }
        public static List<Filme_diretor> ReadAll()
        {
            return Filme_diretorDAL.ReadAll();
        }


    }
}
