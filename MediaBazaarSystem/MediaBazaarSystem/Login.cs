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


namespace MediaBazaarSystem
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            String password = txtBoxPassword.Text;
            String toDecryptPassword = "";

            //using( MySqlConnection connection = new MySqlConnection( @"Server = studmysql01.fhict.local; Uid = ; Database = ; Pwd = ;" ) )
            //{
            //    // SQL query to get the user based on login credentials
            //    MySqlCommand cmd = new MySqlCommand( "Select * from Clients where Username = @email", connection );
            //    cmd.Parameters.Add( "email", MySqlDbType.VarChar ).Value = email;

            //    // Open connection
            //    connection.Open();

            //    MySqlDataReader reader = cmd.ExecuteReader( CommandBehavior.CloseConnection );

            //    try
            //    {

            //        // If the data is available then log user in and open navigation form
            //        // else show error message
            //        if( reader.Read() == true )
            //        {
            //            // The number is based on the column... 
            //            //E.g. password is column 2 and email is column 1
            //            toDecryptPassword = reader.GetString( 2 );

            //            if( Cryptography.Decrypt( toDecryptPassword ) == password )
            //            {
            //                MessageBox.Show( "Login successfull" );
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show( "Email or password is incorrect. Please try again." );
            //        }
            //    }
            //    catch( FormatException ex )
            //    {
            //        MessageBox.Show( ex.ToString() );
            //    }

            //    connection.Close();
            //}
        }

        private void btnRegister_Click( object sender, EventArgs e )
        {
            String email = txtBoxEmail.Text;
            //String password = Cryptography.Encrypt( txtBoxPassword.Text );

            //using( MySqlConnection connection = new MySqlConnection( @"Server = studmysql01.fhict.local; Uid = ; Database = ; Pwd = ;" ) )
            //{
            //    String query = "INSERT INTO Users(email, password) VALUES (@email, @password)";

            //    try
            //    {
            //        connection.Open();
            //        MySqlCommand cmd = new MySqlCommand( query, connection );
            //        cmd.Parameters.AddWithValue( "@email", email );
            //        cmd.Parameters.AddWithValue( "@password", password );
            //        cmd.ExecuteNonQuery();
            //        connection.Close();
            //    }
            //    catch( Exception es )
            //    {
            //        MessageBox.Show( es.Message );
            //    }
            //}
        }
    }
}
