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
using MyMovies.BL;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GestaoDeFilmes : Page
    {
        GestaoDeFilmesViewModel GestaoDeFilmesViewModel { get; set; }   
        public GestaoDeFilmes()
        {
            this.InitializeComponent();
            GestaoDeFilmesViewModel = new GestaoDeFilmesViewModel();
        }

        private async void Adicionar_Filmes_Botao(object sender, RoutedEventArgs e)
        {
            if (!GestaoDeFilmesViewModel.Add_Linha())
            {
                MessageDialog message = new MessageDialog("O Filme não foi adicionado");
                await message.ShowAsync();
            }
            
        }

        private async void Eliminar_Filmes_Botao(object sender, RoutedEventArgs e)
        {
            if(viewFilmes.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Tem que selecionar algum Filme para remover");
                await message.ShowAsync();
            }
            if (!GestaoDeFilmesViewModel.DeleteFilme())
            {
                MessageDialog error = new MessageDialog("O Filme não foi removido");
                await error.ShowAsync();
            }
        }

        private void viewFilmes_RowEditEnded(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            GestaoDeFilmesViewModel.UpdateFilme();
        }

        private void viewFilmes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestaoDeFilmesViewModel.SelectedFilme = viewFilmes.SelectedItem as Filme;
        }
    }
}
