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
            this.clmnEmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmnWorkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpWorkSchedule = new System.Windows.Forms.DateTimePicker();
            this.tbPageHistory = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.lblWorkHistory = new System.Windows.Forms.Label();
            this.tbControlEmp.SuspendLayout();
            this.tbPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmpWorkSchedule)).BeginInit();
            this.tbPageHistory.SuspendLayout();
            this.tbPageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEmployeePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // tbControlEmp
            // 
            this.tbControlEmp.Controls.Add(this.tbPageHome);
            this.tbControlEmp.Controls.Add(this.tbPageHistory);
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
            this.cmboBoxFilter.Text = "Filter";
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
            this.txtBoxHomeSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxHomeSearch.Location = new System.Drawing.Point(211, 21);
            this.txtBoxHomeSearch.Name = "txtBoxHomeSearch";
            this.txtBoxHomeSearch.Size = new System.Drawing.Size(347, 32);
            this.txtBoxHomeSearch.TabIndex = 19;
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
            this.clmnEmployeeName,
            this.clmnRole,
            this.clmnStartTime,
            this.clmnEndTime,
            this.clmnWorkDate});
            this.dataEmpWorkSchedule.Location = new System.Drawing.Point(31, 79);
            this.dataEmpWorkSchedule.Name = "dataEmpWorkSchedule";
            this.dataEmpWorkSchedule.RowHeadersWidth = 51;
            this.dataEmpWorkSchedule.RowTemplate.Height = 24;
            this.dataEmpWorkSchedule.Size = new System.Drawing.Size(809, 461);
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
            this.tbPageHistory.Controls.Add(this.lblWorkHistory);
            this.tbPageHistory.Controls.Add(this.button4);
            this.tbPageHistory.Controls.Add(this.button3);
            this.tbPageHistory.Controls.Add(this.button2);
            this.tbPageHistory.Controls.Add(this.button1);
            this.tbPageHistory.Controls.Add(this.lBoxEmpHistory);
            this.tbPageHistory.Controls.Add(this.btnSearch);
            this.tbPageHistory.Controls.Add(this.txtBoxSearch);
            this.tbPageHistory.Location = new System.Drawing.Point(4, 30);
            this.tbPageHistory.Name = "tbPageHistory";
            this.tbPageHistory.Size = new System.Drawing.Size(870, 675);
            this.tbPageHistory.TabIndex = 2;
            this.tbPageHistory.Text = "History";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Location = new System.Drawing.Point(673, 590);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(162, 42);
            this.button4.TabIndex = 11;
            this.button4.Text = "Night Shift";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Location = new System.Drawing.Point(465, 590);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(162, 42);
            this.button3.TabIndex = 10;
            this.button3.Text = "Day Shift";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(252, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "Fulltime";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(32, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "Part-time";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // lBoxEmpHistory
            // 
            this.lBoxEmpHistory.FormattingEnabled = true;
            this.lBoxEmpHistory.ItemHeight = 21;
            this.lBoxEmpHistory.Location = new System.Drawing.Point(32, 128);
            this.lBoxEmpHistory.Name = "lBoxEmpHistory";
            this.lBoxEmpHistory.Size = new System.Drawing.Size(803, 172);
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
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxSearch.Location = new System.Drawing.Point(32, 23);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(595, 32);
            this.txtBoxSearch.TabIndex = 5;
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
            // lblWorkHistory
            // 
            this.lblWorkHistory.AutoSize = true;
            this.lblWorkHistory.Location = new System.Drawing.Point(28, 104);
            this.lblWorkHistory.Name = "lblWorkHistory";
            this.lblWorkHistory.Size = new System.Drawing.Size(152, 21);
            this.lblWorkHistory.TabIndex = 12;
            this.lblWorkHistory.Text = "Your work history:";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmnWorkDate;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox lBoxEmpHistory;
        private System.Windows.Forms.Label lblWorkHistory;
    }
}