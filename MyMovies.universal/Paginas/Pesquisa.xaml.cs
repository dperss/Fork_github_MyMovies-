using MyMovies.BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class Pesquisa : Page
    {
        public ObservableCollection<Filme> Filmes;
        public Pesquisa()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Filme> flist = e.Parameter as List<Filme>;
            Filmes = new ObservableCollection<Filme>(flist);
            foreach(Filme f in Filmes)
            {
                f.ReadFoto();
            }
            base.OnNavigatedTo(e);
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Filme f = e.ClickedItem as Filme;
            //App.NavigatePaginaFilme(f);
            MainPage mainPage = MainPage.GetCurrent();
            mainPage.NavigatePaginaFilme(f);
        }
    }
}
