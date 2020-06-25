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
        public ViewEmployee(Staff staffMember)
        {
            InitializeComponent();

            lblFirstName.Text += " " + staffMember.FirstName;
            lblLastName.Text += " " + staffMember.LastName;
            lblAddress.Text += " " + staffMember.Address;
            lbSalary.Text += " " + staffMember.Salary;
            lblAge.Text += " " + staffMember.Age;
            lbHoursAvailable.Text += " " + staffMember.HoursAvailable;
            lbPosition.Text += " " + staffMember.Role;
        }
    }
}
