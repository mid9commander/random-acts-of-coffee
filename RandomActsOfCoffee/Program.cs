using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomActsOfCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            var coffeeGod = new MatchArranger();
            var emailMatchAlerter = new EmailMatchAlerter();
            coffeeGod.ArrangeRandomActsOfCoffee(emailMatchAlerter);
        }
    }
}
