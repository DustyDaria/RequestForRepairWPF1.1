using Caliburn.Micro;
using RequestForRepairWPF.Data.Request;
using RequestForRepairWPF.Models.Pages.ViewingEditDelete_Request;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Pages.Request
{
    public class MyRequest_ViewModel : ViewModel
    {
        private BindableCollection<Request_DataModel> _myRequest;
        public BindableCollection<Request_DataModel> MyRequest
        {
            get => _myRequest;
            set => Set(ref _myRequest, value);
        }

        public MyRequest_ViewModel()
        {
            #region Загрузка данных
            Request_DataModel.AllRequestID.Clear();

            AllRequest_Model _model = new AllRequest_Model();
            MyRequest = new BindableCollection<Request_DataModel>(_model.GetAllMyRequests(_model.AllIdRequest_my));
            #endregion
        }
    }
}
