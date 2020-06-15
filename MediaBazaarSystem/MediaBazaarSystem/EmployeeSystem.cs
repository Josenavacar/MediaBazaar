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

namespace MediaBazaarSystem
{
    public partial class EmployeeSystem : Form
    {
        DatabaseHelper dataBase;
        private Department department;
        private Schedule schedule;
        private Employee employee;

        /**
         * The Constructor
         */
        public EmployeeSystem(Department department, Employee employee)
        {
            InitializeComponent();
            dataBase = new DatabaseHelper();
            this.employee = employee;
            this.department = department;
            updateTimer.Enabled = true;
            this.UpdateSchedule();
            lblEmployeeName.Text += " " + employee.FirstName + " " + employee.LastName;
            refreshProfile();
            dtpAvailableWorkDates.MinDate = DateTime.Now;
            dtpAvailableWorkDates.MaxDate = DateTime.Now.AddDays( 7 );
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
            MySqlDataReader reader = dataBase.getSchedules();

            // Add data to data grid view table
            while ( reader.Read() )
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
                    DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                    dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.Cells[ 0 ].Value = firstName + " " + lastName;// First Name
                    row.Cells[ 1 ].Value = role;// Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = date.ToString( "dddd, dd MMMM yyyy" ); // Date
                    dataEmpWorkSchedule.Rows.Add( row );
                }
            }
        }

        /**
         * Method to update the schedule table
         */
        private void UpdateSchedule()
        {
            // Clear table
            lBoxEmpHistory.Items.Clear();
            this.dataEmpWorkSchedule.Rows.Clear();
            department.GetSchedules().Clear();

            MySqlDataReader reader = dataBase.updateSchedules();
            this.GetWorkScheduleDB( reader );
            //this.GetShifts( sql, connection );
            // Disable timer
            updateTimer.Enabled = false;
        }

        /**
         * Method to get database info on work schedule
         */
        private void GetWorkScheduleDB( MySqlDataReader reader )
        {
            if( reader.HasRows )
            {
                // Get the data
                while( reader.Read() )
                {
                    int employeeID = (int)reader.GetValue( 0 );
                    String firstName = reader.GetValue( 1 ).ToString();
                    String lastName = reader.GetValue(2).ToString();
                    String role = reader.GetValue( 3 ).ToString();
                    String startTime = reader.GetValue( 4 ).ToString();
                    String endTime = reader.GetValue( 5 ).ToString();
                    String workDate = reader.GetValue( 6 ).ToString();
                    String departmentName = reader.GetValue( 7 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );
                    int scheduleID = ( int ) reader.GetValue( 8 );

                    if( (dtpWorkSchedule.Value.Date == convertedWorkDate.Date) && ( department.Name == departmentName))
                    {
                        // Add data to data grid view table
                        DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                        dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataEmpWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataEmpWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = firstName + " " + lastName; // First Name
                        row.Cells[ 1 ].Value = role; // Name (Role)
                        row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                        row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                        row.Cells[ 4 ].Value = convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                        dataEmpWorkSchedule.Rows.Add( row );
                    }

                    schedule = new Schedule(scheduleID, firstName, lastName, role, workStartTime, workEndTime, convertedWorkDate, departmentName, employeeID );
                    department.AddSchedule( schedule );

                    if( employeeID == employee.dbID )
                    {
                        lBoxEmpHistory.Items.Add(
                            convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ) + " - " +
                            workStartTime.ToString( "hh:mm tt" ) + " - " +
                            workEndTime.ToString( "hh:mm tt" ) 
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show( "Sorry there's no data. Contact your administrator for more information." );
            }

            reader.Close();
            //connection.Close();
        }

        /**
         * Method to display info on the table based on a user's first name from the searchbox
         */
        private void btnHomeSearch_Click( object sender, EventArgs e )
        {
            txtBoxHomeSearch.CharacterCasing = CharacterCasing.Lower;
            String searchedValue = txtBoxHomeSearch.Text;
            dataEmpWorkSchedule.Rows.Clear();

            try
            {
                foreach( Schedule schedule in department.GetSchedules() )
                {
                    if( searchedValue.Contains( schedule.FirstName.ToLower() ) )
                    {
                        DataGridViewRow newRow = new DataGridViewRow();
                        newRow.CreateCells( dataEmpWorkSchedule );
                        newRow.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName;
                        newRow.Cells[ 1 ].Value = schedule.Role;
                        newRow.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );
                        newRow.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" );
                        newRow.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" );
                        dataEmpWorkSchedule.Rows.Add( newRow );
                    }
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Sorry, that person doesn't exist" );
            }
        }

        /**
         * Method to display info based on the selected option from the dropdown list
         */
        private void cmboBoxFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
            dataEmpWorkSchedule.Rows.Clear();

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if( department.Name == schedule.DepartmentName )
                {
                    if( cmboBoxFilter.SelectedItem.ToString() == "All" )
                    {
                        DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                        dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataEmpWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataEmpWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                        row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                        row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );// Start Time
                        row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" ); // End Time
                        row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                        dataEmpWorkSchedule.Rows.Add( row );
                    }
                    else if( cmboBoxFilter.SelectedItem.ToString() == schedule.Role )
                    {
                        DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                        dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataEmpWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataEmpWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                        row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                        row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );// Start Time
                        row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" ); // End Time
                        row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                        dataEmpWorkSchedule.Rows.Add( row );
                    }
                }
            }
        }

        /**
         * Method to view all shifts in table
         */
        private void btnViewAllShifts_Click( object sender, EventArgs e )
        {
            this.dataEmpWorkSchedule.Rows.Clear();

            foreach(Schedule schedule in department.GetSchedules())
            {
                if( department.Name == schedule.DepartmentName )
                {
                    DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                    dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    dataEmpWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                    dataEmpWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    row.Cells[ 0 ].Value = schedule.FirstName + " " + schedule.LastName; // First Name
                    row.Cells[ 1 ].Value = schedule.Role; // Name (Role)
                    row.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                    dataEmpWorkSchedule.Rows.Add( row );
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
            dataEmpWorkSchedule.Sort( dataEmpWorkSchedule.Columns[ 0 ], ListSortDirection.Ascending );
        }

        /**
         * Method to update the user's profile
         */
        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (checkProfileChange())
            {
                dataBase.updateProfile(employee, txtBoxFirstName.Text, txtBoxLastName.Text, Convert.ToDateTime(txtBoxAge.Text), txtBoxAddress.Text, txtBoxEmail.Text);

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
        private void refreshProfile() //Adds all employee's data into the listbox and textboxes.
        {
            //lbEmployeeInfo.Items.Clear();
            lbEmployeeInfo.Items.Add("Name: " + employee.FirstName);
            lbEmployeeInfo.Items.Add("Surname: " + employee.LastName);
            lbEmployeeInfo.Items.Add("Date of Birth: " + employee.dateOfBirth.Date.ToShortDateString());
            lbEmployeeInfo.Items.Add("Age: " + employee.Age);
            lbEmployeeInfo.Items.Add("Address: " + employee.Address);
            lbEmployeeInfo.Items.Add("Email: " + employee.Email);
        
            txtBoxFirstName.Text = employee.FirstName;
            txtBoxLastName.Text = employee.LastName;
            txtBoxAge.Text = employee.dateOfBirth.ToShortDateString();
            txtBoxAddress.Text = employee.Address;
            txtBoxEmail.Text = employee.Email;
        }
        
        /**
         * Method to check if profile has been changed
         */
        private bool checkProfileChange()
        {
            if (txtBoxFirstName.Text == employee.FirstName && txtBoxLastName.Text == employee.LastName && Convert.ToDateTime(txtBoxAge.Text) == employee.dateOfBirth && txtBoxAddress.Text == employee.Address && txtBoxEmail.Text == employee.Email)
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
         * Method to change password
         */
        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            //On click, opens a form to change the currently logged in user's password.
            ChangePassword pwd = new ChangePassword(null, employee);
            pwd.StartPosition = FormStartPosition.CenterParent;
            pwd.ShowDialog(this);
        }

        /**
         * Method to search the table based on the day (you can only search days and not dates e.g. tuesday or friday)
         */
        private void btnSearch_Click( object sender, EventArgs e )
        {
            lBoxEmpHistory.Items.Clear();
            txtBoxSearch.CharacterCasing = CharacterCasing.Lower;
            String searchedValue = txtBoxSearch.Text;

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if( schedule.FirstName == this.employee.FirstName )
                {
                    if( searchedValue.Contains( schedule.WorkDate.ToString( "dddd" ).ToLower() ) )
                    {
                        lBoxEmpHistory.Items.Add(
                            schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ) + " - " +
                            schedule.StartTime.ToString( "hh:mm tt" ) + " - " +
                            schedule.EndTime.ToString( "hh:mm tt" )
                        );
                    }
                }
            }
        }

        /**
         * Method to view employee's work history
         */
        private void btnViewWorkHistory_Click( object sender, EventArgs e )
        {
            lblWorkHistory.Text = null;
            lblWorkHistory.Text = "Your work history:";
            this.UpdateSchedule();
        }

        /**
         * Method to show employee's morning shifts history
         */
        private void btnMorningShift_Click( object sender, EventArgs e )
        {
            lblWorkHistory.Text = null;
            lblWorkHistory.Text = "Your work history: morning shifts";
            lBoxEmpHistory.Items.Clear();

            MySqlDataReader reader = dataBase.getShift();

            if ( reader.HasRows )
            {
                // Get the data
                while( reader.Read() )
                {
                    int employeeID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetValue( 1 ).ToString();
                    String lastName = reader.GetValue( 2 ).ToString();
                    String role = reader.GetValue( 3 ).ToString();
                    String startTime = reader.GetValue( 4 ).ToString();
                    String endTime = reader.GetValue( 5 ).ToString();
                    String workDate = reader.GetValue( 6 ).ToString();
                    String departmentName = reader.GetValue( 7 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );

                    if( ( this.employee.FirstName == firstName ) && ( department.Name == departmentName ) )
                    {
                        if( ( workStartTime.ToString( "hh:mm tt" ) == "08:00 AM" ) && ( workEndTime.ToString( "hh:mm tt" ) == "11:00 AM" ) )
                        {
                            lBoxEmpHistory.Items.Add(
                                "Date: " + convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ) +
                                " --- Start time: " + workStartTime.ToString( "hh:mm tt" ) +
                                " --- End time: " + workEndTime.ToString( "hh:mm tt" )
                            );
                        }
                    }
                }
            }

            reader.Close();
            //connection.Close();
        }

        /**
         * Method to show employee's afternoon shifts history
         */
        private void btnAfternoonShift_Click( object sender, EventArgs e )
        {
            lblWorkHistory.Text = null;
            lblWorkHistory.Text = "Your work history: afternoon shifts";
            lBoxEmpHistory.Items.Clear();

            MySqlDataReader reader = dataBase.getShift();

            if ( reader.HasRows )
            {
                // Get the data
                while( reader.Read() )
                {
                    int employeeID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetValue( 1 ).ToString();
                    String lastName = reader.GetValue( 2 ).ToString();
                    String role = reader.GetValue( 3 ).ToString();
                    String startTime = reader.GetValue( 4 ).ToString();
                    String endTime = reader.GetValue( 5 ).ToString();
                    String workDate = reader.GetValue( 6 ).ToString();
                    String departmentName = reader.GetValue( 7 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );

                    if( ( this.employee.FirstName == firstName ) && ( department.Name == departmentName ) )
                    {
                        if( ( workStartTime.ToString( "hh:mm tt" ) == "12:00 PM" ) && ( workEndTime.ToString( "hh:mm tt" ) == "04:00 PM" ) )
                        {
                            lBoxEmpHistory.Items.Add(
                                "Date: " + convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ) +
                                " --- Start time: " + workStartTime.ToString( "hh:mm tt" ) +
                                " --- End time: " + workEndTime.ToString( "hh:mm tt" )
                            );
                        }
                    }
                }
            }

            reader.Close();
            //connection.Close();
        }

        /**
         * Method to show employee's evening shifts history
         */
        private void btnEveningShift_Click( object sender, EventArgs e )
        {
            lblWorkHistory.Text = null;
            lblWorkHistory.Text = "Your work history: evening shifts";
            lBoxEmpHistory.Items.Clear();

            MySqlDataReader reader = dataBase.getShift();

            if ( reader.HasRows )
            {
                // Get the data
                while( reader.Read() )
                {
                    int employeeID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetValue( 1 ).ToString();
                    String lastName = reader.GetValue( 2 ).ToString();
                    String role = reader.GetValue( 3 ).ToString();
                    String startTime = reader.GetValue( 4 ).ToString();
                    String endTime = reader.GetValue( 5 ).ToString();
                    String workDate = reader.GetValue( 6 ).ToString();
                    String departmentName = reader.GetValue( 7 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );

                    if( ( this.employee.FirstName == firstName ) && ( department.Name == departmentName ) )
                    {
                        if( ( workStartTime.ToString( "hh:mm tt" ) == "05:00 PM" ) && ( workEndTime.ToString( "hh:mm tt" ) == "09:00 PM" ) )
                        {
                            lBoxEmpHistory.Items.Add(
                                "Date: " + convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ) +
                                " --- Start time: " + workStartTime.ToString( "hh:mm tt" ) +
                                " --- End time: " + workEndTime.ToString( "hh:mm tt" )
                            );
                        }
                    }
                }
            }

            reader.Close();
            //connection.Close();
        }

        private void txtBoxSearch_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Text = "";
        }

        private void txtBoxHomeSearch_Click(object sender, EventArgs e)
        {
            txtBoxHomeSearch.Text = "";
        }

        private void btnAddWorkDate_Click( object sender, EventArgs e )
        {
            if(employee != null)
            {
                int employeeID = employee.dbID;
                DateTime workDate = dtpAvailableWorkDates.Value;

                if(!lBoxWorkDates.Items.Contains( employeeID.ToString() + " " + workDate.ToString( "dddd, dd MMMM yyyy" ) ) )
                {
                    lBoxWorkDates.Items.Add( employeeID.ToString() + " " + workDate.ToString( "dddd, dd MMMM yyyy" ) );
                    dataBase.AddEmployeeWorkDate( employee, workDate );
                }
                else
                {
                    MessageBox.Show( "This date is already chosen! Please choose another day." );
                }
            }
            else
            {
                MessageBox.Show( "You're not authorized to make this request." );
            }
        }
    }
}
