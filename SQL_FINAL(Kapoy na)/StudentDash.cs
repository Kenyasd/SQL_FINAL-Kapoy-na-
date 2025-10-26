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
        // Database connection string
        string connectionString = DBConnection.ConnectionString;

        public StudentDash()
        {
            InitializeComponent();
            // Real-time updating of "Active" checkbox in DataGridView
            dgvStudents.CurrentCellDirtyStateChanged += dgvStudents_CurrentCellDirtyStateChanged;
            dgvStudents.CellValueChanged += dgvStudents_CellValueChanged;
        }         

        private void StudentDash_Load(object sender, EventArgs e)
        {
            // Display current user’s name
            lblName.Text = $"{UserSession.FirstName} {UserSession.LastName}";

            // Display profile picture (if exists)
            if (!string.IsNullOrEmpty(UserSession.ProfilePath) && File.Exists(UserSession.ProfilePath))
            {
                picProfile.Image = new Bitmap(UserSession.ProfilePath);
            }
            else
            {
                picProfile.Image = null; 
            }
            // Load students and count active ones
            LoadStudents();
            CountStudents();
        }

        //Add Students
        private void btnadd_Click(object sender, EventArgs e)
        {
            AddS add = new AddS();
            add.ShowDialog();
            this.Hide();
            LoadStudents();
            CountStudents();

        }

        //Update Students
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

            DataGridViewRow row = dgvStudents.SelectedRows[0];
            int studentID = Convert.ToInt32(row.Cells["StudentID"].Value);
            string firstName = row.Cells["FirstName"].Value.ToString();
            string lastName = row.Cells["LastName"].Value.ToString();

            // Open the Update Form 
            UpdateS update = new UpdateS(studentID);
            update.ShowDialog();
            LoadStudents();

            // Log the update action
            AddLog("UPDATE", $"Updated student record: {firstName} {lastName} (ID: {studentID})");
        }

        //Delete Students
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

        //Log Actions (Create, Update, Delete)
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

        //Search Students
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
            }       
        }

        //Handle Active Status Change
        private void dgvStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvStudents.Columns[e.ColumnIndex].Name == "Active")
            {
                int studentID = Convert.ToInt32(dgvStudents.Rows[e.RowIndex].Cells["StudentID"].Value);
                bool newStatus = Convert.ToBoolean(dgvStudents.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_ActiveStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                AddLog("UPDATE", $"Changed student ID {studentID} Active status to {newStatus}");
                CountStudents();
            }
        }

        //Edit on Checkbox Toggle
        private void dgvStudents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStudents.IsCurrentCellDirty)
            {
                dgvStudents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        //Load Students from Database
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
                
                dgvStudents.ReadOnly = false;
                dgvStudents.Columns["StudentID"].ReadOnly = true; 
                dgvStudents.Columns["Active"].ReadOnly = false;
            }
        }
        //Count Active Students
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

        //Navigation Buttons
        private void btndashB_Click(object sender, EventArgs e)
        {
            Dashboard dash = new Dashboard();
            dash.Show();
            this.Hide();
        }

        private void btnStudentD_Click(object sender, EventArgs e)
        {
            StudentDash studentDash = new StudentDash();
            studentDash.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void btnTeacherD_Click(object sender, EventArgs e)
        {
            TeacherDash teacherDash = new TeacherDash();
            teacherDash.Show();
            this.Hide();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Hide();
        }

        private void btnlogs_Click(object sender, EventArgs e)
        {
            LOGS logs = new LOGS();
            logs.Show();
            this.Hide();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            SUBJECT sUBJECT = new SUBJECT();
            sUBJECT.Show();
            this.Hide();
        }
    }
}
