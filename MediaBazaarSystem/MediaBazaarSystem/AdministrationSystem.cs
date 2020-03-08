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
    public partial class AdministrationSystem : Form
    {
        //Department dep;
        AssignEmployeeSystem assignEmployeeForm = new AssignEmployeeSystem();

        public AdministrationSystem()
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
                String startTime = reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );

                DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                row.Cells[ 4 ].Value = reader.GetValue( 4 ).ToString(); // Date
                dataAdminWorkSchedule.Rows.Add( row );
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            //Employee_Add form1 = new Employee_Add(dep, null);
            //form1.Show();
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            //Employee emp = SearchEmp();
            //if (emp != null)
            //{
            //    ViewEmployee form1 = new ViewEmployee(emp);
            //    form1.Show();
            //}
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            //Employee emp = SearchEmp();
            //if(emp != null)
            //{
            //    Employee_Add form1 = new Employee_Add(dep, emp);
            //    form1.Show();
            //}
            
        }

        //private Employee SearchEmp()
        //{
            //if (lbEmployees.SelectedItem != null)
            //{
            //    String aux = lbEmployees.SelectedItem.ToString();
            //    String[] name = aux.Split(','); //Splits the string by the comma.
            //    String firstName = name[1].Trim();
            //    String lastName = name[0].Trim();
            //    Employee emp = dep.GetEmployee(firstName, lastName);

            //    if(emp == null)
            //    {
            //        MessageBox.Show("Employee not found.");
            //    }

            //    return emp;
            //}
            //else
            //{
            //    MessageBox.Show("Employee not selected.");
            //    return null;
            //}
        //}

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            //Employee fired = SearchEmp();
            //if (fired != null)
            //{
            //    dep.DeleteEmployee(fired);
            //    MessageBox.Show("Employee Fired.");
            //}
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            //int aux1 = lbEmployees.SelectedIndex;

            //lbEmployees.Items.Clear();
            //List<Employee> list = dep.GetEmployees();
            //foreach (Employee emp in list)
            //{
            //    String aux = emp.LastN + ", " + emp.FirstN;
            //    lbEmployees.Items.Add(aux);
            //}

            //if (lbEmployees.Items.Count > 0)
            //{
            //    lbEmployees.SelectedIndex = aux1;
            //}
        }

        private void btnAssignEmployee_Click( object sender, EventArgs e )
        {
            assignEmployeeForm.Show();

            //if( dataAdminWorkSchedule.SelectedRows.Count != -1 )
            //{
            //    DataGridViewRow row = this.dataAdminWorkSchedule.SelectedRows[ 0 ];
            //    MessageBox.Show(row.Cells[ "clmnEmployeeName" ].Value.ToString());
            //}
        }

        private void picBoxLogout_Click( object sender, EventArgs e )
        {
            this.Hide();
            formLogin login = new formLogin();
            login.Show();
        }

        private void dtpWorkSchedule_ValueChanged( object sender, EventArgs e )
        {
            this.dataAdminWorkSchedule.Rows.Clear();
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
                String startTime = reader.GetValue( 2 ).ToString();
                String endTime = reader.GetValue( 3 ).ToString();
                DateTime workStartTime = Convert.ToDateTime( startTime );
                DateTime workEndTime = Convert.ToDateTime( endTime );
                DateTime date = Convert.ToDateTime( reader.GetValue( 4 ).ToString() );
                String theDate = dtpWorkSchedule.Value.ToString( "MM/dd/yyyy" );

                if( theDate == date.ToString( "MM/dd/yyyy" ) )
                {
                    DataGridViewRow row = ( DataGridViewRow ) dataAdminWorkSchedule.Rows[ 0 ].Clone();
                    dataAdminWorkSchedule.Columns[ "clmnWorkDate" ].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    row.Cells[ 0 ].Value = reader.GetValue( 0 ).ToString(); // First Name
                    row.Cells[ 1 ].Value = reader.GetValue( 1 ).ToString(); // Name (Role)
                    row.Cells[ 2 ].Value = workStartTime.ToString( "hh:mm tt" );// Start Time
                    row.Cells[ 3 ].Value = workEndTime.ToString( "hh:mm tt" ); // End Time
                    row.Cells[ 4 ].Value = date.ToString( "MM/dd/yyyy" ); // Date
                    dataAdminWorkSchedule.Rows.Add( row );
                }
            }
        }
    }
}
