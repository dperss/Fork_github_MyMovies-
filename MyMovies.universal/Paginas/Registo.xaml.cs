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
using MyMovies.universal.ViewModel;
using Windows.UI.Popups;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registo : Page
    {
        GestaoDeUtilizadoresViewModel GestaoDeUtilizadoresViewModel { get; set; }
        public Registo()
        {
            this.InitializeComponent();
            GestaoDeUtilizadoresViewModel = new GestaoDeUtilizadoresViewModel();
        }

        private void Button_Submeter(object sender, RoutedEventArgs e)//este codigo devia de estar no gestaodeutilizadoresviewmodel
        {
            Registar();
        }

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
            if (autoSuggestBox.Text == "")
            {
                return;
            }
            List<Filme> flist = App.Pesquisar(autoSuggestBox.Text);
            if (flist.Count == 0)
            {
                MessageDialog message = new MessageDialog("Não foram encontrados quaisquer resultados");
                await message.ShowAsync();
                return;
            }
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePesquisa(flist);
        }

        private async void AutoSuggestBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
                if (autoSuggestBox.Text == "")
                {
                    return;
                }
                List<Filme> flist = App.Pesquisar(autoSuggestBox.Text);
                if (flist.Count == 0)
                {
                    MessageDialog message = new MessageDialog("Não foram encontrados quaisquer resultados");
                    await message.ShowAsync();
                    return;
                }
                MainPage mainPage = MainPage.GetCurrent();
                mainPage.NavigatePesquisa(flist);
            }
        }

        private void EmailTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                Registar();
            }
        }

        private void NomeTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Registar();
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                Registar();
            }
        }
        public async void Registar()
        {
            Utilizador u = new Utilizador();
            u.Email = EmailTextBox.Text;//o acesso às textboxes tem que ser aqui
            u.Nome = NomeTextBox.Text;
            u.Password = PasswordBox.Password;
            u.Tipo = Tipo.admin;
            if (!GestaoDeUtilizadoresViewModel.CreateUtilizador(u))
            {
                MessageDialog message = new MessageDialog("Não foi possível criar a sua conta");
                await message.ShowAsync();
            }
            else
            {
                App.NavigateMainPage();

            }
        }
    }
}
