﻿#pragma checksum "..\..\..\UI\AkcijaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E63E060802C71CA484AB84CD63235ECC3AEFD274"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using POP_SF_37_2016_GUI.UI.Validacija;
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
    /// AkcijaWindow
    /// </summary>
    public partial class AkcijaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbNaziv;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPopust;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpPocetakAkcije;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpZavrsetakAkcije;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\UI\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNamestajAkcija;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-37-2016-GUI;component/ui/akcijawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\AkcijaWindow.xaml"
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
            this.tbNaziv = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.tbPopust = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.dpPocetakAkcije = ((System.Windows.Controls.DatePicker)(target));
            
            #line 57 "..\..\..\UI\AkcijaWindow.xaml"
            this.dpPocetakAkcije.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.ProveriDatum_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dpZavrsetakAkcije = ((System.Windows.Controls.DatePicker)(target));
            
            #line 59 "..\..\..\UI\AkcijaWindow.xaml"
            this.dpZavrsetakAkcije.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.ProveriDatum_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.dgNamestajAkcija = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            
            #line 77 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajNamestajAkcija_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 80 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SacuvajIzmene);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 96 "..\..\..\UI\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzlazIzProzora);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

