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
    public partial class ViewEmployee : Form
    {
        Employee employee;
        Manager manager;
        public ViewEmployee(Employee employee, Manager manager)
        {
            InitializeComponent();
            if(employee != null)
            {
                this.employee = employee;
                lblFirstName.Text += " " + employee.FirstName;
                lblLastName.Text += " " + employee.LastName;
                lblAddress.Text += " " + employee.Address;
                lbMoney.Text += " " + employee.Salary;
                lblAge.Text += " " + employee.Age;
                lbTimeAv.Text += " " + employee.HoursAvailable;
                lbWork.Text += " " + employee.Role;
            }
            else if(manager != null)
            {
                this.manager = manager;
                lblFirstName.Text += " " + manager.FirstName;
                lblLastName.Text += " " + manager.LastName;
                lblAddress.Text += " " + manager.Address;
                lbMoney.Text += " " + manager.Salary;
                lblAge.Text += " " + manager.Age;
                lbTimeAv.Text += " " + manager.HoursAvailable;
                lbWork.Text += " " + manager.Role;
            }
        }
    }
}
