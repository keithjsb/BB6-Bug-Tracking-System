using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BB6.Developer
{
    public partial class DetailedPage : System.Web.UI.Page
    {
        MySqlConnection con;
        DataTable dt = new DataTable();
        DatabaseClass db = new DatabaseClass();

        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            displayBugs();
        }


        private void displayBugs()  
        {
            if (!Page.IsPostBack)
            {
                con = db.getConnection();
                con.Open();

                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM UserDetails WHERE type = 'D'";
                cmd.Connection = con;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);


                DataTable dt = new DataTable();
                da.Fill(dt);

                DropDownList3.DataSource = dt;
                DropDownList3.DataTextField = "username";
                DropDownList3.DataValueField = "username";
                DropDownList3.DataBind();
                con.Close();
            }
        


            id = Request.QueryString["id"];
            BugClass a = new BugClass("1000");

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
            DropDownList2.Items.Insert(1, new ListItem("Open", "Open"));
            DropDownList2.Items.Insert(2, new ListItem("Pending Fix", "Pending Fix"));
            DropDownList2.Items.Insert(3, new ListItem("Pending Review", "Pending Review"));
            DropDownList2.Items.Insert(4, new ListItem("Pending (Resolved)", "Pending (Resolved)"));
            DropDownList2.Items.Insert(5, new ListItem("Closed (Rejected)", "Closed (Rejected)"));
            DropDownList2.Items.Insert(6, new ListItem("Closed (Resolved)", "Closed (Resolved)"));

            string assignee = a.getAssignee();
            //DropDownList3.Items.Insert(0, new ListItem(assignee, assignee));

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
            con = db.getConnection();
            con.Open();

            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE BugDetails SET priority = @priority, assignee = @assignee, status = @status WHERE bug_id = @bugid";
            cmd.Parameters.AddWithValue("@priority", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@assignee", DropDownList3.SelectedValue);
            cmd.Parameters.AddWithValue("@status", DropDownList2.SelectedValue);
            cmd.Parameters.AddWithValue("@bugid", id);

            cmd.Connection = con;

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            Label1.Text = "Bug Report Updated ";

          //Response.Redirect("ViewDetails.aspx");
        }
    }
}