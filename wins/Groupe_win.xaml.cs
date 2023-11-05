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

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Groupe_win.xaml
    /// </summary>
    public partial class Groupe_win : Page
    {
        public Groupe_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Groupe> groupes = new List<Groupe>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select g.id, c.name as course, concat(cl.name, ' ', cl.surname) as client, concat(t.name, ' ', t.surname) as teacher, g.point_quantity, g.load_point, concat(s.day, ' ', s.time) as schedule, concat(a.visiting, ' человек из ', load_point) as attendance from groupes as g join courses as c on g.course_id = c.id join clients as cl on g.client_id = cl.id join teachers as t on g.teacher_id = t.id join schedules as s on g.schedule_id = s.id join attendances as a on g.attendance_id = a.id", conn);
                

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Groupe record = new Groupe();
                        record.id = reader.GetInt32("id");
                        record.курс = reader.GetString("course");
                        record.клиент = reader.GetString("client");
                        record.преподаватель = reader.GetString("teacher");
                        record.мест = reader.GetInt32("point_quantity");
                        record.занято = reader.GetInt32("load_point");
                        record.рассписание = reader.GetString("schedule");
                        record.посещаемость = reader.GetString("attendance");

                        groupes.Add(record);
                    }
                }
            }
            DGGroupe.ItemsSource = groupes;
        }
    }
}
