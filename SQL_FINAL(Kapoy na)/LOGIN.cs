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
    public partial class LOGIN : Form
    {
        int attempts = 0;
        public LOGIN()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source = DESKTOP-IBHAJPM\SQLEXPRESS;
                Initial Catalog=FINAL_DB; Integrated Security=true";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please enter both username and password.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_Login", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Check if admin exists
                    if (dt.Rows.Count > 0)
                    {
                        string fname = dt.Rows[0]["FirstName"].ToString();
                        string lname = dt.Rows[0]["LastName"].ToString();
                        string photoPath = dt.Rows[0]["ProfilePic"].ToString();

                        UserSession.FirstName = fname;
                        UserSession.LastName = lname;
                        UserSession.ProfilePath = photoPath;

                        MessageBox.Show("Welcome, " + fname + "!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Show Dashboard
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        attempts++;
                        MessageBox.Show($"Invalid username or password. Attempt: {attempts}/3", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Exit after 3 failed attempts
                        if (attempts >= 3)
                        {
                            MessageBox.Show("You have reached the maximum number of login attempts.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Application.Exit();
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPass forgot = new ForgotPass();
            forgot.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
