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
using System.Data;
using System.Configuration;
using up.entities;
using Org.BouncyCastle.Tls.Crypto;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для Payment_win.xaml
    /// </summary>
    public partial class Payment_win : Page
    {
        public Payment_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=UP; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<Payment> payments = new List<Payment>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select p.id, co.name as course, concat(c.name, ' ', c.surname) as client, p.cost, p.pay_date from payments as p join courses as co on p.course_id = co.id join clients as c on p.client_id = c.id", conn);


                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Payment record = new Payment();
                        record.id = reader.GetInt32("id");
                        record.курс = reader.GetString("course");
                        record.клиент = reader.GetString("client");
                        record.стоимость = reader.GetInt32("cost");
                        record.дата_оплаты = DateOnly.FromDateTime(reader.GetDateTime("pay_date"));

                        payments.Add(record);
                    }
                }
            }
            DGPayment.ItemsSource = payments;
        }
    }
}