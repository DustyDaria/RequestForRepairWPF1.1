using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.Models.Controls.Menu;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.Controls.Menu;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RequestForRepairWPF.Infrastructure.Commands.Controls.Menu
{
    
    internal class MenuListViewItem_Command : Command
    {

        private string _userTypeOfAccount;
        private int _id;
        Ctrl_burgerMenu_Model menu_Model = new Ctrl_burgerMenu_Model();
        

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            Authorization_View _authorization = new Authorization_View();
            _id = _authorization._authorizationUser.id_user;
            menu_Model.GetType = Convert.ToString(_id);
            _userTypeOfAccount = menu_Model.GetType;

            if (_userTypeOfAccount == "Системный администратор")  
            {
                Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
                            
                menu_ViewModel.listVisibility_AllUsers = true;
                            
                menu_ViewModel.listVisibility_Customers = true;
                            
                menu_ViewModel.listVisibility_Executors = true;
                            
                menu_ViewModel.listVisibility_RegisterNewUser = true;
                            
                menu_ViewModel.listVisibility_EditUserAccount = true;
                            
                menu_ViewModel.listVisibility_WatchRequest = true;
                            
                menu_ViewModel.listVisibility_WatchArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_MyRequest = true;
                           
                menu_ViewModel.listVisibility_MyArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_FileReport = true;
            }
            else if(_userTypeOfAccount == "Заказчик")
            {
                
                            
                Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
                            
                menu_ViewModel.listVisibility_EditUserAccount = true;
                            
                menu_ViewModel.listVisibility_DescriptionRoom = true;
                            
                menu_ViewModel.listVisibility_CreateRequest = true;
                            
                menu_ViewModel.listVisibility_WatchRequest = true;
                            
                menu_ViewModel.listVisibility_WatchArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_MyRequest = true;
                            
                menu_ViewModel.listVisibility_MyArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_FileReport = true;
            } 
            else if(_userTypeOfAccount == "Исполнитель")
            {
                Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
                            
                menu_ViewModel.listVisibility_EditUserAccount = true;
                            
                menu_ViewModel.listVisibility_WatchRequest = true;
                            
                menu_ViewModel.listVisibility_WatchArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_MyRequest = true;
                            
                menu_ViewModel.listVisibility_MyArchiveRequest = true;
                            
                menu_ViewModel.listVisibility_FileReport = true;
            }

        }

        //private RelayCommand addMenuCommand;
        //private string _userTypeOfAccount;
        //private int _id;
        //
        //Ctrl_burgerMenu_Model menu_Model = new Ctrl_burgerMenu_Model();
        //
        //public RelayCommand AddMenuCommand
        //{
        //    set
        //    {
        //        Authorization_View _authorization = new Authorization_View();
        //        _id = _authorization._authorizationUser.id_user;
        //        menu_Model.GetType = Convert.ToString(_id);
        //        _userTypeOfAccount = menu_Model.GetType;
        //    }
        //    get
        //    {
        //        if(_userTypeOfAccount == "Системный администратор")
        //        {
        //            return addMenuCommand ??
        //                (addMenuCommand = new RelayCommand(obj => {
        //                    Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
        //                    menu_ViewModel.listVisibility_AllUsers = true;
        //                    menu_ViewModel.listVisibility_Customers = true;
        //                    menu_ViewModel.listVisibility_Executors = true;
        //                    menu_ViewModel.listVisibility_RegisterNewUser = true;
        //                    menu_ViewModel.listVisibility_EditUserAccount = true;
        //                    menu_ViewModel.listVisibility_WatchRequest = true;
        //                    menu_ViewModel.listVisibility_WatchArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_MyRequest = true;
        //                    menu_ViewModel.listVisibility_MyArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_FileReport = true;
        //                }));
        //        }
        //        else if(_userTypeOfAccount == "Заказчик")
        //        {
        //            return addMenuCommand ??
        //                (addMenuCommand = new RelayCommand(obj =>
        //                {
        //                    Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
        //                    menu_ViewModel.listVisibility_EditUserAccount = true;
        //                    menu_ViewModel.listVisibility_DescriptionRoom = true;
        //                    menu_ViewModel.listVisibility_CreateRequest = true;
        //                    menu_ViewModel.listVisibility_WatchRequest = true;
        //                    menu_ViewModel.listVisibility_WatchArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_MyRequest = true;
        //                    menu_ViewModel.listVisibility_MyArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_FileReport = true;
        //                }));
        //        }
        //        else if(_userTypeOfAccount == "Исполнитель")
        //        {
        //            return addMenuCommand ??
        //                (addMenuCommand = new RelayCommand(obj =>
        //                {
        //                    Ctrl_burgerMenu_ViewModel menu_ViewModel = new Ctrl_burgerMenu_ViewModel();
        //                    menu_ViewModel.listVisibility_EditUserAccount = true;
        //                    menu_ViewModel.listVisibility_WatchRequest = true;
        //                    menu_ViewModel.listVisibility_WatchArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_MyRequest = true;
        //                    menu_ViewModel.listVisibility_MyArchiveRequest = true;
        //                    menu_ViewModel.listVisibility_FileReport = true;
        //                }));
        //        }
        //        else
        //        {
        //            var cmdFalse = new RelayCommand(o => { MessageBox.Show("ERROR! Команда не выполнена"); });
        //            cmdFalse.CanExecute(false);
        //        }
        //    }
        //}

    }
}
