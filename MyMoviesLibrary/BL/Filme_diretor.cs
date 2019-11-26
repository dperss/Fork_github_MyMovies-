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

        public static int Create(Filme_diretor fd)
        {

            return Filme_diretorDAL.Create(fd); //Este metodo vai ser estatico
        }
        public static int Update(Filme_diretor fd)
        {
            return Filme_diretorDAL.Update(fd);
        }

        public static int Delete(Filme_diretor fd)
        {
            return Filme_diretorDAL.Delete(fd);
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
