using System;
using System.Collections.Generic;
using System.Text;
using FilmesLibrary.DAL;

namespace FilmesLibrary.BL
{
    public class avaliacao_comentario
    {
        public int Idavaliacao_comentario { get; set; }
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
        public int Idutilizador { get; set; }
        public int Idfilme { get; set; }

        public avaliacao_comentario() { }

        public avaliacao_comentario(int idavaliacao_comentario, int avaliacao, string comentario, int idutilizador, int idfilme)
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
        public static int Create(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.Create(a);
        }
        public static List<avaliacao_comentario> ReadIdUtilizador(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.ReadIdUtilizador(a);
        }
        public static List<avaliacao_comentario> ReadIdFilme(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.ReadIdFilme(a);
        }
        public static avaliacao_comentario ReadId(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.ReadId(a);
        }
        public static List<avaliacao_comentario> ReadAll()
        {
            return avaliacao_comentarioDAL.ReadAll();
        }
        public static int Update(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.Update(a);
        }
        public static int Delete(avaliacao_comentario a)
        {
            return avaliacao_comentarioDAL.Delete(a);
        }
        public static bool CreateTable()
        {
            return avaliacao_comentarioDAL.CreateTable();
        }

    }
}
