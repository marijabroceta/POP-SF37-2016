﻿#pragma checksum "..\..\..\UI\NamestajProzor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EBE18C2EC6C38D2828BF06872FBB3284FF441A36"
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
    /// NamestajProzor
    /// </summary>
    public partial class NamestajProzor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\UI\NamestajProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbPretraga;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\UI\NamestajProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPretraga;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\UI\NamestajProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiranje;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\UI\NamestajProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiraj;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\UI\NamestajProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgNamestaj;
        
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
            System.Uri resourceLocater = new System.Uri("/POP-SF-37-2016-GUI;component/ui/namestajprozor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\NamestajProzor.xaml"
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
            this.cbPretraga = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.tbPretraga = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            
            #line 71 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PretragaNamestaja_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbSortiranje = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbSortiraj = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            
            #line 83 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SortirajNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgNamestaj = ((System.Windows.Controls.DataGrid)(target));
            
            #line 92 "..\..\..\UI\NamestajProzor.xaml"
            this.dgNamestaj.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.dgNamestaj_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 103 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Osvezi_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 114 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodajNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 115 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IzmeniNamestaj_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 116 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ObrisiNamstaj_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 117 "..\..\..\UI\NamestajProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZatvoriProzor_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

