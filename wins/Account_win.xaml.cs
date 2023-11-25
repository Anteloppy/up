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
    /// Логика взаимодействия для Account_win.xaml
    /// </summary>
    public partial class Account_win : Page
    {
        public Account_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Account> accounts= new List<Account>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select a.id, a.balance, c.company_name from accounts as a join clients as c on a.owner = c.id", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account record = new Account();
                        record.id = reader.GetInt32("id");
                        record.баланс = reader.GetDecimal("balance");
                        record.владелец = reader.GetString("owner");

                        accounts.Add(record);
                    }
                }
            }
            DGAccount.ItemsSource = accounts;
        }
    }
}
