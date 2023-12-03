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
    /// Логика взаимодействия для LivestockEdit.xaml
    /// </summary>
    public partial class LivestockEdit : Page
    {
        public LivestockEdit()
        {
            InitializeComponent();
        }
        public LivestockEdit(int ID, string AnimalType, int Quantity, string AcquisitionDate, string Notes)
        {
            InitializeComponent();
            TBid.Text = Convert.ToString(ID);
            TBanimal_type.Text = AnimalType;
            TBquantity.Text = Convert.ToString(Quantity);
            TBacquisition_date.Text = AcquisitionDate;
            TBnotes.Text = Notes;
        }
        private static string connectionString = "server=localhost; port=3306; database=FarmManagement; user=root; password=Nimda123;";
        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(TBid.Text);
            string edit = "update Livestock set AnimalType = '" + TBanimal_type.Text + "', Quantity = " + Convert.ToInt32(TBquantity.Text) + ", AcquisitionDate = '" + TBacquisition_date.Text + "', Notes = '" + TBnotes.Text + "' where ID = @id; commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(edit, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("поголовье скота с ID " + id + " изменено");
        }
    }
}
