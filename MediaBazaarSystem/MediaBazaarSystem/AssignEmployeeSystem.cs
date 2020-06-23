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
        private DatabaseHelper databaseHelper;
        private Schedule schedule;
        private Department department;

        /**
         * Form constructor
         */
        public AssignEmployeeSystem(Department department, Schedule schedule )
        {
            InitializeComponent();
            this.databaseHelper = new DatabaseHelper();
            this.schedule = schedule;
            this.department = department;
            GetWorkDates();

            txtBoxEmployeeName.Text = this.schedule.FirstName + " " + this.schedule.LastName;

            DateTime time = DateTime.Today;
            for( DateTime _time = time.AddHours( 08 ); _time < time.AddHours( 24 ); _time = _time.AddMinutes( 60 ) ) //from 16h to 18h hours
            {
                comBoxStartTime.Items.Add( _time.ToShortTimeString() );
                comBoxEndTime.Items.Add( _time.ToShortTimeString() );
            }
            this.UpdateSchedule();
        }

        /**
         * Method to get employee's work dates from DB
         */
        private void GetWorkDates()
        {
            MySqlDataReader reader = databaseHelper.getEmpAvailableWorkDates( schedule.EmployeeID );

            // Add data to data grid view table
            while( reader.Read() )
            {
                int employee = ( int ) reader.GetValue( 2 );
                DateTime workDate = Convert.ToDateTime( reader.GetValue( 1 ).ToString() );

                if( employee == schedule.EmployeeID )
                {
                    comBoxWorkDate.Items.Add( workDate.ToString( "dddd, dd MMMM yyyy" ) );
                }
            }
        }

        /**
         * Method to update the listbox with data
         */
        private void UpdateSchedule()
        {
            lBoxAssignEmployee.Items.Clear();

            lBoxAssignEmployee.Items.Add( 
                schedule.FirstName + " " + schedule.LastName + " --- " +
                schedule.StartTime.ToString( "hh:mm tt" ) + " --- " + 
                schedule.EndTime.ToString( "hh:mm tt" ) + " --- " + 
                schedule.WorkDate.ToString( "dddd, dd MMMM yyyy" ) 
            );

            updateTimer.Enabled = false;
        }

        /**
         * Method to assign employee to a schedule and save to DB
         */
        private void btnDone_Click( object sender, EventArgs e )
        {
            updateTimer.Enabled = true;
            String startTime = comBoxStartTime.SelectedItem.ToString();
            String endTime = comBoxEndTime.SelectedItem.ToString();
            String workDate = comBoxWorkDate.SelectedItem.ToString();
            DateTime updateStartTime = DateTime.Parse( startTime );
            DateTime updateEndTime = DateTime.Parse( endTime );
            DateTime updateWorkDate = DateTime.Parse( workDate );
            lBoxAssignEmployee.Items.Clear();
            
            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            string sql = "UPDATE Schedule " +
                "INNER JOIN Person ON Schedule.PersonID = Person.Id " +
                "SET StartTime=@startTime, EndTime=@endTime, WorkDate=@workDate, FirstName=@employeeName " +
                "WHERE Schedule.Id = @scheduleID";

            MySqlConnection connection = new MySqlConnection( connectionString );
            connection.Open();

            MySqlCommand cmd = new MySqlCommand( sql, connection );
            cmd.Parameters.AddWithValue( "@scheduleID", schedule.dbID);
            cmd.Parameters.AddWithValue( "@employeeName", schedule.FirstName );
            cmd.Parameters.AddWithValue( "@startTime", updateStartTime );
            cmd.Parameters.AddWithValue( "@endTime", updateEndTime );
            cmd.Parameters.AddWithValue( "@workDate", updateWorkDate );
            cmd.ExecuteNonQuery(); 
            connection.Close();

            schedule.UpdateSchedule(schedule.dbID, schedule.FirstName, schedule.LastName, schedule.Role, updateStartTime, updateEndTime, updateWorkDate, this.department.Name);

            this.Hide();
        }

        private void updateTimer_Tick( object sender, EventArgs e )
        {
            updateTimer.Interval = 1000;
            this.UpdateSchedule();
        }
    }
}
