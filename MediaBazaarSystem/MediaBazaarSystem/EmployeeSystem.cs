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
    public partial class EmployeeSystem : Form
    {
        public EmployeeSystem(String employeeID)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            InitializeComponent();

            string connectionString = @"Data Source=(local);Initial Catalog=MediaBazaar;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Column Encryption Setting=enabled";
            string sql = "SELECT FirstName, HoursWorked, HoursAvailable, Name FROM [User] JOIN Role ON [User].RoleId = Role.Id";
            SqlConnection connection = new SqlConnection( connectionString );
            SqlCommand cmd = new SqlCommand( sql, connection );
            SqlDataReader reader = cmd.ExecuteReader();
            connection.Open();

            while( reader.Read() )
            {
                DataGridViewRow row = ( DataGridViewRow ) dataGridView1.Rows[ 0 ].Clone();
                row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Hours Worked
                row.Cells[ 2 ].Value = reader.GetValue( 2 ).ToString(); // Hours Avialbel
                row.Cells[ 3 ].Value = reader.GetValue( 3 ).ToString(); // Role
                row.Cells[ 4 ].Value = dateTimePicker.Value.ToString();
                dataGridView1.Rows.Add( row );
                dataGridView1.Controls.Add( dateTimePicker );
                dateTimePicker.Format = DateTimePickerFormat.Time;
            }
        }
    }
}
