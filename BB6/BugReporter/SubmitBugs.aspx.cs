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
        private int addBug()
        {
            string title = txtTitle.Text;
            string desc = txtDescription.Text;
            string key = txtKeywords.Text;
            string bugReporter = "Michael"; //TODO: CHANGE TO DYNAMIC
            DateTime date = DateTime.Now;

            DatabaseClass db = new DatabaseClass();
            MySqlConnection conn = db.getConnection();
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO BugDetails (bugreporter, title, keywords, description, date_reported, status) VALUES(@bugreporter, @title, @keywords, @description, @date_reported, @status)";
            cmd.Parameters.AddWithValue("@bugreporter", bugReporter);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@keywords", key);
            cmd.Parameters.AddWithValue("@description", desc);
            cmd.Parameters.AddWithValue("@date_reported", date);
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