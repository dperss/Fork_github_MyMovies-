using FilmesLibrary.DAL;
using System;
using System.Collections.Generic;
using System.Text;

public enum Tipo { admin = 0, user = 1 };

namespace FilmesLibrary.BL
{
    public class utilizador
    {
        public int Idutilizador { get; set; } = -1;
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Tipo Tipo { get; set; }

        public utilizador() { }
        public utilizador(int idutilizador, string nome, string email, string password, string user_adm)
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
        public static int Create(utilizador u)
        {
            return utilizadorDAL.Create(u);
        }
        public static List<utilizador> ReadNome(utilizador u)
        {
            return utilizadorDAL.ReadNome(u);
        }
        public static utilizador ReadId(utilizador u)
        {
            return utilizadorDAL.ReadId(u);
        }
        public static List<utilizador> ReadAll()
        {
            return utilizadorDAL.ReadAll();
        }
        public static int Update(utilizador u)
        {
            return utilizadorDAL.Update(u);
        }
        public static int Delete(utilizador u)
        {
            return utilizadorDAL.Delete(u);
        }
        public static bool CreateTable()
        {
            return utilizadorDAL.CreateTable();
        }
    }
}
