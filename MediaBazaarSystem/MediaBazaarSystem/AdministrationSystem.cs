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

namespace MediaBazaarSystem
{
    public partial class AdministrationSystem : Form
    {
        DatabaseHelper dataBase;
        private AssignEmployeeSystem assignEmployeeForm;

        private Department department;
        private Manager manager;
        private Schedule schedule;
        private Employee emp;
        public static bool ensure; //Used for double checking when deleting from the database.
        int idManage;
        private String employeeName;
        private String employeeRole;
        private String employeeStartTime;
        private String employeeEndTime;
        private String employeeWorkDate;

        /**
         * Constructor
         */
        public AdministrationSystem( Department department, Manager manager )
        {
            InitializeComponent();
            this.dataAdminWorkSchedule.Rows.Clear();
            this.department = department;
            this.manager = manager;
            lblAdminName.Text += " " + manager.FirstName + " " + manager.LastName;
            updateTimer.Enabled = true;
            this.UpdateSchedule();
            this.UpdateEmployeeManagement();
            hoursStatsChart.Titles.Add( "Hours Available" );
            dataBase = new DatabaseHelper();

            //Profile
            refreshProfile();
        }

        /**
         * Method to get database info on work schedule
         */
        private void GetWorkScheduleDB(String sql, MySqlConnection connection)
        {
            //this.connection = connection;
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.HasRows)
            {
                // Get the data
                while( reader.Read() )
                {
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
                    
                    schedule = new Schedule( scheduleID, firstName, lastName, role, workStartTime, workEndTime, convertedWorkDate, departmentName);
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
         * Method to get database info on employees
         */
        //private void GetEmployeeManagementDB(String sql, MySqlConnection connection)
        //{
        //    this.lbEmployees.Items.Clear();
        //    this.lbManagers.Items.Clear();

        //    MySqlCommand cmd2 = new MySqlCommand( sql, connection );
        //    connection.Open();
        //    cmd2.Parameters.Add( "DepartmentID", MySqlDbType.VarChar ).Value = department.DepartmentID;
        //    MySqlDataReader reader;
        //    reader = cmd2.ExecuteReader();

        //    while( reader.Read() )
        //    {
        //        int role = ( int ) reader.GetValue( 12 );
        //        if( role == 1 )
        //        {
        //            int ID = ( int ) reader.GetValue( 0 );
        //            String firstName = reader.GetString( 1 );
        //            String lastName = reader.GetString( 2 );
        //            DateTime birthDate = ( DateTime ) reader.GetValue( 3 );
        //            String address = reader.GetString( 4 );
        //            String email = reader.GetString( 5 );
        //            String charge = "Manager";
        //            double salary = reader.GetDouble( 7 );
        //            int hoursavailable = ( int ) reader.GetValue( 9 );
        //            int dbContract = ( int ) reader.GetValue( 13 );
        //            Contract contract;

        //            //Calculate age
        //            int age = DateTime.Now.Year - birthDate.Year - 1;
        //            if (birthDate.Month > DateTime.Now.Month)
        //            {
        //                age++;
        //            }
        //            else if (birthDate.Month == DateTime.Now.Month)
        //            {
        //                if (birthDate.Day >= DateTime.Now.Day)
        //                {
        //                    age++;
        //                }
        //            }

        //            if ( dbContract == 1 )
        //            {
        //                contract = Contract.FullTime;
        //            }
        //            else
        //            {
        //                contract = Contract.PartTime;
        //            }

        //            Manager man = new Manager( ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract );

        //            if( department.GetStaffMember( firstName, lastName ) == null )
        //            {
        //                department.AddStaffMember( man );
        //            }

        //            idManage = ID;
        //        }
        //        else if( role == 2 )
        //        {
        //            int ID = ( int ) reader.GetValue( 0 );
        //            String firstName = reader.GetString( 1 );
        //            String lastName = reader.GetString( 2 );
        //            DateTime birthDate = ( DateTime ) reader.GetValue( 3 );
        //            String address = reader.GetString( 4 );
        //            String email = reader.GetString( 5 );
        //            String charge = "Employee";
        //            double salary = reader.GetDouble( 7 );
        //            int hoursavailable = ( int ) reader.GetValue( 9 );
        //            int dbContract = ( int ) reader.GetValue( 13 );
        //            Contract contract;

        //            //Calculate age
        //            int age = DateTime.Now.Year - birthDate.Year - 1;
        //            if (birthDate.Month > DateTime.Now.Month)
        //            {
        //                age++;
        //            }
        //            else if (birthDate.Month == DateTime.Now.Month)
        //            {
        //                if (birthDate.Day >= DateTime.Now.Day)
        //                {
        //                    age++;
        //                }
        //            }

        //            if ( dbContract == 1 )
        //            {
        //                contract = Contract.FullTime;
        //            }
        //            else
        //            {
        //                contract = Contract.PartTime;
        //            }

        //            emp = new Employee( ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract );

        //            if( department.GetStaffMember( firstName, lastName ) == null )
        //            {
        //                department.AddStaffMember( emp );
        //            }

        //            idManage = ID;
        //        }
        //    }
        //    reader.Close();
        //}

        private void LoadStaff()
        {
            List<Staff> staff = dataBase.getStaffFromDB(department);
            foreach(Staff staffmember in staff)
            {
                String staffname = staffmember.FirstName + " " + staffmember.LastName;
                if (staffmember is Employee) //staffmember.Role == Position.Employee
                {
                    lbEmployees.Items.Add(staffmember);
                }
                else if(staffmember is Manager) //staffmember.Role == Position.HRManager || staffmember.Role == Position.StockManager
                {
                    lbManagers.Items.Add(staffmember);
                }
            }
        }

        /**
         * Method to update the schedule table
         */
        private void UpdateSchedule()
        {
            // Clear table
            this.dataAdminWorkSchedule.Rows.Clear();
            department.GetSchedules().Clear();
            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            // SQL Query
            string sql = "SELECT Person.Id, Person.FirstName, Person.LastName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate, Department.Name, Schedule.Id FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID " +
                "INNER JOIN Department ON Person.DepartmentID = Department.Id";

            // Start mysql objects
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            this.GetWorkScheduleDB( sql, connection );

            // Disable timer
            updateTimer.Enabled = false;
        }

        /**
         * Method to update the employee management 
         */
        private void UpdateEmployeeManagement()
        {
            this.lbEmployees.Items.Clear();
            this.lbManagers.Items.Clear();

            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection connection = new MySqlConnection( connectionString );
            //Employee related
            String sql2 = "SELECT * FROM person WHERE DepartmentID = @DepartmentID";
            MySqlCommand cmd2 = new MySqlCommand( sql2, connection );
            cmd2.Parameters.Add( "DepartmentID", MySqlDbType.VarChar ).Value = department.DepartmentID;
            this.GetEmployeeManagementDB( sql2, connection );
        }

        /**
         * Method to get statistics
         */
        private void GetStatistics()
        {
            lBoxStatistics.Items.Clear();
            hoursStatsChart.Series[ "Hours" ].Points.Clear();

            foreach( Employee employee in department.GetStaff() )
            {
                hoursStatsChart.Series[ "Hours" ].IsValueShownAsLabel = true;
                ChartArea chartArea = hoursStatsChart.ChartAreas[ 0 ];
                // The axis range
                chartArea.AxisX.Minimum = 0;
                chartArea.AxisX.Maximum = 10;
                hoursStatsChart.Series[ "Hours" ].Points.AddXY( employee.FirstName, employee.HoursAvailable );
            }

            foreach( Schedule schedule in department.GetSchedules() )
            {
                if( (schedule.DepartmentName == department.Name) && ( !lBoxStatistics.Items.Contains( schedule.FirstName ) ) && ( schedule.IsAvailable == true ) && (schedule.Role == "Employee") )
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
            UpdateOrAdd form = new UpdateOrAdd(department);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog(this);
        }

        /**
         * Method to view employee's details
         */
        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null) //Checks if an employee is selected in the listbox.
            {
                Employee emp = SearchEmp(); 
                if (emp != null)
                {
                    ViewEmployee form1 = new ViewEmployee(emp, null);
                    form1.Show();
                }
            }
            else if(lbManagers.SelectedItem != null) //Checks if a manager is selected in the listbox.
            {
                Manager man = SearchMan(); 
                if(man != null)
                {
                    ViewEmployee form1 = new ViewEmployee(null, man);
                    form1.Show();
                }
            }
        }

        /**
         * Method to update employee's information
         */
        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (lbEmployees.SelectedItem != null) //Checks if an employee is selected in the listbox.
            {
                Employee emp = SearchEmp();
                if (emp != null)
                {
                    UpdateOrAdd form1 = new UpdateOrAdd(department, emp);
                    form1.Show();
                }
            }

            else if(lbManagers.SelectedItem != null) //Checks if a manager is selected in the listbox.
            {
                Manager man = SearchMan();
                if (man != null)
                {
                    UpdateOrAdd form1 = new UpdateOrAdd(department, man);
                    form1.Show();
                }
            }
            else
            {
                MessageBox.Show("Action could not be performed, noone selected.");
            }

        }

