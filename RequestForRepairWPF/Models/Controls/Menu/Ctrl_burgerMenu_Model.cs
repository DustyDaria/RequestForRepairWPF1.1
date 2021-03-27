using RequestForRepairWPF.Data;
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
        int _idUser;
        my_DbContext db = new my_DbContext(); 
        public string GetType
        {
            get
            {
                var query = from c in db.Users
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
                OnPropertyChanged("GetType");
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
