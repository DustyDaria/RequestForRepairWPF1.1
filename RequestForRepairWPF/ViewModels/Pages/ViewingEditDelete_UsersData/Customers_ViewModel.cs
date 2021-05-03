using Caliburn.Micro;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_UsersData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Pages.ViewingEditDelete_UsersData
{
    public class Customers_ViewModel
    {
        public BindableCollection<User_DataModel> AllCustomers { get; set; }
        public Customers_ViewModel()
        {
            #region Загрузка данных
            Customers_Model _model = new Customers_Model();
            AllCustomers = new BindableCollection<User_DataModel>(_model.GetPeople(_model.AllIdUsers));
            #endregion
        }
    }
}
