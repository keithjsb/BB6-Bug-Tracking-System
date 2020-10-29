using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace BB6.BugReporter
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblTest.Text = Request.QueryString["id"];
            //displayBugs();


            BugClass a = new BugClass("1002");
            lblTitle.Text = a.getTitle();
            lblKeywords.Text = a.getKeywords();

        }
        private void displayBugs()
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

            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTest.Text = ddlTest.SelectedValue;
        }

        protected void txtTest_TextChanged(object sender, EventArgs e)
        {
            lblTest.Text = txtTest.Text;
        }
    }
}