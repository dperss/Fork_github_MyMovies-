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
using Windows.System;
using Windows.Storage;
using System.Threading.Tasks;
using Windows.Storage.Pickers;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GestaoDeFilmes : Page
    {
        bool picturesRead = false;
        bool generos_atoresRead = false;
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
                return;
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

        private async void Foto_Button_Click(object sender, RoutedEventArgs e)
        {
            StorageFile file = await GestaoDeFilmesViewModel.OpenLocalFile(".jpg",".png");
            await GestaoDeFilmesViewModel.UpdateFoto(file);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!picturesRead)
            {
                GestaoDeFilmesViewModel.ReadFotos();
                picturesRead = true;
            }
            if (!generos_atoresRead)
            {
                GestaoDeFilmesViewModel.ReadAtores();
                GestaoDeFilmesViewModel.ReadGeneros();
                generos_atoresRead = true;
            }
            template_column.Visibility = Visibility.Visible;
            Generos_column.Visibility = Visibility.Visible;
            Elenco_column.Visibility = Visibility.Visible;

        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            template_column.Visibility = Visibility.Collapsed;
            Generos_column.Visibility = Visibility.Collapsed;
            Elenco_column.Visibility = Visibility.Collapsed;
        }

        private void ComboBox_SelectionChanged_Diretor(object sender, SelectionChangedEventArgs e)
        {

        }


    }
}
