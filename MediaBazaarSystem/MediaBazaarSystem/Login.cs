using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace MediaBazaarSystem
{
    public partial class LoginForm : Form
    {
        /**
         * Constructor
         */
        public LoginForm()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = Convert.ToChar("*");
        }

        /**
         * Method to login based on valid credentials
         */
        private void btnLogin_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;

            DBHandler dBHandler = new DBHandler();
            dBHandler.StaffLogin( email, password );
            this.Hide();
        }
    }
}
