using System;
using System.Collections.Generic;
using System.Text;
using MyMovies.DAL;

public enum Tipo { admin = 0, user = 1 };

namespace MyMovies.BL
{
    public class Utilizador
    {
        public int Idutilizador { get; set; } = -1;
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Tipo Tipo { get; set; }

        public Utilizador() { }
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
    }
}
