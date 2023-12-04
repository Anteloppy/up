using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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
    /// Логика взаимодействия для CropWin.xaml
    /// </summary>
    public partial class CropWin : Page
    {
        public CropWin()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<Crop> crops = new List<Crop>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select C.ID, C.CropName, C.Area, C.PlantingDate, C.ExpectedHarvestDate, P.VarietyName as VarietyName from Crops as C join PlantVarieties as P on C.VarietyID = P.ID", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Crop record = new Crop();
                        record.ID = reader.GetInt32("ID");
                        record.CropName = reader.GetString("CropName");
                        record.Area = reader.GetFloat("Area");
                        record.PlantingDate = reader.GetString("PlantingDate");
                        record.ExpectedHarvestDate = reader.GetString("ExpectedHarvestDate");
                        record.PlantID = reader.GetString("VarietyName");

                        crops.Add(record);
                    }
                }
            }
            DGCrop.ItemsSource = crops;
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            Crop si = (Crop)DGCrop.SelectedItem;
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new CropEdit(si.ID,si.CropName,si.Area,si.PlantingDate,si.ExpectedHarvestDate,si.PlantID));
            Title = "Редактировать посевные площади";
            //this.Close();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            Crop si = (Crop)DGCrop.SelectedItem;
            MessageBoxResult result = MessageBox.Show("удалить строку с ID " + si.ID + "?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string delete = "delete from Crops where ID = @id; commit;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", si.ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("посевная площадь с id " + si.ID + "  удалена");
            }
        }

        private void TBfind_TextChanged(object sender, TextChangedEventArgs e)
        {
            string ts = TBfind.Text;
            if (ts != "")
            {
                List<Crop> find = new List<Crop>();
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string search = "select C.ID, C.CropName, C.Area, C.PlantingDate, C.ExpectedHarvestDate, P.VarietyName as VarietyName from Crops as C join PlantVarieties as P on C.VarietyID = P.ID where C.CropName like @ts;";

                    MySqlCommand cmd = new MySqlCommand(search, conn);
                    cmd.Parameters.AddWithValue("@ts", "%" + ts + "%");

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Crop record = new Crop();
                            record.ID = reader.GetInt32("ID");
                            record.CropName = reader.GetString("CropName");
                            record.Area = reader.GetFloat("Area");
                            record.PlantingDate = reader.GetString("PlantingDate");
                            record.ExpectedHarvestDate = reader.GetString("ExpectedHarvestDate");
                            record.PlantID = reader.GetString("VarietyName");

                            find.Add(record);
                        }
                    }
                }
                DGCrop.ItemsSource = find;
            }
            else LoadData();
        }
    }
}
