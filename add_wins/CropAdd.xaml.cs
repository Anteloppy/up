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
    /// Логика взаимодействия для CropAdd.xaml
    /// </summary>
    public partial class CropAdd : Page
    {
        public CropAdd()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into Crops(CropName, Area, PlantingDate, ExpectedHarvestDate, VarietyID) values('" + TBcrop_name.Text + "', " + Convert.ToDouble(TBarea.Text) + ", '" + DateOnly.FromDateTime(Convert.ToDateTime(TBplanting_date)) + "', '" + DateOnly.FromDateTime(Convert.ToDateTime(TBexpected_harvest_date.Text)) + "', " + Convert.ToInt32(TBvariety_id.Text) + "); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("посевная площадь добавлена");
        }
    }
}
