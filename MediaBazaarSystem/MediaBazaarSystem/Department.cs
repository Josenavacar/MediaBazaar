using MySql.Data.MySqlClient;
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

        /**
         * Constructor
         */
        public Department(String name, int ID)
        {
            this.Name = name;
            this.DepartmentID = ID;
            staff = new List<Staff>();
            schedules = new List<Schedule>();
        }

        /**
         * Method to add staff 
         */
        public void AddStaffMember(Staff employed)
        {
            staff.Add(employed);
        }

        /**
         * Method to delete staff
         */
        public void DeleteStaffMember(Staff unemployed)
        {
            staff.Remove(unemployed);
        }

        /**
         * Method to get staff 
         */
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

        /**
         * Overload method to get staff
         */
        public Staff GetStaffMember( String name )
        {
            foreach( Staff person in staff )
            {
                if( person.FirstName + " " + person.LastName == name )
                {
                    return person;
                }
            }
            return null;
        }

        /**
         * Method to get schedule
         */
        public Schedule GetSchedule(int employeeID, DateTime workDate )
        {
            foreach(Schedule schedule in schedules)
            {
                if(schedule.EmployeeID == employeeID && schedule.WorkDate == workDate)
                {
                    return schedule;
                }
            }

            return null;
        }

        /**
         * Method to return all staff members
         */
        public List<Staff> GetStaff()
        {
            return this.staff;
        }

        /**
         * Method to add schedule
         */
        public void AddSchedule(Schedule schedule)
        {
            schedules.Add(schedule);
        }

        /**
         * Method to return schedules
         */
        public List<Schedule> GetSchedules()
        {
            return this.schedules;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
