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
using MyMovies.universal.ViewModel;
using Windows.UI.Popups;
using System.Collections;
using MyMovies.BL;
using MyMovies.universal;
using MyMovies;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        ViewModel.UserViewModel Log = new ViewModel.UserViewModel();
        ViewModel.GestaoDeUtilizadoresViewModel GestaoDeUtilizadoresViewModel = new ViewModel.GestaoDeUtilizadoresViewModel();

        public Login()
        {
            
            this.InitializeComponent();
            
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Utilizador u = new Utilizador();
            u.Email = EmailTextBox.Text;
            u.Password = PasswordBox.Password;
            Tuple<bool, Tipo> ret = GestaoDeUtilizadoresViewModel.Login(u);
            if (ret.Item1)
            {
                MainPage.Tipo = ret.Item2;
                //mudar item selecionado
                //dar refresh à navigation view
                this.Frame.Navigate(typeof(Paginas.Principal));
            }
            else
            {
                MessageDialog message = new MessageDialog("O seu email ou password estão incorretos");
                await message.ShowAsync();
            }
        }


        private void Button_registar(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Registo));
        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_SelectionChanged_2(object sender, RoutedEventArgs e)
        {

        }
    }

    
}
