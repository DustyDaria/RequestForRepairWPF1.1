﻿#pragma checksum "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3BCCF2CCCFDF4825000032619DE7714FD9F03E8E053D35B6D73BC699A5DD287A"
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
using RequestForRepairWPF.Infrastructure.Commands.Controls.Menu;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.Views.Controls.Menu;
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


namespace RequestForRepairWPF.Views.Controls.Menu {
    
    
    /// <summary>
    /// Ctrl_burgerMenu_View
    /// </summary>
    public partial class Ctrl_burgerMenu_View : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridMenu;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CloseMenu;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_OpenMenu;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_AllUsers;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_Customers;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_Executors;
        
        #line default
        #line hidden
        
        
        #line 194 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_RegisterNewUser;
        
        #line default
        #line hidden
        
        
        #line 219 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_EditUserAccount;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_DescriptionRoom;
        
        #line default
        #line hidden
        
        
        #line 269 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_CreateRequest;
        
        #line default
        #line hidden
        
        
        #line 293 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_WatchRequest;
        
        #line default
        #line hidden
        
        
        #line 343 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_MyRequest;
        
        #line default
        #line hidden
        
        
        #line 393 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListViewItem list_FileReport;
        
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
            System.Uri resourceLocater = new System.Uri("/RequestForRepairWPF;component/views/controls/menu/ctrl_burgermenu_view.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
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
            this.GridMenu = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btn_CloseMenu = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
            this.btn_CloseMenu.Click += new System.Windows.RoutedEventHandler(this.btn_CloseMenu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_OpenMenu = ((System.Windows.Controls.Button)(target));
            
            #line 98 "..\..\..\..\..\Views\Controls\Menu\Ctrl_burgerMenu_View.xaml"
            this.btn_OpenMenu.Click += new System.Windows.RoutedEventHandler(this.btn_OpenMenu_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.list_AllUsers = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 5:
            this.list_Customers = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 6:
            this.list_Executors = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 7:
            this.list_RegisterNewUser = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 8:
            this.list_EditUserAccount = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 9:
            this.list_DescriptionRoom = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 10:
            this.list_CreateRequest = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 11:
            this.list_WatchRequest = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 12:
            this.list_MyRequest = ((System.Windows.Controls.ListViewItem)(target));
            return;
            case 13:
            this.list_FileReport = ((System.Windows.Controls.ListViewItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

