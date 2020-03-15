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
        Employee employee;
        Department dep;
        /**
         * The Constructor
         */
        public EmployeeSystem(Department dep, Employee emp)
        {
            InitializeComponent();
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
                String startTime =  reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );
                 
                DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = reader.GetValue( 4 ).ToString(); // Date
                dataEmpWorkSchedule.Rows.Add( row );
            }

            this.employee = emp;
            this.dep = dep;
            refreshProfile();
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
            this.dataEmpWorkSchedule.Rows.Clear();
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
                    DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                    dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                    row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = date.ToString( "MM/dd/yyyy" ); // Date
                    dataEmpWorkSchedule.Rows.Add( row );
                }
            }
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            if (checkProfileChange())
            {
                //Updates employee in database.
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
                cmd.Parameters.AddWithValue("@Id", employee.dbID);

                cmd.ExecuteNonQuery();

                //Updates employee in list.
                employee.EditEmployee(txtBoxFirstName.Text, txtBoxLastName.Text, Convert.ToInt32(txtBoxAge.Text), txtBoxAddress.Text, employee.Role, employee.Salary, employee.HoursAvailable, txtBoxEmail.Text);

                //Updates profile.
                refreshProfile();

                MessageBox.Show("Profile Updated Successfully");
            }
            else
            {
                MessageBox.Show("No changes made");
            }
        }

        private void refreshProfile() //Adds all employee's data into the listbox and textboxes.
        {
            lbEmployeeInfo.Items.Clear();
            lbEmployeeInfo.Items.Add("Name: " + employee.FirstName);
            lbEmployeeInfo.Items.Add("Surname: " + employee.LastName);
            lbEmployeeInfo.Items.Add("Age: " + employee.Age);
            lbEmployeeInfo.Items.Add("Address: " + employee.Address);
            lbEmployeeInfo.Items.Add("Email: " + employee.Email);
            txtBoxFirstName.Text = employee.FirstName;
            txtBoxLastName.Text = employee.LastName;
            txtBoxAge.Text = employee.Age.ToString();
            txtBoxAddress.Text = employee.Address;
            txtBoxEmail.Text = employee.Email;
        }
        
        private bool checkProfileChange()
        {
            if (txtBoxFirstName.Text == employee.FirstName && txtBoxLastName.Text == employee.LastName && Convert.ToInt32(txtBoxAge.Text) == employee.Age && txtBoxAddress.Text == employee.Address && txtBoxEmail.Text == employee.Email)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            //On click, opens a form to change the currently logged in user's password.
            ChangePassword pwd = new ChangePassword(null, employee);
            pwd.StartPosition = FormStartPosition.CenterParent;
            pwd.ShowDialog(this);
        }
    }
}
