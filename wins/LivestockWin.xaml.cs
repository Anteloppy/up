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
    /// Логика взаимодействия для LivestockWin.xaml
    /// </summary>
    public partial class LivestockWin : Page
    {
        public LivestockWin()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<Livestock> livestocks = new List<Livestock>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Livestock", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Livestock record = new Livestock();
                        record.ID = reader.GetInt32("ID");
                        record.AnimalType = reader.GetString("AnimalType");
                        record.Quantity = reader.GetInt32("Quantity");
                        record.AcquisitionDate = reader.GetString("AcquisitionDate");
                        record.Notes = reader.GetString("Notes");

                        livestocks.Add(record);
                    }
                }
            }
            DGLivestock.ItemsSource = livestocks;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            Livestock si = (Livestock)DGLivestock.SelectedItem;
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new LivestockEdit(si.ID, si.AnimalType,si.Quantity,si.AcquisitionDate,si.Notes));
            Title = "Редактировать поголовье скота";
            //this.Close();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            Livestock si = (Livestock)DGLivestock.SelectedItem;
            MessageBoxResult result = MessageBox.Show("удалить строку с ID " + si.ID + "?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string delete = "delete from Livestock where ID = @id; commit;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", si.ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("поголовье скота с id " + si.ID + "  удалено");
            }
        }

        private void TBfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ts = TBfind.Text;
            if (ts != "")
            {
                List<Livestock> find = new List<Livestock>();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string search = "select * from Livestock where AnimalType like @ts;";

                    MySqlCommand cmd = new MySqlCommand(search, conn);
                    cmd.Parameters.AddWithValue("@ts", "%" + ts + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Livestock record = new Livestock();
                            record.ID = reader.GetInt32("ID");
                            record.AnimalType = reader.GetString("AnimalType");
                            record.Quantity = reader.GetInt32("Quantity");
                            record.AcquisitionDate = reader.GetString("AcquisitionDate");
                            record.Notes = reader.GetString("Notes");

                            find.Add(record);
                        }
                    }
                }
                DGLivestock.ItemsSource = find;
            }
            else LoadData();
        }
    }
}
