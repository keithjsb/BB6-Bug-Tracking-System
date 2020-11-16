using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB6
{
    public class CommentClass
    {
        public int commentID { get; set; }
        public int bugID { get; set; }
        public string commentDescription { get; set; }
        public DateTime commentTimestamp { get; set; }
        public string commentUsername { get; set; }

        public DataTable getCommentsByID()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_bug_id = @bugid";
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public int countCommentsByID()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_bug_id = @bugid";
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt.Rows.Count;
        }

        public DataTable getCommentsByCommentUser()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_username=@username";
            cmd.Parameters.AddWithValue("@username", commentUsername);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public int countCommentsByCommentUser()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_username=@username";
            cmd.Parameters.AddWithValue("@username", commentUsername);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt.Rows.Count;
        }
        public int addComment()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CommentDetails (comment_bug_id,comment_username,comment_date,comment_text) VALUES(@bugid,@comment_username,@comment_date,@comment)";
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Parameters.AddWithValue("@comment_username", commentUsername);
            cmd.Parameters.AddWithValue("@comment", commentDescription);
            cmd.Parameters.AddWithValue("@comment_date", date);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();

            return 0;
        }
    }
}