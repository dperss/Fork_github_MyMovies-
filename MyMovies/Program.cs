using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using MyMovies.BL;
using MyMovies.DAL;

namespace MyMovies
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            Console.WriteLine(Utilizador.CreateTable());
            //db.NonQuery("INSERT INTO[dbo].[Utilizador]([idutilizador],[nome],[email],[password],[tipo])VALUES(14,'QUIM','abcde@example.com','abc','user');", null);
            Utilizador u = new Utilizador(2, "SSSS", "ecs", "eee", "user");
            Utilizador u2 = new Utilizador();
            Escritor e = new Escritor(0, "Miguel");
            Avaliacao_comentario a = new Avaliacao_comentario(0, 5, "comment", 1, 1);
            Console.WriteLine("CREATE TABLE: " + Avaliacao_comentario.CreateTable());
            Console.WriteLine("Insert: " + Avaliacao_comentario.Create(a));
            foreach (Avaliacao_comentario x in Avaliacao_comentario.ReadAll())
            {
                Console.WriteLine(x);
                Console.WriteLine();
            }
            Diretor dir = new Diretor(0, "Rita");
            Diretor.Update(dir);
            foreach (Diretor d in Diretor.ReadAll())
            {
                Console.WriteLine(d);
                Console.WriteLine();
            }
            Console.WriteLine(Diretor.CreateTable());
            UtilizadorDAL.Delete(u);
            u2.Nome = "Miguel";
            UtilizadorDAL.Update(u);
            //int a = utilizadorDAL.Delete();
            List<Utilizador> ulist = UtilizadorDAL.ReadAll();
            foreach (Utilizador x in ulist)
            {
                Console.WriteLine(x);
                Console.WriteLine();
            }

        }
    }

}
