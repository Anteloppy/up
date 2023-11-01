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
        public MainWindow()
        {
            InitializeComponent();
            //frameS.Navigate(new side_menu());
        }
        

        private void BGroupe_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Groupe_win());

        private void BCource_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Course_win());

        private void BTeacher_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Teacher_win());

        private void BSchedule_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Schedule_win());

        private void BAttendance_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Attendance_win());

        private void BClients_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Clients_win());

        private void BExperience_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Experience_win());

        private void BLanguage_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Language_win());

        private void BPayment_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Payment_win());

        private void BReport_Click(object sender, RoutedEventArgs e) => frameM.Navigate(new Report());
    }
}
