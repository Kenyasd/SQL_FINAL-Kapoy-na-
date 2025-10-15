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
    public partial class Register : Form
    {
        string selectedImagePath = "";
        public Register()
        {
            InitializeComponent();
        }
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (txtFirstN.Text == "" || txtLastN.Text == "" || txtUser.Text == "" || txtPass.Text == "")
            {
                MessageBox.Show("Please fill in all required fields.", "Missing Information");
                return;
            }

            string email = txtEmail.Text.Trim();

            // Validate Gmail only
            if (!email.ToLower().Contains("@gmail.com"))
            {
                MessageBox.Show("Email must be a Gmail address. Ex.Name@gmail.com");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_RegisterAdmin", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
                    cmd.Parameters.AddWithValue("@LastName", txtLastN.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAdd.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhonenum.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Username", txtUser.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                    if (string.IsNullOrEmpty(selectedImagePath))
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", DBNull.Value); // no picture
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProfilePic", selectedImagePath); // save the path
                    }                    

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Admin registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Go back to login form
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

        private void btnclear_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName; // save path
                Profilepic.Image = new Bitmap(selectedImagePath); // preview in PictureBox
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {
            LOGIN lOGIN = new LOGIN();
            lOGIN.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
