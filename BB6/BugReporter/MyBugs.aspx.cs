﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace BB6.BugReporter
{
    public partial class MyBugs : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            displayBugs();
        }
        private void displayBugs()
        {
            string username = Session["loginID"].ToString();

            BugClass bc = new BugClass();
            bc.bugReporter = username;
            
            Repeater1.DataSource = bc.getAllBugsForBugReporter();
            Repeater1.DataBind();
        }
        protected static string GetText(object dataItem)
        {
            // this method is for testing. nothing to see here
            // <td><%#GetText(Container.DataItem)%></td>
            string type = Convert.ToString(DataBinder.Eval(dataItem, "type"));
            string sn = Convert.ToString(DataBinder.Eval(dataItem, "sn"));
            if (sn == "3")
                return "Bug Reporter";
            else
                return "Not Bug Reporter";
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string username = Session["loginID"].ToString();

            BugClass bc = new BugClass();
            if (ddlSearchType.SelectedValue == "Assignee")
            {
                Repeater1.DataSource = bc.getBugsByAssignee(txtSearch.Text, username);
                lblError.Text = "";
            }
            else if (ddlSearchType.SelectedValue == "Keywords")
            {
                Repeater1.DataSource = bc.getBugsByKeywords(txtSearch.Text, username);
                lblError.Text = "";
            }
            else if (ddlSearchType.SelectedValue == "Title")
            {
                Repeater1.DataSource = bc.getBugsByTitle(txtSearch.Text, username);
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
    }
}