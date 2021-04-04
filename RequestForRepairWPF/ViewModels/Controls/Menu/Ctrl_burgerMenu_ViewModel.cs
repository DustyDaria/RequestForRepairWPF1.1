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
        string _userTypeOfAccount;
        public string userTypeOfAccount
        {
            get
            {
                //Authorization_View _authorization = new Authorization_View();
                Authorization_ViewModel _authorization = new Authorization_ViewModel();
                //_id = _authorization._authorizationUser.id_user;

                /// _authorization.Authorization_userID !!! не получаю id 

                menu_Model.UserType = Convert.ToString(_authorization.Authorization_userID);
                _userTypeOfAccount = menu_Model.UserType;
        
                return menuItem(_userTypeOfAccount);
            }
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

        bool _listVisibility_AllUsers = false;
        public bool listVisibility_AllUsers
        {
            get => _listVisibility_AllUsers;
            set
            {
                _listVisibility_AllUsers = value;
                OnPropertyChanged("listVisibility_AllUsers");
            }
        }

        bool _listVisibility_Customers = false;
        public bool listVisibility_Customers
        {
            get => _listVisibility_Customers;
            set
            {
                _listVisibility_Customers = value;
                OnPropertyChanged("listVisibility_Customers");
            }
        }

        bool _listVisibility_Executors = false;
        public bool listVisibility_Executors
        {
            get => _listVisibility_Executors;
            set
            {
                _listVisibility_Executors = value;
                OnPropertyChanged("listVisibility_Executors");
            }
        }

        bool _listVisibility_RegisterNewUser = false;
        public bool listVisibility_RegisterNewUser
        {
            get => _listVisibility_RegisterNewUser;
            set
            {
                _listVisibility_RegisterNewUser = value;
                OnPropertyChanged("listVisibility_RegisterNewUser");
            }
        }

        bool _listVisibility_EditUserAccount = false;
        public bool listVisibility_EditUserAccount
        {
            get => _listVisibility_EditUserAccount;
            set
            {
                _listVisibility_EditUserAccount = value;
                OnPropertyChanged("listVisibility_EditUserAccount");
            }
        }

        bool _listVisibility_DescriptionRoom = false;
        public bool listVisibility_DescriptionRoom
        {
            get => _listVisibility_DescriptionRoom;
            set
            {
                _listVisibility_DescriptionRoom = value;
                OnPropertyChanged("listVisibility_DescriptionRoom");
            }
        }

        bool _listVisibility_CreateRequest = false;
        public bool listVisibility_CreateRequest
        {
            get => _listVisibility_CreateRequest;
            set
            {
                _listVisibility_CreateRequest = value;
                OnPropertyChanged("listVisibility_CreateRequest");
            }
        }

        bool _listVisibility_WatchRequest = false;
        public bool listVisibility_WatchRequest
        {
            get => _listVisibility_WatchRequest;
            set
            {
                _listVisibility_WatchRequest = value;
                OnPropertyChanged("listVisibility_WatchRequest");
            }
        }

        bool _listVisibility_WatchArchiveRequest = false;
        public bool listVisibility_WatchArchiveRequest
        {
            get => _listVisibility_WatchArchiveRequest;
            set
            {
                _listVisibility_WatchArchiveRequest = value;
                OnPropertyChanged("listVisibility_WatchArchiveRequest");
            }
        }

        bool _listVisibility_MyRequest = false;
        public bool listVisibility_MyRequest
        {
            get => _listVisibility_MyRequest;
            set
            {
                _listVisibility_MyRequest = value;
                OnPropertyChanged("listVisibility_MyRequest");
            }
        }

        bool _listVisibility_MyArchiveRequest = false;
        public bool listVisibility_MyArchiveRequest
        {
            get => _listVisibility_MyArchiveRequest;
            set
            {
                _listVisibility_MyArchiveRequest = value;
                OnPropertyChanged("listVisibility_MyArchiveRequest");
            }
        }

        bool _listVisibility_FileReport = false;
        public bool listVisibility_FileReport
        {
            get => _listVisibility_FileReport;
            set
            {
                _listVisibility_FileReport = value;
                OnPropertyChanged("listVisibility_FileReport");
            }
        }

        #endregion

        /// <summary> Команды на обработку нажатия по элементам меню </summary>
        #region Команды на обработку нажатия по элементам меню
        /// <summary> Команды на обработку нажатия по элементам меню </summary>

        #region Открыть/закрыть меню

        #region btn_CloseMenu_Click
        public ICommand btn_CloseMenu_Click { get; }
        private bool Canbtn_CloseMenu_ClickExecute(object p) => true;
        private void Onbtn_CloseMenu_ClickExecuted(object p)
        {
            // тело команды
            menuVisibility_Close = false;
            menuVisibility_Open = true;
        }
        #endregion

        #region btn_OpenMenu_Click
        public ICommand btn_OpenMenu_Click { get; }
        private bool Canbtn_OpenMenu_ClickExecute(object p) => true;
        private void Onbtn_OpenMenu_ClickExecuted(object p)
        {
            menuVisibility_Close = true;
            menuVisibility_Open = false;
        }
        #endregion

        #region Изменение Visibility меню

        bool _menuVisibility_Close = false;
        public bool menuVisibility_Close
        {
            get => _menuVisibility_Close;
            set
            {
                _menuVisibility_Close = value;
                OnPropertyChanged("menuVisibility_Close");
            }
        }

        bool _menuVisibility_Open = true;
        public bool menuVisibility_Open
        {
            get => _menuVisibility_Open;
            set
            {
                _menuVisibility_Open = value;
                OnPropertyChanged("menuVisibility_Close");
            }
        }
        #endregion

        #endregion

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
