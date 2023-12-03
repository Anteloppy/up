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
using up.edit_wins;

namespace up
{
    /// <summary>
    /// Логика взаимодействия для edit_win.xaml
    /// </summary>
    public partial class edit_win : Window
    {
        public edit_win()
        {
            InitializeComponent();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }
        private void BEditCrop_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new CropEdit());
            Title = "Изменение в посевныех площадях";
        }
        private void BEditPlantVariety_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new PlantVarietyEdit());
            Title = "Изменение в сортах растений";
        }
        private void BEditLivestock_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new LivestockEdit());
            Title = "Изменение в поголовье скота";
        }
        private void BEditFarmingActivity_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new FarmingActivityEdit());
            Title = "Изменение в сельскохозяйственныех работах";
        }
        private void BEditWorkPlan_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new WorkPlanEdit());
            Title = "Изменение в плане работ";
        }
    }
}
