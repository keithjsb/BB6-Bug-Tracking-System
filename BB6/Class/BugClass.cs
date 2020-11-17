using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace BB6
{
    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff - 7).Date;

        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff - 1).Date;
        }
    }
    public class BugClass
    {
        public int bugID { get; set; }
        public string bugReporter { get; set; }
        public string title { get; set; }
        public string keywords { get; set; }
        public string description { get; set; }
        public DateTime dateReported { get; set; }
        public DateTime dateResolved { get; set; }
        public DateTime dateModified { get; set; }
        public string assignee { get; set; }
        public string priority { get; set; }
        public string status { get; set; }
        public string category { get; set; }

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
                this.category = result.Tables["bugDetails"].Rows[0]["category"].ToString();
                this.dateReported = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_reported"].ToString());
                if (!string.IsNullOrWhiteSpace(result.Tables["bugDetails"].Rows[0]["date_modified"].ToString()))
                    this.dateModified = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_modified"].ToString());
                else
                    this.dateModified = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_reported"].ToString());
                if (!string.IsNullOrWhiteSpace(result.Tables["bugDetails"].Rows[0]["date_resolved"].ToString()))
                    this.dateResolved = DateTime.Parse(result.Tables["bugDetails"].Rows[0]["date_resolved"].ToString());
                this.assignee = result.Tables["bugDetails"].Rows[0]["assignee"].ToString();
                this.priority = result.Tables["bugDetails"].Rows[0]["priority"].ToString();
                this.status = result.Tables["bugDetails"].Rows[0]["status"].ToString();
            }
        }
        //retrieve bugs
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
        public DataTable getBugsForReview()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE status = 'Fixed'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getAllBugsByBugReporter()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where bugreporter = @username";
            cmd.Parameters.AddWithValue("@username", bugReporter);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getAllBugsForDeveloper()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where assignee = @username";
            cmd.Parameters.AddWithValue("@username", assignee);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsForTriager()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE status = 'New' OR status = 'Verified' ORDER BY date_reported DESC";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //search for all users
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
        public DataTable getBugsByAssignee(string assignee)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee LIKE '%" + assignee + "%'";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //search for bug reporter
        public DataTable getBugsByTitle(string title, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bugreporter = @username AND title LIKE @title";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@title", "%" + title + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByAssignee(string assignee, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bugreporter = @username AND assignee LIKE @assignee";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@assignee", "%" + assignee + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByKeywords(string keywords, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bugreporter = @username AND keywords LIKE @keywords";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@keywords", "%" + keywords + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //search for bug reporter
        public DataTable getBugsByTitleForDeveloper(string title, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee = @username AND title LIKE @title";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@title", "%" + title + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByAssigneeForDeveloper(string assignee, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee = @username AND assignee LIKE @assignee";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@assignee", "%" + assignee + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByKeywordsForDeveloper(string keywords, string username)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee = @username AND keywords LIKE @keywords";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@keywords", "%" + keywords + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //search for reviewer
        public DataTable getBugsByTitleReviewer(string title, string status)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE status = @status AND title LIKE @title";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@title", "%" + title + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByAssigneeReviewer(string assignee, string status)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bugreporter = @status AND assignee LIKE @assignee";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@assignee", "%" + assignee + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByKeywordsForReviewer(string keywords, string status)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE bugreporter = @status AND keywords LIKE @keywords";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@keywords", "%" + keywords + "%");
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //search for triager
        public DataTable getBugsByTitleForTriager(string title)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE title LIKE '%" + title + "%' AND status = 'New' OR status = 'Verified' ORDER BY date_reported DESC";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByKeywordsForTriager(string keywords)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE keywords LIKE '%" + keywords + "%' AND status = 'New' OR status = 'Verified' ORDER BY date_reported DESC";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }
        public DataTable getBugsByAssigneeForTriager(string assignee)
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails WHERE assignee LIKE '%" + assignee + "%' AND status = 'New' OR status = 'Verified' ORDER BY date_reported DESC";
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        //add
        public int addFixToBug()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET status = 'Fixed' WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        public int addBug()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO BugDetails (bugreporter, title, keywords, category, description, date_reported, status) VALUES(@bugreporter, @title, @keywords, @category, @description, @date_reported, @status)";
            cmd.Parameters.AddWithValue("@bugreporter", bugReporter);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@keywords", keywords);
            cmd.Parameters.AddWithValue("@description", description);
            cmd.Parameters.AddWithValue("@date_reported", date);
            cmd.Parameters.AddWithValue("@category", category);
            cmd.Parameters.AddWithValue("@status", "New");
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        public int reviewFix()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET status = @status WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        public int assignBug()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET priority = @priority, assignee = @assignee, status = 'Assigned', date_modified = @date_modified WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@priority", priority);
            cmd.Parameters.AddWithValue("@assignee", assignee);
            cmd.Parameters.AddWithValue("@date_modified", date);
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        public int rejectBug()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET status = 'Rejected', date_modified = @date_modified WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@date_modified", date);
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        public int closeBugReport()
        {
            DateTime date = DateTime.Now;
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET status = 'Closed', date_modified = @date_modified, date_resolved = @date_resolved WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@date_modified", date);
            cmd.Parameters.AddWithValue("@date_resolved", date);
            cmd.Parameters.AddWithValue("@bugid", bugID);
            cmd.Connection = conn;
            int count = cmd.ExecuteNonQuery();
            conn.Close();

            if (count != 0)
                return 0;
            else
                return -1;
        }
        //REPORT FUNCTIONS
        public DataTable countReportedWeekly()
        {
            string date = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");
            string dateEnd = DateTime.Now.EndOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where date_reported > @date && date_reported < @dateEnd";

            cmd.Parameters.AddWithValue("@dateEnd", dateEnd + "%");
            cmd.Parameters.AddWithValue("@date", date + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable countReportedMonthly()
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string Month_word = DateTime.Now.AddMonths(-1).ToString("MMMM");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where date_reported LIKE @currentMonth";
            cmd.Parameters.AddWithValue("@currentMonth", currentMonth + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable countResolvedWeekly()
        {
            string date = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");
            string dateEnd = DateTime.Now.EndOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where date_resolved > @date && date_resolved < @dateEnd";

            cmd.Parameters.AddWithValue("@dateEnd", dateEnd + "%");
            cmd.Parameters.AddWithValue("@date", date + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable countResolvedMonthly()
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string Month_word = DateTime.Now.AddMonths(-1).ToString("MMMM");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM BugDetails where date_resolved LIKE @currentMonth";
            cmd.Parameters.AddWithValue("@currentMonth", currentMonth + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public DataTable countComments()
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string date = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");
            string dateEnd = DateTime.Now.EndOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_date > @date && comment_date < @dateEnd";

            cmd.Parameters.AddWithValue("@currentMonth", currentMonth + "%");

            cmd.Parameters.AddWithValue("@dateEnd", dateEnd + "%");
            cmd.Parameters.AddWithValue("@date", date + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            return dt;
        }

        public MySqlCommand mostBugsReported()
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string Month_word = DateTime.Now.AddMonths(-1).ToString("MMMM");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT bugreporter FROM BugDetails where date_reported LIKE @currentMonth GROUP BY bugreporter ORDER BY COUNT(*) DESC LIMIT 1";
            cmd.Parameters.AddWithValue("@currentMonth", currentMonth + "%");

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return cmd;
            conn.Close();

        }

        public MySqlCommand mostBugsFixed()
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string Month_word = DateTime.Now.AddMonths(-1).ToString("MMMM");

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT assignee FROM BugDetails WHERE status = 'Fixed' OR status = 'Verified' OR status = 'Closed' GROUP BY assignee ORDER BY COUNT(*) DESC LIMIT 1";

            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return cmd;
            conn.Close();

        }

    }
}