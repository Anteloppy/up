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
using System.Xml.Linq;

namespace up.add_wins
{
    /// <summary>
    /// Логика взаимодействия для schedule_add.xaml
    /// </summary>
    public partial class schedule_add : Page
    {
        public schedule_add()
        {
            InitializeComponent();
        }

        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string t = "1990.01.01 " + TBtime.Text;
            string add = "insert into schedules(day, time) values('" + TBday.Text + "', '" + t + "'); commit;";
            //string[] tp = TBtime.Text.Split(':');
            //int h = int.Parse(tp[0]), m = int.Parse(tp[1]), s = int.Parse(tp[2]);
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("рассписание добавлено");
        }
    }
}
