using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BB6.Triager
{
    public partial class ViewDetails : System.Web.UI.Page
    {
        string id;

        protected void Page_Load(object sender, EventArgs e)
        { 
            displayBugs();
            displayComments();

            if(!Page.IsPostBack)
            {
                UserClass uc = new UserClass();
                ddlAssignee.DataSource = uc.getDevelopers();
                ddlAssignee.DataTextField = "username";
                ddlAssignee.DataValueField = "username";
                ddlAssignee.DataBind();
            }
        }

        private void displayBugs()  
        {
            id = Request.QueryString["id"];
            BugClass a = new BugClass(id);

            IdLabel.InnerText = "#" + id.ToString();
            CategoryLabel.Text = "[" + a.category + "]";
            TitleLabel.Text = a.title;
            KeyLabel.Text = a.keywords;
            ReporterLabel.Text = "<u>Reported by: " + a.bugReporter + "</u>";
            DateLabel.Text = a.dateReported.ToString();
            if (a.dateModified == a.dateReported)
                DateModifiedLabel.Text = "-";
            else
                DateModifiedLabel.Text = a.dateModified.ToString();
            if (a.dateResolved < a.dateReported)
                DateResolvedLabel.Text = "-";
            else
                DateResolvedLabel.Text = a.dateResolved.ToString();
            DescriptionLabel.Text = a.description;
            PriorityLabel.Text = a.priority;
            AssigneeLabel.Text = a.assignee;
            StatusLabel.Text = a.status;
            StatusLabel2.Text = a.status; //the one inside details card
            changeStatusColor(a.status);

            //fake uploaded fix
            if (a.status == "Fixed" || a.status == "Closed")
            {
                btnSubmit.Disabled = true;
                ddlAssignee.Visible = false;
                ddlPriority.Visible = false;
                ddlStatus.Visible = false;
                StatusLabel2.Visible = true;
                AssigneeLabel.Visible = true;
                PriorityLabel.Visible = true;
                aFix.InnerText = id + "_fix.exe";
                aFix.HRef = "#aFix";
            }
            else if (a.status == "Rejected" || a.status == "Assigned")
            {
                btnSubmit.Disabled = true;
                ddlAssignee.Visible = false;
                ddlPriority.Visible = false;
                ddlStatus.Visible = false;
                StatusLabel2.Visible = true;
                AssigneeLabel.Visible = true;
                PriorityLabel.Visible = true;
                aFix.InnerText = " none";
            }
            else if (a.status == "Verified")
            {
                StatusLabel2.Visible = false;
                AssigneeLabel.Visible = false;
                PriorityLabel.Visible = false;
                aFix.InnerText = id + "_fix.exe";
                aFix.HRef = "#aFix";
            }
            else
            {
                StatusLabel2.Visible = false;
                AssigneeLabel.Visible = false;
                PriorityLabel.Visible = false;

                aFix.InnerText = " none";
            }
        }

        private void displayComments()
        {
            CommentClass cc = new CommentClass();
            cc.bugID = Int32.Parse(id);

            Repeater1.DataSource = cc.getCommentsByID();
            Repeater1.DataBind();

            CommentCountLabel.Text = "&bull; " + cc.countCommentsByID() + " comments";
        }

        protected void updateReport(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                BugClass bc = new BugClass();
                bc.bugID = Int32.Parse(id);

                if(ddlStatus.SelectedValue == "Assigned")
                {
                    if(ddlPriority.SelectedValue != "" && ddlAssignee.SelectedValue != "")
                    {
                        bc.priority = ddlPriority.SelectedValue;
                        bc.assignee = ddlAssignee.SelectedValue;

                        if (bc.assignBug() == 0)
                            Label3.Text = "Bug assigned successfully!";
                        else
                            Label3.Text = "There seem to be a problem changing the status of this bug report.";
                    }
                    else
                        Label3.Text = "You need to select both a priority and an assignee!";
                }
                else if(ddlStatus.SelectedValue == "Closed")
                {
                    if (bc.closeBugReport() == 0)
                        Label3.Text = "Bug report closed successfully!";
                    else
                        Label3.Text = "There seem to be a problem changing the status of this bug report.";
                }
                else
                {
                    if (bc.rejectBug() == 0)
                        Label3.Text = "Bug report has been rejected!";
                    else
                        Label3.Text = "There seem to be a problem changing the status of this bug report.";
                }

                displayBugs();
            }
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                CommentClass cc = new CommentClass();
                cc.bugID = Int32.Parse(id);
                cc.commentDescription = commentBox.Text;
                cc.commentUsername = Session["loginID"].ToString();
                if (cc.addComment() == 0)
                {
                    Label3.Text = "Comment Added.";
                    commentBox.Text = "";
                    displayComments();
                }
                else
                    Label3.Text = "Error submitting your comment. Submit a bug report about this issue.";
            }
        }
        private void changeStatusColor(string status)
        {
            if (status == "New")
                StatusLabel.CssClass = "p-1 text-white status-green";
            else if (status == "Assigned")
                StatusLabel.CssClass = "p-1 text-white status-purple";
            else if (status == "Fixed")
                StatusLabel.CssClass = "p-1 text-white status-orange";
            else if (status == "Verified")
                StatusLabel.CssClass = "p-1 text-white status-green";
            else if (status == "Closed" || status == "Rejected")
                StatusLabel.CssClass = "p-1 text-white status-red";
            else
                StatusLabel.CssClass = "p-1 bg-white";
        }
    }
}