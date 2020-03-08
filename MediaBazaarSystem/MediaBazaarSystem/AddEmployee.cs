using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSystem
{
    public partial class Employee_Add : Form
    {
        Department department;
        Employee employee;
        public Employee_Add(Department dep, Employee emp)
        {
            InitializeComponent();
            this.department = dep;
            this.employee = emp;

            if(emp != null)
            {
                txtBoxFirstName.Text = emp.FirstName;
                txtBoxLastName.Text = emp.LastName;
                numAge.Value = emp.Age;
                tbAddress.Text = emp.Address;
                comBoxPosition.SelectedItem = emp.Role;
                txtBoxSalary.Text = emp.Salary.ToString();
                txtBoxHoursAvailable.Text = emp.HoursAvailable.ToString();

                btnAddEmployee.Text = "Edit";
            }
            else
            {
                btnAddEmployee.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( department.GetEmployee(txtBoxFirstName.Text, txtBoxLastName.Text) != null && employee == null)
            {
                MessageBox.Show("Employee already registered.");
            }
            else
            {
                String FirstN = txtBoxFirstName.Text.ToString();
                String LastN = txtBoxLastName.Text.ToString();
                int age = Convert.ToInt32(numAge.Value);
                String address = tbAddress.Text.ToString();
                String role = comBoxPosition.SelectedItem.ToString();
                double salary = Convert.ToDouble(txtBoxSalary.Text);
                int hoursAvailable = Convert.ToInt32(txtBoxHoursAvailable.Text);

                Employee newEmployee = new Employee(FirstN, LastN, age, address, role, salary, hoursAvailable);
                if ( employee == null)
                {
                    department.AddEmployee(newEmployee);
                    MessageBox.Show("Employee successfully added");
                }
                else
                {
                    department.DeleteEmployee( employee );
                    department.AddEmployee(newEmployee);
                    MessageBox.Show("Employee successfully edited");
                }
                this.Hide();
            }
        }
    }
}
