﻿using MySql.Data.MySqlClient;
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
    /// Логика взаимодействия для payment_add.xaml
    /// </summary>
    public partial class payment_add : Page
    {
        public payment_add()
        {
            InitializeComponent();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string add = "insert into payments(client_id, course_id, cost, pay_date) values('" + Convert.ToInt32(TBclient_id.Text) + "', '" + Convert.ToInt32(TBcourse_id.Text) + "', '" + Convert.ToInt32(TBcost.Text) + "', '" + DateOnly.FromDateTime(Convert.ToDateTime(TBpay_date.Text)) + "'); commit;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(add, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("оплата добавлена");
        }
    }
}
