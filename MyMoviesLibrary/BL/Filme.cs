using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    public class Filme
    {
        public int Idfilme { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Duracao { get; set; } //AQUI TEM QUE SE VER QUAL TIPO QUE SE USA PARA TIME //acho que é um TimeSpan

        public byte[] Foto { get; set; }


        public int Create()
        {

            return FilmeDAL.Create(this); //Este metodo vai ser estatico
        }
        public static List<Filme> ReadAll()
        {
            return FilmeDAL.ReadAll();
        }
        public int Update()
        {
            return FilmeDAL.Update(this);
        }

        public int Delete()
        {
            return FilmeDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return FilmeDAL.CreateTable();
        }
    }
}





















