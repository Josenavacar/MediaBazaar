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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.dtpWorkSchedule = new System.Windows.Forms.DateTimePicker();
            this.btnViewAllWorkShifts = new System.Windows.Forms.Button();
            this.lbWorkSchedule = new System.Windows.Forms.ListBox();
            this.tabPageStatistics = new System.Windows.Forms.TabPage();
            this.lbEmployeeStatistics = new System.Windows.Forms.ListBox();
            this.dataGridViewEmployeeStats = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageProfile = new System.Windows.Forms.TabPage();
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
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.btnViewAllEmployees = new System.Windows.Forms.Button();
            this.btnViewAllProducts = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnViewAll = new System.Windows.Forms.Button();
            this.btnViewAllDepartments = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.tabPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).BeginInit();
            this.tabPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageHome);
            this.tabControl1.Controls.Add(this.tabPageStatistics);
            this.tabControl1.Controls.Add(this.tabPageProfile);
            this.tabControl1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(878, 653);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageHome
            // 
            this.tabPageHome.BackColor = System.Drawing.Color.Tan;
            this.tabPageHome.Controls.Add(this.dtpWorkSchedule);
            this.tabPageHome.Controls.Add(this.btnViewAllWorkShifts);
            this.tabPageHome.Controls.Add(this.lbWorkSchedule);
            this.tabPageHome.Location = new System.Drawing.Point(4, 30);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(870, 619);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "Home";
            // 
            // dtpWorkSchedule
            // 
            this.dtpWorkSchedule.Location = new System.Drawing.Point(242, 508);
            this.dtpWorkSchedule.Name = "dtpWorkSchedule";
            this.dtpWorkSchedule.Size = new System.Drawing.Size(385, 28);
            this.dtpWorkSchedule.TabIndex = 3;
            // 
            // btnViewAllWorkShifts
            // 
            this.btnViewAllWorkShifts.BackColor = System.Drawing.Color.Peru;
            this.btnViewAllWorkShifts.Location = new System.Drawing.Point(242, 559);
            this.btnViewAllWorkShifts.Name = "btnViewAllWorkShifts";
            this.btnViewAllWorkShifts.Size = new System.Drawing.Size(385, 39);
            this.btnViewAllWorkShifts.TabIndex = 2;
            this.btnViewAllWorkShifts.Text = "View All Work Shifts";
            this.btnViewAllWorkShifts.UseVisualStyleBackColor = false;
            // 
            // lbWorkSchedule
            // 
            this.lbWorkSchedule.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbWorkSchedule.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWorkSchedule.FormattingEnabled = true;
            this.lbWorkSchedule.ItemHeight = 23;
            this.lbWorkSchedule.Location = new System.Drawing.Point(18, 20);
            this.lbWorkSchedule.Name = "lbWorkSchedule";
            this.lbWorkSchedule.Size = new System.Drawing.Size(834, 464);
            this.lbWorkSchedule.TabIndex = 0;
            // 
            // tabPageStatistics
            // 
            this.tabPageStatistics.BackColor = System.Drawing.Color.Tan;
            this.tabPageStatistics.Controls.Add(this.btnViewAllDepartments);
            this.tabPageStatistics.Controls.Add(this.btnViewAll);
            this.tabPageStatistics.Controls.Add(this.btnSearch);
            this.tabPageStatistics.Controls.Add(this.txtBoxSearch);
            this.tabPageStatistics.Controls.Add(this.btnViewAllProducts);
            this.tabPageStatistics.Controls.Add(this.btnViewAllEmployees);
            this.tabPageStatistics.Controls.Add(this.lbEmployeeStatistics);
            this.tabPageStatistics.Controls.Add(this.dataGridViewEmployeeStats);
            this.tabPageStatistics.Location = new System.Drawing.Point(4, 30);
            this.tabPageStatistics.Name = "tabPageStatistics";
            this.tabPageStatistics.Size = new System.Drawing.Size(870, 619);
            this.tabPageStatistics.TabIndex = 2;
            this.tabPageStatistics.Text = "Statistics";
            // 
            // lbEmployeeStatistics
            // 
            this.lbEmployeeStatistics.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmployeeStatistics.FormattingEnabled = true;
            this.lbEmployeeStatistics.ItemHeight = 21;
            this.lbEmployeeStatistics.Location = new System.Drawing.Point(32, 267);
            this.lbEmployeeStatistics.Name = "lbEmployeeStatistics";
            this.lbEmployeeStatistics.Size = new System.Drawing.Size(803, 130);
            this.lbEmployeeStatistics.TabIndex = 2;
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
            this.dataGridViewEmployeeStats.Size = new System.Drawing.Size(803, 156);
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
            // tabPageProfile
            // 
            this.tabPageProfile.BackColor = System.Drawing.Color.Tan;
            this.tabPageProfile.Controls.Add(this.lblEmployeeName);
            this.tabPageProfile.Controls.Add(this.pictureBoxEmployeePhoto);
            this.tabPageProfile.Controls.Add(this.label6);
            this.tabPageProfile.Controls.Add(this.lblEmail);
            this.tabPageProfile.Controls.Add(this.txtBoxEmail);
            this.tabPageProfile.Controls.Add(this.lblAddress);
            this.tabPageProfile.Controls.Add(this.lblAge);
            this.tabPageProfile.Controls.Add(this.lblLastName);
            this.tabPageProfile.Controls.Add(this.lblFirstName);
            this.tabPageProfile.Controls.Add(this.txtBoxAddress);
            this.tabPageProfile.Controls.Add(this.txtBoxLastName);
            this.tabPageProfile.Controls.Add(this.txtBoxAge);
            this.tabPageProfile.Controls.Add(this.txtBoxFirstName);
            this.tabPageProfile.Controls.Add(this.btnUpdateProfile);
            this.tabPageProfile.Controls.Add(this.lbEmployeeInfo);
            this.tabPageProfile.Location = new System.Drawing.Point(4, 30);
            this.tabPageProfile.Name = "tabPageProfile";
            this.tabPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfile.Size = new System.Drawing.Size(870, 619);
            this.tabPageProfile.TabIndex = 1;
            this.tabPageProfile.Text = "Profile";
            // 
            // pictureBoxEmployeePhoto
            // 
            this.pictureBoxEmployeePhoto.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxEmployeePhoto.Image")));
            this.pictureBoxEmployeePhoto.Location = new System.Drawing.Point(526, 23);
            this.pictureBoxEmployeePhoto.Name = "pictureBoxEmployeePhoto";
            this.pictureBoxEmployeePhoto.Size = new System.Drawing.Size(297, 239);
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
            // btnViewAllEmployees
            // 
            this.btnViewAllEmployees.Location = new System.Drawing.Point(158, 530);
            this.btnViewAllEmployees.Name = "btnViewAllEmployees";
            this.btnViewAllEmployees.Size = new System.Drawing.Size(232, 42);
            this.btnViewAllEmployees.TabIndex = 3;
            this.btnViewAllEmployees.Text = "View All Employees";
            this.btnViewAllEmployees.UseVisualStyleBackColor = true;
            // 
            // btnViewAllProducts
            // 
            this.btnViewAllProducts.Location = new System.Drawing.Point(158, 464);
            this.btnViewAllProducts.Name = "btnViewAllProducts";
            this.btnViewAllProducts.Size = new System.Drawing.Size(232, 42);
            this.btnViewAllProducts.TabIndex = 4;
            this.btnViewAllProducts.Text = "View All Products";
            this.btnViewAllProducts.UseVisualStyleBackColor = true;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(32, 23);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 32);
            this.txtBoxSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(645, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(190, 42);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnViewAll
            // 
            this.btnViewAll.Location = new System.Drawing.Point(462, 530);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(232, 42);
            this.btnViewAll.TabIndex = 7;
            this.btnViewAll.Text = "View All ...";
            this.btnViewAll.UseVisualStyleBackColor = true;
            // 
            // btnViewAllDepartments
            // 
            this.btnViewAllDepartments.Location = new System.Drawing.Point(462, 464);
            this.btnViewAllDepartments.Name = "btnViewAllDepartments";
            this.btnViewAllDepartments.Size = new System.Drawing.Size(232, 42);
            this.btnViewAllDepartments.TabIndex = 8;
            this.btnViewAllDepartments.Text = "View All Departments";
            this.btnViewAllDepartments.UseVisualStyleBackColor = true;
            // 
            // EmployeeSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 682);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeSystem";
            this.Text = "EmployeeSystem";
            this.tabControl1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageStatistics.ResumeLayout(false);
            this.tabPageStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).EndInit();
            this.tabPageProfile.ResumeLayout(false);
            this.tabPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.DateTimePicker dtpWorkSchedule;
        private System.Windows.Forms.Button btnViewAllWorkShifts;
        private System.Windows.Forms.ListBox lbWorkSchedule;
        private System.Windows.Forms.TabPage tabPageStatistics;
        private System.Windows.Forms.ListBox lbEmployeeStatistics;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.TabPage tabPageProfile;
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
        private System.Windows.Forms.Button btnViewAll;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnViewAllProducts;
        private System.Windows.Forms.Button btnViewAllEmployees;
    }
}