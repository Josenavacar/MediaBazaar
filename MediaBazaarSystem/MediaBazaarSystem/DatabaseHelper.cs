﻿using System;
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
    public class DatabaseHelper
    {
        private String connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";

        public void StaffLogin(String email, String password)
        {
            Contract contract;

            String sql = "SELECT person.Id, person.Firstname, person.Lastname, person.Age, person.Address, person.Email, person.Password, person.Salary, " +
                            "person.HoursWorked, person.HoursAvailable, person.IsAvailable, person.RoleID, department.Name, person.DepartmentID, person.ContractID " +
                         "FROM person JOIN department ON Person.DepartmentID = Department.id " +
                         "WHERE email = @email";

            MySqlConnection conn = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("email", email);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    // Variables 
                    int ID = (int)reader.GetValue(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    DateTime birthDateWithTime = (DateTime)reader.GetValue(3);
                    DateTime birthDate = birthDateWithTime.Date;
                    String address = reader.GetString(4);
                    String toDecryptPassword = reader.GetString(6);
                    double salary = reader.GetDouble(7);
                    int hoursavailable = (int)reader.GetValue(9);
                    int role = (int)reader.GetValue(11);

                    //Calculate age
                    int age = DateTime.Now.Year - birthDate.Year - 1;

                    if (birthDate.Month > DateTime.Now.Month)
                    {
                        age++;
                    }
                    else if (birthDate.Month == DateTime.Now.Month)
                    {
                        if (birthDate.Day >= DateTime.Now.Day)
                        {
                            age++;
                        }
                    }

                    //Department
                    String depName = reader.GetString(12);
                    int depID = (int)reader.GetValue(13);
                    Department department = new Department(depName, depID);

                    // Get the contract
                    int dbContract = (int)reader.GetValue(14);
                    if (dbContract == 1)
                    {
                        contract = Contract.FullTime;
                    }
                    else
                    {
                        contract = Contract.PartTime;
                    }

                    // Decrypt password and check if password is equal to the password user filled in
                    if (Cryptography.Decrypt(toDecryptPassword) == password)
                    {
                        if (role == 1) // Manager
                        {
                            Manager manager = new Manager(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                            AdministrationSystem administrationSystem = new AdministrationSystem(department, manager);
                            administrationSystem.Show();
                        }
                        else if (role == 2) // Employee
                        {
                            Employee employee = new Employee(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                            EmployeeSystem employeeSystem = new EmployeeSystem(department, employee);
                            employeeSystem.Show();
                        }
                    }
                    else if ((Cryptography.Decrypt(toDecryptPassword) != password) || (password == null))
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
                conn.Close();
            }
        }
    


    public void addStaffToDB( Staff staff, int departmentID )
        {
            if(staff != null)
            {
                MySqlConnection conn = new MySqlConnection(connString);

                int age = staff.dateOfBirth.Year - DateTime.Now.Year - 1;
                if (staff.dateOfBirth.Month > DateTime.Now.Month)
                {
                    age++;
                }
                else if (staff.dateOfBirth.Month == DateTime.Now.Month)
                {
                    if (staff.dateOfBirth.Day >= DateTime.Now.Day)
                    {
                        age++;
                    }
                }
                int roleID = (int)staff.Role;

                String password = Cryptography.Encrypt("temp");
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, RoleID, DepartmentID, ContractID) " +
                    "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @RoleID, @DepartmentID, @ContractID) ";

                cmd.Parameters.AddWithValue("@FirstN", staff.FirstName);
                cmd.Parameters.AddWithValue("@LastN", staff.LastName);
                cmd.Parameters.AddWithValue("@Age", staff.dateOfBirth);
                cmd.Parameters.AddWithValue("@Address", staff.Address);
                cmd.Parameters.AddWithValue("@Email", staff.Email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Salary", staff.Salary);
                cmd.Parameters.AddWithValue("@HoursWorked", 0);
                cmd.Parameters.AddWithValue("@HoursAvailable", staff.HoursAvailable);
                cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
                cmd.Parameters.AddWithValue("@ContractID", staff.Contract);
                cmd.ExecuteNonQuery(); //Inserted into database.

                MySqlCommand scheduleCmd = conn.CreateCommand();

                scheduleCmd.CommandText = "INSERT INTO schedule(StartTime, EndTime, WorkDate, PersonID) " +
                    "VALUES(@StartTime, @EndTime, @WorkDate, LAST_INSERT_ID()) ";

                scheduleCmd.Parameters.AddWithValue("@StartTime", DateTime.Today.TimeOfDay);
                scheduleCmd.Parameters.AddWithValue("@EndTime", DateTime.Today.TimeOfDay);
                scheduleCmd.Parameters.AddWithValue("@WorkDate", DateTime.Today);
                scheduleCmd.ExecuteNonQuery(); //Inserted into database.

                MySqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
                MySqlDataReader reader = cmd2.ExecuteReader();
                int ID = 0;
                while (reader.Read())
                {
                    ID = (int)reader.GetValue(0);
                }
                reader.Close();
                conn.Close();

                staff.dbID = ID;
            }
        }

        public List<Staff> getStaffFromDB(Department dep)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT * FROM person JOIN role ON person.RoleID = role.Id WHERE DepartmentID = @DepartmentID";

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DepartmentID", dep.DepartmentID);
            MySqlDataReader reader = cmd.ExecuteReader();

            //List<Staff> result = new List<Staff>();
            while(reader.Read())
            {
                int ID = (int)reader.GetValue(0);
                String firstName = reader.GetString(1);
                String lastName = reader.GetString(2);
                DateTime birthDate = (DateTime)reader.GetValue(3);
                String address = reader.GetString(4);
                String email = reader.GetString(5);
                double salary = reader.GetDouble(7);
                int hoursavailable = (int)reader.GetValue(9);
                int dbContract = (int)reader.GetValue(14); //13
                String role = reader.GetString(16); //16

                Contract contract;
                if (dbContract == 1)
                {
                    contract = Contract.FullTime;
                }
                else
                {
                    contract = Contract.PartTime;
                }

                if(role == "Manager" || role == "Stock Manager")
                {
                    Manager man = new Manager(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                    if (dep.GetStaffMember(man.FirstName, man.LastName) == null)
                    {
                        dep.AddStaffMember(man);
                    }
                }
                else if(role == "Employee")
                {
                    Employee emp = new Employee(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                    if (dep.GetStaffMember(emp.FirstName, emp.LastName) == null)
                    {
                        dep.AddStaffMember(emp);
                    }
                }
            }
            reader.Close();
            conn.Close();

            return dep.GetStaff();
        }

        public int getStaffID()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            String sql = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();

            int ID = 0;
            while (reader.Read())
            {
                ID = (int)reader.GetValue(0);
            }

            return ID;
        }

        /**
         * Method to user update profile
         */
        public void updateProfile(Staff memberToChange, String FirstName, String LastName, DateTime birthDate, String address, String email)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            // Open connection
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE person SET Firstname = @Firstname, Lastname = @Lastname, Age = @Age, Address = @Address, Email = @Email WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Firstname", FirstName);
            cmd.Parameters.AddWithValue("@Lastname", LastName);
            cmd.Parameters.AddWithValue("@Age", birthDate);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Id", memberToChange.dbID);

            cmd.ExecuteNonQuery();

            memberToChange.editStaffMember(FirstName, LastName, birthDate , address, email);
        }

        public void managerUpdateProfile(Staff memberToChange, String FirstName, String LastName, DateTime birthDate, String address, String email, double salary, int hoursAvailable, int roleID, int DepartmentID, Contract contract)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            // Open connection
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "UPDATE person SET Firstname = @FirstN,  Lastname = @LastN, Age = @Age, Address = @Address, Email = @Email, Salary = @Salary," +
                            "HoursAvailable = @HoursAvailable, IsAvailable = @IsAvailable, RoleID = @RoleID, DepartmentID = @DepartmentID, ContractID = @ContractID WHERE Id = @PersonID";

            cmd.Parameters.AddWithValue("@PersonID", memberToChange.dbID);
            cmd.Parameters.AddWithValue("@FirstN", FirstName);
            cmd.Parameters.AddWithValue("@LastN", LastName);
            cmd.Parameters.AddWithValue("@Age", birthDate);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
            cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
            //cmd.Parameters.AddWithValue("@Passcode", passcode);
            cmd.Parameters.AddWithValue("@RoleID", roleID);
            cmd.Parameters.AddWithValue("@DepartmentID", DepartmentID);
            cmd.Parameters.AddWithValue("@ContractID", contract);

            cmd.ExecuteNonQuery();

            memberToChange.editStaffMember(FirstName, LastName, birthDate, address, email);
        }

        public void AddEmployeeWorkDate( Staff employee, DateTime workDate )
        {
            if( employee != null )
            {
                MySqlConnection conn = new MySqlConnection( connString );
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO available_emp_shifts(Available_Date, PersonID) VALUES(@Available_Date, @EmployeeID)";
                cmd.Parameters.AddWithValue( "@Available_Date", workDate );
                cmd.Parameters.AddWithValue( "@EmployeeID", employee.dbID );
                cmd.ExecuteNonQuery();

                conn.Close();
            }
        }

        /**
         * Method to get all available work dates from an Employee
         * This method is using the employee ID
         */
        public MySqlDataReader getEmpAvailableWorkDates(int employeeID)
        {
            string sql = 
                "SELECT * " +
                "FROM available_emp_shifts " +
                "INNER JOIN person ON available_emp_shifts.PersonID = person.Id " +
                "WHERE PersonID = @EmployeeID";

            MySqlConnection connection = new MySqlConnection( connString );
            connection.Open();

            MySqlCommand cmd = new MySqlCommand( sql, connection );
            cmd.Parameters.AddWithValue( "@EmployeeID", employeeID );
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public MySqlDataReader getShift()
        {
            string sql = "SELECT Person.Id, Person.FirstName, Person.LastName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate, Department.Name FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID " +
                "INNER JOIN Department ON Person.DepartmentID = Department.Id";

            MySqlConnection connection = new MySqlConnection(connString);
            // Start mysql objects
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }

        public MySqlDataReader updateSchedules()
        {
            string sql = "SELECT Person.Id, Person.FirstName, Person.LastName, Role.Name, Schedule.StartTime, Schedule.EndTime, Schedule.WorkDate, Department.Name, Schedule.Id FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID " +
                "INNER JOIN Department ON Person.DepartmentID = Department.Id";

            // Start mysql objects
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public void deleteStaffMember(int ID)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM schedule WHERE PersonId = @PersonId";
            cmd.Parameters.AddWithValue("@PersonId", ID);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", ID);
            cmd.ExecuteNonQuery();
        }

        public MySqlDataReader getSchedules()
        {
            // SQL Query
            string sql = "SELECT FirstName, LastName, Name, StartTime, EndTime, WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";

            // Start mysql objects
            MySqlConnection connection = new MySqlConnection(connString);
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            // Open connection
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
    }
}
