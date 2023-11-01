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
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Groupe> groupes = new List<Groupe>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from groupes", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Groupe record = new Groupe();
                        record.id = reader.GetInt32("id");
                        record.course_id = reader.GetInt32("course_id");
                        record.client_id = reader.GetInt32("client_id");
                        record.teacher_id = reader.GetInt32("teacher_id");
                        record.point_quantity = reader.GetInt32("point_quantity");
                        record.load_point = reader.GetInt32("load_point");
                        record.schedule_id = reader.GetInt32("schedule_id");
                        record.attendance_id = reader.GetInt32("attendance_id");

                        groupes.Add(record);
                    }
                }
            }
            DGGroupe.ItemsSource = groupes;
        }
    }
}
