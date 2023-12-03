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
using up.wins;

namespace up.edit_wins
{
    /// <summary>
    /// Логика взаимодействия для FarmingActivityEdit.xaml
    /// </summary>
    public partial class FarmingActivityEdit : Page
    {
        public FarmingActivityEdit()
        {
            InitializeComponent();
        }
        public FarmingActivityEdit(int ID, string ActivityName, string StartDate, string EndDate, string Description)
        {
            InitializeComponent();
            TBid.Text = Convert.ToString(ID);
            TBactivity_name.Text = ActivityName;
            TBstart_date.Text = StartDate;
            TBend_date.Text = EndDate;
            TBdescription.Text = Description;
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TBid.Text);
            string edit = "update FarmingActivities set ActivityName = '" + TBactivity_name.Text + "', StartDate = '" + TBstart_date.Text + "', EndDate = '" + TBend_date.Text + "', Description = '" + TBdescription.Text + "' where ID = @id; commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("сельскохозяйственная работа с ID " + id + " изменена");
        }
    }
}
