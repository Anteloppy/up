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
using MySql.Data.MySqlClient;
using up.entities;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Shedule_win.xaml
    /// </summary>
    public partial class Schedule_win : Page
    {
        public Schedule_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Schedule> schedules = new List<Schedule>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, day, time from schedules", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Schedule record = new Schedule();
                        record.id = reader.GetInt32("id");
                        record.день = DateOnly.FromDateTime(reader.GetDateTime("day"));
                        record.время = TimeOnly.FromDateTime(reader.GetDateTime("time"));

                        schedules.Add(record);
                    }
                }
            }
            DGSchedule.ItemsSource = schedules;
        }
    }
}
