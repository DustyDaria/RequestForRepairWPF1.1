using RequestForRepairWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RequestForRepairWPF.ViewModels.DialogWindows
{
    public class MessageBox_ViewModel : ViewModel
    {
        #region Сообщение для пользователя
        private static string _textMessage;
        public string TextMessage
        {
            get => _textMessage;
            set => Set(ref _textMessage, value);
        }
        #endregion

        #region Закрыть окно
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

    }
}
