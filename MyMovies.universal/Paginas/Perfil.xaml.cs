﻿using System;
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
using MyMovies.BL;
using MyMovies.universal;
using MyMovies;

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
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (EMAIL.Text != "") {
                MainPage.current_user.Email = EMAIL.Text;
            }
            if (NOME.Text != "")
            {
                MainPage.current_user.Nome = NOME.Text;
            }

            if (EMAIL.Text != "" || NOME.Text != "" || PasswordBox.Password != "")
            {
                if (PasswordBox.Password == PasswordBox_2.Password && PasswordBox.Password != "")
                {
                    MainPage.current_user.Password = PasswordBox.Password;
                }
                else
                {
                    if (PasswordBox.Password == PasswordBox_2.Password) { 
                    MessageDialog message = new MessageDialog("As suas passwords não são iguais");
                    await message.ShowAsync();
                    }
                }
                MainPage.current_user.Update();
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
