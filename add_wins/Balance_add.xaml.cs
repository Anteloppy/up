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

namespace up.add_wins
{
    /// <summary>
    /// Логика взаимодействия для Balance_add.xaml
    /// </summary>
    public partial class Balance_add : Page
    {
        public Balance_add()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into balances(id, date, account, balance) values(" + Convert.ToInt32(TBbalance_id.Text) + ", '" + DateOnly.FromDateTime(Convert.ToDateTime(TBdate.Text)) + "', " + Convert.ToInt32(TBaccount.Text) + ", " + Convert.ToDecimal(TBbalance.Text) + "); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("аудит добавлен");
        }
    }
}
