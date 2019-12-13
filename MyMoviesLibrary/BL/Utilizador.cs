using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MyMovies.DAL;

public enum Tipo { admin = 0, user = 1 };

namespace MyMovies.BL
{
    public class Utilizador : INotifyPropertyChanged
    {
        int _Idutilizador;
        string _Nome;
        string _Email;
        string _Password;
        Tipo _Tipo;
        public int Idutilizador { 
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
        public string Nome
        {
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
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
                Onchanged("Email");
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                Onchanged("Password");
            }
        }
        public Tipo Tipo
        {
            get
            {
                return _Tipo;
            }
            set
            {
                _Tipo = value;
                Onchanged("Tipo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Utilizador() {
            Nome = "";
            Email = "";
            Password = "";
            Tipo = Tipo.user;
        }
        public Utilizador(int idutilizador, string nome, string email, string password, string user_adm)
        {
            this.Idutilizador = idutilizador;
            this.Nome = nome;
            this.Email = email;
            this.Password = password;
            if (user_adm.Equals("admin"))
                this.Tipo = Tipo.admin;
            else
                this.Tipo = Tipo.user;
        }
        public override String ToString()
        {
            return $"Id: {Idutilizador}" +
                $"\nNome: {Nome}" +
                $"\nEmail: {Email}" +
                $"\nPassword: {Password}" +
                $"\nTipo: {Tipo}";
        }
        public int Create()
        {
            return UtilizadorDAL.Create(this);
        }
        public List<Utilizador> ReadNome()
        {
            return UtilizadorDAL.ReadNome(this);
        }
        public Utilizador ReadId()
        {
            return UtilizadorDAL.ReadId(this);
        }
        public Utilizador ReadEmail()
        {
            return UtilizadorDAL.ReadEmail(this);
        }
        public static List<Utilizador> ReadAll()
        {
            return UtilizadorDAL.ReadAll();
        }
        public int Update()
        {
            return UtilizadorDAL.Update(this);
        }
        public int Delete()
        {
            return UtilizadorDAL.Delete(this);
        }
        public static bool CreateTable()
        {
            return UtilizadorDAL.CreateTable();
        }
        public void Onchanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
                if (name == "Tipo")
                    this.Update();
            }

        }
        public static int ReSeed(int number)
        {
            return UtilizadorDAL.ReSeed(number);
        }
        public static bool CreateFromObservableCollection(ObservableCollection<Utilizador> collection)
        {
            return UtilizadorDAL.CreateFromObservableCollection(collection);
        }
    }
}
