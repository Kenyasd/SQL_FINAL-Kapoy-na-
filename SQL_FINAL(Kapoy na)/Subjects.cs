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
                lblActiveSubj.Text = $"Active Subjects: {count}";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {

        }
    }
}
