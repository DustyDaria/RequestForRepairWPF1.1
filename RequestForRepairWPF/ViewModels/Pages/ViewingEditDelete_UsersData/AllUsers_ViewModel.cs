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
    public class AllUsers_ViewModel : ViewModel
    {
        private BindableCollection<User_DataModel> _allUsers;
        public BindableCollection<User_DataModel> AllUsers
        {
            get => _allUsers;
            set => Set(ref _allUsers, value);
        }

        public AllUsers_ViewModel()
        {
            /// <summary>Загрузка данных</summary>
            #region Загрузка данных
            /// <summary>Загрузка данных</summary>
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllUsers = new BindableCollection<User_DataModel>(_model.GetPeople_All(_model.AllIdUsers_All));
            #endregion
        }
    }
}