        /**
         * Method that returns an employee selected on the listbox or null if it doesn't exist.
         */
        private Employee SearchEmp()
        {
            String auxEmp = lbEmployees.SelectedItem.ToString();
            String[] name = auxEmp.Split(','); //Splits the string by the comma.
            String firstName = name[1].Trim();
            String lastName = name[0].Trim();
            Employee emp = (Employee)department.GetStaffMember(firstName, lastName);

            if (emp == null)
            {
                MessageBox.Show("Employee not found.");
            }

            return emp;
        }

        /**
         * Method that returns a manager selected on the listbox or null if it doesn't exist.
         */
        private Manager SearchMan()
        {
            String auxMan = lbManagers.SelectedItem.ToString();
            String[] name = auxMan.Split(','); //Splits the string by the comma.
            String firstName = name[1].Trim();
            String lastName = name[0].Trim();
            Manager man = department.GetManager(firstName, lastName);

            if (man == null)
            {
                MessageBox.Show("Employee not found.");
            }

            return man;
        }

        /**
         * Method to delete employee from the database
         */
        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            

            if (lbEmployees.SelectedItem != null)
            {
                //Opens a form that will double check for deleting, if ensure is returned back as true, the employee will be deleted from the database.
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent; //Makes the form pop up in the middle of the parent form (this).
                check.ShowDialog(this);

                if(ensure)
                {
                    Employee fired = SearchEmp();
                    if (fired != null)
                    {
                        cmd.CommandText = "DELETE FROM schedule WHERE PersonId = @PersonId";
                        cmd.Parameters.AddWithValue("@PersonId", fired.dbID);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery(); //Delte from Database.

                        department.DeleteStaffMember(fired); //Delete from list.
                    }

                    ensure = false; //Set ensure back to false for future calls.
                }
            }

