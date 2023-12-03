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
using up.entities;
using up.wins;

namespace up
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            add_win a = new add_win();
            a.Show();
            this.Close();
        }

        private void BCrop_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new CropWin());
            Title = "Посевные площади";
        }

        private void BPlantVariety_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new PlantVarietyWin());
            Title = "Сорта растений";
        }

        private void BLivestock_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new LivestockWin());
            Title = "Поголовье скота";
        }

        private void BFarmingActivity_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new FarmingActivityWin());
            Title = "Сельскохозяйственные работы";
        }

        private void BWorkPlan_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new WorkPlanWin());
            Title = "План работ";
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_win edit = new edit_win();
            edit.Show();
            //this.Close();
        }
    }
}
