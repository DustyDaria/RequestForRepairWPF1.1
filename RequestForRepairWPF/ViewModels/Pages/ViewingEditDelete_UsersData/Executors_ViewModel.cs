using Caliburn.Micro;
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models;
using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.ViewModels.DialogWindows;
using RequestForRepairWPF.Views.DialogWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    class Executors_ViewModel : ViewModel
    {
        private BindableCollection<User_DataModel> _allExecutors;
        public BindableCollection<User_DataModel> AllExecutors
        {
            get => _allExecutors;
            set => Set(ref _allExecutors, value);
        }


        public Executors_ViewModel()
        {
            #region Загрузка данных
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllExecutors = new BindableCollection<User_DataModel>(_model.GetPeople_Executors(_model.AllIdUsers_Executors));
            #endregion

        }

        #region Выбранный критерий поиска
        private string _selectedCriteriaSearch;
        public string SelectedCriteriaSearch
        {
            get => _selectedCriteriaSearch;
            set => Set(ref _selectedCriteriaSearch, value);
        }
        #endregion

        #region Критерий поиска
        private string[] _listCriteriaSearch = new string[] {
            "ID", "Логин", "Категория исполнителя", "Фамилия", 
            "Имя", "Отчество", "Должность", "Телефон"};
        public string[] ListCriteriaSearch
        {
            get => _listCriteriaSearch;
        }
        #endregion

        #region Данные для поиска
        private string _dataForSearch;
        public string DataForSearch
        {
            get => _dataForSearch;
            set => Set(ref _dataForSearch, value);
        }
        #endregion

        #region Команды 
        #region Команда на поиск по полю
        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                _searchCommand = new SearchCommand(this);
                return _searchCommand;
                
            }
        }
        #endregion
        #endregion

    }

    #region Класс-команда для поиска по полю
    internal class SearchCommand : MyRegCommand
    {

        Executors_Model _model = new Executors_Model();
        StringBuilder errors = new StringBuilder();

        public SearchCommand(Executors_ViewModel executors_ViewModel) : base(executors_ViewModel) { }
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Search();

        private void Search()
        {
            if (string.IsNullOrEmpty(_executors_ViewModel.SelectedCriteriaSearch))
                errors.AppendLine("Для поиска необходимо выбрать критерий!");
            if (string.IsNullOrWhiteSpace(_executors_ViewModel.DataForSearch))
                errors.AppendLine("А по каким данным мы проводим поиск? :D");

            if(errors.Length > 0)
            {
                OpenDialogWindow(errors.ToString());
                errors.Clear();
                return;
            }
            else
            {
                //User_DataModel.AllUsersID.Clear();
                //_executors_ViewModel.AllExecutors = new BindableCollection<User_DataModel>
                //                (_model.GetPeople(_model.AllIdUsers_LastName(_executors_ViewModel.DataForSearch)));
                
            }
            //AllExecutors = new BindableCollection<User_DataModel>(_model.GetPeople(_model.AllIdUsers));
        }

        /// <summary> Событие на изменение модели </summary>
        #region Событие на изменение модели
        /// <summary> Событие на изменение модели </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //Метод, который скажет ViewModel, что нужно передать виду новые данные
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion

        #region Открытие диалогового окна
        private void OpenDialogWindow(string textMessage)
        {
            Dialog_ViewModel messageBox_ViewModel = new Dialog_ViewModel(textMessage);
            MessageBox_View messageBox_View = new MessageBox_View();
            messageBox_View.Show();
        }
        #endregion
    }
    #endregion

    #region Вспомогательный класс для команд
    abstract class MyRegCommand : ICommand
    {
        protected Executors_ViewModel _executors_ViewModel;
        public MyRegCommand(Executors_ViewModel executors_ViewModel)
        {
            _executors_ViewModel = executors_ViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }

    #endregion
}
