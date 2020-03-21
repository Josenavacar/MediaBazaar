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
        private String firstName;
        Schedule schedule;
        Employee employee;
        Department department;

        public AssignEmployeeSystem(Department department, Schedule schedule, Employee employee )
        {
            InitializeComponent();
            this.employee = employee;
            this.schedule = schedule;
            this.department = department;

            foreach(Employee employee1 in department.GetEmployees())
            {
                comBoxEmployees.Items.Add( employee1.FirstName );
            }

            DateTime time = DateTime.Today;
            for( DateTime _time = time.AddHours( 08 ); _time < time.AddHours( 24 ); _time = _time.AddMinutes( 60 ) ) //from 16h to 18h hours
            {
                comBoxStartTime.Items.Add( _time.ToShortTimeString() );
                comBoxEndTime.Items.Add( _time.ToShortTimeString() );
            }

            this.UpdateSchedule();

        }
        private void UpdateSchedule()
        {
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
                this.firstName = reader.GetValue( 1 ).ToString();
                String startTime = reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                String workDate = reader.GetValue( 4 ).ToString();

                if( firstName == employee.FirstName )
                {
                    lBoxAssignEmployee.Items.Add( firstName + " - " + startTime + " - " + endTime + " - " + workDate );
                }
            }

            updateTimer.Enabled = false;
        }

        private void btnDone_Click( object sender, EventArgs e )
        {
            updateTimer.Enabled = true;

            String startTime = comBoxStartTime.SelectedItem.ToString();
            String endTime = comBoxEndTime.SelectedItem.ToString();
            String workDate = dtpWorkDate.Value.ToString();
            DateTime updateStartTime = DateTime.Parse( startTime );
            DateTime updateEndTime = DateTime.Parse( endTime );
            DateTime updateWorkDate = DateTime.Parse( workDate );
            lBoxAssignEmployee.Items.Clear();
            
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            string sql = "UPDATE Schedule " +
                "INNER JOIN Person ON Schedule.PersonID = Person.Id " +
                "SET StartTime=@startTime, EndTime=@endTime, WorkDate=@workDate, FirstName=@employeeName " +
                "WHERE Person.FirstName = @employeeName";

            MySqlConnection connection = new MySqlConnection( connectionString );
            MySqlCommand cmd = new MySqlCommand( sql, connection );
            cmd.Parameters.AddWithValue( "@employeeName", this.employee.FirstName );
            cmd.Parameters.AddWithValue( "@startTime", updateStartTime );
            cmd.Parameters.AddWithValue( "@endTime", updateEndTime );
            cmd.Parameters.AddWithValue( "@workDate", updateWorkDate );
            connection.Open();

            schedule.UpdateSchedule(this.employee.FirstName, this.employee.LastName, employee.Role, updateStartTime, updateEndTime, updateWorkDate, this.department.Name);

            this.Hide();
        }

        private void updateTimer_Tick( object sender, EventArgs e )
        {
            updateTimer.Interval = 1000;
            this.UpdateSchedule();
        }
    }
}
