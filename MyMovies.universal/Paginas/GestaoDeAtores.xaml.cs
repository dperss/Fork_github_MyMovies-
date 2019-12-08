using MyMovies.universal.ViewModel;
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
    public sealed partial class GestaoDeAtores : Page
    {
        GestaoDeAtoresViewModel GestaoDeAtoresViewModel { get; set; }
        public GestaoDeAtores()
        {
            this.InitializeComponent();
            GestaoDeAtoresViewModel = new GestaoDeAtoresViewModel();
        }

        private void Adicionar_Atores_Botao(object sender, RoutedEventArgs e)
        {

        }

        private void Eliminar_Atores_Botao(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
