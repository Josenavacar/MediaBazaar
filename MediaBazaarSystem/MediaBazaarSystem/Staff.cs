using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Staff : Person
    {
        protected String role;
        protected String password;
        protected String email;
        protected double salary;
        protected int hoursWorked;
        protected int hoursAvailable;
        protected int personID;

        public override string ToString()
        {
            return base.ToString() + this.role + this.password + this.email + this.salary + this.hoursWorked + this.hoursAvailable;
        }
    }
}
