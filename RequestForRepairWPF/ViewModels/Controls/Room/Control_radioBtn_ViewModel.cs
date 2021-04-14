using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Controls.Room
{
    public class Control_radioBtn_ViewModel : ViewModel
    {
        private List<string> _typeNameList;
        public List<string> TypeNameList
        {
            set => Set(ref _typeNameList, value);
            get => _typeNameList;
        }
    }
}
