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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyMovies.universal
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void nv_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(Paginas.Definicoes));
            }
            else
            {
                TextBlock ItemContent = args.InvokedItem as TextBlock;
                if (ItemContent != null)
                {
                    switch (ItemContent.Tag)
                    {
                        case "Nav_Home":
                            contentFrame.Navigate(typeof(Paginas.Principal));
                            break;
                        case "Nav_Login":
                            contentFrame.Navigate(typeof(Paginas.Login));
                            break;
                        case "Nav_Registo":
                            contentFrame.Navigate(typeof(Paginas.Registo));
                            break;
                        case "Nav_Gestao_de_utilizadores":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeUtilizadores));
                            break;
                        case "Nav_Gestao_de_filmes":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeFilmes));
                            break;
                        case "Nav_Gestao_de_atores":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeAtores));
                            break;

                    }
                }

            }
        }

        private void nv_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

        }

        private void nv_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in nv.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home_Page")
                {
                    nv.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(Paginas.Principal));
        }




    }
}

