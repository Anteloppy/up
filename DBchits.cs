using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using up.entities;

namespace up
{
    class DBchits
    {
        private MySqlConnection connection;
        private string connectionString = "server=localhost; database=UP; userid=admin; password=nimda;";
        public DBchits()
        {
            connection = new MySqlConnection(connectionString);
        }

        private bool OpenConnection()
        {
            try { connection.Open(); return true; }
            catch (MySqlException) { return false; }
        }

        private bool CloseConnection()
        {
            try { connection.Close(); return true; }
            catch (MySqlException) { return false; }
        }


        public DataSet SelectQuery(string query)
        {
            DataSet DS = new DataSet();
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(DS);
                CloseConnection();
            }
            return DS;
        }
        public DBchits(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DBchits GetConnection()
        {
            return new DBchits(connectionString);
        }

        public void ExequteQuery(string query)
        {
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }

        //public List<Groupe> GetGroupes()
        //{
        //    List<Groupe> groupes = new List<Groupe>();
        //    using (MySqlConnection conn = GetConnection())
        //    {
        //        conn.Open();
        //        MySqlCommand cmd = new MySqlCommand("select * from groupes", conn);
        //        using (MySqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                Groupe record = new Groupe();
        //                record.id = reader.GetInt32("id");
        //                record.course_id = reader.GetInt32("course_id");
        //                record.client_id = reader.GetInt32("client_id");
        //                record.teacher_id = reader.GetInt32("teacher_id");
        //                record.point_quantity = reader.GetInt32("point_quantity");
        //                record.load_point = reader.GetInt32("load_point");
        //                record.schedule_id = reader.GetInt32("schedule_id");
        //                record.attendance_id = reader.GetInt32("attendance_id");

        //                groupes.Add(record);
        //            }
        //        }
        //    }

        //    return groupes;
        //}
    }
}
