using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BB6.BugReporter
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        MySqlConnection con;
        DataTable dt = new DataTable();
        DatabaseClass db = new DatabaseClass();

        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayBugs();
            displayComments();
        }


        private void displayBugs()
        {

            id = Request.QueryString["id"];
            BugClass a = new BugClass(id);

            Idlabel.Text = id.ToString();
            TitleLabel.Text = a.getTitle();
            KeyLabel.Text = a.getKeywords();
            ReporterLabel.Text = a.getBugReporter();
            DateLabel.Text = a.getDateReported().ToString();
            PriorityLabel.Text = a.getPriority();
            AssigneeLabel.Text = a.getAssignee();
            StatusLabel.Text = a.getStatus();

        }

        private void displayComments()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM CommentDetails where comment_bug_id = @bugid";
            cmd.Parameters.AddWithValue("@bugid", id);
            cmd.Connection = conn;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);


            DataTable dt = new DataTable();
            da.Fill(dt);

            Repeater1.DataBind();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();

            conn.Close();
        }
        protected static string GetText(object dataItem)
        {
            // <td><%#GetText(Container.DataItem)%></td>
            string type = Convert.ToString(DataBinder.Eval(dataItem, "type"));
            string sn = Convert.ToString(DataBinder.Eval(dataItem, "sn"));
            if (sn == "3")
                return "Developer";
            else
                return "Not Developer";
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            string comment = commentBox.Text;
            string comment_username = Session["loginID"].ToString();
            DateTime date = DateTime.Now;

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO CommentDetails (comment_bug_id,comment_username,comment_date,comment_text) VALUES(@bugid,@comment_username,@comment_date,@comment)";
            cmd.Parameters.AddWithValue("@bugid", id);
            cmd.Parameters.AddWithValue("@comment_username", comment_username);
            cmd.Parameters.AddWithValue("@comment", comment);
            cmd.Parameters.AddWithValue("@comment_date", date);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            conn.Close();

            Label3.Text = "Comment Added.";
            commentBox.Text = "";


            displayComments();
        }
    }
}