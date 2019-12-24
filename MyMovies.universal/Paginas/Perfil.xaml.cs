using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Popups;
using Windows.UI.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Security.Permissions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.Paginas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Perfil : Page
    {


        public Perfil()
        {
            this.InitializeComponent();

            NOME.PlaceholderText = App.utilizador.Nome;
            EMAIL.PlaceholderText = App.utilizador.Email;
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {


            if (EMAIL.Text != "")
            {
                App.utilizador.Email = EMAIL.Text;
            }
            if (NOME.Text != "")
            {
                App.utilizador.Nome = NOME.Text;
            }

            if (EMAIL.Text != "" || NOME.Text != "" || PasswordBox.Password != "")
            {
                if (PasswordBox.Password == PasswordBox_2.Password && PasswordBox.Password != "")
                {
                    App.utilizador.Password = PasswordBox.Password;
                }
                else
                {
                    if (PasswordBox.Password == PasswordBox_2.Password)
                    {
                        MessageDialog message = new MessageDialog("As suas passwords não são iguais");
                        await message.ShowAsync();
                    }
                }
                App.utilizador.Update();
                MessageDialog message_2 = new MessageDialog("As mudanças foram feitas");
                await message_2.ShowAsync();
                this.Frame.Navigate(typeof(Paginas.Principal));
            }
            else
            {
                MessageDialog message_2 = new MessageDialog("Não a nada para mudar");
                await message_2.ShowAsync();
                this.Frame.Navigate(typeof(Paginas.Perfil));
            }
            
        }


    }




}
