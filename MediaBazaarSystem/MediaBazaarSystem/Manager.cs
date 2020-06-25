using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarSystem
{
    public class Manager : Staff
    {
        /**
         * Constructor for HR manager
         */
        public Manager( int ID, String firstName, String lastName, DateTime birthDate, String address, double salary,  int hoursAvailable, String email, Contract contract ) : base(ID, firstName, lastName, birthDate, address, salary, hoursAvailable, email, contract)
        {
            Role = Position.HRManager;
        }

        /**
         * Constructor for Stock manager
         */
        public Manager( int ID, String firstName, String lastName, DateTime birthDate, String address, double salary, int hoursAvailable, String email, Contract contract, int passCode ) : base( ID, firstName, lastName, birthDate, address, salary, hoursAvailable, email, contract, passCode )
        {
            Role = Position.StockManager;
        }

        /**
         * Method to return data in string
         */
        public override string ToString()
        {
            return "First name: " + this.FirstName + " Last name: " + this.LastName +
                " Age: " + this.Age + " Address: " + this.Address +
                " Role: " + this.Role + " Salary: " + this.Salary +
                " Hours Available: " + this.HoursAvailable;
        }
    }
}
