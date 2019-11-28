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

        public static DateTime Lastupdate { get; set; }
        public byte[] Foto { get; set; }

        public static int Create(Filme f)
        {

            return FilmeDAL.Create(f); //Este metodo vai ser estatico
        }
        public static List<Filme> ReadAll()
        {
            return FilmeDAL.ReadAll();
        }
        public static int Update(Filme f)
        {
            return FilmeDAL.Update(f);
        }

        public static int Delete(Filme f)
        {
            return FilmeDAL.Delete(f);
        }
        public static bool CreateTable()
        {
            return FilmeDAL.CreateTable();
        }
    }
}





















