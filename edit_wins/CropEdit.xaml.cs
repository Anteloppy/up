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

namespace up.edit_wins
{
    /// <summary>
    /// Логика взаимодействия для CropEdit.xaml
    /// </summary>
    public partial class CropEdit : Page
    {
        public CropEdit()
        {
            InitializeComponent();
        }
        public CropEdit(int ID, string CropName, float Area, DateOnly PlantingDate, DateOnly ExpectedHarvestDate, int PlantID)
        {
            InitializeComponent();
            TBid.Text = Convert.ToString(ID);
            TBcrop_name.Text = CropName;
            TBarea.Text = Convert.ToString(Area);
            TBplanting_date.Text = Convert.ToString(PlantingDate);
            TBexpected_harvest_date.Text = Convert.ToString(ExpectedHarvestDate);
            TBvariety_id.Text = Convert.ToString(PlantID);
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TBid.Text);
            string edit = "update Crops(CropName, Area, PlantingDate, ExpectedHarvestDate, VarietyID) set values('" + TBcrop_name.Text + "', " + Convert.ToDouble(TBarea.Text) + ", '" + DateOnly.FromDateTime(Convert.ToDateTime(TBplanting_date)) + "', '" + DateOnly.FromDateTime(Convert.ToDateTime(TBexpected_harvest_date.Text)) + "', " + Convert.ToInt32(TBvariety_id.Text) + ") where ID = @id; commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("посевная площадь с id" + id + " изменена");
        }
    }
}
