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
using Org.BouncyCastle.Tls.Crypto;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Course_win.xaml
    /// </summary>
    public partial class Course_win : Page
    {
        public Course_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Course> courses = new List<Course>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select c.id, c.name as name, c.duration as duration, c.lvl as lvl, c.price as price, l.name as language from courses as c join languages as l on c.language_id = l.id", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Course record = new Course();
                        record.id = reader.GetInt32("id");
                        record.название = reader.GetString("name");
                        record.длительность = reader.GetInt32("duration");
                        record.уровень = reader.GetInt32("lvl");
                        record.цена = reader.GetInt32("price");
                        record.язык = reader.GetString("language");

                        courses.Add(record);
                    }
                }
            }
            DGCourse.ItemsSource = courses;
        }
    }
}
