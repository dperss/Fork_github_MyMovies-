﻿#pragma checksum "C:\Curso\DAI\mymovies\MyMovies.universal\Paginas\GestaoDeFilmes.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "46E1B5124F66D274A88EDB550B2751A5"
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
    partial class GestaoDeFilmes : 
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
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class GestaoDeFilmes_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IGestaoDeFilmes_Bindings
        {
            private global::MyMovies.universal.Paginas.GestaoDeFilmes dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid obj2;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2ItemsSourceDisabled = false;

            public GestaoDeFilmes_obj1_Bindings()
            {
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 55 && columnNumber == 9)
                {
                    isobj2ItemsSourceDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // Paginas\GestaoDeFilmes.xaml line 29
                        this.obj2 = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)target;
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

            // IGestaoDeFilmes_Bindings

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
                    this.dataRoot = (global::MyMovies.universal.Paginas.GestaoDeFilmes)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MyMovies.universal.Paginas.GestaoDeFilmes obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_GestaoDeFilmesViewModel(obj.GestaoDeFilmesViewModel, phase);
                    }
                }
            }
            private void Update_GestaoDeFilmesViewModel(global::MyMovies.universal.ViewModel.GestaoDeFilmesViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_GestaoDeFilmesViewModel_Filmes(obj.Filmes, phase);
                    }
                }
            }
            private void Update_GestaoDeFilmesViewModel_Filmes(global::System.Collections.ObjectModel.ObservableCollection<global::MyMovies.BL.Filme> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // Paginas\GestaoDeFilmes.xaml line 29
                    if (!isobj2ItemsSourceDisabled)
                    {
                        XamlBindingSetters.Set_Microsoft_Toolkit_Uwp_UI_Controls_DataGrid_ItemsSource(this.obj2, obj, null);
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
            case 2: // Paginas\GestaoDeFilmes.xaml line 29
                {
                    this.viewFilmes = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.viewFilmes).SelectionChanged += this.viewFilmes_SelectionChanged;
                    ((global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)this.viewFilmes).RowEditEnded += this.viewFilmes_RowEditEnded;
                }
                break;
            case 3: // Paginas\GestaoDeFilmes.xaml line 23
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element3 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element3).Click += this.Adicionar_Filmes_Botao;
                }
                break;
            case 4: // Paginas\GestaoDeFilmes.xaml line 24
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element4 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element4).Click += this.Eliminar_Filmes_Botao;
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
            case 1: // Paginas\GestaoDeFilmes.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    GestaoDeFilmes_obj1_Bindings bindings = new GestaoDeFilmes_obj1_Bindings();
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

