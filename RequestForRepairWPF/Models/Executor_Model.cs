using Prism.Mvvm;
using RequestForRepairWPF.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Data.Linq.SqlClient.SqlMethods.Like;

namespace RequestForRepairWPF.Models
{
    public class Executor_Model : INotifyPropertyChanged
    {
        private readonly Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();
        //public ObservableCollection<Executor> ExecutorsCollection = new ObservableCollection<Executor>();
        //public ObservableCollection<U_R_Executor_Custom> U_R_ExecutorCollection = new ObservableCollection<U_R_Executor_Custom>();

        U_R_Executor_Custom u_r_executorObj = new U_R_Executor_Custom();
        Executor executorObj = new Executor();
        private string criteriaSearch;
        private string dataForSearch;

        /// <summary>Конструкторы</summary>
        #region Конструкторы
        /// <summary>Конструкторы</summary>
         
        public Executor_Model(string criteriaSearch, string dataForSearch)
        {
            this.criteriaSearch = criteriaSearch;
            this.dataForSearch = dataForSearch;
        }
        public Executor_Model() { }
        public Executor_Model(int id_user, string user_login, string last_name, string name, string middle_name, string position, string phone, string category_executors, int requestID_URE)
        {
            executorObj.id_user = id_user;
            executorObj.user_login = user_login;
            executorObj.last_name = last_name;
            executorObj.name = name;
            executorObj.middle_name = middle_name;
            executorObj.position = position;
            executorObj.phone = phone;
            executorObj.category_executors = category_executors;
            //executorObj.requestID_URE = requestID_URE;
        }
        #endregion


        // Нужно будет добавить SET при реализации редактирования
        /// <summary>GET,SET</summary>
        #region GET,SET
        /// <summary>GET,SET</summary>
        public int Id_user
        {
            get
            {
                return executorObj.id_user;
            }
        } 
        public string User_login
        {
            get
            {
                return executorObj.user_login;
            }
        }
        public string Last_name
        {
            get
            {
                return executorObj.last_name;
            }
        }
        public string Name
        {
            get
            {
                return executorObj.name;
            }
        }
        public string Middle_name
        {
            get
            {
                return executorObj.middle_name;
            }
        }
        public string Position
        {
            get
            {
                return executorObj.position;
            }
        }
        public string Phone
        {
            get
            {
                return executorObj.phone;
            }
        }
        public string Category_executors
        {
            get
            {
                return executorObj.category_executors;
            }
        } 
        //public int RequestID_URE
        //{
        //    get
        //    {
        //        return executorObj.requestID_URE;
        //    }
        //}
        #endregion

        /*public ObservableCollection<U_R_Executor_Custom> LoadRequestID()
        {
            var executors = context.Users
                .Where(t => t.type_of_account == "Исполнитель")
                .ToList()
                .ConvertAll(u => new U_R_Executor_Custom(u));
            foreach(var executor in executors)
            {
                executorObj.loadRequestIDCollection.Add(executor);
                //MessageBox.Show(Convert.ToString(U_R_ExecutorCollection.First()));
            }
            return executorObj.loadRequestIDCollection;
        }*/

        /// <summary>Загрузка данных</summary>
        #region Загрузка данных

        /// <summary>Загрузка данных</summary>
        /*public ObservableCollection<Executor> LoadData()
        {
            var _context = context.Users;

            var _query = _context.ToList()
                .ConvertAll(e => new Executor(e));
            foreach (var exe in _query)
            {
                ExecutorsCollection.Add(new Executor
                {
                    id_user = exe.id_user,
                    user_login = exe.user_login,
                    last_name = exe.last_name,
                    name = exe.name,
                    middle_name = exe.middle_name,
                    position = exe.position,
                    phone = exe.phone,
                    category_executors = exe.category_executors,
                    //loadRequestIDCollection = exe.loadRequestIDCollection
                });
            }
            return ExecutorsCollection;
        }*/
        #endregion


        /// <summary>Поиск данных</summary>
        #region Поиск данных
        /// <summary>Поиск данных </summary>
        /*public ObservableCollection<Executor> SearchData
        {
            //var query = db.Executors.Where(p => p.criteriaSearch == "%{dataForSearch}%");
            //IEnumerable<Executor> querySearch = (IEnumerable<Executor>)(from item in db.Executors select db.Users Where );
            get
            {
                //IQueryable<Entities.Executors> querySearch = db.Executors.Where(p => p.criteriaSearch == dataForSearch);
                //int data = Convert.ToInt32(dataForSearch);
                var _querySearch = context.Users.Where(p => p.name == dataForSearch);
                foreach (var exe in _querySearch)
                {
                    ExecutorsCollection.Add(new Executor
                    {
                        id_user = exe.id_user,
                        user_login = exe.user_login,
                        last_name = exe.last_name,
                        name = exe.name,
                        middle_name = exe.middle_name,
                        position = exe.position,
                        phone = exe.phone,
                        category_executors = exe.category_executors,
                        //requestID_URE = exe.requestID_URE
                    });
                }
                OnPropertyChanged("SearchData");
                return ExecutorsCollection;
            }
        }*/


        #endregion


        /// <summary>Событие на изменение модели</summary>
        #region Событие на изменение модели
        /// <summary>Событие на изменение модели</summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") //Метод, который скажет ViewModel, что нужно передать виду новые данные
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
