using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BB6.Triager
{
    public partial class Triager : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            validateLogin();
        }
        private void validateLogin()
        {
            if (Session["loginID"] == null)
                lblID.InnerText = "not logged in";
            else
                lblID.InnerText = Session["loginID"].ToString();
        }
    }
}