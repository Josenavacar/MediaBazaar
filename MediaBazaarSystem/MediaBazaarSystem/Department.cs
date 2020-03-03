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

        public int DepartmentID
        {
            get;
            set;
        }

        public String NAME
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Department(String name)
        {
            employees = new List<Employee>();
            managers = new List<Manager>();
            //Name = name;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
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
            Employee ans = null;
            foreach(Employee aux in employees)
            {
                if(aux.FirstN == firstname && aux.LastN == lastname)
                {
                    ans = aux;
                }
            }
            return ans;
        }

        //public List<Staff> GetStaffs()
        //{
        //    return null;
        //}
    }
}
