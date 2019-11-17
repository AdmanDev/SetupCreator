﻿#pragma checksum "..\..\SetupWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BC2EE7D6E88142C9DC94D28669B4528D670C6521"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using GeneratedSetup;
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


namespace GeneratedSetup {
    
    
    /// <summary>
    /// SetupWindow
    /// </summary>
    public partial class SetupWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 119 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridHeader;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_CloseApp;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img_SetupIconW;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LB_Title;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\SetupWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Grid_Steps;
        
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
            System.Uri resourceLocater = new System.Uri("/GeneratedSetup;component/setupwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SetupWindow.xaml"
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
            
            #line 46 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.TextBlock)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TB_Licence_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 52 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CB_Agree_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.BT_ValidateLicence_Loaded);
            
            #line default
            #line hidden
            
            #line 56 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BT_ValidateLicence_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 62 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Label)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LB_Statut_Loaded);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 65 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.CB_StartApp_Loaded);
            
            #line default
            #line hidden
            
            #line 65 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CB_StartApp_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 66 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.CB_CreateShortcut_Loaded);
            
            #line default
            #line hidden
            
            #line 66 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.CB_CreateShortcut_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 69 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BT_FinshAndClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 77 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Image)(target)).Loaded += new System.Windows.RoutedEventHandler(this.IMG_LargeIcon_Loaded);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 78 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Label)(target)).Loaded += new System.Windows.RoutedEventHandler(this.LB_SetupName_Loaded);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 83 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.TextBox)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TB_OutputDir_Loaded);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 84 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BT_ChooseOutputDir_Click);
            
            #line default
            #line hidden
            
            #line 84 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Loaded += new System.Windows.RoutedEventHandler(this.BT_ChooseOutputDir_Loaded);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 87 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BT_Install_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 93 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Ads_Loaded);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 99 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.ProgressBar)(target)).Initialized += new System.EventHandler(this.PB_Installation_Initialized);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 111 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Label)(target)).Initialized += new System.EventHandler(this.LB_InstallationDetail_Initialized);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 114 "..\..\SetupWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BT_Cancel_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            
            #line 119 "..\..\SetupWindow.xaml"
            this.MainGrid.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MainGrid_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 18:
            this.GridHeader = ((System.Windows.Controls.Grid)(target));
            return;
            case 19:
            this.BT_CloseApp = ((System.Windows.Controls.Button)(target));
            
            #line 127 "..\..\SetupWindow.xaml"
            this.BT_CloseApp.Click += new System.Windows.RoutedEventHandler(this.BT_CloseApp_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.Img_SetupIconW = ((System.Windows.Controls.Image)(target));
            return;
            case 21:
            this.LB_Title = ((System.Windows.Controls.Label)(target));
            return;
            case 22:
            this.Grid_Steps = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

