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
using Windows.UI.Popups;
using System.Collections;
using MyMovies.BL;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GestaoDeUtilizadores : Page
    {
        GestaoDeUtilizadoresViewModel GestaoDeUtilizadoresViewModel { get; set; }


        public GestaoDeUtilizadores()
        {
            this.InitializeComponent();
            GestaoDeUtilizadoresViewModel = new GestaoDeUtilizadoresViewModel();
        }

        private void viewUtilizadores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GestaoDeUtilizadoresViewModel.SelectedUtilizador = viewUtilizadores.SelectedItem as Utilizador;
            //FrameworkElement a = Tipo.GetCellContent(viewUtilizadores.SelectedItem); não consigo editar o valor do Tipo
        }

        private void viewUtilizadores_RowEditEnded(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndedEventArgs e)
        {
            GestaoDeUtilizadoresViewModel.UpdateUtilizador();
        }

        private async void Add_Utilizador_Click(object sender, RoutedEventArgs e)
        {
            if (!GestaoDeUtilizadoresViewModel.Add_Linha())
            {
                MessageDialog message = new MessageDialog("O Utilizador não foi adicionado");
                await message.ShowAsync();
            }
        }

        private async void Eliminar_Utilizador_Click(object sender, RoutedEventArgs e)
        {
            if (viewUtilizadores.SelectedItem == null)
            {
                MessageDialog message = new MessageDialog("Tem que selecionar algum Utilizador para remover");
                await message.ShowAsync();
            }
            if (!GestaoDeUtilizadoresViewModel.DeleteUtilizador())
            {
                MessageDialog error = new MessageDialog("O Utilizador não foi removido");
                await error.ShowAsync();
            }
        }


    }

}