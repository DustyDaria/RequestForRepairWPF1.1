﻿#pragma checksum "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D80658D96F61CECDAEA5D6703B2A807FCD96366019ABC2A58AADB95AA4EA18DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using RequestForRepairWPF;
using RequestForRepairWPF.ViewModels.Pages.Request;
using RequestForRepairWPF.Views.Controls.Menu;
using RequestForRepairWPF.Views.Controls.Room;
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


namespace RequestForRepairWPF.Views.Pages.Request {
    
    
    /// <summary>
    /// AllRequestsPage_View
    /// </summary>
    public partial class AllRequestsPage_View : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 32 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroll;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_Header;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid_Request;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_Search;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_DataForSearch;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Search;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_UpdateData;
        
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
            System.Uri resourceLocater = new System.Uri("/RequestForRepairWPF;component/views/pages/request/allrequestspage_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\Request\AllRequestsPage_View.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            this.scroll = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 2:
            this.label_Header = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.DataGrid_Request = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.comboBox_Search = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.textBox_DataForSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_Search = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btn_UpdateData = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

