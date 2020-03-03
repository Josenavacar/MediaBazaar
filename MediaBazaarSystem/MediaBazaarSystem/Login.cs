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
        Department dep1;
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

            using( MySqlConnection connection = new MySqlConnection( @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;" ) )
            {
                // SQL query to get the user based on login credentials
                MySqlCommand cmd = new MySqlCommand( "Select * from Person where email = @email", connection );
                cmd.Parameters.Add( "email", MySqlDbType.VarChar).Value = email;

                // Open connection
                connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );

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


            using( MySqlConnection connection = new MySqlConnection( @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;" ) )
            {
                String query = "INSERT INTO Person (email, password) VALUES (@email, @password)";

                try
                {
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand( query, connection );
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
