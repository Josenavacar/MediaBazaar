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
                tbFirstN.Text = emp.FirstN;
                tbLastN.Text = emp.LastN;
                numAge.Value = emp.AGE;
                tbAddress.Text = emp.ADDRESS;
                cbPosition.SelectedItem = emp.ROLE;
                tbSalary.Text = emp.SALARY.ToString();
                tbHours.Text = emp.HoursFree.ToString();

                btnAddEmployee.Text = "Edit";
            }
            else
            {
                btnAddEmployee.Text = "Add";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String FirstN = tbFirstN.Text.ToString();
            String LastN = tbLastN.Text.ToString();
            int age = Convert.ToInt32(numAge.Value);
            String address = tbAddress.Text.ToString();
            String role = cbPosition.SelectedItem.ToString();
            double salary = Convert.ToDouble(tbSalary.Text);
            int hoursAvailable = Convert.ToInt32(tbHours.Text);

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
