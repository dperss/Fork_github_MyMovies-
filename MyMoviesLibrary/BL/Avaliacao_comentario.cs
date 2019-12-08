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
        public int Create()
        {
            return Avaliacao_comentarioDAL.Create(this);
        }
        public List<Avaliacao_comentario> ReadIdUtilizador()
        {
            return Avaliacao_comentarioDAL.ReadIdUtilizador(this);
        }
        public List<Avaliacao_comentario> ReadIdFilme()
        {
            return Avaliacao_comentarioDAL.ReadIdFilme(this);
        }
        public Avaliacao_comentario ReadId()
        {
            return Avaliacao_comentarioDAL.ReadId(this);
        }
        public static List<Avaliacao_comentario> ReadAll()
        {
            return Avaliacao_comentarioDAL.ReadAll();
        }
        public int Update()
        {
            return Avaliacao_comentarioDAL.Update(this);
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
