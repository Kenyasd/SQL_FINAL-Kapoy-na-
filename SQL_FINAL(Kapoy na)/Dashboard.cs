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
using System.Windows.Forms.DataVisualization.Charting;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class Dashboard : Form
    {
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.FirstName = null;
            UserSession.LastName = null;
            UserSession.ProfilePath = null;

            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void btnstudentD_Click(object sender, EventArgs e)
        {           
            StudentDash studentDash = new StudentDash();
            studentDash.Show();
            this.Hide();
        }

        private void btnteacherD_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeacherDash teacherDash = new TeacherDash();
            teacherDash.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
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
            LoadStudentChart();
            LoadTeacherChart();
        }

        public Dashboard()
        {
            InitializeComponent();
        }
        private void LoadStudentChart()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int active = Convert.ToInt32(reader["ActiveStudents"]);
                    int inactive = Convert.ToInt32(reader["InactiveStudents"]);

                    chartStudents.Series.Clear();
                    Series series = new Series("Students");
                    series.ChartType = SeriesChartType.Pie;
                    series.Points.AddXY("Active", active);
                    series.Points.AddXY("Inactive", inactive);
                    chartStudents.Series.Add(series);
                }
            }
        }
        private void LoadTeacherChart()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("F_CTeachers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int active = Convert.ToInt32(reader["ActiveTeachers"]);
                    int inactive = Convert.ToInt32(reader["InactiveTeachers"]);

                    chartTeachers.Series.Clear();
                    Series series = new Series("Teachers");
                    series.ChartType = SeriesChartType.Pie;
                    series.Points.AddXY("Active", active);
                    series.Points.AddXY("Inactive", inactive);
                    chartTeachers.Series.Add(series);
                }
            }
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnSubject_Click(object sender, EventArgs e)
        {
            SUBJECT sUBJECT = new SUBJECT();
            sUBJECT.Show();
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
    }
}
