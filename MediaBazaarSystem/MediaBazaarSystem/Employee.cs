using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Employee : Staff
    {
        public int dbID
        {
            get { return this.personID; }
            private set { this.personID = value; }
        }
        public String Email
        {
            get { return this.email; }
            private set { this.email = value; }
        }

        public String FirstName
        {
            get { return firstName; }
            private set { this.firstName = value; }
        }

        public String LastName
        {
            get { return lastName; }
            private set { this.lastName = value; }
        }

        public String Address
        {
            get { return this.address; }
            private set { this.address = value; }
        }

        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public String Role
        {
            get { return this.role; }
            private set { this.role = value; }
        }

        public double Salary
        {
            get { return this.salary; }
            private set { this.salary = value; }
        }

        public int HoursAvailable
        {
            get { return this.hoursAvailable; }
            private set { this.hoursAvailable = value; }
        }

        public Employee(int ID, String firstName, String lastName, int age, String address, String role, double salary, int hoursAvailable, String email) //Removed hoursworked
        {
            dbID = ID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Role = role;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
        }

        public void editEmployee(String firstName, String lastName, int age, String address, String role, double salary, int hoursAvailable, String email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Address = address;
            Role = role;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
        }

        public void GenerateSalary()
        {

        }

        public override string ToString()
        {
            return "First name: " + this.FirstName + " Last name: " + this.LastName + 
                " Age: " + this.Age + " Address: " + this.Address + 
                " Role: " + this.Role + " Salary: " + this.Salary + 
                " Hours Available: " + this.HoursAvailable;
        }
    }
}
