﻿#pragma checksum "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1F2345357A485AFFD59AEA99289C2DEF7D6DDB8E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HCI_Project.FestivalTypeView;
using HCI_Project.Validation;
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


namespace HCI_Project.FestivalTypeView {
    
    
    /// <summary>
    /// NewFestivalTypeWindow
    /// </summary>
    public partial class NewFestivalTypeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFTName;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFTId;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxChooser;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonBrowse;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxFTDescription;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonCancel;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonConfirm;
        
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
            System.Uri resourceLocater = new System.Uri("/HCI-Project;component/festivaltypeview/newfestivaltypewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
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
            this.TextBoxFTName = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.TextBoxFTName.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.countError));
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.TextBoxFTName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBoxFTName_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBoxFTId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBoxChooser = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.TextBoxChooser.AddHandler(System.Windows.Controls.Validation.ErrorEvent, new System.EventHandler<System.Windows.Controls.ValidationErrorEventArgs>(this.countError));
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonBrowse = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.ButtonBrowse.Click += new System.Windows.RoutedEventHandler(this.ButtonBrowse_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxFTDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ButtonCancel = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.ButtonCancel.Click += new System.Windows.RoutedEventHandler(this.ButtonCancel_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\FestivalTypeView\NewFestivalTypeWindow.xaml"
            this.ButtonConfirm.Click += new System.Windows.RoutedEventHandler(this.ButtonConfirm_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
