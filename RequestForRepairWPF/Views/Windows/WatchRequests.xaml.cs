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
using System.Windows.Shapes;

namespace RequestForRepairWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WatchRequests.xaml
    /// </summary>
    public partial class WatchRequests : Window
    {
        private int mainID = 0;
        private string typeRequest = string.Empty;

        public WatchRequests(int mainID, string typeRequest)
        {
            InitializeComponent();

            this.mainID = mainID;
            this.typeRequest = typeRequest;
        }
    }
}
