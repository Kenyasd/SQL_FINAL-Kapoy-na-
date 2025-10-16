using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class StudentDash : Form
    {
        string firstName, lastName, profilePath;

        public StudentDash()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void StudentDash_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{firstName} {lastName}";

            if (!string.IsNullOrEmpty(profilePath) && File.Exists(profilePath))
            {
                picProfile.Image = new Bitmap(profilePath);
            }
            else
            {
                picProfile.Image = picProfile.Image = null;
            }
            
            LoadStudents();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            AddS add = new AddS();
            add.ShowDialog();
            LoadStudents();
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            //if (txtID.Text == "")
            //{
            //    MessageBox.Show("Please select a student to update.");
            //    return;
            //}

            //DialogResult dr = MessageBox.Show("Are you sure you want to update this student?",
            //                                  "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (dr == DialogResult.Yes)
            //{
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand("F_UpdateS", con);
            //        cmd.CommandType = CommandType.StoredProcedure;

            //        cmd.Parameters.AddWithValue("@StudentID", txtID.Text);
            //        cmd.Parameters.AddWithValue("@FirstName", txtFirstN.Text);
            //        cmd.Parameters.AddWithValue("@LastName", txtLast.Text);
            //        cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
            //        cmd.Parameters.AddWithValue("@Course", txtCourse.Text);
            //        cmd.Parameters.AddWithValue("@Department", txtDept.Text);
            //        cmd.Parameters.AddWithValue("@Teacher", txtTeacher.Text);

            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Student updated successfully!");

            //        AddLog("UPDATE", $"Updated student: {txtFirst.Text} {txtLast.Text}");
            //        LoadStudents();
            //        CountStudents();
            //    }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", txtID.Text);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Student deleted successfully!");
                    AddLog("DELETE", $"Deleted student ID: {txtID.Text}");
                    LoadStudents();
                    CountStudents();
                    ClearFields();
                }
            }
        }
        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_AddLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionType", action);
                cmd.Parameters.AddWithValue("@Description", desc);
                cmd.ExecuteNonQuery();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Filter", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }       
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudents.Rows[e.RowIndex];
                txtID.Text = row.Cells["StudentID"].Value.ToString();
                txtFirst.Text = row.Cells["FirstName"].Value.ToString();
                txtLast.Text = row.Cells["LastName"].Value.ToString();
                txtGender.Text = row.Cells["Gender"].Value.ToString();
                txtCourse.Text = row.Cells["Course"].Value.ToString();
                txtDept.Text = row.Cells["Department"].Value.ToString();
                txtTeacher.Text = row.Cells["Teacher"].Value.ToString();
            }
        }       

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllStudents", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }
        }
        private void CountStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActstud.Text = $"Active Students: {count}";
            }
        }
    }
}
