using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Schedule
    {
        String startTime;
        String endTime;
        String workDate;
        String shifts;

        public String StartTime
        {
            get
            {
                return this.startTime;
            }
            set
            {
                DateTime time = new DateTime();

                this.startTime = value;
            }
        }
    }
}
