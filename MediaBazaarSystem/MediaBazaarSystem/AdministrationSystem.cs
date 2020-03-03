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
    public partial class AdministrationSystem : Form
    {
        AssignEmployeeSystem assignEmployeeForm = new AssignEmployeeSystem();

        public AdministrationSystem()
        {
            InitializeComponent();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee_Add form1 = new Employee_Add(dep, null);
            form1.Show();
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            Employee emp = SearchEmp();
            if (emp != null)
            {
                ViewEmployee form1 = new ViewEmployee(emp);
                form1.Show();
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = SearchEmp();
            if(emp != null)
            {
                Employee_Add form1 = new Employee_Add(dep, emp);
                form1.Show();
            }
            
        }

        private Employee SearchEmp()
        {
            if (lbEmployees.SelectedItem != null)
            {
                String aux = lbEmployees.SelectedItem.ToString();
                String[] name = aux.Split(','); //Splits the string by the comma.
                String firstName = name[1].Trim();
                String lastName = name[0].Trim();
                Employee emp = dep.GetEmployee(firstName, lastName);

                if(emp == null)
                {
                    MessageBox.Show("Employee not found.");
                }

                return emp;
            }
            else
            {
                MessageBox.Show("Employee not selected.");
                return null;
            }
        }

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            Employee fired = SearchEmp();
            if (fired != null)
            {
                dep.DeleteEmployee(fired);
                MessageBox.Show("Employee Fired.");
            }
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            int aux1 = lbEmployees.SelectedIndex;

            lbEmployees.Items.Clear();
            List<Employee> list = dep.GetEmployees();
            foreach (Employee emp in list)
            {
                String aux = emp.LastN + ", " + emp.FirstN;
                lbEmployees.Items.Add(aux);
            }

            if (lbEmployees.Items.Count > 0)
            {
                lbEmployees.SelectedIndex = aux1;
            }
        }

        private void btnAssignEmployee_Click( object sender, EventArgs e )
        {
            assignEmployeeForm.Show(); 
        }

        private void picBoxLogout_Click( object sender, EventArgs e )
        {
            this.Hide();
            formLogin login = new formLogin();
            login.Show();
        }
    }
}
