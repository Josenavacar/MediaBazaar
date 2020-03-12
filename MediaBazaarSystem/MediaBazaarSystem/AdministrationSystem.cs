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
        AssignEmployeeSystem assignEmployeeForm;
        private Department department;
        private Manager manager;
        private Schedule schedule;
        private Employee emp;
        public static bool ensure;
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
            // Enable timer
            updateTimer.Enabled = true;
            this.GetStatistics();
            this.UpdateScheduleAndEmployeeManagement();
        }

        /**
         * Method to update the table when timer is running.
         */
        private void UpdateScheduleAndEmployeeManagement()
        {
            // Clear table
            this.dataAdminWorkSchedule.Rows.Clear();
            this.lbEmployees.Items.Clear();
            this.lbManagers.Items.Clear();

            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";

            // SQL Query
            string sql = "SELECT Person.Id, Person.FirstName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";
            // Start mysql objects
            MySqlConnection connection = new MySqlConnection( connectionString );

            MySqlCommand cmd = new MySqlCommand( sql, connection );
            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

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
                DateTime convertedWorkDate = Convert.ToDateTime(workDate);

                // Add data to data grid view table
                DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = firstName; // First Name
                row.Cells[ 1 ].Value = role; // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = convertedWorkDate.ToString( "dddd, dd MMMM yyyy" ); // Work Date
                dataAdminWorkSchedule.Rows.Add( row );

                schedule = new Schedule( firstName, role, workStartTime, workEndTime, convertedWorkDate );
                department.AddSchedule( schedule );
            }

            reader.Close();

            //Employee related
            String sql2 = "SELECT * FROM person WHERE DepartmentID = @DepartmentID";
            MySqlCommand cmd2 = new MySqlCommand( sql2, connection );
            cmd2.Parameters.Add( "DepartmentID", MySqlDbType.VarChar ).Value = department.DepartmentID;
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

                    if(department.GetManager(firstName, lastName) == null)
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

                    if(department.GetEmployee(firstName, lastName) == null)
                    {
                        department.AddEmployee( emp );
                    }

                    idManage = ID;
                }
            }
            reader.Close();

            // Disable timer
            updateTimer.Enabled = false;
            //Refresh.Enabled = false;
        }

        private void GetStatistics()
        {
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee_Add form1 = new Employee_Add(department, null, null);
            form1.Show();
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null)
            {
                Employee emp = SearchEmp();
                if (emp != null)
                {
                    ViewEmployee form1 = new ViewEmployee(emp, null);
                    form1.Show();
                }
            }
            else if(lbManagers.SelectedItem != null)
            {
                Manager man = SearchMan();
                if(man != null)
                {
                    ViewEmployee form1 = new ViewEmployee(null, man);
                    form1.Show();
                }
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (lbEmployees.SelectedItem != null)
            {
                Employee emp = SearchEmp();
                if (emp != null)
                {
                    Employee_Add form1 = new Employee_Add(department, emp, null);
                    form1.Show();
                }
            }

            else if(lbManagers.SelectedItem != null)
            {
                Manager man = SearchMan();
                if (man != null)
                {
                    Employee_Add form1 = new Employee_Add(department, null, man);
                    form1.Show();
                }
            }
            else
            {
                MessageBox.Show("Action could not be performed, noone selected.");
            }

        }

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

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            

            if (lbEmployees.SelectedItem != null)
            {
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent;
                check.ShowDialog(this);

                if(ensure)
                {
                    Employee fired = SearchEmp();
                    if (fired != null)
                    {
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery();

                        department.DeleteEmployee(fired);
                    }

                    ensure = false;
                }
            }

            else if (lbManagers.SelectedItem != null)
            {
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

                    ensure = false;
                }
            }
            
        }

        /**
         * Method to 
         */
        private void Refresh_Tick(object sender, EventArgs e)
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;

            lbEmployees.Items.Clear();
            List<Employee> listEmp = department.GetEmployees();
            foreach( Employee emp in listEmp )
            {
                String outpEmp = emp.LastName + ", " + emp.FirstName;
                lbEmployees.Items.Add( outpEmp );
            }

            try
            {
                if( lbEmployees.Items.Count > 0 )
                {
                    lbEmployees.SelectedIndex = indexEmp;
                }
            }
            catch( Exception ex )
            {
                lbEmployees.SelectedItem = null;
            }


            //Managers
            int indexMan = lbManagers.SelectedIndex;

            lbManagers.Items.Clear();
            List<Manager> listMan = department.GetManagers();
            foreach( Manager man in listMan )
            {
                String outpMan = man.LastName + ", " + man.FirstName;
                lbManagers.Items.Add( outpMan );
            }

            try
            {
                if( lbManagers.Items.Count > 0 )
                {
                    lbManagers.SelectedIndex = indexMan;
                }
            }
            catch( Exception ex )
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
            ChangePassword pwd = new ChangePassword( manager, null );
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
            this.UpdateScheduleAndEmployeeManagement();
        }

        /**
         * Method to view all shifts in table
         */
        private void btnViewAllShifts_Click( object sender, EventArgs e )
        {
            this.dataAdminWorkSchedule.Rows.Clear();
            this.UpdateScheduleAndEmployeeManagement();
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
         * Method to filter schedule table
         */
        private void btnFilter_Click( object sender, EventArgs e )
        {

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
            //lBoxStatistics.Items.Clear();
            //// Set textbox characters to lowercase
            //txtBoxSearch.CharacterCasing = CharacterCasing.Lower;
            //String searchedValue = txtBoxSearch.Text;

            //foreach( Employee employee in department.GetEmployees() )
            //{
            //    // Check if employee has first name with the value in search textbox
            //    // (Remember this info is coming from the database and comparing it to the searched value)
            //    // Return employee in listbox
            //    if( searchedValue.Contains( employee.FirstName.ToLower() ) ) // ToLower is lowercase
            //    {
            //        lBoxStatistics.Items.Add( employee.ToString() );
            //    }
            //}
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

        private void btnHomeSearch_Click( object sender, EventArgs e )
        {
            String searchedValue = txtBoxHomeSearch.Text;

            try
            {
                foreach( Schedule schedule in department.GetSchedules() )
                {
                    if( searchedValue.Contains( schedule.FirstName ) )
                    {
                        dataAdminWorkSchedule.Rows.Clear();

                        dataAdminWorkSchedule.Rows.Add(
                            schedule.FirstName,
                            schedule.Role,
                            schedule.StartTime.ToString( "hh:mm tt" ),
                            schedule.EndTime.ToString( "hh:mm tt" ),
                            schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" )
                        );
                    }
                }
            }
            catch(Exception ex)
            {

                MessageBox.Show( "Sorry, that person doesn't exist" );
                
            }

        }
    }
}
