using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public abstract class Person
    {
        protected int ID;
        protected String firstName;
        protected String lastName;
        protected int age;
        protected String address;

        public Department Department
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "ID: " + this.ID + ". Name: " + this.firstName + this.lastName + ". Age: " + this.age + ". Address: " + this.address;
        }
    }
}
