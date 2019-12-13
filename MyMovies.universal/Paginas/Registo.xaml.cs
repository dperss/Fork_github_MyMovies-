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
using MyMovies.BL;
using MyMovies.universal.ViewModel;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registo : Page
    {
        GestaoDeUtilizadoresViewModel GestaoDeUtilizadoresViewModel { get; set; }
        public Registo()
        {
            this.InitializeComponent();
            GestaoDeUtilizadoresViewModel = new GestaoDeUtilizadoresViewModel();
        }

        private void Button_Submeter(object sender, RoutedEventArgs e)//este codigo devia de estar no gestaodeutilizadoresviewmodel
        {
          
            Utilizador u = new Utilizador();
            u.Email = EmailTextBox.Text;//o acesso às textboxes tem que ser aqui
            u.Nome = NomeTextBox.Text;
            u.Password = PasswordBox.Password;
            u.Tipo = Tipo.user;
            GestaoDeUtilizadoresViewModel.CreateUtilizador(u);//como é que mostro mensagens de erro dependendo do return desta funcao?
            //levar para outra página
        }
    }
}
