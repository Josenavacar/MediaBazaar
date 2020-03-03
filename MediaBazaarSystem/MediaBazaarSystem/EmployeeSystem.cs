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

            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            string sql = "SELECT FirstName, Name, StartTime, EndTime, WorkDate FROM Person " +
                "INNER JOIN Role ON Person.RoleId = Role.Id " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while( reader.Read() )
            {
                String startTime =  reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );

                DataGridViewRow row = ( DataGridViewRow ) dataEmpWorkSchedule.Rows[ 0 ].Clone();
                dataEmpWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = reader.GetValue( 4 ).ToString(); // Date
                //row.Cells[ 7 ].Value = dateTimePicker.Value.ToString();
                dataEmpWorkSchedule.Rows.Add( row );
                //dataGridView1.Controls.Add( dateTimePicker );
                //dateTimePicker.Format = DateTimePickerFormat.Time;
            }
        }

        private void picBoxLogout_Click( object sender, EventArgs e )
        {
            this.Hide();
            formLogin login = new formLogin();
            login.Show();
        }
        //Department dep;
        //public EmployeeSystem(Department dep)
        //{
        //    InitializeComponent();
        //    this.dep = dep;
        //}
    }
}
