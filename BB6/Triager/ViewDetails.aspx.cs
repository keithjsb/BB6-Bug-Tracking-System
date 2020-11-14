using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BB6.Triager
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

            if (!Page.IsPostBack)
            {
                /*
                con = db.getConnection();
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM UserDetails WHERE type = 'D'";
                cmd.Connection = con;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);
                */
                DropDownList3.DataSource = a.getDevelopers();
                DropDownList3.DataTextField = "username";
                DropDownList3.DataValueField = "username";
                DropDownList3.DataBind();
                //con.Close();
            }

            Idlabel.Text = id.ToString();
            TitleLabel.Text = a.getTitle();
            KeyLabel.Text = a.getKeywords();
            ReporterLabel.Text = a.getBugReporter();
            DateLabel.Text = a.getDateReported().ToString();

            string priority = a.getPriority();
            DropDownList1.Items.Insert(0, new ListItem(priority, priority));
            DropDownList1.Items.Insert(1, new ListItem("Low", "Low"));
            DropDownList1.Items.Insert(2, new ListItem("Medium", "Medium"));
            DropDownList1.Items.Insert(3, new ListItem("High", "High"));

            string status = a.getStatus();
            DropDownList2.Items.Insert(0, new ListItem(status, status));
            DropDownList2.Items.Insert(1, new ListItem("Pending Fix", "Pending Fix"));
            DropDownList2.Items.Insert(2, new ListItem("Closed (Rejected)", "Closed (Rejected)"));
            DropDownList2.Items.Insert(3, new ListItem("Closed (Resolved)", "Closed (Resolved)"));

            string assignee = a.getAssignee();
            DropDownList3.Items.Insert(0, new ListItem(assignee, assignee));

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;

            con = db.getConnection();
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (DropDownList2.SelectedValue == "Closed (Resolved)")
                cmd.CommandText = "UPDATE BugDetails SET priority = @priority, assignee = @assignee, status = @status, date_resolved = @date_resolved WHERE bug_id = @bugid";
            else
                cmd.CommandText = "UPDATE BugDetails SET priority = @priority, assignee = @assignee, status = @status WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@priority", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@assignee", DropDownList3.SelectedValue);
            cmd.Parameters.AddWithValue("@status", DropDownList2.SelectedValue);
            cmd.Parameters.AddWithValue("@date_resolved", date);
            cmd.Parameters.AddWithValue("@bugid", id);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

            //MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //da.Fill(dt);

            Label1.Text = "Bug Report Updated ";

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