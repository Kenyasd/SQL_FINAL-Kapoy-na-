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

        string firstName, lastName, profilePath;

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LOGIN login = new LOGIN();
            login.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
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
        }

        public Dashboard(string fname, string lname, string photoPath)
        {
            InitializeComponent();
            firstName = fname;
            lastName = lname;
            profilePath = photoPath;
        }
    }
}
