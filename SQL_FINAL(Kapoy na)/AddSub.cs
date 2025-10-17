﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_FINAL_Kapoy_na_
{
    public partial class AddSub : Form
    {
        public AddSub()
        {
            InitializeComponent();
            LoadTeachers();
            LoadStudents();
        }
        string connectionString = @"Data Source=DESKTOP-IBHAJPM\SQLEXPRESS;Initial Catalog=FINAL_DB;Integrated Security=True";

        private void LoadTeachers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TeacherID, FirstName + ' ' + LastName AS FullName FROM Teachers WHERE Active = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTeacher.DisplayMember = "FullName";
                cmbTeacher.ValueMember = "TeacherID";
                cmbTeacher.DataSource = dt;
            }
        }

        private void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT StudentID, FirstName + ' ' + LastName AS FullName FROM Students WHERE Active = 1", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbStudent.DisplayMember = "FullName";
                cmbStudent.ValueMember = "StudentID";
                cmbStudent.DataSource = dt;
            }
        }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubCode.Text) || string.IsNullOrEmpty(txtSubName.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            int teacherID = Convert.ToInt32(cmbTeacher.SelectedValue);
            int studentID = Convert.ToInt32(cmbStudent.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // Insert into Subjects
                SqlCommand cmd = new SqlCommand("F_AddSubject", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubjectCode", txtSubCode.Text);
                cmd.Parameters.AddWithValue("@SubjectName", txtSubName.Text);
                cmd.ExecuteNonQuery();

                // Get SubjectID of the newly added subject
                SqlCommand getID = new SqlCommand("SELECT IDENT_CURRENT('Subjects')", con);
                int subjectID = Convert.ToInt32(getID.ExecuteScalar());

                // Link Teacher to Subject
                SqlCommand linkTeacher = new SqlCommand("INSERT INTO TeacherSubjects (TeacherID, SubjectID) VALUES (@TID, @SID)", con);
                linkTeacher.Parameters.AddWithValue("@TID", teacherID);
                linkTeacher.Parameters.AddWithValue("@SID", subjectID);
                linkTeacher.ExecuteNonQuery();

                // Link Student to Subject
                SqlCommand linkStudent = new SqlCommand("INSERT INTO StudentSubjects (StudentID, SubjectID) VALUES (@STID, @SID)", con);
                linkStudent.Parameters.AddWithValue("@STID", studentID);
                linkStudent.Parameters.AddWithValue("@SID", subjectID);
                linkStudent.ExecuteNonQuery();

                // 5️⃣ Log creation
                AddLog("CREATE", $"Added Subject {txtSubCode.Text} ({txtSubName.Text})");

                MessageBox.Show("Subject added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
