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
            if (GestaoDeUtilizadoresViewModel.Utilizadores != null)
            {
                viewUtilizadores.ItemsSource = GestaoDeUtilizadoresViewModel.Utilizadores;
            }
        }

        private void Adicionar_Linha_Botao(object sender, RoutedEventArgs e)
        {
            GestaoDeUtilizadoresViewModel.AddLinha();
        }

        private async void Eliminar_Utilizadores_Botao(object sender, RoutedEventArgs e)
        {
            object utilizador = viewUtilizadores.SelectedItem;
            if (utilizador == null)
            {
                MessageDialog select = new MessageDialog("Tem que selecionar alguma linha para remover");
                await select.ShowAsync();
                return;
            }
            if (!GestaoDeUtilizadoresViewModel.DeleteUtilizadores(utilizador)) 
            {
                MessageDialog retorno = new MessageDialog("A Operação falhou");
                await retorno.ShowAsync();
            }
            
        }

        


        private void viewUtilizadores_RowEditEnding(object sender, Microsoft.Toolkit.Uwp.UI.Controls.DataGridRowEditEndingEventArgs e)
        {
            object utilizador = viewUtilizadores.SelectedItem;
            if (!GestaoDeUtilizadoresViewModel.UpdateUtilizadores(utilizador))
            {
                MessageDialog message = new MessageDialog("A linha não foi editada");
            }
        }

        /*private void Page_Loading(FrameworkElement sender, object args)
        {
            GestaoDeUtilizadoresViewModel.CheckWhite();
        }*/
    }

}