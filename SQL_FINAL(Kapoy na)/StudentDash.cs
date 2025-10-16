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
        string firstName="";
        string lastName="";
        string  profilePath = "";
        public StudentDash()
        {
            InitializeComponent();
        }

        public StudentDash(string fname, string lname, string photoPath)
        {
            InitializeComponent();
            firstName = fname;
            lastName = lname;
            profilePath = photoPath;
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
            CountStudents();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            AddS add = new AddS();
            add.ShowDialog();
            LoadStudents();
            CountStudents();

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);

           // UpdateS update = new UpdateS(studentID);
           // update.ShowDialog();
            LoadStudents();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            int studentID = Convert.ToInt32(dgvStudents.SelectedRows[0].Cells["StudentID"].Value);
            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteStudent", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.ExecuteNonQuery();
                }

                AddLog("DELETE", $"Deleted student ID: {studentID}");
                MessageBox.Show("Student deleted successfully!");
                LoadStudents();
                CountStudents();
            }
        }
        private void AddLog(string action, string desc)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_Log", con);
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
                dgvStudents.Rows[e.RowIndex].Selected = true;
            }
        }       

        private void LoadStudents()
        {
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlDataAdapter da = new SqlDataAdapter("F_AllStudents", con);
            //    da.SelectCommand.CommandType = CommandType.StoredProcedure;

            //    DataTable dt = new DataTable();
            //    da.Fill(dt);
            //    dgvStudents.DataSource = dt;
            //}
        }
        private void CountStudents()
        {
            //using (SqlConnection con = new SqlConnection(connectionString))
            //{
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand("F_CountActS", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    int count = (int)cmd.ExecuteScalar();
            //    lblActstud.Text = $"Active Students: {count}";
            //}
        }
    }
}
