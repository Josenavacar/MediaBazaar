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
            this.btnHomeSearch = new System.Windows.Forms.Button();
            this.txtBoxHomeSearch = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSort = new System.Windows.Forms.Button();
            this.btnViewAllShifts = new System.Windows.Forms.Button();
            this.lblAssignEmployee = new System.Windows.Forms.Label();
            this.picBoxLogout = new System.Windows.Forms.PictureBox();
            this.dataAdminWorkSchedule = new System.Windows.Forms.DataGridView();
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWorkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpWorkSchedule = new System.Windows.Forms.DateTimePicker();
            this.tbPageStatistics = new System.Windows.Forms.TabPage();
            this.dataStatistics = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnIsAvailable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewAllDepartments = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnViewAllProducts = new System.Windows.Forms.Button();
            this.btnViewAllEmployees = new System.Windows.Forms.Button();
            this.tbPageProfile = new System.Windows.Forms.TabPage();
            this.btnChangePwd = new System.Windows.Forms.Button();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUndoEmpSelection = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBoxManagers = new System.Windows.Forms.GroupBox();
            this.btnUndoManSelection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbManagers = new System.Windows.Forms.ListBox();
            this.btnViewEmployeeDetails = new System.Windows.Forms.Button();
            this.btnAddEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.lbEmployees = new System.Windows.Forms.ListBox();
            this.btnFireEmployee = new System.Windows.Forms.Button();
            this.Refresh = new System.Windows.Forms.Timer(this.components);
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.tbControlAdmin.SuspendLayout();
            this.tbPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdminWorkSchedule)).BeginInit();
            this.tbPageStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStatistics)).BeginInit();
            this.tbPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminPhoto)).BeginInit();
            this.tbPageEmpManagement.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpBoxManagers.SuspendLayout();
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
            this.tbPageHome.Controls.Add(this.btnHomeSearch);
            this.tbPageHome.Controls.Add(this.txtBoxHomeSearch);
            this.tbPageHome.Controls.Add(this.btnFilter);
            this.tbPageHome.Controls.Add(this.btnSort);
            this.tbPageHome.Controls.Add(this.btnViewAllShifts);
            this.tbPageHome.Controls.Add(this.lblAssignEmployee);
            this.tbPageHome.Controls.Add(this.picBoxLogout);
            this.tbPageHome.Controls.Add(this.dataAdminWorkSchedule);
            this.tbPageHome.Controls.Add(this.dtpWorkSchedule);
            this.tbPageHome.Location = new System.Drawing.Point(4, 30);
            this.tbPageHome.Name = "tbPageHome";
            this.tbPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageHome.Size = new System.Drawing.Size(870, 673);
            this.tbPageHome.TabIndex = 0;
            this.tbPageHome.Text = "Home";
            // 
            // btnHomeSearch
            // 
            this.btnHomeSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHomeSearch.Location = new System.Drawing.Point(565, 10);
            this.btnHomeSearch.Name = "btnHomeSearch";
            this.btnHomeSearch.Size = new System.Drawing.Size(172, 42);
            this.btnHomeSearch.TabIndex = 17;
            this.btnHomeSearch.Text = "Search";
            this.btnHomeSearch.UseVisualStyleBackColor = false;
            this.btnHomeSearch.Click += new System.EventHandler(this.btnHomeSearch_Click);
            // 
            // txtBoxHomeSearch
            // 
            this.txtBoxHomeSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxHomeSearch.Location = new System.Drawing.Point(95, 16);
            this.txtBoxHomeSearch.Name = "txtBoxHomeSearch";
            this.txtBoxHomeSearch.Size = new System.Drawing.Size(464, 32);
            this.txtBoxHomeSearch.TabIndex = 16;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFilter.Location = new System.Drawing.Point(95, 610);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(139, 42);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnSort
            // 
            this.btnSort.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSort.Location = new System.Drawing.Point(631, 610);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(144, 42);
            this.btnSort.TabIndex = 14;
            this.btnSort.Text = "Sort";
            this.btnSort.UseVisualStyleBackColor = false;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // btnViewAllShifts
            // 
            this.btnViewAllShifts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllShifts.Location = new System.Drawing.Point(240, 610);
            this.btnViewAllShifts.Name = "btnViewAllShifts";
            this.btnViewAllShifts.Size = new System.Drawing.Size(385, 42);
            this.btnViewAllShifts.TabIndex = 13;
            this.btnViewAllShifts.Text = "View All Shifts";
            this.btnViewAllShifts.UseVisualStyleBackColor = false;
            this.btnViewAllShifts.Click += new System.EventHandler(this.btnViewAllShifts_Click);
            // 
            // lblAssignEmployee
            // 
            this.lblAssignEmployee.AutoSize = true;
            this.lblAssignEmployee.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignEmployee.Location = new System.Drawing.Point(91, 89);
            this.lblAssignEmployee.Name = "lblAssignEmployee";
            this.lblAssignEmployee.Size = new System.Drawing.Size(538, 22);
            this.lblAssignEmployee.TabIndex = 8;
            this.lblAssignEmployee.Text = "Double click on employee\'s name to assign them to a task";
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
            this.dataAdminWorkSchedule.AllowUserToResizeColumns = false;
            this.dataAdminWorkSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAdminWorkSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEmployeeName,
            this.clmnRole,
            this.clmnStartTime,
            this.clmnEndTime,
            this.clmnWorkDate});
            this.dataAdminWorkSchedule.Location = new System.Drawing.Point(95, 125);
            this.dataAdminWorkSchedule.MultiSelect = false;
            this.dataAdminWorkSchedule.Name = "dataAdminWorkSchedule";
            this.dataAdminWorkSchedule.ReadOnly = true;
            this.dataAdminWorkSchedule.RowHeadersWidth = 51;
            this.dataAdminWorkSchedule.RowTemplate.Height = 24;
            this.dataAdminWorkSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataAdminWorkSchedule.Size = new System.Drawing.Size(680, 412);
            this.dataAdminWorkSchedule.TabIndex = 5;
            this.dataAdminWorkSchedule.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataAdminWorkSchedule_CellDoubleClick);
            // 
            // clmnEmployeeName
            // 
            this.clmnEmployeeName.HeaderText = "Employee";
            this.clmnEmployeeName.MinimumWidth = 6;
            this.clmnEmployeeName.Name = "clmnEmployeeName";
            this.clmnEmployeeName.ReadOnly = true;
            this.clmnEmployeeName.Width = 125;
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
            this.clmnWorkDate.Width = 125;
            // 
            // dtpWorkSchedule
            // 
            this.dtpWorkSchedule.Location = new System.Drawing.Point(240, 563);
            this.dtpWorkSchedule.Name = "dtpWorkSchedule";
            this.dtpWorkSchedule.Size = new System.Drawing.Size(385, 28);
            this.dtpWorkSchedule.TabIndex = 3;
            this.dtpWorkSchedule.ValueChanged += new System.EventHandler(this.dtpWorkSchedule_ValueChanged);
            // 
            // tbPageStatistics
            // 
            this.tbPageStatistics.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageStatistics.Controls.Add(this.dataStatistics);
            this.tbPageStatistics.Controls.Add(this.btnViewAllDepartments);
            this.tbPageStatistics.Controls.Add(this.btnSearch);
            this.tbPageStatistics.Controls.Add(this.txtBoxSearch);
            this.tbPageStatistics.Controls.Add(this.btnViewAllProducts);
            this.tbPageStatistics.Controls.Add(this.btnViewAllEmployees);
            this.tbPageStatistics.Location = new System.Drawing.Point(4, 30);
            this.tbPageStatistics.Name = "tbPageStatistics";
            this.tbPageStatistics.Size = new System.Drawing.Size(870, 673);
            this.tbPageStatistics.TabIndex = 2;
            this.tbPageStatistics.Text = "Statistics";
            // 
            // dataStatistics
            // 
            this.dataStatistics.AllowUserToResizeColumns = false;
            this.dataStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.clmnIsAvailable});
            this.dataStatistics.Location = new System.Drawing.Point(29, 106);
            this.dataStatistics.MultiSelect = false;
            this.dataStatistics.Name = "dataStatistics";
            this.dataStatistics.ReadOnly = true;
            this.dataStatistics.RowHeadersWidth = 51;
            this.dataStatistics.RowTemplate.Height = 24;
            this.dataStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataStatistics.Size = new System.Drawing.Size(803, 241);
            this.dataStatistics.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Role";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Start Time";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "End Time";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Date";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // clmnIsAvailable
            // 
            this.clmnIsAvailable.HeaderText = "Is Available?";
            this.clmnIsAvailable.MinimumWidth = 6;
            this.clmnIsAvailable.Name = "clmnIsAvailable";
            this.clmnIsAvailable.ReadOnly = true;
            this.clmnIsAvailable.Width = 125;
            // 
            // btnViewAllDepartments
            // 
            this.btnViewAllDepartments.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllDepartments.Location = new System.Drawing.Point(296, 601);
            this.btnViewAllDepartments.Name = "btnViewAllDepartments";
            this.btnViewAllDepartments.Size = new System.Drawing.Size(276, 42);
            this.btnViewAllDepartments.TabIndex = 16;
            this.btnViewAllDepartments.Text = "View All Departments";
            this.btnViewAllDepartments.UseVisualStyleBackColor = false;
            this.btnViewAllDepartments.Click += new System.EventHandler(this.btnViewAllDepartments_Click);
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
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(29, 32);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 32);
            this.txtBoxSearch.TabIndex = 13;
            // 
            // btnViewAllProducts
            // 
            this.btnViewAllProducts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllProducts.Location = new System.Drawing.Point(29, 601);
            this.btnViewAllProducts.Name = "btnViewAllProducts";
            this.btnViewAllProducts.Size = new System.Drawing.Size(261, 42);
            this.btnViewAllProducts.TabIndex = 12;
            this.btnViewAllProducts.Text = "View All Products";
            this.btnViewAllProducts.UseVisualStyleBackColor = false;
            this.btnViewAllProducts.Click += new System.EventHandler(this.btnViewAllProducts_Click);
            // 
            // btnViewAllEmployees
            // 
            this.btnViewAllEmployees.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewAllEmployees.Location = new System.Drawing.Point(578, 601);
            this.btnViewAllEmployees.Name = "btnViewAllEmployees";
            this.btnViewAllEmployees.Size = new System.Drawing.Size(254, 42);
            this.btnViewAllEmployees.TabIndex = 11;
            this.btnViewAllEmployees.Text = "View All Employees";
            this.btnViewAllEmployees.UseVisualStyleBackColor = false;
            this.btnViewAllEmployees.Click += new System.EventHandler(this.btnViewAllEmployees_Click);
            // 
            // tbPageProfile
            // 
            this.tbPageProfile.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageProfile.Controls.Add(this.btnChangePwd);
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
            this.tbPageProfile.Location = new System.Drawing.Point(4, 30);
            this.tbPageProfile.Name = "tbPageProfile";
            this.tbPageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tbPageProfile.Size = new System.Drawing.Size(870, 673);
            this.tbPageProfile.TabIndex = 1;
            this.tbPageProfile.Text = "Profile";
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnChangePwd.Location = new System.Drawing.Point(526, 614);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(297, 44);
            this.btnChangePwd.TabIndex = 17;
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.UseVisualStyleBackColor = false;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.Location = new System.Drawing.Point(15, 23);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(55, 21);
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
            // tbPageEmpManagement
            // 
            this.tbPageEmpManagement.BackColor = System.Drawing.SystemColors.Menu;
            this.tbPageEmpManagement.Controls.Add(this.groupBox1);
            this.tbPageEmpManagement.Controls.Add(this.grpBoxManagers);
            this.tbPageEmpManagement.Controls.Add(this.lbManagers);
            this.tbPageEmpManagement.Controls.Add(this.btnViewEmployeeDetails);
            this.tbPageEmpManagement.Controls.Add(this.btnAddEmployee);
            this.tbPageEmpManagement.Controls.Add(this.btnUpdateEmployee);
            this.tbPageEmpManagement.Controls.Add(this.lbEmployees);
            this.tbPageEmpManagement.Controls.Add(this.btnFireEmployee);
            this.tbPageEmpManagement.Location = new System.Drawing.Point(4, 30);
            this.tbPageEmpManagement.Name = "tbPageEmpManagement";
            this.tbPageEmpManagement.Size = new System.Drawing.Size(870, 673);
            this.tbPageEmpManagement.TabIndex = 3;
            this.tbPageEmpManagement.Text = "Employee Management";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUndoEmpSelection);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(19, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 73);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // btnUndoEmpSelection
            // 
            this.btnUndoEmpSelection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUndoEmpSelection.Location = new System.Drawing.Point(235, 27);
            this.btnUndoEmpSelection.Name = "btnUndoEmpSelection";
            this.btnUndoEmpSelection.Size = new System.Drawing.Size(162, 40);
            this.btnUndoEmpSelection.TabIndex = 12;
            this.btnUndoEmpSelection.Text = "Undo Selection";
            this.btnUndoEmpSelection.UseVisualStyleBackColor = false;
            this.btnUndoEmpSelection.Click += new System.EventHandler(this.btnUndoEmpSelection_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Employees";
            // 
            // grpBoxManagers
            // 
            this.grpBoxManagers.Controls.Add(this.btnUndoManSelection);
            this.grpBoxManagers.Controls.Add(this.label2);
            this.grpBoxManagers.Location = new System.Drawing.Point(447, 3);
            this.grpBoxManagers.Name = "grpBoxManagers";
            this.grpBoxManagers.Size = new System.Drawing.Size(403, 73);
            this.grpBoxManagers.TabIndex = 11;
            this.grpBoxManagers.TabStop = false;
            // 
            // btnUndoManSelection
            // 
            this.btnUndoManSelection.BackColor = System.Drawing.Color.OrangeRed;
            this.btnUndoManSelection.Location = new System.Drawing.Point(235, 27);
            this.btnUndoManSelection.Name = "btnUndoManSelection";
            this.btnUndoManSelection.Size = new System.Drawing.Size(162, 40);
            this.btnUndoManSelection.TabIndex = 12;
            this.btnUndoManSelection.Text = "Undo Selection";
            this.btnUndoManSelection.UseVisualStyleBackColor = false;
            this.btnUndoManSelection.Click += new System.EventHandler(this.btnUndoManSelection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Managers";
            // 
            // lbManagers
            // 
            this.lbManagers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbManagers.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbManagers.FormattingEnabled = true;
            this.lbManagers.ItemHeight = 23;
            this.lbManagers.Location = new System.Drawing.Point(447, 82);
            this.lbManagers.Name = "lbManagers";
            this.lbManagers.Size = new System.Drawing.Size(403, 464);
            this.lbManagers.TabIndex = 8;
            // 
            // btnViewEmployeeDetails
            // 
            this.btnViewEmployeeDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnViewEmployeeDetails.Location = new System.Drawing.Point(447, 588);
            this.btnViewEmployeeDetails.Name = "btnViewEmployeeDetails";
            this.btnViewEmployeeDetails.Size = new System.Drawing.Size(211, 48);
            this.btnViewEmployeeDetails.TabIndex = 7;
            this.btnViewEmployeeDetails.Text = "View Details";
            this.btnViewEmployeeDetails.UseVisualStyleBackColor = false;
            this.btnViewEmployeeDetails.Click += new System.EventHandler(this.btnViewEmployeeDetails_Click);
            // 
            // btnAddEmployee
            // 
            this.btnAddEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddEmployee.Location = new System.Drawing.Point(19, 588);
            this.btnAddEmployee.Name = "btnAddEmployee";
            this.btnAddEmployee.Size = new System.Drawing.Size(167, 48);
            this.btnAddEmployee.TabIndex = 6;
            this.btnAddEmployee.Text = "Add";
            this.btnAddEmployee.UseVisualStyleBackColor = false;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUpdateEmployee.Location = new System.Drawing.Point(227, 588);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(182, 48);
            this.btnUpdateEmployee.TabIndex = 5;
            this.btnUpdateEmployee.Text = "Update";
            this.btnUpdateEmployee.UseVisualStyleBackColor = false;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // lbEmployees
            // 
            this.lbEmployees.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbEmployees.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployees.FormattingEnabled = true;
            this.lbEmployees.ItemHeight = 23;
            this.lbEmployees.Location = new System.Drawing.Point(19, 82);
            this.lbEmployees.Name = "lbEmployees";
            this.lbEmployees.Size = new System.Drawing.Size(403, 464);
            this.lbEmployees.TabIndex = 4;
            // 
            // btnFireEmployee
            // 
            this.btnFireEmployee.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnFireEmployee.Location = new System.Drawing.Point(688, 588);
            this.btnFireEmployee.Name = "btnFireEmployee";
            this.btnFireEmployee.Size = new System.Drawing.Size(162, 48);
            this.btnFireEmployee.TabIndex = 3;
            this.btnFireEmployee.Text = "Delete";
            this.btnFireEmployee.UseVisualStyleBackColor = false;
            this.btnFireEmployee.Click += new System.EventHandler(this.btnFireEmployee_Click);
            // 
            // Refresh
            // 
            this.Refresh.Enabled = true;
            this.Refresh.Interval = 1500;
            this.Refresh.Tick += new System.EventHandler(this.Refresh_Tick);
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // AdministrationSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(907, 733);
            this.Controls.Add(this.tbControlAdmin);
            this.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "AdministrationSystem";
            this.Text = "AdministrationSystem";
            this.tbControlAdmin.ResumeLayout(false);
            this.tbPageHome.ResumeLayout(false);
            this.tbPageHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataAdminWorkSchedule)).EndInit();
            this.tbPageStatistics.ResumeLayout(false);
            this.tbPageStatistics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStatistics)).EndInit();
            this.tbPageProfile.ResumeLayout(false);
            this.tbPageProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdminPhoto)).EndInit();
            this.tbPageEmpManagement.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxManagers.ResumeLayout(false);
            this.grpBoxManagers.PerformLayout();
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
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Label lblAssignEmployee;
        private System.Windows.Forms.Button btnViewAllShifts;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnHomeSearch;
        private System.Windows.Forms.TextBox txtBoxHomeSearch;
        private System.Windows.Forms.DataGridView dataStatistics;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnIsAvailable;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUndoEmpSelection;
        private System.Windows.Forms.GroupBox grpBoxManagers;
        private System.Windows.Forms.Button btnUndoManSelection;
    }
}