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
        /**
         * The Constructor
         */
        public EmployeeSystem(String employeeID)
        {
            InitializeComponent();

            string connectionString = @"Data Source=(local);Initial Catalog=MediaBazaar;Integrated Security=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Column Encryption Setting=enabled";
            string sql = "SELECT FirstName, Name, StartTime, EndTime, WorkDate FROM [User] " +
                "INNER JOIN Role ON [User].RoleId = Role.Id " +
                "INNER JOIN Schedule ON [User].Id = Schedule.UserID";
            SqlConnection connection = new SqlConnection( connectionString );
            SqlCommand cmd = new SqlCommand( sql, connection );
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while( reader.Read() )
            {
                String startTime =  reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );

                DataGridViewRow row = ( DataGridViewRow ) dataGVWorkSchedule.Rows[ 0 ].Clone();
                dataGVWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = reader.GetValue( 4 ).ToString(); // Date
                //row.Cells[ 7 ].Value = dateTimePicker.Value.ToString();
                dataGVWorkSchedule.Rows.Add( row );
                //dataGridView1.Controls.Add( dateTimePicker );
                //dateTimePicker.Format = DateTimePickerFormat.Time;
            }
        }
    }
}
