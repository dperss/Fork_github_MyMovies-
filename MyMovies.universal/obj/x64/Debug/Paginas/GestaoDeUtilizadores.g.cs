﻿#pragma checksum "C:\Users\ClaudiaAlves\Desktop\3ano\DAI\Trabalho\mymovies\MyMovies.universal\Paginas\GestaoDeUtilizadores.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EAC081E758C76DF4DFA973EE90126A24"
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
    partial class GestaoDeUtilizadores : 
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
            case 3: // Paginas\GestaoDeUtilizadores.xaml line 70
                {
                    this.viewUtilizadores = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.viewUtilizadores).RowEditEnding += this.viewUtilizadores_RowEditEnding;
                }
                break;
            case 4: // Paginas\GestaoDeUtilizadores.xaml line 96
                {
                    this.Idutilizador = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 5: // Paginas\GestaoDeUtilizadores.xaml line 97
                {
                    this.Nome = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 6: // Paginas\GestaoDeUtilizadores.xaml line 98
                {
                    this.Email = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 7: // Paginas\GestaoDeUtilizadores.xaml line 99
                {
                    this.Password = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 8: // Paginas\GestaoDeUtilizadores.xaml line 100
                {
                    this.Tipo = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 9: // Paginas\GestaoDeUtilizadores.xaml line 64
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element9 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element9).Click += this.Adicionar_Linha_Botao;
                }
                break;
            case 10: // Paginas\GestaoDeUtilizadores.xaml line 65
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element10 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element10).Click += this.Eliminar_Utilizadores_Botao;
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

