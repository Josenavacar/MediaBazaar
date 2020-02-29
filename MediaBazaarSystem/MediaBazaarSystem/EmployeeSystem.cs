using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaBazaarSystem
{
    public partial class EmployeeSystem : Form
    {
        List<string> myList = new List<string>();

        public EmployeeSystem(String employeeID)
        {
            InitializeComponent();
            //myList = employees;

            lbWorkSchedule.Items.Add( employeeID );

            //foreach(String employee in myList)
            //{
            //    lbWorkSchedule.Items.Add(employee);
            //}



            //string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
            //string sql = "SELECT * FROM Authors";
            //SqlConnection connection = new SqlConnection( connectionString );
            //SqlDataAdapter dataadapter = new SqlDataAdapter( sql, connection );
            //DataSet ds = new DataSet();
            //connection.Open();
            //dataadapter.Fill( ds, "Authors_table" );
            //connection.Close();
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "Authors_table";
        }
    }
}
