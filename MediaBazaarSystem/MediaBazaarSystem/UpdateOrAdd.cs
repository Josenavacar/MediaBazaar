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
    public partial class UpdateOrAdd : Form
    {
        Department department;
        Employee employee;
        Manager manager;

        //This form is used by 3 different methods, Add employee, add manager and update employee/manager, for that reason the constructor is overloaded,
        //if a department alone is given, then the method will add a new person, if a department + a manager is given, a manager is to be updated, and if
        //a department and an employee are given, an employee is to be updated.

        /**
         * Constructor
         */
        public UpdateOrAdd(Department dep)
        {
            //Add a new person.
            InitializeComponent();
            this.department = dep;
            this.employee = null;
            this.manager = null;

            btnAddStaff.Text = "Add";
            this.Text = "Add new person";
        }

        /**
         * Method to update manager
         */
        public UpdateOrAdd(Department dep, Manager man)
        {
            //Update manager
            InitializeComponent();
            this.department = dep;
            this.employee = null;
            this.manager = man;
            
            txtBoxFirstName.Text = manager.FirstName;
            txtBoxLastName.Text = manager.LastName;
            numAge.Value = manager.Age;
            tbAddress.Text = manager.Address;
            comBoxPosition.SelectedItem = manager.Role;
            txtBoxSalary.Text = manager.Salary.ToString();
            txtBoxHoursAvailable.Text = manager.HoursAvailable.ToString();
            txtBoxEmail.Text = manager.Email.ToString();

            btnAddStaff.Text = "Edit";
            this.Text = "Update " + manager.FirstName + " " + manager.LastName;
        }

        /**
         * Method to update employee
         */
        public UpdateOrAdd(Department dep, Employee emp)
        {
            //Update employee
            InitializeComponent();
            this.department = dep;
            this.employee = emp;
            this.manager = null;
            
            txtBoxFirstName.Text = emp.FirstName;
            txtBoxLastName.Text = emp.LastName;
            numAge.Value = emp.Age;
            tbAddress.Text = emp.Address;
            comBoxPosition.SelectedItem = emp.Role;
            txtBoxSalary.Text = emp.Salary.ToString();
            txtBoxHoursAvailable.Text = emp.HoursAvailable.ToString();
            txtBoxEmail.Text = emp.Email.ToString();

            btnAddStaff.Text = "Edit";
            this.Text = "Update " + employee.FirstName + " " + employee.LastName;
        }
        
        /**
         * Method to add user to database
         */
        private void btnAddStaff_Click( object sender, EventArgs e )
        {
            //Avoids employees or managers with same name and surname.
            if( department.GetEmployee( txtBoxFirstName.Text, txtBoxLastName.Text ) != null && employee == null && manager == null )
            {
                MessageBox.Show( "Employee already registered." );

            }
            else
            {
                //MySQL
                string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
                MySqlConnection conn = new MySqlConnection( connString );

                int roleID = 0; //This variable will store the role ID to be stored into the database.
                String FirstName = txtBoxFirstName.Text.ToString(); //First name
                String LastName = txtBoxLastName.Text.ToString(); //Last name
                int age = Convert.ToInt32( numAge.Value ); //Age
                String address = tbAddress.Text.ToString(); //Address
                String role = comBoxPosition.SelectedItem.ToString(); //Role (as a string instead of an ID for ease of use and clarity in a list of C#)
                double salary = Convert.ToDouble( txtBoxSalary.Text ); //Salary
                int hoursAvailable = Convert.ToInt32( txtBoxHoursAvailable.Text ); //Hours available
                String email = txtBoxEmail.Text.ToString(); //Email

                //Converts the string role into the ID.
                if( role == "Manager" )
                {
                    roleID = 1;
                }
                else if( role == "Employee" )
                {
                    roleID = 2;
                }

                if( employee == null && manager == null ) //If only a department was given, we will add a new person.
                {
                    String password = Cryptography.Encrypt( "temp" );
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, RoleID, DepartmentID) " +
                        "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @RoleID, @DepartmentID) ";

                    cmd.Parameters.AddWithValue( "@FirstN", FirstName );
                    cmd.Parameters.AddWithValue( "@LastN", LastName );
                    cmd.Parameters.AddWithValue( "@Age", age );
                    cmd.Parameters.AddWithValue( "@Address", address );
                    cmd.Parameters.AddWithValue( "@Email", email );
                    cmd.Parameters.AddWithValue( "@Password", password );
                    cmd.Parameters.AddWithValue( "@Salary", salary );
                    cmd.Parameters.AddWithValue( "@HoursWorked", 0 );
                    cmd.Parameters.AddWithValue( "@HoursAvailable", hoursAvailable );
                    cmd.Parameters.AddWithValue( "@IsAvailable", "Yes" );
                    cmd.Parameters.AddWithValue( "@RoleID", roleID );
                    cmd.Parameters.AddWithValue( "@DepartmentID", department.DepartmentID );
                    cmd.ExecuteNonQuery(); //Inserted into database.


                    MySqlCommand scheduleCmd = conn.CreateCommand();

                    scheduleCmd.CommandText = "INSERT INTO schedule(StartTime, EndTime, WorkDate, PersonID) " +
                        "VALUES(@StartTime, @EndTime, @WorkDate, LAST_INSERT_ID()) ";

                    scheduleCmd.Parameters.AddWithValue( "@StartTime", DateTime.Today.TimeOfDay );
                    scheduleCmd.Parameters.AddWithValue( "@EndTime", DateTime.Today.TimeOfDay );
                    scheduleCmd.Parameters.AddWithValue( "@WorkDate", DateTime.Today );
                    scheduleCmd.ExecuteNonQuery(); //Inserted into database.
                    conn.Close();

                    //Checks for role (1 = Manager, 2 = Employee)
                    if( roleID == 1 )
                    {
                        conn.Open();
                        MySqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        int ID = 0;
                        while( reader.Read() )
                        {
                            ID = ( int ) reader.GetValue( 0 );
                        }
                        reader.Close();
                        conn.Close();
                        Manager newManager = new Manager( ID, FirstName, LastName, age, address, role, salary, hoursAvailable, email ); //Adds the manager to the list.
                        department.AddManager( newManager );
                        MessageBox.Show( "Manager successfully added" );
                    }

                    else if( roleID == 2 )
                    {
                        conn.Open();
                        MySqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        int ID = 0;
                        while( reader.Read() )
                        {
                            ID = ( int ) reader.GetValue( 0 );
                        }
                        reader.Close();
                        conn.Close();
                        Employee newEmployee = new Employee( ID, FirstName, LastName, age, address, role, salary, hoursAvailable, email ); //Adds employee to the list.
                        department.AddEmployee( newEmployee );
                        MessageBox.Show( "Employee successfully added" );
                    }
                }

                else
                {
                    //Edits existing person.
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "UPDATE person SET Firstname = @FirstN,  Lastname = @LastN, Age = @Age, Address = @Address, Email = @Email, Salary = @Salary," +
                        "HoursAvailable = @HoursAvailable, IsAvailable = @IsAvailable, RoleID = @RoleID, DepartmentID = @DepartmentID WHERE Id = @PersonID";

                    cmd.Parameters.AddWithValue( "@FirstN", FirstName );
                    cmd.Parameters.AddWithValue( "@LastN", LastName );
                    cmd.Parameters.AddWithValue( "@Age", age );
                    cmd.Parameters.AddWithValue( "@Address", address );
                    cmd.Parameters.AddWithValue( "@Email", email );
                    cmd.Parameters.AddWithValue( "@Salary", salary );
                    cmd.Parameters.AddWithValue( "@HoursAvailable", hoursAvailable );
                    cmd.Parameters.AddWithValue( "@IsAvailable", "Yes" );
                    cmd.Parameters.AddWithValue( "@RoleID", roleID );
                    cmd.Parameters.AddWithValue( "@DepartmentID", department.DepartmentID );
                    cmd.Parameters.AddWithValue( "@PersonID", employee.dbID );
                    cmd.ExecuteNonQuery(); //Database edit.
                    conn.Close();
                    employee.EditEmployee( FirstName, LastName, age, address, role, salary, hoursAvailable, email ); //List edit (local).
                    MessageBox.Show( "Employee successfully edited" );
                    conn.Close();
                }
                this.Hide();
            }
        }
    }
}
