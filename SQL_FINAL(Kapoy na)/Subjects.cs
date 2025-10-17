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
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
            dgvSubjects.CurrentCellDirtyStateChanged += dgvSubjects_CurrentCellDirtyStateChanged;
        }

        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void Subjects_Load(object sender, EventArgs e)
        {
            lblName.Text = $"{UserSession.FirstName} {UserSession.LastName}";

            if (!string.IsNullOrEmpty(UserSession.ProfilePath) && File.Exists(UserSession.ProfilePath))
            {
                picProfile.Image = new Bitmap(UserSession.ProfilePath);
            }
            else
            {
                picProfile.Image = null; 
            }
            LoadSubjects();
            CountSubjects();
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }
        private void LoadSubjects()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("F_AllSub", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubjects.DataSource = dt;

                dgvSubjects.ReadOnly = false;
                if (dgvSubjects.Columns.Contains("Active"))
                    dgvSubjects.Columns["Active"].ReadOnly = false;
            }
        }
        private void CountSubjects()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CountActiveSubjects", con);
                cmd.CommandType = CommandType.StoredProcedure;
                int count = (int)cmd.ExecuteScalar();
                lblActSub.Text = $"Active Subjects: {count}";
            }
        }
        private void dgvSubjects_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvSubjects.IsCurrentCellDirty)
                dgvSubjects.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void dgvSubjects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSubjects.Columns[e.ColumnIndex].Name == "Active")
            {
                int subjectID = Convert.ToInt32(dgvSubjects.Rows[e.RowIndex].Cells["SubjectID"].Value);
                bool newStatus = Convert.ToBoolean(dgvSubjects.Rows[e.RowIndex].Cells["Active"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_UpdateSubjectActive", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.Parameters.AddWithValue("@Active", newStatus);
                    cmd.ExecuteNonQuery();
                }

                CountSubjects();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_SearchSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Keyword", txtSearch.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSubjects.DataSource = dt;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            AddSub add = new AddSub();
            add.ShowDialog();
            LoadSubjects();
            CountSubjects();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a subject to update.");
                return;
            }

            int subjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["SubjectID"].Value);
            string code = dgvSubjects.SelectedRows[0].Cells["SubjectCode"].Value.ToString();
            string name = dgvSubjects.SelectedRows[0].Cells["SubjectName"].Value.ToString();
            bool active = Convert.ToBoolean(dgvSubjects.SelectedRows[0].Cells["Active"].Value);

            UpdateSub upd = new UpdateSub(subjectID, code, name, active);
            upd.ShowDialog();
            LoadSubjects();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubjects.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a subject to delete.");
                return;
            }

            int subjectID = Convert.ToInt32(dgvSubjects.SelectedRows[0].Cells["SubjectID"].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this subject?",
                                              "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("F_DeleteSubject", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SubjectID", subjectID);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Subject deleted successfully!");
                LoadSubjects();
                CountSubjects();
            }
        }
    }
}
