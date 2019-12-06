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
        public int Create()
        {

            return AtorDAL.Create(this); 
        }
        public int Update()
        {
            return AtorDAL.Update(this);
        }

        public int Delete()
        {
            return AtorDAL.Delete(this);
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

