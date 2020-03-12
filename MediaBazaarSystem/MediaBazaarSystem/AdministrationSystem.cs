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
        public static bool ensure; //Used for double checking when deleting from the database.
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

            //Schedule related
            //string sql = "SELECT FirstName, Name, StartTime, EndTime, WorkDate FROM Person " +
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
            reader.Close();

            //Employee related
            String sql2 = "SELECT * FROM person WHERE DepartmentID = @DepartmentID";
            MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
            cmd2.Parameters.Add("DepartmentID", MySqlDbType.VarChar).Value = department.DepartmentID;

            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                int role = (int)reader.GetValue(11);
                if ( role == 1 ) //Managers
                {
                    //Retreive all the data from the database
                    int ID = (int)reader.GetValue(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    int age = (int)reader.GetValue(3);
                    String address = reader.GetString(4);
                    String email = reader.GetString(5);
                    String charge = "Manager";
                    double salary = reader.GetDouble(7);
                    int hoursavailable = (int)reader.GetValue(9);

                    //Add the manager to the list.
                    Manager man = new Manager(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
                    department.AddManager(man);

                    idManage = ID;
                }

                else if(role == 2) //Employees
                {
                    //Retreive all the data from the database
                    int ID = (int)reader.GetValue(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    int age = (int)reader.GetValue(3);
                    String address = reader.GetString(4);
                    String email = reader.GetString(5);
                    String charge = "Employee";
                    double salary = reader.GetDouble(7);
                    int hoursavailable = (int)reader.GetValue(9);

                    //Add the employee to the list.
                    Employee emp = new Employee(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
                    department.AddEmployee(emp);

                    idManage = ID;
                }
            }
            reader.Close();
            connection.Clone();

            reader.Close();

            //            //Employee related
            //            String sql2 = "SELECT * FROM person WHERE DepartmentID = @DepartmentID";
            //            MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
            //            cmd2.Parameters.Add("DepartmentID", MySqlDbType.VarChar).Value = department.DepartmentID;

            //            reader = cmd2.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                int role = (int)reader.GetValue(11);
            //                if ( role == 1 )
            //                {
            //                    int ID = (int)reader.GetValue(0);
            //                    String firstName = reader.GetString(1);
            //                    String lastName = reader.GetString(2);
            //                    int age = (int)reader.GetValue(3);
            //                    String address = reader.GetString(4);
            //                    String email = reader.GetString(5);
            //                    String charge = "Manager";
            //                    double salary = reader.GetDouble(7);
            //                    int hoursavailable = (int)reader.GetValue(9);

            //                    Manager man = new Manager(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
            //                    department.AddManager(man);

            //                    idManage = ID;
            //                }

            //                else if(role == 2)
            //                {
            //                    int ID = (int)reader.GetValue(0);
            //                    String firstName = reader.GetString(1);
            //                    String lastName = reader.GetString(2);
            //                    int age = (int)reader.GetValue(3);
            //                    String address = reader.GetString(4);
            //                    String email = reader.GetString(5);
            //                    String charge = "Employee";
            //                    double salary = reader.GetDouble(7);
            //                    int hoursavailable = (int)reader.GetValue(9);

            //                    Employee emp = new Employee(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
            //                    department.AddEmployee(emp);

            //                    idManage = ID;
            //                }
            //            }
            //            reader.Close();


            // Disable timer
            updateTimer.Enabled = false;
        }

        private void GetStatistics()
        {

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            UpdateOrAdd form1 = new UpdateOrAdd(department);
            form1.Show();
        }

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

        private Employee SearchEmp() //Returns an employee selected on the listbox or null if it doesn't exist.
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

        private Manager SearchMan() //Returns a manager selected on the listbox or null if it doesn't exist.
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

        private void Refresh_Tick(object sender, EventArgs e)
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;

            lbEmployees.Items.Clear(); //Empties empoloyee listbox
            List<Employee> listEmp = department.GetEmployees(); 
            foreach (Employee emp in listEmp) //Refills employee listbox
            {
                String outpEmp = emp.LastName + ", " + emp.FirstName;
                lbEmployees.Items.Add(outpEmp);
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if (lbEmployees.Items.Count > 0)
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
                lbManagers.Items.Add(outpMan);
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if (lbManagers.Items.Count > 0)
                {
                    lbManagers.SelectedIndex = indexMan;
                }
            }
            catch(Exception ex) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbManagers.SelectedItem = null;
            }
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

        private void lbManagers_Click(object sender, EventArgs e)
        {
            lbEmployees.SelectedItem = null;
        }

        private void lbEmployees_Click(object sender, EventArgs e)
        {
            lbManagers.SelectedItem = null;
        }

        private void btnChangePwd_Click( object sender, EventArgs e )
        {

            //On click, opens a form to change the currently logged in user's password.
            ChangePassword pwd = new ChangePassword(manager, null);
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
