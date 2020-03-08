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
    public partial class AssignEmployeeSystem : Form
    {
        String employeeName;
        String employeeID;
        String firstName;

        public AssignEmployeeSystem(String employeeName )
        {
            InitializeComponent();
            this.employeeName = employeeName;

            DateTime time = DateTime.Today;

            for( DateTime _time = time.AddHours( 08 ); _time < time.AddHours( 24 ); _time = _time.AddMinutes( 60 ) ) //from 16h to 18h hours
            {
                comBoxStartTime.Items.Add( _time.ToShortTimeString() );
                comBoxEndTime.Items.Add( _time.ToShortTimeString() );
            }

            lBoxAssignEmployee.Items.Clear();

            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            string sql = "SELECT Person.Id, FirstName, StartTime, EndTime, WorkDate FROM Person " +
                "INNER JOIN Schedule ON Person.Id = Schedule.PersonID";
            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            connection.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while( reader.Read() )
            {
                this.employeeID = reader.GetValue( 0 ).ToString();
                this.firstName = reader.GetValue( 1 ).ToString();
                String startTime = reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                String workDate = reader.GetValue( 4 ).ToString();

                if(firstName == employeeName )
                {
                    lBoxAssignEmployee.Items.Add(firstName + " - " + startTime + " - " + endTime + " - " + workDate );
                }
            }

        }

        private void btnDone_Click( object sender, EventArgs e )
        {
            String employeeID = this.employeeID;
            String startTime = comBoxStartTime.SelectedItem.ToString();
            String endTime = comBoxEndTime.SelectedItem.ToString();
            DateTime updateStartTime = DateTime.Parse( startTime );
            DateTime updateEndTime = DateTime.Parse( endTime );

            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            string sql = "UPDATE Schedule " +
                "INNER JOIN Person ON Schedule.PersonID = Person.Id " +
                "SET StartTime=@startTime, EndTime=@endTime, FirstName=@employeeName " +
                "WHERE Person.FirstName = @employeeName";

            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            cmd.Parameters.AddWithValue( "@employeeName", this.firstName );
            cmd.Parameters.AddWithValue( "@startTime", updateStartTime );
            cmd.Parameters.AddWithValue( "@endTime", updateEndTime );
            connection.Open();
            int rows = cmd.ExecuteNonQuery();
            MessageBox.Show( rows.ToString() );
        }
    }
}
