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
            
        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";

            if (Page.IsValid)
                login();
        }

        private void login()
        {
            string loginID = txtUser.Text;
            string password = txtPassword.Text;
            string userType = ddlUserType.SelectedValue;

            UserClass user = new UserClass();
            user.username = loginID;
            user.password = password;
            user.type = userType;

            if (user.validateUser())
            {
                Session["ID"] = user.username;
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
                }
            }
            else
                lblError.Text = "Invalid login credentials.";
        }
    }
}