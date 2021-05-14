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
    public class AllRequest2_ViewModel : ViewModel
    {
        private BindableCollection<Request_DataModel> _allRequest;
        public BindableCollection<Request_DataModel> AllRequest
        {
            get => _allRequest;
            set => Set(ref _allRequest, value);
        }

        public AllRequest2_ViewModel()
        {
            #region Загрузка данных
            Request_DataModel.AllRequestID.Clear();

            AllRequest_Model _model = new AllRequest_Model();
            AllRequest = new BindableCollection<Request_DataModel>(_model.GetAllRequests(_model.AllIdRequest_all));
            #endregion
        }
    }
}
