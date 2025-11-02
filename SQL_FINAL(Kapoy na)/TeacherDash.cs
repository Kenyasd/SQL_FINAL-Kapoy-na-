using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class TeacherDash : Form
    {
        // Database connection string
        string connectionString = DBConnection.ConnectionString;

        public TeacherDash()
        {
            InitializeComponent();
            
            // Real-time updating of "Active" checkbox in DataGridView
            dgvTeachers.CurrentCellDirtyStateChanged += dgvTeachers_CurrentCellDirtyStateChanged;
            dgvTeachers.CellValueChanged += dgvTeachers_CellValueChanged;
        }

        private void TeacherDash_Load(object sender, EventArgs e)
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
            
            // Load teachers and count active ones
            LoadTeachers();
            CountTeachers();
        }

        //Load all teachers from stored procedure
        private void LoadTeachers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllTeachers", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTeachers.DataSource = dt;

                // Format DataGridView
                dgvTeachers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTeachers.ReadOnly = false;
                dgvTeachers.Columns["TeacherID"].ReadOnly = true;
                dgvTeachers.Columns["Active"].ReadOnly = false;
                dgvTeachers.Columns["Active"].HeaderText = "Active";               

            }
        }

        //Edit immediately when checkbox is toggled
        private void dgvTeachers_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.IsCurrentCellDirty)
                dgvTeachers.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        //Checkbox value changes — update database
        private void dgvTeachers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTeachers.Columns[e.ColumnIndex].Name == "Active")
            {
                int teacherID = Convert.ToInt32(dgvTeachers.Rows[e.RowIndex].Cells["TeacherID"].Value);
                bool newStatus = Convert.ToBoolean(dgvTeachers.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_UpActStatusT", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }
                    
                // Log and refresh count
                AddLog("UPDATE", $"Changed teacher {teacherID} active status to {newStatus}");
                CountTeachers();
            }
        }

        //Count active teachers via stored procedure
        private void CountTeachers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActTeac.Text = $"Active Teachers: {count}";
            }
        }

        //Navigation Buttons — switch between forms
        private void btndashB_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnStudentD_Click(object sender, EventArgs e)
        {
            StudentDash studentDash = new StudentDash();
            studentDash.Show();
            this.Hide();
        }

        private void btnTeacherD_Click(object sender, EventArgs e)
        {
            TeacherDash teacherDash = new TeacherDash();
            teacherDash.Show();
            this.Hide();
        }

        private void btnsubject_Click(object sender, EventArgs e)
        {
            Subjects subjects = new Subjects();
            subjects.Show();
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
            LOGS lOGS = new LOGS();
            lOGS.Show();
            this.Hide();
        }

        //Logout
        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
        
        //Search teachers
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTeachers.DataSource = dt;
            }
        }

        //Add Teachers
        private void btnadd_Click(object sender, EventArgs e)
        {
            AddT add = new AddT();
            add.ShowDialog();
            LoadTeachers();
            CountTeachers();
        }

        //Update Teachers
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a teacher to update.");
                return;
            }

            DataGridViewRow row = dgvTeachers.SelectedRows[0];
            int teacherID = Convert.ToInt32(row.Cells["TeacherID"].Value);

            UpdateT update = new UpdateT(
                teacherID,
                row.Cells["FirstName"].Value.ToString(),
                row.Cells["LastName"].Value.ToString(),
                row.Cells["Gender"].Value.ToString(),
                row.Cells["Department"].Value.ToString(),
                row.Cells["Subject"].Value.ToString(),
                row.Cells["Username"].Value.ToString(),
                row.Cells["Password"].Value.ToString()
            );

            update.ShowDialog();
            LoadTeachers(); // reload grid after editing
        }

        //Delete Teachers
        private void button8_Click(object sender, EventArgs e)
        {
            if (dgvTeachers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a teacher to delete.");
                return;
            }

            int teacherID = Convert.ToInt32(dgvTeachers.SelectedRows[0].Cells["TeacherID"].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this teacher?", "Confirm Delete",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteTeacher", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeacherID", teacherID);
                    cmd.ExecuteNonQuery();
                }

                AddLog("DELETE", $"Deleted teacher ID {teacherID}");
                MessageBox.Show("Teacher deleted successfully!");
                LoadTeachers();
                CountTeachers();
            }
        }

        //Log actions (Create, Update, Delete)
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
