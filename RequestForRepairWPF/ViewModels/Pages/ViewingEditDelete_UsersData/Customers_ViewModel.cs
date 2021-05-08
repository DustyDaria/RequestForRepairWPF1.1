using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    public class Customers_ViewModel : ViewModel
    {
        private BindableCollection<User_DataModel> _allCustomers;
        public BindableCollection<User_DataModel> AllCustomers
        {
            get => _allCustomers;
            set => Set(ref _allCustomers, value);
        }

        public Customers_ViewModel()
        {
            #region Загрузка данных
            User_DataModel.AllUsersID.Clear();

            AllUsers_Model _model = new AllUsers_Model();
            AllCustomers = new BindableCollection<User_DataModel>(_model.GetPeople_Customers(_model.AllIdUsers_Customers));
            #endregion
        }
    }
}
