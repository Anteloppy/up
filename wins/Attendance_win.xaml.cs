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
using System.Data;
using System.Configuration;
using up.entities;
using System.Runtime.Remoting.Messaging;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Attendance_win.xaml
    /// </summary>
    public partial class Attendance_win : Page
    {
        public Attendance_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Attendance> attendances = new List<Attendance>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select a.id, concat(s.day, ' ', s.time) as schedule, concat(a.visiting, ' человек') as visiting from attendances as a join schedules as s on a.schedule_id = s.id", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attendance record = new Attendance();
                        record.id = reader.GetInt32("id");
                        string sh = reader.GetString("schedule");
                        sh = sh.Replace(" 1990-01-01 ", " ");
                        record.расписание = Convert.ToDateTime(sh);
                        record.посещаемость = reader.GetString("visiting");

                        attendances.Add(record);
                    }
                }
            }
            DGAttendance.ItemsSource = attendances;
        }
    }
}
