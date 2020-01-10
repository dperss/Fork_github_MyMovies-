using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    public class Filme_diretor

    {
        int _Filme_idfime;
        int _Diretor_iddiretor;

        public int Filme_idfilme
        {
            get
            {
                return _Filme_idfime;
            }
            set
            {
                _Filme_idfime = value;
            }
        }
        public int Diretor_iddiretor
        {
            get
            {
                return _Diretor_iddiretor;
            }
            set
            {
                _Diretor_iddiretor = value;
            }
        }

        public int Create()
        {

            return Filme_diretorDAL.Create(this);
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
