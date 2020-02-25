using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Employee : Staff
    {
        private static int idSeeder;

        public Employee(String firstName, String lastName, int age, String address, String role, double salary, int hoursWorked, int hoursAvailable) 
        {
            this.ID = idSeeder;
            idSeeder++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.role = role;
            this.salary = salary;
            this.hoursWorked = hoursWorked;
            this.hoursAvailable = hoursAvailable;
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
