using RequestForRepairWPF.DataGrid;
using RequestForRepairWPF.Models;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels
{
    class AllUsers_ViewModel : ViewModel
    {
        public AllUsers_Model m_model;

        public AllUsers_ViewModel() { }

        /// <summary>Загрузка данных</summary>
        #region Загрузка данных
        /// <summary>Загрузка данных</summary>
        
        public ObservableCollection<User> LoadData
        {
            get
            {
                m_model = new AllUsers_Model();
                return m_model.LoadData();
            }
        }

        #endregion

    }
}
