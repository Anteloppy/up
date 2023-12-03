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
        int a;
        public add_win()
        {
            InitializeComponent();
            switch(a)
            {
                case 1:
                    frameM.Navigate(new CropAdd());
                    Title = "Добавление в посевные площади";
                    break;
                case 2:
                    frameM.Navigate(new PlantVarietyAdd());
                    Title = "Добавление в сорта растений";
                    break;
                case 3:
                    frameM.Navigate(new LivestockAdd());
                    Title = "Добавление в поголовье скота";
                    break;
                case 4:
                    frameM.Navigate(new FarmingActivityAdd());
                    Title = "Добавление в сельскохозяйственные работы";
                    break;
                case 5:
                    frameM.Navigate(new WorkPlanAdd());
                    Title = "Добавление в план работ";
                    break;
            }
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            switch (a)
            {
                case 1:
                    m.frameM.Navigate(new CropWin());
                    Title = "Посевные площади";
                    break;
                case 2:
                    m.frameM.Navigate(new PlantVarietyWin());
                    Title = "Сорта растений";
                    break;
                case 3:
                    m.frameM.Navigate(new LivestockWin());
                    Title = "Поголовье скота";
                    break;
                case 4:
                    m.frameM.Navigate(new FarmingActivityWin());
                    Title = "Сельскохозяйственные работы";
                    break;
                case 5:
                    m.frameM.Navigate(new WorkPlanWin());
                    Title = "План работ";
                    break;
            }
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
