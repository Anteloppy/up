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
using up.add_wins;

namespace up
{
    /// <summary>
    /// Логика взаимодействия для add_win.xaml
    /// </summary>
    public partial class add_win : Window
    {
        public add_win() => InitializeComponent();

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void BAddCrop_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new CropAdd());
            Title = "Добавление в посевные площади";
        }

        private void BAddPlantVariety_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new PlantVarietyAdd());
            Title = "Добавление в сорта растений";
        }

        private void BAddLivestock_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new LivestockAdd());
            Title = "Добавление в поголовье скота";
        }

        private void BAddFarmingActivity_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new FarmingActivityAdd());
            Title = "Добавление в сельскохозяйственные работы";
        }

        private void BAddWorkPlan_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new WorkPlanAdd());
            Title = "Добавление в план работ";
        }
    }
}
