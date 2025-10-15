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
    public partial class StudentDash : Form
    {
        string firstName, lastName, profilePath;

        public StudentDash()
        {
            InitializeComponent();
        }

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
        }
    }
}
