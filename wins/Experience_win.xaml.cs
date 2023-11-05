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
    /// Логика взаимодействия для Experience_win.xaml
    /// </summary>
    public partial class Experience_win : Page
    {
        public Experience_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Experience> experiences = new List<Experience>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select e.id, e.proficiency_level as proficiency_level, l.name as language from experiences as e join languages as l on e.language_id = l.id", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Experience record = new Experience();
                        record.id = reader.GetInt32("id");
                        record.уровень_владения = reader.GetString("proficiency_level");
                        record.язык = reader.GetString("language");

                        experiences.Add(record);
                    }
                }
            }
            DGExperience.ItemsSource = experiences;
        }
    }
}
