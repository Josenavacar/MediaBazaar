using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Schedule
    {
        private bool isAvailable;

        public int dbID
        {
            get;
            set;
        }

        public String FirstName
        {
            get;
            set;
        }

        public String LastName
        {
            get;
            set;
        }

        public String Role
        {
            get;
            set;
        }

        public DateTime StartTime
        {
            get;
            set;
        }

        public DateTime EndTime
        {
            get;
            set;
        }

        public DateTime WorkDate
        {
            get;
            set;
        }

        public bool IsAvailable
        {
            get
            {
                return this.isAvailable;
            }
            set
            {
                this.isAvailable = value;
            }
        }

        public String DepartmentName
        {
            get;
            set;
        }

        public int EmployeeID
        {
            get;
            private set;
        }

        public Schedule(int dbID, String firstName, String lastName, String role, DateTime startTime, DateTime endTime, DateTime workDate, String departmentName, int employeeID)
        {
            this.dbID = dbID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;
            this.IsAvailable = true;
            this.DepartmentName = departmentName;
            this.EmployeeID = employeeID;
        }

        public void UpdateSchedule( int dbID, String firstName, String lastName, String role, DateTime startTime, DateTime endTime, DateTime workDate, String departmentName )
        {
            this.dbID = dbID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;
            this.IsAvailable = true;
            this.DepartmentName = departmentName;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.Role + " " + this.StartTime.ToString( "hh:mm tt" ) + " " + this.EndTime.ToString( "hh:mm tt" ) + " " + this.WorkDate.ToString( "dddd, dd MMMM yyyy" ) + " " + this.IsAvailable + " " + this.DepartmentName;
        }
    }
}
