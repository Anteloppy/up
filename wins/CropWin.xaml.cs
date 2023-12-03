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
    /// Логика взаимодействия для CropWin.xaml
    /// </summary>
    public partial class CropWin : Page
    {
        public CropWin()
        {
            InitializeComponent();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_win edit = new edit_win();
            edit.Show();
            edit.frameM.Navigate(new CropEdit());
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
    }
}
