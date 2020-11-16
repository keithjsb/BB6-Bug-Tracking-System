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
    public partial class SubmitBugs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string title = txtTitle.Text;
                string desc = txtDescription.Text;
                string key = txtKeywords.Text;
                string bugReporter = Session["loginID"].ToString();

                BugClass bc = new BugClass();
                bc.bugReporter = bugReporter;
                bc.title = title;
                bc.keywords = key;
                bc.description = desc;
                bc.category = ddlCategory.SelectedValue;

                if (bc.addBug() == 0)
                {
                    lblError.InnerText = "Bug report submitted.";
                    clearInput();
                }

                else
                    lblError.InnerText = "Error in bug submission.";
            }
            else
                lblError.InnerText = "*Fill up your bug report!";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearInput();
        }
        private void clearInput()
        {
            txtTitle.Text = "";
            txtDescription.Text = "";
            txtKeywords.Text = "";
        }
    }
}