using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Wpf;
using SeriesCollection = LiveCharts.SeriesCollection;
using LiveCharts.Defaults;
using Axis = LiveCharts.Wpf.Axis;
using System.Security.Policy;

namespace MediaBazaarSystem
{
    public partial class AdministrationSystem : Form
    {
        private DatabaseHelper dataBase;
        private EmailHelper emailHelper;
        private UpdateEmployeeSchedule assignEmployeeForm;
        private Department department;
        private Manager manager;
        private Schedule schedule;
        private List<Schedule> schedules;
        private List<Schedule> alreadyScheduled;
        private String employeeName, employeeRole, employeeStartTime, employeeEndTime, employeeWorkDate;
        public static bool ensure; //Used for double checking when deleting from the database.


        /**
         * Constructor
         */
        public AdministrationSystem( Department department, Manager manager )
        {
            InitializeComponent();
            dataBase = new DatabaseHelper();
            emailHelper = new EmailHelper();
            schedules = new List<Schedule>();
            alreadyScheduled = new List<Schedule>();
            this.dataAdminWorkSchedule.Rows.Clear();
            this.department = department;
            this.manager = manager;
            this.UpdateSchedule();
            this.LoadStaff();
            this.LoadScheduleInformation();
            this.refreshProfile();
            lblAdminName.Text += " " + manager.FirstName + " " + manager.LastName;
            comBoxWorkDate.Visible = true;
        }

        /**
         * Method to get database info on work schedule
         */
        private void GetWorkScheduleDB(MySqlDataReader reader)
        {
            if(reader.HasRows)
            {
                // Get the data
                while( reader.Read() )
                {
                    int staffID = (int)reader.GetValue( 0 );
                    String firstName = reader.GetValue( 1 ).ToString();
                    String lastName = reader.GetValue( 2 ).ToString();
                    String role = reader.GetValue( 3 ).ToString();
                    String startTime = reader.GetValue( 4 ).ToString();
                    String endTime = reader.GetValue( 5 ).ToString();
                    String workDate = reader.GetValue( 6 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );
                    String departmentName = reader.GetValue(7).ToString();
                    int scheduleID = (int)reader.GetValue(8);

                    if( (dtpWorkSchedule.Value.Date == convertedWorkDate.Date) && (department.Name == departmentName))
                    {
                        // Add data to data grid view table
                        DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                        dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataAdminWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataAdminWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = firstName + " " + lastName; // First Name
                        row.Cells[ 1 ].Value = role; // Name (Role)
                        row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                        row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                        row.Cells[ 4 ].Value = convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                        dataAdminWorkSchedule.Rows.Add( row );
                    }
                    
                    schedule = new Schedule( scheduleID, firstName, lastName, role, workStartTime, workEndTime, convertedWorkDate, departmentName, staffID);
                    department.AddSchedule( schedule );
                }
            }
            else
            {
                MessageBox.Show( "Sorry there's no data. Contact your administrator for more information." );
            }

            reader.Close();
        }

        /**
         * Method to update the schedule table
         */
        private void UpdateSchedule()
        {
            this.dataAdminWorkSchedule.Rows.Clear();
            department.GetSchedules().Clear();

            MySqlDataReader reader = dataBase.updateSchedules();
            this.GetWorkScheduleDB(reader);

            updateTimer.Enabled = false;
        }


        private void LoadStaff()
        {
            List<Staff> staff = dataBase.getStaffFromDB(department);
            foreach (Staff staffmember in staff)
            {
                String staffname = staffmember.FirstName + " " + staffmember.LastName;
                if (staffmember is Employee) //staffmember.Role == Position.Employee
                {
                    lbEmployees.Items.Add(staffname);
                }
                else if(staffmember is Manager) //staffmember.Role == Position.HRManager || staffmember.Role == Position.StockManager
                {
                    lbManagers.Items.Add(staffname);
                }
            }
        }

