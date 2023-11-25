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
using up.entities;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для User_win.xaml
    /// </summary>
    public partial class User_win : Page
    {
        public User_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<User> users = new List<User>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, name, surname, nickname, password, role from users", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User record = new User();
                        record.id = reader.GetInt32("id");
                        record.имя = reader.GetString("name");
                        record.фамилия = reader.GetString("surname");
                        record.ник = reader.GetString("nickname");
                        record.пароль = reader.GetString("password");
                        record.роль = reader.GetString("role");

                        users.Add(record);
                    }
                }
            }
            DGUser.ItemsSource = users;
        }
    }
}
