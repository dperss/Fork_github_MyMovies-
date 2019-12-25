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
            nome.Text = App.utilizador.Nome;
            email.Text = App.utilizador.Email;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(email.Text==App.utilizador.Email && nome.Text==App.utilizador.Nome && PasswordBox.Password=="" && PasswordBox_2.Password=="")
            {
                MessageDialog message = new MessageDialog("Não alterou os dados");
                await message.ShowAsync();
                return;
            }
            else
            {
                App.utilizador.Email = email.Text;
                App.utilizador.Nome = nome.Text;
                if (PasswordBox.Password == "" && PasswordBox_2.Password=="")
                {
                    if (App.utilizador.Update() == 1)
                    {
                        MessageDialog message = new MessageDialog("Os seus dados foram alterados");
                        await message.ShowAsync();
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Não foi possível alterar os seus dados");
                        await message.ShowAsync();
                    }
                    return;
                }
                if(PasswordBox.Password == PasswordBox_2.Password && PasswordBox.Password != "")
                {
                    App.utilizador.Password = PasswordBox.Password;
                    if (App.utilizador.Update() == 1)
                    {
                        MessageDialog message = new MessageDialog("Os seus dados foram alterados");
                        await message.ShowAsync();
                    }
                    else
                    {
                        MessageDialog message = new MessageDialog("Não foi possível alterar os seus dados");
                        await message.ShowAsync();
                    }
                    return;
                }
            }
            

        }


    }




}
