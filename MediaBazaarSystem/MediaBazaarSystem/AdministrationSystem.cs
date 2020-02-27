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
        Department dep;
        public AdministrationSystem(Department dep)
        {
            InitializeComponent();
            this.dep = dep;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Employee_Add form1 = new Employee_Add(dep, null);
            form1.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            lbEmployees.Items.Clear();
            List<Employee> list = dep.GetEmployees();
            foreach(Employee emp in list)
            {
                String aux = emp.LastN + ", " + emp.FirstN;
                lbEmployees.Items.Add(aux);
            }
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            Employee emp = SearchEmp();
            ViewEmployee form1 = new ViewEmployee(emp);
            form1.Show();
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            Employee emp = SearchEmp();
            Employee_Add form1 = new Employee_Add(dep, emp);
            form1.Show();
        }

        private Employee SearchEmp()
        {
            String aux = lbEmployees.SelectedItem.ToString();
            String[] name = aux.Split(','); //Splits the string by the comma.
            String firstName = name[1].Trim();
            String lastName = name[0].Trim();
            Employee emp = dep.GetEmployee(firstName, lastName);
            return emp;
        }
    }
}
