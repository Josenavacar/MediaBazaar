using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Department
    {
        private int ID;
        private String name;
        private List<Employee> employees;
        private List<Manager> managers;
        private List<Schedule> schedules;

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
            employees = new List<Employee>();
            managers = new List<Manager>();
            schedules = new List<Schedule>();
            DepartmentID = ID;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }
        public void DeleteManager(Manager manager)
        {
            managers.Remove(manager);
        }

        public void AddManager(Manager manager)
        {
            managers.Add(manager);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public List<Manager> GetManagers()
        {
            return managers;
        }

        public Employee GetEmployee(String firstname, String lastname)
        {
            Employee emp = null;
            foreach(Employee employee in employees)
            {
                if( employee.FirstName == firstname && employee.LastName == lastname)
                {
                    emp = employee;
                }
            }
            return emp;
        }

        public Manager GetManager( String firstname, String lastname )
        {
            Manager man = null;
            foreach( Manager manager in managers )
            {
                if( manager.FirstName == firstname && manager.LastName == lastname )
                {
                    man = manager;
                }
            }
            return man;
        }

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
