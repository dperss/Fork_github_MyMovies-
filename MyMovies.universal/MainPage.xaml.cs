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

        private void NavView_Loaded(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(typeof(Login));
            // you can also add items in code behind
            NavView.MenuItems.Add(new NavigationViewItemSeparator());
            NavView.MenuItems.Add(new NavigationViewItem()
            ); ;

            // set the initial SelectedItem 
            foreach (NavigationViewItemBase item in NavView.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Gestão_de_Atores")
                {
                    NavView.SelectedItem = item;
                    break;
                }
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {



            // find NavigationViewItem with Content that equals InvokedItem
            // var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            var item = args.InvokedItemContainer;
            NavView_Navigate(item);

        }

        private void NavView_Navigate(NavigationViewItemBase item)
        {
            switch (item.Tag)
            {
                case "Gestão_de_Atores":
                    myFrame.Navigate(typeof(Login));
                    break;

               /* case "Shop_Page":
                    myFrame.Navigate(typeof());
                    break;
                case "Cart_Page":
                    myFrame.Navigate(typeof());
                    break;
                case "message":
                    myFrame.Navigate(typeof());
                    break;*/


            }
        }

    }
}

