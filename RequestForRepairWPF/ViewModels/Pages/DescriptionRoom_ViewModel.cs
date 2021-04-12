using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.ViewModels.Pages
{
    public class DescriptionRoom_ViewModel : ViewModel
    {

        #region Тип помещения
        private int _roomNumber;
        public int RoomNumber
        {
            get => _roomNumber;
            set => Set(ref _roomNumber, value);
        }
        #endregion

        #region Тип помещения
        private string _typeRoom;
        public string TypeRoom
        {
            get => _typeRoom;
            set => Set(ref _typeRoom, value);
        }
        #endregion

        #region Описание помещения
        private string _descriptionRoom;
        public string DescriptionRoom
        {
            get => _descriptionRoom;
            set => Set(ref _descriptionRoom, value);
        }
        #endregion

        #region комментарий к помещению
        private string _commentRoom;
        public string CcommantRoom
        {
            get => _commentRoom;
            set => Set(ref _commentRoom, value);
        }
        #endregion
    }
}
