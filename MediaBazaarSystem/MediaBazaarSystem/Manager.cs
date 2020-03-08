using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Manager : Staff
    {
        private static int idSeeder;

        public String FirstN
        {
            get { return firstName; }
            private set { this.firstName = value; }
        }

        public String LastN
        {
            get { return lastName; }
            private set { this.lastName = value; }
        }

        public String ADDRESS
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public int AGE
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public String ROLE
        {
            get { return this.role; }
            private set { this.role = value; }
        }

        public double SALARY
        {
            get { return this.salary; }
            private set { this.salary = value; }
        }

        public int HoursFree
        {
            get { return this.hoursAvailable; }
            private set { this.hoursAvailable = value; }
        }

        public Manager( String firstName, String lastName, int age, String address, String role, double salary,  int hoursAvailable ) //hours worked deleted
        {
            this.ID = idSeeder;
            idSeeder++;
            FirstN = firstName;
            LastN = lastName;
            AGE = age;
            ADDRESS = address;
            ROLE = role;
            SALARY = salary;
            HoursFree = hoursAvailable;
        }

        public void GenerateSalary()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
