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
    /// Логика взаимодействия для PlantVarietyEdit.xaml
    /// </summary>
    public partial class PlantVarietyEdit : Page
    {
        public PlantVarietyEdit()
        {
            InitializeComponent();
        }
        public PlantVarietyEdit(int ID, string VarietyName, string PlantType, string Description)
        {
            InitializeComponent();
            TBid.Text = Convert.ToString(ID);
            TBvariety_name.Text = VarietyName;
            TBplant_type.Text = PlantType;
            TBdescription.Text = Description;
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TBid.Text);
            string edit = "update PlantVarieties set VarietyName = '" + TBvariety_name.Text + "', PlantType = '" + TBplant_type.Text + "', Description = '" + TBdescription.Text + "' where ID = @id; commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("сорт растения с ID " + id + " изменён");
        }
    }
}
