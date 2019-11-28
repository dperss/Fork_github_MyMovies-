using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyMovies.BL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registo : Page
    {
        public Registo()
        {
            this.InitializeComponent();
        }

        private void Button_Submeter(object sender, RoutedEventArgs e)//este codigo devia de estar no viewmodel
        {
            Utilizador u = new Utilizador();
            u.Email = EmailTextBox.Text;//o acesso às textboxes tem que ser aqui
            u.Nome = NomeTextBox.Text;
            u.Password = PasswordBox.Password;
            List<Utilizador> utilizadores = Utilizador.ReadAll();//usar auto incremento da base de dados, create table
            int maxid = 0;
            foreach (Utilizador x in utilizadores)
            {
                if (x.Email == u.Email)
                {
                    return;
                }
                if (x.Idutilizador > maxid)
                {
                    maxid = x.Idutilizador;
                }
            }
            u.Idutilizador = maxid + 1;
            u.Tipo = Tipo.user;
            Utilizador.Create(u);
        }
    }
}
