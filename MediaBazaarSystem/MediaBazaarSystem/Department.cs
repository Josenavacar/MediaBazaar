using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Department
    {
        private String name;
        private List<Employee> employees;
        private List<Manager> managers;

        public String NAME
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Department(String name)
        {
            employees = new List<Employee>();
            managers = new List<Manager>();
            NAME = name;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
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

        //public List<Staff> GetStaffs()
        //{
        //    return null;
        //}
    }
}
