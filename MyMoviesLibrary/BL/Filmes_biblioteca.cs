using System;
using System.Collections.Generic;
using System.Text;
using MyMoviesLibrary.DAL;

namespace MyMoviesLibrary.BL
{
    public class Filmes_biblioteca
    {
        public int idfilmes_biblioteca { get; set; }
        public int tipo { get;set; }
        public int utilizador_idutilizador { get; set; }
        public int filme_idfilme { get; set; }
        public Filmes_biblioteca() { }
        public Filmes_biblioteca(int idfilmes_biblioteca,int tipo,int utilizador_idutilizador,int filme_idfilme)
        {
            this.idfilmes_biblioteca = idfilmes_biblioteca;
            this.tipo = tipo;
            this.utilizador_idutilizador = utilizador_idutilizador;
            this.filme_idfilme = filme_idfilme;
        }
        public bool CreateTable()
        {
            return Filmes_bibliotecaDAL.CreateTable();
        }
        public int Create(Filmes_biblioteca u)
        {
            return Filmes_bibliotecaDAL.Create(u);
        }
        public int Update(Filmes_biblioteca u) { 
        
            return Filmes_bibliotecaDAL.Update(u);
        }
        public List<Filmes_biblioteca> ReadAll()
        {         
            return Filmes_bibliotecaDAL.ReadAll();
        }
        public int Delete(Filmes_biblioteca u)
        {
            return Filmes_bibliotecaDAL.Delete(u);
        }
    }
}
