﻿#pragma checksum "..\..\..\View\WordView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "253C1E9E7B68ACCA62A96732AD4033846DAA45F067DC52C07DCD833ADC962200"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Doc_Builder.View;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
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


namespace Doc_Builder.View {
    
    
    /// <summary>
    /// WordViewCommand
    /// </summary>
    public partial class WordViewCommand : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid WordViews;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel FieldContainer;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UploadButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SelectedFileTextBlock;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cb1;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox text;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\View\WordView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button but1;
        
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
            System.Uri resourceLocater = new System.Uri("/Doc_Builder;component/view/wordview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\WordView.xaml"
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
            this.WordViews = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.FieldContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            
            #line 52 "..\..\..\View\WordView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddField_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 53 "..\..\..\View\WordView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.GetValues_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UploadButton = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\View\WordView.xaml"
            this.UploadButton.Click += new System.Windows.RoutedEventHandler(this.UploadButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SelectedFileTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.cb1 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.but = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\View\WordView.xaml"
            this.but.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.but1 = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\..\View\WordView.xaml"
            this.but1.Click += new System.Windows.RoutedEventHandler(this.but1_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

