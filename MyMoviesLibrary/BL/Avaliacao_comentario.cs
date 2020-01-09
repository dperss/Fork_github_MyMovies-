using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MyMovies.DAL;

namespace MyMovies.BL
{
    public class Avaliacao_comentario : INotifyPropertyChanged
    {
        int _Avaliacao;
        string _Comentario;
        int _Idutilizador;
        int _Idfilme;
        string _NomeUtilizador;

        public int Avaliacao
        {
            get
            {
                return _Avaliacao;
            }
            set
            {
                _Avaliacao = value;
                Onchanged("Avaliacao");
            }
        }
        public string Comentario
        {
            get
            {
                return _Comentario;
            }
            set
            {
                //nao esta a dar fire do propertychanged
                _Comentario = value;
                Onchanged("Comentario");
            }
        }
        public int Idutilizador
        {
            get
            {
                return _Idutilizador;
            }
            set
            {
                _Idutilizador = value;
                Onchanged("Idutilizador");
            }
        }
        public int Idfilme
        {
            get
            {
                return _Idfilme;
            }
            set
            {
                _Idfilme = value;
                Onchanged("Idfilme");
            }
        }
        public string NomeUtilizador
        {
            get
            {
                return _NomeUtilizador;
            }
            set
            {
                _NomeUtilizador = value;
                Onchanged("NomeUtilizador");
            }
        }

        public Avaliacao_comentario() {
            Avaliacao = 0;
            Comentario = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
        public List<Avaliacao_comentario> ReadAllComentariosFilme()
        {
            return Avaliacao_comentarioDAL.ReadAllComentariosFilme(this);
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
        public void Onchanged(string name)
        {
                if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));

        }

    }
}
