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

        public void addStaffToDB( Staff man, Department department )
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
            
            department.AddStaffMember(man);
        }

        public List<Staff> getStaffFromDB(Department dep)
        {
            MySqlConnection conn = new MySqlConnection(connString);
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

                if(role == "Manager")
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


        //////////////////////////////////////////////////////////////////W.I.P.////////////////////////////////////////////////////////////////////////////////////
        public void getWorkSchedule(String sql) 
        {
            MySqlConnection conn = new MySqlConnection(connString);

            MySqlCommand cmd = new MySqlCommand(sql, conn);
            // Open connection
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                // Get the data
                while (reader.Read())
                {
                    String firstName = reader.GetValue(1).ToString();
                    String lastName = reader.GetValue(2).ToString();
                    String role = reader.GetValue(3).ToString();
                    String startTime = reader.GetValue(4).ToString();
                    String endTime = reader.GetValue(5).ToString();
                    String workDate = reader.GetValue(6).ToString();
                    DateTime workStartTime = Convert.ToDateTime(startTime);
                    DateTime workEndTime = Convert.ToDateTime(endTime);
                    DateTime convertedWorkDate = Convert.ToDateTime(workDate);
                    String departmentName = reader.GetValue(7).ToString();
                    int scheduleID = (int)reader.GetValue(8);

                    if ((dtpWorkSchedule.Value.Date == convertedWorkDate.Date) && (department.Name == departmentName))
                    {
                        // Add data to data grid view table
                        DataGridViewRow row = (DataGridViewRow)dataAdminWorkSchedule.Rows[0].Clone();
                        dataAdminWorkSchedule.Columns["clmnWorkDate"].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        dataAdminWorkSchedule.Columns["clmnStartTime"].DefaultCellStyle.BackColor = Color.PaleGreen;
                        dataAdminWorkSchedule.Columns["clmnEndTime"].DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        row.Cells[0].Value = firstName + " " + lastName; // First Name
                        row.Cells[1].Value = role; // Name (Role)
                        row.Cells[2].Value = workStartTime.ToString("hh:mm tt");// Start Time
                        row.Cells[3].Value = workEndTime.ToString("hh:mm tt"); // End Time
                        row.Cells[4].Value = convertedWorkDate.ToString("dddd, dd MMMM yyyy"); // Work Date
                        dataAdminWorkSchedule.Rows.Add(row);
                    }

                    schedule = new Schedule(scheduleID, firstName, lastName, role, workStartTime, workEndTime, convertedWorkDate, departmentName);
                    department.AddSchedule(schedule);
                }
            }
            else
            {
                MessageBox.Show("Sorry there's no data. Contact your administrator for more information.");
            }

            reader.Close();
            conn.Close();
        }

    }
}
