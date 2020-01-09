using MyMovies.BL;
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
    public sealed partial class Pagina_Filme : Page
    {
        Filme Filme { get; set; }

        Avaliacao_comentario Avaliacao_comentario;

        bool Avaliacao_comentario_existe = false;

        ObservableCollection<Avaliacao_comentario> comentarios { get; set; }
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
            if (blist != null)
            {
               foreach (Biblioteca bib in blist)
               {
                    if (bib.Categoria == Categoria.favorito)
                        favorito.IsChecked = true;
                    if (bib.Categoria == Categoria.para_ver)
                        para_ver.IsChecked = true;
                    if (bib.Categoria == Categoria.visto)
                        visto.IsChecked = true;
                }
            }
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Filme = e.Parameter as Filme;
            Filme.ReadFoto();
            Filme.ReadAllAtores();
            Filme.ReadAllGeneros();
            Avaliacao_comentario ac = new Avaliacao_comentario();
            ac.Idfilme = Filme.Idfilme;
            if (App.user == true)
            {
                textbox_comentario.Visibility = Visibility.Visible;
                CheckButtonState();
                ac.Idutilizador = App.utilizador.Idutilizador;
                Avaliacao_comentario = ac.ReadUtilizadorFilme();
                if (Avaliacao_comentario == null)
                {
                    Avaliacao_comentario.CreateTable();
                    
                }else
                {
                    Classificacao.Value = Avaliacao_comentario.Avaliacao;
                    Avaliacao_comentario_existe = true;
                }
            }
            List<Avaliacao_comentario> commentslist = ac.ReadAllComentariosFilme();
            if (commentslist != null)
            {
                comentarios = new ObservableCollection<Avaliacao_comentario>(commentslist);
                if(App.user == true)
                {
                    foreach(Avaliacao_comentario x in comentarios)
                    {
                        if(x.Idutilizador == App.utilizador.Idutilizador)
                        {
                            comentarios.Remove(x);
                            textbox_comentario.Visibility = Visibility.Collapsed;
                            textblock_jacomentou.Visibility = Visibility.Visible;
                            ListView_CommentUser.Visibility = Visibility.Visible;
                            Botao_EliminarComentario.Visibility = Visibility.Visible;
                            break;
                        }
                    }
                }
                textblock_comentario.Visibility = Visibility.Visible;
            }
            else
                comentarios = new ObservableCollection<Avaliacao_comentario>();
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

        private void Classificacao_ValueChanged(RatingControl sender, object args)
        {
            RatingControl ratingControl = sender as RatingControl;
            int valorNovo = (int)ratingControl.Value;
            if (valorNovo == -1)
                valorNovo = 0;
            if (Avaliacao_comentario != null)
            {
                Filme.Classificacao = Filme.Classificacao - Avaliacao_comentario.Avaliacao + valorNovo;
                Avaliacao_comentario.Avaliacao = valorNovo;
                Avaliacao_comentario.UpdateAvaliacao();
                Filme.UpdateClassificacao();
            }
            else
            {
                Avaliacao_comentario = new Avaliacao_comentario();
                Avaliacao_comentario.Idfilme = Filme.Idfilme;
                Avaliacao_comentario.Idutilizador = App.utilizador.Idutilizador;
                Avaliacao_comentario.Avaliacao = valorNovo;
                Filme.Classificacao += valorNovo;
                Avaliacao_comentario.Create();
                Filme.UpdateClassificacao();
            }
        }

        private void Button_Click_EliminarComentario(object sender, RoutedEventArgs e)
        {
            Avaliacao_comentario.Comentario = "";
            Avaliacao_comentario.UpdateComentario();
            textbox_comentario.Visibility = Visibility.Visible;
            Botao_EliminarComentario.Visibility = Visibility.Collapsed;
            ListView_CommentUser.Visibility = Visibility.Collapsed;
            textblock_jacomentou.Visibility = Visibility.Collapsed;
        }

        private void textbox_comentario_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key == Windows.System.VirtualKey.Enter)
            {
                TextBox textBox = sender as TextBox;
                if (textBox.Text == "")
                    return;
                if (Avaliacao_comentario == null)
                {
                    Avaliacao_comentario = new Avaliacao_comentario();
                    Avaliacao_comentario.Idutilizador = App.utilizador.Idutilizador;
                    Avaliacao_comentario.Idfilme = Filme.Idfilme;
                }
                Avaliacao_comentario.Comentario = textBox.Text;
                if (Avaliacao_comentario_existe)
                {
                    Avaliacao_comentario.UpdateComentario();
                }
                else
                {
                    if (Avaliacao_comentario.Create() != 1)
                    {
                        Avaliacao_comentario.CreateTable();
                        Avaliacao_comentario.Create();
                    }
                }
                textbox_comentario.Visibility = Visibility.Collapsed;
                ListView_CommentUser.Visibility = Visibility.Visible;
                Botao_EliminarComentario.Visibility = Visibility.Visible;
                textblock_jacomentou.Visibility = Visibility.Visible;
                this.Bindings.Update();
            }
        }
        
    }
}
