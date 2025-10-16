using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class Dashboard : Form
    {     

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
        }

        public Dashboard()
        {
            InitializeComponent();
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
