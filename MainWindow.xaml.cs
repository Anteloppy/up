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

        private void BAccount_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Account_win());
            Title = "Аккаунты";
        }

        private void BAuditLog_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new AuditLog_win());
            Title = "Аудиты";
        }

        private void BBalance_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Balance_win());
            Title = "Баланс";
        }

        private void BClient_Click_1(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Client_win());
            Title = "Клиенты";
        }

        private void BFinancialTransaction_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new FinancialTransaction_win());
            Title = "Финансовые операции";
        }

        private void BIncomeExpense_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new IncomeExpense_win());
            Title = "Доходы и расходы";
        }

        private void BSupplier_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new Supplier_win());
            Title = "Поставщики";
        }

        private void BTaxRecord_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new TaxRecord_win());
            Title = "Налоговый учёт";
        }

        private void BUser_Click(object sender, RoutedEventArgs e)
        {
            frameM.Navigate(new User_win());
            Title = "Пользователи";
        }
    }
}
