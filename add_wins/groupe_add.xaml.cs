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
    /// Логика взаимодействия для groupe_add.xaml
    /// </summary>
    public partial class groupe_add : Page
    {
        public groupe_add()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into groupes(course_id, client_id, teacher_id, point_quantity, load_point, schedule_id, attendance_id) values('" + Convert.ToInt32(TBcourse_id.Text) + "', '" + Convert.ToInt32(TBclient_id.Text) + "', '" + Convert.ToInt32(TBteacher_id.Text) + "', '" + Convert.ToInt32(TBpoint_quantity.Text) + "', '" + Convert.ToInt32(TBload_point.Text) + "', '" + Convert.ToInt32(TBschedule_id.Text) + "', '" + Convert.ToInt32(TBattendance_id.Text) + "'); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("группа добавлена");
        }
    }
}
