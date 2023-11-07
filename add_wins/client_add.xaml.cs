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
    /// Логика взаимодействия для client_add.xaml
    /// </summary>
    public partial class client_add : Page
    {
        public client_add()
        {
            InitializeComponent();
        }

        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "", a = "";
            string b = TBbirth_date.Text;
            char c5 = b[5], c3 = b[3];

            if (b.Contains("-"))
            {
                if (c5 == '-') a = "min_ymd";
                if (c3 == '-') a = "min_dmy";
            }
            if (b.Contains("."))
            {
                if (c5 == '.') a = "dot_ymd";
                if (c3 == '.') a = "dot_dmy";
            }

            switch (a)
            {
                case "min_ymd":
                    add = "insert into clients(name, surname, contact, birth_date, experience_id, requirement) values('" + TBname.Text + "', '" + TBsurname.Text + "', '" + TBcontact.Text + "', str_to_date('" + TBbirth_date.Text + "', '%Y-%m-%d'), '" + Convert.ToInt32(TBexperience_id.Text) + "', '" + TBrequirement.Text + "'); commit;";
                    break;
                case "min_dmy":
                    add = "insert into clients(name, surname, contact, birth_date, experience_id, requirement) values('" + TBname.Text + "', '" + TBsurname.Text + "', '" + TBcontact.Text + "', str_to_date('" + TBbirth_date.Text + "', '%d-%m-%Y'), '" + Convert.ToInt32(TBexperience_id.Text) + "', '" + TBrequirement.Text + "'); commit;";
                    break;
                case "dot_ymd":
                    add = "insert into clients(name, surname, contact, birth_date, experience_id, requirement) values('" + TBname.Text + "', '" + TBsurname.Text + "', '" + TBcontact.Text + "', str_to_date('" + TBbirth_date.Text + "', '%Y.%m.%d'), '" + Convert.ToInt32(TBexperience_id.Text) + "', '" + TBrequirement.Text + "'); commit;";
                    break;
                case "dot_dmy":
                    add = "insert into clients(name, surname, contact, birth_date, experience_id, requirement) values('" + TBname.Text + "', '" + TBsurname.Text + "', '" + TBcontact.Text + "', str_to_date('" + TBbirth_date.Text + "', '%d.%m.%Y'), '" + Convert.ToInt32(TBexperience_id.Text) + "', '" + TBrequirement.Text + "'); commit;";
                    break;
                default:
                    MessageBox.Show("ошибка формата даты");
                    break;
            }
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("клиент добавлен");
        }
    }
}
