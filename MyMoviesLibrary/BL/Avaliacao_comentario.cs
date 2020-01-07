using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Avaliacao_comentario
    {
        public int Avaliacao { get; set; }
        public string Comentario { get; set; }
        public int Idutilizador { get; set; }
        public int Idfilme { get; set; }

        public Avaliacao_comentario() {
            Avaliacao = 0;
            Comentario = "";
        }

        public override String ToString()
        {
            return $"\nAvaliação: {Avaliacao}" +
                $"\nComentário: {Comentario}" +
                $"\nId Utilizador: {Idutilizador}" +
                $"\nId Filme: {Idfilme}";
        }
        public int Create()
        {
            return Avaliacao_comentarioDAL.Create(this);
        }
        
        public Avaliacao_comentario ReadUtilizadorFilme()
        {
            return Avaliacao_comentarioDAL.ReadUtilizadorFilme(this);
        }
        public List<Avaliacao_comentario> ReadClassificacoesFilme()
        {
            return Avaliacao_comentarioDAL.ReadClassificacoesFilme(this);
        }
        public static List<Avaliacao_comentario> ReadAll()
        {
            return Avaliacao_comentarioDAL.ReadAll();
        }
        public int UpdateAvaliacao()
        {
            return Avaliacao_comentarioDAL.UpdateAvaliacao(this);
        }
        public int UpdateComentario()
        {
            return Avaliacao_comentarioDAL.UpdateComentario(this);
        }
        public int Delete()
        {
            return Avaliacao_comentarioDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return Avaliacao_comentarioDAL.CreateTable();
        }

    }
}
