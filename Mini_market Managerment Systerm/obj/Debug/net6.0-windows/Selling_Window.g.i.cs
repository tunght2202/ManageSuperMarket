﻿#pragma checksum "..\..\..\Selling_Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A689EB8EAE8D340C7B3AF66996B864DA9858F3B8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Mini_market_Managerment_Systerm;
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


namespace Mini_market_Managerment_Systerm {
    
    
    /// <summary>
    /// Selling_Window
    /// </summary>
    public partial class Selling_Window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbNameSeller;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbDate;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbName;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPrice;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbQuantity;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBuy;
        
        #line default
        #line hidden
        
        
        #line 162 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbTotal;
        
        #line default
        #line hidden
        
        
        #line 200 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvBill;
        
        #line default
        #line hidden
        
        
        #line 239 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbCategory;
        
        #line default
        #line hidden
        
        
        #line 259 "..\..\..\Selling_Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvProduct;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Mini_market Managerment Systerm;component/selling_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Selling_Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbNameSeller = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.lbDate = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tbName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.tbPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tbQuantity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 129 "..\..\..\Selling_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_AddProduct);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lvBuy = ((System.Windows.Controls.ListView)(target));
            
            #line 139 "..\..\..\Selling_Window.xaml"
            this.lvBuy.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.lvBuy_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lbTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            
            #line 179 "..\..\..\Selling_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_AddBuy);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lvBill = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            
            #line 223 "..\..\..\Selling_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Logout);
            
            #line default
            #line hidden
            return;
            case 12:
            this.cbCategory = ((System.Windows.Controls.ComboBox)(target));
            
            #line 245 "..\..\..\Selling_Window.xaml"
            this.cbCategory.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbCategory_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 254 "..\..\..\Selling_Window.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Refresh);
            
            #line default
            #line hidden
            return;
            case 14:
            this.lvProduct = ((System.Windows.Controls.ListView)(target));
            
            #line 259 "..\..\..\Selling_Window.xaml"
            this.lvProduct.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.lvProduct_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

