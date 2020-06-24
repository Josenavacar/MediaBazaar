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
    public partial class UpdateEmployeeSchedule : Form
    {
        private DatabaseHelper databaseHelper;
        private Schedule schedule;
        private Department department;
        private EmailHelper emailHelper;

        /**
         * Form constructor
         */
        public UpdateEmployeeSchedule(Department department, Schedule schedule )
        {
            InitializeComponent();
            this.databaseHelper = new DatabaseHelper();
            this.emailHelper = new EmailHelper();
            this.schedule = schedule;
            this.department = department;

            txtBoxEmployeeName.Text = this.schedule.FirstName + " " + this.schedule.LastName;

            dtpWorkDates.MinDate = DateTime.Now;
            dtpWorkDates.MaxDate = DateTime.Now.AddDays( 7 );
            DateTime time = DateTime.Today;

            for( DateTime _time = time.AddHours( 08 ); _time < time.AddHours( 24 ); _time = _time.AddMinutes( 60 ) ) //from 16h to 18h hours
            {
                comBoxStartTime.Items.Add( _time.ToShortTimeString() );
                comBoxEndTime.Items.Add( _time.ToShortTimeString() );
            }
            this.UpdateSchedule();
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
            lBoxAssignEmployee.Items.Clear();
            Staff staff = department.GetStaffMember( txtBoxEmployeeName.Text );
            String startTime = comBoxStartTime.SelectedItem.ToString();
            String endTime = comBoxEndTime.SelectedItem.ToString();
            String workDate = dtpWorkDates.Value.ToString();
            DateTime updateStartTime = DateTime.Parse( startTime );
            DateTime updateEndTime = DateTime.Parse( endTime );
            DateTime updateWorkDate = DateTime.Parse( workDate );
            String body = "Your shift has been updated. This is your new shift start time: " + startTime + " end time: " + endTime + " work date: " + workDate;

            try
            {
                databaseHelper.UpdateEmployeeSchedule( schedule, startTime, endTime, workDate );
                emailHelper.SendScheduleEmail( body, staff.Email );
                schedule.UpdateSchedule( schedule.dbID, schedule.FirstName, schedule.LastName, schedule.Role, updateStartTime, updateEndTime, updateWorkDate, this.department.Name );
                this.Hide();
                MessageBox.Show( "Schedule successfully added!" );
            }
            catch( Exception ex )
            {
                MessageBox.Show( "Sorry request failed." );
            }
        }

        /**
         * Method to refresh listbox
         */
        private void updateTimer_Tick( object sender, EventArgs e )
        {
            updateTimer.Interval = 1500;
            this.UpdateSchedule();
        }
    }
}
