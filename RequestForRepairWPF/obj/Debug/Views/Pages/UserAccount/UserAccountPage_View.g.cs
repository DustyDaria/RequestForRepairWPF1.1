﻿#pragma checksum "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1C712D32F48AFEDD23EB2CB3E3DBAE1DB40816B92D9F21D5F95E115701931EE6"
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
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using RequestForRepairWPF;
using RequestForRepairWPF.Infrastructure.Commands.Controls.Menu;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Pages.UserAccount;
using RequestForRepairWPF.Views.Controls.Menu;
using RequestForRepairWPF.Views.Controls.Password;
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


namespace RequestForRepairWPF.Views.Pages.UserAccount {
    
    
    /// <summary>
    /// UserAccountPage_View
    /// </summary>
    public partial class UserAccountPage_View : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scroll;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock label_Header;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_last_name;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_name;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_middle_name;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_position;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_phone;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_user_login;
        
        #line default
        #line hidden
        
        
        #line 185 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_type_of_account;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_category_executors;
        
        #line default
        #line hidden
        
        
        #line 273 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Save;
        
        #line default
        #line hidden
        
        
        #line 290 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Cancel;
        
        #line default
        #line hidden
        
        
        #line 307 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Edit;
        
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
            System.Uri resourceLocater = new System.Uri("/RequestForRepairWPF;component/views/pages/useraccount/useraccountpage_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
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
            this.textBox_last_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBox_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBox_middle_name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.textBox_position = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.textBox_phone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.textBox_user_login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.comboBox_type_of_account = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            this.comboBox_category_executors = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 11:
            this.btn_Save = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.btn_Cancel = ((System.Windows.Controls.Button)(target));
            return;
            case 13:
            this.btn_Edit = ((System.Windows.Controls.Button)(target));
            
            #line 311 "..\..\..\..\..\Views\Pages\UserAccount\UserAccountPage_View.xaml"
            this.btn_Edit.Click += new System.Windows.RoutedEventHandler(this.btn_Edit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

