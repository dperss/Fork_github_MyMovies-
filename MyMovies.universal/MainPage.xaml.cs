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
using MyMovies.BL;
using MyMovies.universal;
using MyMovies;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyMovies.universal
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage() {
            
            this.InitializeComponent();
        }
        

        private void nv_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(Paginas.Definicoes));
            }
            else
            {
                string SelectedItem = args.SelectedItemContainer.Tag.ToString();
                if (SelectedItem != null)
                {
                    switch (SelectedItem)
                    {
                        case "Home_Page":
                            contentFrame.Navigate(typeof(Paginas.Principal));
                            break;
                        case "Gestao_de_utilizadores_Page":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeUtilizadores));
                            break;
                        case "Gestao_de_filmes_Page":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeFilmes));
                            break;
                        case "Gestao_de_atores_Page":
                            contentFrame.Navigate(typeof(Paginas.GestaoDeAtores));
                            break;
                        case "Login_Page":
                            contentFrame.Navigate(typeof(Paginas.Login));
                            break;
                        case "Registo_Page":
                            contentFrame.Navigate(typeof(Paginas.Registo));
                            break;
                        case "Perfil_Page":
                            contentFrame.Navigate(typeof(Paginas.Perfil));
                            break;
                        case "Biblioteca_Page":
                            contentFrame.Navigate(typeof(Paginas.Biblioteca));
                            break;
                    }
                }
                
            }
                    
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

        private void nv_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if(contentFrame.CanGoBack)
                contentFrame.GoBack();
           
        }
        public void LoginNvVisibility(Utilizador u)
        {
            nv_item_Login_Page.Visibility = Visibility.Collapsed;
            nv_item_Registo_Page.Visibility = Visibility.Collapsed;
            if (u.Tipo== Tipo.user)
            {
                nv_item_gestao_atores.Visibility = Visibility.Collapsed;
                nv_item_gestao_filmes.Visibility = Visibility.Collapsed;
                nv_item_gestao_utilizadores.Visibility = Visibility.Collapsed;
                nv_item_Biblioteca_Page.Visibility = Visibility.Visible;
                nv_item_Perfil_Page.Visibility = Visibility.Visible;
            }
            if(u.Tipo == Tipo.admin)
            {
                nv_item_Biblioteca_Page.Visibility = Visibility.Visible;
                nv_item_Perfil_Page.Visibility = Visibility.Visible;
                nv_item_gestao_atores.Visibility = Visibility.Visible;
                nv_item_gestao_filmes.Visibility = Visibility.Visible;
                nv_item_gestao_utilizadores.Visibility = Visibility.Visible;
            }
        }

        public static MainPage GetCurrent()
        {
            Frame appFrame = Window.Current.Content as Frame;
            return appFrame.Content as MainPage;
        }

        public void NavigateHome()
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

        public void ChangeNvSelection(string selection)
        {
            foreach (NavigationViewItemBase item in nv.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == selection)
                {
                    nv.SelectedItem = item;
                    break;
                }
            }
        }


    }
}

