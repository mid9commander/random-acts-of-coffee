using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;

namespace RandomActsOfCoffee
{
    public class EmailMatchAlerter : IMatchAlerter
    {
        public void AlertMatches(IEnumerable<Match> matches)
        {
            foreach (var match in matches)
            {
                AlertMatch(match);
            }
        }

        private void AlertMatch(Match match)
        {
            AlertEmployee(match.EmployeeOne, match.EmployeeTwo);
            AlertEmployee(match.EmployeeTwo, match.EmployeeOne);
        }

        private void AlertEmployee(Employee matcher, Employee matchee)
        {
            //TODO: email
            var blurb = "Hey, {0}, you've been matched with {1} {2} by the Random Act of Coffee bot! Check out their profile in Namely: {3}";
            Console.WriteLine(blurb
                , matcher.FirstName
                , matchee.FirstName
                , matchee.LastName
                , GetNamelyProfileUrl((matchee.Id)));
        }

        private String GetNamelyProfileUrl(String id)
        {
            return String.Format("https://namely.namely.com/profiles/{0}", id);
        }
    }
}
