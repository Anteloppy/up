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

        private void BAdd_Click(object sender, RoutedEventArgs e)
        {
            add_win a = new add_win();
            a.Show();
        }

        private void BRemove_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BGroupe_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Groupe_win());
            Title = "Группы";
        }

        private void BCource_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Course_win());
            Title = "Курсы";
        }

        private void BTeacher_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Teacher_win());
            Title = "Преподаватели";
        }

        private void BSchedule_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Schedule_win());
            Title = "Рассписание";
        }

        private void BAttendance_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Attendance_win());
            Title = "Посещаемость";
        }

        private void BClient_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Client_win());
            Title = "Клиенты";
        }

        private void BExperience_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Experience_win());
            Title = "Опыт";
        }

        private void BLanguage_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Language_win());
            Title = "Языки";
        }

        private void BPayment_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Payment_win());
            Title = "Оплата";
        }

        private void BReport_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Report());
            Title = "Отчёты";
        }
    }
}
