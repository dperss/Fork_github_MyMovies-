using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.BL
{
    public class Ator
    {
        public int Idator { get; set; }
        public string Nome { get; set; }
        public string Datanascimento { get; set; }

        public static DateTime Lastupdate { get; set; }


        public override String ToString()
        {
            return $"Id: {Idator}" +
                $"\nNome: {Nome}" +
                $"\nData de Nascimento: {Datanascimento}";
        }
        public static int Create(Ator a)
        {

            return AtorDAL.Create(a); //Este metodo vai ser estatico
        }
        public static int Update(Ator a)
        {
            return AtorDAL.Update(a);
        }

        public static int Delete(Ator a)
        {
            return AtorDAL.Delete(a);
        }
        public static bool CreateTable()
        {
            return AtorDAL.CreateTable();
        }

        public static List<Ator> ReadAll()
        {
            return AtorDAL.ReadAll();
        }


    }
}

