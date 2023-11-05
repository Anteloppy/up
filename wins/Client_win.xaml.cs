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
    /// Логика взаимодействия для Clients_win.xaml
    /// </summary>
    public partial class Client_win : Page
    {
        public Client_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Client> clients = new List<Client>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from clients", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Client record = new Client();
                        record.id = reader.GetInt32("id");
                        record.имя = reader.GetString("name");
                        record.фамилия = reader.GetString("surname");
                        record.контакты = reader.GetString("contact");
                        record.дата_рождения = DateOnly.FromDateTime(reader.GetDateTime("birth_date"));
                        record.опыт = reader.GetInt32("experience_id");
                        record.потребности = reader.GetString("requirement");

                        clients.Add(record);
                    }
                }
            }
            DGClient.ItemsSource = clients;
        }
    }
}
