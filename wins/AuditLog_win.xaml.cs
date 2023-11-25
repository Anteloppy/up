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
using up.entities;

namespace up.wins
{
    /// <summary>
    /// Логика взаимодействия для AuditLog_win.xaml
    /// </summary>
    public partial class AuditLog_win : Page
    {
        public AuditLog_win()
        {
            InitializeComponent();
            LoadData();
        }
        private static string connectionString = "server=localhost; port=3306; database=accounting_finance; user=root; password=Nimda123;";
        private void LoadData()
        {
            List<AuditLog> auditLogs= new List<AuditLog>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select a.id, u.nickname, a.action, a.description from audit_log as a join users as u on a.user = u.id", conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AuditLog record = new AuditLog();
                        record.id = reader.GetInt32("id");
                        record.дата_время = reader.GetDateTime("datetime");
                        record.пользователь = reader.GetString("user");
                        record.действие = reader.GetString("action");
                        record.описание = reader.GetString("description");

                        auditLogs.Add(record);
                    }
                }
            }
            DGAuditLog.ItemsSource = auditLogs;
        }
    }
}
