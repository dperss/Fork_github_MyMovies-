﻿using System;
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
using System.Threading.Tasks;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {

        GestaoDeUtilizadoresViewModel GestaoDeUtilizadoresViewModel = new GestaoDeUtilizadoresViewModel();

        public Login()
        {

            this.InitializeComponent();

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await LoginMethod();
        }


        private void Button_registar(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Registo));
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.ChangeNvSelection("Registo_Page");
        }

        private async void EmailTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                await LoginMethod();
            }
        }

        private async void PasswordBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                await LoginMethod(); 
            }
        }

        private async Task LoginMethod()
        {
                Utilizador u = new Utilizador();
                u.Email = EmailTextBox.Text;
                u.Password = PasswordBox.Password;
                if (u.Password == "" || u.Email == "")
                {
                    MessageDialog message = new MessageDialog("Tem que preencher os dois campos");
                    await message.ShowAsync();
                    return;
                }
                u = GestaoDeUtilizadoresViewModel.Login(u);
                if (u != null)
                {
                    MainPage mainPage = MainPage.GetCurrent();
                    App.user = true;
                    App.utilizador = u;
                    mainPage.LoginNvVisibility(u);
                    mainPage.NavigateHome();
                }
                else
                {
                    MessageDialog message = new MessageDialog("O seu email ou password estão incorretos");
                    await message.ShowAsync();
                }
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
    }
}
