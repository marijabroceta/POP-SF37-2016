﻿#pragma checksum "..\..\..\UI\ProdajaNamestajaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "191FC28AFDE922DCA1B8A1780A3FB6DB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_37_2016_GUI.UI;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace POP_SF_37_2016_GUI.UI {
    
    
    /// <summary>
    /// ProdajaNamestajaWindow
    /// </summary>
    public partial class ProdajaNamestajaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbKupac;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpDatumProdaje;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgIdNamestaja;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgDodatnaUsluga;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUkupnaCenaBezPDV;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUkupnaCenaSaPDV;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/POP-SF-37-2016-GUI;component/ui/prodajanamestajawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.tbKupac = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.dpDatumProdaje = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.dgIdNamestaja = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            
            #line 53 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajNamestaj);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgDodatnaUsluga = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 72 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajUslugu);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblUkupnaCenaBezPDV = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lblUkupnaCenaSaPDV = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 90 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SacuvajIzmene);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 91 "..\..\..\UI\ProdajaNamestajaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzlazIzProzora);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

