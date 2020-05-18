using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public abstract class Staff
    {
        protected int ID;
        protected String firstName;
        protected String lastName;
        protected int age;
        protected DateTime birthDate;
        protected String address;
        protected String role;
        protected String password;
        protected String email;
        protected double salary;
        protected int hoursWorked;
        protected int hoursAvailable;
        protected int personID;
        protected Contract contract;

        public override string ToString()
        {
            return "ID: " + this.ID + ", Name: " + this.firstName + this.lastName + ". Age: " + this.age + ". Address: " + this.address + this.role + this.password + this.email + this.salary + this.hoursWorked + this.hoursAvailable;
        }
    }
}
