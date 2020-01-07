using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

public enum Categoria { favorito=0, visto=1, para_ver=2};

namespace MyMovies.BL
{
    public class Biblioteca
    {
        Categoria _Categoria;
        int _Utilizador_idutilizador;
        int _Filme_idfilme;

        public Categoria Categoria
        {
            get
            {
                return _Categoria;
            }
            set
            {
                _Categoria = value;
            }
        }
        public int Utilizador_idutilizador
        {
            get
            {
                return _Utilizador_idutilizador;
            }
            set
            {
                _Utilizador_idutilizador = value;
            }
        }
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

        public Biblioteca() { }
        public static bool CreateTable()
        {
            return BibliotecaDAL.CreateTable();
        }
        public int Create()
        {
            return BibliotecaDAL.Create(this);
        }
        public static List<Biblioteca> ReadAll()
        {
            return BibliotecaDAL.ReadAll();
        }
        public int Delete()
        {
            return BibliotecaDAL.Delete(this);
        }
    }
}
