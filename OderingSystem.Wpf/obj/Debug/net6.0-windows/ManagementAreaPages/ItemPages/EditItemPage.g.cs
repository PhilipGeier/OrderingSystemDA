﻿#pragma checksum "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "456AC99ACA29EB56C86279A96D01B6557B99CBB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using OderingSystem.Wpf.ManagementAreaPages.ItemPages;
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


namespace OderingSystem.Wpf.ManagementAreaPages.ItemPages {
    
    
    /// <summary>
    /// EditItemPage
    /// </summary>
    public partial class EditItemPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ItemsBox;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameInput;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceInput;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CategoryDropdown;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ConfirmButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NotificationField;
        
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
            System.Uri resourceLocater = new System.Uri("/OderingSystem.Wpf;component/managementareapages/itempages/edititempage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
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
            this.ItemsBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 18 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
            this.ItemsBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ItemSelection_Changed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PriceInput = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CategoryDropdown = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.ConfirmButton = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
            this.ConfirmButton.Click += new System.Windows.RoutedEventHandler(this.ConfirmButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\..\..\ManagementAreaPages\ItemPages\EditItemPage.xaml"
            this.CancelButton.Click += new System.Windows.RoutedEventHandler(this.CancelButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NotificationField = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

