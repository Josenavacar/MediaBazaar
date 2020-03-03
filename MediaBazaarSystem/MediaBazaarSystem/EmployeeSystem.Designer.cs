namespace MediaBazaarSystem
{
    partial class EmployeeSystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSystem));
            this.tbControlEmp = new System.Windows.Forms.TabControl();
            this.tbPageHome = new System.Windows.Forms.TabPage();
            this.picBoxLogout = new System.Windows.Forms.PictureBox();
            this.dataEmpWorkSchedule = new System.Windows.Forms.DataGridView();
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWorkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpWorkSchedule = new System.Windows.Forms.DateTimePicker();
            this.tbPageStatistics = new System.Windows.Forms.TabPage();
            this.btnViewAllDepartments = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnViewAllProducts = new System.Windows.Forms.Button();
            this.btnViewAllEmployees = new System.Windows.Forms.Button();
            this.dataGridViewEmployeeStats = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPageProfile = new System.Windows.Forms.TabPage();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.pictureBoxEmployeePhoto = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtBoxAddress = new System.Windows.Forms.TextBox();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.txtBoxAge = new System.Windows.Forms.TextBox();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.btnUpdateProfile = new System.Windows.Forms.Button();
            this.lbEmployeeInfo = new System.Windows.Forms.ListBox();
            this.tbControlEmp.SuspendLayout();
            this.tbPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpWorkSchedule)).BeginInit();
            this.tbPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).BeginInit();
            this.tbPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControlEmp
            // 
            this.tbControlEmp.Controls.Add(this.tbPageHome);
            this.tbControlEmp.Controls.Add(this.tbPageStatistics);
            this.tbControlEmp.Controls.Add(this.tbPageProfile);
            this.tbControlEmp.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControlEmp.Location = new System.Drawing.Point(12, 12);
            this.tbControlEmp.Name = "tbControlEmp";
            this.tbControlEmp.SelectedIndex = 0;
            this.tbControlEmp.Size = new System.Drawing.Size(878, 709);
            this.tbControlEmp.TabIndex = 1;
            // 
            // tbPageHome
            // 
            this.tbPageHome.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageHome.Controls.Add(this.picBoxLogout);
            this.tbPageHome.Controls.Add(this.dataEmpWorkSchedule);
            this.tbPageHome.Controls.Add(this.dtpWorkSchedule);
            this.tbPageHome.Location = new System.Drawing.Point(4, 30);
            this.tbPageHome.Name = "tbPageHome";
            this.tbPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageHome.Size = new System.Drawing.Size(870, 675);
            this.tbPageHome.TabIndex = 0;
            this.tbPageHome.Text = "Home";
            // 
            // picBoxLogout
            // 
            this.picBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogout.Image")));
            this.picBoxLogout.Location = new System.Drawing.Point(830, 3);
            this.picBoxLogout.Name = "picBoxLogout";
            this.picBoxLogout.Size = new System.Drawing.Size(34, 27);
            this.picBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogout.TabIndex = 8;
            this.picBoxLogout.TabStop = false;
            this.picBoxLogout.Click += new System.EventHandler(this.picBoxLogout_Click);
            // 
            // dataEmpWorkSchedule
            // 
            this.dataEmpWorkSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmpWorkSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEmployeeName,
            this.clmnRole,
            this.clmnStartTime,
            this.clmnEndTime,
            this.clmnWorkDate});
            this.dataEmpWorkSchedule.Location = new System.Drawing.Point(90, 80);
            this.dataEmpWorkSchedule.Name = "dataEmpWorkSchedule";
            this.dataEmpWorkSchedule.RowHeadersWidth = 51;
            this.dataEmpWorkSchedule.RowTemplate.Height = 24;
            this.dataEmpWorkSchedule.Size = new System.Drawing.Size(680, 485);
            this.dataEmpWorkSchedule.TabIndex = 4;
            // 
            // clmnEmployeeName
            // 
            this.clmnEmployeeName.HeaderText = "Employee";
            this.clmnEmployeeName.MinimumWidth = 6;
            this.clmnEmployeeName.Name = "clmnEmployeeName";
            this.clmnEmployeeName.Width = 125;
            // 
            // clmnRole
            // 
            this.clmnRole.HeaderText = "Role";
            this.clmnRole.MinimumWidth = 6;
            this.clmnRole.Name = "clmnRole";
            this.clmnRole.Width = 125;
            // 
            // clmnStartTime
            // 
            this.clmnStartTime.HeaderText = "Start Time";
            this.clmnStartTime.MinimumWidth = 6;
            this.clmnStartTime.Name = "clmnStartTime";
            this.clmnStartTime.Width = 125;
            // 
            // clmnEndTime
            // 
            this.clmnEndTime.HeaderText = "End Time";
            this.clmnEndTime.MinimumWidth = 6;
            this.clmnEndTime.Name = "clmnEndTime";
            this.clmnEndTime.Width = 125;
            // 
            // clmnWorkDate
            // 
            this.clmnWorkDate.HeaderText = "Date";
            this.clmnWorkDate.MinimumWidth = 6;
            this.clmnWorkDate.Name = "clmnWorkDate";
            this.clmnWorkDate.Width = 125;
            // 
            // dtpWorkSchedule
            // 
            this.dtpWorkSchedule.Location = new System.Drawing.Point(237, 597);
            this.dtpWorkSchedule.Name = "dtpWorkSchedule";
            this.dtpWorkSchedule.Size = new System.Drawing.Size(385, 28);
            this.dtpWorkSchedule.TabIndex = 3;
            // 
            // tbPageStatistics
            // 
            this.tbPageStatistics.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageStatistics.Controls.Add(this.btnViewAllDepartments);
            this.tbPageStatistics.Controls.Add(this.btnSearch);
            this.tbPageStatistics.Controls.Add(this.txtBoxSearch);
            this.tbPageStatistics.Controls.Add(this.btnViewAllProducts);
            this.tbPageStatistics.Controls.Add(this.btnViewAllEmployees);
            this.tbPageStatistics.Controls.Add(this.dataGridViewEmployeeStats);
            this.tbPageStatistics.Location = new System.Drawing.Point(4, 30);
            this.tbPageStatistics.Name = "tbPageStatistics";
            this.tbPageStatistics.Size = new System.Drawing.Size(870, 675);
            this.tbPageStatistics.TabIndex = 2;
            this.tbPageStatistics.Text = "Statistics";
            // 
            // btnViewAllDepartments
            // 
            this.btnViewAllDepartments.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllDepartments.Location = new System.Drawing.Point(158, 527);
            this.btnViewAllDepartments.Name = "btnViewAllDepartments";
            this.btnViewAllDepartments.Size = new System.Drawing.Size(496, 42);
            this.btnViewAllDepartments.TabIndex = 8;
            this.btnViewAllDepartments.Text = "View All Departments";
            this.btnViewAllDepartments.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(645, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(190, 42);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(32, 23);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 32);
            this.txtBoxSearch.TabIndex = 5;
            // 
            // btnViewAllProducts
            // 
            this.btnViewAllProducts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllProducts.Location = new System.Drawing.Point(158, 464);
            this.btnViewAllProducts.Name = "btnViewAllProducts";
            this.btnViewAllProducts.Size = new System.Drawing.Size(496, 42);
            this.btnViewAllProducts.TabIndex = 4;
            this.btnViewAllProducts.Text = "View All Products";
            this.btnViewAllProducts.UseVisualStyleBackColor = false;
            // 
            // btnViewAllEmployees
            // 
            this.btnViewAllEmployees.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllEmployees.Location = new System.Drawing.Point(158, 590);
            this.btnViewAllEmployees.Name = "btnViewAllEmployees";
            this.btnViewAllEmployees.Size = new System.Drawing.Size(496, 42);
            this.btnViewAllEmployees.TabIndex = 3;
            this.btnViewAllEmployees.Text = "View All Employees";
            this.btnViewAllEmployees.UseVisualStyleBackColor = false;
            // 
            // dataGridViewEmployeeStats
            // 
            this.dataGridViewEmployeeStats.AllowUserToOrderColumns = true;
            this.dataGridViewEmployeeStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmployeeStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridViewEmployeeStats.Location = new System.Drawing.Point(32, 95);
            this.dataGridViewEmployeeStats.Name = "dataGridViewEmployeeStats";
            this.dataGridViewEmployeeStats.RowHeadersWidth = 51;
            this.dataGridViewEmployeeStats.RowTemplate.Height = 24;
            this.dataGridViewEmployeeStats.Size = new System.Drawing.Size(803, 330);
            this.dataGridViewEmployeeStats.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Employee Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Position";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Hours worked";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Is Available";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Start Time";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "End Time";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // tbPageProfile
            // 
            this.tbPageProfile.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageProfile.Controls.Add(this.lblEmployeeName);
            this.tbPageProfile.Controls.Add(this.pictureBoxEmployeePhoto);
            this.tbPageProfile.Controls.Add(this.label6);
            this.tbPageProfile.Controls.Add(this.lblEmail);
            this.tbPageProfile.Controls.Add(this.txtBoxEmail);
            this.tbPageProfile.Controls.Add(this.lblAddress);
            this.tbPageProfile.Controls.Add(this.lblAge);
            this.tbPageProfile.Controls.Add(this.lblLastName);
            this.tbPageProfile.Controls.Add(this.lblFirstName);
            this.tbPageProfile.Controls.Add(this.txtBoxAddress);
            this.tbPageProfile.Controls.Add(this.txtBoxLastName);
            this.tbPageProfile.Controls.Add(this.txtBoxAge);
            this.tbPageProfile.Controls.Add(this.txtBoxFirstName);
            this.tbPageProfile.Controls.Add(this.btnUpdateProfile);
            this.tbPageProfile.Controls.Add(this.lbEmployeeInfo);
            this.tbPageProfile.Location = new System.Drawing.Point(4, 30);
            this.tbPageProfile.Name = "tbPageProfile";
            this.tbPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageProfile.Size = new System.Drawing.Size(870, 675);
            this.tbPageProfile.TabIndex = 1;
            this.tbPageProfile.Text = "Profile";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(15, 23);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(283, 21);
            this.lblEmployeeName.TabIndex = 15;
            this.lblEmployeeName.Text = "Hello (here goes the user\'s name)";
            // 
            // pictureBoxEmployeePhoto
            // 
            this.pictureBoxEmployeePhoto.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEmployeePhoto.Image")));
            this.pictureBoxEmployeePhoto.Location = new System.Drawing.Point(526, 23);
            this.pictureBoxEmployeePhoto.Name = "pictureBoxEmployeePhoto";
            this.pictureBoxEmployeePhoto.Size = new System.Drawing.Size(297, 263);
            this.pictureBoxEmployeePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxEmployeePhoto.TabIndex = 13;
            this.pictureBoxEmployeePhoto.TabStop = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 14;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(447, 509);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 21);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email:";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEmail.Location = new System.Drawing.Point(526, 504);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(297, 32);
            this.txtBoxEmail.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(422, 465);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 21);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(454, 415);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(50, 21);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Age:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(399, 364);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(105, 21);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(403, 312);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(101, 21);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddress.Location = new System.Drawing.Point(526, 460);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(297, 32);
            this.txtBoxAddress.TabIndex = 5;
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxLastName.Location = new System.Drawing.Point(526, 359);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(297, 32);
            this.txtBoxLastName.TabIndex = 4;
            // 
            // txtBoxAge
            // 
            this.txtBoxAge.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAge.Location = new System.Drawing.Point(526, 410);
            this.txtBoxAge.Name = "txtBoxAge";
            this.txtBoxAge.Size = new System.Drawing.Size(297, 32);
            this.txtBoxAge.TabIndex = 3;
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFirstName.Location = new System.Drawing.Point(526, 307);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(297, 32);
            this.txtBoxFirstName.TabIndex = 2;
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnUpdateProfile.Location = new System.Drawing.Point(526, 554);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(297, 44);
            this.btnUpdateProfile.TabIndex = 1;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            // 
            // lbEmployeeInfo
            // 
            this.lbEmployeeInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmployeeInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeInfo.FormattingEnabled = true;
            this.lbEmployeeInfo.ItemHeight = 23;
            this.lbEmployeeInfo.Location = new System.Drawing.Point(19, 65);
            this.lbEmployeeInfo.Name = "lbEmployeeInfo";
            this.lbEmployeeInfo.Size = new System.Drawing.Size(330, 533);
            this.lbEmployeeInfo.TabIndex = 0;
            // 
            // EmployeeSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(907, 733);
            this.Controls.Add(this.tbControlEmp);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeSystem";
            this.Text = "EmployeeSystem";
            this.tbControlEmp.ResumeLayout(false);
            this.tbPageHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpWorkSchedule)).EndInit();
            this.tbPageStatistics.ResumeLayout(false);
            this.tbPageStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).EndInit();
            this.tbPageProfile.ResumeLayout(false);
            this.tbPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControlEmp;
        private System.Windows.Forms.TabPage tbPageHome;
        private System.Windows.Forms.DateTimePicker dtpWorkSchedule;
        private System.Windows.Forms.TabPage tbPageStatistics;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TabPage tbPageProfile;
        private System.Windows.Forms.PictureBox pictureBoxEmployeePhoto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtBoxAddress;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.TextBox txtBoxAge;
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.Button btnUpdateProfile;
        private System.Windows.Forms.ListBox lbEmployeeInfo;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Button btnViewAllDepartments;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnViewAllProducts;
        private System.Windows.Forms.Button btnViewAllEmployees;
        private System.Windows.Forms.DataGridView dataEmpWorkSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWorkDate;
        private System.Windows.Forms.PictureBox picBoxLogout;
    }
}