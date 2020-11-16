using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BB6.Reviewer
{
    public partial class Reviewer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validateLogin();
        }
        private void validateLogin()
        {
            if (Session["loginID"] == null)
                Response.Redirect("../Login.aspx");
            else
                lblID.InnerText = Session["loginID"].ToString();
        }
        protected void logOut(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}