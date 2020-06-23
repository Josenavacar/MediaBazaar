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
    public partial class LoginForm : Form
    {
        DatabaseHelper dataBase;

        /**
         * Constructor
         */
        public LoginForm()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = Convert.ToChar("*");
        }

        /**
         * Method to login based on valid credentials
         */
        private void btnLogin_Click( object sender, EventArgs e )
        {
            Contract contract;
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;

            DatabaseHelper dataBase = new DatabaseHelper();
            
            MySqlDataReader reader = dataBase.StaffLogin( email, password );
            try
            {
                if( reader.Read() )
                {
                    // Variables 
                    int ID = ( int ) reader.GetValue( 0 );
                    String firstName = reader.GetString( 1 );
                    String lastName = reader.GetString( 2 );
                    DateTime birthDateWithTime = ( DateTime ) reader.GetValue( 3 );
                    DateTime birthDate = birthDateWithTime.Date;
                    String address = reader.GetString( 4 );
                    String toDecryptPassword = reader.GetString( 6 );
                    double salary = reader.GetDouble( 7 );
                    int hoursavailable = ( int ) reader.GetValue( 9 );
                    int role = ( int ) reader.GetValue( 11 );

                    //Calculate age
                    int age = DateTime.Now.Year - birthDate.Year - 1;

                    if( birthDate.Month > DateTime.Now.Month )
                    {
                        age++;
                    }
                    else if( birthDate.Month == DateTime.Now.Month )
                    {
                        if( birthDate.Day >= DateTime.Now.Day )
                        {
                            age++;
                        }
                    }

                    //Department
                    String depName = reader.GetString( 12 );
                    int depID = ( int ) reader.GetValue( 13 );
                    Department department = new Department( depName, depID );

                    // Get the contract
                    int dbContract = ( int ) reader.GetValue( 14 );
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
                        if( role == 1 ) // Manager
                        {
                            Manager manager = new Manager( ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract );
                            AdministrationSystem administrationSystem = new AdministrationSystem( department, manager );
                            administrationSystem.Show();
                        }
                        else if( role == 2 ) // Employee
                        {
                            Employee employee = new Employee( ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract );
                            EmployeeSystem employeeSystem = new EmployeeSystem( department, employee );
                            employeeSystem.Show();
                        }
                        this.Hide();
                    }
                    else if( ( Cryptography.Decrypt( toDecryptPassword ) != password ) || ( password == null ) )
                    {
                        MessageBox.Show( "Email or password is incorrect. Please try again.");
                    }
                }
                else
                {
                    MessageBox.Show( "Unable to connect to the database. Please contact your administrator." );
                }
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show( ex.Message );
            }

        }
    }
}
