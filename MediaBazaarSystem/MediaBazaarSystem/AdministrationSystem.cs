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
