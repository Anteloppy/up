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
        private void BAddGroupe_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new groupe_add());
            Title = "Добавление в группы";
        }

        private void BAddCource_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new course_add());
            Title = "Добавление в курсы";
        }

        private void BAddTeacher_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new teacher_add());
            Title = "Добавление в преподаватели";
        }

        private void BAddSchedule_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new schedule_add());
            Title = "Добавление в рассписание";
        }

        private void BAddAttendance_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new attendance_add());
            Title = "Добавление в посещаемость";
        }

        private void BAddClient_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new client_add());
            Title = "Добавление в клиенты";
        }

        private void BAddExperience_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new experience_add());
            Title = "Добавление в опыт";
        }

        private void BAddLanguage_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new language_add());
            Title = "Добавление в языки";
        }

        private void BAddPayment_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new payment_add());
            Title = "Добавление в оплата";
        }
    }
}
