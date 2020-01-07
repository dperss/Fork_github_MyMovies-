using MyMovies.BL;
using MyMovies.universal.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagina_Biblioteca : Page
    {
        public GestaoDeFilmesViewModel gestaoDeFilmesViewModel { get; set; }
        public ObservableCollection<Filme> Favoritos { get; set; }
        public ObservableCollection<Filme> Para_Ver { get; set; }
        public ObservableCollection<Filme> Vistos { get; set; }
        public Pagina_Biblioteca()
        {
            this.InitializeComponent();
            gestaoDeFilmesViewModel = new GestaoDeFilmesViewModel();
            Favoritos = new ObservableCollection<Filme>();
            Para_Ver = new ObservableCollection<Filme>();
            Vistos = new ObservableCollection<Filme>();
            getFavoritos();
            getVistos();
            getPara_Ver();
        }

        public void getFavoritos()
        {
            Biblioteca b = new Biblioteca();
            b.Utilizador_idutilizador = App.utilizador.Idutilizador;
            List<Biblioteca> blist = b.ReadUtilizadorFavoritos();
            foreach(Biblioteca x in blist)
            {
                Favoritos.Add(gestaoDeFilmesViewModel.Filmes.FirstOrDefault(i => i.Idfilme == x.Filme_idfilme));
            }
            foreach(Filme f in Favoritos)
            {
                f.ReadFoto();
            }
        }
        public void getVistos()
        {
            Biblioteca b = new Biblioteca();
            b.Utilizador_idutilizador = App.utilizador.Idutilizador;
            List<Biblioteca> blist = b.ReadUtilizadorVistos();
            foreach (Biblioteca x in blist)
            {
                Vistos.Add(gestaoDeFilmesViewModel.Filmes.FirstOrDefault(i => i.Idfilme == x.Filme_idfilme));
            }
            foreach (Filme f in Vistos)
            {
                f.ReadFoto();
            }
        }
        public void getPara_Ver()
        {
            Biblioteca b = new Biblioteca();
            b.Utilizador_idutilizador = App.utilizador.Idutilizador;
            List<Biblioteca> blist = b.ReadUtilizadorPara_Ver();
            foreach (Biblioteca x in blist)
            {
                Para_Ver.Add(gestaoDeFilmesViewModel.Filmes.FirstOrDefault(i => i.Idfilme == x.Filme_idfilme));
            }
            foreach (Filme f in Para_Ver)
            {
                f.ReadFoto();
            }
        }

        private void GridView_Filmes_ItemClick(object sender, ItemClickEventArgs e)
        {
            Filme f = e.ClickedItem as Filme;
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePaginaFilme(f);
        }

        private void Pivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pivot pivot = sender as Pivot;
            PivotItem pivotItem = pivot.SelectedItem as PivotItem;
            if (pivotItem.Tag.ToString() == "Pivot_Favoritos")
            {
                GridView_Filmes.ItemsSource = Favoritos;
            }
            if (pivotItem.Tag.ToString() == "Pivot_Para_ver")
            {
                GridView_Filmes.ItemsSource = Para_Ver;
            }
            if (pivotItem.Tag.ToString() == "Pivot_Vistos")
            {
                GridView_Filmes.ItemsSource = Vistos;
            }
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
            if (autoSuggestBox.Text == "")
            {
                return;
            }
            List<Filme> flist = App.Pesquisar(autoSuggestBox.Text);
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePesquisa(flist);
        }

        private void AutoSuggestBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                AutoSuggestBox autoSuggestBox = sender as AutoSuggestBox;
                if (autoSuggestBox.Text == "")
                {
                    return;
                }
                List<Filme> flist = App.Pesquisar(autoSuggestBox.Text);
                MainPage mainPage = MainPage.GetCurrent();
                mainPage.NavigatePesquisa(flist);
            }
        }
    }
}
