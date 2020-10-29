using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace BB6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testList();
        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string loginID = txtUser.Text;
            string password = txtPassword.Text;
            string userType = ddlUserType.SelectedValue;

            UserClass objAccount = new UserClass(loginID, password, userType);

            if (objAccount.validateUser())
            {
                Session["ID"] = loginID;
                switch (userType)
                {
                    case "BR":
                        Session["loginID"] = loginID;
                        Response.Redirect("BugReporter/Home.aspx");
                        break;
                    case "D":
                        Session["loginID"] = loginID;
                        Response.Redirect("Developer/Home.aspx");
                        break;
                    case "R":
                        Session["loginID"] = loginID;
                        Response.Redirect("Reviewer/Home.aspx");
                        break;
                    case "T":
                        Session["loginID"] = loginID;
                        Response.Redirect("Triager/Home.aspx");
                        break;
                    default:
                        Response.Redirect("Admin.aspx");
                        break;
                }
            }
            else
                lblError.InnerText = "Invalid login credentials.";
        }
        private void testList()
        {
            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM test";

            MySqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            conn.Close();

            foreach(DataRow dr in dt.Rows)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell1 = new HtmlTableCell();
                cell1.InnerText = dr["sn"].ToString();
                row.Cells.Add(cell1);

                HtmlTableCell cell2 = new HtmlTableCell
                {
                    InnerText = dr["username"].ToString()
                };
                row.Cells.Add(cell2);

                HtmlTableCell cell3 = new HtmlTableCell();
                cell3.InnerText = dr["password"].ToString();
                row.Cells.Add(cell3);

                HtmlTableCell cell4 = new HtmlTableCell();
                cell4.InnerText = dr["type"].ToString();
                row.Cells.Add(cell4);

                testTable.Rows.Add(row);
            }
        }
    }
}