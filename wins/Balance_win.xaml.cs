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
    /// Логика взаимодействия для Balance_win.xaml
    /// </summary>
    public partial class Balance_win : Page
    {
        public Balance_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Balance> balances = new List<Balance>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select b.id, b.date, a.owner, b.balance from balance as b join accounts as a on b.account = a.id", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Balance record = new Balance();
                        record.id = reader.GetInt32("id");
                        record.дата = DateOnly.FromDateTime(reader.GetDateTime("datetime"));
                        record.счёт = reader.GetString("account");
                        record.баланс = reader.GetDecimal("balance");

                        balances.Add(record);
                    }
                }
            }
            DGBalance.ItemsSource = balances;
        }
    }
}
