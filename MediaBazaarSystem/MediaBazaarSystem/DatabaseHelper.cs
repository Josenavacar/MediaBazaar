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
    public class DatabaseHelper
    {
        private string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
        

        //public void addWorker(String query, String FirstName, String LastName, DateTime birthDate, String address, String email, String password, double salary, 
        //    int hoursAvailable, int roleID, Contract contract, Department department)
        //{
        //    MySqlConnection con = new MySqlConnection(connString);
        //    con.Open();
        //    MySqlCommand cmd = con.CreateCommand();

        //    cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, RoleID, DepartmentID, ContractID) " +
        //        "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @RoleID, @DepartmentID, @ContractID) ";

        //    cmd.Parameters.AddWithValue("@FirstN", FirstName);
        //    cmd.Parameters.AddWithValue("@LastN", LastName);
        //    cmd.Parameters.AddWithValue("@Age", birthDate);
        //    cmd.Parameters.AddWithValue("@Address", address);
        //    cmd.Parameters.AddWithValue("@Email", email);
        //    cmd.Parameters.AddWithValue("@Password", password);
        //    cmd.Parameters.AddWithValue("@Salary", salary);
        //    cmd.Parameters.AddWithValue("@HoursWorked", 0);
        //    cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
        //    cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
        //    cmd.Parameters.AddWithValue("@RoleID", roleID);
        //    cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
        //    cmd.Parameters.AddWithValue("@ContractID", contract);
        //    cmd.ExecuteNonQuery(); //Inserted into database.


        //    MySqlCommand scheduleCmd = con.CreateCommand();

        //    scheduleCmd.CommandText = "INSERT INTO schedule(StartTime, EndTime, WorkDate, PersonID) " +
        //        "VALUES(@StartTime, @EndTime, @WorkDate, LAST_INSERT_ID()) ";

        //    scheduleCmd.Parameters.AddWithValue("@StartTime", DateTime.Today.TimeOfDay);
        //    scheduleCmd.Parameters.AddWithValue("@EndTime", DateTime.Today.TimeOfDay);
        //    scheduleCmd.Parameters.AddWithValue("@WorkDate", DateTime.Today);
        //    scheduleCmd.ExecuteNonQuery(); //Inserted into database.
        //    con.Close();

        //    int age = birthDate.Year - DateTime.Now.Year - 1;
        //    if (birthDate.Month > DateTime.Now.Month)
        //    {
        //        age++;
        //    }
        //    else if (birthDate.Month == DateTime.Now.Month)
        //    {
        //        if (birthDate.Day >= DateTime.Now.Day)
        //        {
        //            age++;
        //        }
        //    }


        //    //Checks for role (1 = Manager, 2 = Employee)
        //    if (roleID == 1)
        //    {
        //        con.Open();
        //        MySqlCommand cmd2 = con.CreateCommand();
        //        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
        //        MySqlDataReader reader = cmd2.ExecuteReader();
        //        int ID = 0;
        //        while (reader.Read())
        //        {
        //            ID = (int)reader.GetValue(0);
        //        }
        //        reader.Close();
        //        con.Close();

        //        Manager newManager = new Manager(ID, FirstName, LastName, age, birthDate, address, role, salary, hoursAvailable, email, contract); //Adds the manager to the list.
        //        department.AddManager(newManager);
        //        MessageBox.Show("Manager successfully added.");
        //    }
        //    else if (roleID == 2)
        //    {
        //        con.Open();
        //        MySqlCommand cmd2 = con.CreateCommand();
        //        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
        //        MySqlDataReader reader = cmd2.ExecuteReader();
        //        int ID = 0;
        //        while (reader.Read())
        //        {
        //            ID = (int)reader.GetValue(0);
        //        }
        //        reader.Close();
        //        con.Close();

        //        Employee newEmployee = new Employee(ID, FirstName, LastName, age, birthDate, address, role, salary, hoursAvailable, email, contract); //Adds employee to the list.
        //        department.AddEmployee(newEmployee);
        //        MessageBox.Show("Employee successfully added.");
        //    }
        //}

        public void addStaff( Staff man, Department department )
        {
            MySqlConnection conn = new MySqlConnection(connString);

            int age = man.dateOfBirth.Year - DateTime.Now.Year - 1;
            if (man.dateOfBirth.Month > DateTime.Now.Month)
            {
                age++;
            }
            else if (man.dateOfBirth.Month == DateTime.Now.Month)
            {
                if (man.dateOfBirth.Day >= DateTime.Now.Day)
                {
                    age++;
                }
            }

            String password = Cryptography.Encrypt("temp");
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, RoleID, DepartmentID, ContractID) " +
                "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @RoleID, @DepartmentID, @ContractID) ";

            cmd.Parameters.AddWithValue("@FirstN", man.FirstName);
            cmd.Parameters.AddWithValue("@LastN", man.LastName);
            cmd.Parameters.AddWithValue("@Age", man.dateOfBirth);
            cmd.Parameters.AddWithValue("@Address", man.Address);
            cmd.Parameters.AddWithValue("@Email", man.Email);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Salary", man.Salary);
            cmd.Parameters.AddWithValue("@HoursWorked", 0);
            cmd.Parameters.AddWithValue("@HoursAvailable", man.HoursAvailable);
            cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
            cmd.Parameters.AddWithValue("@RoleID", 1);
            cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
            cmd.Parameters.AddWithValue("@ContractID", man.Contract);
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

            man.dbID = ID;
            
            department.AddManager(man);
        }

    }
}
