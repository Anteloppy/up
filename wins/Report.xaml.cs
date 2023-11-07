using System.Windows.Controls.DataVisualization.Charting;
using MySql.Data.MySqlClient;
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
using System.Windows.Markup;

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
            reportShow(0);
        }

        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";

        private void RB1_Click(object sender, RoutedEventArgs e)
        {
            ch1.Series.Clear();
            var data = new List<KeyValuePair<string, int>>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select year(curdate()) - year(birth_date) as возраст, count(*) as сумма from clients  group by возраст;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        int age = reader.GetInt32("возраст");
                        int count = reader.GetInt32("сумма");

                        data.Add(new KeyValuePair<string, int>(age.ToString(), count));
                    }
                }
                conn.Close();
            }
            var dataSeries = new ColumnSeries()
            {
                ItemsSource = data,
                DependentValuePath = "Value",
                IndependentValuePath = "Key"
            };
            ch1.Series.Add(dataSeries);

            reportShow(1);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select avg(year(curdate()) - year(birth_date)) as средний_возраст from clients;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double averageAge = reader.GetDouble("средний_возраст");
                        l1.Content = $"Средний возраст клиентов: {averageAge:F2} лет";
                    }
                }
                conn.Close();
            }
        }

        private void RB2_Click(object sender, RoutedEventArgs e)
        {
            ch2.Series.Clear();
            var data = new List<KeyValuePair<string, int>>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select courses.name, sum(load_point) as sum_clients from groupes join courses on groupes.course_id = courses.id group by courses.name;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int sum = reader.GetInt32("sum_clients");

                        data.Add(new KeyValuePair<string, int>(name, sum));
                    }
                }
                conn.Close();
            }
            var dataSeries = new ColumnSeries()
            {
                ItemsSource = data,
                DependentValuePath = "Value",
                IndependentValuePath = "Key"
            };
            ch2.Series.Add(dataSeries);

            reportShow(2);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select courses.name, sum(load_point) as sum_clients from groupes join courses on groupes.course_id = courses.id group by courses.name order by sum_clients desc limit 1;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString("name");
                        int sum = reader.GetInt32("sum_clients");
                        l2.Content = $"Самый популярный курс: {name}, количество клиентов: {sum}";
                    }
                }
                conn.Close();
            }
        }

        private void RB3_Click(object sender, RoutedEventArgs e)
        {
            ch3.Series.Clear();
            var data = new List<KeyValuePair<string, int>>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select courses.name as курс, count(payments.client_id) - count(clients.id) as не_оплатили from payments join clients on payments.client_id = clients.id join courses on payments.course_id = courses.id group by courses.name;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string name = reader.GetString("курс");
                        int no_paid = reader.GetInt32("не_оплатили");

                        data.Add(new KeyValuePair<string, int>(name, no_paid));
                    }
                }
                conn.Close();
            }
            var dataSeries = new ColumnSeries()
            {
                ItemsSource = data,
                DependentValuePath = "Value",
                IndependentValuePath = "Key"
            };
            ch3.Series.Add(dataSeries);

            reportShow(3);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select count(payments.client_id) - count(clients.id) as не_оплатило from payments join clients on payments.client_id = clients.id;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int no_paid = reader.GetInt32("не_оплатило");
                        l3.Content = $"Всего не оплатило: {no_paid} человек";
                    }
                }
                conn.Close();
            }
        }

        private void RB4_Click(object sender, RoutedEventArgs e)
        {
            ch4.Series.Clear();
            var data = new List<KeyValuePair<string, int>>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select courses.name as курс, (attendances.visiting/groupes.load_point) * 100 as процент_ходящих from groupes join attendances on groupes.attendance_id = attendances.id join courses on groupes.course_id = courses.id;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string name = reader.GetString("курс");
                        int procent = reader.GetInt32("процент_ходящих");

                        data.Add(new KeyValuePair<string, int>(name, procent));
                    }
                }
                conn.Close();
            }
            var dataSeries = new ColumnSeries()
            {
                ItemsSource = data,
                DependentValuePath = "Value",
                IndependentValuePath = "Key"
            };
            ch4.Series.Add(dataSeries);

            reportShow(4);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select courses.name as курс, (attendances.visiting/groupes.load_point) * 100 as процент_ходящих from groupes join attendances on groupes.attendance_id = attendances.id join courses on groupes.course_id = courses.id order by процент_ходящих asc limit 1;", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString("курс");
                        int procent = reader.GetInt32("процент_ходящих");
                        l4.Content = $"Самый непосещаемый курс: {name}, процент посещения: {procent}%";
                    }
                }
                conn.Close();
            }
        }
        public void reportShow(int r)
        {
            report1.Visibility = Visibility.Hidden;
            report2.Visibility = Visibility.Hidden;
            report3.Visibility = Visibility.Hidden;
            report4.Visibility = Visibility.Hidden;
            switch (r)
            {
                case 1: report1.Visibility = Visibility.Visible; break;
                case 2: report2.Visibility = Visibility.Visible; break;
                case 3: report3.Visibility = Visibility.Visible; break;
                case 4: report4.Visibility = Visibility.Visible; break;
                default: break;
            }
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
