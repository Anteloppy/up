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

namespace up.add_wins
{
    /// <summary>
    /// Логика взаимодействия для TaxRecord_add.xaml
    /// </summary>
    public partial class TaxRecord_add : Page
    {
        public TaxRecord_add()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into tax_records(id, date, type, amount, account) values(" + Convert.ToInt32(TBtax_record_id.Text) + ", '" + DateOnly.FromDateTime(Convert.ToDateTime(TBdate.Text)) + "', '" + TBtype.Text + "' + " + Convert.ToDecimal(TBamount.Text) + ", '" + TBaccount.Text + "'); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("налоговый учёт добавлен");
        }
    }
}
