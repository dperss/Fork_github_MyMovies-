using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Avaliacao_comentario
    {
        public int Idavaliacao_comentario { get; set; }
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
        public int Idutilizador { get; set; }
        public int Idfilme { get; set; }

        public Avaliacao_comentario() { }

        public Avaliacao_comentario(int idavaliacao_comentario, int avaliacao, string comentario, int idutilizador, int idfilme)
        {
            this.Idavaliacao_comentario = idavaliacao_comentario;
            this.Avaliacao = avaliacao;
            this.Comentario = comentario;
            this.Idutilizador = idutilizador;
            this.Idfilme = idfilme;
        }

        public override String ToString()
        {
            return $"Id: {Idavaliacao_comentario}" +
                $"\nAvaliação: {Avaliacao}" +
                $"\nComentário: {Comentario}" +
                $"\nId Utilizador: {Idutilizador}" +
                $"\nId Filme: {Idfilme}";
        }
        public static int Create(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.Create(a);
        }
        public static List<Avaliacao_comentario> ReadIdUtilizador(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.ReadIdUtilizador(a);
        }
        public static List<Avaliacao_comentario> ReadIdFilme(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.ReadIdFilme(a);
        }
        public static Avaliacao_comentario ReadId(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.ReadId(a);
        }
        public static List<Avaliacao_comentario> ReadAll()
        {
            return Avaliacao_comentarioDAL.ReadAll();
        }
        public static int Update(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.Update(a);
        }
        public static int Delete(Avaliacao_comentario a)
        {
            return Avaliacao_comentarioDAL.Delete(a);
        }
        public static bool CreateTable()
        {
            return Avaliacao_comentarioDAL.CreateTable();
        }

    }
}
