using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RequestForRepairWPF
{
    /// <summary>
    /// Логика взаимодействия для Menu_Executor.xaml
    /// </summary>
    /// 

    /* МЕНЮ ИСПОЛНПИТЕЛЯ
         * 
         * Просмотр текущих заявок ("Мои заявки")
         * Просмотр выполненных заявок ("Мои архивные заявки")
         * Редактирование личного профиля ("Редактировать личный профиль")
         * Создание отчёта ("Создать отчёт")
         */




    public partial class Menu_Executor : Window
    {
        int mainID = 0;

        public Menu_Executor(int userID)
        {
            InitializeComponent();

            mainID = userID;
        }
    }
}
