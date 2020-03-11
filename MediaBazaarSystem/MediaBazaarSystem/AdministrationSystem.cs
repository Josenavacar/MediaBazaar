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
        }

        /**
         * Method to update the table when timer is running.
         */
        private void UpdateSchedule()
        {
            // Clear table
            this.dataAdminWorkSchedule.Rows.Clear();
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
                String startTime = reader.GetValue( 3 ).ToString();
                String endTime = reader.GetValue( 4 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );

                // Add data to data grid view table
                DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = reader.GetValue( 1 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 2 ).ToString(); // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = reader.GetValue( 5 ).ToString(); // Date
                dataAdminWorkSchedule.Rows.Add( row );
            }

            // Disable timer
            updateTimer.Enabled = false;
        }

        private void GetStatistics()
        {
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            //Employee_Add form1 = new Employee_Add(dep, null);
            //form1.Show();
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            //Employee emp = SearchEmp();
            //if (emp != null)
            //{
            //    ViewEmployee form1 = new ViewEmployee(emp);
            //    form1.Show();
            //}
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            //Employee emp = SearchEmp();
            //if(emp != null)
            //{
            //    Employee_Add form1 = new Employee_Add(dep, emp);
            //    form1.Show();
            //}
            
        }

        //private Employee SearchEmp()
        //{
            //if (lbEmployees.SelectedItem != null)
            //{
            //    String aux = lbEmployees.SelectedItem.ToString();
            //    String[] name = aux.Split(','); //Splits the string by the comma.
            //    String firstName = name[1].Trim();
            //    String lastName = name[0].Trim();
            //    Employee emp = dep.GetEmployee(firstName, lastName);

            //    if(emp == null)
            //    {
            //        MessageBox.Show("Employee not found.");
            //    }

            //    return emp;
            //}
            //else
            //{
            //    MessageBox.Show("Employee not selected.");
            //    return null;
            //}
        //}

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            //Employee fired = SearchEmp();
            //if (fired != null)
            //{
            //    dep.DeleteEmployee(fired);
            //    MessageBox.Show("Employee Fired.");
            //}
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            //int aux1 = lbEmployees.SelectedIndex;

            //lbEmployees.Items.Clear();
            //List<Employee> list = dep.GetEmployees();
            //foreach (Employee emp in list)
            //{
            //    String aux = emp.LastN + ", " + emp.FirstN;
            //    lbEmployees.Items.Add(aux);
            //}

            //if (lbEmployees.Items.Count > 0)
            //{
            //    lbEmployees.SelectedIndex = aux1;
            //}
        }

        private void btnAssignEmployee_Click( object sender, EventArgs e )
        {
            //this.UpdateSchedule();
            //if( dataAdminWorkSchedule.SelectedRows.Count != -1 )
            //{
            //    DataGridViewRow row = this.dataAdminWorkSchedule.SelectedRows[ 0 ];
            //    MessageBox.Show(row.Cells[ "clmnEmployeeName" ].Value.ToString());
            //}
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
            this.UpdateSchedule();
        }

        /**
         * Method to sort table based on employee's name
         */
        private void btnSort_Click( object sender, EventArgs e )
        {
            // Sort the first column in the data grid view (work schedule)
            // In this case the first column is the first name of employee
            dataAdminWorkSchedule.Sort( dataAdminWorkSchedule.Columns[ 0 ], ListSortDirection.Ascending );
        }

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
            string sql = "SELECT Person.FirstName, Person.LastName, Person.Age, Person.Address, Person.Salary, Person.HoursWorked, Person.HoursAvailable, Role.Name, Department.Name FROM Person " +
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
                Employee employee = new Employee( reader.GetValue( 0 ).ToString(), reader.GetValue( 1 ).ToString(), Convert.ToInt32(reader.GetValue( 2 )), reader.GetValue( 3 ).ToString(), reader.GetValue( 7 ).ToString(), Convert.ToDouble(reader.GetValue( 4 )), Convert.ToInt32(reader.GetValue( 6 )) );
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
    }
}
