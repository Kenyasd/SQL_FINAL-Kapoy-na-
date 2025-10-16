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
    public partial class TeacherDash : Form
    {

        string firstName = "";
        string lastName = "";
        string profilePath = "";

        public TeacherDash(string fname, string lname, string photoPath)
        {
            InitializeComponent();
            firstName = fname;
            lastName = lname;
            profilePath = photoPath;
        }

        private void TeacherDash_Load(object sender, EventArgs e)
        {

        }
    }
}