            else if (lbManagers.SelectedItem != null)
            {
                //Opens a form that will double check for deleting, if ensure is returned back as true, the manager will be deleted from the database.
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent;
                check.ShowDialog(this);

                if (ensure)
                {
                    Manager fired = SearchMan();
                    if (fired != null)
                    {
                        cmd.CommandText = "DELETE FROM schedule WHERE PersonId = @PersonId";
                        cmd.Parameters.AddWithValue("@PersonId", fired.dbID);
                        cmd.ExecuteNonQuery();
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery(); //Delte from Database.

                        department.DeleteStaffMember(fired);
                    }

                    ensure = false; //Set ensure back to false for future calls.
                }
            }

            conn.Close();
        }

        /**
         * Jose???
         */
        private void Refresh_Tick(object sender, EventArgs e)  ///////////TO CHANGE////////////////////////////////
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;
            lbEmployees.Items.Clear(); //Empties empoloyee listbox
            List<Staff> listEmp = department.GetStaff(); 
            foreach (Employee emp in listEmp) //Refills employee listbox
            {
                String outpEmp = emp.LastName + ", " + emp.FirstName;
                lbEmployees.Items.Add( outpEmp );
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if( lbEmployees.Items.Count > 0 )
                {
                    lbEmployees.SelectedIndex = indexEmp;
                }
            }
            catch(Exception ex) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbEmployees.SelectedItem = null;
            }

            //Managers
            int indexMan = lbManagers.SelectedIndex;
            lbManagers.Items.Clear(); //Empties managers listbox
            List<Staff> listMan = department.GetStaff();
            foreach (Manager man in listMan) //Refills managers listbox
            {
                String outpMan = man.LastName + ", " + man.FirstName;
                lbManagers.Items.Add( outpMan );
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if( lbManagers.Items.Count > 0 )
                {
                    lbManagers.SelectedIndex = indexMan;
                }
            }
            catch(Exception ex) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
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
            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            // SQL Query
            string sql = "SELECT FirstName, LastName, Name, StartTime, EndTime, WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";

            // Start mysql objects
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );

            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

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

            if( employeeRole == "Manager" )
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
                assignEmployeeForm = new AssignEmployeeSystem( department, schedule );
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
            lBoxDepartmentStats.Items.Add( "Number of employees that are employed: " + length );

            int fTime = 0;
            int pTime = 0;
            foreach(Staff employee in department.GetStaff())
            {
                if( employee.Contract == Contract.FullTime )
                {
                    fTime++;
                }
                else if( employee.Contract == Contract.PartTime )
                {
                    pTime++;
                }
            }
            lBoxDepartmentStats.Items.Add( fTime + " Fulltime workers." );
            lBoxDepartmentStats.Items.Add( pTime + " Parttime workers." );

            int dep = 0;
            for(int i = 0; i < department.GetSchedules().Count; i++ )
            {
                if(department.GetSchedules()[i].DepartmentName == department.Name)
                {
                    dep++;
                }
            }
            lBoxDepartmentStats.Items.Add( "Number of schedules related to this department: " + dep );

            int managers = department.GetStaff().Count;
            lBoxDepartmentStats.Items.Add( "Number of managers: " + managers );
        }

        /**
         * Method to display all employees in every department in the system to the listbox
         */
        private void btnViewAllEmployees_Click( object sender, EventArgs e )
        {
            lBoxEmpStats.Items.Clear();

            foreach(Employee employee in department.GetEmployees())
            {
                if( (!lBoxEmpStats.Items.Contains( employee.FirstName )) && (employee.Role == "Employee") )
                {
                    lBoxEmpStats.Items.Add( employee.FirstName + " " + employee.LastName );
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
                foreach( Employee employee in department.GetEmployees() )
                {
                    if( searchedValue.Contains( employee.FirstName.ToLower() ) )
                    {
                        lBoxEmpStats.Items.Add(
                            employee.dbID + " - " +
                            "Name: " + employee.FirstName + " - " +
                            employee.LastName + " - " +
                            "Role: " + employee.Role + " - " +
                            "Age: " + employee.Age
                        );
                    }
                }
            }
            catch( Exception ex )
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
            catch(Exception ex)
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

            foreach( Employee employee in department.GetEmployees() )
            {
                if( (cmboBoxStatsFilter.SelectedItem.ToString() == "FullTime") && (employee.Contract == Contract.FullTime))
                {
                    lBoxEmpStats.Items.Add(
                        "Name: " + employee.FirstName + " " +
                        employee.LastName + " --- " +
                        "Role: " + employee.Role + " --- " +
                        "Salary: " + employee.Salary
                    );
                }
                else if( ( cmboBoxStatsFilter.SelectedItem.ToString() == "PartTime" ) && ( employee.Contract == Contract.PartTime ) )
                {
                    lBoxEmpStats.Items.Add(
                        "Name: " + employee.FirstName + " " +
                        employee.LastName + " --- " +
                        "Role: " + employee.Role + " --- " +
                        "Salary: " + employee.Salary
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

        private void lbManagers_Click(object sender, EventArgs e)
        {
            lbEmployees.SelectedItem = null;
        }

        private void lbEmployees_Click(object sender, EventArgs e)
        {
            lbManagers.SelectedItem = null;
        }

        private void txtBoxHomeSearch_Click(object sender, EventArgs e)
        {
            txtBoxHomeSearch.Text = "";
        }

        private void txtBoxStatsSearch_Click(object sender, EventArgs e)
        {
            txtBoxStatsSearch.Text = "";
        }
    }
}