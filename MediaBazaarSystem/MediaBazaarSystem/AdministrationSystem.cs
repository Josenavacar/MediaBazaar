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
        AssignEmployeeSystem assignEmployeeForm = new AssignEmployeeSystem();
        private Department department;
        private Manager manager;
        public static bool ensure; //Used for double checking when deleting from the database.

        public AdministrationSystem(Department department, Manager manager)
        {
            InitializeComponent();

            int idManage;
            this.department = department;
            this.manager = manager;

            lblAdminName.Text += " " + manager.FirstName + " " + manager.LastName;

            string connectionString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";

            //Schedule related
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
            reader.Close();

            //Employee related
            String sql2 = "SELECT * FROM person WHERE DepartmentID = @DepartmentID";
            MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
            cmd2.Parameters.Add("DepartmentID", MySqlDbType.VarChar).Value = department.DepartmentID;

            reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                int role = (int)reader.GetValue(11);
                if ( role == 1 ) //Managers
                {
                    //Retreive all the data from the database
                    int ID = (int)reader.GetValue(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    int age = (int)reader.GetValue(3);
                    String address = reader.GetString(4);
                    String email = reader.GetString(5);
                    String charge = "Manager";
                    double salary = reader.GetDouble(7);
                    int hoursavailable = (int)reader.GetValue(9);

                    //Add the manager to the list.
                    Manager man = new Manager(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
                    department.AddManager(man);

                    idManage = ID;
                }

                else if(role == 2) //Employees
                {
                    //Retreive all the data from the database
                    int ID = (int)reader.GetValue(0);
                    String firstName = reader.GetString(1);
                    String lastName = reader.GetString(2);
                    int age = (int)reader.GetValue(3);
                    String address = reader.GetString(4);
                    String email = reader.GetString(5);
                    String charge = "Employee";
                    double salary = reader.GetDouble(7);
                    int hoursavailable = (int)reader.GetValue(9);

                    //Add the employee to the list.
                    Employee emp = new Employee(ID, firstName, lastName, age, address, charge, salary, hoursavailable, email);
                    department.AddEmployee(emp);

                    idManage = ID;
                }
            }
            reader.Close();
            connection.Clone();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            UpdateOrAdd form1 = new UpdateOrAdd(department);
            form1.Show();
        }

        private void btnViewEmployeeDetails_Click(object sender, EventArgs e)
        {
            if(lbEmployees.SelectedItem != null) //Checks if an employee is selected in the listbox.
            {
                Employee emp = SearchEmp(); 
                if (emp != null)
                {
                    ViewEmployee form1 = new ViewEmployee(emp, null);
                    form1.Show();
                }
            }
            else if(lbManagers.SelectedItem != null) //Checks if a manager is selected in the listbox.
            {
                Manager man = SearchMan(); 
                if(man != null)
                {
                    ViewEmployee form1 = new ViewEmployee(null, man);
                    form1.Show();
                }
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (lbEmployees.SelectedItem != null) //Checks if an employee is selected in the listbox.
            {
                Employee emp = SearchEmp();
                if (emp != null)
                {
                    UpdateOrAdd form1 = new UpdateOrAdd(department, emp);
                    form1.Show();
                }
            }

            else if(lbManagers.SelectedItem != null) //Checks if a manager is selected in the listbox.
            {
                Manager man = SearchMan();
                if (man != null)
                {
                    UpdateOrAdd form1 = new UpdateOrAdd(department, man);
                    form1.Show();
                }
            }
            else
            {
                MessageBox.Show("Action could not be performed, noone selected.");
            }

        }

        private Employee SearchEmp() //Returns an employee selected on the listbox or null if it doesn't exist.
        {
            String auxEmp = lbEmployees.SelectedItem.ToString();
            String[] name = auxEmp.Split(','); //Splits the string by the comma.
            String firstName = name[1].Trim();
            String lastName = name[0].Trim();
            Employee emp = department.GetEmployee(firstName, lastName);

            if (emp == null)
            {
                MessageBox.Show("Employee not found.");
            }

            return emp;
        }

        private Manager SearchMan() //Returns a manager selected on the listbox or null if it doesn't exist.
        {
            String auxMan = lbManagers.SelectedItem.ToString();
            String[] name = auxMan.Split(','); //Splits the string by the comma.
            String firstName = name[1].Trim();
            String lastName = name[0].Trim();
            Manager man = department.GetManager(firstName, lastName);

            if (man == null)
            {
                MessageBox.Show("Employee not found.");
            }

            return man;
        }

        private void btnFireEmployee_Click(object sender, EventArgs e)
        {
            string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            

            if (lbEmployees.SelectedItem != null)
            {
                //Opens a form that will double check for deleting, if ensure is returned back as true, the employee will be deleted from the database.
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent; //Makes the form pop up in the middle of the parent form (this).
                check.ShowDialog(this);

                if(ensure)
                {
                    Employee fired = SearchEmp();
                    if (fired != null)
                    {
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery(); //Delte from Database.

                        department.DeleteEmployee(fired); //Delete from list.
                    }

                    ensure = false; //Set ensure back to false for future calls.
                }
            }

            else if (lbManagers.SelectedItem != null)
            {
                //Opens a form that will double check for deleting, if ensure is returned back as true, the manager will be deleted from the database.
                DeleteForm check = new DeleteForm(ensure);
                check.StartPosition = FormStartPosition.CenterParent;
                check.ShowDialog(this);

                if (ensure)
                {
                    Manager fired = SearchMan();
                    if (fired != null)
                    {
                        cmd.CommandText = "DELETE FROM person WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", fired.dbID);
                        cmd.ExecuteNonQuery();

                        department.DeleteManager(fired);
                    }

                    ensure = false; //Set ensure back to false for future calls.
                }
            }

            conn.Close();
        }

        private void Refresh_Tick(object sender, EventArgs e)
        {
            //Employees
            int indexEmp = lbEmployees.SelectedIndex;

            lbEmployees.Items.Clear(); //Empties empoloyee listbox
            List<Employee> listEmp = department.GetEmployees(); 
            foreach (Employee emp in listEmp) //Refills employee listbox
            {
                String outpEmp = emp.LastName + ", " + emp.FirstName;
                lbEmployees.Items.Add(outpEmp);
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if (lbEmployees.Items.Count > 0)
                {
                    lbEmployees.SelectedIndex = indexEmp;
                }
            }
            catch(Exception ex) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbEmployees.SelectedItem = null;
            }
            

            //Managers
            int indexMan = lbManagers.SelectedIndex;

            lbManagers.Items.Clear(); //Empties managers listbox
            List<Manager> listMan = department.GetManagers();
            foreach (Manager man in listMan) //Refills managers listbox
            {
                String outpMan = man.LastName + ", " + man.FirstName;
                lbManagers.Items.Add(outpMan);
            }

            try //Makes sure that the user does not notice this operation by reselecting the exact same item that he had selected.
            {
                if (lbManagers.Items.Count > 0)
                {
                    lbManagers.SelectedIndex = indexMan;
                }
            }
            catch(Exception ex) //If an element was deleted, this would lead to a crash, instead of that we will select nothing.
            {
                lbManagers.SelectedItem = null;
            }
        }

        private void btnAssignEmployee_Click( object sender, EventArgs e )
        {
            assignEmployeeForm.Show();
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

        private void lbManagers_Click(object sender, EventArgs e)
        {
            lbEmployees.SelectedItem = null;
        }

        private void lbEmployees_Click(object sender, EventArgs e)
        {
            lbManagers.SelectedItem = null;
        }

        private void lblChangePwd_Click(object sender, EventArgs e)
        {
            //On click, opens a form to change the currently logged in user's password.
            ChangePassword pwd = new ChangePassword(manager, null);
            pwd.StartPosition = FormStartPosition.CenterParent;
            pwd.ShowDialog(this);
        }
    }
}
