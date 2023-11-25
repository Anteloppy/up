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
    /// Логика взаимодействия для FinancialTransaction_win.xaml
    /// </summary>
    public partial class FinancialTransaction_win : Page
    {
        public FinancialTransaction_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<FinancialTransaction> financialTransactions = new List<FinancialTransaction>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select f.id, f.date, f.type, f.amount, s.owner, r.owner from financial_transactions as f join accounts as s on f.sender = s.id join accounts as r on f.receiver = r.id", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FinancialTransaction record = new FinancialTransaction();
                        record.id = reader.GetInt32("id");
                        record.дата = DateOnly.FromDateTime(reader.GetDateTime("datetime"));
                        record.тип = reader.GetString("type");
                        record.отправитель = reader.GetString("sender");
                        record.получатель = reader.GetString("receiver");

                        financialTransactions.Add(record);
                    }
                }
            }
            DGFinancialTransaction.ItemsSource = financialTransactions;
        }
    }
}
