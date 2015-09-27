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
            var emailMatchAlerter = new EmailMatchAlerter();
            var sqlMatchLogger = new SqlMatchLogger();
            var matchArranger = new MatchArranger(sqlMatchLogger, emailMatchAlerter);
            matchArranger.ArrangeRandomActsOfCoffee(100);
        }
    }
}
