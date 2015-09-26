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
            //TODO:
            //email them
        }

        private String GetNamelyProfileUrl(String id)
        {
            //TODO:
            return "";
        }
    }
}
