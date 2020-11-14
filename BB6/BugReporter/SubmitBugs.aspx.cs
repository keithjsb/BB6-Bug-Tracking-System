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
            category.Items.Insert(0, new ListItem("UI", "UI"));
            category.Items.Insert(1, new ListItem("Server", "Server"));
            category.Items.Insert(2, new ListItem("Error Handling", "Error Handling"));
            category.Items.Insert(3, new ListItem("Syntactics", "Syntactics"));
            category.Items.Insert(4, new ListItem("Others", "Others"));
        }
        private int addBug()
        {
            string title = txtTitle.Text;
            string desc = txtDescription.Text;
            string key = txtKeywords.Text;
            string bugReporter = Session["loginID"].ToString();
            DateTime date = DateTime.Now;

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO BugDetails (bugreporter, title, keywords, category, description, date_reported, status) VALUES(@bugreporter, @title, @keywords, @category, @description, @date_reported, @status)";
            cmd.Parameters.AddWithValue("@bugreporter", bugReporter);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@keywords", key);
            cmd.Parameters.AddWithValue("@description", desc);
            cmd.Parameters.AddWithValue("@date_reported", date);
            cmd.Parameters.AddWithValue("@category", category.SelectedValue);
            cmd.Parameters.AddWithValue("@status", "Open");
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();

            return 0;
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (addBug() == 0)
            {
                lblError.InnerText = "Bug report submitted.";
                clearInput();
            }
                
            else
                lblError.InnerText = "Error in bug submission.";
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