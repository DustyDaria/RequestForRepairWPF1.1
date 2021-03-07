using RequestForRepairWPF.Data;
using RequestForRepairWPF.Models;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels
{
    class Executors_ViewModel : ViewModel
    {
        
        public Executor_Model m_model;
        

        //ExecutorContext db = new ExecutorContext();
        public Executors_ViewModel()
        {
            //m_model = new Executor_Model();
            //m_model.LoadRequestID();
            //m_model.LoadData();
        }
        /// <summary>Загрузка данных</summary>
        #region Загрузка данных
        /// <summary>Загрузка данных</summary>
        /*public ObservableCollection<Executor> LoadData
        {
            get
            {
                m_model = new Executor_Model();
                return m_model.LoadData();
            }
        }*/

        ///// <summary>Загрузка заявок в comboBox</summary>
        //public ObservableCollection<U_R_Executor_Custom> LoadRequestID
        //{
        //    get
        //    {
        //        m_model = new Executor_Model();
        //        return m_model.LoadRequestID();
        //    }
        //}
        #endregion


        ///<summary>Выбор исполнителя</summary>
        #region Выбор исполнителя

        ///<summary>Выбор исполнителя</summary>

        //private Executor _selectedExecutor;
        //public Executor SelectedExecuor
        //{
        //    get => _selectedExecutor;
        //    //set => Set(ref _selectedExecutor, value);
        //
        //}

        #endregion



        ///<summary>Выбор критерия для поиска</summary>
        #region Выбор критерия для поиска

        private string _criteriaSearch;
        ///<summary>Выбор критерия для поиска</summary>
        public string CriteriaSearch
        {
            set => Set(ref _criteriaSearch, value);
        }
        #endregion


        /*
        ///<summary>Поиск</summary>
        #region Поиск

        ///<summary>Поиск</summary>

        private string _dataForSearch;

        public ObservableCollection<Executor> DataForSearch
        {
            set
            {
                Set(ref _dataForSearch, value);
            }

            //get
            //{
            //    m_model = new Executor_Model(_criteriaSearch, _dataForSearch);
            //    return m_model.SearchData;
            //
            //}
        }

        #endregion
        */

        #region Команды

        #region Поиск
        public ICommand SearchDataCommand { get; }
        private bool CanSearchDataCommandExecute(object p) => true;
        /*private ObservableCollection<Executor> OnSearchDataCommandExecuted(object p)
        {
            /// обработка поиска ????????????7
            //return DataForSearch;
        executorObj.SearchData();
            
        }*/
        #endregion


        #endregion

        /*public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }*/
    }
}
