using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyMovies.BL;
using MyMovies.universal;
using MyMovies;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
       

        public Principal()
        {
            
            this.InitializeComponent();
            if (MainPage.current_user.Idutilizador != 0)//Quando tem um user
            {
                Botao_login_sem_user.Visibility = Visibility.Collapsed;
                Botao_registo.Visibility = Visibility.Collapsed;
                Botao_login.Visibility = Visibility.Visible;
            }
            else//Quando não tem user
            {
                
            }
        }

        private void Botao_registo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Registo));
        }

        private void Botao_Biblioteca_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Biblioteca));
        }

        private void Botao_Perfil_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Perfil));
        }

        private void Botao_login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Utilizador c = new Utilizador();
            MainPage.current_user = c;
            this.Frame.Navigate(typeof(Paginas.Principal));
        }

        private void Botao_login_sem_user_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Login));
        }
    }
}
