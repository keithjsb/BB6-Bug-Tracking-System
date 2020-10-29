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
        private string username { get; set; }
        private string password { get; set; }
        private string type { get; set; }

        public UserClass(String username, String password, String type)
        {
            this.username = username;
            this.password = password;
            this.type = type;
        }
        public bool validateUser()
        {
            bool status = false;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM UserDetails WHERE username=@username AND password=@password AND type=@type";
            cmd.Parameters.AddWithValue("@username", this.username);
            cmd.Parameters.AddWithValue("@password", this.password);
            cmd.Parameters.AddWithValue("@type", this.type);

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
                status = true;
            
            conn.Close();
            return status;
        }
    }
}