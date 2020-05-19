using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MediaBazaarSystem
{
    public class DBHandler
    {
        String email;
        String password;

        public MySqlConnection ConnectToDatabase()
        {
            // Connect to DB
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection connection;
            // Start mysql objects
            return  connection = new MySqlConnection( connectionString );
        }

        public void StaffLogin(String email, String pasword)
        {
            this.email = email;
            this.password = pasword;
            String toDecryptPassword = "";
            String depName;
            int depID;
            int role;
            int dbContract;
            Contract contract;

            String sql = "SELECT person.Id, person.Firstname, person.Lastname, person.Age, person.Address, person.Email, person.Password, person.Salary, " +
                            "person.HoursWorked, person.HoursAvailable, person.IsAvailable, person.RoleID, department.Name, person.DepartmentID, person.ContractID " +
                         "FROM person JOIN department ON Person.DepartmentID = Department.id " +
                         "WHERE email = @email";

            MySqlConnection connection = this.ConnectToDatabase();
            MySqlCommand cmd = new MySqlCommand( sql, connection);
            cmd.Parameters.Add( "email", MySqlDbType.VarChar ).Value = email;
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

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
                    toDecryptPassword = reader.GetString( 6 );
                    String charge = "Manager";
                    double salary = reader.GetDouble( 7 );
                    int hoursavailable = ( int ) reader.GetValue( 9 );
                    role = ( int ) reader.GetValue( 11 );

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
                    depName = reader.GetString( 12 );
                    depID = ( int ) reader.GetValue( 13 );
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
                        if( role == 1 ) // Manager
                        {
                            Manager manager = new Manager( ID, firstName, lastName, age, birthDate, address, charge, salary, hoursavailable, email, contract );
                            AdministrationSystem administrationSystem = new AdministrationSystem( department, manager );
                            administrationSystem.Show();
                        }
                        else if( role == 2 ) // Employee
                        {
                            Employee employee = new Employee( ID, firstName, lastName, age, birthDate, address, charge, salary, hoursavailable, email, contract );
                            EmployeeSystem employeeSystem = new EmployeeSystem( department, employee );
                            employeeSystem.Show();
                        }
                    }
                    else if( ( Cryptography.Decrypt( toDecryptPassword ) != password ) || ( password == null ) )
                    {
                        //throw new ArgumentException( "Email or password is incorrect. Please try again." );
                    }
                }
                else
                {
                    //throw new ArgumentException( "Unable to connect to the database. Please contact your administrator." );
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
