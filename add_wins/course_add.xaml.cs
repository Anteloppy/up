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
    /// Логика взаимодействия для course_add.xaml
    /// </summary>
    public partial class course_add : Page
    {
        public course_add()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into courses(name, duration, lvl, price, language_id) values('" + TBname.Text + "', '" + Convert.ToInt32(TBduration.Text) + "', '" + Convert.ToInt32(TBlvl.Text) + "', '" + Convert.ToInt32(TBprice.Text) + "', '" +  Convert.ToInt32(TBlanguage_id.Text) + "'); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("курс добавлен");
        }
    }
}