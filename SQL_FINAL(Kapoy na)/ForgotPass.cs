using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class ForgotPass : Form
    {
        // Database connection String
        string connectionString = DBConnection.ConnectionString;

        public ForgotPass()
        {
            InitializeComponent();
        }

        // Reset Password
        private void btnReset_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string newPass = txtPass.Text.Trim();

            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information");
                return;
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_ResetPass", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    // Add parameters
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@NewPassword", txtPass.Text);
                    cmd.ExecuteNonQuery();
                    
                    AddLog("UPDATE", $"Password reset for username: {user}");

                    MessageBox.Show("Password reset successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Back to Login Form
                    LOGIN lOGIN = new LOGIN();
                    lOGIN.Show();
                    this.Hide();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error");
                }
            }
        }
        // Back to Login Form
        private void label2_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();
        }
        // Add Log
        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand log = new SqlCommand("F_Log", con);
                log.CommandType = CommandType.StoredProcedure;
                log.Parameters.AddWithValue("@ActionType", action);
                log.Parameters.AddWithValue("@Description", desc);
                log.ExecuteNonQuery();
            }
        }
    }
}
