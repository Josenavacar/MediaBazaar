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
    public partial class formLogin : Form
    {
        Department dep1;
        public formLogin()
        {
            InitializeComponent();
            dep1 = new Department("Default");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            EmployeeSystem next = new EmployeeSystem(dep1);
            AdministrationSystem next1 = new AdministrationSystem(dep1);
            next1.Show();
            next.Show();
            this.Hide();
        }
    }
}
