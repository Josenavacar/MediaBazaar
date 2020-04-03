using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Manager : Staff
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

        public DateTime dateOfBirth
        {
            get { return this.birthDate; }
            private set { this.birthDate = value; }
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

        public Contract Contract
        {
            get { return this.contract; }
            private set { this.contract = value; }
        }

        public Manager( int ID, String firstName, String lastName, int age, DateTime birthDate, String address, String role, double salary,  int hoursAvailable, String email, Contract contract ) //hours worked deleted
        {
            dbID = ID;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            dateOfBirth = birthDate;
            Address = address;
            Role = role;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
            Contract = contract;
        }

        public void EditManager(String firstName, String lastName, DateTime birthDate, String address, String role, double salary, int hoursAvailable, String email, Contract contract)
        {
            FirstName = firstName;
            LastName = lastName;
            dateOfBirth = birthDate;

            //Calculate age
            int tempage = birthDate.Year - DateTime.Now.Year - 1;
            if (birthDate.Month > DateTime.Now.Month)
            {
                tempage++;
            }
            else if (birthDate.Month == DateTime.Now.Month)
            {
                if (birthDate.Day >= DateTime.Now.Day)
                {
                    tempage++;
                }
            }
            Age = tempage;
            
            Address = address;
            Role = role;
            Salary = salary;
            HoursAvailable = hoursAvailable;
            Email = email;
            Contract = contract;
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
