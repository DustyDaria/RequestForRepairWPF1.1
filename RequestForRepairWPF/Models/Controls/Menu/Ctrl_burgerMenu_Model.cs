using RequestForRepairWPF.Data;
using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RequestForRepairWPF.Models.Controls.Menu
{
    public class Ctrl_burgerMenu_Model : INotifyPropertyChanged
    {
        private int _idUser;
        private Entities.DB_RequestForRepairEntities context = new Entities.DB_RequestForRepairEntities();

        public string UserType
        {
            get
            {
                var query = from c in context.Users
                            where c.id_user == _idUser
                            select new
                            {
                                c.type_of_account
                            };
                return Convert.ToString(query);
            }
            set
            {
                _idUser = Convert.ToInt32(value);
                OnPropertyChanged("UserType");
            }
        }


        /// <summary> Событие на изменение модели </summary>
        #region Событие на изменение модели
        /// <summary> Событие на изменение модели </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        //Метод, который скажет ViewModel, что нужно передать виду новые данные
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}
