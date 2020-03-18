using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Schedule : Staff
    {
        private bool isAvailable;

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

        public Schedule(String firstName, String lastName, String role, DateTime startTime, DateTime endTime, DateTime workDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;
            this.IsAvailable = true;
        }

        public void UpdateSchedule( String firstName, String lastName, String role, DateTime startTime, DateTime endTime, DateTime workDate )
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.WorkDate = workDate;
            this.IsAvailable = true;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.Role + " " + this.StartTime + " " + this.EndTime + " " + this.WorkDate + " " + this.IsAvailable;
        }
    }
}
