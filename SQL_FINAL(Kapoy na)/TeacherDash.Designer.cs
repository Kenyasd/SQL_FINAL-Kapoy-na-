namespace SQL_FINAL_Kapoy_na_
{
    partial class TeacherDash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idinstruc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTeacherD = new System.Windows.Forms.Button();
            this.btnStudentD = new System.Windows.Forms.Button();
            this.btndashB = new System.Windows.Forms.Button();
            this.btnsubject = new System.Windows.Forms.Button();
            this.btnlogs = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picProfile = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F);
            this.txtSearch.Location = new System.Drawing.Point(594, 50);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 25);
            this.txtSearch.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 38);
            this.label1.TabIndex = 12;
            this.label1.Text = "Teacher Dashboard";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idinstruc,
            this.instructor,
            this.gender,
            this.email,
            this.department,
            this.course,
            this.student,
            this.grade,
            this.status});
            this.dataGridView1.Location = new System.Drawing.Point(2, 81);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(731, 413);
            this.dataGridView1.TabIndex = 11;
            // 
            // idinstruc
            // 
            this.idinstruc.HeaderText = "ID ";
            this.idinstruc.Name = "idinstruc";
            // 
            // instructor
            // 
            this.instructor.HeaderText = "INSTRUCTOR";
            this.instructor.Name = "instructor";
            // 
            // gender
            // 
            this.gender.HeaderText = "GENDER";
            this.gender.Name = "gender";
            // 
            // email
            // 
            this.email.HeaderText = "EMAIL";
            this.email.Name = "email";
            // 
            // department
            // 
            this.department.HeaderText = "DEPARTMENT";
            this.department.Name = "department";
            // 
            // course
            // 
            this.course.HeaderText = "COURSE";
            this.course.Name = "course";
            // 
            // student
            // 
            this.student.HeaderText = "STUDENT";
            this.student.Name = "student";
            // 
            // grade
            // 
            this.grade.HeaderText = "GRADE";
            this.grade.Name = "grade";
            // 
            // status
            // 
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            // 
            // btnTeacherD
            // 
            this.btnTeacherD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTeacherD.FlatAppearance.BorderSize = 0;
            this.btnTeacherD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTeacherD.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnTeacherD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnTeacherD.Location = new System.Drawing.Point(3, 308);
            this.btnTeacherD.Name = "btnTeacherD";
            this.btnTeacherD.Size = new System.Drawing.Size(178, 48);
            this.btnTeacherD.TabIndex = 25;
            this.btnTeacherD.Text = "TEACHER";
            this.btnTeacherD.UseVisualStyleBackColor = true;
            // 
            // btnStudentD
            // 
            this.btnStudentD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStudentD.FlatAppearance.BorderSize = 0;
            this.btnStudentD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudentD.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnStudentD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnStudentD.Location = new System.Drawing.Point(3, 262);
            this.btnStudentD.Name = "btnStudentD";
            this.btnStudentD.Size = new System.Drawing.Size(178, 48);
            this.btnStudentD.TabIndex = 24;
            this.btnStudentD.Text = "STUDENT";
            this.btnStudentD.UseVisualStyleBackColor = true;
            // 
            // btndashB
            // 
            this.btndashB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndashB.FlatAppearance.BorderSize = 0;
            this.btndashB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashB.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btndashB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btndashB.Location = new System.Drawing.Point(3, 204);
            this.btndashB.Name = "btndashB";
            this.btndashB.Size = new System.Drawing.Size(178, 48);
            this.btndashB.TabIndex = 23;
            this.btndashB.Text = "DASHBOARD";
            this.btndashB.UseVisualStyleBackColor = true;
            // 
            // btnsubject
            // 
            this.btnsubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsubject.FlatAppearance.BorderSize = 0;
            this.btnsubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsubject.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnsubject.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnsubject.Location = new System.Drawing.Point(3, 360);
            this.btnsubject.Name = "btnsubject";
            this.btnsubject.Size = new System.Drawing.Size(178, 48);
            this.btnsubject.TabIndex = 19;
            this.btnsubject.Text = "SUBJECT";
            this.btnsubject.UseVisualStyleBackColor = true;
            // 
            // btnlogs
            // 
            this.btnlogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnlogs.FlatAppearance.BorderSize = 0;
            this.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogs.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnlogs.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnlogs.Location = new System.Drawing.Point(0, 459);
            this.btnlogs.Name = "btnlogs";
            this.btnlogs.Size = new System.Drawing.Size(181, 48);
            this.btnlogs.TabIndex = 7;
            this.btnlogs.Text = "LOGS";
            this.btnlogs.UseVisualStyleBackColor = true;
            // 
            // btnreport
            // 
            this.btnreport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnreport.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnreport.Location = new System.Drawing.Point(0, 409);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(181, 48);
            this.btnreport.TabIndex = 6;
            this.btnreport.Text = "REPORT";
            this.btnreport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(0, 516);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 48);
            this.button1.TabIndex = 1;
            this.button1.Text = "LOGOUT";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.picProfile);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 198);
            this.panel1.TabIndex = 18;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblName.Location = new System.Drawing.Point(62, 140);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(54, 19);
            this.lblName.TabIndex = 13;
            this.lblName.Text = "label2";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.panel3.Controls.Add(this.btnTeacherD);
            this.panel3.Controls.Add(this.btnStudentD);
            this.panel3.Controls.Add(this.btndashB);
            this.panel3.Controls.Add(this.btnsubject);
            this.panel3.Controls.Add(this.btnlogs);
            this.panel3.Controls.Add(this.btnreport);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Location = new System.Drawing.Point(-3, -3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 572);
            this.panel3.TabIndex = 18;
            // 
            // button8
            // 
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(605, 507);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(128, 48);
            this.button8.TabIndex = 10;
            this.button8.Text = "DELETE";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // btnupdate
            // 
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.White;
            this.btnupdate.Location = new System.Drawing.Point(326, 507);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(128, 48);
            this.btnupdate.TabIndex = 9;
            this.btnupdate.Text = "UPDATE";
            this.btnupdate.UseVisualStyleBackColor = true;
            // 
            // btnadd
            // 
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(30, 507);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(128, 48);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "ADD";
            this.btnadd.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.btnupdate);
            this.panel2.Controls.Add(this.btnadd);
            this.panel2.Location = new System.Drawing.Point(178, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(747, 567);
            this.panel2.TabIndex = 17;
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.picProfile.Location = new System.Drawing.Point(26, 21);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(128, 76);
            this.picProfile.TabIndex = 2;
            this.picProfile.TabStop = false;
            // 
            // TeacherDash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TeacherDash";
            this.Text = "TeacherDash";
            this.Load += new System.EventHandler(this.TeacherDash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idinstruc;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn department;
        private System.Windows.Forms.DataGridViewTextBoxColumn course;
        private System.Windows.Forms.DataGridViewTextBoxColumn student;
        private System.Windows.Forms.DataGridViewTextBoxColumn grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btnTeacherD;
        private System.Windows.Forms.Button btnStudentD;
        private System.Windows.Forms.Button btndashB;
        private System.Windows.Forms.Button btnsubject;
        private System.Windows.Forms.Button btnlogs;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Panel panel2;
    }
}