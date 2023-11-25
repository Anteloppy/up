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
    /// Логика взаимодействия для IncomeExpense_win.xaml
    /// </summary>
    public partial class IncomeExpense_win : Page
    {
        public IncomeExpense_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<IncomeExpense> incomeExpenses = new List<IncomeExpense>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, date, type, category, amount from income_expenses", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IncomeExpense record = new IncomeExpense();
                        record.id = reader.GetInt32("id");
                        record.дата = DateOnly.FromDateTime(reader.GetDateTime("datetime"));
                        record.тип = reader.GetString("type");
                        record.категория = reader.GetString("category");
                        record.сумма = reader.GetDecimal("amount");

                        incomeExpenses.Add(record);
                    }
                }
            }
            DGIncomeExpense.ItemsSource = incomeExpenses;
        }
    }
}
