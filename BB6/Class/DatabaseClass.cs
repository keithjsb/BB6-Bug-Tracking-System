using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace BB6
{
    public class DatabaseClass
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public DatabaseClass()
        {
            Initialize();
        }

        private void Initialize()
        {
            server = "remotemysql.com";
            database = "GbBLPji6np";
            uid = "GbBLPji6np"; ;
            password = "YQs1S3KJOi";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connectionString);
        }

        public MySqlConnection getConnection()
        {
            return this.conn;
        }
    }
}