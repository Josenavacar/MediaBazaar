using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MediaBazaarSystem
{
    public class Department
    {
        private int ID;
        private String name;
        //private List<Employee> employees;
        //private List<Manager> managers;
        private List<Schedule> schedules;

        private List<Staff> staff;

        public int DepartmentID
        {
            get { return this.ID; }
            private set { this.ID = value; }
        }

        public String Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Department(String name, int ID)
        {
            this.Name = name;

            staff = new List<Staff>();
            //employees = new List<Employee>();
            //managers = new List<Manager>();
            schedules = new List<Schedule>();
            DepartmentID = ID;
        }
        public void AddStaffMember(Staff employed)
        {
            staff.Add(employed);
        }
        public void DeleteStaffMember(Staff unemployed)
        {
            staff.Remove(unemployed);
        }

        public Staff GetStaffMember(String firstname, String lastname)
        {
            foreach(Staff person in staff)
            {
                if(person.FirstName == firstname && person.LastName == lastname)
                {
                    return person;
                }
            }
            return null;
        }

        public List<Staff> GetStaff()
        {
            return this.staff;
        }


        //public void AddEmployee(Staff employee)
        //{

        //    employees.Add(employee);
        //}
        //public void DeleteEmployee(Staff employee)
        //{
        //    employees.Remove(employee);
        //}
        //public void DeleteManager(Staff manager)
        //{
        //    managers.Remove((Manager) manager);
        //}

        //public void AddManager(Staff manager)
        //{
        //    managers.Add((Manager) manager);
        //}

        //public List<Employee> GetEmployees()
        //{
        //    return employees;
        //}

        //public List<Manager> GetManagers()
        //{
        //    return managers;
        //}

        //public Employee GetEmployee(String firstname, String lastname)
        //{
        //    Employee emp = null;
        //    foreach(Employee employee in employees)
        //    {
        //        if( employee.FirstName == firstname && employee.LastName == lastname)
        //        {
        //            emp = employee;
        //        }
        //    }
        //    return emp;
        //}

        //public Manager GetManager( String firstname, String lastname )
        //{
        //    Manager man = null;
        //    foreach( Manager manager in managers )
        //    {
        //        if( manager.FirstName == firstname && manager.LastName == lastname )
        //        {
        //            man = manager;
        //        }
        //    }
        //    return man;
        //}

        public override string ToString()
        {
            return this.Name;
        }

        public void AddSchedule( Schedule schedule )
        {
            schedules.Add( schedule );
        }

        public List<Schedule> GetSchedules()
        {
            return this.schedules;
        }
    }
}
