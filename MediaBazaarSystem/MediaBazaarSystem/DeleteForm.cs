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
    public partial class DeleteForm : Form
    {
        public DeleteForm(bool ensure)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdministrationSystem.ensure = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministrationSystem.ensure = false;
            this.Hide();
        }
    }
}
