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
using System.Windows.Forms.DataVisualization.Charting;

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
    


    public void addStaffToDB( Staff man, int departmentID )
        {
            if(man != null)
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
                int roleID = (int)man.Role;

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
                cmd.Parameters.AddWithValue("@RoleID", roleID);
                cmd.Parameters.AddWithValue("@DepartmentID", departmentID);
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

            List<Staff> result = new List<Staff>();
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
                int dbContract = (int)reader.GetValue(13);
                String role = reader.GetString(16);

                Contract contract;
                if (dbContract == 1)
                {
                    contract = Contract.FullTime;
                }
                else
                {
                    contract = Contract.PartTime;
                }

                if(role == "Manager" || role == "StockManager")
                {
                    Manager man = new Manager(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                    dep.AddStaffMember(man);
                }
                else if(role == "Employee")
                {
                    Employee emp = new Employee(ID, firstName, lastName, birthDate, address, salary, hoursavailable, email, contract);
                    dep.AddStaffMember(emp);
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


        //////////////////////////////////////////////////////////////////W.I.P.////////////////////////////////////////////////////////////////////////////////////
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


        //public void getWorkSchedule(String sql) 
        //{
        //    MySqlConnection conn = new MySqlConnection(connString);

        //    MySqlCommand cmd = new MySqlCommand(sql, conn);
        //    // Open connection
        //    conn.Open();
        //    MySqlDataReader reader = cmd.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        // Get the data
        //        while (reader.Read())
        //        {
        //            String firstName = reader.GetValue(1).ToString();
        //            String lastName = reader.GetValue(2).ToString();
        //            String role = reader.GetValue(3).ToString();
        //            String startTime = reader.GetValue(4).ToString();
        //            String endTime = reader.GetValue(5).ToString();
        //            String workDate = reader.GetValue(6).ToString();
        //            DateTime workStartTime = Convert.ToDateTime(startTime);
        //            DateTime workEndTime = Convert.ToDateTime(endTime);
        //            DateTime convertedWorkDate = Convert.ToDateTime(workDate);
        //            String departmentName = reader.GetValue(7).ToString();
        //            int scheduleID = (int)reader.GetValue(8);

        //            if ((dtpWorkSchedule.Value.Date == convertedWorkDate.Date) && (department.Name == departmentName))
        //            {
        //                // Add data to data grid view table
        //                DataGridViewRow row = (DataGridViewRow)dataAdminWorkSchedule.Rows[0].Clone();
        //                dataAdminWorkSchedule.Columns["clmnWorkDate"].DefaultCellStyle.BackColor = Color.LightSteelBlue;
        //                dataAdminWorkSchedule.Columns["clmnStartTime"].DefaultCellStyle.BackColor = Color.PaleGreen;
        //                dataAdminWorkSchedule.Columns["clmnEndTime"].DefaultCellStyle.BackColor = Color.PaleVioletRed;
        //                row.Cells[0].Value = firstName + " " + lastName; // First Name
        //                row.Cells[1].Value = role; // Name (Role)
        //                row.Cells[2].Value = workStartTime.ToString("hh:mm tt");// Start Time
        //                row.Cells[3].Value = workEndTime.ToString("hh:mm tt"); // End Time
        //                row.Cells[4].Value = convertedWorkDate.ToString("dddd, dd MMMM yyyy"); // Work Date
        //                dataAdminWorkSchedule.Rows.Add(row);
        //            }

        //            schedule = new Schedule(scheduleID, firstName, lastName, role, workStartTime, workEndTime, convertedWorkDate, departmentName);
        //            department.AddSchedule(schedule);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Sorry there's no data. Contact your administrator for more information.");
        //    }

        //    reader.Close();
        //    conn.Close();
        //}

    }
}
