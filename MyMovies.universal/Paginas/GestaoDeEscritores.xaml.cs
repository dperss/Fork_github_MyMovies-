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
    public sealed partial class GestaoDeEscritores : Page
    {
        GestaoDeEscritoresViewModel GestaoDeEscritoresViewModel { get; set; }
        public GestaoDeEscritores()
        {
            this.InitializeComponent();
            GestaoDeEscritoresViewModel = new GestaoDeEscritoresViewModel();
        }
        private async void Adicionar_Escritores_Botao(object sender, RoutedEventArgs e)
        {
            if (!GestaoDeEscritoresViewModel.Add_Linha())
            {
                MessageDialog message = new MessageDialog("O Escritor não foi adicionado");
                await message.ShowAsync();
            }
        }

        private async void Eliminar_Escritores_Botao(object sender, RoutedEventArgs e)
        {
            if (viewEscritores.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Tem que selecionar algum Escritor para remover");
                await message.ShowAsync();
                return;
            }
            int ret = GestaoDeEscritoresViewModel.DeleteEscritor();
            if(ret == 547)
            {
                MessageDialog error = new MessageDialog("O Escritor não foi removido porque há conflito de Foreign Keys");
                await error.ShowAsync();
                return;
            }

            if (ret != 1)
            {
                MessageDialog error = new MessageDialog("O Escritor não foi removido");
                await error.ShowAsync();
            }
        }

        private void viewEscritores_RowEditEnded(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            GestaoDeEscritoresViewModel.UpdateEscritor();
        }

        private void viewEscritores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestaoDeEscritoresViewModel.SelectedEscritor = viewEscritores.SelectedItem as Escritor;
        }
    }
}
