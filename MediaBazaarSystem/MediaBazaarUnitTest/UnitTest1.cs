using System;
using MediaBazaarSystem;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaBazaarUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestToStringMan()
        {
            String FirstName = "John";
            String LastName = "Doe";
            int Age = 20;
            String Address = "Eindhoven";
            String Role = "Manager";
            int Salary = 2000;
            int HoursAvailable = 40;
            Manager man = new Manager(1, FirstName, LastName, Age, DateTime.Now.Date, Address, Role, Salary, HoursAvailable, "doe@gmail.com", Contract.PartTime);


            String expectedToString = "First name: " + FirstName + " Last name: " + LastName + " Age: " + Age + " Address: " + Address + " Role: " + Role + " Salary: " + Salary + " Hours Available: " + HoursAvailable;
            String actualResult = man.ToString();


            Assert.AreEqual(expectedToString, actualResult);
        }

        [TestMethod]
        public void TestToStringEmp()
        {
            String FirstName = "John";
            String LastName = "Doe";
            int Age = 20;
            String Address = "Eindhoven";
            String Role = "Employee";
            int Salary = 2000;
            int HoursAvailable = 40;
            Employee man = new Employee(1, FirstName, LastName, Age, DateTime.Now.Date, Address, Role, Salary, HoursAvailable, "doe@gmail.com", Contract.PartTime);


            String expectedToString = "First name: " + FirstName + " Last name: " + LastName + " Age: " + Age + " Address: " + Address + " Role: " + Role + " Salary: " + Salary + " Hours Available: " + HoursAvailable;
            String actualResult = man.ToString();


            Assert.AreEqual(expectedToString, actualResult);
        }
    }
}
