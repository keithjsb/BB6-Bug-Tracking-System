using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace BB6.Triager
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
    public partial class GenerateReport : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            countReportedWeekly();
            countReportedMontly();
            countResolvedWeekly();
            countResolvedMontly();
            countComments();
            mostBugsReported();
            mostBugsFixed();
        }

        private void countReportedWeekly()
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
            NumOfBugsReportedWeekly.Text = "Number of bugs reported last week: " + dt.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]";

            conn.Close();
        }

        private void countReportedMontly()
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
            NumOfBugsReportedMonthly.Text = "Number of bugs reported in " + Month_word + ": " + dt.Rows.Count.ToString();

            conn.Close();
        }

        private void countResolvedWeekly()
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
            NumOfBugsFixedWeekly.Text = "Number of bugs fixed last week: " + dt.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]"; ;

            conn.Close();
        }

        private void countResolvedMontly()
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
            NumOfBugsFixedMonthly.Text = "Number of bugs fixed in " + Month_word + ": " + dt.Rows.Count.ToString();

            conn.Close();
        }

        private void countComments()
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
            NumOfComments.Text = "Number of Comments last week: " + dt.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]";

            conn.Close();
        }

        private void mostBugsReported()
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
            BestReporter.Text = "Best performing Reporter in " + Month_word + ": " + cmd.ExecuteScalar().ToString();

            conn.Close();
        }

        private void mostBugsFixed()
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
            BestDeveloper.Text = "Best performing Developer in " + Month_word + ": " + cmd.ExecuteScalar().ToString();
            conn.Close();
        }

    }
}