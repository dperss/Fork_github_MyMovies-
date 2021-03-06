﻿using System;
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
using MyMovies.universal.ViewModel;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Principal : Page
    {
        //GestaoDeFilmesViewModel gestaoDeFilmesViewModel { get; set; }
        public ObservableCollection<Filme> Recentes { 
            get
            {
                return App.Recentes;
            }
            set
            {
                App.Recentes = value;
            }
        }
        public static ObservableCollection<Filme> MaisVistos 
        {
            get
            {
                return App.MaisVistos;
            }
            set
            {
                App.MaisVistos = value;
            }
        }
        public static ObservableCollection<Filme> MelhorClassificados 
        {
            get
            {
                return App.MelhorClassificados;
            }
            set
            {
                App.MelhorClassificados = value;
            }
        }

        public Principal()
        {
            this.InitializeComponent();
            if (App.user == true)
            {
                Botao_login_sem_user.Visibility = Visibility.Collapsed;
                Botao_registo.Visibility = Visibility.Collapsed;
                Botao_login.Visibility = Visibility.Visible;
            }
            GestaoDeFilmesViewModel gestaoDeFilmesViewModel = new GestaoDeFilmesViewModel();
            gestaoDeFilmesViewModel.ReadFotos();
            App.Filmes = gestaoDeFilmesViewModel.Filmes;
            App.getRecentes();
            App.getMaisVistos();
            App.getMelhorClassificados();
        }

        private void Botao_registo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Registo));
            MainPage mainPage  = MainPage.GetCurrent();
            mainPage.ChangeNvSelection("Registo_Page");
        }

        private void Botao_Biblioteca_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Pagina_Biblioteca));
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.ChangeNvSelection("Biblioteca_Page");
        }

        private void Botao_Perfil_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Perfil));
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.ChangeNvSelection("Perfil_Page");
        }

        private void Botao_login_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            App.user = false;
            App.NavigateMainPage();
            
        }

        private void Botao_login_sem_user_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Paginas.Login));
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.ChangeNvSelection("Login_Page");
        }

        private async void AutoSuggestBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
                if(autoSuggestBox.Text == "")
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

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
            if (autoSuggestBox.Text == "")
            {
                return;
            }
            List<Filme> flist = App.Pesquisar(autoSuggestBox.Text);
            if(flist.Count == 0)
            {
                MessageDialog message = new MessageDialog("Não foram encontrados quaisquer resultados");
                await message.ShowAsync();
                return;
            }
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePesquisa(flist);
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot pivot = sender as Pivot;
            PivotItem pivotItem = pivot.SelectedItem as PivotItem;
            if(pivotItem.Tag.ToString() == "Pivot_Recentes")
            {
                GridView_Filmes.ItemsSource = Recentes;
            }
            if(pivotItem.Tag.ToString() == "Pivot_MaisVistos")
            {
                GridView_Filmes.ItemsSource = MaisVistos;
            }
            if(pivotItem.Tag.ToString() == "Pivot_MelhorClassificados")
            {
                GridView_Filmes.ItemsSource = MelhorClassificados;
            }
        }

        private void Filmes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Filme f = e.ClickedItem as Filme;
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePaginaFilme(f);
        }
    }
}
