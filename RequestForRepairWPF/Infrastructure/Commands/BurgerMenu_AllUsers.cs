using RequestForRepairWPF.ViewModels;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RequestForRepairWPF.Infrastructure.Commands
{
    internal class BurgerMenu_AllUsers : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            //Application.LoadComponent(AllUsers_View);
            //var window = new Window();
            //window.DataContext = DataContext.AllUsers_View;
            ////window.DataContext = ((AllUsers_View)DataContext).ChildVm; 
            //window.Show();
            var window2 = new AllUsers_View();
            window2.DataContext = new AllUsers_ViewModel();
            //window2.DataContext = new SettingsWindowVM(); 
            window2.Show();

        }
    }
    
    //internal class BurgerMenu_Customers : Command
    //{
    //
    //}
    //
    //internal class BurgerMenu_Executors : Command
    //{
    //
    //}

}
