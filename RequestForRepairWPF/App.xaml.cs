using RequestForRepairWPF.Services;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.ViewModels.Windows;
using RequestForRepairWPF.ViewModels.Windows.UserAccount;
using RequestForRepairWPF.Views.Controls.Menu;
using RequestForRepairWPF.Views.Windows;
using RequestForRepairWPF.Views.Windows.UserAccount;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public DisplayRootRegistry displayRootRegistry = new DisplayRootRegistry();
        Authorization_ViewModel authorization_ViewModel;

        public App()
        {
            displayRootRegistry.RegisterWindowType<Authorization_ViewModel, Authorization_View>();
            //displayRootRegistry.RegisterUserControlType<Ctrl_burgerMenu_ViewModel, Ctrl_burgerMenu_View>();
            //displayRootRegistry.RegisterWindowType<UserAccount_ViewModel, UserAccount_View>();
            //displayRootRegistry.RegisterWindowType<CustomerUserAccount_ViewModel, CustomerUserAccount_View>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            authorization_ViewModel = new Authorization_ViewModel();
            
            await displayRootRegistry.ShowModalPresentation(authorization_ViewModel);
            
            Shutdown();
        }
    }
}
