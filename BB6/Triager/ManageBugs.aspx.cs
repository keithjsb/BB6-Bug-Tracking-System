using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BB6.Triager
{
    public partial class ManageBugs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayManageBugs();
        }
        private void displayManageBugs()
        {
            BugClass bc = new BugClass();
            bc.bugReporter = Session["loginID"].ToString();

            Repeater1.DataSource = bc.getBugsForTriager();
            Repeater1.DataBind();
        }

        protected void searchBugs(object sender, EventArgs e)
        {
            string username = Session["loginID"].ToString();

            BugClass bc = new BugClass();
            if (ddlSearchType.SelectedValue == "Assignee")
            {
                Repeater1.DataSource = bc.getBugsByAssigneeForTriager(txtSearch.Text);
                lblError.Text = "";
            }
            else if (ddlSearchType.SelectedValue == "Keywords")
            {
                Repeater1.DataSource = bc.getBugsByKeywordsForTriager(txtSearch.Text);
                lblError.Text = "";
            }
            else if (ddlSearchType.SelectedValue == "Title")
            {
                Repeater1.DataSource = bc.getBugsByTitleForTriager(txtSearch.Text);
                lblError.Text = "";
            }
            else if (string.IsNullOrWhiteSpace(txtSearch.Text))
                lblError.Text = "Type something to search on.";
            else
                lblError.Text = "Choose a type to search on.";

            Repeater1.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearInput();
        }
        private void clearInput()
        {
            txtSearch.Text = "";
            ddlSearchType.SelectedValue = "-";
            lblError.Text = "";
        }

        protected void Repeater1_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            string status = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "status"));

            if (status == "New")
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded text-white status-green";
            else if (status == "Assigned")
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded text-white status-purple";
            else if (status == "Fixed")
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded text-white status-orange";
            else if (status == "Verified")
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded text-white status-green";
            else if (status == "Closed" || status == "Rejected")
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded text-white status-red";
            else
                ((Label)e.Item.FindControl("lblStatus")).CssClass = "border form-rounded bg-white";

            string assignee = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "assignee"));
            if (string.IsNullOrWhiteSpace(assignee))
                ((Label)e.Item.FindControl("lblAssignee")).Text = "-";
        }
    }
}