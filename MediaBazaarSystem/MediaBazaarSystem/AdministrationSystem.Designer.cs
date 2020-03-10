namespace MediaBazaarSystem
{
    partial class AdministrationSystem
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrationSystem));
            this.tbControlAdmin = new System.Windows.Forms.TabControl();
            this.tbPageHome = new System.Windows.Forms.TabPage();
            this.picBoxLogout = new System.Windows.Forms.PictureBox();
            this.dataAdminWorkSchedule = new System.Windows.Forms.DataGridView();
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWorkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAssignEmployee = new System.Windows.Forms.Button();
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
            this.lblAdminName = new System.Windows.Forms.Label();
            this.pictureBoxAdminPhoto = new System.Windows.Forms.PictureBox();
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
            this.tbPageEmpManagement = new System.Windows.Forms.TabPage();
            this.lbManagers = new System.Windows.Forms.ListBox();
            this.btnViewEmployeeDetails = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.lbEmployees = new System.Windows.Forms.ListBox();
            this.btnFireEmployee = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbControlAdmin.SuspendLayout();
            this.tbPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdminWorkSchedule)).BeginInit();
            this.tbPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).BeginInit();
            this.tbPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminPhoto)).BeginInit();
            this.tbPageEmpManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControlAdmin
            // 
            this.tbControlAdmin.Controls.Add(this.tbPageHome);
            this.tbControlAdmin.Controls.Add(this.tbPageStatistics);
            this.tbControlAdmin.Controls.Add(this.tbPageProfile);
            this.tbControlAdmin.Controls.Add(this.tbPageEmpManagement);
            this.tbControlAdmin.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControlAdmin.Location = new System.Drawing.Point(12, 12);
            this.tbControlAdmin.Name = "tbControlAdmin";
            this.tbControlAdmin.SelectedIndex = 0;
            this.tbControlAdmin.Size = new System.Drawing.Size(878, 707);
            this.tbControlAdmin.TabIndex = 2;
            // 
            // tbPageHome
            // 
            this.tbPageHome.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageHome.Controls.Add(this.picBoxLogout);
            this.tbPageHome.Controls.Add(this.dataAdminWorkSchedule);
            this.tbPageHome.Controls.Add(this.btnAssignEmployee);
            this.tbPageHome.Controls.Add(this.dtpWorkSchedule);
            this.tbPageHome.Location = new System.Drawing.Point(4, 28);
            this.tbPageHome.Name = "tbPageHome";
            this.tbPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageHome.Size = new System.Drawing.Size(870, 675);
            this.tbPageHome.TabIndex = 0;
            this.tbPageHome.Text = "Home";
            // 
            // picBoxLogout
            // 
            this.picBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogout.Image")));
            this.picBoxLogout.Location = new System.Drawing.Point(757, 0);
            this.picBoxLogout.Name = "picBoxLogout";
            this.picBoxLogout.Size = new System.Drawing.Size(117, 39);
            this.picBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogout.TabIndex = 7;
            this.picBoxLogout.TabStop = false;
            this.picBoxLogout.Click += new System.EventHandler(this.picBoxLogout_Click);
            // 
            // dataAdminWorkSchedule
            // 
            this.dataAdminWorkSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdminWorkSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEmployeeName,
            this.clmnRole,
            this.clmnStartTime,
            this.clmnEndTime,
            this.clmnWorkDate});
            this.dataAdminWorkSchedule.Location = new System.Drawing.Point(92, 79);
            this.dataAdminWorkSchedule.Name = "dataAdminWorkSchedule";
            this.dataAdminWorkSchedule.RowHeadersWidth = 51;
            this.dataAdminWorkSchedule.RowTemplate.Height = 24;
            this.dataAdminWorkSchedule.Size = new System.Drawing.Size(680, 431);
            this.dataAdminWorkSchedule.TabIndex = 5;
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
            // btnAssignEmployee
            // 
            this.btnAssignEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAssignEmployee.Location = new System.Drawing.Point(240, 594);
            this.btnAssignEmployee.Name = "btnAssignEmployee";
            this.btnAssignEmployee.Size = new System.Drawing.Size(385, 39);
            this.btnAssignEmployee.TabIndex = 4;
            this.btnAssignEmployee.Text = "Assign An Employee To A Shift";
            this.btnAssignEmployee.UseVisualStyleBackColor = false;
            this.btnAssignEmployee.Click += new System.EventHandler(this.btnAssignEmployee_Click);
            // 
            // dtpWorkSchedule
            // 
            this.dtpWorkSchedule.Location = new System.Drawing.Point(240, 537);
            this.dtpWorkSchedule.Name = "dtpWorkSchedule";
            this.dtpWorkSchedule.Size = new System.Drawing.Size(385, 24);
            this.dtpWorkSchedule.TabIndex = 3;
            this.dtpWorkSchedule.ValueChanged += new System.EventHandler(this.dtpWorkSchedule_ValueChanged);
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
            this.tbPageStatistics.Location = new System.Drawing.Point(4, 28);
            this.tbPageStatistics.Name = "tbPageStatistics";
            this.tbPageStatistics.Size = new System.Drawing.Size(870, 675);
            this.tbPageStatistics.TabIndex = 2;
            this.tbPageStatistics.Text = "Statistics";
            // 
            // btnViewAllDepartments
            // 
            this.btnViewAllDepartments.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllDepartments.Location = new System.Drawing.Point(155, 528);
            this.btnViewAllDepartments.Name = "btnViewAllDepartments";
            this.btnViewAllDepartments.Size = new System.Drawing.Size(498, 42);
            this.btnViewAllDepartments.TabIndex = 16;
            this.btnViewAllDepartments.Text = "View All Departments";
            this.btnViewAllDepartments.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(642, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(190, 42);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(29, 32);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 27);
            this.txtBoxSearch.TabIndex = 13;
            // 
            // btnViewAllProducts
            // 
            this.btnViewAllProducts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllProducts.Location = new System.Drawing.Point(155, 463);
            this.btnViewAllProducts.Name = "btnViewAllProducts";
            this.btnViewAllProducts.Size = new System.Drawing.Size(498, 42);
            this.btnViewAllProducts.TabIndex = 12;
            this.btnViewAllProducts.Text = "View All Products";
            this.btnViewAllProducts.UseVisualStyleBackColor = false;
            // 
            // btnViewAllEmployees
            // 
            this.btnViewAllEmployees.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllEmployees.Location = new System.Drawing.Point(155, 594);
            this.btnViewAllEmployees.Name = "btnViewAllEmployees";
            this.btnViewAllEmployees.Size = new System.Drawing.Size(498, 42);
            this.btnViewAllEmployees.TabIndex = 11;
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
            this.dataGridViewEmployeeStats.Location = new System.Drawing.Point(29, 104);
            this.dataGridViewEmployeeStats.Name = "dataGridViewEmployeeStats";
            this.dataGridViewEmployeeStats.RowHeadersWidth = 51;
            this.dataGridViewEmployeeStats.RowTemplate.Height = 24;
            this.dataGridViewEmployeeStats.Size = new System.Drawing.Size(803, 321);
            this.dataGridViewEmployeeStats.TabIndex = 9;
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
            this.tbPageProfile.Controls.Add(this.lblAdminName);
            this.tbPageProfile.Controls.Add(this.pictureBoxAdminPhoto);
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
            this.tbPageProfile.Location = new System.Drawing.Point(4, 28);
            this.tbPageProfile.Name = "tbPageProfile";
            this.tbPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageProfile.Size = new System.Drawing.Size(870, 675);
            this.tbPageProfile.TabIndex = 1;
            this.tbPageProfile.Text = "Profile";
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.Location = new System.Drawing.Point(15, 23);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(47, 19);
            this.lblAdminName.TabIndex = 15;
            this.lblAdminName.Text = "Hello,";
            // 
            // pictureBoxAdminPhoto
            // 
            this.pictureBoxAdminPhoto.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAdminPhoto.Image")));
            this.pictureBoxAdminPhoto.Location = new System.Drawing.Point(526, 23);
            this.pictureBoxAdminPhoto.Name = "pictureBoxAdminPhoto";
            this.pictureBoxAdminPhoto.Size = new System.Drawing.Size(297, 263);
            this.pictureBoxAdminPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxAdminPhoto.TabIndex = 13;
            this.pictureBoxAdminPhoto.TabStop = false;
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
            this.lblEmail.Size = new System.Drawing.Size(50, 19);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email:";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEmail.Location = new System.Drawing.Point(526, 504);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(297, 27);
            this.txtBoxEmail.TabIndex = 10;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(422, 465);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(65, 19);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(454, 415);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(40, 19);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Age:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(399, 364);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(85, 19);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(403, 312);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(83, 19);
            this.lblFirstName.TabIndex = 6;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtBoxAddress
            // 
            this.txtBoxAddress.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAddress.Location = new System.Drawing.Point(526, 460);
            this.txtBoxAddress.Name = "txtBoxAddress";
            this.txtBoxAddress.Size = new System.Drawing.Size(297, 27);
            this.txtBoxAddress.TabIndex = 5;
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxLastName.Location = new System.Drawing.Point(526, 359);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(297, 27);
            this.txtBoxLastName.TabIndex = 4;
            // 
            // txtBoxAge
            // 
            this.txtBoxAge.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxAge.Location = new System.Drawing.Point(526, 410);
            this.txtBoxAge.Name = "txtBoxAge";
            this.txtBoxAge.Size = new System.Drawing.Size(297, 27);
            this.txtBoxAge.TabIndex = 3;
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxFirstName.Location = new System.Drawing.Point(526, 307);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(297, 27);
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
            this.lbEmployeeInfo.ItemHeight = 21;
            this.lbEmployeeInfo.Location = new System.Drawing.Point(19, 65);
            this.lbEmployeeInfo.Name = "lbEmployeeInfo";
            this.lbEmployeeInfo.Size = new System.Drawing.Size(330, 508);
            this.lbEmployeeInfo.TabIndex = 0;
            // 
            // tbPageEmpManagement
            // 
            this.tbPageEmpManagement.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageEmpManagement.Controls.Add(this.label2);
            this.tbPageEmpManagement.Controls.Add(this.label1);
            this.tbPageEmpManagement.Controls.Add(this.lbManagers);
            this.tbPageEmpManagement.Controls.Add(this.btnViewEmployeeDetails);
            this.tbPageEmpManagement.Controls.Add(this.btnAddEmployee);
            this.tbPageEmpManagement.Controls.Add(this.btnUpdateEmployee);
            this.tbPageEmpManagement.Controls.Add(this.lbEmployees);
            this.tbPageEmpManagement.Controls.Add(this.btnFireEmployee);
            this.tbPageEmpManagement.Location = new System.Drawing.Point(4, 28);
            this.tbPageEmpManagement.Name = "tbPageEmpManagement";
            this.tbPageEmpManagement.Size = new System.Drawing.Size(870, 675);
            this.tbPageEmpManagement.TabIndex = 3;
            this.tbPageEmpManagement.Text = "Employee Management";
            // 
            // lbManagers
            // 
            this.lbManagers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbManagers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagers.FormattingEnabled = true;
            this.lbManagers.ItemHeight = 21;
            this.lbManagers.Location = new System.Drawing.Point(438, 40);
            this.lbManagers.Name = "lbManagers";
            this.lbManagers.Size = new System.Drawing.Size(390, 424);
            this.lbManagers.TabIndex = 8;
            // 
            // btnViewEmployeeDetails
            // 
            this.btnViewEmployeeDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewEmployeeDetails.Location = new System.Drawing.Point(447, 558);
            this.btnViewEmployeeDetails.Name = "btnViewEmployeeDetails";
            this.btnViewEmployeeDetails.Size = new System.Drawing.Size(211, 48);
            this.btnViewEmployeeDetails.TabIndex = 7;
            this.btnViewEmployeeDetails.Text = "View Employee Details";
            this.btnViewEmployeeDetails.UseVisualStyleBackColor = false;
            this.btnViewEmployeeDetails.Click += new System.EventHandler(this.btnViewEmployeeDetails_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddEmployee.Location = new System.Drawing.Point(19, 558);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(167, 48);
            this.btnAddEmployee.TabIndex = 6;
            this.btnAddEmployee.Text = "Add Employee";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdateEmployee.Location = new System.Drawing.Point(227, 558);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(182, 48);
            this.btnUpdateEmployee.TabIndex = 5;
            this.btnUpdateEmployee.Text = "Update Employee";
            this.btnUpdateEmployee.UseVisualStyleBackColor = false;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // lbEmployees
            // 
            this.lbEmployees.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmployees.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployees.FormattingEnabled = true;
            this.lbEmployees.ItemHeight = 21;
            this.lbEmployees.Location = new System.Drawing.Point(19, 40);
            this.lbEmployees.Name = "lbEmployees";
            this.lbEmployees.Size = new System.Drawing.Size(390, 424);
            this.lbEmployees.TabIndex = 4;
            // 
            // btnFireEmployee
            // 
            this.btnFireEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFireEmployee.Location = new System.Drawing.Point(688, 558);
            this.btnFireEmployee.Name = "btnFireEmployee";
            this.btnFireEmployee.Size = new System.Drawing.Size(162, 48);
            this.btnFireEmployee.TabIndex = 3;
            this.btnFireEmployee.Text = "Delete Employee";
            this.btnFireEmployee.UseVisualStyleBackColor = false;
            this.btnFireEmployee.Click += new System.EventHandler(this.btnFireEmployee_Click);
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 1500;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Employees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Managers";
            // 
            // AdministrationSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(907, 733);
            this.Controls.Add(this.tbControlAdmin);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AdministrationSystem";
            this.Text = "AdministrationSystem";
            this.tbControlAdmin.ResumeLayout(false);
            this.tbPageHome.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdminWorkSchedule)).EndInit();
            this.tbPageStatistics.ResumeLayout(false);
            this.tbPageStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmployeeStats)).EndInit();
            this.tbPageProfile.ResumeLayout(false);
            this.tbPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminPhoto)).EndInit();
            this.tbPageEmpManagement.ResumeLayout(false);
            this.tbPageEmpManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControlAdmin;
        private System.Windows.Forms.TabPage tbPageHome;
        private System.Windows.Forms.DateTimePicker dtpWorkSchedule;
        private System.Windows.Forms.TabPage tbPageStatistics;
        private System.Windows.Forms.TabPage tbPageProfile;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.PictureBox pictureBoxAdminPhoto;
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
        private System.Windows.Forms.TabPage tbPageEmpManagement;
        private System.Windows.Forms.Button btnAddEmployee;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.ListBox lbEmployees;
        private System.Windows.Forms.Button btnFireEmployee;
        private System.Windows.Forms.Button btnViewAllDepartments;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnViewAllProducts;
        private System.Windows.Forms.Button btnViewAllEmployees;
        private System.Windows.Forms.DataGridView dataGridViewEmployeeStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnAssignEmployee;
        private System.Windows.Forms.Button btnViewEmployeeDetails;
        private System.Windows.Forms.DataGridView dataAdminWorkSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWorkDate;
        private System.Windows.Forms.PictureBox picBoxLogout;
        private System.Windows.Forms.Timer Refresh;
        private System.Windows.Forms.ListBox lbManagers;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}