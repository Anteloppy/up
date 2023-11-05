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

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Page
    {
        public Report()
        {
            InitializeComponent();
        }

        private void RB1_Click(object sender, RoutedEventArgs e)
        {
            report1.Visibility = Visibility.Visible;
            report2.Visibility = Visibility.Hidden;
        }

        private void RB2_Click(object sender, RoutedEventArgs e)
        {
            report2.Visibility = Visibility.Visible;
            report1.Visibility = Visibility.Hidden;
        }
    }
}
