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
    public partial class ViewEmployee : Form
    {
        Employee emp;
        public ViewEmployee(Employee emp)
        {
            InitializeComponent();
            this.emp = emp;
            lbName.Text += " " + emp.FirstN;
            lbSurn.Text += " " + emp.LastN;
            lbPlace.Text += " " + emp.ADDRESS;
            lbMoney.Text += " " + emp.SALARY;
            lbOld.Text += " " + emp.AGE;
            lbTimeAv.Text += " " + emp.HoursFree;
            lbWork.Text += " " + emp.ROLE;
        }
    }
}
