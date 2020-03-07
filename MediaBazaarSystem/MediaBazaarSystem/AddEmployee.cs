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
        Department dep;
        Employee emp;
        public Employee_Add(Department dep, Employee emp)
        {
            InitializeComponent();
            this.dep = dep;
            this.emp = emp;

            if(emp != null)
            {
                txtBoxFirstName.Text = emp.FirstN;
                txtBoxLastName.Text = emp.LastN;
                numAge.Value = emp.AGE;
                tbAddress.Text = emp.ADDRESS;
                comBoxPosition.SelectedItem = emp.ROLE;
                txtBoxSalary.Text = emp.SALARY.ToString();
                txtBoxHoursAvailable.Text = emp.HoursFree.ToString();

                btnAddEmployee.Text = "Edit";
            }
            else
            {
                btnAddEmployee.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dep.GetEmployee(txtBoxFirstName.Text, txtBoxLastName.Text) != null && emp == null)
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
                if (emp == null)
                {
                    dep.AddEmployee(newEmployee);
                    MessageBox.Show("Employee successfully added");
                }
                else
                {
                    dep.DeleteEmployee(emp);
                    dep.AddEmployee(newEmployee);
                    MessageBox.Show("Employee successfully edited");
                }
                this.Hide();
            }
        }
    }
}
