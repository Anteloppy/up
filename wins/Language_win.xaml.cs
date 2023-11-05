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
    /// Логика взаимодействия для Language_win.xaml
    /// </summary>
    public partial class Language_win : Page
    {
        public Language_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Language> languages = new List<Language>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from languages", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Language record = new Language();
                        record.id = reader.GetInt32("id");
                        record.язык = reader.GetString("name");

                        languages.Add(record);
                    }
                }
            }
            DGLanguage.ItemsSource = languages;
        }
    }
}
