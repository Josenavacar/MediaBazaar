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
    public partial class formLogin : Form
    {
        /**
         * Constructor
         */
        public formLogin()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = Convert.ToChar("*");
        }

        /**
         * Method to login based on valid credentials
         */
        private void btnLogin_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;
            String toDecryptPassword = "";
            String depName;
            int depID;
            int role;
            int dbContract;
            Contract contract;

            using( MySqlConnection connection = new MySqlConnection( @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;" ) )
            {
                // SQL query to get the user based on login credentials
                MySqlCommand cmd = new MySqlCommand("SELECT person.Id, person.Firstname, person.Lastname, person.Age, person.Address, person.Email, person.Password, person.Salary, " +
                    "person.HoursWorked, person.HoursAvailable, person.IsAvailable, person.RoleID, department.Name, person.DepartmentID, person.ContractID FROM person JOIN department ON Person.DepartmentID = Department.id " +
                    "WHERE email = @email", connection ); 
                cmd.Parameters.Add("email", MySqlDbType.VarChar).Value = email;

                // Open connection
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );

                try
                {
                    // If the data is available then log user in and open navigation form
                    // else show error message
                    if( reader.Read() )
                    {
                        // The number is based on the column... 
                        //E.g. password is column 6 and email is column 5
                        toDecryptPassword = reader.GetString( 6 ) ;
                        role = (int)reader.GetValue( 11 );

                        //Department
                        depName = reader.GetString( 12 );
                        depID = (int)reader.GetValue(13);
                        Department department = new Department( depName, depID );

                        // Get the contract
                        dbContract = ( int ) reader.GetValue( 14 );
                        if( dbContract == 1 )
                        {
                            contract = Contract.FullTime;
                        }
                        else
                        {
                            contract = Contract.PartTime;
                        }

                        // Decrypt password and check if password is equal to the password user filled in
                        if( Cryptography.Decrypt( toDecryptPassword ) == password )
                        {
                            if(role == 1) // Manager
                            {
                                int ID = (int)reader.GetValue(0);
                                String firstName = reader.GetString(1);
                                String lastName = reader.GetString(2);
                                int age = (int)reader.GetValue(3);
                                String address = reader.GetString(4);
                                String charge = "Manager";
                                double salary = reader.GetDouble(7);
                                int hoursavailable = (int)reader.GetValue(9);

                                Manager manager = new Manager( ID, firstName, lastName, age, address, charge, salary, hoursavailable, email, contract );
                                AdministrationSystem administrationSystem = new AdministrationSystem( department, manager );

                                administrationSystem.Show();
                                this.Hide();
                            }
                            else if(role == 2) // Employee
                            {
                                int ID = (int)reader.GetValue(0);
                                String firstName = reader.GetString(1);
                                String lastName = reader.GetString(2);
                                int age = (int)reader.GetValue(3);
                                String address = reader.GetString(4);
                                String charge = "Manager";
                                double salary = reader.GetDouble(7);
                                int hoursavailable = (int)reader.GetValue(9);

                                Employee employee = new Employee(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email, contract);
                                EmployeeSystem employeeSystem = new EmployeeSystem(department, employee);

                                employeeSystem.Show();
                                this.Hide();
                            }
                        }
                        else if( (Cryptography.Decrypt( toDecryptPassword ) != password) || (password == null) )
                        {
                            MessageBox.Show( "Email or password is incorrect. Please try again." );
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to connect to the database. Please contact your administrator.");
                    }
                }
                catch( FormatException ex )
                {
                    MessageBox.Show( ex.ToString() );
                }
                connection.Close();
            }
        }
    }
}
