﻿#pragma checksum "..\..\..\..\TablePages\TableLocationPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F65BE240AFDA3814A1A01006C1D4D92EDECD05E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using OderingSystem.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace OderingSystem.Wpf {
    
    
    /// <summary>
    /// TableLocationPage
    /// </summary>
    public partial class TableLocationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 27 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Header;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButton;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bar;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tables;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Terrace;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\TablePages\TableLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid TableGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/OderingSystem.Wpf;component/tablepages/tablelocationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\TablePages\TableLocationPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Header = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.BackButton = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\..\TablePages\TableLocationPage.xaml"
            this.BackButton.Click += new System.Windows.RoutedEventHandler(this.BackButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Bar = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\TablePages\TableLocationPage.xaml"
            this.Bar.Click += new System.Windows.RoutedEventHandler(this.Bar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Tables = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\..\TablePages\TableLocationPage.xaml"
            this.Tables.Click += new System.Windows.RoutedEventHandler(this.Tables_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Terrace = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\..\TablePages\TableLocationPage.xaml"
            this.Terrace.Click += new System.Windows.RoutedEventHandler(this.Terrace_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TableGrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

