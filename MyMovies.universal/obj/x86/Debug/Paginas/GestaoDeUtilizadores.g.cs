﻿#pragma checksum "C:\Curso\DAI\mymovies\MyMovies.universal\Paginas\GestaoDeUtilizadores.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "658CDCE65E4CB5BF3454DF3B951E94BF"
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj, global::System.Collections.IEnumerable value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Collections.IEnumerable) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Collections.IEnumerable), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGridComboBoxColumn_ItemsSource(global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridComboBoxColumn obj, global::System.Collections.IEnumerable value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Collections.IEnumerable) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Collections.IEnumerable), targetNullValue);
                }
                obj.ItemsSource = value;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GestaoDeUtilizadores_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGestaoDeUtilizadores_Bindings
        {
            private global::MyMovies.universal.Paginas.GestaoDeUtilizadores dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj2;
            private global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridComboBoxColumn obj7;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;
            private static bool isobj7ItemsSourceDisabled = false;

            public GestaoDeUtilizadores_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 55 && columnNumber == 9)
                {
                    isobj2ItemsSourceDisabled = true;
                }
                else if (lineNumber == 61 && columnNumber == 64)
                {
                    isobj7ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Paginas\GestaoDeUtilizadores.xaml line 29
                        this.obj2 = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)target;
                        break;
                    case 7: // Paginas\GestaoDeUtilizadores.xaml line 61
                        this.obj7 = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridComboBoxColumn)target;
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IGestaoDeUtilizadores_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MyMovies.universal.Paginas.GestaoDeUtilizadores)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MyMovies.universal.Paginas.GestaoDeUtilizadores obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_GestaoDeUtilizadoresViewModel(obj.GestaoDeUtilizadoresViewModel, phase);
                    }
                }
            }
            private void Update_GestaoDeUtilizadoresViewModel(global::MyMovies.universal.ViewModel.GestaoDeUtilizadoresViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_GestaoDeUtilizadoresViewModel_Utilizadores(obj.Utilizadores, phase);
                        this.Update_GestaoDeUtilizadoresViewModel_Tipos(obj.Tipos, phase);
                    }
                }
            }
            private void Update_GestaoDeUtilizadoresViewModel_Utilizadores(global::System.Collections.ObjectModel.ObservableCollection<global::MyMovies.BL.Utilizador> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Paginas\GestaoDeUtilizadores.xaml line 29
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(this.obj2, obj, null);
                    }
                }
            }
            private void Update_GestaoDeUtilizadoresViewModel_Tipos(global::System.Collections.ObjectModel.ObservableCollection<global::Tipo> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Paginas\GestaoDeUtilizadores.xaml line 61
                    if (!isobj7ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGridComboBoxColumn_ItemsSource(this.obj7, obj, null);
                    }
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Paginas\GestaoDeUtilizadores.xaml line 29
                {
                    this.viewUtilizadores = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.viewUtilizadores).SelectionChanged += this.viewUtilizadores_SelectionChanged;
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.viewUtilizadores).RowEditEnded += this.viewUtilizadores_RowEditEnded;
                }
                break;
            case 3: // Paginas\GestaoDeUtilizadores.xaml line 57
                {
                    this.Idutilizador = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 4: // Paginas\GestaoDeUtilizadores.xaml line 58
                {
                    this.Nome = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 5: // Paginas\GestaoDeUtilizadores.xaml line 59
                {
                    this.Email = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 6: // Paginas\GestaoDeUtilizadores.xaml line 60
                {
                    this.Password = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridTextColumn)(target);
                }
                break;
            case 7: // Paginas\GestaoDeUtilizadores.xaml line 61
                {
                    this.Tipo = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGridComboBoxColumn)(target);
                }
                break;
            case 8: // Paginas\GestaoDeUtilizadores.xaml line 23
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element8 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element8).Click += this.Add_Utilizador_Click;
                }
                break;
            case 9: // Paginas\GestaoDeUtilizadores.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element9 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element9).Click += this.Eliminar_Utilizador_Click;
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
            switch(connectionId)
            {
            case 1: // Paginas\GestaoDeUtilizadores.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    GestaoDeUtilizadores_obj1_Bindings bindings = new GestaoDeUtilizadores_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

