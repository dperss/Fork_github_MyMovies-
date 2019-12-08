using MyMovies.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Idfilme { //PERGUNTAR: porque que se usa uma variável privada e uma property publica? 
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

        public byte[] Foto { 
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

        public event PropertyChangedEventHandler PropertyChanged;

        public Filme()
        {
            Nome = "";
            Ano = "";
            Duracao = "";
        }
        public int Create()
        {

            return FilmeDAL.Create(this); //Este metodo vai ser estatico
        }
        public static List<Filme> ReadAll()
        {
            return FilmeDAL.ReadAll();
        }
        public int Update()
        {
            return FilmeDAL.Update(this);
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
    }
}





