        /**
         * Method to get statistics
         */
        private void GetStatistics()
        {
            lBoxStatistics.Items.Clear();

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if( ( schedule.DepartmentName == department.Name ) && ( !lBoxStatistics.Items.Contains( schedule.FirstName ) ) && ( schedule.IsAvailable == true ) && ( schedule.Role == "Employee" ) )
                {
                    lBoxStatistics.Items.Add( schedule.FirstName );
                }
            }
        }

        /**
         * Method to add employee to the database
         */
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            UpdateOrAdd updateOrAddForm = new UpdateOrAdd(department);
            updateOrAddForm.StartPosition = FormStartPosition.CenterParent;
            updateOrAddForm.ShowDialog(this);
        }

        /**
         * Method to view employee's details
         */
        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null || lbManagers != null)
            {
                Staff staff = SearchSelectedStaff();

                if(staff != null)
                {
                    ViewEmployee viewEmployeeForm = new ViewEmployee(staff);
                    viewEmployeeForm.Show();
                }
            }
        }

        /**
         * Method to update employee's information
         */
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null || lbManagers.SelectedItem != null)
            {
                Staff staff = SearchSelectedStaff();

                if(staff != null)
                {
                    UpdateOrAdd form = new UpdateOrAdd(department, staff);
                    form.Show();
                }
            }
            else
            {
                MessageBox.Show("Action could not be performed, Please select a staff member.");
            }

        }


        private Staff SearchSelectedStaff()
        {
            String auxName = null;
            Staff searching = null;

            if (lbEmployees.SelectedItem != null)
            {
                auxName = lbEmployees.SelectedItem.ToString();
            }
            else if(lbManagers.SelectedItem != null)
            {
                auxName = lbManagers.SelectedItem.ToString();
            }
            
            if(!String.IsNullOrEmpty(auxName))
            {
                String[] name = auxName.Split(' '); //Splits the string by the comma.
                String firstName = name[0].Trim();
                String lastName = name[1].Trim();
                searching = department.GetStaffMember(firstName, lastName);

                if (searching == null)
                {
                    MessageBox.Show("Employee not found.");
                }
            }
            
            return searching;
        }

        /**
         * Method to delete employee from the database
         */
        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null || lbManagers.SelectedItem != null)
            {
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent; //Makes the form pop up in the middle of the parent form (this).
                check.ShowDialog(this);

                if (ensure)
                {
                    Staff fired = SearchSelectedStaff();
                    if(fired != null)
                    {
                        dataBase.deleteStaffMember(fired.dbID);
                        department.DeleteStaffMember(fired);
                    }
                }
            }
        }

        /**
         * Jose???
         */
        private void Refresh_Tick(object sender, EventArgs e)  ///////////TO CHANGE////////////////////////////////
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;
            int indexMan = lbManagers.SelectedIndex;
            lbManagers.Items.Clear(); //Empties managers listbox
            lbEmployees.Items.Clear(); //Empties empoloyee listbox

            LoadStaff();

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if( lbEmployees.Items.Count > 0 )
                {
                    lbEmployees.SelectedIndex = indexEmp;
                }
            }
            catch(Exception) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbEmployees.SelectedItem = null;
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if (lbManagers.Items.Count > 0)
                {
                    lbManagers.SelectedIndex = indexMan;
                }
            }
            catch (Exception) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbManagers.SelectedItem = null;
            }
        }

        /**
         * Method to log out 
         */
        private void picBoxLogout_Click( object sender, EventArgs e )
        {
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        /**
         * Method when user selects a date from the date time picker for the work schedule
         */
        private void dtpWorkSchedule_ValueChanged( object sender, EventArgs e )
        {
            // Clear table
            this.dataAdminWorkSchedule.Rows.Clear();

            MySqlDataReader reader = dataBase.getSchedules();

            // Add data to data grid view table
            while( reader.Read() )
            {
                String firstName = reader.GetValue( 0 ).ToString();
                String lastName = reader.GetValue( 1 ).ToString();
                String role = reader.GetValue( 2 ).ToString();
                String startTime = reader.GetValue( 3 ).ToString();
                String endTime = reader.GetValue( 4 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );
                DateTime date = Convert.ToDateTime( reader.GetValue( 5 ).ToString() );
                String theDate = dtpWorkSchedule.Value.ToString( "dddd, dd MMMM yyyy" );

                // Check if the date in the work schedule is equal to the date from the DB
                if( theDate == date.ToString( "dddd, dd MMMM yyyy" ) )
                {
                    DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                    dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.Cells[ 0 ].Value = firstName + " " + lastName;// First Name
                    row.Cells[ 1 ].Value = role;// Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = date.ToString( "dddd, dd MMMM yyyy" ); // Date
                    dataAdminWorkSchedule.Rows.Add( row );
                }
            }
        }

        /**
         * Method to change user's password
         */
        private void btnChangePwd_Click( object sender, EventArgs e )
        {
            //On click, opens a form to change the currently logged in user's password.
            ChangePassword pwd = new ChangePassword(manager, null);
            pwd.StartPosition = FormStartPosition.CenterParent;
            pwd.ShowDialog( this );
        }

        /**
         * Method when user double clicks on row (on an employee)
         */
        private void dataAdminWorkSchedule_CellDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            // Get the row index and employee's schedule info
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataAdminWorkSchedule.Rows[ index ];
            employeeName = selectedRow.Cells[ 0 ].Value.ToString();
            employeeRole = selectedRow.Cells[ 1 ].Value.ToString();
            employeeStartTime = selectedRow.Cells[ 2 ].Value.ToString();
            employeeEndTime = selectedRow.Cells[ 3 ].Value.ToString();
            employeeWorkDate = selectedRow.Cells[ 4 ].Value.ToString();

            if( employeeRole == "Manager" || employeeRole == "Stock Manager" )
            {
                MessageBox.Show( "You can't assign a top ranking manager to a shift! Please contact your administrator." );
            }
            else if(employeeRole == "Employee")
            {
                foreach( Schedule s in department.GetSchedules() )
                {
                    if( ( s.FirstName + " " + s.LastName == employeeName ) && ( s.StartTime.ToString( "hh:mm tt" ) == employeeStartTime ) && ( s.EndTime.ToString( "hh:mm tt" ) == employeeEndTime ) )
                    {
                        schedule = s;
                    }
                }

                // Open the assign employee form
                assignEmployeeForm = new UpdateEmployeeSchedule( department, schedule );
                assignEmployeeForm.Show();
            }
        }

        /**
         * Method to update timer
         */
        private void updateTimer_Tick( object sender, EventArgs e )
        {
            this.UpdateSchedule();
            this.GetStatistics();
        }

        /**
         * Method to view all shifts in table
         */
        private void btnViewAllShifts_Click( object sender, EventArgs e )
        {
            this.dataAdminWorkSchedule.Rows.Clear();

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if(department.Name == schedule.DepartmentName)
                {
                    DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                    dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    dataAdminWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                    dataAdminWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                    row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                    row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                    dataAdminWorkSchedule.Rows.Add( row );
                }
            }
        }

        /**
         * Method to sort employee's name alphabetically in schedule table
         */
        private void btnSort_Click( object sender, EventArgs e )
        {
            // Sort the first column in the data grid view (work schedule)
            // In this case the first column is the first name of employee
            dataAdminWorkSchedule.Sort( dataAdminWorkSchedule.Columns[ 0 ], ListSortDirection.Ascending );
        }

        /**
         * Method to display departments information
         */
        private void btnViewDepartmentInfo_Click( object sender, EventArgs e )
        {
            lBoxDepartmentStats.Items.Clear();
            
            int length = department.GetStaff().Count;
            lBoxDepartmentStats.Items.Add( "# of employees and managers that are employed: " + length + "  " );

            int empfullTime = 0;
            int empPartTime = 0;
            int manfullTime = 0;
            int manPartTime = 0;
            int managers = 0;

            foreach(Staff staff in department.GetStaff())
            {
                if(staff is Employee)
                {
                    if( staff.Contract == Contract.FullTime )
                    {
                        empfullTime++;
                    }
                    else if( staff.Contract == Contract.PartTime )
                    {
                        empPartTime++;
                    }
                }
                else if( staff is Manager )
                {
                    managers++;

                    if( staff.Contract == Contract.FullTime )
                    {
                        manfullTime++;
                    }
                    else if( staff.Contract == Contract.PartTime )
                    {
                        manPartTime++;
                    }
                }
            }

            lBoxDepartmentStats.Items.Add( manfullTime + empfullTime + " Fulltime workers." );
            lBoxDepartmentStats.Items.Add( manPartTime + empPartTime + " Parttime workers." );

            int dep = 0;
            for(int i = 0; i < department.GetSchedules().Count; i++ )
            {
                if(department.GetSchedules()[i].DepartmentName == department.Name)
                {
                    dep++;
                }
            }
            lBoxDepartmentStats.Items.Add( "# of schedules related to this department: " + dep );

            lBoxDepartmentStats.Items.Add( "# of managers: " + managers );
        }

        /**
         * Method to display all employees in every department in the system to the listbox
         */
        private void btnViewAllEmployees_Click( object sender, EventArgs e )
        {
            lBoxEmpStats.Items.Clear();

            foreach(Staff staff in department.GetStaff())
            {
                if(staff is Employee)
                {
                    if( ( !lBoxEmpStats.Items.Contains( staff.FirstName ) ) && ( staff.Role == Position.Employee ) )
                    {
                        lBoxEmpStats.Items.Add( staff.FirstName + " " + staff.LastName );
                    }
                }
            }
        }

        /**
         * Method to search and display information in the listbox
         */
        private void btnSearch_Click( object sender, EventArgs e )
        {
            // Set textbox characters to lowercase
            txtBoxStatsSearch.CharacterCasing = CharacterCasing.Lower;
            String searchedValue = txtBoxStatsSearch.Text;
            lBoxEmpStats.Items.Clear();

            try
            {
                foreach( Staff staff in department.GetStaff() )
                {
                    if(staff is Employee)
                    {
                        if( searchedValue.Contains( staff.FirstName.ToLower() ) && staff.Role == Position.Employee )
                        {
                            lBoxEmpStats.Items.Add(
                                staff.dbID + " - " +
                                "Name: " + staff.FirstName + " - " +
                                staff.LastName + " - " +
                                "Role: " + staff.Role + " - " +
                                "Age: " + staff.Age
                            );
                        }
                    }
                }
            }
            catch( Exception )
            {
                MessageBox.Show( "Sorry, that person doesn't exist" );
            }
        }

        /**
         * Method to display info on the table based on a user's first name from the searchbox
         */
        private void btnHomeSearch_Click( object sender, EventArgs e )
        {
            txtBoxHomeSearch.CharacterCasing = CharacterCasing.Lower;
            String searchedValue = txtBoxHomeSearch.Text;
            dataAdminWorkSchedule.Rows.Clear();

            try
            {
                foreach( Schedule schedule in department.GetSchedules() )
                {
                    if( searchedValue.Contains( schedule.FirstName.ToLower() ) )
                    {
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells( dataAdminWorkSchedule );
                        newRow.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName;
                        newRow.Cells[ 1 ].Value = schedule.Role;
                        newRow.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );
                        newRow.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" );
                        newRow.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" );
                        dataAdminWorkSchedule.Rows.Add(newRow);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show( "Sorry, that person doesn't exist" );
            }
        }

        /**
         * Method to display info based on the selected option from the dropdown list (HOME PAGE)
         */
        private void cmboBoxFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
            dataAdminWorkSchedule.Rows.Clear();

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if( department.Name == schedule.DepartmentName )
                {
                    if( cmboBoxFilter.SelectedItem.ToString() == "All" )
                    {
                        DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                        dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataAdminWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataAdminWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                        row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                        row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );
                        row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" );
                        row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" );
                        dataAdminWorkSchedule.Rows.Add( row );
                    }
                    else if( cmboBoxFilter.SelectedItem.ToString() == schedule.Role )
                    {
                        DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                        dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataAdminWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataAdminWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                        row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                        row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );
                        row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" );
                        row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" );
                        dataAdminWorkSchedule.Rows.Add( row );
                    }
                }
            }
        }

        /**
         * Method whenever mouse hovers over the logout icon
         */
        private void picBoxLogout_MouseEnter(object sender, EventArgs e)
        {
            picBoxLogout.Cursor = Cursors.Hand;
        }

        /**
         * Method whenever mouse is not hovering over logout icon
         */
        private void picBoxLogout_MouseLeave(object sender, EventArgs e)
        {
            picBoxLogout.Cursor = Cursors.Default;
        }

        /**
         * Method to load data into tab page when tab page is selected
         */
        private void tbControlAdmin_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( tbControlAdmin.SelectedTab == tbControlAdmin.TabPages[ "tbPageStatistics" ] )//your specific tabname
            {
                this.GetStatistics();
            }
        }

        /**
         * Method to filter information in the list box based on role (STATS PAGE)
         */
        private void cmboBoxStatsFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
            lBoxEmpStats.Items.Clear();

            foreach( Staff staff in department.GetStaff() )
            {
                if( (cmboBoxStatsFilter.SelectedItem.ToString() == "FullTime") && (staff.Contract == Contract.FullTime) && staff.Role == Position.Employee )
                {
                    lBoxEmpStats.Items.Add(
                        "Name: " + staff.FirstName + " " +
                        staff.LastName + " --- " +
                        "Role: " + staff.Role + " --- " +
                        "Salary: " + staff.Salary
                    );
                }
                else if( ( cmboBoxStatsFilter.SelectedItem.ToString() == "PartTime" ) && ( staff.Contract == Contract.PartTime ) && staff.Role == Position.Employee )
                {
                    lBoxEmpStats.Items.Add(
                        "Name: " + staff.FirstName + " " +
                        staff.LastName + " --- " +
                        "Role: " + staff.Role + " --- " +
                        "Salary: " + staff.Salary
                    );
                }
            }
        }

        /**
         * Method to update user information in the profile
         */
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if(checkProfileChange())
            {
                dataBase.updateProfile(manager, txtBoxFirstName.Text, txtBoxLastName.Text, Convert.ToDateTime(txtBoxAge.Text), txtBoxAddress.Text, txtBoxEmail.Text);

                //Updates profile.
                lbEmployeeInfo.Items.Clear();
                refreshProfile();

                MessageBox.Show("Profile Updated Successfully");
            }
            else
            {
                MessageBox.Show("Information incorrect or not changed.");
            }
        }

        /**
         * Method to refresh profile
         */
        private void refreshProfile() //Adds all manager's data into the listbox and textboxes.
        {
            //lbEmployeeInfo.Items.Clear();
            lbEmployeeInfo.Items.Add("Name: " + manager.FirstName);
            lbEmployeeInfo.Items.Add("Surname: " + manager.LastName);
            lbEmployeeInfo.Items.Add("Date of Birth: " + manager.dateOfBirth.Date.ToShortDateString());
            lbEmployeeInfo.Items.Add("Age: " + manager.Age);
            lbEmployeeInfo.Items.Add("Address: " + manager.Address);
            lbEmployeeInfo.Items.Add("Email: " + manager.Email);

            txtBoxFirstName.Text = manager.FirstName;
            txtBoxLastName.Text = manager.LastName;
            txtBoxAge.Text = manager.dateOfBirth.Date.ToShortDateString();
            txtBoxAddress.Text = manager.Address;
            txtBoxEmail.Text = manager.Email;
        }

        /**
         * Method to check if profile has been changed
         */
        private bool checkProfileChange()
        {
            if(txtBoxFirstName.Text == manager.FirstName && txtBoxLastName.Text == manager.LastName && Convert.ToDateTime(txtBoxAge.Text) == manager.dateOfBirth && txtBoxAddress.Text == manager.Address && txtBoxEmail.Text == manager.Email)
            {
                return false;
            }
            else if (String.IsNullOrEmpty(txtBoxFirstName.Text) || String.IsNullOrEmpty(txtBoxLastName.Text) || String.IsNullOrEmpty(txtBoxAge.Text) || String.IsNullOrEmpty(txtBoxAddress.Text) || String.IsNullOrEmpty(txtBoxEmail.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /**
         * Focus out selection
         */
        private void lbManagers_Click(object sender, EventArgs e)
        {
            lbEmployees.SelectedItem = null;
        }

        /**
         * Focus out selection
         */
        private void lbEmployees_Click(object sender, EventArgs e)
        {
            lbManagers.SelectedItem = null;
        }

        /**
         * Remove placeholder
         */
        private void txtBoxHomeSearch_Click(object sender, EventArgs e)
        {
            txtBoxHomeSearch.Text = "";
        }

        /**
         * Remove placeholder
         */
        private void txtBoxStatsSearch_Click(object sender, EventArgs e)
        {
            txtBoxStatsSearch.Text = "";
        }

        /**
          * Method to show information (SCHEDULE MANAHEMENT TAB)
          */
        private void picBoxInformationIcon_Click( object sender, EventArgs e )
        {
            String info = "As HR manager you have to the ability to make schedules based on the employee's submitted preferred shifts " +
                "or you can make a schedule if they are no preferred shifts by an employee. " +
                "There can only be 5 schedule made PER day and ONE employee per shift. " +
                "After submitting the schedule, the employee will receive a email with schedule information.";

            InformationForm informationForm = new InformationForm( info );
            informationForm.Show();
        }

        /**
         * Method to load schedule information when form is loaded
         */
        private void LoadScheduleInformation()
        {
            DateTime time = DateTime.Today;
            for( DateTime _time = time.AddHours( 08 ); _time < time.AddHours( 24 ); _time = _time.AddMinutes( 60 ) ) //from 16h to 18h hours
            {
                comBoxStartTime.Items.Add( _time.ToShortTimeString() );
                comBoxEndTime.Items.Add( _time.ToShortTimeString() );
            }

            foreach( Staff staff in department.GetStaff() )
            {
                if( staff is Employee )
                {
                    comBoxEmployees.Items.Add( staff.FirstName + " " + staff.LastName );
                }
            }
        }

        /**
         * Method to add a new schedule to the system
         */
        private void btnDone_Click( object sender, EventArgs e )
        {
            lBoxSchedulingEmployee.Items.Clear();
            Staff staff = department.GetStaffMember( comBoxEmployees.SelectedItem.ToString() );
            String startTime = comBoxStartTime.SelectedItem.ToString();
            String endTime = comBoxEndTime.SelectedItem.ToString();
            String workDate = comBoxWorkDate.SelectedItem.ToString();
            DateTime updateStartTime = DateTime.Parse( startTime );
            DateTime updateEndTime = DateTime.Parse( endTime );
            DateTime updateWorkDate = DateTime.Parse( workDate );
                        
            foreach( Schedule schedule in department.GetSchedules() )
            {
                //updateTimer.Enabled = false;

                if( !lBoxSchedulingEmployee.Items.Contains( "Employee: " + staff.FirstName + " " + staff.LastName + " Start time: " + startTime + " End time: " + endTime + " Work date: " + workDate ) )
                {
                    try
                    {
                        String body = 
                                    "This is your newly added shift. " + " Start time: " + startTime + " End time: " + endTime + " Work date: " + updateWorkDate.ToString( "dddd, dd MMMM yyyy" ) + ". " +
                                    "If you are not content with your schedule. " +
                                    "Please contact your manager or make personal agreements with your colleages. " +
                                    "However, if you switch your shift with a colleage please do not forget to notify your manager. " +
                                    "They will need to update your schedule.";

                        lBoxSchedulingEmployee.Items.Add
                        (
                            "Employee: " + staff.FirstName + " " + staff.LastName +
                            " Start time: " + startTime +
                            " End time: " + endTime +
                            " Work date: " + workDate
                        );
                        schedule.UpdateSchedule( staff.dbID, staff.FirstName, staff.LastName, staff.Role.ToString(), updateStartTime, updateEndTime, updateWorkDate, this.department.Name );

                        dataBase.AddSchedule( staff, startTime, endTime, workDate );
                        emailHelper.SendScheduleEmail( body, staff.Email );

                        MessageBox.Show( "Schedule successfully added!" );
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show( "Sorry request failed." ) ;
                    }
                }
            }
        }

        /**
         * Method to run when user select an employee
         * 
         * It will check if the selected employee exists
         * Then it will get all of the employee's available dates 
         * Then it will check if those dates had been already scheduled.
         * If so, it will not display those dates. 
         * If not, then it will display the dates that are not yet scheduled
         * 
         * Also, if there more than 5 schedules made in a day, then it will not be scheduled
         */
        private void comBoxEmployees_SelectedIndexChanged( object sender, EventArgs e )
        {
            comBoxWorkDate.DataSource = null;
            Staff staff = department.GetStaffMember( comBoxEmployees.SelectedItem.ToString() );
            MySqlDataReader reader = dataBase.getEmpAvailableWorkDates( staff.dbID );

            if( reader.HasRows )
            {
                // Add data to data grid view table
                while( reader.Read() )
                {
                    int employee = ( int ) reader.GetValue( 4 );
                    DateTime workDate = Convert.ToDateTime( reader.GetValue( 1 ).ToString() );

                    if( employee == staff.dbID )
                    {
                        comBoxWorkDate.Items.Add( workDate.ToString( "dddd, dd MMMM yyyy" ) );

                        foreach( Schedule schedule in department.GetSchedules() )
                        {
                            if( employee == schedule.EmployeeID && workDate != null )
                            {
                                for( int i = 0; i < comBoxWorkDate.Items.Count; i++ )
                                {
                                    if( comBoxWorkDate.Items[ i ].ToString() == schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ) )
                                    {
                                        comBoxWorkDate.Items.Remove( comBoxWorkDate.Items[ i ].ToString() );
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                List<DateTime> dates = new List<DateTime>();

                DateTime thisMonth = new DateTime( DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );

                for( int i = 0; i < 7; i++ )
                {
                    dates.Add( thisMonth.AddDays( i ) );
                }

                comBoxWorkDate.DataSource = dates;
                comBoxWorkDate.FormatString = "dddd, dd MMMM yyyy";
            }
        }


        /**
         * Method to run when user selects a month from the combobox
         * In this method there will be checks and looping
         * 
         * It will loop over staff and schedules
         * Then will check if the month is equal to the months in schedule
         * Then will check for duplicated staff id (in the same month) 
         * Then assign the calculated hours per month to a new value
         * Then display
         */
        private void comboBoxMonth_SelectedIndexChanged( object sender, EventArgs e )
        {   
            lBoxScheduleStats.Items.Clear();

            List<Schedule> schedules = department.GetSchedules();
            List<Staff> staff = department.GetStaff();

            int currentID;

            for(int i = 0; i < staff.Count; i++)
            {
                if(staff[i] is Employee)
                {
                    currentID = staff[i].dbID;
                    int hoursWorked = 0;
                    foreach (Schedule schedule in schedules)
                    {
                        if( comboBoxMonth.SelectedItem.ToString() == schedule.WorkDate.ToString( "MMMM" ) )
                        {
                            if( currentID == schedule.EmployeeID )
                            {
                                hoursWorked += ( int ) ( schedule.EndTime - schedule.StartTime ).TotalHours;

                            }
                        }
                    }
                    
                    if(hoursWorked == 0)
                    {
                        String toShow = staff[ i ].FirstName + " " + staff[ i ].LastName + " : " + "No available hours recorded this month";
                        lBoxScheduleStats.Items.Add( toShow );
                    }
                    else
                    {
                        String toShow = staff[ i ].FirstName + " " + staff[ i ].LastName + " : " + hoursWorked + " hours";
                        lBoxScheduleStats.Items.Add( toShow );
                    }
                }
            }
        }
    }
}