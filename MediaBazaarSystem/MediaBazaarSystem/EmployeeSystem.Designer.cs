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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeSystem));
            this.tbControlEmp = new System.Windows.Forms.TabControl();
            this.tbPageHome = new System.Windows.Forms.TabPage();
            this.cmboBoxFilter = new System.Windows.Forms.ComboBox();
            this.btnHomeSearch = new System.Windows.Forms.Button();
            this.txtBoxHomeSearch = new System.Windows.Forms.TextBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnViewAllShifts = new System.Windows.Forms.Button();
            this.picBoxLogout = new System.Windows.Forms.PictureBox();
            this.dataEmpWorkSchedule = new System.Windows.Forms.DataGridView();
            this.clmnStaffName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWorkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpWorkSchedule = new System.Windows.Forms.DateTimePicker();
            this.tbPageHistory = new System.Windows.Forms.TabPage();
            this.btnMorningShift = new System.Windows.Forms.Button();
            this.btnViewWorkHistory = new System.Windows.Forms.Button();
            this.lblWorkHistory = new System.Windows.Forms.Label();
            this.btnEveningShift = new System.Windows.Forms.Button();
            this.btnAfternoonShift = new System.Windows.Forms.Button();
            this.lBoxEmpHistory = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.tbPageProfile = new System.Windows.Forms.TabPage();
            this.btnChangePwd = new System.Windows.Forms.Button();
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
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.tbPageShiftManagement = new System.Windows.Forms.TabPage();
            this.dtpAvailableWorkDates = new System.Windows.Forms.DateTimePicker();
            this.btnAddWorkDate = new System.Windows.Forms.Button();
            this.lBoxWorkDates = new System.Windows.Forms.ListBox();
            this.tbControlEmp.SuspendLayout();
            this.tbPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpWorkSchedule)).BeginInit();
            this.tbPageHistory.SuspendLayout();
            this.tbPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).BeginInit();
            this.tbPageShiftManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControlEmp
            // 
            this.tbControlEmp.Controls.Add(this.tbPageHome);
            this.tbControlEmp.Controls.Add(this.tbPageHistory);
            this.tbControlEmp.Controls.Add(this.tbPageShiftManagement);
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
            this.tbPageHome.Controls.Add(this.cmboBoxFilter);
            this.tbPageHome.Controls.Add(this.btnHomeSearch);
            this.tbPageHome.Controls.Add(this.txtBoxHomeSearch);
            this.tbPageHome.Controls.Add(this.btnSort);
            this.tbPageHome.Controls.Add(this.btnViewAllShifts);
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
            // cmboBoxFilter
            // 
            this.cmboBoxFilter.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboBoxFilter.FormattingEnabled = true;
            this.cmboBoxFilter.Items.AddRange(new object[] {
            "All",
            "Manager",
            "Employee"});
            this.cmboBoxFilter.Location = new System.Drawing.Point(27, 21);
            this.cmboBoxFilter.Name = "cmboBoxFilter";
            this.cmboBoxFilter.Size = new System.Drawing.Size(178, 29);
            this.cmboBoxFilter.TabIndex = 21;
            this.cmboBoxFilter.Text = "Role Filter";
            this.cmboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.cmboBoxFilter_SelectedIndexChanged);
            // 
            // btnHomeSearch
            // 
            this.btnHomeSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHomeSearch.Location = new System.Drawing.Point(564, 15);
            this.btnHomeSearch.Name = "btnHomeSearch";
            this.btnHomeSearch.Size = new System.Drawing.Size(172, 42);
            this.btnHomeSearch.TabIndex = 20;
            this.btnHomeSearch.Text = "Search";
            this.btnHomeSearch.UseVisualStyleBackColor = false;
            this.btnHomeSearch.Click += new System.EventHandler(this.btnHomeSearch_Click);
            // 
            // txtBoxHomeSearch
            // 
            this.txtBoxHomeSearch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxHomeSearch.Location = new System.Drawing.Point(211, 21);
            this.txtBoxHomeSearch.Name = "txtBoxHomeSearch";
            this.txtBoxHomeSearch.Size = new System.Drawing.Size(347, 30);
            this.txtBoxHomeSearch.TabIndex = 19;
            this.txtBoxHomeSearch.Text = "Search by first name...";
            this.txtBoxHomeSearch.Click += new System.EventHandler(this.txtBoxHomeSearch_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSort.Location = new System.Drawing.Point(455, 614);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(385, 42);
            this.btnSort.TabIndex = 16;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnViewAllShifts
            // 
            this.btnViewAllShifts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllShifts.Location = new System.Drawing.Point(31, 614);
            this.btnViewAllShifts.Name = "btnViewAllShifts";
            this.btnViewAllShifts.Size = new System.Drawing.Size(385, 42);
            this.btnViewAllShifts.TabIndex = 15;
            this.btnViewAllShifts.Text = "View All Shifts";
            this.btnViewAllShifts.UseVisualStyleBackColor = false;
            this.btnViewAllShifts.Click += new System.EventHandler(this.btnViewAllShifts_Click);
            // 
            // picBoxLogout
            // 
            this.picBoxLogout.Image = ((System.Drawing.Image)(resources.GetObject("picBoxLogout.Image")));
            this.picBoxLogout.Location = new System.Drawing.Point(757, 0);
            this.picBoxLogout.Name = "picBoxLogout";
            this.picBoxLogout.Size = new System.Drawing.Size(117, 39);
            this.picBoxLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxLogout.TabIndex = 8;
            this.picBoxLogout.TabStop = false;
            this.picBoxLogout.Click += new System.EventHandler(this.picBoxLogout_Click);
            // 
            // dataEmpWorkSchedule
            // 
            this.dataEmpWorkSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmpWorkSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnStaffName,
            this.clmnRole,
            this.clmnStartTime,
            this.clmnEndTime,
            this.clmnWorkDate});
            this.dataEmpWorkSchedule.Location = new System.Drawing.Point(31, 79);
            this.dataEmpWorkSchedule.MultiSelect = false;
            this.dataEmpWorkSchedule.Name = "dataEmpWorkSchedule";
            this.dataEmpWorkSchedule.ReadOnly = true;
            this.dataEmpWorkSchedule.RowHeadersWidth = 51;
            this.dataEmpWorkSchedule.RowTemplate.Height = 24;
            this.dataEmpWorkSchedule.Size = new System.Drawing.Size(809, 461);
            this.dataEmpWorkSchedule.TabIndex = 4;
            // 
            // clmnStaffName
            // 
            this.clmnStaffName.HeaderText = "Name";
            this.clmnStaffName.MinimumWidth = 6;
            this.clmnStaffName.Name = "clmnStaffName";
            this.clmnStaffName.ReadOnly = true;
            this.clmnStaffName.Width = 125;
            // 
            // clmnRole
            // 
            this.clmnRole.HeaderText = "Role";
            this.clmnRole.MinimumWidth = 6;
            this.clmnRole.Name = "clmnRole";
            this.clmnRole.ReadOnly = true;
            this.clmnRole.Width = 125;
            // 
            // clmnStartTime
            // 
            this.clmnStartTime.HeaderText = "Start Time";
            this.clmnStartTime.MinimumWidth = 6;
            this.clmnStartTime.Name = "clmnStartTime";
            this.clmnStartTime.ReadOnly = true;
            this.clmnStartTime.Width = 125;
            // 
            // clmnEndTime
            // 
            this.clmnEndTime.HeaderText = "End Time";
            this.clmnEndTime.MinimumWidth = 6;
            this.clmnEndTime.Name = "clmnEndTime";
            this.clmnEndTime.ReadOnly = true;
            this.clmnEndTime.Width = 125;
            // 
            // clmnWorkDate
            // 
            this.clmnWorkDate.HeaderText = "Date";
            this.clmnWorkDate.MinimumWidth = 6;
            this.clmnWorkDate.Name = "clmnWorkDate";
            this.clmnWorkDate.ReadOnly = true;
            this.clmnWorkDate.Width = 255;
            // 
            // dtpWorkSchedule
            // 
            this.dtpWorkSchedule.Location = new System.Drawing.Point(235, 565);
            this.dtpWorkSchedule.Name = "dtpWorkSchedule";
            this.dtpWorkSchedule.Size = new System.Drawing.Size(385, 28);
            this.dtpWorkSchedule.TabIndex = 3;
            this.dtpWorkSchedule.ValueChanged += new System.EventHandler(this.dtpWorkSchedule_ValueChanged);
            // 
            // tbPageHistory
            // 
            this.tbPageHistory.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageHistory.Controls.Add(this.btnMorningShift);
            this.tbPageHistory.Controls.Add(this.btnViewWorkHistory);
            this.tbPageHistory.Controls.Add(this.lblWorkHistory);
            this.tbPageHistory.Controls.Add(this.btnEveningShift);
            this.tbPageHistory.Controls.Add(this.btnAfternoonShift);
            this.tbPageHistory.Controls.Add(this.lBoxEmpHistory);
            this.tbPageHistory.Controls.Add(this.btnSearch);
            this.tbPageHistory.Controls.Add(this.txtBoxSearch);
            this.tbPageHistory.Location = new System.Drawing.Point(4, 30);
            this.tbPageHistory.Name = "tbPageHistory";
            this.tbPageHistory.Size = new System.Drawing.Size(870, 675);
            this.tbPageHistory.TabIndex = 2;
            this.tbPageHistory.Text = "History";
            // 
            // btnMorningShift
            // 
            this.btnMorningShift.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnMorningShift.Location = new System.Drawing.Point(247, 590);
            this.btnMorningShift.Name = "btnMorningShift";
            this.btnMorningShift.Size = new System.Drawing.Size(168, 42);
            this.btnMorningShift.TabIndex = 14;
            this.btnMorningShift.Text = "Morning shift";
            this.btnMorningShift.UseVisualStyleBackColor = false;
            this.btnMorningShift.Click += new System.EventHandler(this.btnMorningShift_Click);
            // 
            // btnViewWorkHistory
            // 
            this.btnViewWorkHistory.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewWorkHistory.Location = new System.Drawing.Point(32, 590);
            this.btnViewWorkHistory.Name = "btnViewWorkHistory";
            this.btnViewWorkHistory.Size = new System.Drawing.Size(168, 42);
            this.btnViewWorkHistory.TabIndex = 13;
            this.btnViewWorkHistory.Text = "View Work History";
            this.btnViewWorkHistory.UseVisualStyleBackColor = false;
            this.btnViewWorkHistory.Click += new System.EventHandler(this.btnViewWorkHistory_Click);
            // 
            // lblWorkHistory
            // 
            this.lblWorkHistory.AutoSize = true;
            this.lblWorkHistory.Location = new System.Drawing.Point(28, 104);
            this.lblWorkHistory.Name = "lblWorkHistory";
            this.lblWorkHistory.Size = new System.Drawing.Size(152, 21);
            this.lblWorkHistory.TabIndex = 12;
            this.lblWorkHistory.Text = "Your work history:";
            // 
            // btnEveningShift
            // 
            this.btnEveningShift.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnEveningShift.Location = new System.Drawing.Point(667, 590);
            this.btnEveningShift.Name = "btnEveningShift";
            this.btnEveningShift.Size = new System.Drawing.Size(168, 42);
            this.btnEveningShift.TabIndex = 11;
            this.btnEveningShift.Text = "Evening Shift";
            this.btnEveningShift.UseVisualStyleBackColor = false;
            this.btnEveningShift.Click += new System.EventHandler(this.btnEveningShift_Click);
            // 
            // btnAfternoonShift
            // 
            this.btnAfternoonShift.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAfternoonShift.Location = new System.Drawing.Point(459, 590);
            this.btnAfternoonShift.Name = "btnAfternoonShift";
            this.btnAfternoonShift.Size = new System.Drawing.Size(168, 42);
            this.btnAfternoonShift.TabIndex = 10;
            this.btnAfternoonShift.Text = "Afternoon Shift";
            this.btnAfternoonShift.UseVisualStyleBackColor = false;
            this.btnAfternoonShift.Click += new System.EventHandler(this.btnAfternoonShift_Click);
            // 
            // lBoxEmpHistory
            // 
            this.lBoxEmpHistory.FormattingEnabled = true;
            this.lBoxEmpHistory.ItemHeight = 21;
            this.lBoxEmpHistory.Location = new System.Drawing.Point(32, 128);
            this.lBoxEmpHistory.Name = "lBoxEmpHistory";
            this.lBoxEmpHistory.Size = new System.Drawing.Size(803, 403);
            this.lBoxEmpHistory.TabIndex = 7;
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(32, 23);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 30);
            this.txtBoxSearch.TabIndex = 5;
            this.txtBoxSearch.Text = "Search by date...";
            this.txtBoxSearch.Click += new System.EventHandler(this.txtBoxSearch_Click);
            // 
            // tbPageProfile
            // 
            this.tbPageProfile.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageProfile.Controls.Add(this.btnChangePwd);
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
            // btnChangePwd
            // 
            this.btnChangePwd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnChangePwd.Location = new System.Drawing.Point(526, 613);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(297, 44);
            this.btnChangePwd.TabIndex = 18;
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.UseVisualStyleBackColor = false;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(15, 23);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(55, 21);
            this.lblEmployeeName.TabIndex = 15;
            this.lblEmployeeName.Text = "Hello,";
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
            this.lblEmail.Location = new System.Drawing.Point(444, 509);
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
            this.lblAddress.Location = new System.Drawing.Point(429, 465);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(82, 21);
            this.lblAddress.TabIndex = 9;
            this.lblAddress.Text = "Address:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(397, 415);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(119, 21);
            this.lblAge.TabIndex = 8;
            this.lblAge.Text = "Date of Birth:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(409, 364);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(105, 21);
            this.lblLastName.TabIndex = 7;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(411, 312);
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
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            // 
            // lbEmployeeInfo
            // 
            this.lbEmployeeInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmployeeInfo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeInfo.FormattingEnabled = true;
            this.lbEmployeeInfo.ItemHeight = 23;
            this.lbEmployeeInfo.Location = new System.Drawing.Point(19, 65);
            this.lbEmployeeInfo.Name = "lbEmployeeInfo";
            this.lbEmployeeInfo.Size = new System.Drawing.Size(330, 487);
            this.lbEmployeeInfo.TabIndex = 0;
            // 
            // tbPageShiftManagement
            // 
            this.tbPageShiftManagement.Controls.Add(this.lBoxWorkDates);
            this.tbPageShiftManagement.Controls.Add(this.btnAddWorkDate);
            this.tbPageShiftManagement.Controls.Add(this.dtpAvailableWorkDates);
            this.tbPageShiftManagement.Location = new System.Drawing.Point(4, 30);
            this.tbPageShiftManagement.Name = "tbPageShiftManagement";
            this.tbPageShiftManagement.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageShiftManagement.Size = new System.Drawing.Size(870, 675);
            this.tbPageShiftManagement.TabIndex = 3;
            this.tbPageShiftManagement.Text = "Shift Management";
            this.tbPageShiftManagement.UseVisualStyleBackColor = true;
            // 
            // dtpAvailableWorkDates
            // 
            this.dtpAvailableWorkDates.Location = new System.Drawing.Point(461, 77);
            this.dtpAvailableWorkDates.Name = "dtpAvailableWorkDates";
            this.dtpAvailableWorkDates.Size = new System.Drawing.Size(385, 28);
            this.dtpAvailableWorkDates.TabIndex = 4;
            // 
            // btnAddWorkDate
            // 
            this.btnAddWorkDate.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddWorkDate.Location = new System.Drawing.Point(461, 146);
            this.btnAddWorkDate.Name = "btnAddWorkDate";
            this.btnAddWorkDate.Size = new System.Drawing.Size(385, 42);
            this.btnAddWorkDate.TabIndex = 15;
            this.btnAddWorkDate.Text = "Add Work Date";
            this.btnAddWorkDate.UseVisualStyleBackColor = false;
            this.btnAddWorkDate.Click += new System.EventHandler(this.btnAddWorkDate_Click);
            // 
            // lBoxWorkDates
            // 
            this.lBoxWorkDates.FormattingEnabled = true;
            this.lBoxWorkDates.ItemHeight = 21;
            this.lBoxWorkDates.Location = new System.Drawing.Point(23, 77);
            this.lBoxWorkDates.Name = "lBoxWorkDates";
            this.lBoxWorkDates.Size = new System.Drawing.Size(409, 487);
            this.lBoxWorkDates.TabIndex = 16;
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
            this.tbPageHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpWorkSchedule)).EndInit();
            this.tbPageHistory.ResumeLayout(false);
            this.tbPageHistory.PerformLayout();
            this.tbPageProfile.ResumeLayout(false);
            this.tbPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).EndInit();
            this.tbPageShiftManagement.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControlEmp;
        private System.Windows.Forms.TabPage tbPageHome;
        private System.Windows.Forms.DateTimePicker dtpWorkSchedule;
        private System.Windows.Forms.TabPage tbPageHistory;
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.DataGridView dataEmpWorkSchedule;
        private System.Windows.Forms.PictureBox picBoxLogout;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnViewAllShifts;
        private System.Windows.Forms.ComboBox cmboBoxFilter;
        private System.Windows.Forms.Button btnHomeSearch;
        private System.Windows.Forms.TextBox txtBoxHomeSearch;
        private System.Windows.Forms.Button btnEveningShift;
        private System.Windows.Forms.Button btnAfternoonShift;
        private System.Windows.Forms.ListBox lBoxEmpHistory;
        private System.Windows.Forms.Label lblWorkHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStaffName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWorkDate;
        private System.Windows.Forms.Button btnViewWorkHistory;
        private System.Windows.Forms.Button btnMorningShift;
        private System.Windows.Forms.TabPage tbPageShiftManagement;
        private System.Windows.Forms.ListBox lBoxWorkDates;
        private System.Windows.Forms.Button btnAddWorkDate;
        private System.Windows.Forms.DateTimePicker dtpAvailableWorkDates;
    }
}