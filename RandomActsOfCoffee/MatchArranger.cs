using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;
using RandomActsOfCoffee.Entities.HrisApi;

namespace RandomActsOfCoffee
{
    public class MatchArranger
    {
        public void ArrangeRandomActsOfCoffee(IMatchAlerter matchAlerter)
        {
            var consumer = new HrisApiConsumer();
            ProfilesIndex profilesIndex = consumer.GetProfilesIndex("namely");
            List<Profile> profiles = profilesIndex.profiles.Where(p => p.user_status == "active").ToList();

            var transformer = new ProfilesToEmployeesTransformer();
            List<Employee> employees = transformer.TransformProfilesToEmployees(profiles);

            var matchMaker = new MatchArranger();
            var matches = matchMaker.MakeMatches(employees, 100);
            matchAlerter.AlertMatches(matches);
        }

        public List<Match> MakeMatches(List<Employee> employees, int matchesToMake)
        {
            var matches = new List<Match>();

            var random = new Random();

            //attempt to satisfy matchesToMake until employees are all removed
            for (int i = 0; i < matchesToMake; i++)
            {
                if (employees.Any())
                {
                    //pick first employee
                    var randomIndex = random.Next(0, employees.Count());
                    var firstEmployee = employees[randomIndex];
                    employees.Remove(firstEmployee);

                    //pick second employee
                    var coworkers = employees.Where(e => e.StateWorksIn == firstEmployee.StateWorksIn).ToList();
                    if (coworkers.Any())
                    {
                        randomIndex = random.Next(0, coworkers.Count());
                        var secondEmployee = coworkers[randomIndex];
                        employees.Remove(secondEmployee);

                        var match = new Match()
                        {
                            EmployeeOne = firstEmployee,
                            EmployeeTwo = secondEmployee
                        };

                        //TODO:
                        //needs logic to filter out combinations that have already happened
                        //needs to persist somehow for this
                        matches.Add(match);
                    }
                }
            }

            return matches;
        }

    }
}
