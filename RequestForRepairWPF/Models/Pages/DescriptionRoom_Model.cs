using RequestForRepairWPF.Data;
using RequestForRepairWPF.Data.Room;
using RequestForRepairWPF.Data.User;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Pages
{
    public class DescriptionRoom_Model : ViewModel
    {
        private Entities.DB_RequestForRepairEntities3 context = new Entities.DB_RequestForRepairEntities3();
        //U_R_Room _room = new U_R_Room();
        DescriptionRoom _descriptionRoom = new DescriptionRoom();
        TypeRoom _typeRoom = new TypeRoom();
        private int _idTypeRoom;
        private List<string> _typeRoomList = new List<string>();


        #region Возврат номера помещения заказчика (U_R_Room)
        public int RoomNumber
        {
            get
            {
                U_R_Room.roomNUMBER_URR = context.U_R_Room
                    .Where(c => c.userID_URR == User.id_user)
                    .Select(c => c.roomNUMBER_URR)
                    .FirstOrDefault();

                return U_R_Room.roomNUMBER_URR;
            }
        }
        #endregion

        #region Возврат id заказчика (U_R_Room)
        public int UserID
        {
            get
            {
                U_R_Room.userID_URR = User.id_user;

                return U_R_Room.userID_URR;
            }
        }
        #endregion

        #region Возврат id типа помещения заказчика (U_R_Room)
        public int ID_TypeRoom_URR
        {
            get
            {
                U_R_Room.id_type_room_URR = (int)context.U_R_Room
                    .Where(c => c.roomNUMBER_URR == U_R_Room.roomNUMBER_URR)
                    .Select(c => c.id_type_room_URR)
                    .FirstOrDefault();

                return U_R_Room.id_type_room_URR;
            }
        }
        #endregion

        #region Получение названия типа помещения (TypeRoom)
        private string _nameTypeRoom_TR;
        public string NameTypeRoom_TR
        {
            set => Set(ref _nameTypeRoom_TR, value);
        }
        #endregion

        #region Возврат id типа помещения по названию помещения (TypeRoom)
        public int ID_TypeRoom_TR
        {
            get
            {
                U_R_Room.id_type_room_URR = context.TypeRoom
                    .Where(c => c.name_type_room_TR == _nameTypeRoom_TR)
                    .Select(c => c.id_type_room_TR)
                    .FirstOrDefault();

                return U_R_Room.id_type_room_URR;
            }
        }
        #endregion

        #region Возврат описания помещения (DescriptionRoom)
        public string DescriptionRoom
        {
            get
            {
                _descriptionRoom.description_DR = context.DescriptionRoom
                    .Where(c => c.id_type_room_DR == U_R_Room.id_type_room_URR)
                    .Select(c => c.description_DR)
                    .FirstOrDefault();
                
                return _descriptionRoom.description_DR;
            }
        }
        #endregion

        #region Возврат комментария к описанию помещения
        public string CommentRoom
        {
            get
            {
                _descriptionRoom.comment_DR = context.DescriptionRoom
                    .Where(c => c.id_type_room_DR == U_R_Room.id_type_room_URR)
                    .Select(c => c.comment_DR)
                    .FirstOrDefault();
                return _descriptionRoom.comment_DR;
            }
        }
        #endregion

        #region Возврат типа помещения
        public string TypeRoom
        {
            get
            {
                _typeRoom.name_type_room_TR = context.TypeRoom
                    .Where(c => c.id_type_room_TR == U_R_Room.id_type_room_URR)
                    .Select(c => c.name_type_room_TR)
                    .FirstOrDefault();
                return _typeRoom.name_type_room_TR;
            }
        }
        #endregion

        #region Возврат списка всех типов помещения
        public List<string> TypeRoom_List
        {
            get
            {
                foreach(var l in context.TypeRoom)
                {
                    _typeRoomList.Add(l.name_type_room_TR);
                }

                return _typeRoomList;
            }
        }
        #endregion
    }
}
