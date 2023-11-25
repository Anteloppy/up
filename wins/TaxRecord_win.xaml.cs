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
    /// Логика взаимодействия для TaxRecord_win.xaml
    /// </summary>
    public partial class TaxRecord_win : Page
    {
        public TaxRecord_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<TaxRecord> taxRecords = new List<TaxRecord>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select t.id, t.date, t.type, t.amount, a.owner from tax_records as t join accounts as a on t.account = a.id", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TaxRecord record = new TaxRecord();
                        record.id = reader.GetInt32("id");
                        record.дата = DateOnly.FromDateTime(reader.GetDateTime("date"));
                        record.тип = reader.GetString("type");
                        record.сумма = reader.GetInt32("ammount");
                        record.счёт = reader.GetString("account");

                        taxRecords.Add(record);
                    }
                }
            }
            DGTaxRecord.ItemsSource = taxRecords;
        }
    }
}
