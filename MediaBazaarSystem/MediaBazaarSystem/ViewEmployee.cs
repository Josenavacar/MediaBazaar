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
        public ViewEmployee(Employee employee )
        {
            InitializeComponent();
            this.employee = employee;
            lblFirstName.Text += " " + employee.FirstName;
            lblLastName.Text += " " + employee.LastName;
            lblAddress.Text += " " + employee.Address;
            lbMoney.Text += " " + employee.Salary;
            lblAge.Text += " " + employee.Age;
            lbTimeAv.Text += " " + employee.HoursAvailable;
            lbWork.Text += " " + employee.Role;
        }
    }
}
