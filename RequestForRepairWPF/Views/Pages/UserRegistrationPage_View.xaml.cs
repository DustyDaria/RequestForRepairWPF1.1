﻿using System;
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

namespace RequestForRepairWPF.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserRegistrationPage_View.xaml
    /// </summary>
    public partial class UserRegistrationPage_View : Page
    {
        public UserRegistrationPage_View()
        {
            InitializeComponent();
        }
        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            this.btn_Edit.IsEnabled = !this.btn_Edit.IsEnabled;
        }

    }
}
