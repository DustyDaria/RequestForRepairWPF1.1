using RequestForRepairWPF.Data;
using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Services;
using RequestForRepairWPF.Views.Pages;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestForRepairWPF.Infrastructure.Commands
{
    public class LogOut : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => AppRestart();

        private void AppRestart()
        {
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }
    }
}
