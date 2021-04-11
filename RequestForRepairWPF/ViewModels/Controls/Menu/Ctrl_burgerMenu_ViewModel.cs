using RequestForRepairWPF.Infrastructure.Commands.Controls.Menu;
using RequestForRepairWPF.Models.Controls.Menu;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.Windows;
using RequestForRepairWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Controls.Menu
{
    public class Ctrl_burgerMenu_ViewModel : ViewModel
    {

        //private string _userTypeOfAccount;
        private int _id;
        Ctrl_burgerMenu_Model menu_Model = new Ctrl_burgerMenu_Model();
        

        #region Команда на загрузкку элементов меню
        public ICommand MenuLoad_Command { get; }
        public Ctrl_burgerMenu_ViewModel()
        {
            MenuLoad_Command = new MenuLoad_Command(this);
        }
        #endregion

        private static string _userTypeOfAccount;
        public string userTypeOfAccount
        {
            get => _userTypeOfAccount;
            set => Set(ref _userTypeOfAccount, value);
        }

        private string menuItem(string _userTypeOfAccount)
        {
            if (_userTypeOfAccount == "Системный администратор")
            {
                _listVisibility_AllUsers = true;

                _listVisibility_Customers = true;

                _listVisibility_Executors = true;

                _listVisibility_RegisterNewUser = true;

                _listVisibility_EditUserAccount = true;

                _listVisibility_WatchRequest = true;

                _listVisibility_WatchArchiveRequest = true;

                _listVisibility_MyRequest = true;

                _listVisibility_MyArchiveRequest = true;

                _listVisibility_FileReport = true;
            }
            else if (_userTypeOfAccount == "Заказчик")
            {
                _listVisibility_EditUserAccount = true;

                _listVisibility_DescriptionRoom = true;

                _listVisibility_CreateRequest = true;

                _listVisibility_WatchRequest = true;

                _listVisibility_WatchArchiveRequest = true;

                _listVisibility_MyRequest = true;

                _listVisibility_MyArchiveRequest = true;

                _listVisibility_FileReport = true;
            }
            else if (_userTypeOfAccount == "Исполнитель")
            {
                _listVisibility_EditUserAccount = true;

                _listVisibility_WatchRequest = true;

                _listVisibility_WatchArchiveRequest = true;

                _listVisibility_MyRequest = true;

                _listVisibility_MyArchiveRequest = true;

                _listVisibility_FileReport = true;
            }

            return _userTypeOfAccount;
        }



        /// <summary> Инициализация элементов меню </summary>
        #region Инициализация элементов меню
        /// <summary> Инициализация элементов меню </summary>

        private static bool _listVisibility_AllUsers;
        public bool listVisibility_AllUsers
        {
            get => _listVisibility_AllUsers;
            set => Set(ref _listVisibility_AllUsers, value);
        }

        private static bool _listVisibility_Customers;
        public bool listVisibility_Customers
        {
            get => _listVisibility_Customers;
            set => Set(ref _listVisibility_Customers, value);
        }

        private static bool _listVisibility_Executors;
        public bool listVisibility_Executors
        {
            get => _listVisibility_Executors;
            set => Set(ref _listVisibility_Executors, value);
        }

        private static bool _listVisibility_RegisterNewUser;
        public bool listVisibility_RegisterNewUser
        {
            get => _listVisibility_RegisterNewUser;
            set => Set(ref _listVisibility_RegisterNewUser, value);
        }

        private static bool _listVisibility_EditUserAccount;
        public bool listVisibility_EditUserAccount
        {
            get => _listVisibility_EditUserAccount;
            set => Set(ref _listVisibility_EditUserAccount, value);
        }

        private static bool _listVisibility_DescriptionRoom;
        public bool listVisibility_DescriptionRoom
        {
            get => _listVisibility_DescriptionRoom;
            set => Set(ref _listVisibility_DescriptionRoom, value);
        }

        private static bool _listVisibility_CreateRequest;
        public bool listVisibility_CreateRequest
        {
            get => _listVisibility_CreateRequest;
            set => Set(ref _listVisibility_CreateRequest, value);
        }

        private static bool _listVisibility_WatchRequest;
        public bool listVisibility_WatchRequest
        {
            get => _listVisibility_WatchRequest;
            set => Set(ref _listVisibility_WatchRequest, value);
        }

        private static bool _listVisibility_WatchArchiveRequest;
        public bool listVisibility_WatchArchiveRequest
        {
            get => _listVisibility_WatchArchiveRequest;
            set => Set(ref _listVisibility_WatchArchiveRequest, value);
        }

        private static bool _listVisibility_MyRequest;
        public bool listVisibility_MyRequest
        {
            get => _listVisibility_MyRequest;
            set => Set(ref _listVisibility_MyRequest, value);
        }

        private static bool _listVisibility_MyArchiveRequest;
        public bool listVisibility_MyArchiveRequest
        {
            get => _listVisibility_MyArchiveRequest;
            set => Set(ref _listVisibility_MyArchiveRequest, value);
        }

        private static bool _listVisibility_FileReport;
        public bool listVisibility_FileReport
        {
            get => _listVisibility_FileReport;
            set => Set(ref _listVisibility_FileReport, value);
        }

        #endregion

        /// <summary> Команды на обработку нажатия по элементам меню </summary>
        #region Команды на обработку нажатия по элементам меню
        /// <summary> Команды на обработку нажатия по элементам меню </summary>

        //#region Открыть/закрыть меню
        //
        //#region btn_CloseMenu_Click
        //public ICommand btn_CloseMenu_Click { get; }
        //private bool Canbtn_CloseMenu_ClickExecute(object p) => true;
        //private void Onbtn_CloseMenu_ClickExecuted(object p)
        //{
        //    // тело команды
        //    menuVisibility_Close = false;
        //    menuVisibility_Open = true;
        //}
        //#endregion
        //
        //#region btn_OpenMenu_Click
        //public ICommand btn_OpenMenu_Click { get; }
        //private bool Canbtn_OpenMenu_ClickExecute(object p) => true;
        //private void Onbtn_OpenMenu_ClickExecuted(object p)
        //{
        //    menuVisibility_Close = true;
        //    menuVisibility_Open = false;
        //}
        //#endregion
        //
        //#region Изменение Visibility меню
        //
        //bool _menuVisibility_Close = false;
        //public bool menuVisibility_Close
        //{
        //    get => _menuVisibility_Close;
        //    set
        //    {
        //        _menuVisibility_Close = value;
        //        OnPropertyChanged("menuVisibility_Close");
        //    }
        //}
        //
        //bool _menuVisibility_Open = true;
        //public bool menuVisibility_Open
        //{
        //    get => _menuVisibility_Open;
        //    set
        //    {
        //        _menuVisibility_Open = value;
        //        OnPropertyChanged("menuVisibility_Close");
        //    }
        //}
        //#endregion
        //
        //#endregion

        #region Исполнители

        private ICommand _openExecutorsView;

        public ICommand OpenExecutorsView
        {
            get
            {
                if(_openExecutorsView == null)
                {
                    _openExecutorsView = new OpenExecutorsViewCommand(this);
                }
                return _openExecutorsView;
            }
        }

        
        

        #endregion

        
        #endregion

    }

    class OpenExecutorsViewCommand : MyCommand
    {
        public OpenExecutorsViewCommand(Ctrl_burgerMenu_ViewModel ctrl_Menu_ViewModel) : base(ctrl_Menu_ViewModel)
        {

        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            var executors_ViewModel = new Executors_ViewModel();
            displayRootRegistry.ShowPresentation(executors_ViewModel);
        }
    }

    #region Вспомогательный класс для команд

    abstract class MyCommand : ICommand
    {
        protected Ctrl_burgerMenu_ViewModel _ctrlMenu_ViewModel;

        public MyCommand(Ctrl_burgerMenu_ViewModel ctrlMenu_ViewModel)
        {
            _ctrlMenu_ViewModel = ctrlMenu_ViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }

    #endregion

}
