using MyMovies.BL;
using MyMovies.universal.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GestaoDeDiretores : Page
    {
        GestaoDeDiretoresViewModel GestaoDeDiretoresViewModel { get; set; }
        public GestaoDeDiretores()
        {
            this.InitializeComponent();
            GestaoDeDiretoresViewModel = new GestaoDeDiretoresViewModel();
        }
        private async void Adicionar_Diretores_Botao(object sender, RoutedEventArgs e)
        {
            if (!GestaoDeDiretoresViewModel.Add_Linha())
            {
                MessageDialog message = new MessageDialog("O Diretor não foi adicionado");
                await message.ShowAsync();
            }
        }

        private async void Eliminar_Diretores_Botao(object sender, RoutedEventArgs e)
        {
            if (viewDiretores.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Tem que selecionar algum Diretor para remover");
                await message.ShowAsync();
                return;
            }
            int ret = GestaoDeDiretoresViewModel.DeleteDiretor();
            if (ret == 547)
            {
                MessageDialog error = new MessageDialog("O Diretor não foi removido porque há conflito de Foreign Keys");
                await error.ShowAsync();
                return;
            }

            if (ret != 1)
            {
                MessageDialog error = new MessageDialog("O Diretor não foi removido");
                await error.ShowAsync();
            }
        }

        private void viewDiretores_RowEditEnded(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            GestaoDeDiretoresViewModel.UpdateDiretor();
        }

        private void viewDiretores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestaoDeDiretoresViewModel.SelectedDiretor = viewDiretores.SelectedItem as Diretor;
        }
    }
}
