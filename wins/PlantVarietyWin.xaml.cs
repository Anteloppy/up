using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
    /// Логика взаимодействия для PlantVarietyWin.xaml
    /// </summary>
    public partial class PlantVarietyWin : Page
    {
        public PlantVarietyWin()
        {
            InitializeComponent();
            LoadData();
            TBfind.TextChanged += TBfind_TextChanged;
        }

        private void LoadData()
        {
            List<PlantVariety> plants = new List<PlantVariety>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from PlantVarieties", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PlantVariety record = new PlantVariety();
                        record.ID = reader.GetInt32("ID");
                        record.VarietyName = reader.GetString("VarietyName");
                        record.PlantType = reader.GetString("PlantType");
                        record.Description = reader.GetString("Description");

                        plants.Add(record);
                    }
                }
            }
            DGPlantVariety.ItemsSource = plants;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            PlantVariety si = (PlantVariety)DGPlantVariety.SelectedItem;
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new PlantVarietyEdit(si.ID, si.VarietyName, si.PlantType, si.Description));
            Title = "Редактировать сорта растений";
            //this.Close();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            PlantVariety si = (PlantVariety)DGPlantVariety.SelectedItem;
            MessageBoxResult result = MessageBox.Show("удалить строку с ID " + si.ID + "?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string delete = "delete from PlantVarieties where ID = @id; commit;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", si.ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("сорт растения с id " + si.ID + "  удалён");
            }
        }

        private void TBfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ts = TBfind.Text;
            if (ts != "")
            {
                List<PlantVariety> find = new List<PlantVariety>();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string search = "select * from PlantVarieties where VarietyName like @ts;";
                
                    MySqlCommand cmd = new MySqlCommand(search, conn);
                    cmd.Parameters.AddWithValue("@ts", "%" + ts + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PlantVariety record = new PlantVariety();
                            record.ID = reader.GetInt32("ID");
                            record.VarietyName = reader.GetString("VarietyName");
                            record.PlantType = reader.GetString("PlantType");
                            record.Description = reader.GetString("Description");

                            find.Add(record);
                        }
                    }
                }
                DGPlantVariety.ItemsSource = find;
            }
            else LoadData();
        }
    }
}
