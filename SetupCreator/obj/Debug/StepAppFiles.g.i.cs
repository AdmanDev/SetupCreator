﻿#pragma checksum "..\..\StepAppFiles.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4181B2F24A48A721811354D3CB9855D867A4A153"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using SetupCreator;
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


namespace SetupCreator {
    
    
    /// <summary>
    /// StepAppFiles
    /// </summary>
    public partial class StepAppFiles : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TB_AppEXE;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_ChooseAppEXE;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LV_Files;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_AddFile;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_AddFolder;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\StepAppFiles.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BT_Remove;
        
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
            System.Uri resourceLocater = new System.Uri("/SetupCreator;component/stepappfiles.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\StepAppFiles.xaml"
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
            this.TB_AppEXE = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.BT_ChooseAppEXE = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\StepAppFiles.xaml"
            this.BT_ChooseAppEXE.Click += new System.Windows.RoutedEventHandler(this.BT_ChooseAppEXE_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LV_Files = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.BT_AddFile = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\StepAppFiles.xaml"
            this.BT_AddFile.Click += new System.Windows.RoutedEventHandler(this.BT_AddFile_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BT_AddFolder = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\StepAppFiles.xaml"
            this.BT_AddFolder.Click += new System.Windows.RoutedEventHandler(this.BT_AddFolder_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BT_Remove = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\StepAppFiles.xaml"
            this.BT_Remove.Click += new System.Windows.RoutedEventHandler(this.BT_Remove_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

