﻿#pragma checksum "C:\Curso\DAI\mymovies\MyMovies.universal\Paginas\Principal.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "880849ED8A146CD18FAD5CE6809DAC57"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMovies.universal.Paginas
{
    partial class Principal : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Paginas\Principal.xaml line 62
                {
                    this.Filmes = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 4: // Paginas\Principal.xaml line 36
                {
                    this.Botao_login = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Botao_login).Click += this.Botao_login_Click;
                }
                break;
            case 5: // Paginas\Principal.xaml line 47
                {
                    this.Botao_login_sem_user = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Botao_login_sem_user).Click += this.Botao_login_sem_user_Click;
                }
                break;
            case 6: // Paginas\Principal.xaml line 40
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element6 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element6).Click += this.Botao_Perfil_Click;
                }
                break;
            case 7: // Paginas\Principal.xaml line 41
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element7 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element7).Click += this.Botao_Biblioteca_Click;
                }
                break;
            case 8: // Paginas\Principal.xaml line 42
                {
                    this.LogOut = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.LogOut).Click += this.LogOut_Click;
                }
                break;
            case 9: // Paginas\Principal.xaml line 31
                {
                    this.Botao_registo = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.Botao_registo).Click += this.Botao_registo_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

