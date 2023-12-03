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
    /// Логика взаимодействия для WorkPlanEdit.xaml
    /// </summary>
    public partial class WorkPlanEdit : Page
    {
        public WorkPlanEdit()
        {
            InitializeComponent();
        }
        public WorkPlanEdit(int ID, string PlanName, string PlanDate)
        {
            InitializeComponent();
            TBid.Text = Convert.ToString(ID);
            TBplan_name.Text = PlanName;
            TBplan_date.Text = PlanDate;
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TBid.Text);
            string edit = "update WorkPlans set PlanName = '" + TBplan_name.Text + "', PlanDate = '" + TBplan_date.Text + "' where ID = @id; commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("план работ с ID " + id + " изменён");
        }
    }
}
