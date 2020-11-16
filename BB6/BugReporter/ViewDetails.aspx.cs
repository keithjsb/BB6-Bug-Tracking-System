using System;
using System.Web.UI;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace BB6.BugReporter
{
    public partial class ViewDetails : System.Web.UI.Page
    {
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
            PriorityLabel.Text = a.priority;
            AssigneeLabel.Text = a.assignee;
            DescriptionLabel.Text = a.description;
            StatusLabel.Text = a.status;
            changeStatusColor(a.status);
            if (a.status == "Fixed" || a.status == "Closed")
            {
                aFix.InnerText = id + "_fix.exe";
                aFix.HRef = "#aFix";
                aFix.Attributes.Add("onClientClick", "fix()");
            }
            else
                aFix.InnerText = " none";
        }

        private void displayComments()
        {
            CommentClass cc = new CommentClass();
            cc.bugID = Int32.Parse(id);

            Repeater1.DataSource = cc.getCommentsByID();
            Repeater1.DataBind();

            CommentCountLabel.Text = "&bull; " + cc.countCommentsByID() + " comments";
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
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