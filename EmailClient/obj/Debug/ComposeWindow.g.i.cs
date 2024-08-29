﻿#pragma checksum "..\..\ComposeWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F10C566C6982E993CCE96DBCB10747D82CEE322C328EDB7EA0DBCFDF93D0D5DC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace EmailClient {
    
    
    /// <summary>
    /// ComposeWindow
    /// </summary>
    public partial class ComposeWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSender;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSubject;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CcRecpt;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBody;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDraft;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSend;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox totalAttachedFiles;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\ComposeWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAt;
        
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
            System.Uri resourceLocater = new System.Uri("/EmailClient;component/composewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ComposeWindow.xaml"
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
            this.cmbSender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.txtTo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtSubject = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CcRecpt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtBody = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnDraft = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\ComposeWindow.xaml"
            this.btnDraft.Click += new System.Windows.RoutedEventHandler(this.btnDraft_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSend = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\ComposeWindow.xaml"
            this.btnSend.Click += new System.Windows.RoutedEventHandler(this.btnSend_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.totalAttachedFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 9:
            this.btnAt = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\ComposeWindow.xaml"
            this.btnAt.Click += new System.Windows.RoutedEventHandler(this.btnAt_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

