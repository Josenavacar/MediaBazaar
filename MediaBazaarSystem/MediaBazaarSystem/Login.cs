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
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            txtBoxPassword.PasswordChar = Convert.ToChar("*");
        }

        private void btnLogin_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;
            String toDecryptPassword = "";
            int role;

            using( SqlConnection connection = new SqlConnection( @"Data Source=(local);Initial Catalog=MediaBazaar;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Column Encryption Setting=enabled" ) )
            {
                // SQL query to get the user based on login credentials
                SqlCommand cmd = new SqlCommand( "Select * from [User] where email = @email", connection );
                cmd.Parameters.Add( "email", SqlDbType.NVarChar ).Value = email;

                // Open connection
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );

                try
                {
                    // If the data is available then log user in and open navigation form
                    // else show error message
                    if( reader.Read() == true )
                    {
                        // The number is based on the column... 
                        //E.g. password is column 6 and email is column 5
                        toDecryptPassword = reader.GetString( 6 ) ;
                        role = (int)reader.GetValue(11);

                        if( Cryptography.Decrypt( toDecryptPassword ) == password )
                        {
                            if(role == 1) // Manager
                            {
                                AdministrationSystem administrationSystem = new AdministrationSystem();
                                administrationSystem.Show();
                                this.Hide();
                            }
                            else if(role == 2) // Employee
                            {
                                String employeeID = reader.GetValue( 0 ).ToString();
                                EmployeeSystem employeeSystem = new EmployeeSystem( employeeID );
                                employeeSystem.Show();
                                this.Hide();
                            }
                        }
                        else if( (Cryptography.Decrypt( toDecryptPassword ) != password) || (password == null) )
                        {
                            MessageBox.Show( "Email or password is incorrect. Please try again." );
                        }
                    }
                }
                catch( FormatException ex )
                {
                    MessageBox.Show( ex.ToString() );
                }
                connection.Close();
            }
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = Cryptography.Encrypt( txtBoxPassword.Text );

            using( SqlConnection connection = new SqlConnection( @"Data Source=(local);Initial Catalog=MediaBazaar;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Column Encryption Setting=enabled" ) )
            {
                String query = "INSERT INTO [User](email, password) VALUES (@email, @password)";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand( query, connection );
                    cmd.Parameters.AddWithValue( "@email", email );
                    cmd.Parameters.AddWithValue( "@password", password );
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch( Exception es )
                {
                    MessageBox.Show( es.Message );
                }
            }
        }
    }
}
