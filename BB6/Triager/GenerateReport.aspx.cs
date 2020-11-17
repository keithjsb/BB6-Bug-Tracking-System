using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace BB6.Triager
{

    public partial class GenerateReport : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            string Month = DateTime.Now.AddMonths(-1).ToString("MM");
            string Year = DateTime.Now.ToString("yyyy");
            string currentMonth = Year + "-" + Month;

            string Month_word = DateTime.Now.AddMonths(-1).ToString("MMMM");
            string date = DateTime.Now.StartOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");
            string dateEnd = DateTime.Now.EndOfWeek(DayOfWeek.Monday).ToString("yyyy-MM-dd h:mm tt");

            BugClass bc = new BugClass();

            DataTable reportw = bc.countReportedWeekly();
            DataTable reportm = bc.countReportedMontly();
            DataTable resolvew = bc.countResolvedWeekly();
            DataTable resolvem = bc.countResolvedMontly();
            DataTable commentw = bc.countComments();
            MySqlCommand reporter = bc.mostBugsReported();
            MySqlCommand dev = bc.mostBugsFixed();

            NumOfBugsReportedWeekly.Text = "Number of bugs reported last week: " + reportw.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]";
            NumOfBugsReportedMonthly.Text = "Number of bugs reported in " + Month_word + ": " + reportm.Rows.Count.ToString();
            NumOfBugsFixedWeekly.Text = "Number of bugs fixed last week: " + resolvew.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]"; ;
            NumOfBugsFixedMonthly.Text = "Number of bugs fixed in " + Month_word + ": " + resolvem.Rows.Count.ToString();
            NumOfComments.Text = "Number of Comments last week: " + commentw.Rows.Count.ToString() + "   [" + date + "  TO  " + dateEnd + "]";
            BestReporter.Text = "Best performing Reporter in " + Month_word + ": " + reporter.ExecuteScalar().ToString();
            BestDeveloper.Text = "Best performing Developer in " + Month_word + ": " + dev.ExecuteScalar().ToString();

        }


    }
}