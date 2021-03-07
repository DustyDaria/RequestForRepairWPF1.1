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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RequestForRepairWPF.Views.Controls.Room
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class Control_radioBtn : UserControl
    {
        DataBase dataBase = new DataBase();
        List<string> typeList = new List<string>();
        public Control_radioBtn()
        {
            InitializeComponent();

            string queryCountType_GET = string.Format("SELECT COUNT(DISTINCT id_type_room_TR) FROM TypeRoom;");
            string queryTypeRoom_GET = string.Format("SELECT DISTINCT name_type_room_TR FROM TypeRoom;");
            
            typeList = dataBase.GetResultList(queryTypeRoom_GET);
            
            for (int i = 0; i < dataBase.GetID(queryCountType_GET); i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = typeList[i];
                radioButton.Margin = new System.Windows.Thickness(5);
                //radioButton.FontSize = new System.Windows.FontSizeConverter(12);
                radioButton.VerticalAlignment = VerticalAlignment.Center;
                radioButton.GroupName = "TypeRoom";
                radioButton.Checked += new RoutedEventHandler(RadioButton_Checked);
                panelForRadioBtn.Children.Add(radioButton);
            }
        }
        public string SelectedValue { get; set; }

        public void GetValue(string content)
        {

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton item)
            {
                SelectedValue = item.Content.ToString();
            }
        }
    }
}
