using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;

namespace MyMovies.BL
{
    public class Filme : INotifyPropertyChanged
    {
        private int _Idfilme;
        private string _Nome;
        private string _Ano;
        private string _Duracao;
        private byte[] _Foto;
        private Diretor _Diretor;
        private Escritor _Escritor;
        private ObservableCollection<Ator> _Atores;
        private List<Genero> _Generos;
        private long _Visualizacoes;
        private long _Classificacao;

        public int Idfilme {
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
        public string Nome { 
            get 
            { 
                return _Nome;  
            } 
            set
            {
                _Nome = value;
                Onchanged("Nome");
            } 
        }
        public string Ano { 
            get 
            { 
                return _Ano; 
            } 
            set 
            {
                _Ano = value;
                Onchanged("Ano");
            } 
        }
        public string Duracao { 
            get 
            { 
                return _Duracao; 
            } 
            set 
            {
                _Duracao = value;
                Onchanged("Duracao");
            } 
        } //AQUI TEM QUE SE VER QUAL TIPO QUE SE USA PARA TIME //acho que é um TimeSpan

        public byte[] Foto
        {
            get
            {
                return _Foto;
            }
            set
            {
                _Foto = value;
                Onchanged("Foto");
            }
        }

        public Diretor Diretor
        {
            get
            {
                return _Diretor;
            }
            set
            {
                _Diretor = value;
                Onchanged("Diretor");
            }
        }
        public Escritor Escritor
        {
            get
            {
                return _Escritor;
            }
            set
            {
                _Escritor = value;
                Onchanged("Escritor");
            }
        }
        public ObservableCollection<Ator> Atores
        {
            get
            {
                return _Atores;
            }
            set
            {
                _Atores = value;
                Onchanged("Atores");
            }
        }
        public List<Genero> Generos
        {
            get
            {
                return _Generos;
            }
            set
            {
                _Generos = value;
                Onchanged("Generos");
            }
        }
        public long Visualizacoes
        {
            get
            {
                return _Visualizacoes;
            }
            set
            {
                _Visualizacoes = value;
            }
        }
        public long Classificacao
        {
            get
            {
                return _Classificacao;
            }
            set
            {
                _Classificacao = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public Filme()
        {
            Nome = "";
            Ano = "";
            Duracao = "";
            Diretor = new Diretor();
            Escritor = new Escritor();
        }
        public int Create()
        {

            return FilmeDAL.Create(this);
        }
        public static List<Filme> ReadAll()
        {
            return FilmeDAL.ReadAll();
        }
        public Byte[] ReadFoto()
        {
            return FilmeDAL.ReadFoto(this);
        }
        public static List<Filme> ReadAllJoin()
        {
            return FilmeDAL.ReadAllJoin();
        }
        public ObservableCollection<Ator> ReadAllAtores()
        {
            return FilmeDAL.ReadAllAtores(this.Idfilme);
        }
        public List<Genero> ReadAllGeneros()
        {
            return FilmeDAL.ReadAllGeneros(this.Idfilme);
        }

        public int Update()
        {
            return FilmeDAL.Update(this);
        }
        public int UpdateFoto()
        {
            return FilmeDAL.UpdateFoto(this);
        }

        public int Delete()
        {
            return FilmeDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return FilmeDAL.CreateTable();
        }
        public void Onchanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));

        }
        public static int ReSeed(int number)
        {
            return FilmeDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Filme> collection)
        {
            return FilmeDAL.CreateFromObservableCollection(collection);
        }
        
    }
}





















