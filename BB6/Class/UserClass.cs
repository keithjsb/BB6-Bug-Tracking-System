using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace BB6
{
    public class UserClass
    {
        public string username { get; set; }
        public string password { get; set; }
        public string type { get; set; }
        public bool validateUser()
        {
            bool status = false;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM UserDetails WHERE username=@username AND password=@password AND type=@type";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@type", type);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                status = true;
            
            conn.Close();
            return status;
        }
        public DataTable getDevelopers()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM UserDetails WHERE type = 'D'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}