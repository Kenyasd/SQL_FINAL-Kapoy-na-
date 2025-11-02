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
    public partial class Reports : Form
    {
        // Database connection string
        string connectionString = DBConnection.ConnectionString;
        
        public Reports()
        {
            InitializeComponent();
        }

        // Load user info and report counts on form load
        private void Reports_Load(object sender, EventArgs e)
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
                picProfile.Image = null; // or a default picture
            }
            // Load report counts
            LoadReportCounts();
        }

        //Navigate to other forms
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

        // Logout and return to login form
        private void button1_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        // Get count from stored procedure
        private int GetCount(string procedure)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("F_CountActS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
        // Get grouped count from stored procedure
        private string GetGroupedCount(string procedure)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(procedure, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt.Rows.Count.ToString();
            }
        }

        // Load all report counts into labels
        private void LoadReportCounts()
        {
            lblActStud.Text = GetCount("F_CountActiveS").ToString();
            lblActTeach.Text = GetCount("F_CountActiveT").ToString();
            lblActSub.Text = GetCount("F_CountActiveSubjects").ToString();

            lblStudPerSub.Text = GetGroupedCount("F_CountStudentsPerSubject");
            lblStudPerTeach.Text = GetGroupedCount("F_CountStudentsPerTeacher");
        }

    }
}
