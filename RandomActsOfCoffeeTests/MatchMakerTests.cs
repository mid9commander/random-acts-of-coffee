using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RandomActsOfCoffee;
using RandomActsOfCoffee.Entities;

namespace RandomActsOfCoffeeTests
{
    [TestFixture]
    class MatchMakerTests
    {
        [TestCase(2, 1, 1)]
        [TestCase(2, 2, 1)]
        [TestCase(9, 5, 4)]
        [TestCase(10, 100, 5)]
        [TestCase(100, 50, 50)]
        [TestCase(1000, 500, 500)]
        public void MakeMatches(int employeesToSupply, int matchesToMake, int matchesMade)
        {
            var employees = new List<Employee>();
            for (int i = 0; i < employeesToSupply; i++)
                employees.Add(GetRandomEmployee());

            var matchMaker = new MatchMaker();
            var matches = matchMaker.GetMatches(employees, matchesToMake);

            Assert.AreEqual(matchesMade, matches.Count());
        }

        [TestCase(20, 10, 10, 10)]
        [TestCase(10, 10, 10, 10)]
        [TestCase(1, 0, 1, 1)]
        public void DoNotMatchEmployeesFromDifferentStates(int matchesToMake
                                                           ,int matchesMade
                                                           ,int employeesFromNewYork
                                                           ,int employeesFromCalifornia)
        {
            var employees = new List<Employee>();

            for (int i = 0; i < employeesFromNewYork; i++)
                employees.Add(GetRandomEmployee("NY"));

            for (int i = 0; i < employeesFromCalifornia; i++)
                employees.Add(GetRandomEmployee("CA"));

            var matchMaker = new MatchMaker();
            var matches = matchMaker.GetMatches(employees, matchesToMake);

            Assert.AreEqual(matchesMade, matches.Count());
        }

        private Employee GetRandomEmployee(String stateWorksIn = "")
        {
            return new Employee()
            {
                StateWorksIn = stateWorksIn
            };
        }
    }
}
