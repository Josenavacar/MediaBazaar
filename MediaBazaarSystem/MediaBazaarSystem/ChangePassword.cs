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
    public partial class ChangePassword : Form
    {
        Manager man;
        Employee emp;

        String active = "";

        public ChangePassword(Manager man, Employee emp)
        {
            InitializeComponent();

            tbCurrentPwd.UseSystemPasswordChar = true;
            tbNewPwd.UseSystemPasswordChar = true;
            tbConfirmPwd.UseSystemPasswordChar = true;
            this.man = man;
            this.emp = emp;

            if(man != null)
            {
                active = "Manager";
            }
            else if(emp != null)
            {
                active = "Employee";
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            String toDecryptPassword = "";
            String introducedPassword = tbCurrentPwd.Text.ToString();
            int ID = -1;

            string connString = @"Server = studmysql01.fhict.local; Uid = dbi437493; Database = dbi437493; Pwd = dbgroup01;";
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();

            if (active == "Manager")
            {
                ID = man.dbID;
                cmd.CommandText = "SELECT Password FROM person WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", ID);
            }
            else if(active == "Employee")
            {
                ID = emp.dbID;
                cmd.CommandText = "SELECT Password FROM person WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", ID);
            }

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                toDecryptPassword = reader.GetString(0);
            }
            reader.Close();

            if (Cryptography.Decrypt(toDecryptPassword) == introducedPassword)
            {
                if (tbNewPwd.Text.ToString() == tbConfirmPwd.Text.ToString())
                {
                    String newPassword = Cryptography.Encrypt(tbNewPwd.Text.ToString());
                    cmd.CommandText = "UPDATE person SET Password = @Password WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Password", newPassword);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Password updated");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New Password introduced does not match");
                }
            }
            else
            {
                MessageBox.Show("Current password incorrect");
            }
            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operation canceled");
            this.Close();
        }
    }
}
