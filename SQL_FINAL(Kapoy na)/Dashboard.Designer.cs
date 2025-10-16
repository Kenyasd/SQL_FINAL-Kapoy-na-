namespace SQL_FINAL_Kapoy_na_
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ActChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.UsersChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnteacherD = new System.Windows.Forms.Button();
            this.btndashboard = new System.Windows.Forms.Button();
            this.btnstudentD = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnreport = new System.Windows.Forms.Button();
            this.btnlogs = new System.Windows.Forms.Button();
            this.picProfile = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersChart)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.panel2.Controls.Add(this.ActChart);
            this.panel2.Controls.Add(this.UsersChart);
            this.panel2.Controls.Add(this.lbl);
            this.panel2.Location = new System.Drawing.Point(177, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 567);
            this.panel2.TabIndex = 8;
            // 
            // ActChart
            // 
            this.ActChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.ActChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            chartArea15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            chartArea15.Name = "ChartArea1";
            this.ActChart.ChartAreas.Add(chartArea15);
            legend15.BackColor = System.Drawing.Color.SlateGray;
            legend15.Name = "Legend1";
            this.ActChart.Legends.Add(legend15);
            this.ActChart.Location = new System.Drawing.Point(400, 107);
            this.ActChart.Name = "ActChart";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            this.ActChart.Series.Add(series15);
            this.ActChart.Size = new System.Drawing.Size(333, 350);
            this.ActChart.TabIndex = 14;
            this.ActChart.Text = "chart1";
            // 
            // UsersChart
            // 
            this.UsersChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            this.UsersChart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            chartArea16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(53)))), ((int)(((byte)(71)))));
            chartArea16.Name = "ChartArea1";
            this.UsersChart.ChartAreas.Add(chartArea16);
            legend16.BackColor = System.Drawing.Color.SlateGray;
            legend16.Name = "Legend1";
            this.UsersChart.Legends.Add(legend16);
            this.UsersChart.Location = new System.Drawing.Point(45, 107);
            this.UsersChart.Name = "UsersChart";
            series16.ChartArea = "ChartArea1";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.UsersChart.Series.Add(series16);
            this.UsersChart.Size = new System.Drawing.Size(333, 350);
            this.UsersChart.TabIndex = 13;
            this.UsersChart.Text = "chart1";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl.Location = new System.Drawing.Point(24, 25);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(186, 38);
            this.lbl.TabIndex = 12;
            this.lbl.Text = "Dashboard";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.Location = new System.Drawing.Point(0, 520);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(181, 48);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "LOGOUT";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(40)))), ((int)(((byte)(62)))));
            this.panel1.Controls.Add(this.btnteacherD);
            this.panel1.Controls.Add(this.btndashboard);
            this.panel1.Controls.Add(this.btnstudentD);
            this.panel1.Controls.Add(this.btnSubject);
            this.panel1.Controls.Add(this.btnreport);
            this.panel1.Controls.Add(this.btnlogs);
            this.panel1.Controls.Add(this.picProfile);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(-1, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 572);
            this.panel1.TabIndex = 7;
            // 
            // btnteacherD
            // 
            this.btnteacherD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnteacherD.FlatAppearance.BorderSize = 0;
            this.btnteacherD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnteacherD.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnteacherD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnteacherD.Location = new System.Drawing.Point(0, 310);
            this.btnteacherD.Name = "btnteacherD";
            this.btnteacherD.Size = new System.Drawing.Size(181, 48);
            this.btnteacherD.TabIndex = 18;
            this.btnteacherD.Text = "TEACHER";
            this.btnteacherD.UseVisualStyleBackColor = true;
            this.btnteacherD.Click += new System.EventHandler(this.btnteacherD_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndashboard.FlatAppearance.BorderSize = 0;
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndashboard.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btndashboard.Location = new System.Drawing.Point(1, 203);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(181, 48);
            this.btndashboard.TabIndex = 17;
            this.btndashboard.Text = "DASHBOARD";
            this.btndashboard.UseVisualStyleBackColor = true;
            this.btndashboard.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // btnstudentD
            // 
            this.btnstudentD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnstudentD.FlatAppearance.BorderSize = 0;
            this.btnstudentD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstudentD.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstudentD.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnstudentD.Location = new System.Drawing.Point(0, 260);
            this.btnstudentD.Name = "btnstudentD";
            this.btnstudentD.Size = new System.Drawing.Size(181, 48);
            this.btnstudentD.TabIndex = 16;
            this.btnstudentD.Text = "STUDENT";
            this.btnstudentD.UseVisualStyleBackColor = true;
            this.btnstudentD.Click += new System.EventHandler(this.btnstudentD_Click);
            // 
            // btnSubject
            // 
            this.btnSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubject.FlatAppearance.BorderSize = 0;
            this.btnSubject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubject.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubject.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSubject.Location = new System.Drawing.Point(0, 367);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(181, 48);
            this.btnSubject.TabIndex = 14;
            this.btnSubject.Text = "SUBJECT";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Click += new System.EventHandler(this.btnSubject_Click);
            // 
            // btnreport
            // 
            this.btnreport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnreport.FlatAppearance.BorderSize = 0;
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnreport.Location = new System.Drawing.Point(0, 412);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(181, 48);
            this.btnreport.TabIndex = 6;
            this.btnreport.Text = "REPORT";
            this.btnreport.UseVisualStyleBackColor = true;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnlogs
            // 
            this.btnlogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnlogs.FlatAppearance.BorderSize = 0;
            this.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogs.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogs.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnlogs.Location = new System.Drawing.Point(0, 462);
            this.btnlogs.Name = "btnlogs";
            this.btnlogs.Size = new System.Drawing.Size(181, 48);
            this.btnlogs.TabIndex = 7;
            this.btnlogs.Text = "LOGS";
            this.btnlogs.UseVisualStyleBackColor = true;
            this.btnlogs.Click += new System.EventHandler(this.btnlogs_Click);
            // 
            // picProfile
            // 
            this.picProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.picProfile.Location = new System.Drawing.Point(26, 33);
            this.picProfile.Name = "picProfile";
            this.picProfile.Size = new System.Drawing.Size(128, 76);
            this.picProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picProfile.TabIndex = 2;
            this.picProfile.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Location = new System.Drawing.Point(1, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(180, 198);
            this.panel3.TabIndex = 15;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(35)))), ((int)(((byte)(62)))));
            this.lblName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblName.Location = new System.Drawing.Point(44, 142);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(23, 18);
            this.lblName.TabIndex = 14;
            this.lblName.Text = "W";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 567);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ActChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsersChart)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProfile)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnteacherD;
        private System.Windows.Forms.Button btndashboard;
        private System.Windows.Forms.Button btnstudentD;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.Button btnreport;
        private System.Windows.Forms.Button btnlogs;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart UsersChart;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataVisualization.Charting.Chart ActChart;
    }
}