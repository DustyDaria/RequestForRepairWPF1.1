using RequestForRepairWPF.Infrastructure.Commands.Base;
using RequestForRepairWPF.ViewModels.Base;
using RequestForRepairWPF.Views.DialogWindows;
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
        #region Конструкторы
        public MessageBox_ViewModel(string text)
        {
            TextMessage = text;
        }

        public MessageBox_ViewModel()
        {
            //#region Команды
            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            //#endregion
        }
        #endregion

        #region Сообщение для пользователя
        private static string _textMessage;
        public string TextMessage
        {
            get => _textMessage;
            set => Set(ref _textMessage, value);
        }
        #endregion

        #region Закрыть окно (при биндинге кнопка отключается)
        //public ICommand CloseApplicationCommand { get; }
        //
        //private bool CanCloseApplicationCommandExecute(object p) => true;
        //private void OnCloseApplicationCommandExecuted(object p)
        //{
        //    MessageBox_View messageBox_View = new MessageBox_View();
        //    messageBox_View.Close();
        //    this.Close();
        //}

        public bool CanClose { get; set; }

        private RelayCommand closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (closeCommand == null)
                {
                    closeCommand = new RelayCommand(param => Close(), param => CanClose);
                }
                return closeCommand;
            }
        }

        public void Close()
        {
            this.Close();
        }

        #endregion

    }
}
