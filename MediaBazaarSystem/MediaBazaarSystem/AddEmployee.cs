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
    public partial class Employee_Add : Form
    {
        Department department;
        Employee employee;
        Manager manager;
        public Employee_Add(Department dep, Employee emp, Manager man)
        {
            InitializeComponent();
            this.department = dep;
            this.employee = emp;
            this.manager = man;

            if(emp != null)
            {
                txtBoxFirstName.Text = emp.FirstName;
                txtBoxLastName.Text = emp.LastName;
                numAge.Value = emp.Age;
                tbAddress.Text = emp.Address;
                comBoxPosition.SelectedItem = emp.Role;
                txtBoxSalary.Text = emp.Salary.ToString();
                txtBoxHoursAvailable.Text = emp.HoursAvailable.ToString();
                txtBoxEmail.Text = emp.Email.ToString();

                btnAddEmployee.Text = "Edit";
            }
            else if(man != null)
            {
                txtBoxFirstName.Text = manager.FirstName;
                txtBoxLastName.Text = manager.LastName;
                numAge.Value = manager.Age;
                tbAddress.Text = manager.Address;
                comBoxPosition.SelectedItem = manager.Role;
                txtBoxSalary.Text = manager.Salary.ToString();
                txtBoxHoursAvailable.Text = manager.HoursAvailable.ToString();
                txtBoxEmail.Text = manager.Email.ToString();

                btnAddEmployee.Text = "Edit";
            }
            else
            {
                btnAddEmployee.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (department.GetEmployee(txtBoxFirstName.Text, txtBoxLastName.Text) != null && employee == null)
            {
                MessageBox.Show("Employee already registered.");
            }
            else
            {
                //MySQL
                string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
                MySqlConnection conn = new MySqlConnection(connString);

                int roleID = 0;
                String FirstN = txtBoxFirstName.Text.ToString();
                String LastN = txtBoxLastName.Text.ToString();
                int age = Convert.ToInt32(numAge.Value);
                String address = tbAddress.Text.ToString();
                String role = comBoxPosition.SelectedItem.ToString();
                double salary = Convert.ToDouble(txtBoxSalary.Text);
                int hoursAvailable = Convert.ToInt32(txtBoxHoursAvailable.Text);
                String email = txtBoxEmail.Text.ToString();

                if(role == "Manager")
                {
                    roleID = 1;
                }
                else if(role == "Employee")
                {
                    roleID = 2;
                }
                
                if (employee == null)
                {
                    String password = Cryptography.Encrypt("temp");
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "INSERT INTO person(Firstname, Lastname, Age, Address, Email, Password, Salary, HoursWorked, HoursAvailable, IsAvailable, RoleID, DepartmentID) " +
                        "VALUES(@FirstN, @LastN, @Age, @Address, @Email, @Password, @Salary, @HoursWorked, @HoursAvailable, @IsAvailable, @RoleID, @DepartmentID)";
                    
                    cmd.Parameters.AddWithValue("@FirstN", FirstN);
                    cmd.Parameters.AddWithValue("@LastN", LastN);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@HoursWorked", 0);
                    cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
                    cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    if(roleID == 1)
                    {
                        conn.Open();
                        MySqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1";
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        int ID = 0;
                        while (reader.Read())
                        {
                            ID = (int)reader.GetValue(0);
                        }
                        reader.Close();
                        conn.Close();
                        Manager newManager = new Manager(ID, FirstN, LastN, age, address, role, salary, hoursAvailable, email);
                        department.AddManager(newManager);
                        MessageBox.Show("Manager successfully added");
                    }

                    else
                    {
                        conn.Open();
                        MySqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "SELECT Id FROM person ORDER BY Id DESC LIMIT 1";
                        MySqlDataReader reader = cmd2.ExecuteReader();
                        int ID = 0;
                        while(reader.Read())
                        {
                            ID = (int)reader.GetValue(0);
                        }
                        reader.Close();
                        conn.Close();
                        Employee newEmployee = new Employee(ID, FirstN, LastN, age, address, role, salary, hoursAvailable, email);
                        department.AddEmployee(newEmployee);
                        MessageBox.Show("Employee successfully added");
                    }
                }

                else
                {
                    conn.Open();
                    MySqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "UPDATE person SET Firstname = @FirstN,  Lastname = @LastN, Age = @Age, Address = @Address, Email = @Email, Salary = @Salary," +
                        "HoursAvailable = @HoursAvailable, IsAvailable = @IsAvailable, RoleID = @RoleID, DepartmentID = @DepartmentID WHERE Id = @PersonID";

                    cmd.Parameters.AddWithValue("@FirstN", FirstN);
                    cmd.Parameters.AddWithValue("@LastN", LastN);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@HoursAvailable", hoursAvailable);
                    cmd.Parameters.AddWithValue("@IsAvailable", "Yes");
                    cmd.Parameters.AddWithValue("@RoleID", roleID);
                    cmd.Parameters.AddWithValue("@DepartmentID", department.DepartmentID);
                    cmd.Parameters.AddWithValue("@PersonID", employee.dbID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    employee.editEmployee(FirstN, LastN, age, address, role, salary, hoursAvailable, email);
                    MessageBox.Show("Employee successfully edited");
                }
                this.Hide();
            }
        }
    }
}
