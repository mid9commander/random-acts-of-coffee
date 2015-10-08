using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomActsOfCoffee.Entities;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;

namespace RandomActsOfCoffee
{
    public class DynamoDbMatchLogger : IMatchLogger
    {
        private readonly AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        private readonly List<Match> _preexistingMatches;

        public DynamoDbMatchLogger()
        {
            _preexistingMatches = new List<Match>();

            //grab all the existing matches
            List<DynamoDbMatch> dynamoDbMatches;
            using (var context = new DynamoDBContext(client))
            {
                dynamoDbMatches = context.Scan<DynamoDbMatch>().ToList();
            }

            foreach(var dynamoDbMatch in dynamoDbMatches)
            {
                _preexistingMatches.Add(ToMatch(dynamoDbMatch));
            }
        }

        public void LogMatches(IEnumerable<Match> matches)
        {
            using (var context = new DynamoDBContext(client))
            {
                var dynamoDbMatches = new List<DynamoDbMatch>();
                foreach(var match in matches)
                {
                    dynamoDbMatches.Add(ToDynamoDbMatch(match));
                }

                var batchWriter = context.CreateBatchWrite<DynamoDbMatch>();
                batchWriter.AddPutItems(dynamoDbMatches);
                batchWriter.Execute();
            }
        }

        public Boolean IsAPreexistingMatch(Match match)
        {
            foreach (var preexistingMatch in _preexistingMatches)
            {
                if (preexistingMatch.EmployeeOne.Id == match.EmployeeOne.Id && preexistingMatch.EmployeeTwo.Id == match.EmployeeTwo.Id)
                    return true;
                else if (preexistingMatch.EmployeeOne.Id == match.EmployeeTwo.Id && preexistingMatch.EmployeeTwo.Id == match.EmployeeOne.Id)
                    return true;
            }
            return false;
        }

        private Match ToMatch(DynamoDbMatch dynamoDbMatch)
        {
            return new Match()
            {
                EmployeeOne = new Employee() { Id = dynamoDbMatch.EmployeeOneGuid },
                EmployeeTwo = new Employee() { Id = dynamoDbMatch.EmployeeTwoGuid }
            };
        }

        private DynamoDbMatch ToDynamoDbMatch(Match match)
        {
            return new DynamoDbMatch()
            {
                EmployeeOneGuid = match.EmployeeOne.Id,
                EmployeeTwoGuid = match.EmployeeTwo.Id
            };
        }
    }
}
