using MyMovies.BL;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Pagina_Filme : Page
    {
        Filme Filme { get; set; }
        public Pagina_Filme()
        {
            this.InitializeComponent();
            Visibilidade();
            
        }

        public void CheckButtonState()
        {
            Biblioteca b = new Biblioteca();
            b.Filme_idfilme = Filme.Idfilme;
            b.Utilizador_idutilizador = App.utilizador.Idutilizador;
            List<Biblioteca> blist = b.ReadUtilizadorFilme();
            foreach(Biblioteca bib in blist)
            {
                if (bib.Categoria == Categoria.favorito)
                    favorito.IsChecked = true;
                if (bib.Categoria == Categoria.para_ver)
                    para_ver.IsChecked = true;
                if (bib.Categoria == Categoria.visto)
                    visto.IsChecked = true;
            }
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Filme = e.Parameter as Filme;
            Filme.ReadFoto();
            Filme.ReadAllAtores();
            Filme.ReadAllGeneros();
            if(App.user == true)
                CheckButtonState();
            base.OnNavigatedTo(e);
        }
        public void Visibilidade()
        {
            if(App.user == true)
            {
                para_ver.Visibility = Visibility.Visible;
                visto.Visibility = Visibility.Visible;
                favorito.Visibility = Visibility.Visible;
                Classificacao.Visibility = Visibility.Visible;
            }
        }

        private void favorito_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            Biblioteca b = new Biblioteca();
            if (toggleButton.IsChecked == true)
            {
                b.Categoria = Categoria.favorito;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Create();
            }
            if(toggleButton.IsChecked == false)
            {
                b.Categoria = Categoria.favorito;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Delete();
            }
        }

        private void visto_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            Biblioteca b = new Biblioteca();
            if (toggleButton.IsChecked == true)
            {
                b.Categoria = Categoria.visto;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Create();
                Filme.Visualizacoes += 1;
                Filme.UpdateVisualizacoes();
            }
            if (toggleButton.IsChecked == false)
            {
                b.Categoria = Categoria.visto;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Delete();
                Filme.Visualizacoes -= 1;
                Filme.UpdateVisualizacoes();
            }
        }

        private void para_ver_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;
            Biblioteca b = new Biblioteca();
            if (toggleButton.IsChecked == true)
            {
                b.Categoria = Categoria.para_ver;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Create();
            }
            if (toggleButton.IsChecked == false)
            {
                b.Categoria = Categoria.para_ver;
                b.Filme_idfilme = Filme.Idfilme;
                b.Utilizador_idutilizador = App.utilizador.Idutilizador;
                b.Delete();
            }
        }
    }
}
