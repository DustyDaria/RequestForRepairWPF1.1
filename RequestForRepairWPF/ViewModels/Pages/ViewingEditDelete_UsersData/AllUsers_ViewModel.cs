using Caliburn.Micro;
using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models;
using RequestForRepairWPF.Models.Pages;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    class AllUsers_ViewModel : ViewModel
    {
        public BindableCollection<User_DataModel> AllUsers { get; set; }

        public AllUsers_ViewModel()
        {
            AllUsers_Model _model = new AllUsers_Model();
            AllUsers = new BindableCollection<User_DataModel>(_model.GetPeople(_model.AllIdUsers));
        }

        /// <summary>Загрузка данных</summary>
        #region Загрузка данных
        /// <summary>Загрузка данных</summary>
        
        //public ObservableCollection<User_DataModel> LoadData
        //{
        //   // get
        //   // {
        //   //     m_model = new AllUsers_Model();
        //   //     return m_model.LoadData();
        //   // }
        //}
        //
        #endregion

    }
}
