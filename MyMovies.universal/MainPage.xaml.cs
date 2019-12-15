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
        public static Tipo Tipo { get; set; } = Tipo.user;

        public MainPage() {
            
            this.InitializeComponent();
        }
        private void nv_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            /*if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(Paginas.Definicoes));
            }
            else
            {
                TextBlock ItemContent = args.InvokedItem as TextBlock;
                if (ItemContent != null)
                {
                    if (Tipo == Tipo.admin)
                    {
                        nv_item_gestao_utilizadores.Visibility = Visibility.Visible;
                        nv_item_gestao_filmes.Visibility = Visibility.Visible;
                        nv_item_gestao_atores.Visibility = Visibility.Visible;
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
                    else
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
                            
                        }
                    }

                }

            }*/
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
                if(SelectedItem != null) {
                    if (Tipo == Tipo.admin)
                    {
                        nv_item_gestao_utilizadores.Visibility = Visibility.Visible;
                        nv_item_gestao_filmes.Visibility = Visibility.Visible;
                        nv_item_gestao_atores.Visibility = Visibility.Visible;
                        switch (SelectedItem)
                        {
                            case "Home_Page":
                                contentFrame.Navigate(typeof(Paginas.Principal));
                                break;
                            case "Login_Page":
                                contentFrame.Navigate(typeof(Paginas.Login));
                                break;
                            case "Registo_Page":
                                contentFrame.Navigate(typeof(Paginas.Registo));
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
                        }
                    }
                    else
                    {
                        switch (SelectedItem)
                        {
                            case "Home_Page":
                                contentFrame.Navigate(typeof(Paginas.Principal));
                                break;
                            case "Login_Page":
                                contentFrame.Navigate(typeof(Paginas.Login));
                                break;
                            case "Registo_Page":
                                contentFrame.Navigate(typeof(Paginas.Registo));
                                break;

                        }
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
       

    }
}

