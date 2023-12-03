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
    /// Логика взаимодействия для PlantVarientyWin.xaml
    /// </summary>
    public partial class PlantVarientyWin : Page
    {
        public PlantVarientyWin()
        {
            InitializeComponent();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            PlantVarienty si = (PlantVarienty)DGPlantVarienty.SelectedItem;
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new PlantVarietyEdit(si.ID, si.VarietyName, si.PlantType, si.Description));
            Title = "Редактировать сорта растений";
            //this.Close();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BDelete_Click(object sender, RoutedEventArgs e)
        {
            PlantVarienty si = (PlantVarienty)DGPlantVarienty.SelectedItem;
            MessageBoxResult result = MessageBox.Show("удалить строку с ID " + si.ID + "?", "подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string delete = "delete from PlantVarienties where ID = @id; commit;";
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(delete, conn);
                cmd.Parameters.AddWithValue("@id", si.ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("сорт растения с id " + si.ID + "  удалён");
            }
        }
    }
}
