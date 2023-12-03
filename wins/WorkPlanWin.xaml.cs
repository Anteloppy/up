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
using up.edit_wins;
using up.entities;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для WorkPlanWin.xaml
    /// </summary>
    public partial class WorkPlanWin : Page
    {
        public WorkPlanWin()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<WorkPlan> plans = new List<WorkPlan>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from WorkPlans", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WorkPlan record = new WorkPlan();
                        record.ID = reader.GetInt32("ID");
                        record.PlanName = reader.GetString("PlanName");
                        record.PlanDate = reader.GetString("PlanDate");

                        plans.Add(record);
                    }
                }
            }
            DGWorkPlan.ItemsSource = plans;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            WorkPlan si = (WorkPlan)DGWorkPlan.SelectedItem;
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new WorkPlanEdit(si.ID,si.PlanName,si.PlanDate));
            Title = "Редактировать план работ";
            //this.Close();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            WorkPlan si = (WorkPlan)DGWorkPlan.SelectedItem;
            MessageBoxResult result = MessageBox.Show("удалить строку с ID " + si.ID + "?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string delete = "delete from WorkPlans where ID = @id; commit;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", si.ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("план работ с id " + si.ID + "  удалён");
            }
        }

        private void TBfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ts = TBfind.Text;
            if (ts != "")
            {
                List<WorkPlan> find = new List<WorkPlan>();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string search = "select * from WorkPlans where PlanName like @ts;";

                    MySqlCommand cmd = new MySqlCommand(search, conn);
                    cmd.Parameters.AddWithValue("@ts", "%" + ts + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            WorkPlan record = new WorkPlan();
                            record.ID = reader.GetInt32("ID");
                            record.PlanName = reader.GetString("PlanName");
                            record.PlanDate = reader.GetString("PlanDate");

                            find.Add(record);
                        }
                    }
                }
                DGWorkPlan.ItemsSource = find;
            }
            else LoadData();
        }
    }
}
