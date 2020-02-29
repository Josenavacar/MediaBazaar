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
        List<String> employees = new List<String>();

        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;
            String toDecryptPassword = "";
            

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
                        for( int i = 0; i < reader.FieldCount; i++ )
                        {
                            employees.Add(Convert.ToString( reader.GetValue( i ) ));
                        }

                        // The number is based on the column... 
                        //E.g. password is column 2 and email is column 1
                        toDecryptPassword = reader.GetString( 6 ) ;

                        if( Cryptography.Decrypt( toDecryptPassword ) == password )
                        {
                            MessageBox.Show( "Login successfull" );
                            //EmployeeSystem employeeSystem = new EmployeeSystem( employees );
                            //employeeSystem.Show();

                            //string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
                            //string sql = "SELECT * FROM Authors";
                            //SqlConnection connecton = new SqlConnection( connectionString );
                            //SqlDataAdapter dataadapter = new SqlDataAdapter( sql, connecton );
                            //DataSet ds = new DataSet();
                            //connection.Open();
                            //dataadapter.Fill( ds, "Authors_table" );
                            //connection.Close();
                            //dataGridView1.DataSource = ds;
                            //dataGridView1.DataMember = "Authors_table";

                            //using( SqlDataAdapter sda = new SqlDataAdapter( cmd, connection ) )
                            //{
                            //    DataTable dt = new DataTable();
                            //    sda.Fill( dt );

                            //    if( dt.Rows.Count > 0 )
                            //    {
                                    
                            //        String employeeID = dt.Rows[ 0 ][ "Id" ].ToString();
                            //        MessageBox.Show( employeeID );
                            //        //EmployeeSystem employeeSystem = new EmployeeSystem( employeeID );
                            //        //employeeSystem.Show();
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show( "Please Check your Username & password" );
                            //    }

                            //    dt.Dispose();

                            //}

                        }
                    }
                    else
                    {
                        MessageBox.Show( "Email or password is incorrect. Please try again." );
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
