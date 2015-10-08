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
            var dynamoDbMatchLogger = new DynamoDbMatchLogger();
            var matchArranger = new MatchArranger(dynamoDbMatchLogger, emailMatchAlerter);
            matchArranger.ArrangeRandomActsOfCoffee(2);

            Console.ReadLine();
        }
    }
}

