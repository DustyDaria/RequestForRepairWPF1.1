﻿using RequestForRepairWPF.Data;
using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Infrastructure.Commands.Controls.Menu
{
    public class MenuLoad_Command : Command
    {
        private readonly Ctrl_burgerMenu_ViewModel _viewModel;

        public MenuLoad_Command(Ctrl_burgerMenu_ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => MenuLoad();

        private void MenuLoad()
        {
           // _viewModel.userTypeOfAccount = User.type_of_account;

            if(User.type_of_account == "Системный администратор")
            {
                _viewModel.listVisibility_AllUsers = true;
                _viewModel.listVisibility_Customers = true;
                _viewModel.listVisibility_Executors = true;
                _viewModel.listVisibility_RegisterNewUser = true;
                _viewModel.listVisibility_EditUserAccount = true;
                _viewModel.listVisibility_WatchRequest = true;
                _viewModel.listVisibility_WatchArchiveRequest = true;
                _viewModel.listVisibility_MyRequest = true;
                _viewModel.listVisibility_MyArchiveRequest = true;
                _viewModel.listVisibility_FileReport = true;
            }
            else if(User.type_of_account == "Заказчик")
            {
                _viewModel.listVisibility_EditUserAccount = true;
                _viewModel.listVisibility_DescriptionRoom = true;
                _viewModel.listVisibility_CreateRequest = true;
                _viewModel.listVisibility_WatchRequest = true;
                _viewModel.listVisibility_WatchArchiveRequest = true;
                _viewModel.listVisibility_MyRequest = true;
                _viewModel.listVisibility_MyArchiveRequest = true;
                _viewModel.listVisibility_FileReport = true;
            }
            else if(User.type_of_account == "Исполнитель")
            {
                _viewModel.listVisibility_EditUserAccount = true;
                _viewModel.listVisibility_WatchRequest = true;
                _viewModel.listVisibility_WatchArchiveRequest = true;
                _viewModel.listVisibility_MyRequest = true;
                _viewModel.listVisibility_MyArchiveRequest = true;
                _viewModel.listVisibility_FileReport = true;
            }
        }

    }
}
