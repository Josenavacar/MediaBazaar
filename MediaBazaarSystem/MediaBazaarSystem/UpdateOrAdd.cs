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
        DatabaseHelper dataBase;
        Department department;
        //Employee employee;
        //Manager manager;
        Staff staffMember;

        String FirstName, LastName, address, email;
        DateTime birthDate;
        double salary;
        int hoursAvailable, roleID, DepartmentID;
        Position role;
        Contract contract;

        //This form is used by 3 different methods, Add employee, add manager and update employee/manager, for that reason the constructor is overloaded,
        //if a department alone is given, then the method will add a new person, if a department + a manager is given, a manager is to be updated, and if
        //a department and an employee are given, an employee is to be updated.

        /**
         * Constructor
         */
        public UpdateOrAdd(Department dep)
        {
            InitializeComponent();

            btnEditStaff.Enabled = false;
            btnEditStaff.Visible = false;
            this.Text = "Add new person";

            this.department = dep;

            dataBase = new DatabaseHelper();
        }

        public UpdateOrAdd(Department dep, Staff staffMember)
        {
            InitializeComponent();

            btnAddStaff.Enabled = false;
            btnAddStaff.Visible = false;
            this.Text = "Update " + staffMember.FirstName + " " + staffMember.LastName;

            this.department = dep;
            this.staffMember = staffMember;

            SetUpForm();

            dataBase = new DatabaseHelper();
        }

        private void SetUpForm()
        {
            txtBoxFirstName.Text = staffMember.FirstName;
            txtBoxLastName.Text = staffMember.LastName;
            tbBirthDate.Text = staffMember.dateOfBirth.ToString();
            tbAddress.Text = staffMember.Address;
            comBoxRole.SelectedItem = staffMember.Role;
            txtBoxSalary.Text = staffMember.Salary.ToString();
            txtBoxHoursAvailable.Text = staffMember.HoursAvailable.ToString();
            txtBoxEmail.Text = staffMember.Email.ToString();
            comBoxRole.SelectedIndex = (int)staffMember.Role - 1;
            cmboBoxDepartment.SelectedIndex = this.department.DepartmentID - 1;
            cmboBoxContract.SelectedIndex = (int)staffMember.Contract - 1;
        }

        ///**
        // * Method to update manager
        // */
        //public UpdateOrAdd(Department dep, Manager man)
        //{
        //    //Update manager
        //    InitializeComponent();
        //    this.department = dep;
        //    this.employee = null;
        //    this.manager = man;

        //    txtBoxFirstName.Text = manager.FirstName;
        //    txtBoxLastName.Text = manager.LastName;
        //    tbBirthDate.Text = manager.dateOfBirth.ToString();
        //    tbAddress.Text = manager.Address;
        //    comBoxRole.SelectedItem = manager.Role;
        //    txtBoxSalary.Text = manager.Salary.ToString();
        //    txtBoxHoursAvailable.Text = manager.HoursAvailable.ToString();
        //    txtBoxEmail.Text = manager.Email.ToString();

        //    btnAddStaff.Text = "Edit";
        //    this.Text = "Update " + manager.FirstName + " " + manager.LastName;
        //}

        ///**
        // * Method to update employee
        // */
        //public UpdateOrAdd(Department dep, Employee emp)
        //{
        //    //Update employee
        //    InitializeComponent();
        //    this.department = dep;
        //    this.employee = emp;
        //    this.manager = null;

        //    txtBoxFirstName.Text = employee.FirstName;
        //    txtBoxLastName.Text = employee.LastName;
        //    tbBirthDate.Text = employee.dateOfBirth.ToString();
        //    tbAddress.Text = employee.Address;
        //    comBoxRole.SelectedItem = employee.Role;
        //    txtBoxSalary.Text = employee.Salary.ToString();
        //    txtBoxHoursAvailable.Text = employee.HoursAvailable.ToString();
        //    txtBoxEmail.Text = employee.Email.ToString();

        //    btnAddStaff.Text = "Edit";
        //    this.Text = "Update " + employee.FirstName + " " + employee.LastName;
        //}

        ///**
        // * Method to add user to database
        // */
        //private void btnAddStaff_Click( object sender, EventArgs e )
        //{
        //    //Avoids employees or managers with same name and surname.
        //    if( department.GetEmployee( txtBoxFirstName.Text, txtBoxLastName.Text ) != null && employee == null && manager == null )
        //    {
        //        MessageBox.Show( "Employee already registered." );

        //    }
        //    else
        //    {
        //        //MySQL
        //        string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
        //        MySqlConnection conn = new MySqlConnection( connString );

        //        try
        //        {
        //            int roleID = 0; //This variable will store the role ID to be stored into the database.
        //            String FirstName = txtBoxFirstName.Text.ToString(); //First name
        //            String LastName = txtBoxLastName.Text.ToString(); //Last name
        //            DateTime birthDate = Convert.ToDateTime(tbBirthDate.Text); //Date of Birth
        //            String address = tbAddress.Text.ToString(); //Address
        //            String role = comBoxRole.SelectedItem.ToString(); //Role (as a string instead of an ID for ease of use and clarity in a list of C#)
        //            double salary = Convert.ToDouble(txtBoxSalary.Text); //Salary
        //            int hoursAvailable = Convert.ToInt32(txtBoxHoursAvailable.Text); //Hours available
        //            int passcode = Convert.ToInt32( txtBoxPasscode.Text );
        //            String email = txtBoxEmail.Text.ToString(); //Email
        //            Contract contract = (Contract)Enum.Parse(typeof(Contract), cmboBoxContract.SelectedItem.ToString());

        //            //Calculate age
        //            int age = birthDate.Year - DateTime.Now.Year - 1;
        //            if (birthDate.Month > DateTime.Now.Month)
        //            {
        //                age++;
        //            }
        //            else if (birthDate.Month == DateTime.Now.Month)
        //            {
        //                if (birthDate.Day >= DateTime.Now.Day)
        //                {
        //                    age++;
        //                }
        //            }

        //            //Converts the string role into the ID.
        //            if (role == "Manager")
        //            {
        //                roleID = 1;
        //            }
        //            else if (role == "Employee")
        //            {
        //                roleID = 2;
        //            }

        //            if (employee == null && manager == null) //If only a department was given, we will add a new person.
        //            {
        //                String password = Cryptography.Encrypt("temp");
        //                conn.Open();
        //                MySqlCommand cmd = conn.CreateCommand();

        //                cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, Passcode, RoleID, DepartmentID, ContractID) " +
        //                    "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @Passcode, @RoleID, @DepartmentID, @ContractID) ";

        //                cmd.Parameters.AddWithValue("@FirstN", FirstName);
        //                cmd.Parameters.AddWithValue("@LastN", LastName);
        //                cmd.Parameters.AddWithValue("@Age", birthDate);
        //                cmd.Parameters.AddWithValue("@Address", address);
        //                cmd.Parameters.AddWithValue("@Email", email);
        //                cmd.Parameters.AddWithValue("@Password", password);
        //                cmd.Parameters.AddWithValue("@Salary", salary);
        //                cmd.Parameters.AddWithValue("@HoursWorked", 0);
        //                cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
        //                cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
        //                cmd.Parameters.AddWithValue("@Passcode", passcode );
        //                cmd.Parameters.AddWithValue("@RoleID", roleID);
        //                cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
        //                cmd.Parameters.AddWithValue("@ContractID", contract);
        //                cmd.ExecuteNonQuery(); //Inserted into database.


        //                MySqlCommand scheduleCmd = conn.CreateCommand();

        //                scheduleCmd.CommandText = "INSERT INTO schedule(StartTime, EndTime, WorkDate, PersonID) " +
        //                    "VALUES(@StartTime, @EndTime, @WorkDate, LAST_INSERT_ID()) ";

        //                scheduleCmd.Parameters.AddWithValue("@StartTime", DateTime.Today.TimeOfDay);
        //                scheduleCmd.Parameters.AddWithValue("@EndTime", DateTime.Today.TimeOfDay);
        //                scheduleCmd.Parameters.AddWithValue("@WorkDate", DateTime.Today);
        //                scheduleCmd.ExecuteNonQuery(); //Inserted into database.
        //                conn.Close();

        //                //Checks for role (1 = Manager, 2 = Employee)
        //                if (roleID == 1)
        //                {
        //                    conn.Open();
        //                    MySqlCommand cmd2 = conn.CreateCommand();
        //                    cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
        //                    MySqlDataReader reader = cmd2.ExecuteReader();
        //                    int ID = 0;
        //                    while (reader.Read())
        //                    {
        //                        ID = (int)reader.GetValue(0);
        //                    }
        //                    reader.Close();
        //                    conn.Close();

        //                    Manager newManager = new Manager(ID, FirstName, LastName, age, birthDate, address, role, salary, hoursAvailable, email, contract); //Adds the manager to the list.
        //                    department.AddManager(newManager);
        //                    MessageBox.Show("Manager successfully added.");
        //                }
        //                else if (roleID == 2)
        //                {
        //                    conn.Open();
        //                    MySqlCommand cmd2 = conn.CreateCommand();
        //                    cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1"; //Extracts the Id assigned from the database.
        //                    MySqlDataReader reader = cmd2.ExecuteReader();
        //                    int ID = 0;
        //                    while (reader.Read())
        //                    {
        //                        ID = (int)reader.GetValue(0);
        //                    }
        //                    reader.Close();
        //                    conn.Close();

        //                    Employee newEmployee = new Employee(ID, FirstName, LastName, age, birthDate, address, role, salary, hoursAvailable, email, contract); //Adds employee to the list.
        //                    department.AddEmployee(newEmployee);
        //                    MessageBox.Show("Employee successfully added.");
        //                }
        //            }
        //            else
        //            {
        //                //Edits existing person.
        //                conn.Open();
        //                MySqlCommand cmd = conn.CreateCommand();

        //                cmd.CommandText = "UPDATE person SET Firstname = @FirstN,  Lastname = @LastN, Age = @Age, Address = @Address, Email = @Email, Salary = @Salary," +
        //                    "HoursAvailable = @HoursAvailable, IsAvailable = @IsAvailable, Passcode = @Passcode,RoleID = @RoleID, DepartmentID = @DepartmentID, ContractID = @ContractID WHERE Id = @PersonID";

        //                cmd.Parameters.AddWithValue("@FirstN", FirstName);
        //                cmd.Parameters.AddWithValue("@LastN", LastName);
        //                cmd.Parameters.AddWithValue("@Age", birthDate);
        //                cmd.Parameters.AddWithValue("@Address", address);
        //                cmd.Parameters.AddWithValue("@Email", email);
        //                cmd.Parameters.AddWithValue("@Salary", salary);
        //                cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
        //                cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
        //                cmd.Parameters.AddWithValue( "@Passcode", passcode );
        //                cmd.Parameters.AddWithValue("@RoleID", roleID);
        //                cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
        //                cmd.Parameters.AddWithValue("@ContractID", contract);

        //                if (roleID == 1)
        //                {
        //                    cmd.Parameters.AddWithValue("@PersonID", manager.dbID);
        //                    manager.EditManager(FirstName, LastName, birthDate, address, role, salary, hoursAvailable, email, contract); //List edit (local).
        //                }
        //                else if( roleID == 2 )
        //                {
        //                    cmd.Parameters.AddWithValue("@PersonID", employee.dbID);
        //                    employee.EditEmployee(FirstName, LastName, birthDate, address, role, salary, hoursAvailable, email, contract); //List edit (local).
        //                }

        //                cmd.ExecuteNonQuery(); //Database edit.
        //                conn.Close();

        //                MessageBox.Show("Employee successfully edited");
        //            }

        //            this.Hide();

        //    }
        //        catch (Exception)
        //    {
        //        MessageBox.Show("Information not filled properly, please try again");
        //    }
        //}
        //}

        private void tbBirthDate_Click(object sender, EventArgs e)
        {
            tbBirthDate.Text = "";
        }

        private void btnEditStaff_Click(object sender, EventArgs e)
        {
            ReadInfoFromForm();
            //int passcode = Convert.ToInt32(txtBoxPasscode.Text);

            dataBase.managerUpdateProfile(staffMember, FirstName, LastName, birthDate, address, email, salary, hoursAvailable, roleID, DepartmentID, contract);
            staffMember.editStaffMember(FirstName, LastName, birthDate, address, email, salary, hoursAvailable, role, contract);

            MessageBox.Show("Staff member edited successfully");
            this.Close();
        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            ReadInfoFromForm();
            int tempID = -1;

            Staff newStaffMember = null;

            if (role == Position.Employee)
            {
                newStaffMember = new Employee(tempID, FirstName, LastName, birthDate, address, salary, hoursAvailable, email, contract);
            }
            else if (role == Position.HRManager || role == Position.StockManager)
            {
                newStaffMember = new Manager(tempID, FirstName, LastName, birthDate, address, salary, hoursAvailable, email, contract);
            }
            
            dataBase.addStaffToDB(newStaffMember, DepartmentID);
            newStaffMember.dbID = dataBase.getStaffID();

            if(this.department.DepartmentID == DepartmentID)
            {
                department.AddStaffMember(newStaffMember);
            }

            MessageBox.Show("Staff member added successfully");
            this.Close();
        }

        private void ReadInfoFromForm()
        {
            this.FirstName = txtBoxFirstName.Text.ToString(); //First name
            this.LastName = txtBoxLastName.Text.ToString(); //Last name
            this.birthDate = Convert.ToDateTime(tbBirthDate.Text); //Date of Birth
            this.address = tbAddress.Text.ToString(); //Address
            this.email = txtBoxEmail.Text.ToString(); //Email
            this.salary = Convert.ToDouble(txtBoxSalary.Text); //Salary
            this.hoursAvailable = Convert.ToInt32(txtBoxHoursAvailable.Text); //Hours available
            this.roleID = comBoxRole.SelectedIndex + 1;
            this.role = (Position)roleID; //Role (as a string instead of an ID for ease of use and clarity in a list of C#)
            this.DepartmentID = cmboBoxDepartment.SelectedIndex + 1;
            this.contract = (Contract)Enum.Parse(typeof(Contract), cmboBoxContract.SelectedItem.ToString());
        }
    }
}
