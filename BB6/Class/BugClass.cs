using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace BB6
{
    public class BugClass
    {
        private int bugID;
        private string bugReporter;
        private string title;
        private string keywords;
        private string description;
        private DateTime dateReported;
        private DateTime dateResolved;
        private string assignee;
        private string priority;
        private string status;

        private int commentID;
        private string commentDescription;
        private DateTime commentTimestamp;
        private string commenter;

        public int getBugID()
        {
            return this.bugID;
        }
        public string getBugReporter()
        {
            return this.bugReporter;
        }
        public string getTitle()
        {
            return this.title;
        }
        public string getKeywords()
        {
            return this.keywords;
        }
        public string getDescription()
        {
            return this.description;
        }
        public DateTime getDateReported()
        {
            return this.dateReported;
        }
        public DateTime getDateResolved()
        {
            return this.dateResolved;
        }
        public string getAssignee()
        {
            return this.assignee;
        }
        public string getPriority()
        {
            return this.priority;
        }
        public string getStatus()
        {
            return this.status;
        }
        public int getCommentID()
        {
            return this.commentID;
        }
        public string getCommentDescription()
        {
            return this.commentDescription;
        }
        public DateTime getCommentTimestamp()
        {
            return this.commentTimestamp;
        }
        public string getCommenter()
        {
            return this.commenter;
        }

        public BugClass()
        {

        }
        public BugClass(string id)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bug_id=@bugid";
            cmd.Parameters.AddWithValue("@bugid", id);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataSet result = new DataSet();
            da.Fill(result, "bugDetails");
            conn.Close();

            if(result.Tables["bugDetails"].Rows.Count > 0)
            {
                this.bugReporter = result.Tables["bugDetails"].Rows[0]["bugreporter"].ToString();
                this.title = result.Tables["bugDetails"].Rows[0]["title"].ToString();
                this.keywords = result.Tables["bugDetails"].Rows[0]["keywords"].ToString();
                this.description = result.Tables["bugDetails"].Rows[0]["description"].ToString();
                this.dateReported = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_reported"].ToString());
                if (!string.IsNullOrWhiteSpace(result.Tables["bugDetails"].Rows[0]["date_resolved"].ToString()))
                    this.dateResolved = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_resolved"].ToString());
                this.assignee = result.Tables["bugDetails"].Rows[0]["assignee"].ToString();
                this.priority = result.Tables["bugDetails"].Rows[0]["priority"].ToString();
                this.status = result.Tables["bugDetails"].Rows[0]["status"].ToString();
            }
        }
        public DataTable getAllBugs()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByTitle(string title)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE title LIKE '%" + title + "%'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByAssignee(string assignee)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee LIKE '%"+ assignee +"%'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByKeywords(string keywords)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE keywords LIKE '%" + keywords + "%'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
    }
}