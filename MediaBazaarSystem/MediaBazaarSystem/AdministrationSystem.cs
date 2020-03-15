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
    public partial class AdministrationSystem : Form
    {
        private AssignEmployeeSystem assignEmployeeForm;
        private Department department;
        private Manager manager;
        private Schedule schedule;
        private Employee emp;
        public static bool ensure; //Used for double checking when deleting from the database.
        int idManage;
        private String employeeName;

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
            this.GetStatistics();
            this.UpdateSchedule();
            this.UpdateEmployeeManagement();

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
                    String role = reader.GetValue( 2 ).ToString();
                    String startTime = reader.GetValue( 3 ).ToString();
                    String endTime = reader.GetValue( 4 ).ToString();
                    String workDate = reader.GetValue( 5 ).ToString();
                    DateTime workStartTime = Convert.ToDateTime( startTime );
                    DateTime workEndTime = Convert.ToDateTime( endTime );
                    DateTime convertedWorkDate = Convert.ToDateTime( workDate );

                    // Add data to data grid view table
                    DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                    dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    dataAdminWorkSchedule.Columns[ "clmnStartTime" ].DefaultCellStyle.BackColor = Color.PaleGreen;
                    dataAdminWorkSchedule.Columns[ "clmnEndTime" ].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                    row.Cells[ 0 ].Value = firstName; // First Name
                    row.Cells[ 1 ].Value = role; // Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                    dataAdminWorkSchedule.Rows.Add( row );

                    schedule = new Schedule( firstName, role, workStartTime, workEndTime, convertedWorkDate );
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
        public void GetEmployeeManagementDB(String sql, MySqlConnection connection)
        {
            this.lbEmployees.Items.Clear();
            this.lbManagers.Items.Clear();

            MySqlCommand cmd2 = new MySqlCommand( sql, connection );
            connection.Open();
            cmd2.Parameters.Add( "DepartmentID", MySqlDbType.VarChar ).Value = department.DepartmentID;
            MySqlDataReader reader;
            reader = cmd2.ExecuteReader();

            while( reader.Read() )
            {
                int role = ( int ) reader.GetValue( 11 );
                if( role == 1 )
                {
                    int ID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetString( 1 );
                    String lastName = reader.GetString( 2 );
                    int age = ( int ) reader.GetValue( 3 );
                    String address = reader.GetString( 4 );
                    String email = reader.GetString( 5 );
                    String charge = "Manager";
                    double salary = reader.GetDouble( 7 );
                    int hoursavailable = ( int ) reader.GetValue( 9 );
                    Manager man = new Manager( ID, firstName, lastName, age, address, charge, salary, hoursavailable, email );

                    if( department.GetManager( firstName, lastName ) == null )
                    {
                        department.AddManager( man );
                    }

                    idManage = ID;
                }
                else if( role == 2 )
                {
                    int ID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetString( 1 );
                    String lastName = reader.GetString( 2 );
                    int age = ( int ) reader.GetValue( 3 );
                    String address = reader.GetString( 4 );
                    String email = reader.GetString( 5 );
                    String charge = "Employee";
                    double salary = reader.GetDouble( 7 );
                    int hoursavailable = ( int ) reader.GetValue( 9 );
                    emp = new Employee( ID, firstName, lastName, age, address, charge, salary, hoursavailable, email );

                    if( department.GetEmployee( firstName, lastName ) == null )
                    {
                        department.AddEmployee( emp );
                    }

                    idManage = ID;
                }
            }
            reader.Close();
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
            string sql = "SELECT Person.Id, Person.FirstName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";
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
        public void UpdateEmployeeManagement()
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

        }

        /**
         * Method to add employee to the database
         */
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            UpdateOrAdd form1 = new UpdateOrAdd(department);
            form1.Show();
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
            Employee emp = department.GetEmployee(firstName, lastName);

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
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery(); //Delte from Database.

                        department.DeleteEmployee(fired); //Delete from list.
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
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery();

                        department.DeleteManager(fired);
                    }

                    ensure = false; //Set ensure back to false for future calls.
                }
            }

            conn.Close();
        }

        /**
         * Jose???
         */
        private void Refresh_Tick(object sender, EventArgs e)
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;
            lbEmployees.Items.Clear(); //Empties empoloyee listbox
            List<Employee> listEmp = department.GetEmployees(); 
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
            List<Manager> listMan = department.GetManagers();
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
            formLogin login = new formLogin();
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
            string sql = "SELECT FirstName, Name, StartTime, EndTime, WorkDate FROM Person " +
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
                String startTime = reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );
                DateTime date = Convert.ToDateTime( reader.GetValue( 4 ).ToString() );
                String theDate = dtpWorkSchedule.Value.ToString( "MM/dd/yyyy" );

                // Check if the date in the work schedule is equal to the date from the DB
                if( theDate == date.ToString( "MM/dd/yyyy" ) )
                {
                    DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                    dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                    row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = date.ToString( "MM/dd/yyyy" ); // Date
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
            // Get the row index and employee's name
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataAdminWorkSchedule.Rows[ index ];
            employeeName = selectedRow.Cells[ 0 ].Value.ToString();

            // Open the assign employee form
            assignEmployeeForm = new AssignEmployeeSystem( employeeName );
            assignEmployeeForm.Show();
        }

        /**
         * Method to update timer
         */
        private void updateTimer_Tick( object sender, EventArgs e )
        {
            updateTimer.Interval = 1000;
            this.UpdateSchedule();
        }

        /**
         * Method to view all shifts in table
         */
        private void btnViewAllShifts_Click( object sender, EventArgs e )
        {
            this.dataAdminWorkSchedule.Rows.Clear();
            this.UpdateSchedule();
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
         * Method to display all departments in system to listbox
         */
        private void btnViewAllDepartments_Click( object sender, EventArgs e )
        {
            //lBoxStatistics.Items.Clear();
            //// Connect to DB
            //string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            //// SQL Query
            //string sql = "SELECT Name FROM Department ";
            //// Start mysql objects
            //MySqlConnection connection = new MySqlConnection( connectionString );
            //MySqlCommand cmd = new MySqlCommand( sql, connection );
            //// Open connection
            //connection.Open();
            //MySqlDataReader reader = cmd.ExecuteReader();

            //// Get the data
            //while( reader.Read() )
            //{
            //    department = new Department( reader.GetString( 0 ) );
            //    lBoxStatistics.Items.Add( department.ToString() );
            //}
        }

        /**
         * Method to display all employees in every department in the system to the listbox
         */
        private void btnViewAllEmployees_Click( object sender, EventArgs e )
        {
            dataStatistics.Rows.Clear();
            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            // SQL Query
            string sql = "SELECT Person.Id, Person.FirstName, Person.LastName, Person.Age, Person.Address, Person.Salary, Person.HoursWorked, Person.HoursAvailable, Person.Email, Role.Name, Department.Name FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Department ON Person.DepartmentID = Department.Id";
            // Start mysql objects
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            // Get the data
            while( reader.Read() )
            {
                // Create employee object
                Employee employee = new Employee( 
                    Convert.ToInt32(reader.GetValue( 0 ).ToString()), //ID
                    reader.GetValue( 1 ).ToString(), // First Name
                    reader.GetValue( 2 ).ToString(), // Lastname
                    Convert.ToInt32(reader.GetValue( 3 )), // Age
                    reader.GetValue( 4 ).ToString(),  //Address
                    reader.GetValue( 9 ).ToString(),  //Role
                    Convert.ToDouble(reader.GetValue( 5 )), //Salary
                    Convert.ToInt32(reader.GetValue( 7 ).ToString()), // Hours available
                    reader.GetValue( 8 ).ToString() // Email
                    );
                department.AddEmployee(employee);
            }

            // Add employees to the data table
            foreach(Employee emp in department.GetEmployees())
            {
                DataGridViewRow row = ( DataGridViewRow ) dataStatistics.Rows[ 0 ].Clone();
                //dataStatistics.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = emp.FirstName;// First Name
                row.Cells[ 1 ].Value = emp.Role;// Name (Role)
                row.Cells[ 2 ].Value = emp.Salary;// Start Time
                row.Cells[ 3 ].Value = emp.HoursAvailable;// End Time
                row.Cells[ 4 ].Value = emp.Department;// Date
                row.Cells[ 5 ].Value = emp.Age;// Date
                dataStatistics.Rows.Add( row );
            }
        }

        /**
         * Method to display all products in the system to the listbox
         */
        private void btnViewAllProducts_Click( object sender, EventArgs e )
        {

        }

        /**
         * Method to search and display information in the listbox
         */
        private void btnSearch_Click( object sender, EventArgs e )
        {
            // Set textbox characters to lowercase
            txtBoxStatsSearch.CharacterCasing = CharacterCasing.Lower;
            String searchedValue = txtBoxStatsSearch.Text;
            dataStatistics.Rows.Clear();

            try
            {
                foreach( Employee employee in department.GetEmployees() )
                {
                    if( searchedValue.Contains( employee.FirstName.ToLower() ) )
                    {
                        //DataGridViewRow newRow = new DataGridViewRow();
                        //newRow.CreateCells( dataStatistics );
                        //newRow.Cells[ 0 ].Value = schedule.FirstName;
                        //newRow.Cells[ 1 ].Value = schedule.Role;
                        //newRow.Cells[ 2 ].Value = schedule.StartTime.ToString( "hh:mm tt" );
                        //newRow.Cells[ 3 ].Value = schedule.EndTime.ToString( "hh:mm tt" );
                        //newRow.Cells[ 4 ].Value = schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" );
                        //dataStatistics.Rows.Add( newRow );
                    }
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Sorry, that person doesn't exist" );
            }
        }

        /**
         * Method to undo a selection in the employees listbox
         */
        private void btnUndoEmpSelection_Click( object sender, EventArgs e )
        {
            lbEmployees.SelectedItem = null;
        }

        /**
         * Method to undo a selection in the manager listbox
         */
        private void btnUndoManSelection_Click( object sender, EventArgs e )
        {
            lbManagers.SelectedItem = null;
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
                        newRow.Cells[ 0 ].Value = schedule.FirstName;
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
         * Method to display info based on the selected option from the dropdown list
         */
        private void cmboBoxFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
            dataAdminWorkSchedule.Rows.Clear();
            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            // SQL Query
            string sql = "SELECT Person.Id, Person.FirstName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID " +
                "WHERE Role.name = '" + cmboBoxFilter.SelectedItem.ToString() + "'";
            // Start mysql objects
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            // Check which option is selected from the combobox
            if(cmboBoxFilter.SelectedItem.ToString() == "All")
            {
                this.UpdateSchedule();
            }
            else
             
            {   this.GetWorkScheduleDB(sql, connection);
            }
        }

        private void picBoxLogout_MouseEnter(object sender, EventArgs e)
        {
            picBoxLogout.Cursor = Cursors.Hand;
        }

        private void picBoxLogout_MouseLeave(object sender, EventArgs e)
        {
            picBoxLogout.Cursor = Cursors.Default;
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if(checkProfileChange())
            {
                //Updates manager in database.
                string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
                MySqlConnection conn = new MySqlConnection(connString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE person SET Firstname = @Firstname, Lastname = @Lastname, Age = @Age, Address = @Address, Email = @Email WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Firstname", txtBoxFirstName.Text);
                cmd.Parameters.AddWithValue("@Lastname", txtBoxLastName.Text);
                cmd.Parameters.AddWithValue("@Age", Convert.ToInt32(txtBoxAge.Text));
                cmd.Parameters.AddWithValue("@Address", txtBoxAddress.Text);
                cmd.Parameters.AddWithValue("@Email", txtBoxEmail.Text);
                cmd.Parameters.AddWithValue("@Id", manager.dbID);

                cmd.ExecuteNonQuery();

                //Updates manager in list.
                manager.EditManager(txtBoxFirstName.Text, txtBoxLastName.Text, Convert.ToInt32(txtBoxAge.Text), txtBoxAddress.Text, manager.Role, manager.Salary, manager.HoursAvailable, txtBoxEmail.Text);

                //Updates profile.
                refreshProfile();

                MessageBox.Show("Profile Updated Successfully");
            }
            else
            {
                MessageBox.Show("No changes made");
            }
        }

        private void refreshProfile() //Adds all manager's data into the listbox and textboxes.
        {
            lbEmployeeInfo.Items.Clear();
            lbEmployeeInfo.Items.Add("Name: " + manager.FirstName);
            lbEmployeeInfo.Items.Add("Surname: " + manager.LastName);
            lbEmployeeInfo.Items.Add("Age: " + manager.Age);
            lbEmployeeInfo.Items.Add("Address: " + manager.Address);
            lbEmployeeInfo.Items.Add("Email: " + manager.Email);
            txtBoxFirstName.Text = manager.FirstName;
            txtBoxLastName.Text = manager.LastName;
            txtBoxAge.Text = manager.Age.ToString();
            txtBoxAddress.Text = manager.Address;
            txtBoxEmail.Text = manager.Email;
        }

        private bool checkProfileChange()
        {
            if(txtBoxFirstName.Text == manager.FirstName && txtBoxLastName.Text == manager.LastName && Convert.ToInt32(txtBoxAge.Text) == manager.Age && txtBoxAddress.Text == manager.Address && txtBoxEmail.Text == manager.Email)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
